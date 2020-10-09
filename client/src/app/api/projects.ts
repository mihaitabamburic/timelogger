import { getUserId } from '../services/userService';
import ProjectViewModel from '../models/projectViewModel';

const BASE_URL = 'http://localhost:3001/api';

export async function getAll(): Promise<ProjectViewModel[]> {
	const response = await fetch(`${BASE_URL}/v1/projects/users/${getUserId()}`);

	if (response.ok) {
		return response.json();
	}
	return [];
}