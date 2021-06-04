import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Team, TeamService } from '@api';
import { Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.scss']
})
export class TeamsComponent {

  public readonly teams$: Observable<Team[]> = this._teamService.get()
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
    private readonly _teamService: TeamService
  ) { }

  public handlePageEvent($event: PageEvent) {
    this.pageIndex = $event.pageIndex;
    this.pageSize = $event.pageSize;
  }
}
