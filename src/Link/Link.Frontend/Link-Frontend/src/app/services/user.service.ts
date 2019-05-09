import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserDto } from '../interfaces/user-dto';

@Injectable()
export class UserService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:50001/api/User/';

  getUsers() {
    return this.http.get<UserDto[]>(this.baseUrl);
}

  getUserById(id: number) {
    return this.http.get<UserDto>(this.baseUrl + '/' + id);
  }

  createUser(user: UserDto) {
    return this.http.post(this.baseUrl, user,
    {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text'
    })
    .subscribe(data => console.log('Works!'));
  }

  updateUser(user: UserDto) {
    return this.http.put(this.baseUrl + '/' + user.id, user);
  }

  deleteUser(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }
}
