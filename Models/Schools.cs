using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace universities.Models
{
    public class School

    {
        [Key]
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
        public List<SchoolType> latestprogramscip_4_digit { get; set; }

    }





    public class SchoolType
    {
        [Key]
        [JsonProperty("unit_id")]
        public string Id { get; set; }

        [JsonProperty("school.type")]
        public string Type { get; set; }
        //Navigation Property
        public School School { get; set; }
    }


    public class Schools //Page Response
    {

        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        public List<School> results { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }
        [JsonProperty("page")]
        public string Page { get; set; }
        [JsonProperty("per_page")]
        public string PerPage { get; set; }
    }


}
