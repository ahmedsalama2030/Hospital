using Microsoft.AspNetCore.Http;
using System;
 

namespace Web.Areas.Admin.helper
{
    public static class RequestPagination
    {
        public static RequestQuery RequestQeury(this HttpRequest request)
        {
             var sortColumnName = request.Query["orderName"];
            var requestQuery = new RequestQuery()
            {
                length = Convert.ToInt32(request.Query["length"]),
                start = Convert.ToInt32(request.Query["start"]),
                draw= Int32.Parse(request.Query["draw"]),
                sortColumnName = sortColumnName,
                sortDirection = request.Query["orderDir"],
                filterType = request.Query["filterType"],
                filterText = request.Query["filterText"],
            };
            return requestQuery;
        }
    }
}
 