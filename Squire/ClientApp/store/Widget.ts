import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

export interface WidgetState {
    isLoading: boolean;
    swId: string;
    software: any;
}

interface RequestWidgetAction {
    type: 'REQUEST_WIDGET';
    swId: string;
}

interface ReceiveWidgetAction {
    type: 'RECEIVE_WIDGET';
    swId: string;
    software: any;
}

type KnownAction = RequestWidgetAction | ReceiveWidgetAction;

export const actionCreators = {
    requestWidget: (swId: string): AppThunkAction<KnownAction> => async (dispatch, getState) => {
        dispatch({ type: 'REQUEST_WIDGET', swId: swId });
        const fetchWidget = fetch(`Widget/Show?id=${swId}`);
        addTask(fetchWidget);
        const res = await (await fetchWidget).json();
        debugger;
        dispatch({ type: 'RECEIVE_WIDGET', swId: swId, software: res });
    }
};

const unloadedState: WidgetState = { swId: '', software: {}, isLoading: false };

export const reducer: Reducer<WidgetState> = (state: WidgetState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;

    switch (action.type) {
        case 'REQUEST_WIDGET':
            return {
                swId: action.swId,
                software: state.software,
                isLoading: true
            };
        case 'RECEIVE_WIDGET':
            {
                debugger;
                return {
                    swId: action.swId,
                    software: action.software,
                    isLoading: false
                };
            }
        default:
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
