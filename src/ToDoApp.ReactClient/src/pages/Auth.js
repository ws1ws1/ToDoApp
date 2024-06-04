import React, { useContext, useEffect, useState } from 'react';
import { NavLink, useLocation, useNavigate } from 'react-router-dom';
import { HOME_ROUTE, LOGIN_ROUTE, REGISTRATION_ROUTE } from '../utils/consts';
import { registration } from '../http/userAPI';
import { observer } from 'mobx-react-lite';
import { Context } from '..';

const Auth = observer( () => {
    const {user} = useContext(Context);

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    useEffect(() => {
        if (user.isAuth)
            navigate(HOME_ROUTE);
    }, [user.isAuth]);

    const navigate = useNavigate();

    const currentLocation = useLocation();
    const isLoginPage = currentLocation.pathname === LOGIN_ROUTE;

    const signUp = async () => {
        try {
            const response = await registration(email, password);

            user.setIsAuth(true);
            user.setUser(response);

            navigate(HOME_ROUTE); 
        }
        catch(e) {
            alert(e.response.data.message);
        }
    }

    return (
            <section className="bg-light vh-100">
                <div className="container py-5 h-100">
                    <div className="row d-flex justify-content-center align-items-center h-100">
                        <div className="col-12 col-md-8 col-lg-6 col-xl-5">
                            <div className="card shadow-2-strong rounded-3">
                                <div className="card-body p-5 text-center">
                                    {
                                        isLoginPage ? 
                                            <h3 className="mb-5">Sign in</h3>
                                        :
                                            <h3 className="mb-5">Sign up</h3>
                                    }                                    

                                    <div className="form-outline mb-4">
                                        <label className="form-label" htmlFor="typeEmailX">Email:</label>
                                        <input type="email" className="form-control form-control-lg" value={email} onChange={e => setEmail(e.target.value)} />
                                    </div>
                                    
                                    <div className="form-outline mb-4">
                                        <label className="form-label" htmlFor="typePasswordX">Password:</label>
                                        <input type="password" className="form-control form-control-lg" value={password} onChange={e => setPassword(e.target.value)} />
                                    </div>

                                    {
                                        isLoginPage ? 
                                            <NavLink to={REGISTRATION_ROUTE}>Registration</NavLink>
                                        :
                                            <NavLink to={LOGIN_ROUTE}>Authorization</NavLink>
                                    }
                                    {
                                        isLoginPage ?
                                            <button className="form-control btn btn-primary btn-lg mb-5" onClick={signUp}>Log in</button>
                                        :
                                            <button className="form-control btn btn-primary btn-lg mb-5" onClick={signUp}>Sign up</button>
                                    }
                                </div>
                            </div>                        
                        </div>
                    </div>
                </div>
            </section>
    );
})

export default Auth;

/*
                                    <button className="form-control btn btn-primary btn-lg" onClick={onGetCurrentUser}>Get</button>
*/