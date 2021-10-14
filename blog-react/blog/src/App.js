import React from 'react';
import { ThemeProvider } from 'styled-components';

import { lightTheme, darkTheme } from './theme';
import { GlobalStyles } from './global';

import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import { Link } from "react-router-dom";
import { Article, Footer, Home, AboutMe } from "./components";

import { useDarkMode } from './components/useDarkMode';
import Toggle from './components/Toggle';

function App() {
  const [theme, toggleTheme ] = useDarkMode();
  const themeMode = theme === 'light' ? lightTheme : darkTheme;

  return (
    <ThemeProvider theme={themeMode}>
      <>
        <GlobalStyles />
        <Router>
          <div className="navigation">
            <nav class="navbar navbar-expand navbar-dark bg-dark">
              <div class="container">
                <Link class="navbar-brand" to="/">
                  Jared Holgate's Blog
                </Link>
                <div>
                  <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                      <Link class="nav-link" to="/">
                        Home
                      </Link>
                    </li>
                    <li class="nav-item">
                      <Link class="nav-link" to="/about">
                        About
                      </Link>
                    </li>
                    <li>
                     <Toggle theme={theme} toggleTheme={toggleTheme} />
                    </li>
                  </ul>
                </div>
              </div>
            </nav>
          </div>
 
          <Switch>
            <Route path="/" exact component={() => <Home />} />
            <Route path="/about" exact component={() => <AboutMe />} />
            <Route path="/article/:id" exact component={() => <Article />} />
          </Switch>
          <Footer />
        </Router>
      </>
    </ThemeProvider>
  );
};

export default App;
