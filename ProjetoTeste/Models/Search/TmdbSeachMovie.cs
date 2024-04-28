using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProjetoTeste.Models.Movie;

namespace ProjetoTeste.Models.Search
{
    public class TmdbSeachMovie
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("results")]
        public ResultMovie[] Results { get; set; }
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

    }

    public class ResultMovie
    {
        [JsonPropertyName("adult")]
        public bool Adult { get; set; }
        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; set; }
        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }
        [JsonPropertyName("overview")]
        public string Overview { get; set; }
        [JsonPropertyName("popularity")]
        public float Popularity { get; set; }
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("video")]
        public bool video { get; set; }
        [JsonPropertyName("vote_average")]
        public float VoteAvarage { get; set; }
        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }
    }
}
