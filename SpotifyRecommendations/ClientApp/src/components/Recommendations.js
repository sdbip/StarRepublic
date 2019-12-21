import React, { Component } from 'react';
import { Spinner, Fade, ListGroup, ListGroupItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

export class Recommendations extends Component {
	static displayName = Recommendations.name;

	constructor(props) {
		super(props);
		this.query = props.location.search
			.substr(1)
			.split("&")
			.map(pair => pair.split("="))
			.reduce((memo, p) => ({...memo, [p[0]]: p[1] }), {})

		this.state = { recommendations: [], loading: true };
	}

	componentDidMount() {
		this.loadRecommendations(this.query);
	}

	render() {
		return (
			<div>
				<h1>Recommendations</h1>
				<Fade in={this.state.loading} tag="h5" className="mt-3">
					Loading ...
				</Fade>
				<Fade in={!this.state.loading} tag="h5" className="mt-3">
					<ListGroup>
						{this.state.recommendations.map(item =>
							<ListGroupItem key={item.id} title={item.id} onClick={() => this.loadRecommendations({ seed: item.id, type: item.type })}>
								{item.name}
							</ListGroupItem>
						)}
					</ListGroup>
				</Fade>
			</div>
		);
	}

	async loadRecommendations(query) {
		this.state = { recommendations: [], loading: true };
		const response = await fetch(`spotify/make-recommendations?type=${query.type}&seed=${query.seed}`);
		const data = await response.json();
		this.setState({ recommendations: data, loading: false });
	}
}
