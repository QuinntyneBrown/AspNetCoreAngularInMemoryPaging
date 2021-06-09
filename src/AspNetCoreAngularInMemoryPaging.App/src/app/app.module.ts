import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { baseUrl } from '@core/constants';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TeamsModule } from './teams/teams.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';
import { TeamCardModule } from '@shared/cards/team-card/team-card.module';
import { PlayerCardModule } from '@shared/cards/player-card/player-card.module';
import { MaterialModule } from '@shared/material/material.module';



@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TeamsModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    HttpClientModule,
    TeamCardModule,
    PlayerCardModule,
    MaterialModule
  ],
  providers: [
    { provide: baseUrl, useValue: 'https://localhost:5001/' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
