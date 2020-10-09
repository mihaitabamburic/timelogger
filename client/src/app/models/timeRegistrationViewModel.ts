export class TimeRegistrationViewModel {
  timeRegistrationId: number;
  timeLogged: number;
  createdAt: string;

  constructor() {
    this.timeRegistrationId = 0;
    this.timeLogged = 0;
    this.createdAt = '';
  }
}