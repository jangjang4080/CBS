using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWICE
{
    class MemberCollection
    {
        public ObjectId Id { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string info { get; set; }
        public string imageurl { get; set; }
    }

    public class TWICEDB
    {
        public static Dictionary<string, MemberInfo> memberDic = new Dictionary<string, MemberInfo>();

        public void Read()
        {
            memberDic.Clear();

            var client = new MongoClient(Env.dbIPAdress);
            var db = client.GetDatabase("TWICE");
            var collection = db.GetCollection<MemberCollection>("Member");
            var filter = Builders<MemberCollection>.Filter.Empty;
            foreach (var member in collection.Find(filter).ToListAsync().Result)
            {
                MemberInfo memberInfo = new MemberInfo(member.name, member.info, member.imageurl);
                memberDic.Add(member.id, memberInfo);

                System.Console.WriteLine(memberInfo.name);
                System.Console.WriteLine(memberInfo.info);
                System.Console.WriteLine(member.imageurl);
            }
        }
    }
}
