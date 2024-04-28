using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoTeste.Models.Search
{
    public class TmdbSeachTv
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("results")]
        public ResultTv[] Results { get; set; }
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

    }

    public class ResultTv
    {
        [JsonPropertyName("adult")]
        public bool Adult { get; set; }
        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; set; }
        [JsonPropertyName("original_name")]
        public string OriginalName { get; set; }
        [JsonPropertyName("overview")]
        public string Overview { get; set; }
        [JsonPropertyName("popularity")]
        public float Popularity { get; set; }
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
        [JsonPropertyName("first_air_date")]
        public string FirstAirDate { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("vote_average")]
        public float VoteAvarage { get; set; }
        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }
    }
}
