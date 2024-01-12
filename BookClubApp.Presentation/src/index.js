import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { BrowserRouter} from 'react-router-dom';

import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { Auth0Provider } from '@auth0/auth0-react';

const domain = process.env.REACT_APP_AUTH0_DOMAIN;
const clientId = process.env.REACT_APP_AUTH0_CLIENT_ID; 
const audience = process.env.REACT_APP_AUTH0_AUDIENCE_IDENTIFIER

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <Auth0Provider
        domain={domain}
        clientId={clientId}
        authorizationParams={{ 
          redirect_uri: window.location.origin,
          audience: audience,
          scope: "openid profile email",
        }}
      >
        <App />
      </Auth0Provider>
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById('root')
);

reportWebVitals();