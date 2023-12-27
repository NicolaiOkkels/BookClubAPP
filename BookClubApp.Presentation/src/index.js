import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { BrowserRouter} from 'react-router-dom';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { Auth0Provider } from '@auth0/auth0-react';
import Modal from 'react-modal';

const root = ReactDOM.createRoot(document.getElementById('root'));
const domain = process.env.REACT_APP_AUTH0_DOMAIN; //TODO: change from env at release and is only for test
const clientId = process.env.REACT_APP_AUTH0_CLIENT_ID; //TODO: change from env at release and is only for test
const audience = process.env.REACT_APP_AUTH0_AUDIENCE_IDENTIFIER

Modal.setAppElement('#root');
root.render(
  <>
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
  </>,
);

reportWebVitals();