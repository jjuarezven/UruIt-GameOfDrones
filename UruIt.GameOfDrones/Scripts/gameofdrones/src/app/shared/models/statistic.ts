export class Statistic {
  PlayerName: string;
  WonGames: number;

  constructor(name: string, won: number) {
    this.PlayerName = name;
    this.WonGames = won
  }
}
