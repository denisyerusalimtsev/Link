import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListEventComponent } from './events/list-copter/list-copter.component';

const routes: Routes = [ 
  { path: 'events', component: ListEventComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
