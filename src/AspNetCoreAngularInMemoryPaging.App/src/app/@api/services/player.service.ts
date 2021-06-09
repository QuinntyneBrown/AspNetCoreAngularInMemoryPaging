import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Player } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class PlayerService  {

  uniqueIdentifierName: string = "playerId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public get(): Observable<Player[]> {
    return this._client.get<{ players: Player[] }>(`${this._baseUrl}api/player`)
      .pipe(
        map(x => x.players)
      );
  }

  public getById(options: { playerId: string }): Observable<Player> {
    return this._client.get<{ player: Player }>(`${this._baseUrl}api/player/${options.playerId}`)
      .pipe(
        map(x => x.player)
      );
  }

  public remove(options: { player: Player }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/player/${options.player.playerId}`);
  }

  public create(options: { player: Player }): Observable<{ player: Player }> {
    return this._client.post<{ player: Player }>(`${this._baseUrl}api/player`, { player: options.player });
  }

  public update(options: { player: Player }): Observable<{ player: Player }> {
    return this._client.put<{ player: Player }>(`${this._baseUrl}api/player`, { player: options.player });
  }
}
