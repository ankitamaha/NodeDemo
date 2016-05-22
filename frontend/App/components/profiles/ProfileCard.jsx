import React from 'react';

class ProfileCard extends React.Component {
  render() {
    return (
      <div className="col-md-3" key={this.props.Id}>
        <div className="panel panel-default">
          <div className="panel-body">
            <img src={this.props.AvatarURL} style={{ maxWidth: '100%' }}/>
          </div>
          <div className="panel-footer">
            {this.props.FirstName}&nbsp;{this.props.LastName}
          </div>
        </div>
      </div>
    );
  }
}

export default ProfileCard;
