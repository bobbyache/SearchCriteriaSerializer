using System.Xml.Linq;

namespace LastSearchCriteria
{
    public interface ICriteriaSerializer
    {
        T Deserialize<T>(XElement rootElement) where T : class;
        XElement Serialize<T>(T criteriaSection) where T : class;
    }
}