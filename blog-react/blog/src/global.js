import { createGlobalStyle } from 'styled-components';

export const GlobalStyles = createGlobalStyle`
  *,
  *::after,
  *::before {
    box-sizing: border-box;
  }
  body {
    background: ${({ theme }) => theme.body};
    color: ${({ theme }) => theme.text};
    padding: 0;
    margin: 0;
    font-family: BlinkMacSystemFont, -apple-system, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
    transition: all 0.25s linear;
  }
  header {
    display: flex;
    justify-content: space-between;
    padding: 2px;
  }
  content {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    height: 92vh;
  }
  footer {
    position: absolute;
    bottom: 2%;
    left: 50%;
    transform: translateX(-50%);
  }
  small {
    display: block;
  }
  button {
    display: block;
  }
  a {
    color: ${({ theme }) => theme.text};
  }
`;