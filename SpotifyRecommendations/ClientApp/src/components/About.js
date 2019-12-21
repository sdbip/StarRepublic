import React, { Component } from 'react';

export class About extends Component {
  static displayName = About.name;

  render () {
    return (
      <div>
        <h1>About Spotify Recommendations</h1>
        <p>This is a single-page application, built with:</p>
        <ul>
          <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
          <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
          <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling (well it's part of the template, why simple CSS isn't enough is beyond me.)</li>
        </ul>
      </div>
    );
  }
}
