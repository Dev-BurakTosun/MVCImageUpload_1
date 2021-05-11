using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCImageUpload_1.Tools
{
    public static class ImageUploader
    {
        public static string UploadImage(string serverPath,HttpPostedFileBase file)
        {
            if (file!=null)
            {
                Guid uniqueName = Guid.NewGuid();

                string[] fileArray = file.FileName.Split('.');// burdaki split metodu sayesinde ilgili yapının uzantısının da içeride bulunduğu bir string string dizisi almış olduk. Split metodu belirttiğiniz char karakterinden metni bölerek size bir array sunar.

                string extension = fileArray[fileArray.Length - 1].ToLower();


                string fileName = $"{uniqueName}.{extension}"; // normal şartlar altında biz burda Guid kullandığımız için asla bir dosya ismi aynı olmayacaktır. Lakin siz Guid kullanmazsanız (kullanıcıya yüklemek istediği dosyanın ismini girdirebilirsiniz.) Böyle bir durum söz konusu ise ek olarak bir kontrol yapmanız gerekir.

                if (extension=="jpg"||extension=="gif"||extension=="jpeg")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+fileName)))
                    {
                        return "1"; // Dosya zaten var kodu.
                    }
                    else
                    {
                        string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    return "2"; // Seçilen dosya resim değildir.
                }
            }
            else
            {
                return "3"; //Dosya boş kodu.
            }

        }
    }
}