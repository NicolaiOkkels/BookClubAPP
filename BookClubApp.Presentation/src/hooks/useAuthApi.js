import { useAuth0 } from '@auth0/auth0-react';
import axios from 'axios';

const useAuthApi = () => {
  const { getAccessTokenSilently } = useAuth0();

  const apiClient = axios.create({
    baseURL: "http://localhost:5179",
  });

  const makeRequest = async (method, url, data = null, config = {}) => {
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
  };

  return {
    get: (url, config) => makeRequest('get', url, null, config),
    post: (url, data, config) => makeRequest('post', url, data, config),
    put: (url, data, config) => makeRequest('put', url, data, config),
    delete: (url, config) => makeRequest('delete', url, null, config),
  };
};

export default useAuthApi;