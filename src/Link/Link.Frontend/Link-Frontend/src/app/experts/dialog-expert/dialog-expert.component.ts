import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { ExpertDto } from 'src/app/interfaces/expert-dto';
import { ExpertService } from 'src/app/services/expert.service';
import { NotificationService } from 'src/app/services/notification.service';
import { Expert } from '../../models/expert';

@Component({
  selector: 'app-dialog-expert',
  templateUrl: './dialog-expert.component.html',
  styleUrls: ['./dialog-expert.component.scss']
})
export class DialogExpertComponent implements OnInit {

  expertForm!: FormGroup;
  events: ExpertDto[];
  constructor(private expertService: ExpertService,
              public notificationService: NotificationService,
              public dialogRef: MatDialogRef<DialogExpertComponent>) { }

  ngOnInit() {
    this.expertForm = new FormGroup({
      id: new FormControl(null),
      firstName: new FormControl('', {
        validators: [Validators.required]
      }),
      lastName: new FormControl('', {
        validators: [Validators.required]
      }),
      expertType: new FormControl('', {
        validators: [Validators.required]
      }),
      expertStatus: new FormControl('', {
        validators: [Validators.required]
      }),
    });

    this.expertService.getExperts()
      .subscribe(data => {
        this.events = data;
        console.log(this.events);
      });
  }

  onClear() {
    this.expertForm.reset();
  }

  onSubmit() {
    if (this.expertForm.valid) {
      const expert = new Expert(
        this.expertForm.value.id,
        this.expertForm.value.firstName,
        this.expertForm.value.lastName,
        this.expertForm.value.expertType,
        this.expertForm.value.expertStatus);
      this.expertService.createExpert(expert);
      console.log(expert);
      this.onClose();
      this.notificationService.success(':: Submitted successfully');
    }
  }

  onClose() {
    this.expertForm.reset();
    this.dialogRef.close();
  }

}
