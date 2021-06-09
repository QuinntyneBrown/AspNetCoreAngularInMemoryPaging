import { Component, Input, OnInit } from '@angular/core';
import { Player } from '@api';

@Component({
  selector: 'app-player-card',
  templateUrl: './player-card.component.html',
  styleUrls: ['./player-card.component.scss']
})
export class PlayerCardComponent {
  @Input() public player: Player;
}
