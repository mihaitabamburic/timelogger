import React from 'react';
import ProjectViewModel from '../models/projectViewModel';

export default function ProjectsTable(props: { projects: ProjectViewModel[]; }) {
	return (
		<table className="table-fixed w-full">
			<thead className="bg-gray-200">
				<tr>
					<th className="border px-4 py-2 w-12">#</th>
					<th className="border px-4 py-2">Project Name</th>
					<th className="border px-4 py-2">Time Logged</th>
					<th className="border px-4 py-2">Deadline</th>
				</tr>
			</thead>
			<tbody>
				{props.projects.map(project =>
					<tr>
						<td className="border px-4 py-2 w-12">{project.id}</td>
						<td className="border px-4 py-2">{project.name}</td>
						<td className="border px-4 py-2">{project.timeLogged}</td>
						<td className="border px-4 py-2">{project.deadline}</td>
					</tr>)}
			</tbody>
		</table>
	);
}