using System;
using System.Collections.Generic;

namespace MVC_Repository_Service.Misc
{
    //在兩個介面中的 Create, Update, Delete 所回傳的型別是 IResult，這是我自己建立的型別
    public interface IResult
    {
        Guid ID { get; }
        bool Success { get; set; }
        string Message { get; set; }
        Exception Exception { get; set; }
        List<IResult> InnerResults { get; }
    }
}