using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIFunction.Function.WorkItem
{
    /// <summary>
    /// JsonTest.xaml 的互動邏輯
    /// </summary>
    public partial class JsonTest : UserControl
    {
        String gJsonInfo = "";
        String gJsonInfo2 = "";
        public JsonTest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Build Json structure from class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JsonTest1_Click(object sender, RoutedEventArgs e)
        {
            // https://www.newtonsoft.com/json/help/html/SerializeDataSet.htm
            //DataSet mySWFWMatch = JoinDataSet();

            JsonTestClass jsonTestClass = new JsonTestClass
            {
                Version = "0.6.99.0",
                HIDVersion = "1.1.9.0",
                ImageInfo = new List<string>
                {
                    "lsbltSxzSYJT91t34oqgN9zFvJkQcDh8Vhm7WUGyYe9rHMeCfFwf0nOIAVAVP+kE70sB8EXSM0bdoRfJ/ILmBouJqhcsPhGy",
                    "isQpycQnjeiyrjRj4THS7aL/5PqQEFA3A6XZVwZq9Tty0awWgDyWhptK0sYjk1fIR5LhNnELunYpQPz/pZDMlzZRpKUQ9YOO",
                    "Mwxqf2JYQXlA8fwF3YSfcyIHj+XvTWPSGscaeH28K1vjW6V+RKDzNetv54YCzQkBBhvFgjmW9WY5rB2ruZhLw04ISOMFqT1N"
                },
                Software = new List<string>
                {
                    "Setup_v0.6.99.0.msi",
                    ""
                },
                HIDFileName = new List<string>
                {
                    "LBQ1590_V1.1.9.bin",
                    ""
                },
                VersionPair = new Dictionary<string, string>
                {
                    { "0.6.0.0", "1.1.9.0,LBQ1590_V1.1.9.bin" },
                    { "0.6.99.0", "1.1.9.0,LBQ1590_V1.1.9.bin" }
                }

                //appFwVerMatch = mySWFWMatch
            };

            gJsonInfo = JsonConvert.SerializeObject(jsonTestClass, Formatting.Indented);
            Debug.WriteLine("Json result:" + gJsonInfo);
        }

        private DataSet JoinDataSet()
        {
            DataSet mySWFWMatch = new DataSet();
            mySWFWMatch.Namespace = "NetFrameWork";
            DataTable table = new DataTable();
            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.AutoIncrement = true;
            DataColumn swColumn = new DataColumn("swVer", typeof(string));
            DataColumn fwColumn = new DataColumn("fwVer", typeof(string));
            DataColumn fwNameColumn = new DataColumn("fwNameVer", typeof(string));
            table.Columns.Add(idColumn);
            table.Columns.Add(swColumn);
            table.Columns.Add(fwColumn);
            table.Columns.Add(fwNameColumn);
            mySWFWMatch.Tables.Add(table);

            DataRow newRow = table.NewRow();
            newRow["swVer"] = "0.6.99.0";
            newRow["fwVer"] = "1.1.9.0";
            newRow["fwNameVer"] = "LBQ1590_V1.1.9.bin";
            table.Rows.Add(newRow);

            mySWFWMatch.AcceptChanges();
            return mySWFWMatch;
        }

        /// <summary>
        /// Change Json to class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JsonTest2_Click(object sender, RoutedEventArgs e)
        {
            JsonTestClass? jsonTestClass = JsonConvert.DeserializeObject<JsonTestClass>(gJsonInfo);

            if (jsonTestClass != null)
            {
                Debug.WriteLine("ImageInfo:" + jsonTestClass.ImageInfo[0] + " , " + jsonTestClass.VersionPair["0.6.0.0"]);
                //Debug.WriteLine("ImageInfo:" + jsonTestClass.ImageInfo[0] + " , " + jsonTestClass.appFwVerMatch.Tables["Table1"] );

                //if (jsonTestClass.appFwVerMatch.Tables["Table1"] != null)
                //{
                //    DataTable dataTable = jsonTestClass.appFwVerMatch.Tables["Table1"];
                //    foreach (DataRow row in dataTable.Rows)
                //    {
                //        Debug.WriteLine("tableInfo:" + row["swVer"] + " , " + row["fwVer"] + " , " + row["fwNameVer"]);
                //    }
                //}
            }
        }

        private void JsonTest3_Click(object sender, RoutedEventArgs e)
        {
            // Case 1: Old app version and don't have higher FW version, update app at first
            //string NowAppVersion = "0.5.0.0";
            //string NowFWVersion = "1.1.9.0";

            // Case 2: Old app version and have new FW version, check FW status and update FW at first
            // (Tonie want this version)
            //string NowAppVersion = "0.6.0.0";
            //string NowFWVersion = "1.1.8.0";

            // Case 3: App have latest version and have new FW version, update FW at first
            // (Tonie want this version)
            string NowAppVersion = "0.6.99.0";
            string NowFWVersion = "1.1.8.0";

            bool isHaveNewApp = false;
            bool isHaveNewFW = false;

            // Case 3: Old app version and have higher FW version, check FW status and update FW at first

            JsonTestClass? jsonTestClass = JsonConvert.DeserializeObject<JsonTestClass>(gJsonInfo);

            if (jsonTestClass != null)
            {
                //Debug.WriteLine("ImageInfo:" + jsonTestClass.ImageInfo[0] + " , " + jsonTestClass.VersionPair["0.6.0.0"]);
                string verNewApp = jsonTestClass.Version;
                string verNewFW = jsonTestClass.HIDVersion;
                string verNowAvailableFW = "";
                try {
                    verNowAvailableFW = jsonTestClass.VersionPair[NowAppVersion];
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Restart err:" + ex.Message);
                    verNowAvailableFW = "";
                }

                string highestFWVer = "";
                string highestFWFile = "";
                if (String.IsNullOrEmpty(verNowAvailableFW))
                {
                    verNowAvailableFW = "";
                }
                else
                {
                    var temp = verNowAvailableFW.Split(',');
                    if (temp.Count() >= 2)
                    {
                        highestFWVer = temp[0];
                        highestFWFile = temp[1];
                    }
                }

                Version vNowAppVersion = new Version(NowAppVersion);
                Version vNewAppVersion = new Version(verNewApp);
                if(vNewAppVersion > vNowAppVersion)
                {
                    isHaveNewApp = true;
                    Debug.WriteLine($"You have a new app to download: {vNewAppVersion}, old:{vNowAppVersion}");
                }


                Debug.WriteLine($"Info: {verNewApp}, {verNewFW}, {verNowAvailableFW}, {highestFWVer}, {highestFWFile}");
                if (highestFWVer != "")
                {
                    Version nowFWVersion = new Version(NowFWVersion);
                    Version higherFWVersion = new Version(highestFWVer);
                    if (nowFWVersion < higherFWVersion)
                    {
                        isHaveNewFW = true;
                        Debug.WriteLine($"FW need to update, now:{nowFWVersion.ToString()}, server side: {higherFWVersion.ToString()}");
                    }
                    else
                        Debug.WriteLine($"FW doesn't need to update, now:{nowFWVersion.ToString()}, server side: {higherFWVersion.ToString()}");
                } else
                {
                    Debug.WriteLine($"Server doesn't have higher version info"); 
                }

                if(isHaveNewFW)
                {
                    Debug.WriteLine($"Result: Have new FW, update FW at first");
                } else if (isHaveNewApp)
                {
                    Debug.WriteLine($"Result: No new FW, but can update app");
                } else
                {
                    Debug.WriteLine($"Result: Don't update any SW");
                }

                // Launcher取FW的方法
                //version = await getHIDFWVersion();
                //if (version != string.Empty)
                //RegistryHelper.Instance.CheckHIDFWVersion(version);

                //驗證版本的方法 (重要)
                //Version curVersion = new Version(verValue);
                //Version serverVersion = new Version(hidFWVersion.Version);

                //if (curVersion < serverVersion)
                //{
                //    result = await DownloadFile("NEW_FW", hidFWVersion.FileName);
                //}

                //if (result)
                //{
                //    ValueSet request = new ValueSet();
                //    request.Add("Type", "NEW_HID_FW");
                //    request.Add("Value", hidFWVersion.FileName);
                //    ((MainWindow)myWindow).ServiceSendMessage(request);    //Important
                //}
            }
        }

        private void JsonTest4_Click(object sender, RoutedEventArgs e)
        {
            JsonTestClass2 jsonTestClass2 = new JsonTestClass2();
            jsonTestClass2.FWVersionPair = new List<PairInfo>();

            // Initial
            jsonTestClass2.APPVersion = "0.6.99";
            jsonTestClass2.FWVersion = "1.1.9";
            jsonTestClass2.ImageInfo = new List<string>
                {
                    "lsbltSxzSYJT91t34oqgN9zFvJkQcDh8Vhm7WUGyYe9rHMeCfFwf0nOIAVAVP+kE70sB8EXSM0bdoRfJ/ILmBouJqhcsPhGy",
                    "isQpycQnjeiyrjRj4THS7aL/5PqQEFA3A6XZVwZq9Tty0awWgDyWhptK0sYjk1fIR5LhNnELunYpQPz/pZDMlzZRpKUQ9YOO",
                    "Mwxqf2JYQXlA8fwF3YSfcyIHj+XvTWPSGscaeH28K1vjW6V+RKDzNetv54YCzQkBBhvFgjmW9WY5rB2ruZhLw04ISOMFqT1N"
                };
            jsonTestClass2.APPName = new List<string>
            {
                    "Setup_v0.6.99.msi",
                    ""
            };
            jsonTestClass2.FWName = new List<string>
            {
                    "LBQ1590_V1.1.9.bin",
                    ""
            };

            // First version
            PairInfo pairInfo1 = new PairInfo();
            pairInfo1.Launcher_ver = "0.6.0";
            FWVerName FW_MIN1 = new FWVerName("1.1.9", "File1190.hex");
            pairInfo1.FW_MIN = FW_MIN1;

            FWVerName Except_List1 = new FWVerName("1.1.5", "File1150.hex");
            FWVerName Except_List2 = new FWVerName("1.1.7", "File1170.hex");
            pairInfo1.Except_List = new List<FWVerName>() { Except_List1, Except_List2 };

            jsonTestClass2.FWVersionPair.Add(pairInfo1);

            // Second version
            PairInfo pairInfo2 = new PairInfo();
            pairInfo2.Launcher_ver = "0.5.0";
            FWVerName FW_MIN2 = new FWVerName("1.1.3", "File1190.hex");
            pairInfo2.FW_MIN = FW_MIN2;

            FWVerName SpecicalList3 = new FWVerName("1.1.5", "File1150.hex");
            FWVerName SpecicalList4 = new FWVerName("1.1.4", "File1140.hex");
            pairInfo2.Except_List = new List<FWVerName>() { SpecicalList3, SpecicalList4 };

            jsonTestClass2.FWVersionPair.Add(pairInfo2);

            gJsonInfo2 = JsonConvert.SerializeObject(jsonTestClass2, Formatting.Indented);
            Debug.WriteLine("Json result2:" + gJsonInfo2);
        }

        private void JsonTest5_Click(object sender, RoutedEventArgs e)
        {
            // Case 1: Old app version and don't have higher FW version, update app at first
            string NowAppVersion = "0.5.0.0";
            string NowFWVersion = "1.1.8.0";

            // Case 2: Old app version and don't have higher FW version, but fw can't be update due to except limitation
            //string NowAppVersion = "0.5.0.0";
            //string NowFWVersion = "1.1.4.0";

            // Case 3: Old app version and have new FW version, check FW status and update FW at first
            // (Tonie want this version)
            //string NowAppVersion = "0.6.0.0";
            //string NowFWVersion = "1.1.8.0";

            // Case 4: App have latest version and have new FW version, update FW at first
            // (Tonie want this version)
            //string NowAppVersion = "0.7.0.0";
            //string NowFWVersion = "1.1.3.0";

            // Case 5: App & FW version are the latest.  Don't need to update.
            //string NowAppVersion = "0.7.0.0";
            //string NowFWVersion = "1.1.10.0";

            // Case 6: No VersionPair status

            JsonTestClass2? jsonTestClass2 = JsonConvert.DeserializeObject<JsonTestClass2>(gJsonInfo2);
            if (jsonTestClass2 != null)
            {
                //Debug.WriteLine("ImageInfo:" + jsonTestClass.ImageInfo[0] + " , " + jsonTestClass.VersionPair["0.6.0.0"]);
                string verNewApp = jsonTestClass2.APPVersion;
                string verNewFW = jsonTestClass2.FWVersion;
                //string verNowAvailableFW = "";
                //List<PairInfo> verPairInfo = new();

                Version vNowAppVer = new Version(NowAppVersion);
                Version vNowFWVer = new Version(NowFWVersion);
                Version vNewAppVer = new Version(verNewApp);
                Version vNewFWVer = new Version(verNewFW);
                bool isFWCanUpdate = false;
                bool isAPPCanUpdate = false;

                if (VerCompareWithoutRevision(vNowAppVer, vNewAppVer) < 0)
                    isAPPCanUpdate = true;
                if (VerCompareWithoutRevision(vNowFWVer, vNewFWVer) < 0)
                {
                    isFWCanUpdate = true;
                    if(jsonTestClass2.FWVersionPair != null)    //Check FW download rule
                    {
                        foreach (PairInfo info in jsonTestClass2.FWVersionPair)    //All app files have their FW rule
                        {
                            Version itemAppVer = new Version(info.Launcher_ver);
                            if (VerCompareWithoutRevision(vNowAppVer, itemAppVer) == 0)
                            {
                                Version itemMinFWVersion = new Version(info.FW_MIN.FW_Ver);
                                Debug.WriteLine($"Test1:{vNowFWVer.CompareTo(itemMinFWVersion)}");
                                if (vNowFWVer.CompareTo(itemMinFWVersion) > 0)  //FW can update if larger then FW minimum version
                                {
                                    List<FWVerName> fwExcept = info.Except_List;    //FW can't update if present version is in except list
                                    //isFWCanUpdate = true;
                                    if (fwExcept != null)
                                    {
                                        if (fwExcept.Count > 0)
                                        {
                                            foreach (FWVerName exceptInfo in fwExcept)
                                            {
                                                Version exceptHIDVersion = new Version(exceptInfo.FW_Ver);
                                                if (VerCompareWithoutRevision(vNowFWVer, exceptHIDVersion) == 0)
                                                {
                                                    isFWCanUpdate = false;
                                                    break;
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }

                }
                Debug.WriteLine($"FW can update?:{isFWCanUpdate}");
                Debug.WriteLine($"APP can update?:{isAPPCanUpdate}");
                

                // Launcher取FW的方法
                //version = await getHIDFWVersion();
                //if (version != string.Empty)
                //RegistryHelper.Instance.CheckHIDFWVersion(version);

                //驗證版本的方法 (重要)
                //Version curVersion = new Version(verValue);
                //Version serverVersion = new Version(hidFWVersion.Version);

                //if (curVersion < serverVersion)
                //{
                //    result = await DownloadFile("NEW_FW", hidFWVersion.FileName);
                //}

                //if (result)
                //{
                //    ValueSet request = new ValueSet();
                //    request.Add("Type", "NEW_HID_FW");
                //    request.Add("Value", hidFWVersion.FileName);
                //    ((MainWindow)myWindow).ServiceSendMessage(request);    //Important
                //}
                //// }
            }
        }

        private int VerCompareWithoutRevision(Version ver1, Version ver2)
        {
            //Debug.WriteLine($"verinfo:{ver1.}");
            if ((ver1.Major == ver2.Major) && (ver1.Minor == ver2.Minor) && (ver1.Build == ver2.Build))
                return 0;
            else
            {
                int returnValue = -1;
                if (ver1.Major > ver2.Major)
                    returnValue = 1;
                else if(ver1.Minor > ver2.Minor)
                    returnValue = 1;
                else if (ver1.Build > ver2.Build)
                    returnValue = 1;
                return returnValue;
            }
        }

        private void JsonTest6_Click(object sender, RoutedEventArgs e)
        {
            string NowAppVersion = "0.5.0";
            string NowAppVersion2 = "0.5.1";
            string NowFWVersion = "1.1.9";

            string NewAppVersion = "0.5.0.0";
            string NewAppVersion2 = "0.5.0";

            Version vNowAppVer = new Version(NowAppVersion);
            Version vNowAppVer2 = new Version(NowAppVersion2);
            Version vNowFWVer = new Version(NowFWVersion);
            Version vNewAppVer = new Version(NewAppVersion);
            Version vNewAppVer2 = new Version(NewAppVersion2);

            if (vNowAppVer == vNowFWVer)
                Debug.WriteLine($"Test 01: NowAppVersion = NewAppVersion");
            Debug.WriteLine($"Test 02: {vNowAppVer.CompareTo(vNewAppVer)}");
            Debug.WriteLine($"Test 021: {vNowAppVer2.CompareTo(vNewAppVer)}");
            Debug.WriteLine($"Test 03: {vNowAppVer.Major}  {vNowAppVer.Revision} | {vNewAppVer.Major}  {vNewAppVer.Revision}");
            Debug.WriteLine($"Test 04: {vNowAppVer.CompareTo(vNewAppVer2)}");
        }
    }
}
