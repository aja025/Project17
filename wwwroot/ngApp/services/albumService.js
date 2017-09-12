class AlbumService {
    constructor($resource) {
        this.albumResource = $resource("/api/albums/:id", null, { 'update': { method:'PUT' } });
    }

    getAlbums() {
        return this.albumResource.query();
    }

    getAlbum(id) {
        return this.albumResource.get({ id: id });
    }

    addAlbum(album, success, error) {
        this.albumResource.save(album, success, error);
    }

    updateAlbum(album, success, error) {
        this.albumResource.update({ id: album.albumId }, album, success, error);
    }

    deleteAlbum(id, success, error) {
        this.albumResource.delete({ id: id }, success, error);
    }
}
