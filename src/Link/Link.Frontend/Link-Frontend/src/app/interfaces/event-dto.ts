import { ExpertDto } from './expert-dto';

export interface EventDto {
    id: string;
    userId: string;
    name: string;
    expertType: string;
    status: string;
    latitude: string;
    longitude: string;
    startTime: Date;
    endTime: Date;
    countOfNeededExpert: number;
    experts: ExpertDto[];
}
