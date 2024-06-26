import React, { useContext } from "react";
import {Routes, Route} from 'react-router-dom'
import {publicRoutes} from "../routes";
import { Context } from "..";

const AppRouter = () => {
    const {user} = useContext(Context);
    
    return (
        <Routes>
            {publicRoutes.map(({path, element}) =>
                <Route key={path} path={path} element={element}/>
            )}
        </Routes>
    );
}

export default AppRouter;