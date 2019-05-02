import React, { Component } from 'react';
import './main.css';

export class LockedForm extends Component {
    static displayName = LockedForm.name;

    constructor(props) {
        super(props);
        this.state = { forms: [], loading: true };

        fetch('api/Home/FormFields/' + props.match.params.formID)
            .then(response => response.json())
            .then(data => {
                this.setState({ fields: data, formID: props.match.params.formID, loading: false });
            });
    }

    static renderForm(fields) {
        return (
            <div key={fields.formID} class="row">
                {fields.map(field =>
                    <div class="col-6 form-field__wrapper">
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
                : LockedForm.renderForm(this.state.fields);
        debugger;
        let formState = this.props.match.params.state ? <h2>Accepted</h2> : <h2>Rejected</h2>;

        return (
            
            <div class="row">
                <div>
                    {formState}
                </div>
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
            </div>
        );
    }
}
