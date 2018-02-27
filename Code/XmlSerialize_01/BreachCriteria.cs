using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSerialize_01
{
    public class BreachCriteria
    {
        [XmlAttribute("breach-context")]
        public int? BreachContext { get; set; }

        [XmlIgnore]
        public bool BreachContextSpecified { get { return BreachContext.HasValue; } }

        [XmlAttribute("breach-status")]
        public int? BreachStatus { get; set; }

        public BreachCriteria()
        {
        }
    }
}
