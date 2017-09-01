using CSCore;
using CSCore.Codecs.WAV;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;
using CSCore.Streams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordSound
{
    
    enum CaptureMode
    {
        Capture = 1,
        // ReSharper disable once UnusedMember.Local
        LoopbackCapture = 2
    }
    public partial class RecordSoundWithPcm : Form
    {

        Stopwatch objStopWatch = new Stopwatch();
        public string _FileName = @"C:\RecordingAudio\recording.wav";
        public string _folderPath = @"C:\RecordingAudio";

        //Change this to CaptureMode.Capture to capture a microphone,...


        private CaptureMode CaptureMode ;
        private MMDevice _selectedDevice;
        private WasapiCapture _soundIn;
        private WaveWriter waveWriter;
       

        public MMDevice SelectedDevice
        {
            get { return _selectedDevice; }
            set
            {
                _selectedDevice = value;
                if (value != null)
                    BtnStart.Enabled = true;
            }
        }

        public RecordSoundWithPcm()
        {
            InitializeComponent();
            BindLang();
        }

        public void BindLang()
        {
            SupportedLanguages[] list = new SupportedLanguages[]  {
                                 new SupportedLanguages(1,"af-ZA","Afrikaans (South Africa)"),
                                 new SupportedLanguages(2,"id-ID","Indonesian (Indonesia)"),
                                 new SupportedLanguages(3,"ms-MY","Malay (Malaysia)"),
                                 new SupportedLanguages(4,"ca-ES","Catalan (Spain)"),
                                 new SupportedLanguages(5,"cs-CZ","Czech (Czech Republic)"),
                                 new SupportedLanguages(6,"da-DK","Danish (Denmark)"),
                                 new SupportedLanguages(7,"de-DE","German (Germany)"),
                                  new SupportedLanguages(8,"en-AU","English (Australia)"),
                                 new SupportedLanguages(9,"en-CA","English (Canada)"),
                                 new SupportedLanguages(10,"en-GB","English (United Kingdom)"),
                                 new SupportedLanguages(11,"en-IN","English (India)"),
                                 new SupportedLanguages(12,"en-IE","English (Ireland)"),
                                 new SupportedLanguages(13,"en-NZ","English (New Zealand)"),
                                 new SupportedLanguages(14,"en-PH","English (Philippines)"),
                                  new SupportedLanguages(15,"en-ZA","English (South Africa)"),
                                 new SupportedLanguages(16,"en-US","English (United States)"),
                                 new SupportedLanguages(17,"es-AR","Spanish (Argentina)"),
                                 new SupportedLanguages(18,"es-BO","Spanish (Bolivia)"),
                                 new SupportedLanguages(19,"es-CL","Spanish (Chile)"),
                                 new SupportedLanguages(20,"es-CO","Spanish (Colombia)"),
                                 new SupportedLanguages(21,"es-CR","Spanish (Costa Rica)"),
                                  new SupportedLanguages(22,"es-EC","Spanish (Ecuador)"),
                                 new SupportedLanguages(23,"es-SV","Spanish (El Salvador)"),
                                 new SupportedLanguages(24,"es-ES","Spanish (Spain)"),
                                 new SupportedLanguages(25,"es-US","Spanish (United States)"),
                                 new SupportedLanguages(26,"es-GT","Spanish (Guatemala)"),
                                 new SupportedLanguages(27,"es-HN","Spanish (Honduras)"),
                                 new SupportedLanguages(28,"es-MX","Spanish (Mexico)"),
                                  new SupportedLanguages(29,"es-NI","Spanish (Nicaragua)"),
                                 new SupportedLanguages(30,"es-PA","Spanish (Panama)"),
                                 new SupportedLanguages(31,"es-PY","Spanish (Paraguay)"),
                                 new SupportedLanguages(32,"es-PE","Spanish (Peru)"),
                                 new SupportedLanguages(33,"es-PR","Spanish (Puerto Rico)"),
                                 new SupportedLanguages(34,"es-DO","Spanish (Dominican Republic)"),
                                 new SupportedLanguages(35,"es-UY","Spanish (Uruguay)"),
                                  new SupportedLanguages(36,"es-VE","Spanish (Venezuela)"),
                                 new SupportedLanguages(37,"eu-ES","Basque (Spain)"),
                                 new SupportedLanguages(38,"fil-PH","Filipino (Philippines)"),
                                 new SupportedLanguages(39,"fr-CA","French (Canada)"),
                                 new SupportedLanguages(40,"fr-FR","French (France)"),
                                 new SupportedLanguages(41,"gl-ES","Galician (Spain)"),
                                 new SupportedLanguages(42,"hr-HR","Croatian (Croatia)"),
                                  new SupportedLanguages(43,"zu-ZA","Zulu (South Africa)"),
                                 new SupportedLanguages(44,"is-IS","Icelandic (Iceland)"),
                                 new SupportedLanguages(45,"it-IT","Italian (Italy)"),
                                 new SupportedLanguages(46,"lt-LT","Lithuanian (Lithuania)"),
                                 new SupportedLanguages(47,"hu-HU","Hungarian (Hungary)"),
                                 new SupportedLanguages(48,"nl-NL","Dutch (Netherlands)"),
                                 new SupportedLanguages(49,"nb-NO","Norwegian Bokmål (Norway)"),
                                  new SupportedLanguages(50,"pl-PL","Polish (Poland)"),
                                 new SupportedLanguages(51,"pt-BR","Portuguese (Brazil)"),
                                 new SupportedLanguages(52,"pt-PT","Portuguese (Portugal)"),
                                 new SupportedLanguages(53,"ro-RO","Romanian (Romania)"),
                                 new SupportedLanguages(54,"sk-SK","Slovak (Slovakia)"),
                                 new SupportedLanguages(55,"sl-SI","Slovenian (Slovenia)"),
                                 new SupportedLanguages(56,"fi-FI","Finnish (Finland)"),
                                  new SupportedLanguages(57,"sv-SE","Swedish (Sweden)"),
                                 new SupportedLanguages(58,"vi-VN","Vietnamese (Vietnam)"),
                                 new SupportedLanguages(59,"tr-TR","Turkish (Turkey)"),
                                 new SupportedLanguages(60,"el-GR","Greek (Greece)"),
                                 new SupportedLanguages(61,"bg-BG","Bulgarian (Bulgaria)"),
                                 new SupportedLanguages(62,"ru-RU","Russian (Russia)"),
                                 new SupportedLanguages(63,"sr-RS","Serbian (Serbia)"),
                                  new SupportedLanguages(64,"uk-UA","Ukrainian (Ukraine)"),
                                 new SupportedLanguages(65,"he-IL","Hebrew (Israel)"),
                                 new SupportedLanguages(66,"ar-IL","Arabic (Israel)"),
                                 new SupportedLanguages(67,"ar-JO","Arabic (Jordan)"),
                                 new SupportedLanguages(68,"ar-AE","Arabic (United Arab Emirates)"),
                                 new SupportedLanguages(69,"ar-BH","Arabic (Bahrain)"),
                                 new SupportedLanguages(70,"ar-DZ","Arabic (Algeria)"),
                                  new SupportedLanguages(71,"ar-SA","Arabic (Saudi Arabia)"),
                                 new SupportedLanguages(72,"ar-IQ","Arabic (Iraq)"),
                                 new SupportedLanguages(73,"ar-KW","Arabic (Kuwait)"),
                                 new SupportedLanguages(74,"ar-MA","Arabic (Morocco)"),
                                 new SupportedLanguages(75,"ar-TN","Arabic (Tunisia)"),
                                 new SupportedLanguages(76,"ar-OM","Arabic (Oman)"),
                                 new SupportedLanguages(77,"ar-PS","Arabic (State of Palestine)"),
                                  new SupportedLanguages(78,"ar-QA","Arabic (Qatar)"),
                                 new SupportedLanguages(79,"ar-LB","Arabic (Lebanon)"),
                                 new SupportedLanguages(80,"ar-EG","Arabic (Egypt)"),
                                 new SupportedLanguages(81,"fa-IR","Persian (Iran)"),
                                 new SupportedLanguages(82,"hi-IN","Hindi (India)"),
                                 new SupportedLanguages(83,"th-TH","Thai (Thailand)"),
                                 new SupportedLanguages(84,"ko-KR","Korean (South Korea)"),
                                 new SupportedLanguages(85,"cmn-Hant-TW","Mandarin (Traditional, Taiwan)"),
                                 new SupportedLanguages(86,"yue-Hant-HK","Cantonese (Traditional, Hong Kong)"),
                                 new SupportedLanguages(87,"ja-JP","Japanese (Japan)"),
                                 new SupportedLanguages(88,"cmn-Hans-HK","Mandarin (Simplified, Hong Kong)"),
                                 new SupportedLanguages(89,"cmn-Hans-CN","Chinese, Mandarin (Simplified, China)")
                               };
            cmbLanguageCode.DataSource = list;
            cmbLanguageCode.ValueMember = "LanguageCode";
            cmbLanguageCode.DisplayMember = "Name";
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            txtTranscript.Text = string.Empty;
            BtnSaveStop.Enabled = true;
            BtnStart.Hide();
            BtnSaveStop.Show();
            StartCapture(_FileName);
            lblDisplayTime.Visible = true;
        }

        private void StartCapture(string fileName)
        {
            //Capture Mode
            CaptureMode = (CaptureMode)1;
            DataFlow dataFlow = CaptureMode == CaptureMode.Capture ? DataFlow.Capture : DataFlow.Render;
            //

            //Getting the audio devices from 
            var devices = MMDeviceEnumerator.EnumerateDevices(dataFlow, DeviceState.Active);
            if (!devices.Any())
            {
                MessageBox.Show("No devices found.");
                return;
            }

            int selectedDeviceIndex = 0;
            SelectedDevice = devices[selectedDeviceIndex];

            if (SelectedDevice == null)
                return;

            if (CaptureMode == CaptureMode.Capture)
                _soundIn = new WasapiCapture();
            else
                _soundIn = new WasapiLoopbackCapture();

            _soundIn.Device = SelectedDevice;

            //Sample rate of audio
            int sampleRate = 16000;
            //bits per rate
            int bitsPerSample = 16;
            //chanels
            int channels = 1;


            //initialize the soundIn instance
            _soundIn.Initialize();

            //create a SoundSource around the the soundIn instance
            //this SoundSource will provide data, captured by the soundIn instance
            var soundInSource = new SoundInSource(_soundIn) { FillWithZeros = false };

            //create a source, that converts the data provided by the
            //soundInSource to any other format
            //in this case the "Fluent"-extension methods are being used
            IWaveSource convertedSource = soundInSource
                .ChangeSampleRate(sampleRate) // sample rate
                .ToSampleSource()
                .ToWaveSource(bitsPerSample); //bits per sample

            //channels=1 then we  need to create  mono audio
            convertedSource = convertedSource.ToMono();

            AudioToText audioToText = new AudioToText();
            audioToText.SetFolderPermission(_folderPath);

            //create a new wavefile
            waveWriter = new WaveWriter(fileName, convertedSource.WaveFormat);
            //register an event handler for the DataAvailable event of 
            //the soundInSource
            //Important: use the DataAvailable of the SoundInSource
            //If you use the DataAvailable event of the ISoundIn itself
            //the data recorded by that event might won't be available at the
            //soundInSource yet
            soundInSource.DataAvailable += (s, e) =>
        {
            //read data from the converedSource
            //important: don't use the e.Data here
            //the e.Data contains the raw data provided by the 
            //soundInSource which won't have your target format
            byte[] buffer = new byte[convertedSource.WaveFormat.BytesPerSecond / 2];
            int read;

            //keep reading as long as we still get some data
            //if you're using such a loop, make sure that soundInSource.FillWithZeros is set to false
            while ((read = convertedSource.Read(buffer, 0, buffer.Length)) > 0)
            {
                //write the read data to a file
                // ReSharper disable once AccessToDisposedClosure
                waveWriter.Write(buffer, 0, read);
            }
        };

            //we've set everything we need -> start capturing data
            objStopWatch.Start();
            _soundIn.Start();

        }
        private void StopCapture()
        {
            if (_soundIn != null)
            {
                _soundIn.Stop();
                _soundIn.Dispose();
                _soundIn = null;

                if (waveWriter is IDisposable)
                    ((IDisposable)waveWriter).Dispose();
            }
        }
        private void BtnSaveStop_Click(object sender, EventArgs e)
        {
            lblWait.Visible = true;
            Application.DoEvents();
            BtnSaveStop.Hide();
            StopCapture();
            objStopWatch.Reset();
            lblDisplayTime.Visible = false;
            // Process.Start(_FileName);
            AudioToText audioToText = new AudioToText();
            string message = "Processing is Done!";
            txtTranscript.Text = audioToText.GetTextBy16BitPCMAudio(_FileName,cmbLanguageCode.SelectedValue.ToString(),ref message);
            lblWait.Visible = false;
            BtnStart.Show();
            MessageBox.Show(message);
        }
      

        private void StopWatchTimer_Tick(object sender, EventArgs e)
        {
            if (objStopWatch.IsRunning)
            {
                TimeSpan objTimeSpan = TimeSpan.FromMilliseconds(objStopWatch.ElapsedMilliseconds);
                lblDisplayTime.Text = String.Format(CultureInfo.CurrentCulture, "{0:00}:{1:00}:{2:00}.{3:00}", objTimeSpan.Hours, objTimeSpan.Minutes, objTimeSpan.Seconds, objTimeSpan.Milliseconds / 10);
            }
        }
        private void RecordSoundWithPcm_Load(object sender, EventArgs e)
        {
            cmbLanguageCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguageCode.SelectedIndex = 15;
            BtnSaveStop.Visible = false;
            lblDisplayTime.Visible = false;
            lblWait.Visible = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
            }

            base.OnFormClosing(e);
        }
        private void RecordSoundWithPcm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void showGooglemapBtn_Click(object sender, EventArgs e)
        {
            GoogleMapfrm frm = new GoogleMapfrm();
            frm.Show();
        }
    }

    public class SupportedLanguages
    {
        public int ID { get; set; }
        public string LanguageCode { get; set; }
        public string Name { get; set; }
        public SupportedLanguages(int id, string code, string name)
        {
            ID = id;
            LanguageCode = code;
            Name = name;
        }
    }
}
