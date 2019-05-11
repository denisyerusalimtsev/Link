import { Component, OnInit, ChangeDetectorRef, ViewChild } from '@angular/core';
import { MatDialog, MatTableDataSource, MatSort, MatPaginator } from '@angular/material';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.scss']
})
export class ListUserComponent implements OnInit {

  constructor(private changeDetectorRefs: ChangeDetectorRef,
    private dialog: MatDialog) {
    this.dataSource = new MatTableDataSource();
  }

  dataSource: MatTableDataSource<any>;
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

  applyFilter() {
    this.dataSource.filter = this.searchKey.trim().toLowerCase();
  }

  refresh() {
    /*this.service.getCopters()
      .subscribe((data: CopterDto[]) => {
          this.copters = data.map(dto => Copter.Create(dto));

        console.log(this.copters);
        this.dataSource.data = this.copters;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      });*/
    this.changeDetectorRefs.detectChanges();
  }
}
