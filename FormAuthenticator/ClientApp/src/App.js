import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/RejectedForms';
import { Counter, AcceptedForms } from './components/AcceptedForms';
import { Form } from './components/Form'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/LockedForm/:formID/:formName/:SubmissionID/:state' component={LockedForm} />
                <Route path='/rejected' component={RejectedForms} />
                <Route path='/form/:formID/:formName/:SubmissionID' component={Form} />
            </Layout>
        );
    }
}
