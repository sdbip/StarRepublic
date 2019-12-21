import React, { useState } from 'react';
import { DropdownItem, DropdownMenu, DropdownToggle, Input, InputGroup, InputGroupButtonDropdown, Label } from 'reactstrap';

const sampleArtists = [
	'Bon Jovi',
	'Bonnie Tyler',
	'Eric Clapton',
	'Janis Joplin',
	'Whitesnake'
];

export const Home = () => {
	const [dropdownOpen, setDropdownOpen] = useState(false);
	const [searchTerm, setSearchTerm] = useState("");

	const toggle = () => {
		setDropdownOpen(!dropdownOpen);
	}

	return (
		<InputGroup>
			<Label for="search-term">Search for...</Label>
			<Input type="text" name="searchTerm" id="search-term" value={searchTerm} />
			<InputGroupButtonDropdown addonType="append" isOpen={dropdownOpen} toggle={toggle}>
				<DropdownToggle caret>
					Sample searches
				</DropdownToggle>
				<DropdownMenu>{sampleArtists.map(name =>
					<DropdownItem onClick={() => setSearchTerm(name)}>{name}</DropdownItem>)}
				</DropdownMenu>
			</InputGroupButtonDropdown>
		</InputGroup>
	);
}
