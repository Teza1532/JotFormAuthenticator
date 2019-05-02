import React, { Component } from 'react';
import moment from 'moment';
import { Link } from 'react-router-dom';


export class AcceptedForms extends Component {
    static displayName = AcceptedForms.name;

    constructor(props) {
        super(props);
        this.state = { forms: [], loading: true };

        fetch('api/Home/AcceptedForms')
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
                                    <div>Accepted On: {moment(form.updatedOn).format('DD-MMM-YYYY')}</div>
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
            : AcceptedForms.renderForms(this.state.forms);
        return (

            <div>
                <h1>Accepted Forms</h1>
                {contents}
            </div>

        );
    }
}
