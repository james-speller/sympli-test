import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, CEO!</h1>
            <p>Select a search engine, then enter the term you wish to search for and the URL you wish to see in the results.</p>

      </div>
    );
  }
}
