import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { UserListComponent } from './user-list.component';
import { UserService } from '../../services/user.service';
import { of, throwError } from 'rxjs';
import { User } from '../../models/user.model';

describe('UserListComponent', () => {
  let component: UserListComponent;
  let fixture: ComponentFixture<UserListComponent>;
  let userService: jasmine.SpyObj<UserService>;

  const mockUsers: User[] = [
    { id: 1, username: 'johndoe', email: 'john@example.com' },
    { id: 2, username: null, email: 'jane@example.com' },
    { id: 3, username: 'bobsmith', email: 'bob@example.com' }
  ];

  beforeEach(async () => {
    const userServiceSpy = jasmine.createSpyObj('UserService', ['getUsers']);

    await TestBed.configureTestingModule({
      imports: [UserListComponent, HttpClientTestingModule],
      providers: [
        { provide: UserService, useValue: userServiceSpy }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(UserListComponent);
    component = fixture.componentInstance;
    userService = TestBed.inject(UserService) as jasmine.SpyObj<UserService>;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should load users on init', () => {
    userService.getUsers.and.returnValue(of(mockUsers));

    fixture.detectChanges();

    expect(userService.getUsers).toHaveBeenCalled();
    expect(component.users).toEqual(mockUsers);
    expect(component.errorMessage).toBeNull();
  });

  it('should handle error when loading users fails', () => {
    spyOn(console, 'error');
    userService.getUsers.and.returnValue(throwError(() => new Error('API Error')));

    fixture.detectChanges();

    expect(component.users).toEqual([]);
    expect(component.errorMessage).toBe('An error occurred while loading users. Please try again later.');
  });
});
