using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model.Model.Table
{
    [Table("RD_STORE")]
    public class RDStore
    {
        [Key]
        public int StoreID { get; set; }
        public string Email { get; set; }
        public string StoreName { get; set; }
        public string Password { get; set; }
        public string UTCTime { get; set; }
        public string UTCName { get; set; }
        public DateTime? ExpDate { get; set; }
        public int? Status { get; set; }
    }
}
