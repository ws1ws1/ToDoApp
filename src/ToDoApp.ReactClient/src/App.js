import { BrowserRouter } from 'react-router-dom';
import './App.css';
import AppRouter from './components/AppRouter';
import { useContext, useEffect } from 'react';
import { Context } from '.';
import { getCurrentUser } from './http/userAPI';

function App() {
  const {user} = useContext(Context);

  useEffect( () => {
    getCurrentUser().then(data => {
      if (data !== null){
        user.setUser(data);
        user.setIsAuth(true);
      }
    })
  }, []);

  return (
    <div className="App">
      <BrowserRouter>
        <AppRouter />
      </BrowserRouter>
    </div>
  );
}

export default App;
