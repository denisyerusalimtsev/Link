import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListEventComponent } from './events/list-event/list-event.component';
import { ListExpertComponent } from './experts/list-expert/list-expert.component';
import { ListUserComponent } from './users/list-user/list-user.component';

const routes: Routes = [
  { path: 'events', component: ListEventComponent },
  { path: 'experts', component: ListExpertComponent },
  { path: 'users', component: ListUserComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
