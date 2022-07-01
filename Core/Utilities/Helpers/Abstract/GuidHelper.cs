using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.Abstract
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
            //burada yüklediğimiz dosya için eşsiz bir isim oluşturduk.
            //yani dosya eklerken dosyanın adı kendi olmasın
        }
    }
}
