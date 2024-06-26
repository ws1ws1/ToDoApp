import { useContext, useEffect, useState } from "react";
import { observer } from "mobx-react-lite";
import { Context } from "..";
import { useNavigate } from "react-router-dom";
import { LOGIN_ROUTE } from '../utils/consts';

const Home = observer( () => {
    const {user} = useContext(Context);
    const navigate = useNavigate();

    useEffect(() => {
        if (!user.isAuth)            
            navigate(LOGIN_ROUTE);
    }, [user.isAuth]);

    return(
        <div>Privetiki {user.user.email}</div>
    );
})

export default Home;
