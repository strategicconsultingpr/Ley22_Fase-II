$(document).ready(function () {
    $(".SEPSDivs").addClass("SEPSDivsInfo");
    $(".SEPSDivs").removeClass("SEPSDivs");
});
function dsmivShowHideClick() {
    try {
        var showContentButton = document.getElementById("dsmiv_showContentButton");
        if (showContentButton.getAttribute("aria-expanded") == "false") {
            showContentButton.innerText = "Esconder contenido";
        }
        else {
            showContentButton.innerText = "Mostrar contenido";
            showContentButton.setAttribute('aria-expanded', 'false');
        }
    }
    catch (ex) { window.alert(ex.message); }
}