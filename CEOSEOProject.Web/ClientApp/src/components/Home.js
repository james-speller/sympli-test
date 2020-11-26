import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    constructor() {
        super();
        this.state = {
            searchEngine: 'google',
            searchTerm: '',
            resultURL: '',
            results: ''
        }

        this.handleInputChange = this.handleInputChange.bind(this);
        this.search = this.search.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;
        const name = target.name;
        const value = target.value;

        this.setState({
            [name]: value
        });
    }

    async search() {
        const response = await fetch(
            'Search?engine=' + this.state.searchEngine
            + '&term=' + this.state.searchTerm
            + '&resultUrl=' + this.state.resultURL
           );
        const data = await response.json();
        this.setState({ results: 'Search results: ' + data });
    }

    render() {
        return (
            <div>
                <h1>Hello, CEO!</h1>
                <p>Select a search engine, then enter the term you wish to search for and the URL you wish to see in the results.</p>

                <label>Search Engine: 
                    <select value={this.state.searchEngine} name="searchEngine" onChange={this.handleInputChange}>
                        <option value="google">Google</option>
                        <option value="bing">Bing</option>
                    </select>
                </label>
                <br/>

                <label>Search term: <input type="text" name="searchTerm" value={this.state.searchTerm} onChange={this.handleInputChange}/></label>
                <br />

                <label>URL to find in the results: <input type="text" name="resultURL" value={this.state.resultURL} onChange={this.handleInputChange}/></label>
                <br />

                <button className="btn btn-primary" onClick={this.search}>Search</button>
                <br/>

                <p className="search-results">{this.state.results}</p>
            </div>
        );
    }
}
