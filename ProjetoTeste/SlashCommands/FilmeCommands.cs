using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProjetoTeste.Models.Movie;
using ProjetoTeste.Models.Search;

namespace ProjetoTeste.SlashCommands
{
    public class FilmeCommands : ApplicationCommandModule
    {

        [SlashCommand("filme", "Busca informações de um filme pelo nome")]
        public async Task Filme(InteractionContext ctx,
            [Option("nome", "Nome do filme a ser pesquisado")] string nomeFilme)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource, new DiscordInteractionResponseBuilder().AsEphemeral(true));

            var httpClient = new HttpClient();
            //Necessario capturar a API Key pela themoviedb.org
            string apiKey = "";
            string url = $"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&query={nomeFilme}&language=pt-BR";

            var resposta = await httpClient.GetFromJsonAsync<TmdbSeachMovie>(url);


            if (resposta != null && resposta.Results.Length > 0)
            {
                var filme = resposta.Results[0];
                var embed = new DiscordEmbedBuilder
                {
                    Title = filme.Title,
                    Description = $"**Sinopse:** {filme.Overview}",
                    Color = DiscordColor.Green,
                    Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                    {
                        Url = $"https://image.tmdb.org/t/p/original{filme.PosterPath}"
                    },
                    Footer = new DiscordEmbedBuilder.EmbedFooter
                    {
                        Text = "StreamVerse"
                    }

                };
                //Ano
                embed.AddField("Data de Lançamento", DateTime.ParseExact(filme.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"), inline: false);

                string providersUrl = $"https://api.themoviedb.org/3/movie/{filme.Id}/watch/providers?api_key={apiKey}";
                var providersResponse = await httpClient.GetFromJsonAsync<TmdbMovieWatchProviders>(providersUrl);

                if (providersResponse.Results.BR != null) { 
                    //Flatrate
                    if (providersResponse.Results.BR.Flatrate != null)
                    {
                        //var brProviders = providersResponse.Results["BR"].Flatrate;
                        var brProviders = providersResponse.Results.BR.Flatrate;
                        if (brProviders != null && brProviders.Length > 0)
                        {
                            string providersText = string.Join("\n", brProviders.Select(p => $"{p.ProviderName}"));
                            embed.AddField("Onde Assistir", providersText, inline: true);
                        }
                    }
                    //Buy
                    if (providersResponse.Results.BR.Buy != null)
                    {
                        var brProviders = providersResponse.Results.BR.Buy;
                        if (brProviders != null && brProviders.Length > 0)
                        {
                            string providersText = string.Join("\n", brProviders.Select(p => $"{p.ProviderName}"));
                            embed.AddField("Onde Comprar", providersText, inline: true);
                        }
                    }

                    //Alugar
                    if (providersResponse.Results.BR.Rent != null)
                    {
                        var brProviders = providersResponse.Results.BR.Rent;
                        if (brProviders != null && brProviders.Length > 0)
                        {
                            string providersText = string.Join("\n", brProviders.Select(p => $"{p.ProviderName}"));
                            embed.AddField("Onde Alugar", providersText, inline: true);
                        }
                    }

                    //Outros
                    if (providersResponse.Results.BR.Ads != null)
                    {
                        var brProviders = providersResponse.Results.BR.Rent;
                        if (brProviders != null && brProviders.Length > 0)
                        {
                            string providersText = string.Join("\n", brProviders.Select(p => $"{p.ProviderName}"));
                            
                        }
                    }

                }
                else
                {
                    embed.AddField("Outros", "Atualmente esse filme não está disponível no Brasil", inline: true);
                }



                await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(embed));

            }
            else
            {
                var embed = new DiscordEmbedBuilder
                {
                    Title = "Filme não encontrado",
                    Description = "Não conseguimos encontrar o filme que você solicitou em nossa base de dados. " +
                           "Se você gostaria que esse filme fosse incluído, por favor, realize uma solicitação de inclusão. " +
                           "Você pode fazer isso enviando uma mensagem para nós com o título e detalhes do filme, " +
                           "ou se preferir, utilize nosso formulário de contato no website.",
                    Color = DiscordColor.Orange,
                    Footer = new DiscordEmbedBuilder.EmbedFooter
                    {
                        Text = "StreamVerse"
                    }

                }.Build();

                await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Filme não encontrado."));

            }
        }

    }

}

