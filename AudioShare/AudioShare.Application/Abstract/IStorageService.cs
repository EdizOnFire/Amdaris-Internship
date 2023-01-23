using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioShare.Application.Abstract
{
    public interface IStorageService
    {
        void Upload(IFormFile formFile);
        void Delete(string fileName);
    }
}
