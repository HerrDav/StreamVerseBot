# 1. Discord Movie and Series Bot

Este projeto consiste em um bot para Discord que permite aos usuários consultar informações sobre filmes e séries através da API do site themoviedb.org. O bot é implementado usando a biblioteca DSharpPlus e utiliza comandos SlashCommand para a interação.

## Funcionalidades

- **Consulta de Filmes**: Permite aos usuários buscar informações sobre filmes usando comandos específicos.
- **Consulta de Séries**: Os usuários podem obter informações sobre séries de TV, incluindo detalhes sobre temporadas e episódios específicos. Além disso, é possível consultar os episódios de uma temporada específica.

## Tecnologias Utilizadas

- [DSharpPlus](https://dsharpplus.github.io/DSharpPlus/) - Biblioteca para criar bots para Discord que suporta diversas funcionalidades incluindo comandos de barra (Slash Commands).

## Requisitos

Certifique-se de ter as seguintes bibliotecas instaladas, todas na versão 4.4.6:
- DSharpPlus
- DSharpPlus.CommandsNext
- DSharpPlus.Interactivity
- DSharpPlus.SlashCommands

## Configuração Inicial

### 1. Configuração do ID do Servidor

No arquivo `Program.cs`, altere o valor da variável `IdServidor` para corresponder ao ID do seu servidor de teste no Discord:

```csharp
ulong IdServidor = 0000000000000000000; // Substitua com o ID do seu servidor
```
# 2. Configuração da API Key
É necessário configurar a chave da API do The Movie DB para fazer as consultas. Faça o seguinte:
- Acesse [The Movie DB API](https://developer.themoviedb.org/docs/getting-started) e obtenha sua chave API.
- Em `SlashCommands/FilmeCommands.cs` e `SlashCommands/SerieCommands.cs`, substitua a variável `string apiKey` com a chave obtida.


# 3. Como Usar no Discord
Após configurar o bot e adicionar ao seu servidor, você pode usar os seguintes comandos Slash:

**/filme nome_do_filme**: Busca informações sobre o filme especificado.
**/serie nome_da_serie temporada número_do_episódio**: Busca informações detalhadas sobre um episódio específico.
**/serie nome_da_serie temporada**: Lista todos os episódios de uma temporada específica.


Entendi! Vou ajustar a seção "Contribuições e Continuação do Projeto" para refletir que o projeto está atualmente parado e pode ser retomado por quem estiver interessado. Aqui está a versão atualizada:


# 4. Contribuições e Continuação do Projeto

Este projeto foi desenvolvido como uma ferramenta de aprendizado para criar bots no Discord e está atualmente parado. No entanto, está aberto a contribuições e pode ser continuado por qualquer pessoa interessada. Para continuar o desenvolvimento a partir de onde foi parado, você pode clonar o repositório, instalar as dependências necessárias e começar a adicionar novas funcionalidades ou melhorar as existentes. Instruções detalhadas para clonar e configurar o projeto podem ser encontradas abaixo:
