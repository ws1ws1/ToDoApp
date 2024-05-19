import React, { createContext } from 'react';
import ReactDOM from 'react-dom/client';
import 'bootstrap/dist/css/bootstrap.min.css';
import App from './App.jsx';
import UserStore from './store/UserStore';

export const Context = createContext(null);

ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <Context.Provider value={{ user: new UserStore }}>
            <App />
        </Context.Provider>
  </React.StrictMode>
)
