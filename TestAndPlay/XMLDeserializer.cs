using System;
using System.IO;
using System.Xml.Serialization;

namespace TestAndPlay
{
    class XMLDeserializer
    {
        public void Deserialize()
        {
            Console.WriteLine(File.Exists(@"E:\customfile.xml"));

            StreamReader s = new StreamReader(@"E:\customfile.xml");
            XmlSerializer x = new XmlSerializer(typeof(Vegetable));
            Vegetable v = (Vegetable)x.Deserialize(s);
            Console.WriteLine("Color is " + v.Color);
        }
    }
}
