import { useAuth0 } from "@auth0/auth0-react";
import { React } from "react";
import './Profile.css';
import useAuthApi from "../hooks/useAuthApi";
import { useEffect } from "react";

const Profile = () => {
  const { user, isAuthenticated } = useAuth0();
  const api = useAuthApi();

  useEffect(() => {
    if (isAuthenticated) {
      // Replace with your own API endpoint
      api.get(`/Member/getmemberbyemail?email=${user.email}`)
        .then(response => {
          if (!response.data) {
            // User doesn't exist, save them to the database
            console.log('User variables:', user);
            const userData = {
              email: user.email,
              name: user.name,
              birthdate: user.birthdate ? user.birthdate : '2000-01-01',
             // memberships: null
            };
            console.log('User data:', userData);
            api.post('/Member/addmember', userData, { headers: { 'Content-Type': 'application/json' } })
              .then(response => console.log('User saved successfully'))
              .catch(error => console.error('Error saving user:', error));
          }
        })
        .catch(error => console.error('Error checking user:', error));
    }
  }, [api, isAuthenticated, user]);

  return (
    isAuthenticated && (
      <article>
        {user?.picture && <img src={user.picture} alt={user?.name} className="profile-pic"/>}
        <h4>{user?.name}</h4>
      </article>
    )
  )
}

export default Profile;