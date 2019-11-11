import { combineReducers } from "redux";
import { HttpState, httpReducer } from "./http";

export interface StateReducer {
    http: HttpState;
};

export const state = combineReducers<StateReducer>({
    http: httpReducer
});