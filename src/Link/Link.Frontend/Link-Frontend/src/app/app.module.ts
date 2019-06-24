import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MaterialModule } from './material/material.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

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

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

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
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
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
