#r "Newtonsoft.Json"

using System;
using Newtonsoft.Json;
using System.Threading.Tasks;

public static string Run(string mySbMsg, TraceWriter log)
{
    log.Info($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
           dynamic MyData = JsonConvert.DeserializeObject(mySbMsg);

            DateTime functiondate = MyData.functiondate;
            MyData.storefunctiondate = DateTime.UtcNow;

            //calculate time difference from sent to received and write to console
            TimeSpan timedifference = DateTime.UtcNow - functiondate;
            double timespan = timedifference.Milliseconds;
            MyData.functiontimespan = timespan;

            string outmessage = JsonConvert.SerializeObject(MyData);
            return outmessage;
}
