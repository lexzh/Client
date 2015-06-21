using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class DoorState : AttachParser
    {
        private int _type;

        public DoorState(int type)
        {
            this._type = type;
        }

        public DoorState(string messageData)
        {
            base.MessageAlarmText = messageData;
        }

        public override string Parse()
        {
            StringBuilder stringBuilder = new StringBuilder();
            byte num = Convert.ToByte(base.MessageAlarmText.Substring(0, 2), 16);
            if (this._type == 0)
            {
                if ((num & 4) != 4)
                {
                    return "0";
                }
                return "1";
            }
            if (this._type != 1)
            {
                return "0";
            }
            if ((num & 1) != 1)
            {
                return "0";
            }
            return "1";
        }
    }
}
