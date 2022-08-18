using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParserWinForms
{
    public class ParserConfig
    {
        public string BaseUrl { get; set; }

        public string TitleTag { get; set; }

        public string ContentTag { get; set; }
    }
}
