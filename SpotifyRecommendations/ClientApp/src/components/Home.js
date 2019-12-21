import React, { useState } from 'react';
import { DropdownItem, DropdownMenu, DropdownToggle, Input, InputGroup, InputGroupButtonDropdown, Label } from 'reactstrap';

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
				<DropdownMenu>
					<DropdownItem onClick={() => setSearchTerm('Bon Jovi')}>Bon Jovi</DropdownItem>
					<DropdownItem onClick={() => setSearchTerm('Bonnie Tyler')}>Bonnie Tyler</DropdownItem>
					<DropdownItem onClick={() => setSearchTerm('Eric Clapton')}>Eric Clapton</DropdownItem>
					<DropdownItem onClick={() => setSearchTerm('Janis Joplin')}>Janis Joplin</DropdownItem>
					<DropdownItem onClick={() => setSearchTerm('Whitesnake')}>Whitesnake</DropdownItem>
				</DropdownMenu>
			</InputGroupButtonDropdown>
		</InputGroup>
	);
}
