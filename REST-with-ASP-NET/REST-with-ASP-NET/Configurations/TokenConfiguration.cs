using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_with_ASP_NET.Configurations
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int Minutes { get; set; }
        public int DaysToExpiry { get; set; }
    }
}
