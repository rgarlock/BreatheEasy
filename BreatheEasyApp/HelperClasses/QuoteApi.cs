using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using BreatheEasyApp.Models.ViewModels;
using RestSharp;

namespace BreatheEasyApp.HelperClasses
{
    public class QuoteApi
    {
        public static QuoteContent GetQod()
        {
            var client = new RestClient("http://quotes.rest/qod.json");
            var request = new RestRequest("/", Method.GET);

            request.Parameters.Add(new Parameter { Name = "category", Value = "inspire", Type = ParameterType.QueryString });

            var response = client.Execute<QuoteResponse>(request);
            if (!response.IsSuccessful)
            {
                return null;
            }


            return response.Data.Contents.Quotes[0];
        }

            
    }
}