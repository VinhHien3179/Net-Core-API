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
    public class RDStoreInfo
    {
        [Key]
        public int StoreID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Logo { get; set; }
        public string Phone { get; set; }
    }
}
