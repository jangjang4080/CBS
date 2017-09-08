using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birth
{
    class BirthCollection
    {
        public ObjectId Id { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
    }

    public class BirthDB
    {
        public static Dictionary<string, BirthInfo> birthDic = new Dictionary<string, BirthInfo>();

        public void Read()
        {
            var client = new MongoClient("mongodb://49.165.232.70:27017");
            var db = client.GetDatabase("Birth");
            var birthCollection = db.GetCollection<BirthCollection>("2018");
            var filter = Builders<BirthCollection>.Filter.Empty;
            foreach (var birth in birthCollection.Find(filter).ToListAsync().Result)
            {
                BirthInfo info = new BirthInfo(birth.name, birth.date.ToShortDateString());
                birthDic.Add(birth.id, info);

                //System.Console.WriteLine(birth.name);
                //System.Console.WriteLine(birth.date.ToShortDateString());
            }
        }
    }
}
