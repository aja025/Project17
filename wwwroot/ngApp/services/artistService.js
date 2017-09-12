class ArtistService {
    constructor($resource) {
        this.artistResource = $resource("/api/artists/:id", null, { 'update': { method:'PUT' } });
    }

    getArtists() {
        return this.artistResource.query();
    }

    getArtist(id) {
        return this.artistResource.get({ id: id });
    }

    addArtist(artist, success, error) {
        this.artistResource.save(artist, success, error);
    }

    updateArtist(artist, success, error) {
        this.artistResource.update({ id: artist.artistId }, artist, success, error);
    }

    deleteArtist(id, success, error) {
        this.artistResource.delete({ id: id }, success, error);
    }
}
