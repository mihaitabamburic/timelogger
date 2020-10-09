import React, { Component } from 'react';
import { getAll } from '../api/projects';
import ProjectsTable from '../components/ProjectsTable';
import ProjectViewModel from '../models/projectViewModel';

export default class Projects extends Component<{}, {
	projects: ProjectViewModel[];
	dataLoaded: Boolean;
}> {
	constructor(props: Readonly<{}>) {
		super(props);
		this.state = { projects: [], dataLoaded: false };
	}

	async componentDidMount() {
		this.handleResponse(await getAll());
	}

	private handleResponse(response: ProjectViewModel[]): void {
		if (response) {
			this.setState({ projects: response, dataLoaded: true });
		}
	}

	render() {
		if (!this.state.dataLoaded) {
			return null;
		}

		return (
			<>
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

				<ProjectsTable projects={this.state.projects} />
			</>
		);
	}
}