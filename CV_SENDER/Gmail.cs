using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_SENDER
{
    public class Gmail
    {
        public Gmail() { }




        //**************************************************************************
        //<<<<<<<<<<<<<<<<<<<<<    login variabels    >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //**************************************************************************
        private string input_pass_label = "סיסמה";
        private string input_pass = "Passwd";
        private string input_email = "Email";
        private string next_btn = "next";
        private string login_btn="signIn";
        private string Link_gmail = "https://mail.google.com/mail/";
        private string Link_gmail2 = "https://mail.google.com/mail/u/0/h/1bjyfdtv42fdg/?&st=";
        public string Input_pass_label { get => input_pass_label; set => input_pass_label = value; }
        public string Input_pass { get => input_pass; set => input_pass = value; }
        public string Input_email { get => input_email; set => input_email = value; }
        public string Next_btn { get => next_btn; set => next_btn = value; }
        public string Login_btn { get => login_btn; set => login_btn = value; }
        public string Link_gmail1 { get => Link_gmail; set => Link_gmail = value; }
        public string Link_gmail21 { get => Link_gmail2; set => Link_gmail2 = value; }
    }
}
