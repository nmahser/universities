using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using universities.Models;
using System.Diagnostics;
using universities.DataAccess;

namespace universities.APIHandlerManager
{
    public class APIHandler
    {

        static string BASE_URL = "https://api.data.gov/ed/collegescorecard/v1/schools";
        static string API_KEY = ""; //Add your API key here inside ""

        HttpClient httpClient;

        
        ///  Constructor to initialize the connection to the data source
        public APIHandler()
        {

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

      

        public Schools GetSchools()
        {
            string Universities_API_PATH = BASE_URL + "?latest.programs.cip_4_digit.code=1107&latest.programs.cip_4_digit.credential.level=5&per_page=100&fields=school.state,school.price_calculator_url,school.school_url,school.name,id,latest.cost.tuition.out_of_state,latest.cost.tuition.in_state,latest.student.size,latest.programs.cip_4_digit.school.type,latest.programs.cip_4_digit.unit_id&sort=school.state";
            string schoolsData = "";

            Schools schools = null;

            httpClient.BaseAddress = new Uri(Universities_API_PATH);


            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {

                HttpResponseMessage response = httpClient.GetAsync(Universities_API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {

                    schoolsData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                }

                if (!schoolsData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    // Handle null values in some of the properties
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    schools = JsonConvert.DeserializeObject<Schools>(schoolsData,settings);

                }

                else if  (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("ERROR:HTTP Response Status:" + response.IsSuccessStatusCode);
                }

            }
            catch (Exception e)
            {
               

                Console.WriteLine(e.Message);
            }


            return schools;
        }


    }
}
