function validation2() {

    var combo1 = document.getElementById("<%=cboregimen.ClientID%>")
    if (combo1.value == null || combo1.value == "0") {
        alert("Porfavor, seleccione el tipo comida correspondiente");
        document.getElementById("<%=cboregimen.ClientID%>").style.border = "2px solid red";
        return false;
    }
    else {
        document.getElementById("<%=cboregimen.ClientID%>").style.border = "";
    }


    return true;
}
