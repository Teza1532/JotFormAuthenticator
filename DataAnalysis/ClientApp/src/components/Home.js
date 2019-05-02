import React, { Component } from 'react';
import { VictoryBar, VictoryChart, VictoryAxis } from 'victory';

export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = { jobsPerDepartment: [], loading: true };

        fetch('api/Vehicle/GetDepartmentJobsCount')
            .then(response => response.json())
            .then(data => {
                this.setState({ jobsPerDepartment: data, loading: false });
            });
    }

    static renderJobsPerDepartmentChart(jobsPerDepartment) {
        return (
            <VictoryChart domainPadding={20}>
                <VictoryAxis
                    fixLabelOverlap={true}
                />
                <VictoryBar data={jobsPerDepartment} x="departmentID" y="jobsCompleted" />
            </VictoryChart>
        )
    };

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderJobsPerDepartmentChart(this.state.jobsPerDepartment);


        return (
            <div>
                <h2>Jobs completed by each department</h2>
                {contents}
            </div>
        );
    }
}




