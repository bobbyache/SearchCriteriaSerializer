﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;
using LastSearchCriteria;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using LastSearchCriteriaTests.Criteria;

namespace LastSearchCriteriaTests
{
    [TestClass]
    public class SerializerTests
    {
        [TestMethod]
        public void CriteriaSection_CanBeSerializedAndDeserialized_Using_Serializer()
        {
            CriteriaSerializer serializer = new CriteriaSerializer();

            BreachAgeGeneralCriteriaSection criteria = new BreachAgeGeneralCriteriaSection
            {
                Session = ComplianceSession.New,
                SessionId = 2,
                ShowBreachAges = true,
                ShowOverriddenBreaches = true,
                ShowRuleGroups = false
            };

            string xml = serializer.Serialize<BreachAgeGeneralCriteriaSection>(criteria);
            BreachAgeGeneralCriteriaSection crit = serializer.Deserialize<BreachAgeGeneralCriteriaSection>(xml);

            Assert.AreEqual(CompactXml("<BreachAgeGeneralCriteriaSection session=\"New\" session-id=\"2\" show-breach-ages=\"true\" show-overridden-breaches=\"true\" show-rule-groups=\"false\" />"), CompactXml(xml));
        }

        [TestMethod]
        public void BreachAgeCriteria_WhenInstantiatedAndSerialized_Returns_SingleClosedXmlTag()
        {
            BreachAgeCriteria breachAgeCriteria = new BreachAgeCriteria();
            breachAgeCriteria.Session = ComplianceSession.New;
            breachAgeCriteria.SessionId = 2;
            breachAgeCriteria.ShowBreachAges = true;
            breachAgeCriteria.ShowOverriddenBreaches = true;
            breachAgeCriteria.ShowRuleGroups = false;

            string expectedXml = CompactXml("<BreachAgeCriteria><BreachAgeGeneralCriteriaSection session=\"New\" session-id=\"2\" show-breach-ages=\"true\" show-overridden-breaches=\"true\" show-rule-groups=\"false\" /></BreachAgeCriteria>");
            string generatedXml = CompactXml(breachAgeCriteria.Serialize());

            Assert.AreEqual(expectedXml, generatedXml);
        }

        public static string CompactXml(string xml)
        {
            return System.Text.RegularExpressions.Regex.Replace(xml, "[ \t\n\r\v\f]", "");
        }

        [TestMethod]
        public void BreachAgeCriteria_WhenInstantiated_ViaXml_Returns_Correct_Values()
        {
            string xml = "<BreachAgeCriteria><BreachAgeGeneralCriteriaSection session=\"New\" session-id=\"2\" show-breach-ages=\"true\" show-overridden-breaches=\"true\" show-rule-groups=\"false\" /></BreachAgeCriteria>";
            BreachAgeCriteria breachAgeCriteria = new BreachAgeCriteria(xml);

            Assert.AreEqual(ComplianceSession.New, breachAgeCriteria.Session);
            Assert.AreEqual(2, breachAgeCriteria.SessionId);
            Assert.AreEqual(true, breachAgeCriteria.ShowBreachAges);
            Assert.AreEqual(true, breachAgeCriteria.ShowOverriddenBreaches);
            Assert.AreEqual(false, breachAgeCriteria.ShowRuleGroups);
        }
    }
}
