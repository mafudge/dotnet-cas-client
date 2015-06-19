using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public string toJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
            
    } //end class 

    public static class CasAuthTicketExtensions
    {
        public static CasAuthTicket fromJSON(this CasAuthTicket ticket, string JSONstring)
        {
            return ticket = JsonConvert.DeserializeObject<CasAuthTicket>(JSONstring);
        }

        public static string toBase64(this CasAuthTicket ticket)
        {
            string json = ticket.toJSON();
            return Base64Utility.EncodeTo64(json);
        }

        public static CasAuthTicket fromBase64(this CasAuthTicket ticket,  string base64string )
        {
            string json = Base64Utility.DecodeFrom64(base64string);
            return ticket.fromJSON(json);
        }
    }
}
