<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Falp.Oficial.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Styles/Login.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/Login.js" type="text/javascript"></script>
    <style type="text/css">
        .btn_signin
        {}
    </style>
</head>
<body>


    
     <div class="container">
    
        <div class="card card-container">
        <h1> Sistema  Nutriciòn</h1>
    <center>   <h2>(Falp)</h2> </center> 
            
            <img id="profile-img" class="profile-img-card"  src="Imagenes/Logos/log.jpg" alt=""   width="100px" height="100px"   />
            <center><img src="Imagenes/Imagenes/valor.png"    height="70px"  /> </center> 
       
            <form class="form-signin" runat="server">
                <span id="reauth-email" class="reauth-email"></span>
                <input type="text" id="inputEmail" name="inputEmail" class="form-control" runat="server"   placeholder="Usuario" required >
                <input type="password" id="inputPassword" name="inputPassword" runat="server"   class="form-control" placeholder="Password" required>


             <asp:Button ID="Button1"  CssClass="btn_signin" runat="server" Text="Ingresar" 
                      OnClick="ingresar"  />

         
            </form><!-- /form -->
        
          
        </div><!-- /card-container -->
    </div><!-- /container -->
    
</body>
</html>
