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


@NgModule({
  declarations: [
    AppComponent,
    ListEventComponent,
    ListExpertComponent,
    ListUserComponent,
    DialogUserComponent,
    DialogEventComponent,
    DialogExpertComponent
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
    DialogUserComponent
  ],
  providers: [
    UserService,
    EventService,
    ExpertService,
    NotificationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
