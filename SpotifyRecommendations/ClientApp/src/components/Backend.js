export const searchArtists = async (artist) => {
	const response = await fetch(`spotify/search?artist=${artist}`);
	if (!response.ok)
		return errorResponse(await response.text());
	return artistsResponse(await response.json());
}

export const searchTracks = async (track) => {
	const response = await fetch(`spotify/search?track=${track}`);
	if (!response.ok)
		return errorResponse(await response.text());
	return tracksResponse(await response.json());
}

const errorResponse = (error) => ({ error, ok: false });
const artistsResponse = (artists) => ({ artists, ok: true });
const tracksResponse = (tracks) => ({ tracks, ok: true });
