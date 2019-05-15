import { Component, OnInit, ChangeDetectorRef, ViewChild } from '@angular/core';
import { MatDialog, MatTableDataSource, MatSort, MatPaginator } from '@angular/material';

@Component({
  selector: 'app-list-expert',
  templateUrl: './list-expert.component.html',
  styleUrls: ['./list-expert.component.scss']
})
export class ListExpertComponent implements OnInit {

  constructor(private changeDetectorRefs: ChangeDetectorRef,
              private dialog: MatDialog) {
    this.dataSource = new MatTableDataSource();
  }

  dataSource: MatTableDataSource<any>;
  displayedColumns: string[] =
    ['id', 'firstName', 'lastName',
      'expertType', 'expertStatus',
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
