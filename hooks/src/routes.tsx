import * as React from 'react';
import { Route, Switch } from 'react-router-dom';
import { Layout } from './components/layout';
import { LoadListComponent } from './hooks/listAvengersHooks';
import { EditAvengerComponent } from './hooks/editAvengerHooks';
import { AddAvengerComponent } from './hooks/addAvengerHooks';

export const routes =
    <Switch>       
        <Layout>
            <Switch>
            <Route exact={true} path='/' component={LoadListComponent} />
            <Route exact={true} path='/anyadir' component={AddAvengerComponent} />
            <Route exact={true} path='/editar/:id' component={EditAvengerComponent} />
            </Switch>
        </Layout>
    </Switch>;