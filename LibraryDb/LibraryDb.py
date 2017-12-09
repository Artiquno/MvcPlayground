import os
import eyed3
import pyodbc
import json
import sys
from math import floor

db_data = {}
home = os.path.expanduser("~")

conn = pyodbc.connect(Trusted_connection = True, driver = "{SQL Server}", server = "ARTIQUNO\ARTIQUNO", database = "Playground")

def get_data(query, collection):
	"""Get existing values from database"""
	global db_data, conn
	cursor = conn.cursor()
	cursor.execute(query)
	row = cursor.fetchone()

	db_data[collection] = {}
	while row:
		db_data[collection][row[1]] = row[0]
		row = cursor.fetchone()

		
def get_all_data():
	""" Get all relevant data from the database """
	db_calls = {
		"artists": "SELECT Id, Name FROM Artists",
		"albums": "SELECT Id, Title FROM Albums",
		"genres": "SELECT Id, Name FROM Genres",
		"songs": "SELECT Id, Title FROM Songs"
	}
	for key, query in db_calls.items():
		get_data(query, key)

def insert_artist(song):
	""" Insert artist to database
	Artist data is taken from song's info
	"""
	global conn, db_data
	artist = song.tag.artist

	cursor = conn.cursor()
	cursor.execute("INSERT INTO Artists (Name) VALUES (?)", (artist,))
	conn.commit()

	cursor.execute("SELECT @@IDENTITY")
	db_data["artists"][artist] = cursor.fetchone()[0]
	pass

def insert_album(song):
	""" Insert album in database
	Album data is taken from song's info
	"""
	global conn, db_data
	album = song.tag.album

	if song.tag.artist not in db_data["artists"]:
		insert_artist(song)
	artist_id = db_data["artists"][song.tag.artist]

	cursor = conn.cursor()
	cursor.execute("INSERT INTO Albums (ArtistId, Title, Cover, Tracks, Discs, Downloads) VALUES (?, ?, NULL, ?, ?, ?)", (artist_id, album, 1, 1, 0))
	conn.commit()

	cursor.execute("SELECT @@IDENTITY")
	db_data["albums"][album] = cursor.fetchone()[0]

def insert_genre(song):
	""" Insert genre in database
	Genre data is taken from song's info
	"""
	global conn, db_data
	genre = str(song.tag.non_std_genre)

	cursor = conn.cursor()
	cursor.execute("INSERT INTO Genres (Name) VALUES (?)", (genre,))
	conn.commit()

	cursor.execute("SELECT @@IDENTITY")
	db_data["genres"][genre] = cursor.fetchone()[0]

def add_song(song):
	""" Add song to insertion query
	Returns value to be appended to existing query
	"""
	global db_data

	if song.tag.artist is None:
		return ("", ())

	if song.tag.album not in db_data["albums"].keys():
		insert_album(song)

	genre = str(song.tag.non_std_genre)
	if genre not in db_data["genres"].keys():
		insert_genre(song)
	
	album_id = db_data["albums"][song.tag.album]
	genre_id = db_data["genres"][genre]

	lyrics = ""
	if song.tag.lyrics:
		for lyric in song.tag.lyrics:
			lyrics += lyric.text + "\n"

	query = "(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?), "
	items = (
		album_id,
		genre_id,
		1,
		song.tag.title,
		str(song.tag.best_release_date.year) if song.tag.best_release_date else "2017",
		song.info.time_secs,
		song.tag.track_num[0] if song.tag.disc_num[0] is not None else 1,
		song.tag.disc_num[0] if song.tag.disc_num[0] is not None else 1,
		1,
		song.tag.comments.get("").text[:2048] if song.tag.comments.get("") is not None else "",
		lyrics[:2048],
		None,
		0)
	return (query, items)

def save_library():
	""" Save library from ~/Music into database """
	global home, conn
	library_path = home + r"\Music"
	os.chdir(library_path)

	songs = os.listdir()
	cursor = conn.cursor()
	query = "INSERT INTO Songs (AlbumId, GenreId, FileId, Title, ReleaseDate, Length, TrackNr, DiscNr, Rating, Comments, Lyrics, Cover, Downloads) VALUES "
	items = ()
	for index, song in enumerate(songs):
		if song.find(" - ") == -1 or song.find(".mp3") == -1:
			continue

		song_data = eyed3.load(song)
		if song_data.tag.artist is None:
			continue

		q, i = add_song(song_data)
		query += q
		items += i
		if index % floor(2100 / len(i)) == 0:
			query = query[:-2]

			cursor.execute(query, items)
			conn.commit()

			query = "INSERT INTO Songs (AlbumId, GenreId, FileId, Title, ReleaseDate, Length, TrackNr, DiscNr, Rating, Comments, Lyrics, Cover, Downloads) VALUES "
			items = ()

	if(len(items) > 0):
		query = query[:-2]

		cursor.execute(query, items)
		conn.commit()

get_all_data()
#print(json.dumps(db_data, indent = 4, separators = (",", ": ")))
save_library()
