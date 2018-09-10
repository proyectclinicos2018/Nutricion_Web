<%@ Page Title="" Language="C#" MasterPageFile="~/General_Oficial.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Falp.Oficial.Home1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <script type="text/javascript">
          if (history.forward(1)) {
              history.replace(history.forward(1));
          }
    </script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
   <div class="Subtitulo">
      Bienvenido, Estimado Usuario:  <asp:Label ID="txtusuario" runat="server"  ></asp:Label>
 
           <center><asp:Button ID="Button1"  CssClass="btn btn-success" runat="server" Text="Ingresar Listado Pacientes" OnClick="ingresar" />
           <asp:Button ID="btn_actualizar"  CssClass="btn btn-danger" runat="server" Text="Actualizar  Pacientes" OnClick="actualizar" />
       
           </center>
           </div>

           <center>
           <img src="Imagenes/Login/falp.png"  /> 
           <br />  <br />

                <img src="Imagenes/Imagenes/valor.png"    height="130px"  /> 
           <br /> 
           </center>
           
                  </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btn_actualizar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>




</asp:Content>
