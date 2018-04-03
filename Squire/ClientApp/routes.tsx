import * as React from 'react';
import { Layout } from './components/Layout';
import { EmptyLayout } from './components/EmptyLayout';
import Home from './components/Home';
import FetchData from './components/FetchData';
import Counter from './components/Counter';
import Widget from './components/Widget';
import { Router, Route, IndexRoute, hashHistory } from 'react-router';

export const routes =
    <Router history={hashHistory}>
        <Route path="/" component={LayoutContainer}>
            <Route component={Layout1}>
                <IndexRoute component={DashboardView} />
                <Route path='Contacts' component={ContactManagerView} />
            </Route>

            <Route component={Layout2}>
                <Route path='CallerId' component={CallerIdView} />
            </Route>

            <Route component={Layout}>
                <Route path='*' component={NotFound} />
            </Route>
        </Route>
    </Router>


    <Route path="/">

        { /* Routes that use layout 1 */}
        <Route component={Layout}>
            <IndexRoute component={Home} />
            <Route path='counter' component={Counter} />
            <Route path='fetchdata/:startDateIndex?' component={FetchData} />
        </Route>

        <Route component={EmptyLayout}>
            { /* Routes that use layout 2 */}
            <Route path='widget/:swId' component={Widget} />
        </Route>
    </Route>