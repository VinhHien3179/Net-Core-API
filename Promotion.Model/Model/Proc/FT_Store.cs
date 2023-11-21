using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model.Model.Proc
{
    public class FT_Store
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UTCTime { get; set; }
        public string UTCName { get; set; }
        public DateTime? ExpDate { get; set; }
        public int? Status { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Logo { get; set; }
        public string Phone { get; set; }
    }
}
