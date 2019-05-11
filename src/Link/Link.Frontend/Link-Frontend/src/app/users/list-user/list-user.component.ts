import { Component, OnInit, ChangeDetectorRef, ViewChild } from '@angular/core';
import { MatDialog, MatTableDataSource, MatSort, MatPaginator, MatDialogConfig } from '@angular/material';
import { UserService } from '../../services/user.service';
import { UserDto } from 'src/app/interfaces/user-dto';
import { User } from '../../models/user';
import { DialogUserComponent } from '../dialog-user/dialog-user.component';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.scss']
})
export class ListUserComponent implements OnInit {

  constructor(
    private userService: UserService,
    private changeDetectorRefs: ChangeDetectorRef,
    private dialog: MatDialog) {
    this.dataSource = new MatTableDataSource();
  }

  users: UserDto[];
  dataSource: MatTableDataSource<User>;
  displayedColumns: string[] =
    ['id', 'firstName', 'lastName',
      'phoneNumber', 'email',
      'actions'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  searchKey: string;

  ngOnInit() {
    this.refresh();
  }

  onSearchClear() {
    this.searchKey = '';
    this.applyFilter();
  }

  onCreate() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = false;
    dialogConfig.autoFocus = true;
    dialogConfig.height = '70%';
    dialogConfig.width = '80%';
    this.dialog.open(DialogUserComponent, dialogConfig)
    .afterClosed().subscribe(result => {
      this.refresh();
  });
  }

  applyFilter() {
    this.dataSource.filter = this.searchKey.trim().toLowerCase();
  }

  refresh() {
    this.userService.getUsers()
      .subscribe((data: UserDto[]) => {
        this.users = data.map(dto => User.Create(dto));

        console.log(this.users);
        this.dataSource.data = this.users;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      });
    this.changeDetectorRefs.detectChanges();
  }
}
