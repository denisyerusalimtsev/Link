import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NotificationService } from 'src/app/services/notification.service';
import { MatDialogRef } from '@angular/material';
import { EventDto } from 'src/app/interfaces/event-dto';
import { EventService } from 'src/app/services/event.service';

@Component({
  selector: 'app-dialog-event',
  templateUrl: './dialog-event.component.html',
  styleUrls: ['./dialog-event.component.scss']
})
export class DialogEventComponent implements OnInit {

  eventForm!: FormGroup;
  events: EventDto[];
  constructor(private eventService: EventService,
              public notificationService: NotificationService,
              public dialogRef: MatDialogRef<DialogEventComponent>) { }

  ngOnInit() {
    this.eventForm = new FormGroup({
      id: new FormControl(null),
      name: new FormControl('', {
        validators: [Validators.required]
      }),
      firstName: new FormControl('', {
        validators: [Validators.required]
      }),
      lastName: new FormControl('', {
        validators: [Validators.required]
      }),
      phoneNumber: new FormControl('', {
        validators: [Validators.required]
      }),
      email: new FormControl('', {
        validators: [Validators.required]
      })
    });

    this.eventService.getEvents()
      .subscribe(data => {
        this.events = data;
        console.log(this.events);
      });
  }

  onClear() {
    this.eventForm.reset();
  }

  onSubmit() {
    if (this.eventForm.valid) {
      const copter = new Event(
        this.eventForm.value.id,
        this.eventForm.value.firstName,
        this.eventForm.value.lastName,
        this.eventForm.value.phoneNumber,
        this.eventForm.value.email);
      this.userService.createUser(copter);
      console.log(copter);
      this.onClose();
      this.notificationService.success(':: Submitted successfully');
    }
  }

  onClose() {
    this.eventForm.reset();
    this.dialogRef.close();
  }
}
