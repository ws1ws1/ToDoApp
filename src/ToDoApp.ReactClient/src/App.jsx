import { BrowserRouter } from 'react-router-dom';
import AppRouter from './components/AppRouter';
import { useContext, useEffect } from 'react';
import { Context } from './main';
import { getCurrentUser } from './http/userAPI';

function App() {
    const { user } = useContext(Context);

    useEffect(() => {
        getCurrentUser().then(data => {
            user.setUser(data);
            user.setIsAuth(true);
            console.log('app');
            console.log(data);
        })
    }, []);

  return (
      <div >
          <BrowserRouter>
              <AppRouter />
          </BrowserRouter>
      </div>
  )
}

export default App
