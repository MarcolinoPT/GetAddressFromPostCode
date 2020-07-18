import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = {
        addresses: undefined,
        loading: false,
        postcode: undefined,
        housenumber: undefined
     };
    this.handleHouseNumberChange = this.handleHouseNumberChange.bind(this);
    this.handlePostCodeChange = this.handlePostCodeChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  static renderResultsTable(addresses) {
    if(!addresses || !addresses.addresses || addresses.addresses.length === 0){
      return (
      <div>
        <span>No results!</span>
      </div>
        );
    }
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Distance: <span>{addresses.distanceInKm} Km or {addresses.distanceInMiles} Miles</span></th>
          </tr>
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
    );
  }

  handlePostCodeChange(event){
    this.setState({ postcode: event.target.value });
  }

  handleHouseNumberChange(event){
    this.setState({ housenumber: event.target.value });
  }

  handleSubmit(event){
    this.setState({ loading: true});
    console.log(this.state);
    event.preventDefault();
    this.submitSearch();
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderResultsTable(this.state.addresses);

    return (
      <div>
        <form onSubmit={this.handleSubmit}>
            <h1 id="tabelLabel" >Find customer address</h1>
            <div>
              <label>Post code</label>
              <input type="text" onChange={this.handlePostCodeChange} />
            </div>
            <div>
              <label>House number</label>
              <input type="text" onChange={this.handleHouseNumberChange} />
            </div>
            <input type="submit" value="Search" />
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
    console.log(response);
    const data = await response.json();
    this.setState({ addresses: data, loading: false})
    console.log(this.state);
  }
}
