using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFileProcess
    {
        public Task<IResult> Upload(string fileName, IFormFile fileList);
        public IResult Delete(string path);
    }
}
