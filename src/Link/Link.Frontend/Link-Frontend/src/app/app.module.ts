import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MaterialModule } from './material/material.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListEventComponent } from './events/list-event/list-event.component';
import { ListExpertComponent } from './experts/list-expert/list-expert.component';
import { ListUserComponent } from './users/list-user/list-user.component';
import { DialogUserComponent } from './users/dialog-user/dialog-user.component';
import { UserService } from './services/user.service';
import { DialogEventComponent } from './events/dialog-event/dialog-event.component';
import { ExpertService } from './services/expert.service';
import { NotificationService } from './services/notification.service';
import { DialogExpertComponent } from './experts/dialog-expert/dialog-expert.component';
import { EventService } from './services/event.service';
import { GoogleMapComponent } from './map/google-map/google-map.component';
import { TableEventComponent } from './map/table-event/table-event.component';
import { MapEventComponent } from './map/map-event/map-event.component';
import { StateService } from './services/state.service';
import { DialogAssignExpertsComponent } from './map/dialog-assign-experts/dialog-assign-experts.component';


@NgModule({
  declarations: [
    AppComponent,
    ListEventComponent,
    ListExpertComponent,
    ListUserComponent,
    DialogUserComponent,
    DialogEventComponent,
    DialogExpertComponent,
    MapEventComponent,
    GoogleMapComponent,
    TableEventComponent,
    DialogAssignExpertsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  entryComponents: [
    DialogUserComponent,
    DialogExpertComponent,
    DialogEventComponent,
    DialogAssignExpertsComponent
  ],
  providers: [
    UserService,
    EventService,
    ExpertService,
    NotificationService,
    StateService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
