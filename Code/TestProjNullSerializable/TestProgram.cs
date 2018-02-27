using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// https://stackoverflow.com/questions/1295697/deserializing-empty-xml-attribute-value-into-nullable-int-property-using-xmlseri

namespace TestProjNullSerializable
{
    [XmlRoot("root")]
    public class DeserializeMe
    {
        [XmlArray("elements"), XmlArrayItem("element")]
        public List<Element> Element { get; set; }
    }

    public class Element : IXmlSerializable
    {
        public int? Value1 { get; private set; }
        public float? Value2 { get; private set; }

        public void ReadXml(XmlReader reader)
        {
            string attr1 = reader.GetAttribute("attr");
            string attr2 = reader.GetAttribute("attr2");
            reader.Read();

            Value1 = ConvertToNullable<int>(attr1);
            Value2 = ConvertToNullable<float>(attr2);
        }

        private static T? ConvertToNullable<T>(string inputValue) where T : struct
        {
            if (string.IsNullOrEmpty(inputValue) || inputValue.Trim().Length == 0)
            {
                return null;
            }

            try
            {
                TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                return (T)conv.ConvertFrom(inputValue);
            }
            catch (NotSupportedException)
            {
                // The conversion cannot be performed
                return null;
            }
        }

        public XmlSchema GetSchema() { return null; }
        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }

    class TestProgram
    {
        public static void Main(string[] args)
        {
            string xml = @"<root><elements><element attr='11' attr2='11.3'/><element attr='' attr2=''/></elements></root>";
            XmlSerializer deserializer = new XmlSerializer(typeof(DeserializeMe));
            Stream xmlStream = new MemoryStream(Encoding.ASCII.GetBytes(xml));
            var result = (DeserializeMe)deserializer.Deserialize(xmlStream);

            //string text = string.Empty;
            //using (StringWriter textWriter = new StringWriter())
            //{
            //    deserializer.Serialize(textWriter, result);
            //    text = textWriter.ToString();
            //}
        }
    }
}
