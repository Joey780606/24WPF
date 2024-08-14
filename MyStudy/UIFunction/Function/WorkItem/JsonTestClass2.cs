using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFunction.Function.WorkItem
{
    public class JsonTestClass2
    {
        public string Version { get; set; }
        public string HIDVersion { get; set; }
        public IList<string> ImageInfo { get; set; }
        public IList<string> Software { get; set; }
        public IList<string> HIDFileName { get; set; }
        public List<PairInfo> VersionPair;
    }

    public class PairInfo
    {
        public String Launcher_ver {  get; set; }
        public FWVerName FW_MIN { get; set; }
        public List<FWVerName> Special_List { get; set; }
    }

    public class FWVerName
    {
        public string FW_MIN_Ver { get; set; }
        public string FW_File_Name { get; set; }

        public FWVerName(String fw_min_ver, String fw_file_name)
        {
            FW_MIN_Ver = fw_min_ver;
            FW_File_Name = fw_file_name;
        }
    }
}
