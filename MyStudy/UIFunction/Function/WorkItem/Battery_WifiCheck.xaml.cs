using ManagedNativeWifi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
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
    /// Interaction logic for Battery_WifiCheck.xaml
    /// </summary>
    public partial class Battery_WifiCheck : UserControl
    {
        private ManagementEventWatcher batteryChangeWatcher;
        public Battery_WifiCheck()
        {
            InitializeComponent();
        }

        // Check battery
        private void BatteryCheckOn_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Battery start to check");
            if (batteryChangeWatcher == null)
            {
                WqlEventQuery query = new WqlEventQuery("SELECT * FROM __InstanceModificationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_Battery'");
                batteryChangeWatcher = new ManagementEventWatcher(query);
                batteryChangeWatcher.EventArrived += new EventArrivedEventHandler(battery_EventArrived);
                batteryChangeWatcher.Start();
            }

        }

        private void battery_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject mo = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value;
            int batteryStatus = Convert.ToInt32(mo["BatteryStatus"]);
            //int batteryPercentage = (int)mo["EstimatedChargeRemaining"];
            int batteryPercentage = Convert.ToInt32(mo["EstimatedChargeRemaining"]);
            //var batteryPercentage = Convert.ToString(mo["EstimatedChargeRemaining"]);
            Debug.WriteLine($"The battery level is {batteryStatus}, {batteryPercentage}");
        }

        private void BatteryCheckOff_Click(object sender, RoutedEventArgs e)
        {
            if (batteryChangeWatcher != null)
            {
                batteryChangeWatcher.Stop();
                batteryChangeWatcher.EventArrived -= battery_EventArrived;
                batteryChangeWatcher = null;
            }
            Debug.WriteLine($"Battery stop check");
        }

        private void BatteryInitialcheck_Click(object sender, RoutedEventArgs e)
        {
            ManagementClass mc = new ManagementClass("Win32_Battery");
            ManagementObjectCollection moc = mc.GetInstances();

            ManagementObjectCollection.ManagementObjectEnumerator mom = moc.GetEnumerator();
            if (mom.MoveNext())
            {
                Debug.WriteLine("EstimatedChargeRemaining: \t{0} {1}%", mom.Current.Properties["BatteryStatus"].Value, mom.Current.Properties["EstimatedChargeRemaining"].Value);
            }
        }

        private void WifiCheck1_Click(object sender, RoutedEventArgs e)
        {
            // 取得所有網路介面
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            // 尋找 Wi-Fi 介面並檢查連線狀態
            foreach (NetworkInterface networkInterface in interfaces)
            {
                Debug.WriteLine($"Network type:{networkInterface.NetworkInterfaceType}");
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    if (networkInterface.OperationalStatus == OperationalStatus.Up)
                    {
                        //  networkInterface.
                        Debug.WriteLine($"Wifi is up");
                    }
                    else
                    {
                        Debug.WriteLine($"Wifi is down");
                    }
                }
            }

        //https://stackoverflow.com/questions/1686715/c-sharp-how-do-i-access-the-wlan-signal-strength-and-others
        }

        /// <summary>
        /// User Nuget: ManagedNativeWifi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WifiCheck2_Click(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine("===== Usable Interfaces =====");
            //foreach (var interfaceInfo in NativeWifi.EnumerateInterfaces())
            //{
            //    Debug.WriteLine($"Interface: {interfaceInfo.Description} ({interfaceInfo.Id})");
            //}

            Debug.WriteLine("===== Usable Interface Connections =====");
            foreach (var interfaceInfo in NativeWifi.EnumerateInterfaceConnections())
            {
                Debug.WriteLine($"{{Interface: {interfaceInfo.Description} ({interfaceInfo.Id})");
                Debug.WriteLine($" Connection: {interfaceInfo.ConnectionMode}");
                Debug.WriteLine($" RadioOn: {interfaceInfo.IsRadioOn}");
                Debug.WriteLine($" Connected: {interfaceInfo.IsConnected}");
                Debug.WriteLine($" Profile: {interfaceInfo.ProfileName}}}");
            }

            //Debug.WriteLine("===== Available Network SSIDs =====");
            //foreach (var ssid in NativeWifi.EnumerateAvailableNetworkSsids())
            //{
            //    Debug.WriteLine($"SSID: {ssid}");
            //}

            //Debug.WriteLine("===== Connected Network SSIDs =====");
            //foreach (var ssid in NativeWifi.EnumerateConnectedNetworkSsids())
            //{
            //    Debug.WriteLine($"SSID: {ssid}");
            //}

            Debug.WriteLine("===== Available Networks =====");
            foreach (var network in NativeWifi.EnumerateAvailableNetworks())
            {
                Debug.WriteLine($"{{Interface: {network.Interface.Description} ({network.Interface.Id})");
                Debug.WriteLine($" SSID: {network.Ssid}");
                Debug.WriteLine($" BssType: {network.BssType}");
                Debug.WriteLine($" SignalQuality: {network.SignalQuality}");
                Debug.WriteLine($" Security: {network.IsSecurityEnabled}}}");
            }

            //Debug.WriteLine("===== Available Network Groups =====");
            //foreach (var network in NativeWifi.EnumerateAvailableNetworkGroups())
            //{
            //    Debug.WriteLine($"{{Interface: {network.Interface.Description} ({network.Interface.Id})");
            //    Debug.WriteLine($" SSID: {network.Ssid}");
            //    Debug.WriteLine($" BssNetworks: {network.BssNetworks.Count}");
            //    Debug.WriteLine($" SignalQuality: {network.SignalQuality}");
            //    Debug.WriteLine($" LinkQuality: {network.LinkQuality}");
            //    Debug.WriteLine($" Band: {network.Band} GHz");
            //    Debug.WriteLine($" Channel: {network.Channel}}}");
            //}

            //Debug.WriteLine("===== BSS Networks =====");
            //foreach (var network in NativeWifi.EnumerateBssNetworks())
            //{
            //    Debug.WriteLine($"{{Interface: {network.Interface.Description} ({network.Interface.Id})");
            //    Debug.WriteLine($" SSID: {network.Ssid}");
            //    Debug.WriteLine($" BssType: {network.BssType}");
            //    Debug.WriteLine($" BSSID: {network.Bssid}");
            //    Debug.WriteLine($" PhyType: {network.PhyType} 802.11{network.PhyType.ToProtocolName()}");
            //    Debug.WriteLine($" SignalStrength: {network.SignalStrength}");
            //    Debug.WriteLine($" LinkQuality: {network.LinkQuality}");
            //    Debug.WriteLine($" Frequency: {network.Frequency} KHz");
            //    Debug.WriteLine($" Band: {network.Band} GHz");
            //    Debug.WriteLine($" Channel: {network.Channel}}}");
            //}

            //Debug.WriteLine("===== Network Profile Names =====");
            //foreach (var name in NativeWifi.EnumerateProfileNames())
            //{
            //    Debug.WriteLine($"Name: {name}");
            //}

            //Debug.WriteLine("===== Network Profiles =====");
            //foreach (var profile in NativeWifi.EnumerateProfiles())
            //{
            //    Debug.WriteLine($"{{Name: {profile.Name}");
            //    Debug.WriteLine($" Interface: {profile.Interface.Description} ({profile.Interface.Id})");
            //    Debug.WriteLine($" SSID: {profile.Document.Ssid}");
            //    Debug.WriteLine($" BssType: {profile.Document.BssType}");
            //    Debug.WriteLine($" Authentication: {profile.Document.Authentication}");
            //    Debug.WriteLine($" Encryption: {profile.Document.Encryption}");
            //    Debug.WriteLine($" AutoConnect: {profile.Document.IsAutoConnectEnabled}");
            //    Debug.WriteLine($" AutoSwitch: {profile.Document.IsAutoSwitchEnabled}");
            //    Debug.WriteLine($" Position: {profile.Position}}}");
            //}

            //Debug.WriteLine("===== Network Profile Radios =====");
            //foreach (var profile in NativeWifi.EnumerateProfileRadios())
            //{
            //    Debug.WriteLine($"{{Name: {profile.Name}");
            //    Debug.WriteLine($" Interface: {profile.Interface.Description} ({profile.Interface.Id})");
            //    Debug.WriteLine($" SSID: {profile.Document.Ssid}");
            //    Debug.WriteLine($" RadioOn: {profile.IsRadioOn}");
            //    Debug.WriteLine($" Connected: {profile.IsConnected}");
            //    Debug.WriteLine($" SignalQuality: {profile.SignalQuality}");
            //    Debug.WriteLine($" LinkQuality: {profile.LinkQuality}");
            //    Debug.WriteLine($" Band: {profile.Band} GHz");
            //    Debug.WriteLine($" Channel: {profile.Channel}}}");
            //}
        }
    }
}
