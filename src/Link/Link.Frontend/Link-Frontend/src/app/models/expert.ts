import { ExpertDto } from '../interfaces/expert-dto';
import { ExpertType } from './expert-type';
import { ExpertStatus } from './expert-status';
export class Expert {
    constructor(
        public id: string,
        public firstName: string,
        public lastName: string,
        public expertType: string,
        public expertStatus: string
    ) { }

    public static Create(dto: ExpertDto): Expert {
        return new Expert(
            dto.id,
            dto.firstName,
            dto.lastName,
            dto.type,
            dto.status);
    }
}
