import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NotificationService } from 'src/app/services/notification.service';
import { MatDialogRef } from '@angular/material';
import { EventDto } from 'src/app/interfaces/event-dto';
import { EventService } from 'src/app/services/event.service';
import { Event } from '../../models/event';

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
      userId: new FormControl('', {
        validators: [Validators.required]
      }),
      name: new FormControl('', {
        validators: [Validators.required]
      }),
      expertType: new FormControl('', {
        validators: [Validators.required]
      }),
      status: new FormControl('', {
        validators: [Validators.required]
      }),
      latitude: new FormControl('', {
        validators: [Validators.required]
      }),
      longitude: new FormControl('', {
        validators: [Validators.required]
      }),
      startTime: new FormControl('', {
        validators: [Validators.required]
      }),
      endTime: new FormControl('', {
        validators: [Validators.required]
      }),
      countOfNeededExperts: new FormControl('', {
        validators: [Validators.required]
      })
    });

    this.eventService.getEvents()
      .subscribe(data => {
        this.events = data.events;
        console.log(this.events);
      });
  }

  onClear() {
    this.eventForm.reset();
  }

  onSubmit() {
    if (this.eventForm.valid) {
      const event = new Event(
        this.eventForm.value.id,
        this.eventForm.value.userId,
        this.eventForm.value.name,
        this.eventForm.value.expertType,
        this.eventForm.value.status,
        this.eventForm.value.latitude,
        this.eventForm.value.longitude,
        this.eventForm.value.startTime,
        this.eventForm.value.endTime,
        this.eventForm.value.countOfNeededExpert,
        null);
      this.eventService.createEvent(event);
      console.log(event);
      this.onClose();
      this.notificationService.success(':: Submitted successfully');
    }
  }

  onClose() {
    this.eventForm.reset();
    this.dialogRef.close();
  }
}
