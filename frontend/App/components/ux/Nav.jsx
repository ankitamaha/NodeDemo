import React from 'react';

class Nav extends React.Component {
  render() {
    return (
      <nav className="navbar navbar-default">
        <div className="container-fluid">
          <div className="navbar-header">
            <a className="navbar-brand" href="#">{this.props.appTitle}</a>
          </div>
        </div>
      </nav>
    );
  }
}

export default Nav;
