import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { Home } from './components/Home';
import { Calculator } from './components/Calculator';
import { NavMenu } from './components/NavMenu';

import './custom.css'

function App() {

    return (
        <div>
            <Router>
                <NavMenu />
                <div className="container">
                    <Switch>
                        <Route exact path='/' component={ Home } />
                        <Route path='/calculator' component={ Calculator }/>
                    </Switch>
                </div>
            </Router>
            </div>
    );
}

export default App;
