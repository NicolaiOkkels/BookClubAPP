import React from 'react';
import { useEffect, useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import Layout  from './Components/Layout';
import { useAuth0 } from '@auth0/auth0-react';
//import './custom.css';
import './App.css';

const App = () => {
  const { isAuthenticated, isLoading, error, loginWithRedirect } = useAuth0();
  const [redirectInProgress, setRedirectInProgress] = useState(false); // Add this state

  // Redirect to the login screen
  useEffect(() => {
    if (!isAuthenticated && !isLoading && !redirectInProgress) {
      setRedirectInProgress(true);
      loginWithRedirect();
    }
  }, [isAuthenticated, isLoading, loginWithRedirect, redirectInProgress]);


  if (isLoading) {
    return <p>Loading...</p>;
  }

  return (
    <Layout>
      <div>
        {error && <p>Authentication Error: {error.message}</p>}
      </div>
      <Routes>
        {AppRoutes.map((route, index) => {
          const { element, ...rest } = route;
          return <Route key={index} {...rest} element={element} />;
        })}
      </Routes>
    </Layout>
  );
};

export default App;