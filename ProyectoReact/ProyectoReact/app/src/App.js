import React from 'react';
import './App.scss';
import { BrowserRouter, Switch, Route, NavLink } from 'react-router-dom';
import { Component } from 'react';
import Login from './login/login';
import Home from './home/home';

class App extends Component {
    render() {
        return (
            <div className="App">
            <BrowserRouter>
              <div>
                <div className="header">
                  <NavLink exact activeClassName="active" to="/home">Home</NavLink>
                  <NavLink activeClassName="active" to="/login">Login</NavLink><small>(Access without token only)</small>
                  <NavLink activeClassName="active" to="/dashboard">Dashboard</NavLink><small>(Access with token only)</small>
                </div>
                <div className="content">
                  <Switch>
                    <Route exact path="/home" component={Home} />
                    <Route path="/login" component={Login} />
                  </Switch>
                </div>
              </div>
            </BrowserRouter>
            </div>
        );
    }
}
export default App;
