//$(document).ready(function () {
//    $('[id=XML]').click(function () {
//        var m = [];
//        var elements = document.getElementsByClassName('category');
//        var skip = document.getElementById('skip');
//        var take = document.getElementById('take');
//        for (var i in elements) {
//            if (elements[i].checked) {
//                m[i++] = elements[i].id.split('=');
//            }
//        };
//        var url = 'http://localhost:61589/Report?';
//        var request = new XMLHttpRequest();
//        request.open('GET', url);
//        request.setRequestHeader('Content-Type', 'application/x-www-form-url');
//        request.setRequestHeader('skip', skip);
//        request.setRequestHeader('take', take);
//        for (var item in m) {
//            request.setRequestHeader(m[item][0], m[item][1]);
//        }
//        request.addEventListener("readystatechange", () => {
//            if (request.readyState === 4 && request.status === 200) {
//                console.log("All ok");
//            }
//        });
//        request.send();
//        /* $.ajax({
//             url: url,
//             datatType : 'xml',
//             success: function (jsonData) {
//                 alert(jsonData);
//             }
//         });*/
//    });
//});


$(document).ready(function () {
    $('[id=XSLX]').click(function () {
        var m = [];
        var elements = document.getElementsByClassName('category');
        var sort = document.getElementById('sort');
        var skip = document.getElementById('sort');
        var take = document.getElementById('take');
        for (var i in elements) {
            if (elements[i].checked) {
                m[i++] = elements[i].id.split('=');
            }
        };
        var url = 'http://localhost:61589/Report?';
        var request = new XMLHttpRequest();
        request.open('GET', url);
        request.setRequestHeader('Content-Type', 'application/json');
        request.setRequestHeader('skip', skip);
        request.setRequestHeader('take', take);
        request.setRequestHeader('sort', sort);
        var arr = [];
        var i = 0;
        for (var item in m) {
            var q = false;
            for (var i in arr) {
                if (arr[i].PropertyName === m[item][0]) {
                    q = true;
                    arr[i].PropertyValues[arr[i].PropertyValues.length] = {
                            "Value": m[item][1],
                            "Checked":true 
                        }
                    
                }
            }
            if (!q) {
                arr[arr.length] = {
                    "PropertyName": m[item][0],
                    "PropertyValues": {
                        "Value": m[item][1],
                        "Checked": true 
                    }
                }
            }
        }
        request.addEventListener("readystatechange", () => {
            if (request.readyState === 4 && request.status === 200) {
                console.log("All ok");
            }
        });
        request.send();
        /* $.ajax({
             url: url,
             datatType : 'xml',
             success: function (jsonData) {
                 alert(jsonData);
             }
         });*/
    });
});
