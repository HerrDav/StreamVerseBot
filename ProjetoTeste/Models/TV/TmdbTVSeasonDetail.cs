using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProjetoTeste.Models.Movie;

namespace ProjetoTeste.Models.TV
{
    public class TmdbTVSeasonDetail
    {
        [JsonPropertyName("_id")]
        public string _Id { get; set; }
        [JsonPropertyName("air_date")]
        public string AirDate { get; set; }

        [JsonPropertyName("episodes")]
        public Episodes[] Episodes { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("overview")]
        public string Overview { get; set; }
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

    }

    public class Episodes
    {
        [JsonPropertyName("air_date")]
        public string AirDate { get; set; }
        [JsonPropertyName("episode_number")]
        public int EpisodeNumber { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }
    }
}
