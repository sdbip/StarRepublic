import React, { useState } from 'react';
import { DropdownItem, DropdownMenu, DropdownToggle } from 'reactstrap';
import { ListGroup, ListGroupItem } from 'reactstrap';
import { Input, InputGroup, InputGroupButtonDropdown } from 'reactstrap';
import { Button, Fade, Form, Label } from 'reactstrap';
import { searchArtists } from './Backend'

const sampleArtists = [
	'Bon Jovi',
	'Bonnie Tyler',
	'Eric Clapton',
	'Janis Joplin',
	'Whitesnake'
];

export const Home = () => {
	const [dropdownOpen, setDropdownOpen] = useState(false);
	const [resultsVisible, setResultsVisible] = useState(false);
	const [searchTerm, setSearchTerm] = useState("");
	const [searchResults, setSearchResults] = useState([]);

	const toggleDropDown = () => {
		setDropdownOpen(!dropdownOpen);
	};

	const search = async () => {
		setResultsVisible(false);
		var result = await searchArtists(searchTerm);
		setSearchResults(result);
		setResultsVisible(true);
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
					<DropdownMenu>{sampleArtists.map(name =>
						<DropdownItem onClick={() => setSearchTerm(name)}>{name}</DropdownItem>)}
					</DropdownMenu>
				</InputGroupButtonDropdown>
			</InputGroup>
			<Button color="primary" onClick={search}>Search</Button>
			<Fade in={!resultsVisible} tag="h5" className="mt-3">
				Search for your favourite artists and they will appear here.
			</Fade>
			<Fade in={resultsVisible} tag="h5" className="mt-3">
				<ListGroup>{searchResults.map(artist =>
					<ListGroupItem>{artist}</ListGroupItem>)}
				</ListGroup>
			</Fade>
		</Form>
	);
}
