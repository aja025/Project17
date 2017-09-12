class AlbumController {
    constructor($albumService) {
        this.albumService = $albumService;
        this.albums = this.albumService.getAlbums();
        this.albumDetail = null;
        this.resetMessages();
    }

    resetMessages() {
        this.showSuccess = false;
        this.showError = false;
        this.serverMessage = "";
    }

    cancel() {
        this.albumDetail = null;
        this.resetMessages();
    }

    newAlbum() {
        this.albumDetail = {
            albumId: 0,
            title: null,
            artistId: null,
            phone: null,
            fax: null,
            email: null
        };
    }

    saveAlbum() {
        if (this.albumDetail.albumId === 0) {
            this.albumService.addAlbum(this.albumDetail, res => {
                this.serverMessage = "Record added.";
                this.showSuccess = true;
                this.albums = this.albumService.getAlbums();
            }, res => {
                this.serverMessage = "An error occurred.";
                this.showError = true;
            });
        } else {
            this.albumService.updateAlbum(this.albumDetail, res => {
                this.serverMessage = "Record updated.";
                this.showSuccess = true;
                this.albums = this.albumService.getAlbums();
            }, res => {
                this.serverMessage = "An error occurred.";
                this.showError = true;
            });
        }
    }

    deleteAlbum(id) {
        this.albumService.deleteAlbum(id, res => {
            this.albums = this.albumService.getAlbums();
        }, res => {
            this.albums = this.albumService.getAlbums();
        });
    }

    getAlbum(id) {
        this.resetMessages();
        this.albumDetail = this.albumService.getAlbum(id);
    }
}