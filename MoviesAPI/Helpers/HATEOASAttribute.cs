using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Helpers
{
    public class HATEOASAttribute : ResultFilterAttribute
    {
        protected bool ShouldINcludeHATEOAS(ResultExecutingContext context)
        {
            var result = context.Result as ObjectResult;
            if (!IsSuccessfulResponse(result))
            {
                return false;
            }

            var header = context.HttpContext.Request.Headers["IncludeHATEOAS"];
            if (header.Count == 0)
            {
                return false;
            }

            var value = header[0];
            if (!value.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            return true;
        }

        private bool IsSuccessfulResponse(ObjectResult result)
        {
            if (result == null)
            {
                return false;
            }

            if (result.StatusCode.HasValue && !result.StatusCode.Value.ToString().StartsWith("2"))
            {
                return false;
            }

            return true;
        }
    }
}
