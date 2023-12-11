import { useAuth0 } from "@auth0/auth0-react";
import './Profile.css';

const Profile = () => {
    const { user, isAuthenticated} = useAuth0();
    return (
        isAuthenticated && (
            <article>
                {user?.picture && <img src={user.picture} alt={user?.name} className="profile-pic"/>}
                <h4>{user?.name}</h4>
            </article>
        )
    )
}

export default Profile