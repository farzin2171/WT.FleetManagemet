using System.Collections.Generic;

namespace WT.MobileWebService.Contract.V1.Responses
{
    public class AuthFailResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
