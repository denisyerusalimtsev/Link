import { Expert } from './expert';
import { EventDto } from '../interfaces/event-dto';

export class Event {
    constructor(
        public id: string,
        public userId: string,
        public name: string,
        public expertType: string,
        public status: string,
        public latitude: number,
        public longitude: number,
        public startTime: Date,
        public endTime: Date,
        public countOfNeededExperts: number,
        public experts: Expert[]
    ) { }

    public static Create(dto: EventDto): Event {
        // tslint:disable-next-line: prefer-const
        let parsedExperts: Expert[];

        if (dto.experts != null && dto.experts.length !== 0) {
            dto.experts.forEach(expert => {
                parsedExperts.push(Expert.Create(expert));
            });
        }

        return new Event(
            dto.id,
            dto.userId,
            dto.name,
            dto.expertType,
            dto.status,
            dto.latitude,
            dto.longitude,
            dto.startTime,
            dto.endTime,
            dto.countOfNeededExperts,
            parsedExperts);
    }
}
