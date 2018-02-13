using LastSearchCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LastSearchCriteriaTests.Criteria
{
    public class CriteriaSectionGroup : ISerializable
    {
        private ICriteriaSerializer serializer;
        private CriteriaSection generalCriteria;

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


        public CriteriaSectionGroup(ICriteriaSerializer serializer)
        {
            this.generalCriteria = new CriteriaSection();
            if (serializer == null)
                throw new ArgumentNullException("Serializer must be defined for this construct.");
            this.serializer = serializer;
        }

        public CriteriaSectionGroup(ICriteriaSerializer serializer, string xml)
        {
            if (serializer == null)
                throw new ArgumentNullException("Serializer must be defined for this construct.");
            this.serializer = serializer;

            this.Deserialize(xml);
        }

        public string Serialize()
        {
            XElement element = new XElement(this.GetType().Name);

            element.Add(serializer.Serialize(generalCriteria));

            return element.ToString();
        }

        private void Deserialize(string serializedEntity)
        {
            XElement element = XElement.Parse(serializedEntity);
            generalCriteria = serializer.Deserialize<CriteriaSection>(element);
        }
    }
}
