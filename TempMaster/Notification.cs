using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TempMaster
{
    public partial class Notification : Form
    {
        public string EmailServer {get;set;}
        public string EmailPort {get;set;}
        public bool EmailSSL {get;set;}
        public string EmailAddress {get;set;}
        public string EmailPassword {get;set;}
        public string PhoneNumber {get;set;}
        public string Carrier { get; set; }

        public Notification()
        {
            InitializeComponent();
        }

        public Notification(string emailserver, string emailport, Boolean emailssl, string emailaddr, string emailpass, string phonenum, string carrier)
        {
            InitializeComponent();
            emailServerTextBox.Text = emailserver;
            emailPortTextBox.Text = emailport;
            emailSslCheckBox.Checked = emailssl;
            emailAddrTextBox.Text = emailaddr;
            emailPasswordTextBox.Text = emailpass;
            phoneTextBox.Text = phonenum;
            
            var carriers = new Dictionary<string, string>();
            carriers["3 River Wireless"] = "@sms.3rivers.net";
            carriers["ACS Wireless"] = "@paging.acswireless.com";
            carriers["Alltel"] = "@message.alltel.com";
            carriers["AT&T"] = "@txt.att.net";
            carriers["Bell Canada"] = "@txt.bellmobility.ca";
            carriers["Bell Canada"] = "@bellmobility.ca";
            carriers["Bell Mobility (Canada)"] = "@txt.bell.ca";
            carriers["Bell Mobility"] = "@txt.bellmobility.ca";
            carriers["Blue Sky Frog"] = "@blueskyfrog.com";
            carriers["Bluegrass Cellular"] = "@sms.bluecell.com";
            carriers["Boost Mobile"] = "@myboostmobile.com";
            carriers["BPL Mobile"] = "@bplmobile.com";
            carriers["Carolina West Wireless"] = "@cwwsms.com";
            carriers["Cellular One"] = "@mobile.celloneusa.com";
            carriers["Cellular South"] = "@csouth1.com";
            carriers["Centennial Wireless"] = "@cwemail.com";
            carriers["CenturyTel"] = "@messaging.centurytel.net";
            carriers["Cingular (Now AT&T)"] = "@txt.att.net";
            carriers["Clearnet"] = "@msg.clearnet.com";
            carriers["Comcast"] = "@comcastpcs.textmsg.com";
            carriers["Corr Wireless Communications"] = "@corrwireless.net";
            carriers["Dobson"] = "@mobile.dobson.net";
            carriers["Edge Wireless"] = "@sms.edgewireless.com";
            carriers["Fido"] = "@fido.ca";
            carriers["Golden Telecom"] = "@sms.goldentele.com";
            carriers["Helio"] = "@messaging.sprintpcs.com";
            carriers["Houston Cellular"] = "@text.houstoncellular.net";
            carriers["Idea Cellular"] = "@ideacellular.net";
            carriers["Illinois Valley Cellular"] = "@ivctext.com";
            carriers["Inland Cellular Telephone"] = "@inlandlink.com";
            carriers["MCI"] = "@pagemci.com";
            carriers["Metrocall"] = "@page.metrocall.com";
            carriers["Metrocall 2-way"] = "@my2way.com";
            carriers["Metro PCS"] = "@mymetropcs.com";
            carriers["Microcell"] = "@fido.ca";
            carriers["Midwest Wireless"] = "@clearlydigital.com";
            carriers["Mobilcomm"] = "@mobilecomm.net";
            carriers["MTS"] = "@text.mtsmobility.com";
            carriers["Nextel"] = "@messaging.nextel.com";
            carriers["OnlineBeep"] = "@onlinebeep.net";
            carriers["PCS One"] = "@pcsone.net";
            carriers["President's Choice"] = "@txt.bell.ca";
            carriers["Public Service Cellular"] = "@sms.pscel.com";
            carriers["Qwest"] = "@qwestmp.com";
            carriers["Rogers AT&T Wireless"] = "@pcs.rogers.com";
            carriers["Rogers Canada"] = "@pcs.rogers.com";
            carriers["Satellink"] = ".pageme@satellink.net";
            carriers["Southwestern Bell"] = "@email.swbw.com";
            carriers["Sprint"] = "@messaging.sprintpcs.com";
            carriers["Sumcom"] = "@tms.suncom.com";
            carriers["Surewest Communicaitons"] = "@mobile.surewest.com";
            carriers["T-Mobile"] = "@tmomail.net";
            carriers["Telus"] = "@msg.telus.com";
            carriers["Tracfone"] = "@txt.att.net";
            carriers["Triton"] = "@tms.suncom.com";
            carriers["Unicel"] = "@utext.com";
            carriers["US Cellular"] = "@email.uscc.net";
            carriers["Solo Mobile"] = "@txt.bell.ca";
            carriers["Sprint"] = "@messaging.sprintpcs.com";
            carriers["Sumcom"] = "@tms.suncom.com";
            carriers["Surewest Communicaitons"] = "@mobile.surewest.com";
            carriers["T-Mobile"] = "@tmomail.net";
            carriers["Telus"] = "@msg.telus.com";
            carriers["Triton"] = "@tms.suncom.com";
            carriers["Unicel"] = "@utext.com";
            carriers["US Cellular"] = "@email.uscc.net";
            carriers["US West"] = "@uswestdatamail.com";
            carriers["Verizon"] = "@vtext.com";
            carriers["Virgin Mobile"] = "@vmobl.com";
            carriers["Virgin Mobile Canada"] = "@vmobile.ca";
            carriers["West Central Wireless"] = "@sms.wcc.net";
            carriers["Western Wireless"] = "@cellularonewest.com";
            carriers["Chennai RPG Cellular"] = "@rpgmail.net";
            carriers["Chennai Skycell / Airtel"] = "@airtelchennai.com";
            carriers["Comviq"] = "@sms.comviq.se";
            carriers["Delhi Aritel"] = "@airtelmail.com";
            carriers["Delhi Hutch"] = "@delhi.hutch.co.in";
            carriers["DT T-Mobile"] = "@t-mobile-sms.de";
            carriers["Dutchtone / Orange-NL"] = "@sms.orange.nl";
            carriers["EMT"] = "@sms.emt.ee";
            carriers["Escotel"] = "@escotelmobile.com";
            carriers["German T-Mobile"] = "@t-mobile-sms.de";
            carriers["Goa BPLMobil"] = "@bplmobile.com";
            carriers["Golden Telecom"] = "@sms.goldentele.com";
            carriers["Gujarat Celforce"] = "@celforce.com";
            carriers["JSM Tele-Page"] = "pinnumber@jsmtel.com";
            carriers["Kerala Escotel"] = "@escotelmobile.com";
            carriers["Kolkata Airtel"] = "@airtelkol.com";
            carriers["Kyivstar"] = "@smsmail.lmt.lv";
            carriers["Lauttamus Communication"] = "@e-page.net";
            carriers["LMT"] = "@smsmail.lmt.lv";
            carriers["Maharashtra BPL Mobile"] = "@bplmobile.com";
            carriers["Maharashtra Idea Cellular"] = "@ideacellular.net";
            carriers["Manitoba Telecom Systems"] = "@text.mtsmobility.com";
            carriers["Meteor"] = "@mymeteor.ie";
            carriers["MiWorld"] = "@m1.com.sg";
            carriers["Mobileone"] = "@m1.com.sg";
            carriers["Mobilfone"] = "@page.mobilfone.com";
            carriers["Mobility Bermuda"] = "@ml.bm";
            carriers["Mobistar Belgium"] = "@mobistar.be";
            carriers["Mobitel Tanzania"] = "@sms.co.tz";
            carriers["Mobtel Srbija"] = "@mobtel.co.yu";
            carriers["Movistar"] = "@correo.movistar.net";
            carriers["Mumbai BPL Mobile"] = "@bplmobile.com";
            carriers["Netcom"] = "@sms.netcom.no";
            carriers["Ntelos"] = "@pcs.ntelos.com";
            carriers["O2"] = "@o2.co.uk";
            carriers["O2"] = "@o2imail.co.uk";
            carriers["O2 (M-mail)"] = "@mmail.co.uk";
            carriers["One Connect Austria"] = "@onemail.at";
            carriers["OnlineBeep"] = "@onlinebeep.net";
            carriers["Optus Mobile"] = "@optusmobile.com.au";
            carriers["Orange"] = "@orange.net";
            carriers["Orange Mumbai"] = "@orangemail.co.in";
            carriers["Orange NL / Dutchtone"] = "@sms.orange.nl";
            carriers["Oskar"] = "@mujoskar.cz";
            carriers["P&T Luxembourg"] = "@sms.luxgsm.lu";
            carriers["Personal Communication"] = "@pcom.ru (put the  in the subject line)";
            carriers["Pondicherry BPL Mobile"] = "@bplmobile.com";
            carriers["Primtel"] = "@sms.primtel.ru";
            carriers["Safaricom"] = "@safaricomsms.com";
            carriers["Satelindo GSM"] = "@satelindogsm.com";
            carriers["SCS-900"] = "@scs-900.ru";
            carriers["SFR France"] = "@sfr.fr";
            carriers["Simple Freedom"] = "@text.simplefreedom.net";
            carriers["Smart Telecom"] = "@mysmart.mymobile.ph";
            carriers["Southern LINC"] = "@page.southernlinc.com";
            carriers["Sunrise Mobile"] = "@mysunrise.ch";
            carriers["Sunrise Mobile"] = "@swmsg.com";
            carriers["Surewest Communications"] = "@freesurf.ch";
            carriers["Swisscom"] = "@bluewin.ch";
            carriers["T-Mobile Austria"] = "@sms.t-mobile.at";
            carriers["T-Mobile Germany"] = "@t-d1-sms.de";
            carriers["T-Mobile UK"] = "@t-mobile.uk.net";
            carriers["Tamil Nadu BPL Mobile"] = "@bplmobile.com";
            carriers["Tele2 Latvia"] = "@sms.tele2.lv";
            carriers["Telefonica Movistar"] = "@movistar.net";
            carriers["Telenor"] = "@mobilpost.no";
            carriers["Teletouch"] = "@pageme.teletouch.com";
            carriers["Telia Denmark"] = "@gsm1800.telia.dk";
            carriers["TIM"] = "@timnet.com";
            carriers["TSR Wireless"] = "@alphame.com";
            carriers["UMC"] = "@sms.umc.com.ua";
            carriers["Uraltel"] = "@sms.uraltel.ru";
            carriers["Uttar Pradesh Escotel"] = "@escotelmobile.com";
            carriers["Vessotel"] = "@pager.irkutsk.ru";
            carriers["Vodafone Italy"] = "@sms.vodafone.it";
            carriers["Vodafone Japan"] = "@c.vodafone.ne.jp";
            carriers["Vodafone Japan"] = "@h.vodafone.ne.jp";
            carriers["Vodafone Japan"] = "@t.vodafone.ne.jp";
            carriers["Vodafone UK"] = "@vodafone.net";
            carriers["Wyndtell"] = "@wyndtell.com";

            carrierComboBox.DataSource = new BindingSource(carriers, null);
            carrierComboBox.DisplayMember = "key";
            carrierComboBox.ValueMember = "value";
            if (carrier != null)
            {
                carrierComboBox.SelectedValue = carrier;
            }
        }

        private void Notification_FormClosing(object sender, FormClosingEventArgs e)
        {
            EmailServer = emailServerTextBox.Text;
            EmailPort = emailPortTextBox.Text;
            EmailSSL = emailSslCheckBox.Checked;
            EmailAddress = emailAddrTextBox.Text;
            EmailPassword = emailPasswordTextBox.Text;
            PhoneNumber = phoneTextBox.Text;
            if (carrierComboBox.SelectedValue != null)
            {
                Carrier = carrierComboBox.SelectedValue.ToString();
            }
        }
    }
}
