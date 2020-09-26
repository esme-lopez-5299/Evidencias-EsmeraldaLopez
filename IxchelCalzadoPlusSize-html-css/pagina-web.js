// JavaScript source code
        (function () {
            setInterval(function () {
                var enviosbackground = document.getElementById("enviogratis"),

                    colores = ["#000000", "#632768", "#8C47D7"];

                enviosbackground.style.background = colores[Math.floor(Math.random() * colores.length)];
            }, 1000);
        }())


