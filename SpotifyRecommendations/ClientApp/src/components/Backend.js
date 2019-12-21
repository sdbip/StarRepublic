export const searchArtists = async (artist) => {
	const response = await fetch(`spotify/search?searchTerm=${artist}`);
	if (!response.ok)
		throw new Error(await response.text())
	return await response.json();
}
