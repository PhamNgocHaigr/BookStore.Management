(function () {

    document.getElementById('Avatar').onchange = function () {
        const input = document.getElementById('Avatar').files[0];

        if (input) {
            document.getElementById('img-avatar').src = URL.createObjectURL(input);
        }
    }




})();