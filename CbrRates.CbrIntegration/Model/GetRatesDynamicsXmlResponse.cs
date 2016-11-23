using System.Xml.Serialization;

namespace CbrRates.CbrIntegration.Model
{
    [XmlRoot("ValCurs")]
    public class GetRatesDynamicsXmlResponse
    {
        [XmlAttribute(AttributeName = "ID")]
        public string CurrencyId { get; set; }

        [XmlAttribute(AttributeName = "DateRange1")]
        public string DateFrom { get; set; }

        [XmlAttribute(AttributeName = "DateRange2")]
        public string DateTo { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Record")]
        public GetRatesDynamicsXmlResponseRecord[] Records { get; set; }
    }
}
