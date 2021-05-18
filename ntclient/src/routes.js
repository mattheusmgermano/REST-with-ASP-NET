import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

import Login from './pages/Login';
import Books from './pages/Books';
import NewBooks from './pages/NewBooks';

export default function Routes(){
    return(
        <BrowserRouter>
        <Switch>
            <Route path="/" exact component={Login}/>
            <Route path="/books" exact component={Books}/>
            <Route path="/books/novo/:bookId" component={NewBooks}/>
        </Switch>
        </BrowserRouter>
    )
}