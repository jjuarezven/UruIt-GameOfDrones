import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Movement } from './shared/models/movement';
import { Statistic } from './shared/models/statistic';
import { Round } from './shared/models/Round';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string;
  scores: number[]; // store the scores. index 0 is player 1. index 1 is player 2.
  namePlayer1: string;
  namePlayer2: string;
  movementPlayer1: number;
  movementPlayer2: number;
  round: number;
  isResultShow: boolean;
  showPlayersRegistration: boolean;
  player1Played: boolean;
  movements: Array<Movement> = [{ Name: 'Rock', Value: 0 }, { Name: 'Paper', Value: 1 }, { Name: 'Scissor ', Value: 2 }];
  statistics: Array<Statistic>;
  rounds: Array<Round>;
  winner: string;
  // theResult -  0 winner
  //              1 lose
  //              2 tie
  theResult = 0
  constructor() {
    this.initializeGame();
  }

  initializeGame() {
    this.title = 'Game of Drones';
    this.scores = [0, 0];
    this.namePlayer1 = '';
    this.namePlayer2 = '';
    this.movementPlayer1 = null;
    this.movementPlayer2 = null;
    this.isResultShow = false;
    this.showPlayersRegistration = true;
    this.player1Played = false;
    this.round = 1;
    this.statistics = [];
    this.rounds = [];
    this.winner = '';
  }

  startGame() {
    this.showPlayersRegistration = false;
  }

  processMovement(player: Number) {
    this.player1Played = this.movementPlayer1 !== null;

    if (this.movementPlayer1 && this.movementPlayer2) {
      if (this.movementPlayer1 === this.movementPlayer2) {
        this.theResult = 2;
      }
      // let's say you picked rock ( 0 ) 
      // and the enemy picked paper ( 1 )
      // you lose because ( 0 - 1 + 3 ) % 3  is equal to 2.

      // when you picked rock ( 0 )
      // and the enemy picked scissor ( 2 )
      // you win because ( 0 - 2 + 3) % 3 is equal to 1.

      // when you picked scissor ( 2 )
      // and the enemy picked paper ( 1 )
      // you win because ( 2 - 1 + 3 ) % 3 is equal to 1. 4 % 3 is 1.
      // Hope you get the picture.
      else if ((this.movementPlayer1 - this.movementPlayer2 + 3) % 3 == 1) {
        // YOU WIN
        this.theResult = 0;
        this.scores[0] = this.scores[0] + 1;
        this.rounds.push({ PlayerName: this.namePlayer1, Round: this.round });
      }
      else {
        // YOU LOSE
        this.theResult = 1;
        this.scores[1] = this.scores[1] + 1;
        this.rounds.push({ PlayerName: this.namePlayer2, Round: this.round });
        //this.statistics[1].WonRound++;
      }
      this.movementPlayer1 = null;
      this.movementPlayer2 = null;
      this.player1Played = false;
      this.round++;
      //if (this.statistics[0].WonRound === 3 || this.statistics[1].WonRound === 3) {
      if (this.scores[0] === 3 || this.scores[1] === 3) {
        this.evaluateEmperor();
      }
    }
  }

  evaluateEmperor() {
    this.winner = this.scores[0] === 3 ? this.namePlayer1 : this.namePlayer2;
  }
}
