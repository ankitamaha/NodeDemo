import React from 'react';
import xhr from './../../services/xhr';
import ProfileCard from './ProfileCard';
import CreateProfileButton from './CreateProfileButton';
import AddProfile from './AddProfile';

class ProfileWall extends React.Component {
  constructor(props) {
    super(props);

    this.state = { profiles: [] };
  }

  addProfile(profile) {
    this.setState({
      profiles: this.state.profiles.concat([profile])
    });
  }

  componentDidMount() {
    xhr.get('/api/profiles')
      .then((txt) => JSON.parse(txt))
      .then((json) => {
        this.setState({ profiles: json });
      });
  }

  renderPanel(profile, idx) {
    return (
      <ProfileCard {...profile} />
    );
  }

  render() {
    return (
      <section className="row">
        <div className="row">
          <div className="col-md-12">
            {this.state.profiles.map(this.renderPanel)}
          </div>
        </div>
        <div className="row">
          <div className="col-md-12">
            <AddProfile onProfileAdded={this.addProfile.bind(this)}/>
          </div>
        </div>
      </section>
    );
  }
}

export default ProfileWall;
