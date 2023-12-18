import React, { createContext, useContext, useEffect, useState } from 'react';
import useAuthApi from '../hooks/useAuthApi';

const CsrfTokenContext = createContext();

export function useCsrfToken() {
  return useContext(CsrfTokenContext);
}

export function CsrfTokenProvider({ children }) {
  const api = useAuthApi();
  const [csrfToken, setCsrfToken] = useState(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    let isMounted = true;

    const fetchToken = async () => {
      if (!isMounted) return;

      try {
        const token = await api.fetchCsrfToken();
        if (isMounted) {
          setCsrfToken(token);
          setIsLoading(false);
        }
      } catch (error) {
        console.error('Error fetching CSRF token:', error);
      }
    };

    if (!csrfToken) {
      fetchToken();
    }

    return () => {
      isMounted = false;
    };
  }, []);

  return (
    <CsrfTokenContext.Provider value={{ csrfToken, isLoading }}>
      {children}
    </CsrfTokenContext.Provider>
  );
}