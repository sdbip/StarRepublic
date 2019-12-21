import React, { useState } from 'react';
import { Button, DropdownItem, DropdownMenu, DropdownToggle, Fade, Form, Input, InputGroup, InputGroupButtonDropdown, Label, ListGroup, ListGroupItem } from 'reactstrap';

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

	const toggleDropDown = () => {
		setDropdownOpen(!dropdownOpen);
	};

	const search = () => {
		setResultsVisible(true);
	};

	return (
		<Form>
			<InputGroup>
				<Label for="search-term">Search for...</Label>
				<Input type="text" name="searchTerm" id="search-term" value={searchTerm} />
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
				<ListGroup>{sampleArtists.map(artist =>
					<ListGroupItem>{artist}</ListGroupItem>)}
				</ListGroup>
			</Fade>
		</Form>
	);
}
