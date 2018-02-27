using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlSerialize_01;

namespace LastSearchCriteriaTests
{
    [TestClass]
    public class XmlTests
    {
        [TestMethod]
        public void Test_SerializationOutput()
        {
            BreachCriteria criteria = new BreachCriteria();
            criteria.BreachContext = null;
            criteria.BreachStatus = 5;

            string xml = Xml.Serialize(criteria);
            //Assert.AreEqual("", xml);

            //BreachCriteria criteria2 = new BreachCriteria();
            BreachCriteria criteria2 = Xml.Deserialize<BreachCriteria>(xml);

            Assert.IsNull(criteria2.BreachContext);
            Assert.AreEqual(5, criteria2.BreachStatus);
        }
    }
}
