using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.IO;

namespace Birth
{
    public class BirthTable : SAXParser
    {
        private static BirthTable birthTable = new BirthTable();
        public static BirthTable Instance
        {
            get { return birthTable; }
        }

        public static Dictionary<string, BirthInfo> birthDic = new Dictionary<string, BirthInfo>();

        #region(XML Read)
        protected override bool Read_Internal(XmlTextReader reader)
        {
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if ("BirthTable" == reader.Name)
                        continue;

                    reader.ReadAttributeValue();

                    if ("element" == reader.Name)
                    {
                        string id = reader.GetAttribute("id");
                        string name = reader.GetAttribute("name");
                        string date = reader.GetAttribute("date");

                        BirthInfo b = new BirthInfo(name, date);
                        if (birthDic.ContainsKey(id))
                        {
                            birthDic[id] = b;
                        }
                        else
                        {
                            birthDic.Add(id, b);
                        }
                    }
                    else
                    {
                        Debug.Assert(false);
                        return false;
                    }
                }
            }

            reader.Close();

            return true;
        }

        #endregion


    }
}