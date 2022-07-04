using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)//Success değilse, logic hatalıysa
                {
                    return logic;//parametreyle gönderilen iş kurallarından başarısız olanı business a geri bildiriyoruz
                }
            }
            return null;
        }
    }
}
