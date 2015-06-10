using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasAssertionModel
{
    public class CasAuthTicket
    {
        public String Identity { get; set; }
        public String ServiceTicket { get; set; }
        public String OriginatingService { get; set; }

        public DateTime ValidFromDate { get; set; }
        public DateTime ValidUntilDate { get; set; }

        public Dictionary<String, IList<String>> Attributes { get; set; }

        public CasAuthTicket()
        {
            this.Attributes = new Dictionary<string, IList<string>>();
        }

            
    }
}
