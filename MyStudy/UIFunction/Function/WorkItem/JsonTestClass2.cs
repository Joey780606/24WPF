using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFunction.Function.WorkItem
{
    public class JsonTestClass2
    {
        public string APPVersion { get; set; }          //App program version
        public string FWVersion { get; set; }           //HID program version
        public IList<string> ImageInfo { get; set; }    //IGDB info
        public IList<string> APPName { get; set; }      //App software name
        public IList<string> FWName { get; set; }       //HID software name
        public IList<PairInfo> FWVersionPair { get; set; }  //HID update limitation
    }

    public class PairInfo
    {
        public String Launcher_ver {  get; set; }
        public FWVerName FW_MIN { get; set; }
        public List<FWVerName> Except_List { get; set; }
    }

    public class FWVerName
    {
        public string FW_Ver { get; set; }
        public string FW_File_Name { get; set; }

        public FWVerName(String fw_ver, String fw_file_name)
        {
            FW_Ver = fw_ver;
            FW_File_Name = fw_file_name;
        }
    }
}
