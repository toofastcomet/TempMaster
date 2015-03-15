using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Timers;
using GoIOdotNET;
using VSTCoreDefsdotNET;
using System.Threading;

namespace TempMaster
{
    public partial class Form1 : Form
    {
        string EmailServer;
        string EmailPort;
        bool EmailSSL;
        string EmailAddress;
        string EmailPassword;
        string PhoneNumber;
        string Carrier;
        string LogInterval;
        System.Windows.Forms.Timer timer1;
        System.Windows.Forms.Timer timer2;
        TimeSpan timespan1;
        TimeSpan timespan2;
        BackgroundWorker bw;
        IntPtr sensorHandle;
        Log LogInstance;
        
        public Form1()
        {
            InitializeComponent();

            EmailServer = Properties.Settings.Default["EmailServer"].ToString();
            EmailPort = Properties.Settings.Default["EmailPort"].ToString();
            EmailSSL = Properties.Settings.Default["EmailSSL"].ToString() == "1";
            EmailAddress = Properties.Settings.Default["EmailAddress"].ToString();
            EmailPassword = Properties.Settings.Default["EmailPassword"].ToString();
            PhoneNumber = Properties.Settings.Default["PhoneNumber"].ToString();
            Carrier = Properties.Settings.Default["Carrier"].ToString();
            LogInterval = Properties.Settings.Default["LogInterval"].ToString();
            if (!string.IsNullOrEmpty(LogInterval))
            {
                LogInstance = new Log(LogInterval);
            }

            CreateProbeThread();
        }

        private void CreateProbeThread()
        {
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            double currentTemp = 0;
            int status = InitializeProbe();
            while (bw.CancellationPending != true)
            {
                currentTemp = ReadProbe();
                //debugging purposes w/o probe to simulate going past alert value
                //if (currentTemp == 0)
                //{
                //    currentTemp = DateTime.Now.Second;
                //}
                bw.ReportProgress(0, currentTemp.ToString());
                Application.DoEvents();
                if (LogInstance != null)
                {
                    LogInstance.LogFile(currentTemp.ToString());
                }
                Thread.Sleep(1000);
            }
            e.Cancel = true;
        }

        private int InitializeProbe()
        {
            Console.WriteLine("Initialzing library...");
            IntPtr initResult = GoIO.Init();
            if (initResult.ToInt32() != 0)
            {
                Console.Write("Unable to initialize library");
                Console.ReadLine();
                return -1;
            }

            Console.WriteLine("Updating list of available Go!Temps");
            int numGoTempsFound = GoIO.UpdateListOfAvailableDevices(
                VST_USB_defs.VENDOR_ID, VST_USB_defs.PRODUCT_ID_GO_TEMP);

            StringBuilder deviceName = new StringBuilder(GoIO.MAX_SIZE_SENSOR_NAME);

            Console.WriteLine("Getting first device name");
            int status = GoIO.GetNthAvailableDeviceName(deviceName, deviceName.Capacity,
                VST_USB_defs.VENDOR_ID, VST_USB_defs.PRODUCT_ID_GO_TEMP, 0);

            if (status != 0)
            {
                Console.WriteLine("Unable to get the first device name");
                Console.ReadLine();
                return -1;
            }

            Console.WriteLine("Opening device");
            sensorHandle = GoIO.Sensor_Open(deviceName.ToString(), VST_USB_defs.VENDOR_ID,
                VST_USB_defs.PRODUCT_ID_GO_TEMP, 0);
            if (sensorHandle == IntPtr.Zero)
            {
                Console.WriteLine("Unable to open sensor.");
                Console.ReadLine();
                return -1;
            }
            Console.WriteLine("Starting measurements");
            GoIO.Sensor_SendCmdAndGetResponse4(sensorHandle, GoIO_ParmBlk.CMD_ID_START_MEASUREMENTS, GoIO.TIMEOUT_MS_DEFAULT);
            return 0;
        }

        private double ReadProbe()
        { 
            double volts;
            double currtemp = 0;

            if (sensorHandle != IntPtr.Zero)
            {
                int MAX = 1000;
                int[] raw = new int[MAX];
                int numMeasurements = GoIO.Sensor_ReadRawMeasurements(sensorHandle, raw, (uint)raw.Length);

                for (int i = 0; i < numMeasurements; i++)
                {
                    volts = GoIO.Sensor_ConvertToVoltage(sensorHandle, raw[i]);
                    currtemp = GoIO.Sensor_CalibrateData(sensorHandle,volts);
                }
            }
            return Math.Round(currtemp,1);
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.label1.Text = e.UserState as string;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //cleanup usb connection!
            GoIO.Sensor_SendCmdAndGetResponse4(sensorHandle, GoIO_ParmBlk.CMD_ID_STOP_MEASUREMENTS, GoIO.TIMEOUT_MS_DEFAULT);
            Console.WriteLine("Closing sensor handle");
            GoIO.Sensor_Close(sensorHandle);
            sensorHandle = IntPtr.Zero;

            Console.WriteLine("Uninitializing library");
            //GoIO.Uninit();

            //if ((e.Cancelled == true))
            //{
            //}

            //else if (!(e.Error == null))
            //{
            //}

            //else
            //{
            //}

            //close logging file

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default["EmailServer"] = EmailServer;
            Properties.Settings.Default["EmailPort"] = EmailPort;
            if (EmailSSL)
            {
                Properties.Settings.Default["EmailSSL"] = "1";
            }
            else
            {
                Properties.Settings.Default["EmailSSL"] = "0";
            }
            Properties.Settings.Default["EmailAddress"] = EmailAddress;
            Properties.Settings.Default["EmailPassword"] = EmailPassword;
            Properties.Settings.Default["PhoneNumber"] = PhoneNumber;
            Properties.Settings.Default["Carrier"] = Carrier;
            Properties.Settings.Default["LogInterval"] = LogInterval;
            Properties.Settings.Default.Save();
            
            //close the thread nicely
            label1.Visible = false;
            bw.CancelAsync();
            while (bw.CancellationPending)
            {
                Thread.Sleep(50);
                Application.DoEvents();
            }

            if (LogInstance != null)
            {
                LogInstance.CloseLog();
            }
        }

        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notification noti = new Notification(EmailServer, EmailPort, EmailSSL, EmailAddress, EmailPassword, PhoneNumber, Carrier, LogInterval);
            noti.ShowDialog();
            EmailServer = noti.EmailServer;
            EmailPort = noti.EmailPort;
            EmailSSL = noti.EmailSSL;
            EmailAddress = noti.EmailAddress;
            EmailPassword = noti.EmailPassword;
            PhoneNumber = noti.PhoneNumber;
            Carrier = noti.Carrier;
            LogInterval = noti.LogInterval;
            if (!string.IsNullOrEmpty(LogInterval))
            {
                if (LogInstance == null)
                {
                    LogInstance = new Log(LogInterval);
                }
            }
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            Color currcolor = label1.ForeColor;
            //check to alert to change color and send email/sms
            float alert1;
            float alert2;
            float currtemp;
            float.TryParse(alert1TextBox.Text, out alert1);
            float.TryParse(alert2TextBox.Text, out alert2);
            float.TryParse(label1.Text, out currtemp);

            if (currtemp > 0)
            {
                label1.ForeColor = Color.White;
                if (alert1 > 0 && currtemp > alert1)
                {
                    label1.ForeColor = Color.Green;
                    if (currcolor != Color.Green)
                    {
                        //send alert
                        label1.ForeColor = Color.Green;
                        SendAlert();

                        //perhaps start timer
                        if (alert1TimerCheckBox.Checked & timer1 == null)
                        {
                            StartTimer1();
                        }
                    }
                }
                if (alert2 > 0 && currtemp > alert2)
                {
                    label1.ForeColor = Color.Maroon;
                    if (currcolor != Color.Maroon)
                    {
                        //send alert
                        label1.ForeColor = Color.Maroon;
                        SendAlert();

                        //perhaps start timer
                        if (alert2TimerCheckBox.Checked & timer2 == null)
                        {
                            StartTimer2();
                        }
                    }
                }
            }
        }

        private void StartTimer1()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer_Tick);
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timespan1 = timespan1.Add(new TimeSpan(0, 0, 1));
            timer1label.Text = timespan1.ToString();
        }

        private void StartTimer2()
        {
            timer2 = new System.Windows.Forms.Timer();
            timer2.Tick += new EventHandler(timer_Tick2);
            timer2.Interval = 1000;
            timer2.Enabled = true;
            timer2.Start();
        }

        void timer_Tick2(object sender, EventArgs e)
        {
            timespan2 = timespan2.Add(new TimeSpan(0, 0, 1));
            timer2label.Text = timespan2.ToString();
        }

        private void SendAlert()
        {
            string EmailBody = "Current Temperature - " + label1.Text;

            if (EmailServer != null & EmailPort != null & EmailAddress != null & EmailPassword != null)
            {
                SendMessage(EmailAddress, EmailAddress, "Temperature Alert", EmailBody, false, EmailServer, EmailPort, EmailAddress, EmailPassword, EmailSSL);
            }

            if (PhoneNumber != null & Carrier != null)
            {
                SendMessage(EmailAddress, PhoneNumber + Carrier, "Temperature Alert", EmailBody, false, EmailServer, EmailPort, EmailAddress, EmailPassword, EmailSSL);
            }
        }

        public void SendMessage(string fromAddress, string toAddress,string subject, string body, bool useHtml, string smtpHost, string smtpPort, string smtpUserName, string smtpPassword, bool useSSL)
        {
            try
            {
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress(fromAddress);
                    message.To.Add(toAddress);
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = useHtml;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = smtpHost;
                    smtpClient.Port = int.Parse(smtpPort);
                    smtpClient.Credentials = new NetworkCredential(smtpUserName, smtpPassword);
                    smtpClient.EnableSsl = useSSL;
                    smtpClient.Send(message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void alert1TextBox_Validating(object sender, CancelEventArgs e)
        {
            float a;
            if (alert1TextBox.Text != "")
            {
                if (!float.TryParse(alert1TextBox.Text, out a))
                {
                    MessageBox.Show("Value must be numeric.", "String Error!");
                    e.Cancel = true;
                }
            }
            label1_TextChanged(this, e);
        }

        private void alert2TextBox_Validating(object sender, CancelEventArgs e)
        {
            float a;
            if (alert2TextBox.Text != "")
            {
                if (!float.TryParse(alert2TextBox.Text, out a))
                {
                    MessageBox.Show("Value must be numeric.", "String Error!");
                    e.Cancel = true;
                }
            }
            label1_TextChanged(this, e);
        }

        private void stopTimersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1 != null)
            {
                timer1.Stop();
                timer1.Dispose();
                timer1 = null;
                timespan1 = new TimeSpan();
            }
            if (timer2 != null)
            {
                timer2.Stop();
                timer2.Dispose();
                timer2 = null;
                timespan2 = new TimeSpan();
            }
        }

    }
}
