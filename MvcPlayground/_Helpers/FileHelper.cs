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
            string res = HttpContext.Current.Server.MapPath(path + "/" + file.FileName);
            //file.SaveAs(path + file.FileName)
            return res;
        }

        public static string SaveImage(HttpPostedFileBase file)
        {
            return SaveFile(file, "~/Uploads/Images");
        }
    }
}