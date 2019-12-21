export const searchArtists = async (artist) => {
	const response = await fetch(`spotify/search?searchTerm=${artist}`);
	if (!response.ok)
		return errorResponse(await response.text());
	return artistsResponse(await response.json());
}

const errorResponse = (error) => ({ error, ok: false });
const artistsResponse = (artists) => ({ artists, ok: true });
