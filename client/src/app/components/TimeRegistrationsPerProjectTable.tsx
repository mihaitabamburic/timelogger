import React from 'react';
import { TimeRegistrationViewModel } from '../models/timeRegistrationViewModel';

export default function TimeRegistrationsPerProjectTable(props: { timeRegistrations: TimeRegistrationViewModel[]; }) {
	return (
		<table className="table-fixed w-full">
			<thead className="bg-gray-200">
				<tr>
					<th className="border px-4 py-2 w-12">#</th>
					<th className="border px-4 py-2">Time Logged</th>
				</tr>
			</thead>
			<tbody>
				{props.timeRegistrations.map(timeRegistration =>
					<tr key={timeRegistration.timeRegistrationId}>
						<td className="border px-4 py-2 w-12">{timeRegistration.timeRegistrationId}</td>
						<td className="border px-4 py-2">{timeRegistration.timeLogged}</td>
					</tr>)}
			</tbody>
		</table>
	);
}