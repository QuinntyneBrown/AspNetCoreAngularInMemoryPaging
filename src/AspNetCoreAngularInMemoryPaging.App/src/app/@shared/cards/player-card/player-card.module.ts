import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlayerCardComponent } from './player-card.component';
import { MaterialModule } from '@shared/material/material.module';



@NgModule({
  declarations: [
    PlayerCardComponent
  ],
  exports: [
    PlayerCardComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ]
})
export class PlayerCardModule { }
