import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeamsRoutingModule } from './teams-routing.module';
import { TeamsComponent } from './teams.component';
import { MaterialModule } from '@shared/material/material.module';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    TeamsComponent
  ],
  imports: [
    CommonModule,
    TeamsRoutingModule,
    MaterialModule,
    HttpClientModule
  ]
})
export class TeamsModule { }
