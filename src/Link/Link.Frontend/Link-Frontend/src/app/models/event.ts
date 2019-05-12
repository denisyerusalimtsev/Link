import { Expert } from './expert';
import { ExpertType } from './expert-type';
import { Status } from './status';

export class Event {
    constructor(
        public id: string,
        public userId: string,
        public name: string,
        public expertType: ExpertType,
        public status: Status,
        public latitude: number,
        public longitude: number,
        public startTime: Date,
        public endTime: Date,
        public ountOfNeededExpert: number,
        public experts: Expert[]
    ) { }
}
