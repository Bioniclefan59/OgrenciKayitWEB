
document.addEventListener("DOMContentLoaded", function () {
    fetch('./api/ogrenciler/GetStudentNames')
        .then(response => response.json())
        .then(data => {
            autocomplete(document.getElementById("txtOgrenciIsmi"), data);
        })
        .catch(error => console.error('Error fetching student names:', error));
});


    function autocomplete(input, arr) {
        var currentFocus;
        input.addEventListener("input", function (e) {
            var val = this.value;
            closeAllLists();
            if (!val) { return false; }
            currentFocus = -1;
            var div = document.createElement("div");
            div.setAttribute("id", this.id + "-autocomplete-list");
            div.setAttribute("class", "autocomplete-items");
            this.parentNode.appendChild(div);
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].toUpperCase().includes(val.toUpperCase())) {
                    var item = document.createElement("div");
                    item.innerHTML = "<strong>" + arr[i].substr(0, val.length) + "</strong>";
                    item.innerHTML += arr[i].substr(val.length);
                    item.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
                    item.addEventListener("click", function (e) {
                        input.value = this.getElementsByTagName("input")[0].value;
                        closeAllLists();
                    });
                    div.appendChild(item);
                }
            }
        });

        input.addEventListener("keydown", function (e) {
            var x = document.getElementById(this.id + "-autocomplete-list");
            if (x) x = x.getElementsByTagName("div");
            if (e.keyCode == 40) { // Down arrow key
                currentFocus++;
                addActive(x);
            } else if (e.keyCode == 38) { // Up arrow key
                currentFocus--;
                addActive(x);
            } else if (e.keyCode == 13) { // Enter key
                e.preventDefault();
                if (currentFocus > -1) {
                    if (x) x[currentFocus].click();
                }
            }
        });
    }

    function addActive(x) {
        if (!x) return false;
        removeActive(x);
        if (currentFocus >= x.length) currentFocus = 0;
        if (currentFocus < 0) currentFocus = (x.length - 1);
        x[currentFocus].classList.add("autocomplete-active");
    }

    function removeActive(x) {
        for (var i = 0; i < x.length; i++) {
            x[i].classList.remove("autocomplete-active");
        }
    }

    function closeAllLists(elmnt) {
        var items = document.getElementsByClassName("autocomplete-items");
        for (var i = 0; i < items.length; i++) {
            if (elmnt != items[i] && elmnt != input) {
                items[i].parentNode.removeChild(items[i]);
            }
        }
    }