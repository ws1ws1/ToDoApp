import { useContext } from "react";
import { observer } from "mobx-react-lite";
import { Context } from "../main";

const Home = observer(() => {
    const { user } = useContext(Context);

    return (
        <div>Privetiki {user.user.email}</div>
    );
})

export default Home;