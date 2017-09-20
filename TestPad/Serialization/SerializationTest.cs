using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace TestPad.Serialization
{
    public class SerializationTest
    {
        static void DateTimeOffsetSerialization()
        {
            var dto = DateTimeOffset.Now;
            Console.WriteLine(dto);
            Console.WriteLine(dto.ToString());
            Console.WriteLine(dto.ToString("o"));
            Console.WriteLine(dto.ToString("r"));
            Console.WriteLine(dto.ToString("u"));
            Console.WriteLine(dto.ToString("s"));
            var s = dto.ToString("o");
            var dto1 = DateTimeOffset.Parse(s);
            if (dto == dto1)
            {
                Console.WriteLine("Worked");
            }
            else
            {
                Console.WriteLine("Failed");
            }
            var ns = JsonConvert.SerializeObject(dto);
            var dto2 = JsonConvert.DeserializeObject<DateTimeOffset>(ns);
            if (dto == dto2)
            {
                Console.WriteLine("Worked");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            var dcs = SerializeUsingDCJS(dto);
            var dto3 = DeserializeUsingDCJS<DateTimeOffset>(dcs);
            if (dto == dto3)
            {
                Console.WriteLine("Worked");
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }

        static string SerializeUsingDCJS<T>(T value)
        {
            using (var stream = new MemoryStream())
            {
                var dcs = new DataContractJsonSerializer(typeof(T));
                dcs.WriteObject(stream, value);
                stream.Position = 0;
                using (var sr = new StreamReader(stream))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        static T DeserializeUsingDCJS<T>(string value)
        {
            using (var stream = new MemoryStream(Encoding.ASCII.GetBytes(value)))
            {
                stream.Position = 0;
                var dcs = new DataContractJsonSerializer(typeof(T));
                T item = (T)dcs.ReadObject(stream);
                return item;
            }
        }
    }
}
