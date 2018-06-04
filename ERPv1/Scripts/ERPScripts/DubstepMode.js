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

            var randEl = document.getElementsByTagName("*");

            var randomNumber = Math.floor(Math.random() * randEl.length);

            randEl = randEl[randomNumber];

            var rand1 = Math.floor(Math.random() * 255);
            var rand2 = Math.floor(Math.random() * 255);
            var rand3 = Math.floor(Math.random() * 255);

            try {
                var style = randEl.getAttribute("style");

                var pattern = /background-color:rgb\\([0-9]{1,3},[0-9]{1,3},[0-9]{1,3}\\)/g;

                if (pattern.test(style)) {

                    style = style.replace(pattern, "background-color:rgb(" + rand1 + "," + rand2 + "," + rand3 + ")");

                    randEl.setAttribute("style", style);

                } else {
                    randEl.setAttribute("style", style + ";background-color:rgb(" + rand1 + "," + rand2 + "," + rand3 + ")");
                }

            } catch (e) {
            }

        }
    }, 5);

});