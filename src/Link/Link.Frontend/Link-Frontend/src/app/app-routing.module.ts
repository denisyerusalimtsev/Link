import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListEventComponent } from './events/list-event/list-event.component';
import { ListExpertComponent } from './experts/list-expert/list-expert.component';
import { ListUserComponent } from './users/list-user/list-user.component';
import { MapEventComponent } from './map/map-event/map-event.component';
import { StatisticComponent } from './statistic/statistic/statistic.component';

const routes: Routes = [
  { path: 'events', component: ListEventComponent },
  { path: 'experts', component: ListExpertComponent },
  { path: 'users', component: ListUserComponent },
  { path: 'map', component: MapEventComponent },
  { path: 'statistic', component: StatisticComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
