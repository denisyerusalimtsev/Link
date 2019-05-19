import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';
import { NotificationService } from 'src/app/services/notification.service';
import { MatDialogRef } from '@angular/material';
import { User } from 'src/app/models/user';
import { UserDto } from 'src/app/interfaces/user-dto';

@Component({
  selector: 'app-dialog-user',
  templateUrl: './dialog-user.component.html',
  styleUrls: ['./dialog-user.component.scss']
})
export class DialogUserComponent implements OnInit {

  userForm!: FormGroup;
  users: UserDto[];
  constructor(private userService: UserService,
              public notificationService: NotificationService,
              public dialogRef: MatDialogRef<DialogUserComponent>) { }

  ngOnInit() {
    this.userForm = new FormGroup({
      id: new FormControl(null),
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

    this.userService.getUsers()
      .subscribe(data => {
        this.users = data.users;
        console.log(this.users);
      });
  }

  onClear() {
    this.userForm.reset();
  }

  onSubmit() {
    if (this.userForm.valid) {
      const copter = new User(
        this.userForm.value.id,
        this.userForm.value.firstName,
        this.userForm.value.lastName,
        this.userForm.value.phoneNumber,
        this.userForm.value.email);
      this.userService.createUser(copter);
      console.log(copter);
      this.onClose();
      this.notificationService.success(':: Submitted successfully');
    }
  }

  onClose() {
    this.userForm.reset();
    this.dialogRef.close();
  }
}
