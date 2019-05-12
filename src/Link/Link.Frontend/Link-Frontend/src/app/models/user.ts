import { UserDto } from '../interfaces/user-dto';

export class User {
    constructor(public id: string,
                public firstName: string,
                public lastName: string,
                public phoneNumber: string,
                public email: string) { }

    public static Create(dto: UserDto): User {
        return new User(dto.id, dto.firstName, dto.lastName, dto.phoneNumber, dto.email);
    }
}
