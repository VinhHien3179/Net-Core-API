using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model.Model.Comon
{
    public class rsData
    {
        public rsData()
        {
            status = 0;
            message = "Successful";
            extended_data = new Dictionary<string, object>();
        }

        public Dictionary<string, object> extended_data { get; set; }
        public int status { get; set; }
        public string message { get; set; }
        public object obj_data { get; set; }
    }
}
