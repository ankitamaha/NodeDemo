
const xhr = {
  post(url, data) {
    let xhr = new XMLHttpRequest();
    return new Promise((resolve, reject) => {
      xhr.open('POST', url);
      xhr.setRequestHeader('Content-Type', 'application/json');
      xhr.setRequestHeader('Accept', 'application/json');
      xhr.onreadystatechange = () => {
        if (xhr.readyState == XMLHttpRequest.DONE) {
          if (xhr.status >= 200 && xhr.status < 300) {
            resolve(xhr.responseText);
          } else {
            reject(xhr.responseText);
          }
        }
      };
      xhr.send(JSON.stringify(data));
    });
  },

  get(url) {
    let xhr = new XMLHttpRequest();
    return new Promise((resolve, reject) => {
      xhr.open('GET', encodeURI(url));
      xhr.onreadystatechange = () => {
        if (xhr.readyState == XMLHttpRequest.DONE) {
          if (xhr.status === 200) {
            resolve(xhr.responseText);
          } else {
            reject(xhr.responseText);
          }
        }
      };
      xhr.send();
    });
  }
};

export default xhr;
