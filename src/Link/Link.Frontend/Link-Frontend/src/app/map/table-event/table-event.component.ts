import { Component, OnInit, ViewChild } from '@angular/core';
import { StateService } from 'src/app/services/state.service';
import { MatTableDataSource, MatPaginator, MatSort, MatDialogConfig, MatDialog } from '@angular/material';
import { EventService } from '../../services/event.service';
import { Event } from '../../models/event';
import { GetEventsDto } from '../../dto/get-event.dto';
import { DialogAssignExpertsComponent } from '../dialog-assign-experts/dialog-assign-experts.component';

@Component({
  selector: 'app-table-event',
  templateUrl: './table-event.component.html',
  styleUrls: ['./table-event.component.scss']
})
export class TableEventComponent implements OnInit {
  events: Event[];
  googleMap = 'https://www.google.com/maps/dir/?api=1&destination=';
  dataSource: MatTableDataSource<Event>;
  displayedColumns: string[] =
    ['id', 'name', 'type',
      'status', 'startTime',
      'countOfNeededExpert',
      'actions'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private stateService: StateService,
    private eventService: EventService,
    private dialog: MatDialog
    ) {
    this.dataSource = new MatTableDataSource();
  }

  ngOnInit() {
    this.refresh();
  }

  markOnMap(event: Event) {
    this.stateService.currentPlaceGeometry.next(event);
  }

  assignExperts(event: Event) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = false;
    dialogConfig.autoFocus = true;
    dialogConfig.height = '50%';
    dialogConfig.width = '70%';
    dialogConfig.data = event;

    this.dialog.open(DialogAssignExpertsComponent, dialogConfig)
    .afterClosed().subscribe(result => {
      this.refresh();
    });
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
  }
}
