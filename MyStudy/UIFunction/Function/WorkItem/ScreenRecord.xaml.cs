using ScreenRecorderLib;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.Diagnostics;

/*
 * Author: Joey Yang
 * Reference: https://github.com/sskodje/ScreenRecorderLib?tab=readme-ov-file
 * Theme: ScreenRecorderLib library study
 */
namespace UIFunction.Function.WorkItem
{
    /// <summary>
    /// Interaction logic for ScreenRecord.xaml
    /// </summary>
    public partial class ScreenRecord : UserControl
    {
        Recorder _rec;

        public ScreenRecord()
        {
            InitializeComponent();
        }

        private RecorderOptions getRecorderOption()
        {
            List<AudioDevice> inputDevices = Recorder.GetSystemAudioDevices(AudioDeviceSource.InputDevices);
            List<AudioDevice> outputDevices = Recorder.GetSystemAudioDevices(AudioDeviceSource.OutputDevices);
            AudioDevice selectedOutputDevice = outputDevices.FirstOrDefault();//select one of the devices.. Passing empty string or null uses system default playback device.
            AudioDevice selectedInputDevice = inputDevices.FirstOrDefault();//select one of the devices.. Passing empty string or null uses system default recording device.
            //Debug.Write(selectedOutputDevice);
            //Debug.Write(selectedInputDevice);
            Debug.WriteLine("OutputDevice result: " + selectedOutputDevice + "===");
            Debug.WriteLine("InputDevice result: " + selectedInputDevice + "===");

            //These options must be set before starting the recording, and cannot be modified while recording.
            RecorderOptions options = new RecorderOptions
            {
                //SourceOptions = new SourceOptions
                //{
                //    //Populate and pass a list of recordingsources.
                //    RecordingSources = new List<RecordingSourceBase>()
                //},
                //OutputOptions = new OutputOptions
                //{
                //    RecorderMode = RecorderMode.Video,
                //    //This sets a custom size of the video output, in pixels.
                //    OutputFrameSize = new ScreenSize(1920, 1080),
                //    //Stretch controls how the resizing is done, if the new aspect ratio differs.
                //    Stretch = StretchMode.Uniform,
                //    //SourceRect allows you to crop the output.
                //    SourceRect = new ScreenRect(100, 100, 500, 500)
                //},
                AudioOptions = new AudioOptions
                {
                    Bitrate = AudioBitrate.bitrate_128kbps,
                    Channels = AudioChannels.Stereo,
                    IsAudioEnabled = true,
                },
                //VideoEncoderOptions = new VideoEncoderOptions
                //{
                //    Bitrate = 8000 * 1000,
                //    Framerate = 60,
                //    IsFixedFramerate = true,
                //    //Currently supported are H264VideoEncoder and H265VideoEncoder
                //    Encoder = new H264VideoEncoder
                //    {
                //        BitrateMode = H264BitrateControlMode.CBR,
                //        EncoderProfile = H264Profile.Main,
                //    },
                //    //Fragmented Mp4 allows playback to start at arbitrary positions inside a video stream,
                //    //instead of requiring to read the headers at the start of the stream.
                //    IsFragmentedMp4Enabled = true,
                //    //If throttling is disabled, out of memory exceptions may eventually crash the program,
                //    //depending on encoder settings and system specifications.
                //    IsThrottlingDisabled = false,
                //    //Hardware encoding is enabled by default.
                //    IsHardwareEncodingEnabled = true,
                //    //Low latency mode provides faster encoding, but can reduce quality.
                //    IsLowLatencyEnabled = false,
                //    //Fast start writes the mp4 header at the beginning of the file, to facilitate streaming.
                //    IsMp4FastStartEnabled = false
                //},
                //MouseOptions = new MouseOptions
                //{
                //    //Displays a colored dot under the mouse cursor when the left mouse button is pressed.	
                //    IsMouseClicksDetected = true,
                //    MouseLeftClickDetectionColor = "#FFFF00",
                //    MouseRightClickDetectionColor = "#FFFF00",
                //    MouseClickDetectionRadius = 30,
                //    MouseClickDetectionDuration = 100,
                //    IsMousePointerEnabled = true,
                //    /* Polling checks every millisecond if a mouse button is pressed.
                //       Hook is more accurate, but may affect mouse performance as every mouse update must be processed.*/
                //    MouseClickDetectionMode = MouseDetectionMode.Hook
                //},
                //OverlayOptions = new OverLayOptions
                //{
                //    //Populate and pass a list of recording overlays.
                //    Overlays = new List<RecordingOverlayBase>()
                //},
                //SnapshotOptions = new SnapshotOptions
                //{
                //    //Take a snapshot of the video output at the given interval
                //    SnapshotsWithVideo = false,
                //    SnapshotsIntervalMillis = 1000,
                //    SnapshotFormat = ImageFormat.PNG,
                //    //Optional path to the directory to store snapshots in
                //    //If not configured, snapshots are stored in the same folder as video output.
                //    SnapshotsDirectory = ""
                //},
                //LogOptions = new LogOptions
                //{
                //    //This enabled logging in release builds.
                //    IsLogEnabled = true,
                //    //If this path is configured, logs are redirected to this file.
                //    LogFilePath = "recorder.log",
                //    LogSeverityLevel = ScreenRecorderLib.LogLevel.Debug
                //}
            };
            return options;
        }

        private void StartRecord_Click(object sender, RoutedEventArgs e)
        {
            _rec = Recorder.CreateRecorder(getRecorderOption());    //加入選項
            //_rec = Recorder.CreateRecorder();
            _rec.OnRecordingComplete += Rec_OnRecordingComplete;
            _rec.OnRecordingFailed += Rec_OnRecordingFailed;
            _rec.OnStatusChanged += Rec_OnStatusChanged;
            //Record to a file
            Debug.WriteLine("Path result: " + System.IO.Path.GetTempPath() + "===");    //C:\Users\yty06\AppData\Local\Temp\
            string videoPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "testJoey2.mp4");
            _rec.Record(videoPath);
        }

        private void Rec_OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
        {
            //Get the file path if recorded to a file
            string path = e.FilePath;
        }
        private void Rec_OnRecordingFailed(object sender, RecordingFailedEventArgs e)
        {
            string error = e.Error;
        }
        private void Rec_OnStatusChanged(object sender, RecordingStatusEventArgs e)
        {
            RecorderStatus status = e.Status;
        }

        private void StopRecord_Click(object sender, RoutedEventArgs e)
        {
            _rec.Stop();
        }
    }
}
