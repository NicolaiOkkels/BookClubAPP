import { useAuth0 } from '@auth0/auth0-react';
import axios from 'axios';
import { useMemo, useCallback } from 'react';

const apiUrl = process.env.REACT_APP_API_URL;

const useAuthApi = () => {
  const { getAccessTokenSilently } = useAuth0();

  const apiClient = useMemo(() => axios.create({
    baseURL: apiUrl,
  }), []);

  const makeRequest = useCallback(async (method, url, data = null, config = {}) => {
    const token = await getAccessTokenSilently({ audience: "https://api.bookclub.com" });
    return apiClient({
      method,
      url,
      data,
      ...config,
      headers: {
        ...config.headers,
        Authorization: `Bearer ${token}`,
      },
    });
  }, [getAccessTokenSilently, apiClient]);

  return useMemo(() => ({
    get: (url, config) => makeRequest('get', url, null, config),
    post: (url, data, config) => makeRequest('post', url, data, config),
    put: (url, data, config) => makeRequest('put', url, data, config),
    delete: (url, config) => makeRequest('delete', url, null, config),
  }), [makeRequest]);
};

export default useAuthApi;