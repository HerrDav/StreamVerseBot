using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoTeste.Models.TV
{
    public class TmdbResponseSerie
    {
        [JsonPropertyName("results")]
        public TmdbSerie[] Results { get; set; }
    }

    public class TmdbSerie
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("overview")]
        public string Overview { get; set; }
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
    }

    public record TmbdResponseEpisode(TmdbEpisode[] Results);
    public record TmdbEpisode(string air_date, string name, string overview, string still_path);
}