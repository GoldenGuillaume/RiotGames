# Project Name

Interface library for the Riot Games Rest API

## Installation

TODO: Describe the installation process

## Usage

##### Standard usage

```CSharp
IRiotGamesApiService service = new LeagueService();
service.GetChallengerLeagueByQueue(QueueEnum.RANKED_SOLO_5X5);
```

##### Dependency injection inside an ASP .Net Core project

```CSharp
IRiotGamesApiService service = new LeagueService();
service.GetChallengerLeagueByQueue(QueueEnum.RANKED_SOLO_5X5);
```

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## History

TODO: Write history

## Credits

TODO: Write credits

## License

TODO: Write license
