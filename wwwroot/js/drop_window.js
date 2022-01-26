Dropzone.autoDiscover = false;
var myDropzone = new Dropzone("div#myDrop", {
    acceptedFiles: "image/*",
    maxFiles:1,
    addRemoveLinks: true,
    init: function() {
        this.on("maxfilesexceeded", function(file){
            this.removeFile(file);            
        });
    },
    url: "#"
});