import { Component } from '@angular/core';
import { Player, PlayerService, Team, TeamService } from '@api';
import { forkJoin, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  public vm$: Observable<{
    teams: Team[],
    players: Player[]
  }> = forkJoin([
    this._teamService.get(),
    this._playerService.get()
  ]).pipe(
    map(([teams,players])=> ({ teams, players }))
  );

  constructor(
    private readonly _teamService: TeamService,
    private readonly _playerService: PlayerService
  ) { }


}
