import logo from './logo.svg';
import './App.css';
import { useState } from 'react';

function App() {
  return (
    <div className="App">
      <InitialDisplay />
    </div>
  );
}

function InitialDisplay() {
  const [apiResponse, setApiResponse] = useState(undefined);

  fetch("http://localhost:9000/testAPI")
    .then(res => res.text())
    .then(res => setApiResponse(res));

  if (apiResponse != undefined) {
    console.log(apiResponse);
    return <p>{apiResponse}</p>;
  }
  else {
    return <p>API is not working!</p>;
  }
}

export default App;