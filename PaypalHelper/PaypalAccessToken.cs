using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayPayCore.PaypalHelper
{
    public class PaypalAccessToken
    {
        public string scope { get; set; }
        public string access_token { get; set; }
        public string access_type { get; set; }
        public string app_id { get; set; }
        public int expires_in { get; set; }
        public string nonce { get; set; }
    }
}
