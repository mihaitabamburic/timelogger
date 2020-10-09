import { TimeRegistrationSaveModel } from '../models/timeRegistrationSaveModel';
import { TimeRegistrationViewModel } from '../models/timeRegistrationViewModel';

const BASE_URL = 'http://localhost:3001/api';

export async function getAll(projectId: number): Promise<TimeRegistrationViewModel[]> {
	const response = await fetch(`${BASE_URL}/v1/timeregistrations/projects/${projectId}`);
	if (response.ok) {
		return await response.json();
	}
	return [];
}

export async function save(projectId: number, timeRegistration: TimeRegistrationSaveModel): Promise<boolean> {
	const response = await fetch(`${BASE_URL}/v1/timeregistrations/projects/${projectId}`, {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json'
		},
		mode: 'cors',
		credentials: 'include',
		body: JSON.stringify(timeRegistration)
	});
	return response.status === 204;
}