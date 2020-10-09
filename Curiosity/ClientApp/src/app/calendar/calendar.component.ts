import { Component, OnInit } from '@angular/core';
import { CalendarOptions, DateSelectArg, EventClickArg, EventApi } from '@fullcalendar/angular';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  eventId = 0;
  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    headerToolbar: {
      left: 'prev,next today',
      center: 'title',
      right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
    },
    editable: true,
    selectable: true,
    selectMirror: true,
    // dateClick: this.handleDateClick.bind(this), // bind is important!
    events: [
      { title: 'Get stuff done', date: '2020-10-09' },
      { title: 'Tutor James', date: '2020-10-10' }
    ],
    eventsSet: this.handleEvents.bind(this),
    select: this.handleDateSelect.bind(this),
    eventClick: this.handleEventClick.bind(this),
  };

  currentEvents: EventApi[] = [];
  constructor() { }

  ngOnInit(): void {
  }

  // handleDateClick(arg) {
  //   alert('date click! ' + arg.dateStr);
  // }

  handleEvents(events: EventApi[]) {
    this.currentEvents = events;
  }

  handleDateSelect(selectInfo: DateSelectArg) {
    const title = prompt('Please enter a new title for your event');
    const calendarApi = selectInfo.view.calendar;

    calendarApi.unselect(); // clear date selection

    if (title) {
      calendarApi.addEvent({
        id: this.createEventID(),
        title,
        start: selectInfo.startStr,
        end: selectInfo.endStr,
        allDay: selectInfo.allDay
      });
    }
  }

  createEventID() {
    return String(this.eventId++);
  }

  handleEventClick(clickInfo: EventClickArg) {
    if (confirm(`Are you sure you want to delete the event '${clickInfo.event.title}'`)) {
      clickInfo.event.remove();
    }
  }

}
