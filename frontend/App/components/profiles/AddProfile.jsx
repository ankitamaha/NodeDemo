import React from 'react';
import xhr from './../../services/xhr';

class AddProfile extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      FirstName: '',
      LastName: '',
      Company: '',
      AvatarURL: ''
    };
  }
  handleAddProfileEvent(event) {
    xhr.post('/api/profiles', this.state)
      .then(() => this.props.onProfileAdded(this.state))
      .then(() => this.setState({}));
  }

  handleFirstNameChange(event) {
    this.setState({FirstName: event.target.value});
  }

  handleLastNameChange(event) {
    this.setState({LastName: event.target.value});
  }

  handleCompanyChange(event) {
    this.setState({Company: event.target.value});
  }

  handleAvatarURLChange(event) {
    this.setState({AvatarURL: event.target.value});
  }

  render() {
    return (
      <form>
        <div className="form-group col-md-6">
          <label for="FirstName">First Name</label>
          <input
            type="text"
            className="form-control"
            id="FirstName"
            placeholder="First Name"
            value={this.state.FirstName}
            onChange={this.handleFirstNameChange.bind(this)} />
        </div>
        <div className="form-group col-md-6">
          <label for="LastName">Last Name</label>
          <input
            type="text"
            className="form-control"
            id="LastName"
            placeholder="Last Name"
            value={this.state.LastName}
            onChange={this.handleLastNameChange.bind(this)} />
        </div>
        <div className="form-group col-md-12">
          <label for="AvatarURL">Avatar URL</label>
          <input
            type="text"
            className="form-control"
            id="AvatarURL"
            placeholder="Avatar URL"
            value={this.state.AvatarURL}
            onChange={this.handleAvatarURLChange.bind(this)} />
        </div>
        <div className="form-group col-md-12">
          <label for="Company">Company Name</label>
          <input
            type="text"
            className="form-control"
            id="Company"
            placeholder="Company Name"
            value={this.state.Company}
            onChange={this.handleCompanyChange.bind(this)} />
        </div>
        <button
          type="button"
          className="btn btn-default"
          onClick={this.handleAddProfileEvent.bind(this)}>Add Profile</button>
      </form>
    );
  }
}

export default AddProfile;
