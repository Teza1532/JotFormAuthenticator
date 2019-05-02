import React, { Component } from 'react';
import moment from 'moment';
import './main.css';
import { withRouter } from 'react-router';

export class Form extends Component {
    static displayName = Form.name;

    constructor(props) {
        super(props);
        this.state = { forms: [], loading: true };

        fetch('api/Home/FormFields/' + props.match.params.formID)
            .then(response => response.json())
            .then(data => {
                this.setState({ fields: data, formID: props.match.params.formID, loading: false });
            });
    }

    acceptForm(formID) {
        fetch('api/Home/AcceptForm/' + formID, method: "POST")
            .then(response => response.text())
            .finally(() =>
                this.props.history.push('/')            
            );
    }

    rejectForm(formID) {
       fetch('api/Home/RejectForm/' + formID, method: "POST",);
            this.props.history.push('/');      
    }

    static renderForm(fields) {
        return (
            <div key={fields.formID} class="row">
                {fields.map(field =>
                    <div  class="col-6 form-field__wrapper">
                        <strong class="col-6 form-field__text">{field.fieldName}:</strong>
                        <div class="col-6 form-field__text" >{'\u00A0'}{'\u00A0'}{'\u00A0'}{field.fieldValue}</div>
                    </div>
                )}
            </div>
        )
    }

    render() {
        let contents =
            this.state.loading
                ? <p><em>Loading...</em></p>
                : Form.renderForm(this.state.fields);;
        return (
            <div class="row">
                <h1 class="col-12">Index</h1>
                <div class="row">
                    <div class="col-6">
                        <strong>Form: {this.props.match.params.formName}</strong>
                    </div>
                    <div class="col-6">
                        <strong>
                            Submission:  {this.props.match.params.SubmissionID}
                        </strong>
                    </div>
                </div>
                {contents}
                <div class="form-field__footer">
                    <div class="row">
                        <div class="col-6">
                            <button onClick={() => this.acceptForm(this.state.formID)} class="form-field__accept">Accept</button>
                        </div>
                        <div class="col-6" >
                            <button onClick={() => this.rejectForm(this.state.formID)} class="form-field__reject">Reject</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
