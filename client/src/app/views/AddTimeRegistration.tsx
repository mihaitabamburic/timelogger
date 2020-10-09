import React, { Component } from 'react';
import { Redirect, RouteComponentProps } from 'react-router-dom';
import { save } from '../api/timeRegistrations';
import { TimeRegistrationSaveModel } from '../models/timeRegistrationSaveModel';

const MINUTES_WORKED_MIN_VALUE = 30;

export default class AddTimeRegistration extends Component<RouteComponentProps<{ projectId: string; }>, { minutesWorked: number; saveSuccessful: Boolean; }> {
  constructor(props: Readonly<RouteComponentProps<{ projectId: string; }>>) {
    super(props);
    this.state = { minutesWorked: MINUTES_WORKED_MIN_VALUE, saveSuccessful: false };
  }

  updateTimeLogged = (e: React.ChangeEvent<HTMLInputElement>) => {
    this.setState({ minutesWorked: Number(e.target.value) });
  };

  handleSavingTimeRegistration = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
    e.preventDefault();

    if (this.state.minutesWorked < MINUTES_WORKED_MIN_VALUE) {
      return;
    }

    const timeRegistration = new TimeRegistrationSaveModel();
    timeRegistration.minutesWorked = this.state.minutesWorked;
    save(Number(this.props.match.params.projectId), timeRegistration)
      .then(result => this.setState({ saveSuccessful: result }))
      .catch(error => console.log(error));
  };

  render() {
    if (this.state.saveSuccessful) {
      return (
        <Redirect to={`/project/${this.props.match.params.projectId}/`} />
      );
    }

    return (
      <>
        <div className="container mx-auto">

          <div className="flex items-center my-6">
            <form>
              <label className="py-2 px-4" htmlFor="newTimeRegistrationInput">Time worked </label>
              <input className="border py-2 px-4" type="number" min={MINUTES_WORKED_MIN_VALUE} defaultValue={MINUTES_WORKED_MIN_VALUE} onChange={this.updateTimeLogged} id="newTimeRegistrationInput" required={true} />

              <div className="flex justify-end my-6">
                <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" onClick={this.handleSavingTimeRegistration}>Log time</button>
              </div>
            </form>
          </div>

        </div>
      </>
    );
  }
}