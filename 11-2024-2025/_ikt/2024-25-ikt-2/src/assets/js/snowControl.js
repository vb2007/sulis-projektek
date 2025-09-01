let isSnowing = true;
const snowButton = document.querySelector(".nav--button");
const snowflakes = document.querySelector(".snowflakes");

function toggleSnow() {
    if (isSnowing) {
        snowflakes.style.display = "none";
        snowButton.classList.remove("nav--button");
        snowButton.classList.add("nav--button--disabled");
    }
    else {
        snowflakes.style.display = "block";
        snowButton.classList.remove("nav--button--disabled");
        snowButton.classList.add("nav--button");
    }
    isSnowing = !isSnowing;
}

snowButton.addEventListener("click", function(e) {
    e.preventDefault();
    toggleSnow();
});