import logo from './logo.svg';
import './App.css';
import { useState } from 'react';

function App() {

  const [apiResponse, setApiResponse] = useState('');

  fetch("http://localhost:9000/testAPI")
    .then(res => res.text())
    .then(res => setApiResponse(res));

  return (
    <div className="App">
        <p>
          {apiResponse}
        </p>
    </div>
  );
}

export default App;