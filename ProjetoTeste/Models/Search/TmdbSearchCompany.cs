using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace ProjetoTeste.Models.Search
{
    public class TmdbSearchCompany
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("results")]
        public ResultCompany[] Results { get; set; }
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }

    public class ResultCompany
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("logo_path")]
        public string LogoPath { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("origin_country")]
        public string OriginCountry { get; set; }
    }
}
