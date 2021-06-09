import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TeamService } from '@api';
import { Subject } from 'rxjs';
import { map, startWith, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent  {

  private readonly _refresh$ = new Subject();

  public team$ = this._activatedRoute.paramMap
  .pipe(
    map(paramMap => paramMap.get("id")),
    switchMap(teamId => this._refresh$.pipe(startWith(true),map(_ => teamId))),
    switchMap(teamId => this._teamService.getById({ teamId }))
  )
  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _teamService: TeamService

  ) { }

  ngOnInit(): void {
  }

}
