using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace universities.Models
{ 
        public class School

        {

            [JsonProperty("id")]
            public int Id { get; set; }
            
            [JsonProperty("latest.cost.tuition.out_of_state")]       
            public int TuitionOutOfState { get; set; }
        
            [JsonProperty("school.price_calculator_url")]    
            public string PriceCalculatorUrl { get; set; }

            [JsonProperty("school.school_url")]  
            public string Url { get; set; }

            [JsonProperty("latest.cost.tuition.in_state")]
            public int TuitionInState { get; set; }

            [JsonProperty("school.name")]
            public string Name { get; set; }

            [JsonProperty("school.state")]
            public string State { get; set; }

            [JsonProperty("latest.student.size")]
            public int Studentsize { get; set; }

            [JsonProperty("latest.programs.cip_4_digit")]
            public List<Type> latestprogramscip_4_digit { get; set; }
        }

        
        public class Type
        {
            [JsonProperty("school.type")]
            public string SchoolType { get; set; }
        }

        public class Schools
        {
            public List<School> results { get; set; }
        }

   }
