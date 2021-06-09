import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamCardComponent } from './team-card.component';
import { MaterialModule } from '@shared/material/material.module';



@NgModule({
  declarations: [
    TeamCardComponent
  ],
  exports: [
    TeamCardComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ]
})
export class TeamCardModule { }
