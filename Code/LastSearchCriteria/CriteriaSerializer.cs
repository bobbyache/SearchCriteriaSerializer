using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LastSearchCriteria
{
    public class CriteriaSerializer
    {
        public string Serialize<T>(T criteria) where T : class
        {
            if (criteria == null)
            {
                return string.Empty;
            }

            var xmlserializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            var settings = new XmlWriterSettings();

            settings.OmitXmlDeclaration = true;
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = XmlWriter.Create(stringWriter, settings))
            {

                xmlserializer.Serialize(writer, criteria, namespaces);
                return stringWriter.ToString();
            }
        }

        public T Deserialize<T>(string xml) where T : class
        {
            using (var reader = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
