import React from 'react';
import { getDateAsString } from '../helpers/dateHelper';
import { convertMinutesToHoursAsString } from '../helpers/numberFormatHelper';
import ProjectViewModel from '../models/projectViewModel';

function getRedirectLinkTo(projectId: number) {
	return `/projects/${projectId}`;
}

export default function ProjectsTable(props: { projects: ProjectViewModel[]; sortByDeadline: any; }) {
	return (
		<table className="table-fixed w-full">
			<thead className="bg-gray-200">
				<tr>
					<th className="border px-4 py-2 w-12">#</th>
					<th className="border px-4 py-2">Project Name</th>
					<th className="border px-4 py-2">Time Logged</th>
					<th className="border px-4 py-2" onClick={props.sortByDeadline}>Deadline</th>
					<th className="border px-4 py-2">Actions</th>
				</tr>
			</thead>
			<tbody>
				{props.projects.map((project, index) =>
					<tr key={index}>
						<td className="border px-4 py-2 w-12">{index + 1}</td>
						<td className="border px-4 py-2">{project.name}</td>
						<td className="border px-4 py-2">{convertMinutesToHoursAsString(project.timeLogged)}</td>
						<td className="border px-4 py-2">{getDateAsString(project.deadline)}</td>
						<td className="border px-4 py-2">
							<a href={getRedirectLinkTo(project.id)}>
								<input type="button" value={"Overview"} />
							</a>
						</td>
					</tr>)}
			</tbody>
		</table>
	);
}