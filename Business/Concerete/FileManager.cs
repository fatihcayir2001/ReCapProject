using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;

namespace Business.Concerete
{
    public class FileManager : IFileProcess
    {
        private readonly IHostingEnvironment environment;
        string FileDirectory;
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\Images\\";

        /// <summary>
        /// Upload to server's assets folder
        /// </summary>
        /// <param name="fileName">Guid File Name</param>
        /// <param name="file">Image</param>
        /// <returns></returns>
        public async Task<IResult> Upload(string fileName, IFormFile file)
        {
            

            CheckDirectoryExists(_currentDirectory+_folderName);
            CreateImageFile(_currentDirectory+_folderName+fileName,file);
            var result = new SuccessResult((_folderName + fileName).Replace("\\", "/"));
            if (result.Success==true)
            {
                return result;
            }

            return new ErrorResult("Yükleme başarısız, file manageri kontrol edin");


        }
        /// <summary>
        /// Delete file from given path
        /// </summary>
        /// <param name="path">Guid file path</param>
        /// <returns></returns>
        public IResult Delete(string path)
        {
            var roadpath = Path.Combine(FileDirectory, path + ".png");
            if (File.Exists(roadpath))
            {
                File.Delete(roadpath);
            }
            return new SuccessResult();
        }


        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("Wrong file type.");
            }
            return new SuccessResult();
        }
    }


}
