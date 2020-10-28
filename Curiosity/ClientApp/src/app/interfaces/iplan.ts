import { DateRange } from '@fullcalendar/angular';

export interface IPlan {
    id?: number;
    title: string;
    start: Date;
    startTime: Date;
    end: Date;
    endTime: Date;
    allDay: boolean;
    memberId?: number;
}
