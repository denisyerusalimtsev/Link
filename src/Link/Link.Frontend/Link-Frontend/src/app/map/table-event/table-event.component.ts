import { Component, OnInit, ViewChild } from '@angular/core';
import { StateService } from 'src/app/services/state.service';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { EventDto } from 'src/app/interfaces/event-dto';
import { EventService } from '../../services/event.service';
import { Event } from '../../models/event';
import { GetEventsDto } from '../../dto/get-event.dto';

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
    private eventService: EventService
    ) {
    this.dataSource = new MatTableDataSource();
  }

  ngOnInit() {
    this.refresh();
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
