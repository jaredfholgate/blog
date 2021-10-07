import React from 'react';
import { ThemeProvider } from 'styled-components';

import { useDarkMode } from './useDarkMode';
import { lightTheme, darkTheme } from './theme';
import { GlobalStyles } from './global';

import Toggle from './components/Toggle';

function App() {
  const [theme, toggleTheme, componentMounted] = useDarkMode();
  const themeMode = theme === 'light' ? lightTheme : darkTheme;

  if (!componentMounted) {
    return <div />
  };

  return (
    <ThemeProvider theme={themeMode}>
      <>
        <GlobalStyles />
        <header>
          <div className="alignLeft">
            <large>Jared Holgate Blog</large>
          </div>
          <div className="alignRight">
            <Toggle theme={theme} toggleTheme={toggleTheme} />
          </div>
        </header>
        <content>
          Work in Progress!
        </content>
        

        <footer>
          <small>© Jared Holgate {new Date().getFullYear()}</small>
        </footer>
      </>
    </ThemeProvider>
  );
};

export default App;
