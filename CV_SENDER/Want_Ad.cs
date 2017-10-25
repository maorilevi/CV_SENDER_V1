using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_SENDER
{
    public class Want_Ad
    {

        private string From = "";

        private string link_to_page = "";

        private string alltext= "";


        private string bodymail = "";
        private List<string> links_to_ad = new List<string>();
        public Want_Ad() { }

        public string From1 { get => From; set => From = value; }
        public string Link_to_page { get => link_to_page; set => link_to_page = value; }
        public string Alltext { get => alltext; set => alltext = value; }
        public string Bodymail { get => bodymail; set => bodymail = value; }
        public List<string> Links_to_ad { get => links_to_ad; set => links_to_ad = value; }
    }
}
