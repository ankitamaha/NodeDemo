import React from 'react';

class CreateProfileButton extends React.Component {
  handleClickEvent(event) {
    this.props.onClick(event);
  }

  render() {
    return (
      <button className="btn btn-primary" onClick={this.handleClickEvent.bind(this)}>
        Add Profile
      </button>
    );
  }
}

export default CreateProfileButton;
