export default class ProjectViewModel {
  id: number;
  name: string;
  timeLogged: number;
  deadline: Date;

  constructor(){
    this.id = 0;
    this.name = '';
    this.timeLogged = 0;
    this.deadline = new Date();
  }
}