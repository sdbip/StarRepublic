export const searchArtists = async (artist) => {
	const response = await fetch(`spotify/search?searchTerm=${artist}`);
	return await response.json();
}
