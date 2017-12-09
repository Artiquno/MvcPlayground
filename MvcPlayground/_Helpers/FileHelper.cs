using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPlayground.Helpers
{
    public static class FileHelper
    {
        public const string ImagePath = "~/Uploads/Images";

        public static string SaveFile(HttpPostedFileBase file, string path = "~/Uploads")
        {
            string filename = System.Web.HttpUtility.UrlEncode(file.FileName);
            string res = HttpContext.Current.Server.MapPath(path + "/" + filename);
            file.SaveAs(res);
            return path.Replace("~", "") + "/" + filename;
        }

        public static string SaveImage(HttpPostedFileBase file)
        {
            return SaveFile(file, ImagePath);
        }
    }
}