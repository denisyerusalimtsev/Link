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


@NgModule({
  declarations: [
    AppComponent,
    ListEventComponent,
    ListExpertComponent,
    ListUserComponent,
    DialogUserComponent
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
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
