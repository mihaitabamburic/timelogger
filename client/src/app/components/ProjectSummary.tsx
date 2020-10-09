import React from 'react';
import { TimeRegistrationViewModel } from '../models/timeRegistrationViewModel';

function getTotalHoursFrom(timeRegistrations: TimeRegistrationViewModel[]): number {
  let sum = 0;

  timeRegistrations.forEach(element => {
    sum += element.timeLogged;
  });

  return sum / 60;
}

export default function ProjectSummary(props: { timeRegistrations: TimeRegistrationViewModel[]; }) {
  return (
    <>
      <div className="container mx-auto">
        <p className="block mt-1 text-lg leading-tight font-semibold text-gray-900 hover:underline">Total Time Logged: {getTotalHoursFrom(props.timeRegistrations)} h</p>
      </div>
    </>
  );
}