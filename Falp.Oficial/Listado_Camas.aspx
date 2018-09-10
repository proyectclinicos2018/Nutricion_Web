<%@ Page Title="" Language="C#" MasterPageFile="~/General2.Master" AutoEventWireup="true" CodeBehind="Listado_Camas.aspx.cs" Inherits="Falp.Oficial.Listado_Camas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/flick/jquery-ui.min.css">
<script src="http://code.jquery.com/jquery-1.10.0.min.js"/></script>
<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"/></script>

    <link href="Styles/estilo_bos.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/js_bos.js" type="text/javascript"></script>
     
     <script type="text/javascript">
         /*$(document).ready(function () {
         $("form").keypress(function (e) {
         if (e.which == 13) {
         return false;
         }
         });
         });*/
    </script>
    <script type="text/javascript">

        function informacion() {
            $('#generar_pedido').modal();
        }

        function generar_pedido() {
            $('#generar_pedido').modal();
        }

        function detalle_pedido() {
            $('#detalle_pedido').modal();
        }

        function msg() {
            $('#msg').modal();
        }

        function MostrarLabel() {


            setTimeout("OcultarLabel()", 3000);


            var msj = document.getElementById("lblMensaje");


            msj.style.visibility = "visible";


        }
        function OcultarLabel() {
            var msj = document.getElementById("lblMensaje");
            msj.style.visibility = "hidden";
        }



    </script>
    <script type="text/javascript">
        if (history.forward(1)) {
            history.replace(history.forward(1));
        }
    </script>

    <div class="col-sm-12">
        <div class="col-sm-3" style="padding-right: 3px; padding-left: 8px">
                                <div class="form-group">
        <h4> Listado de Camas </h4>
        </div>
        </div>

            <div class="col-sm-6" style="padding-right: 3px; padding-left: 8px">
                                <div class="form-group">
        <div id="lblMensaje" style="visibility: hidden;">
            <asp:Label ID="txtmsg1" runat="server" ForeColor="Red"></asp:Label>
        </div>
        </div>
        </div>

         <div class="col-sm-3" style="padding:2px 2px 2px 2px">
                                    <div class="form-group">
                                      <label >
                                            Fecha Pedido:
                                        </label>
                                         <asp:TextBox id="datepicker1" name="datepicker1" runat="server"  Enabled="true" placeholder="DD-MM-YYYY" type="text"    OnTextChanged="datepicker1_TextChanged" AutoPostBack="true"
                                                        style="height: 29px;  width: 50%" />
                                            </div>
                                            </div>
        
    </div>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div class="panel panel-success">
     
                <div class="panel-heading" style="height: 29px">
          
                </div>
                <div class="panel-body" style="width: 100%; display: inline-block; padding: 3px 3px 3px 10px">
                    <div class="row" style="padding-right: 3px; padding-left: 3px">
                        <div class="col-sm-12">
                            <div class="col-sm-2" style="padding-right: 3px; padding-left: 8px">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Turno</label>
                                    <asp:DropDownList ID="cboturno" runat="server" Style="height: 29px; width: 85%">
                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-4" style="padding-right: 3px; padding-left: 8px">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Nombre</label>
                                    <asp:TextBox type="text" ID="txnombre" runat="server" onkeypress="return soloLetras(event)"
                                        placeholder=" Nombre" Style="height: 29px; width: 85%" />
                                </div>
                            </div>
                            <div class="col-sm-2" style="padding-right: 3px; padding-left: 8px">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Rut</label>
                                    <asp:TextBox type="text" ID="txrut" runat="server" placeholder=" Rut" AutoPostBack="true"
                                        Style="height: 29px; width: 85%" />
                                </div>
                            </div>
                            <div class="col-sm-4" style="padding-right: 3px; padding-left: 8px">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Servicio</label>
                                    <asp:DropDownList ID="cboservicio" runat="server" Style="height: 29px; width: 85%">
                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
              
                        </div>
                        <div class="col-sm-12">
                            <div class="col-sm-2" style="padding-right: 3px; padding-left: 8px">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Tipo Comida</label>
                                    <asp:DropDownList ID="cbotipo_comida" runat="server" Style="height: 29px; width: 85%">
                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-4" style="padding-right: 3px; padding-left: 8px">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Estado</label>
                                    <asp:DropDownList ID="cboestado" runat="server" Style="height: 29px; width: 85%">
                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-2" style="padding-right: 3px; padding-left: 8px">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Ficha</label>
                                    <asp:TextBox type="text" ID="ficha_2" runat="server" onkeypress="return validNumericos(event)"
                                        placeholder=" Ficha" Style="height: 29px; width: 85%" />
                                </div>
                            </div>
                                 

                            
                            <div class="col-sm-1" style="padding-right: 3px; padding-left: 8px">
                                <div class="form-group">
                                    <br />
                                    <asp:Button ID="btn_buscar" CssClass="btn btn-success" runat="server" Text="Buscar"
                                        OnClick="buscar" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel panel-info">
                    <div class="panel-heading" style="width: 100%; height: 29px; padding: 3px 3px 3px 10px">
                        <div class="col-sm-10" style="padding-right: 3px; padding-left: 3px">
                            <div class="form-group">
                                Listado
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="form-group">
                                <right>
               Registros: <asp:Label ID="txtcantidad" runat="server" ></asp:Label></right>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body" style="width: 100%">
                        <asp:GridView ID="grillacama" runat="server" Width="100%" HorizontalAlign="Center"
                            OnPageIndexChanging="grillacama_PageIndexChanging" AutoGenerateColumns="false"
                            AllowPaging="true" GridLines="Vertical" PageSize="12000" OnRowDataBound="grillacama_RowDataBound"
                            DataKeyNames="_Id,_Id_pac,_Ficha,_Correlativo,_Tipo_doc,_Cod_cama,_Nom_habitacion,_Cod_servicio,_Estado_cama,_Estado,_Cod_menu,_Cod_tipo_alimento,_Cod_tipo_distribucion,_Cod_tipo_comida,_Cod_nhc,_Fecha_hosp,_Fecha_alta,_Fecha_pedido, _Ingesta, _Vale_impreso,_Hora"
                            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                            RowStyle-CssClass="rows" CellPadding="4" Font-Size="11px" EmptyDataText="Estimado  Usuario, No existen Datos">
                            <Columns>
                                <asp:TemplateField HeaderText="P" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <center>
                                            <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="P" Width="28px"
                                                Height="24px" OnClick="ingresar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="I&B" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <center>
                                            <asp:Button ID="Button2" CssClass="btn btn-info" runat="server" Text="I" Width="28px"
                                                Height="24px" OnClick="Btn_detalle_pedido" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="_Nom_estado" HeaderText="Estado" HeaderStyle-Width="5%"
                                    HeaderStyle-HorizontalAlign="LEFT" ItemStyle-HorizontalAlign="LEFT" />
                                <asp:TemplateField HeaderText="D" HeaderStyle-Width="1%">
                                    <ItemTemplate>
                                        <asp:Image ID="img_1" runat="server" Width="18px" Height="18px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="C1" HeaderStyle-Width="1%">
                                    <ItemTemplate>
                                        <asp:Image ID="img_2" runat="server" Width="18px" Height="18px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="A" HeaderStyle-Width="1%">
                                    <ItemTemplate>
                                        <asp:Image ID="img_3" runat="server" Width="18px" Height="18px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="O" HeaderStyle-Width="1%">
                                    <ItemTemplate>
                                        <asp:Image ID="img_4" runat="server" Width="18px" Height="18px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="C" HeaderStyle-Width="1%">
                                    <ItemTemplate>
                                        <asp:Image ID="img_5" runat="server" Width="18px" Height="18px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="C2" HeaderStyle-Width="1%">
                                    <ItemTemplate>
                                        <asp:Image ID="img_6" runat="server" Width="18px" Height="18px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CE" HeaderStyle-Width="1%">
                                    <ItemTemplate>
                                        <asp:Image ID="img_7" runat="server" Width="18px" Height="18px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="HCO" HeaderStyle-Width="1%">
                                    <ItemTemplate>
                                        <asp:Image ID="img_8" runat="server" Width="18px" Height="18px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="_Num_cama" HeaderText="Cama" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left"
                                    ItemStyle-HorizontalAlign="LEFT" />
                                <asp:BoundField DataField="_Cod_habitacion" HeaderText="Hab." HeaderStyle-Width="1%"
                                    HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                                <asp:BoundField DataField="_Cod_nhc" HeaderText=" NHC" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left"
                                    ItemStyle-HorizontalAlign="LEFT" />
                                <asp:BoundField DataField="_Num_doc" HeaderText="Ident." HeaderStyle-Width="2%" HeaderStyle-HorizontalAlign="left"
                                    ItemStyle-HorizontalAlign="LEFT" />
                                <asp:BoundField DataField="_Nombres" HeaderText="Nombre Pac." HeaderStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="_Nom_servicio" HeaderText="Servicio" HeaderStyle-Width="3%"
                                    HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
               
                <div class="modal fade" id="generar_pedido" tabindex="-1" role="dialog" aria-labelledby="contactLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    ×</button>
                                <h4 class="panel-title" id="H2">
                                    <span class="glyphicon glyphicon-info-sign"></span>Estimado Usuario, Esta Seguro
                                    de Generar Pedido</h4>
                            </div>
                            <div class="modal-body">
                                <div class="col-sm-3" style="padding-right: 3px; padding-left: 8px">
                                    <div class="form-group">
                                        <label style="width: 100%">
                                            Identificacion</label>
                                        <asp:TextBox type="text" ID="rut1" runat="server" Enabled="false" placeholder=" Rut"
                                            Style="height: 29px; width: 85%" />
                                    </div>
                                </div>
                                <div class="col-sm-6" style="padding-right: 3px; padding-left: 8px">
                                    <div class="form-group">
                                        <label style="width: 100%">
                                            Nombre</label>
                                        <asp:TextBox type="text" ID="nombre1" runat="server" Enabled="false" placeholder=" Nombre"
                                            Style="height: 29px; width: 85%" />
                                    </div>
                                </div>
                                <div class="col-sm-3" style="padding-right: 3px; padding-left: 8px">
                                    <div class="form-group">
                                        <label style="width: 100%">
                                            Ficha</label>
                                        <asp:TextBox type="text" ID="ficha1" runat="server" Enabled="false" placeholder=" Ficha"
                                            Style="height: 29px; width: 85%" />
                                    </div>
                                </div>
                                <div class="col-sm-2" style="padding-right: 3px; padding-left: 8px">
                                    <div class="form-group">
                                        <label style="width: 100%">
                                            Cama</label>
                                        <asp:TextBox type="text" ID="cama1" runat="server" Enabled="false" placeholder=" Cama"
                                            Style="height: 29px; width: 85%" />
                                    </div>
                                </div>
                                <div class="col-sm-2" style="padding-right: 3px; padding-left: 8px">
                                    <div class="form-group">
                                        <label style="width: 100%">
                                            Habitacion</label>
                                        <asp:TextBox type="text" ID="habitacion1" runat="server" Enabled="false" placeholder=" Habitación"
                                            Style="height: 29px; width: 85%" />
                                    </div>
                                </div>
                                <div class="col-sm-8" style="padding-right: 3px; padding-left: 8px">
                                    <div class="form-group">
                                        <label style="width: 100%">
                                            Servicio</label>
                                        <asp:TextBox type="text" ID="servicio1" runat="server" Enabled="false" placeholder=" Servicio"
                                            Style="height: 29px; width: 85%" />
                                    </div>
                                </div>
                                <div class="col-sm-12" style="padding-right: 3px; padding-left: 8px">
                                    <div class="form-group">
                                        <label style="width: 100%">
                                            Comentario</label>
                                          <asp:TextBox type="text" ID="txtobservaciones" placeholder="Observación " TextMode="MultiLine" 
                                    Style="height: 100px; width: 100%" runat="server"  />
                                    </div>
                                </div>
                                
                            
                                        
                               
                            </div>
                              <div  style=" text-align:right; padding:5px 5px 5px 5px">
                                     <asp:Button ID="btn_generar_pedido" CssClass="btn btn-info" runat="server" Text="Generar Pedido"
                                        OnClick="Btn_envia_generar_ped" />  
                                        </div>  
                                  
                                
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="msg" tabindex="-1" role="dialog" aria-labelledby="contactLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    ×</button>
                                <h4 class="panel-title" id="H4">
                                    <span class="glyphicon glyphicon-info-sign"></span>Estimado Usuario</h4>
                            </div>
                            <div class="modal-body" style="padding: 5px; height: 100px">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <asp:Label type="text" ID="txtmsg" runat="server" />
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>

                  <div id='imagenFlotante'>

                <asp:ImageButton ID="ImageButton1" ImageUrl="~/Imagenes/Botones/volver_1.png" runat="server" Width="40px" Height="40px" ToolTip="Volver Pedido" OnClick="volver" /><br />

       

</div>
<style>
#imagenFlotante {
  bottom:10px;
  right:10px;
  position: fixed;
  _position:absolute;
  clip:inherit;
  _top:expression(document.documentElement.scrollTop+document.documentElement.clientHeight-this.clientHeight);
  _right:expression(document.documentElement.scrollLeft+ document.documentElement.clientWidth - offsetWidth);
}

</style> 
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btn_buscar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <script type="text/javascript">
            $(function () {
                $.ajax({
                    type: "POST",
                    url: "Default.aspx/GetCustomers",
                    data: '{}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (r) {
                        var ddlCustomers = $("[id*=ddlCustomers]");
                        ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
                        $.each(r.d, function () {
                            ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
                        });
                    }
                });
            });
        </script>

        <script type="text/javascript">
            $("[id$=datepicker1]").datepicker({
                // Formato de la fecha
                language: "es",
                dateFormat: "dd-mm-yy",
                showOn: 'button',
                // Primer dia de la semana El lunes
                firstDay: 1,
                // Dias Largo en castellano
                dayNames: ["Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"],
                // Dias cortos en castellano
                dayNamesMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
                // Nombres largos de los meses en castellano
                monthNames: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
                // Nombres de los meses en formato corto 
                monthNamesShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dec"],
                buttonImageOnly: true,
                buttonImage: 'Imagenes/Botones/calender20.png',
                // Cuando seleccionamos la fecha esta se pone en el campo Input 

                onSelect: function (dateText) {
                    $('#fecha').val(dateText);
                }
            });
</script>
     
        <script type="text/javascript">
    
       
            /* $(document).ready(function () {
          
            $("[id$=datepicker1]").datepicker({
                language: "es",
//            dateFormat: 'dd-mm-yy',
//            // showOn: 'button',
//            changeMonth: true,
//            changeYear: true,  
//            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
//            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
//            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
//            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb']
            // buttonImageOnly: true,
            // buttonImage: 'Imagenes/Botones/calender20.png'
            });
            }).datepicker("setDate", new Date());*/
        </script>
        <script type="text/javascript">

            function soloLetras(e) {
                key = e.keyCode || e.which;
                tecla = String.fromCharCode(key).toLowerCase();
                letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
                especiales = [8, 37, 39, 46];

                tecla_especial = false
                for (var i in especiales) {
                    if (key == especiales[i]) {
                        tecla_especial = true;
                        break;
                    }
                }

                if (letras.indexOf(tecla) == -1 && !tecla_especial)
                    return false;
            } 
        </script>
        <script type="text/javascript">
            function validNumericos(evt) {
                var nav4 = window.Event ? true : false;

                var key = nav4 ? evt.which : evt.keyCode;

                return (key <= 13 || (key >= 48 && key <= 57) || key == 44);
            }  
        </script>


          <script type="text/javascript">

            
              function valida_fecha() {
                  var fecha = $('#ContentPlaceHolder1_datepicker1').val();
                
                  re = /^[0-9][0-9]\-[0-9][0-9]\-[0-9][0-9][0-9][0-9]$/;
	
                if(!re.exec(fecha))
                {
	              ///  alert("La fecha no tiene formato DD-MM-AAAA")
	                
	                fecha = new Date();

	           //     $('#ContentPlaceHolder1_datepicker1').val(fecha.getDate() + "-" + (fecha.getMonth() + 1) + "-" + fecha.getFullYear());
                }
                else
                {
	               
                 };
              }

        </script>
</asp:Content>
