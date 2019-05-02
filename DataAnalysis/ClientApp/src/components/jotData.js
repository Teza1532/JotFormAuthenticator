import React, { Component } from 'react';
import { VictoryBar, VictoryChart, VictoryAxis } from 'victory';

export class JotData extends Component {
    constructor(props) {
        super(props);
        this.state = { Forms: [], loading: true };

        fetch('api/Form/GetForms')
            .then(response => response.json())
            .then(data => {
                this.setState({ Forms: data, loading: false });
            });
    }

    static RenderOverViewForm(Forms) {
        return (
            <p> returned from method</p>
        )
    };

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : JotData.RenderOverViewForm(this.state.Forms);
        debugger;

        return (
            <div>
                <h2>Jobs completed by each department</h2>
                {contents}
            </div>
        );
    }
}




