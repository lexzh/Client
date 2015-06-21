using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class AttachParser
    {
        private string messageAlarmText;

        public string MessageAlarmText
        {
            get
            {
                return this.messageAlarmText;
            }
            set
            {
                this.messageAlarmText = value;
            }
        }

        protected AttachParser()
        {
        }

        public virtual string Parse()
        {
            return string.Empty;
        }
    }
}
