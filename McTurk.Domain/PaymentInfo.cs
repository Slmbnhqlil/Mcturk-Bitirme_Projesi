using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTurk.Domain
{
    public class PaymentInfo
    {
        public string CardTitle { get; set; }
        public string CardNumber { get; set; }
        public string CardCVC { get; set; }
        public string CustomerPhone { get; set; }
        public string Amount { get; set; }
    }
}
