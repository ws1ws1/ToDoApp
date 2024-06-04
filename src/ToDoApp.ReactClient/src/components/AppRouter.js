import React, { useContext } from "react";
import {Routes, Route, Redirect} from 'react-router-dom'
import {publicRoutes} from "../routes";
import { Context } from "..";

const AppRouter = () => {
    const {user} = useContext(Context);
    console.log(user);
    return (
        <Routes>
            {publicRoutes.map(({path, element}) =>
                <Route key={path} path={path} element={element}/>
            )}
        </Routes>
    );
}


export default AppRouter;

/*
            <Route path={LOGIN_ROUTE} Component={Auth} />
            <Route path={REGISTRATION_ROUTE} Component={Auth} />
            <Route path={HOME_ROUTE} Component={Home} />
*/
/*
            {publicRoutes.map(({path, element}) =>
                <Route key={path} path={path} element={<element />}/>
            )}
*/