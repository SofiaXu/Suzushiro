using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuzushiroBackend.Models
{
    public class JsonWebTokenModel
    {
        public string Secert { get; set; } = "C25D7877936F93F23DEC59F7CB0292BE";

        public string Issuer { get; set; } = "Suzushiro";

        public string Audience { get; set; } = "Suzushiro";

        public int AccessExpiration { get; set; } = 109500;

        public int RefreshExpiration { get; set; } = 219000;
    }
}
