using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.Abstract
{
    public interface IFileHelper
    {
        IResult Upload(IFormFile file, string root);
        IResult Delete(string filePath);
        IResult Update(IFormFile file, string filePath, string root);
    }
}
