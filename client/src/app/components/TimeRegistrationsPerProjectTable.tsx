import React from 'react';
import { getDateAsString } from '../helpers/dateHelper';
import { TimeRegistrationViewModel } from '../models/timeRegistrationViewModel';

export default function TimeRegistrationsPerProjectTable(props: { timeRegistrations: TimeRegistrationViewModel[]; }) {
	return (
		<table className="table-fixed w-1/2">
			<thead className="bg-gray-200">
				<tr>
					<th className="border px-4 py-2 w-12">#</th>
					<th className="border px-4 py-2">Time Logged</th>
					<th className="border px-4 py-2">Created On</th>
				</tr>
			</thead>
			<tbody>
				{props.timeRegistrations.map((timeRegistration, index) =>
					<tr key={index}>
						<td className="border px-4 py-2 w-12">{index + 1}</td>
						<td className="border px-4 py-2">{timeRegistration.timeLogged} m</td>
						<td className="border px-4 py-2">{getDateAsString(timeRegistration.createdAt)}</td>
					</tr>)}
			</tbody>
		</table>
	);
}