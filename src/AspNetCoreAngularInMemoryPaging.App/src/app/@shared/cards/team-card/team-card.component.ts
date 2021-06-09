import { Component, Input, OnInit } from '@angular/core';
import { Team } from '@api';

@Component({
  selector: 'app-team-card',
  templateUrl: './team-card.component.html',
  styleUrls: ['./team-card.component.scss']
})
export class TeamCardComponent {
  @Input() public team: Team;
}
