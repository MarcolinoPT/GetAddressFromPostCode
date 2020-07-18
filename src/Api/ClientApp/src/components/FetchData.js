import React, { Component } from 'react';
import Postcode from 'postcode';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = {
        addresses: undefined,
        loading: false,
        postcode: undefined,
        housenumber: undefined,
        searchHistory: []
     };
    this.handleHouseNumberChange = this.handleHouseNumberChange.bind(this);
    this.handlePostCodeChange = this.handlePostCodeChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  static renderResultsTable(addresses, searchHistory) {
    if(!addresses || !addresses.addresses){
      return(<div></div>)
    }
    if(addresses.addresses.length === 0){
      return (
      <div>
        <br></br>
        <span>No results!</span>
      </div>
        );
    }
    return (
      <div>
        <br></br>
        <h3>Search history</h3>
        <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Post code</th>
              <th>House number</th>
            </tr>
          </thead>
          <tbody>
            {searchHistory && searchHistory.map((search, index) =>
              <tr key={index}>
                <td>{search.postcode}</td>
                <td>{search.housenumber}</td>
              </tr>
            )}
          </tbody>
        </table>
        <br></br>
        <h3>Search results</h3>
        <span>Distance: {addresses.distanceInKm.toFixed(2)} Km or {addresses.distanceInMiles.toFixed(2)} Miles</span>
        <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Addresses</th>
              <th>Locality</th>
              <th>Town/City</th>
              <th>County</th>
            </tr>
          </thead>
          <tbody>
            {addresses.addresses && addresses.addresses.map((address, index) =>
              <tr key={index}>
                <td>{address.line1 + address.line2 + address.line3 + address.line4}</td>
                <td>{address.locality}</td>
                <td>{address.townOrCity}</td>
                <td>{address.county}</td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    );
  }

  handlePostCodeChange(event){
    const postCode =  Postcode.isValid(event.target.value)
    ? event.target.value
    : undefined;
    this.setState({ postcode: postCode });
  }

  handleHouseNumberChange(event){
    this.setState({ housenumber: event.target.value });
  }

  handleSubmit(event){
    // Prevent page reload
    event.preventDefault();
    // Update history search
    let { searchHistory } = this.state;
    // Push new search
    searchHistory.push({ postcode: this.state.postcode, housenumber: this.state.housenumber});
    // Filter search history and save to state
    searchHistory = searchHistory.length > 3 ? searchHistory.slice(1, 4) : searchHistory;
    // Reverse to show latest 1st
    searchHistory.reverse();
    this.setState({ loading: true, searchHistory: searchHistory});
    this.submitSearch();
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderResultsTable(this.state.addresses, this.state.searchHistory);

    return (
      <div>
        <h2 id="tabelLabel" >Find customer address</h2>
        <form onSubmit={this.handleSubmit}>
            <div>
              <label>Post code</label>
              <input type="text" onChange={this.handlePostCodeChange} />
              <label>House number (optional)</label>
              <input type="text" onChange={this.handleHouseNumberChange} />
              <input type="submit" value="Search" disabled={!this.state.postcode}/>
            </div>
        </form>
      <div>
          {contents}
      </div>
      </div>
    );
  }

  async submitSearch(){
    const { postcode, housenumber } = this.state;
    const uri = `address?postcode=${postcode}` + (housenumber ? `&housenumber=${housenumber}` : "") ;
    const response = await fetch(uri);
    const data = await response.json();
    this.setState({ addresses: data, loading: false})
  }
}
