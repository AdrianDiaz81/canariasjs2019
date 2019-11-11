import * as React from 'react';
import { Route, Switch } from 'react-router-dom';
import { Layout } from './components/layout';
import {ListAvengerContainer} from './components/avengers/listAvengerContainer';
import {AddAvengerContainer} from './components/avengers/addAvengerContainer';
import { EditAvengerContainer} from './components/avengers/editAvengerContainer';


export const routes =
    <Switch>       
        <Layout>
            <Switch>
            <Route exact={true} path='/' component={ListAvengerContainer} />
            <Route exact={true} path='/anyadir' component={AddAvengerContainer} />
            <Route exact path="/editar/:id" component={EditAvengerContainer} />
            </Switch>
        </Layout>
    </Switch>;