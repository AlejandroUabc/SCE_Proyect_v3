function ocultarPassR() {
    var control = document.getElementById("ddlTipoUsu");
    var password = document.getElementById("txContra");
    var lpassword = document.getElementById("etContra");
    var bc = document.getElementById("btRegistrarS");
    var bs = document.getElementById("btRegistrarC");
    var reqVal = document.getElementById("rfvContra");
    var regVal = document.getElementById("revContra");
    if (control.value == 1) {
        password.style.visibility = "visible";
        //bc.style.visibility = "hidden";
        //bs.style.visibility = "visible";
        bc.style.display = "none";
        bs.style.display = "block";
        regVal.style.visibility = "visible";
        reqVal.style.visibility = "visible";
        lpassword.style.visibility = "visible";
    } else {
        password.style.visibility = "hidden";
        //bc.style.visibility = "visible";
        //bs.style.visibility = "hidden";
        bc.style.display = "block";
        bs.style.display = "none";
        regVal.style.visibility = "hidden";
        reqVal.style.visibility = "hidden";
        lpassword.style.visibility = "hidden";
    }
}

function ocultarPassM() {
    var control = document.getElementById("ddlTipoUsu");
    var password = document.getElementById("txContra");
    var lpassword = document.getElementById("etContra");
    var bc = document.getElementById("btModificarS");
    var bs = document.getElementById("btModificarC");
    var reqVal = document.getElementById("rfvContra");
    var regVal = document.getElementById("revContra");
    if (control.value == 1) {
        password.style.visibility = "visible";
        //bc.style.visibility = "hidden";
        //bs.style.visibility = "visible";
        bc.style.display = "none";
        bs.style.display = "block";
        regVal.style.visibility = "visible";
        reqVal.style.visibility = "visible";
        lpassword.style.visibility = "visible";
    } else {
        password.style.visibility = "hidden";
        //bc.style.visibility = "visible";
        //bs.style.visibility = "hidden";
        bc.style.display = "block";
        bs.style.display = "none";
        regVal.style.visibility = "hidden";
        reqVal.style.visibility = "hidden";
        lpassword.style.visibility = "hidden";
    }
}
function cargarR() {
    var bs = document.getElementById("btRegistrarS");
    var password = document.getElementById("txContra");
    var lpassword = document.getElementById("etContra");
    var reqVal = document.getElementById("rfvContra");
    var regVal = document.getElementById("revContra");
    regVal.style.visibility = "hidden";
    reqVal.style.visibility = "hidden";
    password.style.visibility = "hidden";
    lpassword.style.visibility = "hidden";
    //bs.style.visibility = "hidden";
    bs.style.display = "none";
}
function cargarM() {
    var bs = document.getElementById("btModificarS");
    var password = document.getElementById("txContra");
    var lpassword = document.getElementById("etContra");
    var reqVal = document.getElementById("rfvContra");
    var regVal = document.getElementById("revContra");
    regVal.style.visibility = "hidden";
    reqVal.style.visibility = "hidden";
    password.style.visibility = "hidden";
    lpassword.style.visibility = "hidden";
    //bs.style.visibility = "hidden";
    bs.style.display = "none";
}