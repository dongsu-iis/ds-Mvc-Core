using System;
using System.Collections.Generic;
using System.Text;

namespace ds.NorthwindApp.Service.Interface
{
    public interface IResult
    {
        Guid ID { get; }

        bool Success { get; set; }

        string Message { get; set; }

        Exception Exception { get; set; }

        List<IResult> InnerResults { get; }

    }
}
