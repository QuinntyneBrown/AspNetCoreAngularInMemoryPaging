import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [{
  path: '',
  pathMatch:'full',
  loadChildren: () => import('./teams/teams.module').then(m => m.TeamsModule)
},
{
  path: 'detail/:id',
  loadChildren: () => import('./detail/detail.module').then(m => m.DetailModule)
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
