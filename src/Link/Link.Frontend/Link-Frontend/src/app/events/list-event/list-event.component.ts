import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MatTableDataSource, MatDialog, MatPaginator, MatSort, MatDialogConfig } from '@angular/material';
import { DialogEventComponent } from '../dialog-event/dialog-event.component';
import { EventService } from '../../services/event.service';
import { NotificationService } from '../../services/notification.service';
import { Event } from '../../models/event';
import { GetEventsDto } from '../../dto/get-event.dto';

@Component({
  selector: 'app-list-event',
  templateUrl: './list-event.component.html',
  styleUrls: ['./list-event.component.css']
})
export class ListEventComponent implements OnInit {

  constructor(
    private eventService: EventService,
    private notificationService: NotificationService,
    private changeDetectorRefs: ChangeDetectorRef,
    private dialog: MatDialog) {
    this.dataSource = new MatTableDataSource();
  }

  events: Event[];
  dataSource: MatTableDataSource<Event>;
  displayedColumns: string[] =
    ['id', 'name', 'type',
      'status', 'latitude', 'longitude',
      'startTime', 'endTime', 'countOfNeededExpert',
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

  onCreate() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = false;
    dialogConfig.autoFocus = true;
    dialogConfig.height = '80%';
    dialogConfig.width = '50%';
    this.dialog.open(DialogEventComponent, dialogConfig)
      .afterClosed().subscribe(result => {
        this.refresh();
      });
  }

  onEdit(row) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = false;
    dialogConfig.autoFocus = true;
    dialogConfig.height = '80%';
    dialogConfig.width = '50%';
    this.dialog.open(DialogEventComponent, dialogConfig)
      .afterClosed().subscribe(result => {
        this.refresh();
      });
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record ?')) {
      this.eventService.deleteEvent(id);
      this.notificationService.warn('! Deleted successfully');
      this.refresh();
    }
  }

  refresh() {
    this.eventService.getEvents()
      .subscribe((data: GetEventsDto) => {
        this.events = data.events.map(dto => Event.Create(dto));

        console.log(this.events);
        this.dataSource.data = this.events;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      });
    this.changeDetectorRefs.detectChanges();
  }
}
