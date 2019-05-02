import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { RejectedForms } from './components/RejectedForms';
import { AcceptedForms } from './components/AcceptedForms';
import { LockedForm } from './components/LockedForm';
import { Form } from './components/Form'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/LockedForm/:formID/:formName/:SubmissionID/:state' component={LockedForm} />
                <Route path='/rejected' component={RejectedForms} />
                <Route path='/accepted' component={AcceptedForms} />
                <Route path='/form/:formID/:formName/:SubmissionID' component={Form} />
            </Layout>
        );
    }
}
