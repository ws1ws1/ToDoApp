import { useContext, useEffect, useState } from "react";
import { observer } from "mobx-react-lite";
import { Context } from "..";

const Home = observer( () => {
    const {user} = useContext(Context);

    return(
        <div>Privetiki {user.user.email}</div>
    );
})

export default Home;
