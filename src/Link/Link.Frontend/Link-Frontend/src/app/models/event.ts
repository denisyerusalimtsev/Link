import { Expert } from './expert';
import { ExpertType } from './expert-type';
import { Status } from './status';
import { EventDto } from '../interfaces/event-dto';

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
        public countOfNeededExpert: number,
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
            ExpertType[dto.expertType],
            Status[dto.status],
            dto.latitude,
            dto.longitude,
            dto.startTime,
            dto.endTime,
            dto.countOfNeededExpert,
            parsedExperts);
    }
}
