import { Component, OnInit } from '@angular/core';
import { CalendarOptions, DateSelectArg, EventClickArg, EventApi, Calendar } from '@fullcalendar/angular';
import { IPlan } from '../interfaces/iplan';
import { EventService } from '../services/event.service';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  plans: IPlan[];
  eventId = 0;
  calendar: Calendar;
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
    // events: [
    //   { title: 'Get stuff done', date: '2020-10-09' },
    //   { title: 'Tutor James', date: '2020-10-10' }
    // ],
    eventsSet: this.handleEvents.bind(this),
    select: this.handleDateSelect.bind(this),
    eventClick: this.handleEventClick.bind(this),
  };

  currentEvents: IPlan[] = [];
  constructor(private planService: EventService) {}

  ngOnInit(): void {

  }

  // handleDateClick(arg) {
  //   alert('date click! ' + arg.dateStr);
  // }

  handleEvents() {
    this.currentEvents = this.plans;
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
