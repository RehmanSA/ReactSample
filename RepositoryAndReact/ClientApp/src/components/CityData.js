import React, { Component } from 'react';

export class CityData extends Component {
    displayName = CityData.name

    constructor(props) {
        super(props);
        this.state = { cities: [], loading: true };

        fetch('api/City/CityInformations')
            .then(response => response.json())
            .then(data => {
                this.setState({ cities: data, loading: false });
            });
    }

    static renderCityTable(cities) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>City Name</th>                       
                    </tr>
                </thead>
                <tbody>
                    {cities.map(city =>
                        <tr key={city.cityId}>
                            <td>{city.cityId}</td>
                            <td>{city.cityName}</td>                          
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading ? <p><em>Loading...</em></p>: CityData.renderCityTable(this.state.cities);

        return (
            <div>
                <h1>City Information</h1>

                {contents}
            </div>
        );
    }
}
