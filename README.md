<p align="center">
  <img src="Resources/logo_library.png">
</p>

<p align="center">Interface library for the Riot Games Rest API</p>

##
[![Generic badge](https://img.shields.io/badge/version-1.1-green.svg)](https://github.com/GoldenGuillaume/RiotGames)
[![Generic badge](https://img.shields.io/badge/runtime-.NET_Standard_2.1-blue.svg)](https://docs.microsoft.com/fr-fr/dotnet/standard/net-standard)
[![Generic badge](https://img.shields.io/badge/dependencies-up_to_date-green.svg)](https://github.com/GoldenGuillaume/RiotGames)
[![GitHub license](https://img.shields.io/github/license/GoldenGuillaume/RiotGames)](https://github.com/GoldenGuillaume/RiotGames)



## Install

Currently not on Nuget, clone the repository and add reference. To make it work you need to set a new environment variable called `RIOTGAMES_API_TOKEN` with your API key to be able to launch Http requests or to provide an HttpClient already
setted to the constructor which take an HttpClient as parameter.

## Compatibility

The project is built with .NET Standard version 2.1, it support compatibility with .NET Core, Mono and Xamarin, refer to [this link](https://docs.microsoft.com/fr-fr/dotnet/standard/net-standard)
to get version compatibilities.

## Usage


###### 1. Standard usage:

To Set the location building the service the api key is provided by the environment variable:
```CSharp
RiotGames.Api.Http.LeagueService service = new LeagueService(LocationEnum.EUW1);
service.GetChallengerLeagueByQueue(QueueEnum.RANKED_SOLO_5X5);
```

The service is built with api key provided either the location need to be configurer
here by the ConfigureLocation function who take LocationEnum as parameter:
```CSharp
RiotGames.Api.Http.LeagueService service = new LeagueService();
service.ConfigureLocation(LocationEnum.EUW1);
service.GetChallengerLeagueByQueue(QueueEnum.RANKED_SOLO_5X5);
```

The service is built with an HttpClient configured before, if the Environment variable
isn't passed in the client sent as parameter then the environment variable is taken, if the
baseAdress isn't correct either it is set to null and a call to ConfigureLocation is needed:
```CSharp
HttpClient client = new HttpClient();
client.BaseAdress = "https://euw1.api.riotgames.com/"
client.DefaultRequestHeaders.Add("X-Riot-Token", "YourApiKey");

RiotGames.Api.Http.LeagueService service = new LeagueService(client);
service.GetChallengerLeagueByQueue(QueueEnum.RANKED_SOLO_5X5);
```

Pass an unseted HttpClient instance and let the constructor configure it (notice that in that case the base address with location is not setted 
you will have to call ConfigureLocation):
```CSharp
HttpClient client = new HttpClient();
RiotGames.Api.Http.LeagueService service = new LeagueService(client);
service.ConfigureLocation(LocationEnum.EUW1);
service.GetChallengerLeagueByQueue(QueueEnum.RANKED_SOLO_5X5);
```

###### 2. Dependency injection inside an ASP .Net Core project:

Inject the service in the ConfigureService method of the startup.cs class:
```CSharp
public void ConfigureServices(IServiceCollection services)
{
    /* Add Api implementation services */
    services.AddHttpClient<SummonerService>();
    services.AddHttpClient<LeagueService>();
    services.AddHttpClient<MatchService>();
}
```

Call ConfigureLocation before calling service method:
```CSharp
service.ConfigureLocation(LocationEnum.EUW1);
service.GetChallengerLeagueByQueue(QueueEnum.RANKED_SOLO_5X5);
```

## License

For the moment, not under any licence.
