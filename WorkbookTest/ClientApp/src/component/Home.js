import React, { useState } from 'react';

const Home = (props) => {
  const [currentCount, setCurrentCount] = useState(0);
  
  const retrieveCountersDev = (e) => {
    fetch('api/Excel')
      .then(response => response.json())
      .then(data => {
        setCurrentCount(data);
      });
  }
  
  const retrieveCountersEPPlus = (e) => {
    fetch('api/Excel/EPPlus')
      .then(response => response.json())
      .then(data => {
        setCurrentCount(data);
      });
  }

  return (
    <div>
      <h1>Counter</h1>

      <p>Retrieves how many sheets the spreadsheet has.</p>

      <p>Count: <strong>{currentCount}</strong></p>

      <button className="btn btn-primary" onClick={retrieveCountersDev}>Count (DevExpress.Spreadsheet)</button>
      <button className="btn btn-primary" onClick={retrieveCountersEPPlus}>Count (EPPlus)</button>
    </div>
  );
}

export default Home;