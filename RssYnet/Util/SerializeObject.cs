using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace rssYnet.Util
{
    public class SerializeObject
    {
        public static string JsonSerializeObject<T>(T obj)
        {

            //Create a stream to serialize the object to.
            var ms = new MemoryStream();

            // Serializer the User object to the stream.
            var ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(ms, obj);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json, 0, json.Length);

        }
        
        // Deserialize a JSON stream to a User object.
        public static T JsonDeserializeToObject<T>(string json)
        {

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(typeof(T));
            T deserialized = (T)ser.ReadObject(ms);
            ms.Close();
            return deserialized;
        }
    }
}
