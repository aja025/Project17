class ArtistController {
    constructor($artistService) {
        this.artistService = $artistService;
        this.artists = this.artistService.getArtists();
        this.artistDetail = null;
        this.resetMessages();
    }

    resetMessages() {
        this.showSuccess = false;
        this.showError = false;
        this.serverMessage = "";
    }

    cancel() {
        this.artistDetail = null;
        this.resetMessages();
    }

    newArtist() {
        this.artistDetail = {
            artistId: 0,
            lastName: null,
            firstName: null,
            title: null,
            reportsTo: null,
            birthDate: "2017-01-10T00:37:00.520Z",
            hireDate: "2017-01-10T00:37:00.520Z",
            address: null,
            city: null,
            state: null,
            country: null,
            postalCode: null,
            phone: null,
            fax: null,
            email: null
        };
    }

    saveArtist() {
        if (this.artistDetail.artistId === 0) {
            this.artistService.addArtist(this.artistDetail, res => {
                this.serverMessage = "Record added.";
                this.showSuccess = true;
                this.artists = this.artistService.getArtists();
            }, res => {
                this.serverMessage = "An error occurred.";
                this.showError = true;
            });
        } else {
            this.artistService.updateArtist(this.artistDetail, res => {
                this.serverMessage = "Record updated.";
                this.showSuccess = true;
                this.artists = this.artistService.getArtists();
            }, res => {
                this.serverMessage = "An error occurred.";
                this.showError = true;
            });
        }
    }

    deleteArtist(id) {
        this.artistService.deleteArtist(id, res => {
            this.artists = this.artistService.getArtists();
        }, res => {
            this.artists = this.artistService.getArtists();
        });
    }

    getArtist(id) {
        this.resetMessages();
        this.artistDetail = this.artistService.getArtist(id);
    }
}