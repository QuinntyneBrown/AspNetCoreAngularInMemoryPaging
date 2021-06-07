import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { Team, TeamService } from '@api';
import { TeamPopupComponent } from '@shared/material/popups/team-popup/team-popup.component';
import { Observable, Subject } from 'rxjs';
import { map, startWith, switchMap, takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.scss']
})
export class TeamsComponent {

  private readonly _destroyed$: Subject<void> = new Subject();

  private readonly _refresh$: Subject<void> = new Subject();

  @ViewChild(MatPaginator, { static: false }) private readonly _paginator: MatPaginator | undefined;

  public readonly vm$: Observable<{
    teams: Team[]
  }> = this._refresh$.pipe(tap(x => {
    this._paginator.pageIndex = 0;
    this.pageIndex = 0;
  })).pipe(
    startWith(true),
    switchMap(x => this._teamService.get()),
    map(teams => ({ teams}))
  )


  public pageSize = 5;
  public pageIndex = 0;
  public get start() {
    return this.pageIndex * this.pageSize
  }
  public get end() {
    return this.start + this.pageSize
  }
  public readonly pageSizeOptions: number[] = [5, 10, 25, 100];

  constructor(
    private readonly _teamService: TeamService,
    private readonly _dialog: MatDialog
  ) { }

  edit(team: Team) {
    this._dialog.open<TeamPopupComponent>(TeamPopupComponent)
    .afterClosed()
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this._refresh$.next())
    )
    .subscribe();
  }
}
