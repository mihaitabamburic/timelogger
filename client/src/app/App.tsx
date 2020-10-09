import * as React from 'react';
import './tailwind.generated.css';
import {
    BrowserRouter as Router,
    Switch,
    Route
} from 'react-router-dom';

import TimeRegistrationsPerProject from './views/TimeRegistrationsPerProject';
import Home from './views/Home';
import AddTimeRegistration from './views/AddTimeRegistration';

export default function App() {
    return (
        <Router>
            <header className="bg-gray-900 text-white flex items-center h-12 w-full">
                <div className="container mx-auto">
                    <a className="navbar-brand" href="/">Timelogger</a>
                </div>
            </header>
            <div>
                <Switch>
                    <Route exact={true} path="/project/:projectId/timeregistration/" component={AddTimeRegistration} />
                    <Route exact={true} path="/project/:projectId/" component={TimeRegistrationsPerProject} />
                    <Route exact={true} path="/" component={Home} />
                </Switch>
            </div>
        </Router>
    );
}
