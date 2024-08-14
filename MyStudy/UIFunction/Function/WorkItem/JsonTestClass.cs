using System;
using System.Collections.Generic;
using System.Data;  //For DataSet
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFunction.Function.WorkItem
{
    public class JsonTestClass
    {
        public string Version { get; set; }
        public string HIDVersion { get; set; }
        public IList<string> ImageInfo { get; set; }
        public IList<string> Software { get; set; }
        public IList<string> HIDFileName { get; set; }

        //public DataSet appFwVerMatch  { get; set; }
        public Dictionary<string, string> VersionPair { get; set; }
    }
}
