import React, { Component } from 'react';
import moment from 'moment';
import './main.css';
import { Link } from 'react-router-dom';


export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { forms: [], loading: true };

        fetch('api/Home/Forms')
            .then(response => response.json())
            .then(data => {
                this.setState({ forms: data, loading: false });
            });
    }

    static renderForms(forms) {
        return (
             <div class="container-fluid">
                {forms.map(form =>
                    <Link to={"/form/" + form.formModelID + "/" + form.formName + "/" + form.submissionID}>
                        <div class="formList-row__wrapper">
                            <div class="row">
                                <div class="col-sm">
                                    <div>Form Name: {form.formName}</div>
                                </div>
                                <div class="col-sm">
                                    <div>Submission ID: {form.submissionID}</div>
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
            : Home.renderForms(this.state.forms);
        return (
           
            <div>
                <h1>Forms</h1>
                {contents}
            </div>
      
        );
    }
}
