import * as React from 'react';

export class EmptyLayout extends React.Component<{}, {}> {
    public render() {
        return <div className='container-fluid'>
            <div className='row'>
                {this.props.children}
            </div>
        </div>;
    }
}
