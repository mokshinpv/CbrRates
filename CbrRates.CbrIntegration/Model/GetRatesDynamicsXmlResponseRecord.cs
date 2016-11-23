using System.Xml.Serialization;

namespace CbrRates.CbrIntegration.Model
{
    [XmlRoot(ElementName = "Record")]
    public class GetRatesDynamicsXmlResponseRecord
    {
        [XmlAttribute("Date")]
        public string Date { get; set; }

        [XmlAttribute("Id")]
        public string CurrencyId { get; set; }

        [XmlElement(ElementName = "Nominal")]
        public int Nominal { get; set; }

        [XmlElement(ElementName = "Value")]
        public string Value { get; set; }
    }
}
