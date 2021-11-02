function CallLogout() {
    $.get("/Home/Logout", function (str) {
        alert(str);
    });
    var url = "/Home/Index";
    window.open(url, "_self");
}
