function toggleDubstepMode() {

    var soundControl = $("#dubstepControl")[0];

    if (soundControl.paused) {
        soundControl.play();
    } else {
        location.reload();
    }
}

$(document).ready(function () {

    var soundControl = $("#dubstepControl")[0];

    setInterval(function () {
        if (!soundControl.paused) {

            var randEl = $("*");
            var randomNumber = Math.floor(Math.random() * randEl.length);

            randEl = randEl[randomNumber];

            var rand1 = Math.floor(Math.random() * 255);
            var rand2 = Math.floor(Math.random() * 255);
            var rand3 = Math.floor(Math.random() * 255);

            try {
                randEl.setAttribute("style", "background-color:rgb(" + rand1 + "," + rand2 + "," + rand3 + ")");
            } catch (e) {

            } 
          
        }
    }, 5);

});