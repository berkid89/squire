import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as WidgetStore from '../store/Widget';

type WidgetProps =
    WidgetStore.WidgetState
    & typeof WidgetStore.actionCreators
    & RouteComponentProps<{ swId: string }>;

class Widget extends React.Component<WidgetProps, {}> {
    componentWillMount() {
        const swId = this.props.match.params.swId;
        this.props.requestWidget(swId);
    }
    
    public render() {
        return (<div>
            <h1>Widget!</h1>
            <p>{this.props.isLoading}</p>
            <p>{this.props.swId}</p>
            <p>{JSON.stringify(this.props.software)}</p>
        </div>);
    }
}

export default connect(
    (state: ApplicationState) => state.widget,
    WidgetStore.actionCreators
)(Widget) as typeof Widget;