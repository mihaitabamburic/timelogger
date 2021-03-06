import React, { Component } from 'react';
import { getAll } from '../api/projects';
import ProjectsTable from '../components/ProjectsTable';
import { sortProjects } from '../helpers/projectSortHelper';
import ProjectViewModel from '../models/projectViewModel';

export default class Projects extends Component<{}, {
	projects: ProjectViewModel[];
	sortAscending: Boolean;
	dataLoaded: Boolean;
	enableAdd: Boolean;
	enableSearch: Boolean;
}> {
	constructor(props: Readonly<{}>) {
		super(props);
		this.state = { projects: [], sortAscending: true, dataLoaded: false, enableSearch: false, enableAdd: false };
	}

	async componentDidMount() {
		const projects = await getAll();
		if (projects) {
			this.setState({ projects, dataLoaded: true });
		}
	}

	sortByDeadline = () => {
		debugger;
		const sortAscending = this.state.sortAscending;
		const projects = sortProjects(this.state.projects, this.state.sortAscending);
		this.setState({ projects, sortAscending: !sortAscending });
	};

	renderAddButtonIfNeeded() {
		if (this.state.enableAdd) {
			return (
				<div className="w-1/2">
					<button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Add entry</button>
				</div>
			);
		}
		return null;
	}

	renderSearchButtonIfNeeded() {
		if (this.state.enableSearch) {
			return (
				<div className="w-1/2 flex justify-end">
					<form>
						<input className="border rounded-full py-2 px-4" type="search" placeholder="Search" aria-label="Search" />
						<button className="bg-blue-500 hover:bg-blue-700 text-white rounded-full py-2 px-4 ml-2" type="submit">Search</button>
					</form>
				</div>
			);
		}
		return null;
	}

	render() {
		if (!this.state.dataLoaded) {
			return null;
		}

		return (
			<>
				<main>
					<div className="container mx-auto">
						<div className="flex items-center my-6">
							{this.renderAddButtonIfNeeded()}
							{this.renderSearchButtonIfNeeded()}
						</div>

						<ProjectsTable projects={this.state.projects} sortByDeadline={this.sortByDeadline} />
					</div>
				</main>
			</>
		);
	}
}