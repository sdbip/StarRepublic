import React, { useState } from 'react';
import { DropdownItem, DropdownMenu, DropdownToggle, ToastBody, ToastHeader, Jumbotron, Card, CardBody } from 'reactstrap';
import { ListGroup, ListGroupItem } from 'reactstrap';
import { Input, InputGroup, InputGroupButtonDropdown } from 'reactstrap';
import { Button, Fade, Form, Label, Toast } from 'reactstrap';
import { searchArtists, searchTracks } from './Backend'

const sampleArtists = [
	'Bon Jovi',
	'Bonnie Tyler',
	'Eric Clapton',
	'Janis Joplin',
	'Whitesnake'
];

const sampleTracks = [
	'Born to Run',
	'Highway to Hell',
	'Total Eclipse of the Heart'
];

export const Home = () => {
	const [dropdownOpen, setDropdownOpen] = useState(false);
	const [resultsVisible, setResultsVisible] = useState(false);
	const [searchTerm, setSearchTerm] = useState("");
	const [searchResults, setSearchResults] = useState([]);
	const [errorMessage, setErrorMessage] = useState(null);

	const toggleDropDown = () => {
		setDropdownOpen(!dropdownOpen);
	};

	const search = async () => {
		setErrorMessage(null);
		setResultsVisible(false);
		var result = await searchTracks(searchTerm);
		if (result.ok) {
			setSearchResults(result.tracks);
			setResultsVisible(true);
		} else {
			setErrorMessage(result.error);
		}
	};

	return (
		<Form>
			<InputGroup>
				<Label for="search-term">Search for...</Label>
				<Input type="text" name="searchTerm" id="search-term" value={searchTerm} onChange={(event) => setSearchTerm(event.target.value)} />
				<InputGroupButtonDropdown addonType="append" isOpen={dropdownOpen} toggle={toggleDropDown}>
					<DropdownToggle caret>
						Sample searches
					</DropdownToggle>
					<DropdownMenu>{sampleTracks.map(name =>
						<DropdownItem key={name} onClick={() => setSearchTerm(name)}>{name}</DropdownItem>)}
					</DropdownMenu>
				</InputGroupButtonDropdown>
			</InputGroup>
			<Button color="primary" onClick={search}>Search</Button>
			<Fade in={!resultsVisible} tag="h5" className="mt-3">
				Search for your favourite artists and they will appear here.
			</Fade>
			<Fade in={resultsVisible} tag="h5" className="mt-3">
				<ListGroup>{searchResults.map(artist =>
					<ListGroupItem key={artist}>{artist}</ListGroupItem>)}
				</ListGroup>
			</Fade>
			<Fade in={errorMessage != null} tag="h5" className="mt-3">
				<Card body inverse color="danger">
					<CardBody>{errorMessage || ''}</CardBody>
				</Card>
			</Fade>
		</Form>
	);
}
