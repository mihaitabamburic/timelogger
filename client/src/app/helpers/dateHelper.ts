export function getDateAsString(input: string): string {
  const date = new Date(input);
  const day = date.getDay().toString().padStart(2, '0');
  const month = (date.getMonth() + 1).toString().padStart(2, '0');
  const year = date.getFullYear();
  const hour = date.getHours().toString().padStart(2, '0');
  const minutes = date.getMinutes().toString().padStart(2, '0');
  return `${day}-${month}-${year} ${hour}:${minutes}`;
}