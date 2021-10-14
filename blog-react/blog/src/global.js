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
  .line {
    background-color: ${({ theme }) => theme.text};
  }
  .container-article {
    background-color: ${({ theme }) => theme.articleSummaryBackground};
    margin-bottom: 10px;
    border-radius: 20px;
    padding-top: 20px !important;
    padding-bottom: 20px;
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
  .articleContent {
    margin-bottom: 80px;
  }
`;