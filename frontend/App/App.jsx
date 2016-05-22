import React from 'react';
import Nav from './components/ux/Nav';
import ProfileWall from './components/profiles/ProfileWall';

class App extends React.Component {
  render() {
    return (
      <div>
        <Nav appTitle="App" />
        <div className="container-fluid">
          <div className="row">
            <div className="col-md-12">
              <h1>Welcome.</h1>
            </div>
          </div>
          <div className="container">
            <ProfileWall />
          </div>
        </div>
      </div>
    );
  }
}

export default App;
