import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListEventComponent } from './events/list-event/list-event.component';

const routes: Routes = [ 
  { path: 'events', component: ListEventComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
