
var element = document.getElementById("example")
var textExample = "this is a text";
var aNumer = 10.33;

var complexObject = {
    name : "Israel",
    lastName: "Perez",
    age : 19
}
var ul = "<ul>"
for (var i = 0; i < textExample.length; i++) {
    ul += ("<li>" + textExample[i] + "</li>")
}
ul += "</ul>"
element.innerHTML = ul;