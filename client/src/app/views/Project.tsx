import React, { Component } from 'react';
import { Redirect, RouteComponentProps } from 'react-router-dom';
import { TimeRegistrationViewModel } from '../models/timeRegistrationViewModel';
import { getAll } from '../api/timeRegistrations';
import ProjectSummary from '../components/ProjectSummary';
import TimeRegistrationsPerProjectTable from '../components/TimeRegistrationsPerProjectTable';

export default class Project extends Component<RouteComponentProps<{ projectId: string; }>, {
  timeRegistrations: TimeRegistrationViewModel[];
  dataLoaded: Boolean;
  addEntryRequested: Boolean;
}> {
  constructor(props: Readonly<RouteComponentProps<{ projectId: string; }>>) {
    super(props);
    this.state = { timeRegistrations: [], dataLoaded: false, addEntryRequested: false };
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

  handleAddingNewEntry = () => {
    this.setState({ addEntryRequested: true });
  };

  getTotalTimeLoggedInHours() {
    return 1;
  }

  render() {
    if (!this.state.dataLoaded) {
      return null;
    }

    if (this.state.addEntryRequested) {
      return (
        <Redirect to={`/project/${Number(this.props.match.params.projectId)}/timeregistration/`} />
      );
    }

    return (
      <>
        <div className="container mx-auto">
          <div className="flex items-center my-6">
            <div className="w-1/2">
              <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" onClick={this.handleAddingNewEntry}>Add entry</button>
            </div>
          </div>

          <ProjectSummary timeRegistrations={this.state.timeRegistrations} />

          <TimeRegistrationsPerProjectTable timeRegistrations={this.state.timeRegistrations} />
        </div>
      </>
    );
  }
}