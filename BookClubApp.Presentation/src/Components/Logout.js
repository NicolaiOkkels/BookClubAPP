import React from 'react';
import { useAuth0 } from '@auth0/auth0-react';

const Logout = () => {
    const { logout, isAuthenticated } = useAuth0();
    
    return (
        isAuthenticated && (
            <button onClick={() => logout()} className="button-logo-style">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round" className="feather feather-log-out">
                    <path d="M9 21H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h4"/>
                    <polyline points="16 17 21 12 16 7"/>
                    <line x1="21" y1="12" x2="9" y2="12"/>
                </svg>
            </button>
        )
    );
};

export default Logout;