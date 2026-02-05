import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { UserService } from './user.service';
import { User } from '../models/user.model';

describe('UserService', () => {
  let service: UserService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [UserService]
    });
    service = TestBed.inject(UserService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should fetch users from API', () => {
    const mockUsers: User[] = [
      { id: 1, username: 'johndoe', email: 'john@example.com' },
      { id: 2, username: null, email: 'jane@example.com' },
      { id: 3, username: 'bobsmith', email: 'bob@example.com' }
    ];

    service.getUsers().subscribe(users => {
      expect(users.length).toBe(3);
      expect(users).toEqual(mockUsers);
    });

    // Keep this aligned with the service's configured API URL.
    const req = httpMock.expectOne('http://localhost:5008/api/users');
    expect(req.request.method).toBe('GET');
    req.flush(mockUsers);
  });
});
