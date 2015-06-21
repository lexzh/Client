using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PublicClass;
using WinFormsUI.Controls;
using System.Data;

namespace Client
{
    class AttachInfoResolve
    {
        public AttachInfoResolve()
        {
        }

        public void Set(ThreeStateTreeNode myNode, DataRow dr)
        {
            string str;
            try
            {
                string str1 = string.Concat("Attach_", myNode.CarId);
                string str2 = string.Concat("Attach_", dr["OrderID"].ToString(), "_", dr["CarID"].ToString());
                if (dr.Table.ExtendedProperties.ContainsKey(str1))
                {
                    str = dr.Table.ExtendedProperties[str1].ToString();
                }
                else
                {
                    str = (dr.Table.ExtendedProperties.ContainsKey(str2) ? dr.Table.ExtendedProperties[str2].ToString() : "");
                }
                string str3 = str;
                if (str3.Length > 0)
                {
                    AttachData attachDatum = new AttachData(str3);
                    string str4 = attachDatum.ParseAttachData("1", "");
                    if (str4.Trim().Length <= 0)
                    {
                        str4 = attachDatum.ParseAttachData("01", "");
                        if (str4.Trim().Length > 0)
                        {
                            myNode.DynamicAttr["oil"] = string.Concat(str4, "L");
                        }
                    }
                    else
                    {
                        myNode.DynamicAttr["oil"] = string.Concat(str4, "L");
                    }
                    str4 = attachDatum.ParseAttachData("D1", "1");
                    if (str4.Trim().Length <= 0 || !str4.Equals("1"))
                    {
                        str4 = attachDatum.ParseAttachData("D1", "0");
                        if (str4.Trim().Length <= 0 || !str4.Equals("1"))
                        {
                            myNode.DynamicAttr["罐子状态"] = "停转";
                        }
                        else
                        {
                            myNode.DynamicAttr["罐子状态"] = "卸料";
                        }
                    }
                    else
                    {
                        myNode.DynamicAttr["罐子状态"] = "搅拌";
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord(string.Concat("附加报文解析异常：", exception.ToString()));
            }
        }
    }

}
