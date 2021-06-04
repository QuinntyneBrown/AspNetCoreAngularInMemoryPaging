import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { baseUrl } from '@core/constants';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TeamsModule } from './teams/teams.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TeamsModule,
    BrowserAnimationsModule
  ],
  providers: [
    { provide: baseUrl, useValue: 'https://localhost:5001/' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
