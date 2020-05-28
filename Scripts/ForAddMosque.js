
function loadDoc() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("add").innerHTML = this.responseText;
        }
    };
    if (document.getElementById("format").value == "") {
        document.getElementById("List").innerHTML = "Please Select from the list";
    }
    else if (document.getElementById("format").value == 24) {
        xhttp.open("GET", "/Home/AddMosque24", true);
        xhttp.send();
    }
    else if (document.getElementById("format").value == 12) {
        xhttp.open("GET", "/Home/AddMosque12", true);
        xhttp.send();
    }
}