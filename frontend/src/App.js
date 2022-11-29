import logo from './logo.svg';
import './App.css';
import axios from "axios";

let hello = ""

function getHello(){
  axios.get('/hello').then(res => window.alert(res.data))
}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <button onClick={getHello}>Default</button>;
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
