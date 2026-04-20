using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public Result(bool success,string message) : this(success)
        {
            Message = message;
        }
        // this yapısı ile alttaki default ctor'un da çalışmasını sağlıyoruz.
        // sadece success gönderilirse alttaki , hem succes hem message gönderilirse ustteki calısır
        public Result(bool success)
        {
            Success = success;
        }
    }
}
