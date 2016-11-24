using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using CbrRates.CbrIntegration.Extensions;
using CbrRates.CbrIntegration.Model;
using CbrRates.DataContract;

namespace CbrRates.CbrIntegration
{
    public class CbrService : ICbrService
    {
        private const string ServiceBaseUrl = @"http://www.cbr.ru/scripts/";
        private const string GetRateDynamicsRelativeUrl = @"XML_dynamic.asp?date_req1={0}&date_req2={1}&VAL_NM_RQ={2}";
        
        public GetRateDynamicsResponse GetRateDynamics(GetRateDynamicsRequest request)
        {
            if (request.StartDate > request.EndDate)
            {
                throw new ArgumentException("Дата начала должна быть больше даты конца", nameof(request.StartDate));
            }

            var url = ServiceBaseUrl + string.Format(GetRateDynamicsRelativeUrl, 
                request.StartDate.ToString(Constants.RequestDateFormat, CultureInfo.InvariantCulture),
                request.EndDate.ToString(Constants.RequestDateFormat, CultureInfo.InvariantCulture),
                request.CurrencyId);

            return CallService<GetRatesDynamicsXmlResponse>(url).ToDto();
        }

        private static T CallService<T>(string url)
        {
            var request = WebRequest.Create(url);

            using (var response = request.GetResponse())
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                }
            }
        }
    }
}
