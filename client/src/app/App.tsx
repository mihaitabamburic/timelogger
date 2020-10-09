import * as React from 'react';
import './tailwind.generated.css';
import {
    BrowserRouter as Router,
    Switch,
    Route
} from 'react-router-dom';

import Project from './views/Project';
import Home from './views/Home';
import AddTimeRegistration from './views/AddTimeRegistration';
import Projects from './views/Projects';

export default function App() {
    return (
        <Router>
            <header className="bg-gray-900 text-white flex items-center h-12 w-full">
                <div className="container mx-auto">
                    <a className="navbar-brand" href="/">Timelogger</a>
                    <a className="navbar-brand pl-8" href="/projects">Projects</a>
                </div>
            </header>
            <div>
                <Switch>
                    <Route exact={true} path="/projects/:projectId/timeregistration/" component={AddTimeRegistration} />
                    <Route exact={true} path="/projects/:projectId/" component={Project} />
                    <Route exact={true} path="/projects/" component={Projects} />
                    <Route path="*" component={Home} />
                </Switch>
            </div>
        </Router>
    );
}
