import React, { Component } from 'react';
import { RouteComponentProps } from 'react-router-dom';
import { getAll } from '../api/timeRegistrations';
import TimeRegistrationsPerProjectTable from '../components/TimeRegistrationsPerProjectTable';
import { TimeRegistrationViewModel } from '../models/timeRegistrationViewModel';

export default class TimeRegistrationsPerProject extends Component<RouteComponentProps<{ projectId: string; }>, {
  timeRegistrations: TimeRegistrationViewModel[];
  dataLoaded: Boolean;
}> {
  constructor(props: Readonly<RouteComponentProps<{ projectId: string; }>>) {
    super(props);
    this.state = { timeRegistrations: [], dataLoaded: false };
  }

  componentDidMount() {
    getAll(Number(this.props.match.params.projectId))
      .then(response => this.handleResponse(response))
      .catch(error => console.log(error));

  }

  private handleResponse(response: TimeRegistrationViewModel[]): void {
    if (response && response.length !== 0) {
      this.setState({ timeRegistrations: response, dataLoaded: true });
    }
  }

  render() {
    if (!this.state.dataLoaded) {
      return null;
    }

    return (
      <>
        <div className="container mx-auto">

          <div className="flex items-center my-6">
            <div className="w-1/2">
              <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Add entry</button>
            </div>

            <div className="w-1/2 flex justify-end">
              <form>
                <input className="border rounded-full py-2 px-4" type="search" placeholder="Search" aria-label="Search" />
                <button className="bg-blue-500 hover:bg-blue-700 text-white rounded-full py-2 px-4 ml-2" type="submit">Search</button>
              </form>
            </div>
          </div>

          <TimeRegistrationsPerProjectTable timeRegistrations={this.state.timeRegistrations} />
        </div>
      </>
    );
  }
}