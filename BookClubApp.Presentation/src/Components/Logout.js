import { useAuth0 } from "@auth0/auth0-react";

const Logout = () => {
    const { logout, isAuthenticated} = useAuth0();
    return (
        isAuthenticated && (
            <button onClick={() => logout() }>
                Log ud
            </button>
        )
    )
}

export default Logout