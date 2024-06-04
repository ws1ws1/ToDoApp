import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { LOGIN_ROUTE } from "../utils/consts";

const Home = () => {
    const [userEmail, setUserEmail] = useState('');
    const navigate = useNavigate();

    useEffect(() => {
        const getCurrentUser =  async () => {
            const response = await fetch('https://localhost:50858/api/User/Get', {
                method: 'GET',
                credentials: 'include'
            });
            const data = await response.json();
            console.log(data);
            if (data.status == '401')
                navigate(LOGIN_ROUTE);
            else
                setUserEmail(data.email);
        };
        getCurrentUser();
    }, []);

    return(
        <div>Privetiki {userEmail}</div>
    );
}

export default Home;