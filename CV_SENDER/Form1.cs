using AutoReport1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace CV_SENDER
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer myclock = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer myclock2 = new System.Windows.Forms.Timer();

        static protected List<Want_Ad> mylist = new List<Want_Ad>();
        static protected Gmail MygmailAccount = new Gmail();
        static protected string MESSAGE_LABEL = "Process";

        static protected WebBrowser web_login = new WebBrowser();
        static protected WebBrowser web_single_ad = new WebBrowser();

        static protected int page_count = 50;



        static protected List<string> Ad_array = new List<string>();

        public Form1()
        {
            InitializeComponent();

        }
        protected void login()
        {
            //LoginTOJobMaster();
            web_login.Refresh(WebBrowserRefreshOption.Completely);

            web_login.Navigate(MygmailAccount.Link_gmail21+ page_count);
            web_login.Refresh(WebBrowserRefreshOption.Completely);
            web_login.ScriptErrorsSuppressed = true;

            while (web_login.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }
            AutoClosingMessageBox.Show(MESSAGE_LABEL, "-Caption 1-", 1000, textBox3);
            try
            {
                web_login.Document.GetElementById(MygmailAccount.Input_email).SetAttribute("value", "maorlevi1990@gmail.com");
            }
            catch (Exception exp)
            {

            }

            AutoClosingMessageBox.Show(MESSAGE_LABEL, "-Caption 2-", 1000, textBox3);
            //try
            //{
            if (web_login.Document.GetElementById(MygmailAccount.Next_btn) != null)
            {
                try
                {
                    web_login.Document.GetElementById(MygmailAccount.Next_btn).InvokeMember("click");
                    AutoClosingMessageBox.Show(MESSAGE_LABEL, "-Caption 3-", 1000, textBox3);
                    while (!web_login.DocumentText.Contains(MygmailAccount.Input_pass)) { Application.DoEvents(); }

                    AutoClosingMessageBox.Show(MESSAGE_LABEL, "-Caption 4-", 1000, textBox3);
                    //Boolean run = true;

                    passworinsert();


                }
                catch (Exception exp) { }

            }
            if (web_login.DocumentText.Contains("טוען תצוגה רגילה"))
            {
                web_login.Document.GetElementById("stb").Children[0].Children[1].InvokeMember("click");
                //web_login.Navigate(MygmailAccount.Link_gmail1);
            }
            while (web_login.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }
            AutoClosingMessageBox.Show("passworinsert", "-Caption 6-", 4000, textBox3);
            Boolean runer = true;
            while (runer)
            {
                if (web_login.Document.GetElementsByTagName("table").Count > 7)
                {
                    ANALYSIS_page();
                    runer = false;
                }
                Application.DoEvents();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            LoginTOJobMaster();
            web_login.Refresh(WebBrowserRefreshOption.Completely);

            web_login.Navigate(MygmailAccount.Link_gmail1);
            web_login.Refresh(WebBrowserRefreshOption.Completely);
            web_login.ScriptErrorsSuppressed = true;

            while (web_login.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }
            AutoClosingMessageBox.Show(MESSAGE_LABEL, "-Caption 1-", 1000, textBox3);
            try
            {
                web_login.Document.GetElementById(MygmailAccount.Input_email).SetAttribute("value", "maorlevi1990@gmail.com");
            }
            catch (Exception exp)
            {

            }

            AutoClosingMessageBox.Show(MESSAGE_LABEL, "-Caption 2-", 1000, textBox3);
            //try
            //{
            if (web_login.Document.GetElementById(MygmailAccount.Next_btn) != null)
            {
                try
                {
                    web_login.Document.GetElementById(MygmailAccount.Next_btn).InvokeMember("click");
                    AutoClosingMessageBox.Show(MESSAGE_LABEL, "-Caption 3-", 1000, textBox3);
                    while (!web_login.DocumentText.Contains(MygmailAccount.Input_pass)) { Application.DoEvents(); }

                    AutoClosingMessageBox.Show(MESSAGE_LABEL, "-Caption 4-", 1000, textBox3);
                    //Boolean run = true;

                    passworinsert();


                }
                catch (Exception exp) { }

            }
            if (web_login.DocumentText.Contains("טוען תצוגה רגילה"))
            {
                web_login.Document.GetElementById("stb").Children[0].Children[1].InvokeMember("click");
                //web_login.Navigate(MygmailAccount.Link_gmail1);
            }
            while (web_login.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }
            AutoClosingMessageBox.Show("passworinsert", "-Caption 6-", 4000, textBox3);
            Boolean runer = true;
            while (runer)
            {
                if (web_login.Document.GetElementsByTagName("table").Count > 7)
                {
                    ANALYSIS_page();
                    runer = false;
                }
                Application.DoEvents();
            }
        }
        public void passworinsert()
        {                //set password

            while (!web_login.DocumentText.Contains(MygmailAccount.Input_pass_label)) { Application.DoEvents(); }
            while (web_login.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }
            AutoClosingMessageBox.Show("passworinsert", "-Caption 5-", 3000, textBox3);

            web_login.Document.GetElementById(MygmailAccount.Input_pass).SetAttribute("value", textBox2.Text);
            AutoClosingMessageBox.Show("passworinsert", "-Caption 6-", 3000, textBox3);
            web_login.Document.GetElementById(MygmailAccount.Login_btn).InvokeMember("click");

            AutoClosingMessageBox.Show("passworinsert", "-Caption 6-", 3000, textBox3);
            Boolean runer = true;
            while (runer)
            {
                if (web_login.DocumentText.Contains("טוען תצוגה רגילה"))
                {
                    web_login.Document.GetElementById("stb").InvokeMember("submit");

                    web_login.Navigate(MygmailAccount.Link_gmail1);
                    runer = false;
                }
                else
                {
                    Application.DoEvents();
                }
            }

        }
        protected void ANALYSIS_page()
        {
            PAGE_ANALYSIS myanalysis = new PAGE_ANALYSIS();
            List<Want_Ad> wd_list = new List<Want_Ad>();
            wd_list= myanalysis.CreateList(web_login);
            for(int indx = 0; indx < wd_list.Count; indx++)
            {
                mylist.Add(wd_list[indx]);
            }
            foreach (Want_Ad ad in wd_list)
            {
                if (!ad.From1.Equals(""))
                {
                    //listBox1.Items.Add(ad.From1);

                    dataGridView1.Rows.Add(false, ad.From1, ad.Link_to_page, "");
                }
            }


            counter = 0;
            myclock.Interval = 1000; // specify interval time as you want
            myclock.Tick += new EventHandler(timer_Tick);
            myclock.Start();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        static protected int counter = 0;
        private void button3_Click(object sender, EventArgs e)
        {


        }
        void timer_Tick(object sender, EventArgs e)
        {

            if (counter < mylist.Count)
            {
                if (!mylist[counter].From1.Equals(""))
                {
                    if (web_single_ad.DocumentText != "")
                    {
                        Ad_array.Add(web_single_ad.DocumentText);
                        
                        mylist[counter>0?counter - 1:0].Bodymail = web_single_ad.DocumentText;
                    }

                    web_single_ad.Navigate(mylist[counter].Link_to_page);
                    web_single_ad.ScriptErrorsSuppressed = true;
                    AutoClosingMessageBox.Show(MESSAGE_LABEL, "page:"+ page_count.ToString()+"open ad number:" + (counter + 1).ToString(), 3000, textBox3);


                    textBox3.SelectionStart = textBox3.Text.Length;
                    textBox3.ScrollToCaret();
                }
                counter++;
            }
            else
            {
                //:io
                //web_login.Document.GetElementById(":io").InvokeMember("click");
                page_count += 50;
                login();
                myclock.Start();
            }
        }

        static protected string end_of_link = "UploadSingle.aspx";
        static protected string strt_of_link = "http://www.google.com/url?q=";

        private Boolean Links_Extractor(List<Want_Ad> list)
        {

            foreach (Want_Ad wd in list)
            {

                if (wd.From1.Contains("AllJobs"))
                {
                    string HtmlText = wd.Bodymail;
                    if (string.IsNullOrWhiteSpace(HtmlText))
                    {
                        // Putting a div inside body forces control to use div instead of P (paragraph)
                        // when the user presses the enter button
                    }

                    WebBrowser wb = new WebBrowser();

                    wb.Navigate("about:blank");
                    wb.ScriptErrorsSuppressed = true;

                    if (wb.Document != null)
                    {
                        wb.Document.Write(string.Empty);
                    }
                    wb.DocumentText = HtmlText;

                    wb.DocumentText = "0";
                    wb.Document.OpenNew(true);
                    wb.Document.Write(HtmlText);
                    wb.Refresh();

                    string object_Str = Links_Extractor_To_Ad(wb.Document.GetElementsByTagName("a"), "");
                    char ch = '"';
                    string find = "href=";
                    string[] splitarray = object_Str.Split(new[] { find }, StringSplitOptions.None);
                    List<string> linksstack = new List<string>();
                    if (splitarray.Length > 0)
                    {
                        foreach (string singlelink in splitarray)
                        {
                            if (singlelink.Contains("www."))
                            {
                                string newlink = (singlelink.ToString()).Remove(0, 1);
                                int indx_of_end = newlink.IndexOf(ch), newEnd = 0;
                                newlink = newlink.Remove(indx_of_end, newlink.Length - indx_of_end);
                                //string FixLink = newlink.Remove(0, strt_of_link.Length+1);
                                //newEnd = FixLink.IndexOf(end_of_link);
                                //newEnd += end_of_link.Length;
                                //FixLink += FixLink.Remove(newEnd, FixLink.Length - newEnd);
                                Boolean exist = false;
                                foreach (string link in wd.Links_to_ad)
                                {
                                    if (link.Equals(newlink))
                                    {
                                        exist = true;
                                    }
                                }
                                if (!exist)
                                {
                                    wd.Links_to_ad.Add(newlink);
                                    listBox1.Items.Add(newlink);
                                }
                            }

                        }
                    }
                }
                else if (wd.From1.Contains("Jobmaster"))
                {
                        string HtmlText = wd.Bodymail;
                        if (string.IsNullOrWhiteSpace(HtmlText))
                        {
                            // Putting a div inside body forces control to use div instead of P (paragraph)
                            // when the user presses the enter button
                        }

                        WebBrowser wb = new WebBrowser();

                        wb.Navigate("about:blank");
                        wb.ScriptErrorsSuppressed = true;

                        if (wb.Document != null)
                        {
                            wb.Document.Write(string.Empty);
                        }
                        wb.DocumentText = HtmlText;

                        wb.DocumentText = "0";
                        wb.Document.OpenNew(true);
                        wb.Document.Write(HtmlText);
                        wb.Refresh();

                        string object_Str = Links_Extractor_To_Ad(wb.Document.GetElementsByTagName("a"), "");
                        char ch = '"';
                        string find = "href=";
                        string[] splitarray = object_Str.Split(new[] { find }, StringSplitOptions.None);
                        List<string> linksstack = new List<string>();
                        if (splitarray.Length > 0)
                        {
                            foreach (string singlelink in splitarray)
                            {
                                if (singlelink.Contains("www."))
                                {
                                string newlink = (singlelink.ToString()).Remove(0, 1);
                                int indx_of_end = newlink.IndexOf(ch), newEnd = 0;
                                newlink = newlink.Remove(indx_of_end, newlink.Length - indx_of_end);
                                //string FixLink = newlink.Remove(0, strt_of_link.Length+1);
                                //newEnd = FixLink.IndexOf(end_of_link);
                                //newEnd += end_of_link.Length;
                                //FixLink += FixLink.Remove(newEnd, FixLink.Length - newEnd);
                                Boolean exist = false;
                                foreach (string link in wd.Links_to_ad)
                                {
                                    if (link.Equals(newlink))
                                    {
                                        exist = true;
                                    }
                                }
                                if (!exist)
                                {
                                    wd.Links_to_ad.Add(newlink);
                                    listBox1.Items.Add(newlink);
                                }
                            }
                            }
                        }
                    }

            }
            return true;

        }
        public static string TextToHtml(string text)
        {
            text = HttpUtility.HtmlEncode(text);
            text = text.Replace("\r\n", "\r");
            text = text.Replace("\n", "\r");
            text = text.Replace("\r", "<br>\r\n");
            text = text.Replace("  ", " &nbsp;");
            return text;
        }
        List<WebBrowser> WebList = new List<WebBrowser>();
        private void button5_Click(object sender, EventArgs e)
        {
            Links_Extractor(mylist);

            foreach (Want_Ad ad in mylist)
            {
                foreach (string str in ad.Links_to_ad)
                {
                    if (!str.Equals(""))
                    {
                        WebBrowser wb = new WebBrowser();
                        wb.Navigate(str);
                        wb.ScriptErrorsSuppressed = true;
                        webBrowser1.Navigate(str);
                        webBrowser1.ScriptErrorsSuppressed = true;
                        WebList.Add(wb);
                    }
                    //  textBox5.Text+=str+ Environment.NewLine + Environment.NewLine;
                }
            }
            Boolean check = true;
            while (check)
            {
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                {
                    check = false;
                    string url = webBrowser1.Url.ToString();
                    string newurl = url.Remove(0, strt_of_link.Length);
                    int stop = newurl.IndexOf(end_of_link);

                    newurl = newurl.Remove(stop + end_of_link.Length, end_of_link.Length);

                    webBrowser1.Navigate(newurl);
                }
                else
                {
                    Application.DoEvents();
                }

            }
            myclock2.Interval = 15000; // specify interval time as you want
            myclock2.Tick += new EventHandler(timer_Tick_CV_SEND);
            myclock2.Start();
        }


        public string Links_Extractor_To_Ad(HtmlElementCollection theElementCollection, string result)
        {

            if (result.Equals(""))
            {
                foreach (HtmlElement element in theElementCollection)
                {
                    if (element.InnerText != null)
                    {
                        if (element.InnerText.ToString().Contains("צפה בפרטים מלאים") || element.InnerText.ToString().Contains("הגש מועמדות"))
                        {
                            string find = "href=", NewResult = "";
                            // int indx_ofFind = element.OuterHtml.ToString().IndexOf(find);
                            NewResult = element.OuterHtml.ToString();
                            //result = NewResult.Remove(0, NewResult.Length - indx_ofFind);
                            result += NewResult;
                        }
                    }
                    else
                    {
                        if (result.Equals(""))
                            result += Links_Extractor_To_Ad(element.Children, result);

                    }
                }
            }

            return (result);
        }
        static protected string loginObject_email = "in-email-c";
        static protected string loginObject_pass = "in-pass-c";

        static protected string AllJobes_link = "https://www.alljobs.co.il/SignIn/?SignInPointID=12&cfn=JobAfterSignInOrLogIn&JobID=4593290&manualresize=1&paramAffiliate=-1&position=&region=";
        static protected string AllJobes_link_1 = "https://www.alljobs.co.il/";
        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate(AllJobes_link);
            webBrowser2.ScriptErrorsSuppressed = true;
            HtmlElement email = null,pass=null;

            Boolean clickBut = false;

            Boolean check = true;
            while (check)
            {
                if (webBrowser2.ReadyState == WebBrowserReadyState.Complete)
                {



                    webBrowser2.Document.GetElementById("inputEmail").SetAttribute("value", "maorlevi1990@gmail.com");
                    webBrowser2.Document.GetElementById("inputPassword").SetAttribute("value", "orironi2014");
                    Boolean checkIner = true;
                    while (checkIner)
                    {
                            if (webBrowser2.Document.GetElementById("inputEmail").GetAttribute("value") != null && webBrowser2.Document.GetElementById("inputPassword").GetAttribute("value") != null)
                            {
                                check = false;
                                checkIner = false;
                                clickBut = true;

                                webBrowser2.Document.GetElementById("btn-submit-form").InvokeMember("click");
                                // MessageBox.Show(webBrowser2.Url.ToString().Remove(webBrowser2.Url.ToString().IndexOf("SignIn/"), webBrowser2.Url.ToString().Length - webBrowser2.Url.ToString().IndexOf("SignIn/")));
                        }
                        else
                            {
                                Application.DoEvents();
                            }

                        }
                    }
 
                else { Application.DoEvents();}

            }


          
        }
        static protected string end_of_link1 = "UploadSingle.aspx";
        static protected string strt_of_link1 = "http://www.google.com/url?q=";

        private void button6_Click(object sender, EventArgs e)
        {
             webBrowser2.Navigate(webBrowser2.Url.ToString().Remove(webBrowser2.Url.ToString().IndexOf("SignIn/"), webBrowser2.Url.ToString().Length- webBrowser2.Url.ToString().IndexOf("SignIn/")));


        }
        static protected int ListIndx = 0;
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (ListIndx < listBox1.Items.Count)
            {
                ListIndx++;

            }

            // newlink = newlink.Remove(newlink.IndexOf(end_of_link1), newlink.Length - newlink.IndexOf(end_of_link1));
           webBrowser1.Navigate(listBox1.Items[ListIndx].ToString());

            Boolean run = true;
            while (run)
            {
                if(webBrowser1.ReadyState == WebBrowserReadyState.Complete){
                    run = false;
                    
                    webBrowser1.Navigate(webBrowser1.Document.All[0].All[11].InnerText.ToString());
                    textBox6.Text = webBrowser1.Document.All[0].All[11].InnerText.ToString();
                    if (webBrowser1.Document.All[0].All[11].InnerText.ToString().Contains("alljobs")){
                        Boolean runto = true;
                        while (runto){
                            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete){
                                runto = false;

                                string buttnname = "job-content-bottom" + returnJobId(webBrowser1.Url.ToString());
                                //HtmlElementCollection list = webBrowser1.Document.GetElementById(buttnname).Children;
                                HtmlElementCollection list = webBrowser1.Document.GetElementsByTagName("div");
                                foreach (HtmlElement elem in list)
                                {
                                    if (elem.GetAttribute("className").ToString().Equals(""))
                                    {
                                        //    elem.InvokeMember("click");

                                    }
                                }
                            }else{Application.DoEvents();}
                        }
                    }else if (webBrowser1.Document.All[0].All[11].InnerText.ToString().Contains("jobmaster"))
                    {
                        Boolean runto = true;
                        while (runto)
                        {
                            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                            {
                                runto = false;
                                HtmlElementCollection list = webBrowser1.Document.GetElementsByTagName("input");
                                foreach (HtmlElement elem in list){
                                    if (elem.GetAttribute("className").ToString().Equals("bttn blue full")){
                                        elem.InvokeMember("click");
                                    }
                                }
                                Boolean runersendCv = true;
                                while (runersendCv){
                                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && webBrowser1.DocumentText.Contains("bttn blue SaveButton WithCancel")){
                                        runersendCv = false;
                                        HtmlElementCollection list2 = webBrowser1.Document.GetElementsByTagName("input");
                                        foreach (HtmlElement elem in list){
                                            if (elem.GetAttribute("className").ToString().Equals("bttn blue SaveButton WithCancel")){
                                                elem.InvokeMember("click");
                                            }
                                        }
                                    }else{Application.DoEvents();}
                                }
                            }else{Application.DoEvents();}
                        }
                    }
                }else{Application.DoEvents();}
            }
        }
        //=======================================================================================================================
        //++++++++++++++++++++++++++++++++++  CV SENDER +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //=======================================================================================================================
        protected Boolean sendCV()
        {
            try
            {

                if (ListIndx < listBox1.Items.Count)
                {
                    ListIndx++;

                }
                
                // newlink = newlink.Remove(newlink.IndexOf(end_of_link1), newlink.Length - newlink.IndexOf(end_of_link1));
                webBrowser1.Navigate(listBox1.Items[ListIndx].ToString());

                Boolean run = true;
                while (run)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        run = false;

                        webBrowser1.Navigate(webBrowser1.Document.All[0].All[11].InnerText.ToString());
                        textBox6.Text = webBrowser1.Document.All[0].All[11].InnerText.ToString();
                        if (webBrowser1.Document.All[0].All[11].InnerText.ToString().Contains("alljobs"))
                        {
                            Boolean runto = true;
                            while (runto)
                            {
                                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                                {
                                    runto = false;

                                    string buttnname = "job-content-bottom" + returnJobId(webBrowser1.Url.ToString());
                                    //HtmlElementCollection list = webBrowser1.Document.GetElementById(buttnname).Children;
                                    HtmlElementCollection list = webBrowser1.Document.GetElementsByTagName("div");
                                    foreach (HtmlElement elem in list)
                                    {
                                        if (elem.GetAttribute("className").ToString().Equals(""))
                                        {
                                            //    elem.InvokeMember("click");

                                        }
                                    }
                                }
                                else { Application.DoEvents(); }
                            }
                        }
                        else if (webBrowser1.Document.All[0].All[11].InnerText.ToString().Contains("jobmaster"))
                        {
                            Boolean runto = true;
                            while (runto)
                            {
                                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                                {
                                    runto = false;
                                    HtmlElementCollection list = webBrowser1.Document.GetElementsByTagName("input");
                                    foreach (HtmlElement elem in list)
                                    {
                                        if (elem.GetAttribute("className").ToString().Equals("bttn blue full"))
                                        {
                                            elem.InvokeMember("click");
                                        }
                                    }
                                    Boolean runersendCv = true;
                                    while (runersendCv)
                                    {
                                        if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && webBrowser1.DocumentText.Contains("bttn blue SaveButton WithCancel"))
                                        {
                                            runersendCv = false;
                                            HtmlElementCollection list2 = webBrowser1.Document.GetElementsByTagName("input");
                                            foreach (HtmlElement elem in list)
                                            {
                                                if (elem.GetAttribute("className").ToString().Equals("bttn blue SaveButton WithCancel"))
                                                {
                                                    elem.InvokeMember("click");
                                                }
                                            }
                                        }
                                        else { Application.DoEvents(); }
                                    }
                                }
                                else { Application.DoEvents(); }
                            }
                        }
                    }
                    else { Application.DoEvents(); }
                }

                return true;
            }catch(Exception exp)
            {
                return false;
            }
        }













        public static List<string> urlEncodedCharacters = new List<string>
{
  "/", "\\", "<", ">", ":", "\"", "|", "?", "%" //and others, but not *
};
        //Since this is a superset of urlEncodedCharacters, we won't be able to only use UrlEncode() - instead we'll use HexEncode
        public static List<string> specialCharactersNotAllowedInWindows = new List<string>
{
  "/", "\\", "<", ">", ":", "\"", "|", "?", "*" //windows dissallowed character set
};

        public static string Encode(string fileName)
        {
            //CheckForFullPath(fileName); // optional: make sure it's not a path?
            List<string> charactersToChange = new List<string>(specialCharactersNotAllowedInWindows);
            charactersToChange.AddRange(urlEncodedCharacters.
                Where(x => !urlEncodedCharacters.Union(specialCharactersNotAllowedInWindows).Contains(x)));   // add any non duplicates (%)

            charactersToChange.ForEach(s => fileName = fileName.Replace(s, Uri.HexEscape(s[0])));   // "?" => "%3f"

            return fileName;
        }




        private void button2_Click(object sender, EventArgs e)
        { 

            if (ListIndx > 0)
            {
                ListIndx--;

            }

            webBrowser1.Navigate(listBox1.Items[ListIndx].ToString());
        }
        //=================================================================================
        //+++++++++++++++++++++++          AllJobs      +++++++++++++++++++++++++++++++++
        //=================================================================================
        public string returnJobId(string link)
        {
            try
            {
                string newVar = link.Remove(0, link.IndexOf("JobIDs="));
                newVar = newVar.Remove(0, newVar.IndexOf(",")+1);
                newVar = newVar.Remove(newVar.IndexOf("&"), newVar.Length- newVar.IndexOf("&"));

                return newVar;
            }catch(Exception exp)
            {
                return "";
            }
        }


        //=================================================================================
        //+++++++++++++++++++++++          jobmaster      +++++++++++++++++++++++++++++++++
        //=================================================================================


        private void button7_Click(object sender, EventArgs e)
        {


        


        }



        protected Boolean LoginTOJobMaster()
        {
            try
            {

                webBrowser3.Navigate("https://www.jobmaster.co.il/code/korot/password.asp");
                webBrowser3.ScriptErrorsSuppressed = true;
                Boolean Loading = true;
                while (Loading)
                {
                    if (webBrowser3.ReadyState == WebBrowserReadyState.Complete)
                    {
                        Loading = false;
                        HtmlElementCollection ALLiNPUT = webBrowser3.Document.GetElementsByTagName("input");
                        foreach (HtmlElement element in ALLiNPUT)
                        {
                            if (element.Name.ToString().Equals("pemail"))
                            {
                                element.SetAttribute("value", "maorlevi1990@gmail.com");
                            }
                            if (element.Name.ToString().Equals("password"))
                            {
                                element.SetAttribute("value", "305505703");
                            }
                            if (element.GetAttribute("value").ToString().Equals("התחבר"))
                            {
                                element.InvokeMember("click");
                            }
                        }
                    }
                    else
                    {
                        Application.DoEvents();
                    }
                }
                return true;
            }catch(Exception excp)
            {
                return false;
            }
        }









        void timer_Tick_CV_SEND(object sender, EventArgs e)
        {

            if (ListIndx < listBox1.Items.Count)
            {
                
                // newlink = newlink.Remove(newlink.IndexOf(end_of_link1), newlink.Length - newlink.IndexOf(end_of_link1));
                webBrowser1.Navigate(listBox1.Items[ListIndx].ToString());

                Boolean run = true;
                while (run)
                {
                    if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                    {
                        run = false;

                        webBrowser1.Navigate(webBrowser1.Document.All[0].All[11].InnerText.ToString());
                        textBox6.Text = webBrowser1.Document.All[0].All[11].InnerText.ToString();
                        if (webBrowser1.Document.All[0].All[11].InnerText.ToString().Contains("alljobs"))
                        {
                            Boolean runto = true;
                            while (runto)
                            {
                                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                                {
                                    runto = false;

                                    string buttnname = "job-content-bottom" + returnJobId(webBrowser1.Url.ToString());
                                    //HtmlElementCollection list = webBrowser1.Document.GetElementById(buttnname).Children;
                                    HtmlElementCollection list = webBrowser1.Document.GetElementsByTagName("div");
                                    foreach (HtmlElement elem in list)
                                    {
                                        if (elem.GetAttribute("className").ToString().Equals(""))
                                        {
                                            //    elem.InvokeMember("click");

                                        }
                                    }
                                }
                                else { Application.DoEvents(); }
                            }
                        }
                        else if (webBrowser1.Document.All[0].All[11].InnerText.ToString().Contains("jobmaster"))
                        {
                            Boolean runto = true;
                            while (runto)
                            {
                                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                                {
                                    runto = false;
                                    HtmlElementCollection list = webBrowser1.Document.GetElementsByTagName("input");
                                    foreach (HtmlElement elem in list)
                                    {
                                        if (elem.GetAttribute("className").ToString().Equals("bttn blue full"))
                                        {
                                            elem.InvokeMember("click");
                                        }
                                    }
                                    Boolean runersendCv = true;
                                    while (runersendCv)
                                    {
                                        if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && webBrowser1.DocumentText.Contains("bttn blue SaveButton WithCancel"))
                                        {
                                            runersendCv = false;
                                            HtmlElementCollection list2 = webBrowser1.Document.GetElementsByTagName("input");
                                            foreach (HtmlElement elem in list)
                                            {
                                                if (elem.GetAttribute("className").ToString().Equals("bttn blue SaveButton WithCancel"))
                                                {
                                                    elem.InvokeMember("click");
                                                }
                                            }
                                        }
                                        else { Application.DoEvents(); }
                                    }
                                }
                                else { Application.DoEvents(); }
                            }
                        }
                    }
                    else { Application.DoEvents(); }


                }
                ListIndx++;

            }
            else
            {
                myclock.Stop();

            }
        }







        //private void button3_Click(object sender, EventArgs e)
        //{
        //    web_login.Navigate(MygmailAccount.Link_gmail1);
        //    while (web_login.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }
        //    AutoClosingMessageBox.Show("passworinsert", "-Caption 6-", 3000, textBox3);
        //    web_login.Document.GetElementById("stb").InvokeMember("submit");
        //}
    }
}
