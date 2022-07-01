using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
   public interface IDataResult<T>:IResult
    {
        //IResult referansını tutar ve aynı zamanda data döndürebilir
        T Data { get; }
    }
}
