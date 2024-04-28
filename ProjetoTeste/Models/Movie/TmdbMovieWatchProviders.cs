using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoTeste.Models.Movie
{
    //public record TmdbMovieWatchProviders(Dictionary<string, TmdbProviderCountry> Results);

    //public record TmdbProviderCountry(TmdbProviderDetail[] Flatrate);

    //public record TmdbProviderDetail(string Provider_Name);
    public class TmdbMovieWatchProviders
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("results")]
        public ResultsProViders Results { get; set; }
    }

    public class ResultsProViders
    {
        [JsonPropertyName("link")]
        public string Link { get; set; }
        [JsonPropertyName("BR")]
        public BR BR { get; set; }

    }

    public class BR
    {
        [JsonPropertyName("buy")]
        public Providers[] Buy { get; set; }
        [JsonPropertyName("rent")]
        public Providers[] Rent { get; set; }
        [JsonPropertyName("flatrate")]
        public Providers[] Flatrate { get; set; }
        [JsonPropertyName("ads")]
        public Providers[] Ads { get; set; }
    }

    public class Providers
    {
        [JsonPropertyName("logo_path")]
        public string LogoPath { get; set; }
        [JsonPropertyName("provider_id")]
        public int ProviderId { get; set; }
        [JsonPropertyName("provider_name")]
        public string ProviderName { get; set; }
        [JsonPropertyName("display_priority")]
        public int DisplayPriority { get; set; }
    }
}
