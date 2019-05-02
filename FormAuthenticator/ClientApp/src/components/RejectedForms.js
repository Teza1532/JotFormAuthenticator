import React, { Component } from 'react';
import moment from 'moment';
import { Link } from 'react-router-dom';
import './main.css';

export class RejectedForms extends Component {
    static displayName = RejectedForms.name;

    constructor(props) {
        super(props);
        this.state = { forms: [], loading: true };

        fetch('api/Home/RejectedForms')
            .then(response => response.json())
            .then(data => {
                this.setState({ forms: data, loading: false });
            });
    }

    static renderForms(forms) {
        return (
            <div class="container-fluid">
                {forms.map(form =>
                    <Link to={"/Lockedform/" + form.formModelID + "/" + form.formName + "/" + form.submissionID + "/" + true}>
                        <div class="formList-row__wrapper">
                            <div class="row">
                                <div class="col-sm">
                                    <div>Form Name: {form.formName}</div>
                                </div>
                                <div class="col-sm">
                                    <div>Submission ID: {form.submissionID}</div>
                                </div>
                                <div class="col-sm">
                                    <div>Rejected On: {moment(form.updatedOn).format('DD-MMM-YYYY')}</div>
                                </div>
                                <div class="col-sm formList-row__right--column">
                                    <div>Completed On: {moment(form.createdOn).format('DD-MMM-YYYY')}</div>
                                </div>

                            </div>
                        </div>
                    </Link>
                )}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : RejectedForms.renderForms(this.state.forms);
        return (

            <div>
                <h1>Rejected Forms</h1>
                {contents}
            </div>

        );
    }
}