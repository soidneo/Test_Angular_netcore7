import { TestBed } from '@angular/core/testing';
import { StudentComponent } from './student.component';

describe('StudentComponent', () => {
  beforeEach(() => TestBed.configureTestingModule({
    declarations: [StudentComponent]
  }));

  it('should create the student', () => {
    const fixture = TestBed.createComponent(StudentComponent);
    const student = fixture.componentInstance;
    expect(student).toBeTruthy();
  });

  it(`should have as title 'Interrapidisimo_test.Angular'`, () => {
    const fixture = TestBed.createComponent(StudentComponent);
    const student = fixture.componentInstance;
    expect(student.title).toEqual('Interrapidisimo_test.Angular');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(StudentComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.content span')?.textContent).toContain('Interrapidisimo_test.Angular student is running!');
  });
});
