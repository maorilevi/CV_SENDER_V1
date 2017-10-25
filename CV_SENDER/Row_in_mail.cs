using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_SENDER
{
    public class Row_in_mail
    {
        public Row_in_mail()
        {
        }

            private string from = "";
        private DateTime receive_at;

        public string From { get => from; set => from = value; }
        public DateTime Receive_at { get => receive_at; set => receive_at = value; }
    }
}
