import Auth from "./pages/Auth";
import Home from "./pages/Home";

import { HOME_ROUTE, LOGIN_ROUTE, REGISTRATION_ROUTE } from "./utils/consts";


export const publicRoutes = [
    {
        path: LOGIN_ROUTE,
        element: <Auth />
    },
    {
        path: REGISTRATION_ROUTE,
        element: <Auth />
    },
    {
        path: HOME_ROUTE,
        element: <Home />
    }
]