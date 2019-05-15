import { Component, OnInit, ChangeDetectorRef, ViewChild } from '@angular/core';
import { MatDialog, MatTableDataSource, MatSort, MatPaginator, MatDialogConfig } from '@angular/material';
import { DialogExpertComponent } from '../dialog-expert/dialog-expert.component';
import { ExpertService } from '../../services/expert.service';
import { ExpertDto } from '../../interfaces/expert-dto';
import { Expert } from 'src/app/models/expert';

@Component({
  selector: 'app-list-expert',
  templateUrl: './list-expert.component.html',
  styleUrls: ['./list-expert.component.scss']
})
export class ListExpertComponent implements OnInit {

  constructor(
    private expertService: ExpertService,
    private changeDetectorRefs: ChangeDetectorRef,
    private dialog: MatDialog) {
    this.dataSource = new MatTableDataSource();
  }

  experts: Expert[];
  dataSource: MatTableDataSource<Expert>;
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

  onCreate() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = false;
    dialogConfig.autoFocus = true;
    dialogConfig.height = '80%';
    dialogConfig.width = '50%';
    this.dialog.open(DialogExpertComponent, dialogConfig)
      .afterClosed().subscribe(result => {
        this.refresh();
      });
  }

  onSearchClear() {
    this.searchKey = '';
    this.applyFilter();
  }

  applyFilter() {
    this.dataSource.filter = this.searchKey.trim().toLowerCase();
  }

  refresh() {
    this.expertService.getExperts()
      .subscribe((data: ExpertDto[]) => {
        this.experts = data.map(dto => Expert.Create(dto));

        console.log(this.experts);
        this.dataSource.data = this.experts;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      });
    this.changeDetectorRefs.detectChanges();
  }
}
