import React from 'react';
import './App.css';
import {BrowserRouter, Route, Switch} from "react-router-dom";
import NavBar from "./components/navBar";
import CosmeticsTable from "./components/cosmeticsTable";

function App() {
  return (
    <BrowserRouter>
      <NavBar/>
        <Switch>
            <Route path={"/Cosmetics"} component={CosmeticsTable}/>
        </Switch>
    </BrowserRouter>
  );
}

export default App;
