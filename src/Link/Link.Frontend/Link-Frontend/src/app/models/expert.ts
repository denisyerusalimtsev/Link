import { ExpertType } from './expert-type';
import { ExpertStatus } from './expert-status';
export class Expert {
    constructor(
        public id: string,
        public firstName: string,
        public lastName: string,
        public expertType: ExpertType,
        public expertStatus: ExpertStatus
    ) { }
}
