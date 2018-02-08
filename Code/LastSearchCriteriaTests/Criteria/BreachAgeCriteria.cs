using LastSearchCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LastSearchCriteriaTests.Criteria
{
    public class BreachAgeCriteria : SectionedCriteriaSerializer
    {
        private BreachAgeGeneralCriteriaSection generalCriteria;

        public ComplianceSession Session
        {
            get { return generalCriteria.Session; }
            set { generalCriteria.Session = value; }
        }
        public int SessionId
        {
            get { return generalCriteria.SessionId; }
            set { generalCriteria.SessionId = value; }
        }

        public bool ShowBreachAges
        {
            get { return generalCriteria.ShowBreachAges; }
            set { generalCriteria.ShowBreachAges = value; }
        }

        public bool ShowOverriddenBreaches
        {
            get { return generalCriteria.ShowOverriddenBreaches; }
            set { generalCriteria.ShowOverriddenBreaches = value; }
        }

        public bool ShowRuleGroups
        {
            get { return generalCriteria.ShowRuleGroups; }
            set { generalCriteria.ShowRuleGroups = value; }
        }

        public BreachAgeCriteria()
        {
            this.generalCriteria = new BreachAgeGeneralCriteriaSection();
        }

        public BreachAgeCriteria(string xml)
        {
            XElement element = XElement.Parse(xml);
            generalCriteria = Deserialize<BreachAgeGeneralCriteriaSection>(element);
        }

        public string Serialize()
        {
            XElement element = new XElement(this.GetType().Name);

            element.Add(Serialize(generalCriteria));

            return element.ToString();
        }
    }
}
