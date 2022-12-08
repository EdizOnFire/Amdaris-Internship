using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEditor.Application.Abstract
{
    public interface IStorageService
    {
        void Upload(IFormFile formFile);
    }
}
