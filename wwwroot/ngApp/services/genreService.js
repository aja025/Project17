class GenreService {
    constructor($resource) {
        this.genreResource = $resource("/api/genre/:id", null, { 'update': { method:'PUT' } });
    }

    getGenres() {
        return this.genreResource.query();
    }

    getGenre(id) {
        return this.genreResource.get({ id: id });
    }

    addGenre(genre, success, error) {
        this.genreResource.save(genre, success, error);
    }

    updateGenre(genre, success, error) {
        this.genreResource.update({ id: genre.genreId }, genre, success, error);
    }

    deleteGenre(id, success, error) {
        this.genreResource.delete({ id: id }, success, error);
    }
}
