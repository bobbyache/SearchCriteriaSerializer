using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LastSearchCriteria
{
    public class CriteriaSectionSerializer
    {
        protected CriteriaSerializer serializer = new CriteriaSerializer();

        public XElement Serialize<T>(T criteriaSection) where T : class
        {
            return XElement.Parse(serializer.Serialize<T>(criteriaSection));
        }

        public T Deserialize<T>(XElement rootElement) where T : class
        {
            string elementName = typeof(T).Name;
            string elementXml = rootElement.Elements().Single(e => e.Name == elementName).ToString();
            return serializer.Deserialize<T>(elementXml);
        }
    }
}
