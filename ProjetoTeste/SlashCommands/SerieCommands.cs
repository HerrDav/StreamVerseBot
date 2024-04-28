using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using ProjetoTeste.Models.TV;
using ProjetoTeste.Models.Search;
using ProjetoTeste.Models.Movie;

namespace ProjetoTeste.SlashCommands
{
    public class SerieCommands : ApplicationCommandModule
    {
        [SlashCommand("serie", "Busca informações de uma série pelo nome, temporada e episódio")]
        public async Task Serie(InteractionContext ctx,
        [Option("Name", "Nome da série a ser pesquisada")] string nomeSerie,
        [Option("Season", "Número da Season")] long temporada,
        [Option("Episode", "Número do Episódio")] long? episodio = null)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true));

            var httpClient = new HttpClient();
            //Necessario capturar a API Key pela themoviedb.org
            string apiKey = "";


            string searchUrl = $"https://api.themoviedb.org/3/search/tv?api_key={apiKey}&query={Uri.EscapeDataString(nomeSerie)}&language=pt-BR";

            var searchResponse = await httpClient.GetAsync(searchUrl);
            if (searchResponse.IsSuccessStatusCode)
            {
                var searchContent = await searchResponse.Content.ReadAsStringAsync();
                var searchResult = System.Text.Json.JsonSerializer.Deserialize<TmdbSeachTv>(searchContent);

                if (searchResult != null && searchResult.Results.Length > 0)
                {
                    var serie = searchResult.Results[0]; // Assume a primeira série da lista
                                                            // Agora que temos o ID da série, vamos buscar a temporada e o episódio

                    if (episodio != null)
                    {
                        string episodeUrl = $"https://api.themoviedb.org/3/tv/{serie.Id}/season/{temporada}/episode/{episodio}?api_key={apiKey}&language=pt-BR";

                        var episodeResponse = await httpClient.GetAsync(episodeUrl);
                        if (episodeResponse.IsSuccessStatusCode)
                        {
                            var episodeContent = await episodeResponse.Content.ReadAsStringAsync();
                            var episodeDetails = System.Text.Json.JsonSerializer.Deserialize<TmdbEpisode>(episodeContent);





                            // Criando o embed com detalhes do episódio
                            if (episodeDetails != null)
                            {
                                var embed = new DiscordEmbedBuilder
                                {
                                    Title = $"{serie.Name} - Temporada {temporada}, Episódio {episodio}",
                                    Description = $"**Episódio:** *{episodeDetails.name}* \n\n" +
                                    $"{episodeDetails.overview}",
                                    Color = DiscordColor.Red,
                                    Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                                    {
                                        Url = $"https://image.tmdb.org/t/p/original{episodeDetails.still_path}"
                                    },
                                    Footer = new DiscordEmbedBuilder.EmbedFooter
                                    {
                                        Text = "StreamVerse"
                                    }
                                };

                                //Ano
                                embed.AddField("Data de Lançamento", DateTime.ParseExact(episodeDetails.air_date, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"), inline: true);

                                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embed));
                            }
                            else
                            {
                                await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Detalhes do episódio não encontrados."));
                            }
                        }
                        else
                        {
                            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Falha ao obter detalhes do episódio."));
                        }
                    }
                    else
                    {
                        string seasonUrl = $"https://api.themoviedb.org/3/tv/{serie.Id}/season/{temporada}?api_key={apiKey}&language=pt-BR";

                        var seasonResponse = await httpClient.GetAsync(seasonUrl);
                        if (seasonResponse.IsSuccessStatusCode)
                        {



                            var seasonContent = await seasonResponse.Content.ReadAsStringAsync();
                            var seasonDetails = System.Text.Json.JsonSerializer.Deserialize<TmdbTVSeasonDetail>(seasonContent);

                            
                            if (seasonDetails.Episodes != null && seasonDetails.Episodes.Length > 0)
                            {

                                var embed = new DiscordEmbedBuilder
                                {
                                    Title = $"{serie.Name} - {seasonDetails.Name}",
                                    Description = string.Join("\n", seasonDetails.Episodes.Select(p => $"**{p.EpisodeNumber}** - {p.Name} - *{p.Runtime} min* ")),
                                    Color = DiscordColor.Red,
                                    Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                                    {
                                        Url = $"https://image.tmdb.org/t/p/original{seasonDetails.PosterPath}"
                                    },
                                    Footer = new DiscordEmbedBuilder.EmbedFooter
                                    {
                                        Text = "StreamVerse"
                                    }
                                };

                                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embed));


                            }
                            else
                            {
                                await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Série ou temporada não encontrada."));
                            }

                        }

                    }
                    
                }
                else
                {
                    await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Série não encontrada."));
                }
            }
            else
            {
                await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Falha ao buscar a série."));
            }
            
        }

    }
}

