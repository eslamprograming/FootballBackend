using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helper
{
    public static class UploadFile
    {
        public static object Save(IFormFile file)
        {
            Stream fileStream = GetFileAsStream("credentials.json");
            string folderId = "13DT57LBrkmKR0CGCd6qQ159r8pdi-Z5F";
            var obj=UploadFileToGoogleDrive(file,folderId, fileStream);
            return obj;
        }

        //private static object UploadFileToGoogleDrive(string credentialspath, string folderId, string fileToUpload)
        //{
        //    try
        //    {
        //        GoogleCredential credential;
        //        using (var stream = new FileStream(credentialspath, FileMode.Open, FileAccess.Read))
        //        {
        //            credential = GoogleCredential.FromStream(stream).CreateScoped(new[]
        //            {
        //                DriveService.ScopeConstants.DriveFile
        //            });
        //            var service = new DriveService(new BaseClientService.Initializer()
        //            {
        //                HttpClientInitializer = credential,
        //                ApplicationName = "Google Drive Upload Console App"
        //            });
        //            var FileMetaData = new Google.Apis.Drive.v3.Data.File()
        //            {
        //                Name = Path.GetFileName(fileToUpload),
        //                Parents = new List<string> { folderId }
        //            };
        //            FilesResource.CreateMediaUpload request;
        //            using (var stream1 = new FileStream(fileToUpload, FileMode.Open))
        //            {
        //                request = service.Files.Create(FileMetaData, stream1,"");
        //                request.Fields = "id";
        //                request.Upload();
        //            }
        //            var uploadfile = request.ResponseBody;
        //            return uploadfile;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // يمكنك التعامل مع الاستثناءات هنا أو تسجيلها لمزيد من التحليل.
        //        return $"Error: {ex.Message}";
        //    }
        //}
        private static object UploadFileToGoogleDrive(IFormFile file, string folderId, Stream credentialsStream)
        {
            try
            {
                var credential = GoogleCredential.FromStream(credentialsStream)
                    .CreateScoped(new[] { DriveService.ScopeConstants.DriveFile });

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Drive Upload Console App"
                });

                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(file.FileName),
                    Parents = new List<string> { folderId }
                };

                FilesResource.CreateMediaUpload request;

                using (var stream = file.OpenReadStream())
                {
                    request = service.Files.Create(fileMetadata, stream, file.ContentType);
                    request.Fields = "id";
                    request.Upload();
                }

                var uploadedFile = request.ResponseBody;
                return uploadedFile;
            }
            catch (Exception ex)
            {
                // يمكنك التعامل مع الاستثناءات هنا أو تسجيلها لمزيد من التحليل.
                return $"Error: {ex.Message}";
            }
        }
       
        public static Stream GetFileAsStream(string fileName)
        {
            try
            {
                // استخدام مسار المشروع للوصول إلى الملف
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                // قراءة المحتوى من الملف ونسخه إلى MemoryStream
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin); // إعادة تعيين المؤشر إلى بداية الـ Stream
                    return memoryStream;
                }
            }
            catch (Exception ex)
            {
                // التعامل مع الاستثناءات هنا
                return null; // أو يمكنك رمي الاستثناء هنا
            }
        }


    }
}
