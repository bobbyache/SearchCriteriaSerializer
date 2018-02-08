using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LastSearchCriteriaTests.Criteria
{
    public enum ComplianceSession
    {
        New,
        Old
    }

    public class BreachAgeGeneralCriteriaSection
    {
        [XmlAttribute("session")]
        public ComplianceSession Session { get; set; }

        [XmlAttribute("session-id")]
        public int SessionId { get; set; }

        [XmlAttribute("show-breach-ages")]
        public bool ShowBreachAges { get; set; }

        [XmlAttribute("show-overridden-breaches")]
        public bool ShowOverriddenBreaches { get; set; }

        [XmlAttribute("show-rule-groups")]
        public bool ShowRuleGroups { get; set; }
    }
}
