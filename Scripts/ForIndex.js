function loadDoc() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {

        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("List").innerHTML = this.responseText;
        }
    };
    if (document.getElementById("MosqueArea").value == "") {
        document.getElementById("List").innerHTML = "Please Select from the list";
    }
    else if (document.getElementById("format").value == "") {
        document.getElementById("List").innerHTML = "Please Select format from the list";
    }
    else if (document.getElementById("format").value == 24) {
        xhttp.open("GET", "/Home/GetList24?area=" + document.getElementById("MosqueArea").value, true);
        xhttp.send();
    }
    else if (document.getElementById("format").value == 12) {
        xhttp.open("GET", "/Home/GetList12?area=" + document.getElementById("MosqueArea").value, true);
        xhttp.send();
    }
}