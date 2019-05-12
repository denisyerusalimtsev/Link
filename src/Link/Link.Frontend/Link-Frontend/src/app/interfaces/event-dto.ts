import { ExpertDto } from './expert-dto';

export interface EventDto {
    id: string;
    userId: string;
    name: string;
    expertType: string;
    status: string;
    latitude: number;
    longitude: number;
    startTime: Date;
    endTime: Date;
    countOfNeededExpert: number;
    experts: ExpertDto[];
}
