import { actionsDef } from '../actions/actionsDef';
export const addAvengerReducer = (state: boolean , action: any) => {
    switch (action.type) {
        case actionsDef.avenger.ADD_AVENGER:
            return handleAddAvengerCompleted(state, action.payload);
    }
    return state;
};
const handleAddAvengerCompleted = (state: boolean=true, payload: boolean) => {
    return payload;
};