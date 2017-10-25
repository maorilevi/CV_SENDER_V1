using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CV_SENDER
{
    public class PAGE_ANALYSIS
    {
        static protected string[] WEBSITE_NAMES = { "Jobmaster","פורטל דרושים", "AllJobs‏" };

        static protected string TAG_LABEL = "table";
        static protected string CLASS_NAME = "\"F cf zt";
        public PAGE_ANALYSIS() {}
            public List<Want_Ad> CreateList(WebBrowser wb){

            List<Want_Ad> wantd_list = new List<Want_Ad>();

            HtmlElementCollection theElementCollection = default(HtmlElementCollection);
            theElementCollection = wb.Document.GetElementsByTagName(TAG_LABEL);
            //theElementCollection2 = theElementCollection[7].Children;
            foreach (HtmlElement element_row in theElementCollection[8].Children)
            {
                foreach(HtmlElement SINGLE_LINE in element_row.Children)
                {
                    wantd_list.Add(CREATE_ROW(SINGLE_LINE, wb.Url.ToString()));
                }
            }
            //foreach(HtmlElement element in theElementCollection)
            //{
            //    if (element.OuterHtml.Contains("class=" + CLASS_NAME)|| element.OuterHtml.Contains("class=m"))
            //    {
            //        int indx = 0;
            //        if(element.OuterHtml.Contains("class=" + CLASS_NAME))
            //            indx = 1;
            //        else if (element.OuterHtml.Contains("class=m"))
            //            indx = 0;
            //        foreach (HtmlElement element_row in element.Children[indx].Children)
            //        {
            //            CREATE_ROW(element_row);
            //        }
            //    }
            //}
          


            return wantd_list;

        } 





        //<p style = "text-align: right;" > &nbsp;&nbsp;<span id = ":36" class="aXw T-KT" title="לא מסומן בכוכב" aria-label="לא מסומן בכוכב"><img class="T-KT-JX" src="images/cleardot.gif" alt="לא מסומן בכוכב" /></span></p>
        //<div id = ":37" class="pG" style="text-align: right;" role="img" aria-label="לא חשוב" data-tooltip-align="b,l" data-tooltip-delay="1500" data-tooltip-contained="true">
        //<div class="T-ays-a45"><span class="aol">לחץ כדי ללמד את Gmail ששיחה זו חשובה.</span></div>
        //<div class="pH-A7 a9q">&nbsp;</div>
        //<div class="bnj ">&nbsp;</div>
        //</div>
        //<div id = ":33" class="afn" style="text-align: right;">לא נקרא, <span dir = "ltr" >< span class="zF">Jobmaster.co.il</span></span>&rlm;, <strong>דרוש/ה: מפתח/ת BI עם ידע בCOGNOS,SSIS,SSASלפורטל ידע במש ממשלתי</strong>, <strong>19:53</strong>, מאור לוי שלום רב, באתר ג'וב מאסטר פורסמה מודעת דרושים חדשה ע"י מעסיק פוטנציאלי. תפקיד: מפתח/ת BI עם ידע בCOGNOS,SSIS,SSASלפורטל ידע במש' ממשלתי בתחום: מחשבים ותוכנה - מתכנת - מיקום משרה:.</div>
        //<div id = ":38" class="yW" style="text-align: right;"><span dir = "ltr" >< span class="zF">Jobmaster.co.il</span></span>&rlm;</div>
        //<div class="xS" style="text-align: right;" role="link">
        //<div class="xT">
        //<div class="y6"><span id = ":3b" class="bog"><strong>דרוש/ה: מפתח/ת BI עם ידע בCOGNOS,SSIS,SSASלפורטל ידע במש ממשלתי</strong></span><span class="y2">&nbsp;-&nbsp;מאור לוי שלום רב, באתר ג'וב מאסטר פורסמה מודעת דרושים חדשה ע"י מעסיק פוטנציאלי. תפקיד: מפתח/ת BI עם ידע בCOGNOS,SSIS,SSASלפורטל ידע במש' ממשלתי בתחום: מחשבים ותוכנה - מתכנת - מיקום משרה:</span></div>
        //</div>
        //</div>
        //<p style = "text-align: right;" > &nbsp;<span id = ":3c" title="25 בספטמבר 2017 בשעה 19:53" aria-label="25 בספטמבר 2017 בשעה 19:53"><strong>19:53</strong></span></p>











        //<TD width = "1%" noWrap><INPUT type = checkbox value=15ebe50f544d3cdf name = t >< IMG border=0 alt="" src="https://ssl.gstatic.com/ui/v1/icons/mail/images/cleardot.gif" width=15 height=15></TD>
        //<TD width = "25%" >< B > פורטל דרושים</B>(5)</TD>
        //<TD width = "73%" >< A href="?&amp;th=15ebe50f544d3cdf&amp;v=c"><SPAN class=ts><FONT size = 1 >< FONT color=#006633></FONT></FONT><B>3 משרות חדשות שפורסמו היום בפורטל דרושים</B><FONT color=#7777cc> - פורטל דרושים שלום maor, 26/09/2017 להלן 3 משרות חדשות העונות להגדרות הסוכן החכם שלכם: לצפיה ב-3 המשרות באתר הלוח שלי: לוח משרות מותאמות אישית ע"פ הגדרות הסוכן החכםלכניסה ללוח » ASP.NET Software</FONT></SPAN></A></TD>
        //<TD width = "1%" noWrap><B>16:12</B></TD>
        protected Want_Ad CREATE_ROW(HtmlElement element2,string mainurl)
        {
            string label_A= "A";
            string new_row = "";
            string link = "";
            string start_a_index="< A href =\"";
            string end_a_index = ">";

            Want_Ad NEW_ROW = new Want_Ad();

            foreach (HtmlElement NEW_ELEMENT in element2.Children)
            {
                if (NEW_ELEMENT.InnerText != null)
                {
                    foreach (string str in WEBSITE_NAMES)
                    {
                        if (NEW_ELEMENT.InnerText.Contains(str))
                        {
                            new_row += str;
                        }
                    }
                } //"<A href=\"?&amp;th=15ec819898467f19&amp;v=c\"><SPAN class=ts><FONT size=1><FONT color=#006633></FONT></FONT><B>נמצאו 8 משרות חדשות שמתאימות לך, פרסומות והטבות</B><FONT color=#7777cc> - מאור שלום, להלן משרות שפורסמו באתר ומתאימות להגדרות החיפוש שלך משרה חמה! בודק /ת BI /DWH חברה: טלדור Taldor - מערכות מחשבים מקום העבודה: לוד סוג משרה: משרה מלאה דרוש /ה בודק /ת BI/DWH לארגון בריאות</FONT></SPAN></A>"
                if (NEW_ELEMENT.Children.Count>0)
                {
                    if (NEW_ELEMENT.Children[0].TagName == label_A)
                    {
                        int indx_1 = NEW_ELEMENT.Children[0].OuterHtml.IndexOf(end_a_index);

                        int indx_2 = NEW_ELEMENT.Children[0].OuterHtml.IndexOf(start_a_index)+ start_a_index.Length;

                        int length = NEW_ELEMENT.Children[0].OuterHtml.Length;

                        string newlink = NEW_ELEMENT.Children[0].OuterHtml.Remove(indx_1-1, (length - indx_1)+1);
                        //&amp;
                        newlink = newlink.Remove(0, indx_2);
                        mainurl += newlink;
                        mainurl=Regex.Replace(mainurl, @"&amp;", "&");
                        
                        //Regex.Replace(mainurl.Replace(Environment.NewLine, " "), "<.*?>", String.Empty);
                        link = NEW_ELEMENT.Children[0].OuterHtml;
                    }

                }
            }
            NEW_ROW.Link_to_page = mainurl;
            NEW_ROW.From1 = new_row;
            return NEW_ROW;

        }



    }
}
