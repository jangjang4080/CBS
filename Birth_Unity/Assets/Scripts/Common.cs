using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWICE
{
    public class MemberInfo
    {
        public string name;
        public string info;
        public string imageURL;

        public MemberInfo(string name, string info, string imageURL)
        {
            this.name = name;
            this.info = info;
            this.imageURL = imageURL;
        }
    }
}
