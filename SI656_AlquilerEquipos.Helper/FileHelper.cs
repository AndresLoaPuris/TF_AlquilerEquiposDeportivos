using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SI656_AlquilerEquipos.Helper
{
    public static class FileHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file">File we are going to save</param>
        /// <param name="basePath">Path where the file is going to be saved</param>
        /// <returns>The actual path where the file will be located</returns>
        public static string GetPath(this HttpPostedFileBase file, string basePath)
        {
            try
            {
                var filename = $"{Guid.NewGuid().ToString().Split('-')[1]}_{DateTime.Now.Ticks}_{file.FileName}";
                var path = basePath + filename;
                return path;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return String.Empty;
            }
        }

        public static String UploadImageFile(HttpPostedFileBase file, string path)
        {

            var nameImage = "";

            if (file != null && file.ContentLength != 0)
            {

                if (file.ContentLength > ConstantHelper.ONE_MEGA_BYTES)
                {
                    throw new ArgumentException("El archivo debe pesar menos de 1Mb");
                }

                //  Check for valid image
                var extension = file.FileName.Split('\\').Last().Split('.').Last();

                if (ConstantHelper.EXTENSION_IMAGEN.Contains(extension.ToUpper()))
                {
                    var directoryInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(path));
                    if (!directoryInfo.Exists)
                    {
                        directoryInfo.Create();
                    }

                    //  Save the incoming image
                    var fileName = (Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName)).ToUpper();
                    var pathDriverImage = HttpContext.Current.Server.MapPath(path + "\\" + fileName);
                    file.SaveAs(pathDriverImage);

                    //Resize image
                    var img = Image.FromFile(pathDriverImage);
                    var newImage = ConvertHelper.ResizeImage(img, 200, 200);

                    //Dispose not resized image
                    img.Dispose();
                    //Delete the not resized image
                    System.IO.File.Delete(pathDriverImage);
                    //Save new Image
                    newImage.Save(pathDriverImage);

                    nameImage = fileName;
                }
            }
            return nameImage;
        }

        public static string UploadFile(HttpPostedFileBase file, string path, string prePath)
        {
            var nameFile = "";

            if (file != null && file.ContentLength != 0)
            {
                var directoryInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(path));
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }

                //  Save the incoming image
                var fileName = (Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName)).ToUpper();
                var pathDriverFile = HttpContext.Current.Server.MapPath(path + "\\" + fileName);
                file.SaveAs(pathDriverFile);

                nameFile = $"{prePath}{fileName}";
            }
            return nameFile;
        }
    }

}
