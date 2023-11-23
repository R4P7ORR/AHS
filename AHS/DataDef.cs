using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHS
{
    public class DataDef
    {
        public int id { get; set; }
        public string patient { get; set; }
        public string hospital { get; set; }
        public int debt { get; set; }
        public bool insured { get; set; }
        public List<operationTypes> operationLogs { get; set; }
    }
    public class operationTypes
    {
        public string name { get; set; }
        public int cost { get; set; }
    }
}
