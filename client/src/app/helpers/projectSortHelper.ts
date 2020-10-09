import ProjectViewModel from '../models/projectViewModel';

function sortAsc(a: string, b: string): number {
  const datea = new Date(a);
  const dateb = new Date(b);
  if (datea === dateb) {
    return 0;
  }

  return datea > dateb ? 1 : -1;
}

function sortDesc(a: string, b: string): number {
  return sortAsc(a, b) * -1;
}

export function sortProjects(
  projects: ProjectViewModel[], sortAscending: Boolean): ProjectViewModel[] {
  const result = Array.from(projects);
  result.sort(sortAscending ? (a, b) => sortAsc(a.deadline, b.deadline) : (a, b) => sortDesc(a.deadline, b.deadline));
  return result;
}