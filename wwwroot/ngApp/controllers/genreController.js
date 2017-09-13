class GenreController {
    constructor($genreService) {
        this.genreService = $genreService;
        this.genres = this.genreService.getGenres();
        this.genreDetail = null;
        this.resetMessages();
    }

    resetMessages() {
        this.showSuccess = false;
        this.showError = false;
        this.serverMessage = "";
    }

    cancel() {
        this.genreDetail = null;
        this.resetMessages();
    }

    newGenre() {
        this.genreDetail = {
            genreId: 0,
            name: null
        };
    }

    saveGenre() {
        if (this.genreDetail.genreId === 0) {
            this.genreService.addGenre(this.genreDetail, res => {
                this.serverMessage = "Record added.";
                this.showSuccess = true;
                this.genres = this.genreService.getGenres();
            }, res => {
                this.serverMessage = "An error occurred.";
                this.showError = true;
            });
        } else {
            this.genreService.updateGenre(this.genreDetail, res => {
                this.serverMessage = "Record updated.";
                this.showSuccess = true;
                this.genres = this.genreService.getGenres();
            }, res => {
                this.serverMessage = "An error occurred.";
                this.showError = true;
            });
        }
    }

    deleteGenre(id) {
        this.genreService.deleteGenre(id, res => {
            this.genres = this.genreService.getGenres();
        }, res => {
            this.genres = this.genreService.getGenres();
        });
    }

    getGenre(id) {
        this.resetMessages();
        this.genreDetail = this.genreService.getGenre(id);
    }
}