<%@ Page Title="" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="Generar_Pedido.aspx.cs" Inherits="Falp.Oficial.Generar_Pedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/flick/jquery-ui.min.css">
<script src="http://code.jquery.com/jquery-1.10.0.min.js"/></script>
<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"/></script>

    <link href="Styles/estilo_bos.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/js_bos.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(document).ready(function () {
         $("form").keypress(function (e) {
             if (e.which == 13) {
                 return false;
             }
         });
     });
</script>


<script type="text/javascript">



    function desayuno() {
        $('#btn_desayuno').modal();

    }

    function info_comentario() {
    
        $('#comentario').modal();
    }

    function mensajes() {
        $('#mensajes').modal();
    }

    function cambiar_estado() {
        $('#cambiar_estado_comida').modal();
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
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
<div ng-app="MyApp" ng-controller="MyController">

    <div class="Subtitulo_1" style="height: 53px">
        <div class="row">
            <div class="col-sm-6" style="height: 29px">
                <div class="form-group">
                    <h3>  Generar Pedido <asp:Label ID="txtpedido" runat="server" ></asp:Label> </h3> 
                </div>
            </div>
          
             <div class="col-sm-4">
                <div class="form-group">
              
             
                            <div id="lblMensaje" style="visibility:hidden;">    <asp:Label ID="txtmsg1" runat="server" ForeColor="Red"></asp:Label> </div>   
                 
                </div>
            </div>
            <div class="col-sm-2">
                <div class="form-group">

                  
                    
                   
                </div>
            </div>
        
        </div>
    </div>
    <br />


         <div class="row">
                <div class="col-md-3" style="padding-right: 3px; padding-left: 15px" >
                 <div class="panel panel-success" >
                    <div class="panel-heading">Opciones Alimentaciòn</div>
                    <div id="ck" runat="server"  class="panel-body" style="width: 100%; display: inline-block; padding: 3px 3px 3px 2px">

                   <div class="col-md-12 " style="padding-right: 3px; padding-left: 2px" >
                  <div class="radio"> <label><asp:RadioButton ID="ck_ayuno"  runat="server" GroupName="opc_alim" AutoPostBack="true"  CausesValidation="true"    OnCheckedChanged="opc_alim_CheckedChanged"  />  Ayuno</label>  <asp:ImageButton ID="btn_b_ayuno" ImageUrl="~/Imagenes/Botones/buscar.png" runat="server" Width="16px" Height="16px" ToolTip="Ver Comentario"  OnClick="buscar_comentario" /></div>
                  <div class="radio"> <label><asp:RadioButton ID="ck_alimen_oral"  runat="server" GroupName="opc_alim" AutoPostBack="true" CausesValidation="true"  OnCheckedChanged="opc_alim_CheckedChanged"  />  Alimentaciòn Oral</label> <asp:ImageButton ID="btn_b_alim_oral" ImageUrl="~/Imagenes/Botones/buscar.png" runat="server" Width="16px" Height="16px" ToolTip="Ver Comentario"  OnClick="buscar_comentario" /></div>
                  <div class="radio"> <label><asp:RadioButton ID="ck_nut_oral"  runat="server" GroupName="opc_alim"  CausesValidation="true"  AutoPostBack="true"  OnCheckedChanged="opc_alim_CheckedChanged"  />  Nutriciòn Enteral</label> <asp:ImageButton ID="btn_b_nut_oral" ImageUrl="~/Imagenes/Botones/buscar.png" runat="server" Width="16px" Height="16px" ToolTip="Ver Comentario"  OnClick="buscar_comentario" /></div>
                  <div class="radio"> <label><asp:RadioButton ID="ck_nut_parenteral"  runat="server" GroupName="opc_alim"   CausesValidation="true"  AutoPostBack="true" OnCheckedChanged="opc_alim_CheckedChanged"  />  Nutriciòn Parental</label> <asp:ImageButton ID="btn_b_nut_parenteral" ImageUrl="~/Imagenes/Botones/buscar.png" runat="server" Width="16px" Height="16px" ToolTip="Ver Comentario"  OnClick="buscar_comentario" /></div>
                 <div class="radio"> <label><asp:RadioButton ID="ck_cero_boca"  runat="server" GroupName="opc_alim"   CausesValidation="true"  AutoPostBack="true" OnCheckedChanged="opc_alim_CheckedChanged"  />  Cero por Boca</label><asp:ImageButton ID="btn_b_cero_boca" ImageUrl="~/Imagenes/Botones/buscar.png" runat="server" Width="16px" Height="16px" ToolTip="Ver Comentario"  OnClick="buscar_comentario" /></div>
                
                    </div>
                   
                    </div>
                    </div>

                </div>


                   <div class="col-md-3">
                 <div class="panel panel-success">
                    <div class="panel-heading">Bandeja</div>
                    <div class="panel-body" style="width: 100%">

                    <div class="col-md-12 " style="padding:1px 1px 1px 1px" >
                 
                        <div class="form-group">
                        <label>Bandeja</label>
                         <asp:DropDownList ID="cboaislamiento"  runat="server" Style="height: 29px; width: 100%"   OnSelectedIndexChanged="cboaislamiento_SelectedIndexChanged" AutoPostBack="true"
                                    CausesValidation="true">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                       
                    </div>
                    </div>
                   
                    </div>
                    </div>

                </div>

                 <div class="col-md-6 " style="padding-right: 1px; padding-left: 1px ; padding-top:1" >
                  <div class="panel panel-success">
                    <div class="panel-heading">Detalle del  Regimen</div>
                    <div class="panel-body" style="width: 100%">
                     <div class="col-sm-12" style="padding: 1px 1px 1px 1px" >
                          <div class="col-sm-4" style="padding:1px 1px 1px 1px" >
                        <div class="form-group">
                        <label>Cobro</label>
                            <asp:DropDownList ID="cboregimen"  runat="server" Style="height: 29px; width: 90%"   OnSelectedIndexChanged="cboregimen_SelectedIndexChanged" AutoPostBack="true"
                                    CausesValidation="true">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4" style="padding:1px 1px 1px 1px" >
                        <div class="form-group">
                        <label>Consistencia</label>

                             <asp:DropDownList ID="cboconsistencia"  runat="server" Style="height: 29px; width: 90%"   OnSelectedIndexChanged="cboconsistencia_SelectedIndexChanged" AutoPostBack="true"
                                    CausesValidation="true">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4" style="padding:1px 1px 1px 1px" >
                        <div class="form-group">
                        <label>Digestibilidad</label>
                         <asp:DropDownList ID="cbodigestabilidad"  runat="server" Style="height: 29px; width: 90%"   OnSelectedIndexChanged="cbodigestabilidad_SelectedIndexChanged" AutoPostBack="true"
                                    CausesValidation="true">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                           
                        </div>
                    </div>
                    </div>


                          <div class="col-sm-12" style="padding:1px 1px 1px 1px" >
                          <div class="col-sm-4" style="padding:1px 1px 1px 1px" >
                        <div class="form-group">
                        <label>Sal</label>
                            <asp:DropDownList ID="cbosal"  runat="server" Style="height: 29px; width: 90%"   OnSelectedIndexChanged="cbosal_SelectedIndexChanged" AutoPostBack="true"
                                    CausesValidation="true">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4" style="padding:1px 1px 1px 1px" >
                        <div class="form-group">
                        <label>Lactosa</label>

                             <asp:DropDownList ID="cbolactosa"  runat="server" Style="height: 29px; width: 90%"   OnSelectedIndexChanged="cbolactosa_SelectedIndexChanged" AutoPostBack="true"
                                    CausesValidation="true">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4" style="padding:1px 1px 1px 1px" >
                        <div class="form-group">
                        <label>Dulzor</label>
                         <asp:DropDownList ID="cbodulzor"  runat="server" Style="height: 29px; width: 90%"   OnSelectedIndexChanged="cbodulzor_SelectedIndexChanged" AutoPostBack="true"
                                    CausesValidation="true">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                           
                        </div>
                    </div>
                    </div>

                    </div>
                    </div>


                </div>
           </div>
     
  
    <div class="panel panel-success">
        <div class="panel-heading">
            Alimentacion Oral</div>
        <div class="panel-body" style="width: 100%">
            <div class="row">
                <div class="col-md-12 ">
                 <div class="col-xs-3" >
                             <center>  
                                        <asp:ImageButton ID="img_d_2"  ImageUrl="~/Imagenes/Almuerzos/desa_1.jpg"  Cssclass="img-circle"  runat="server" Width="100px" Height="100px" OnClick="acceso_d"  /> 
                                    <h5>
                                        Desayuno(D)</h5>
                                        <asp:ImageButton ID="img_d"  ImageUrl="~/Imagenes/Botones/off.png"   runat="server" Width="30px" Height="30px" OnClick="Btn_desayuno"  /> 
                   
                                       
                                </center>
                                  </div>
                                  <div class="col-xs-3" >
                              <center>   
                               <asp:ImageButton ID="img_c1_2" ImageUrl="~/Imagenes/Almuerzos/cola_1.jpg"  runat="server" Cssclass="img-circle"  Width="100px" Height="100px" OnClick="acceso_c1"  /> 
                                      
                               
                                    <h5>
                                       Colación Matinal(C1)</h5>

                                       <asp:ImageButton ID="img_c1" ImageUrl="~/Imagenes/Botones/off.png" Cssclass="img-circle"   runat="server" Width="30px" Height="30px" OnClick="Btn_colacion_man"  /> 
                                      </center> <br /> 
                            </div>

                              <div class="col-xs-3" >
                               <center>  
                                <asp:ImageButton ID="img_a_2" ImageUrl="~/Imagenes/Almuerzos/almu_4.jpg"  runat="server" Cssclass="img-circle"  Width="100px" Height="100px" OnClick="acceso_a"  /> 
                                
                                    <h5>
                                        Almuerzo(A)</h5>
                                          <asp:ImageButton ID="img_a" ImageUrl="~/Imagenes/Botones/off.png"  runat="server" Width="30px" Height="30px" OnClick="Btn_almuerzo1"  /> 
                                      
                                           </center>
                            </div>

                
                             <div class="col-xs-3" >
                             <center>  
                                 <asp:ImageButton ID="img_o_2" ImageUrl="~/Imagenes/Almuerzos/desa_1.jpg"  runat="server" Cssclass="img-circle"  Width="100px" Height="100px" OnClick="acceso_o"  /> 
                                
                                    <h5>
                                        Once(O)</h5>
                                         <asp:ImageButton ID="img_o" ImageUrl="~/Imagenes/Botones/off.png"  class="img-circle"  runat="server" Width="30px" Height="30px" OnClick="Btn_once"  /> 
                                      
                                         </center>
                                 
                            </div>

                             <div class="col-xs-12">
                               <div class="col-xs-3" >
                              <center>   
                                <asp:ImageButton ID="img_c_2" ImageUrl="~/Imagenes/Almuerzos/almu_4.jpg"  runat="server" Cssclass="img-circle"  Width="100px" Height="100px" OnClick="acceso_c"  /> 
                                
                                    <h5>
                                        Cena(C)</h5>
                                            <asp:ImageButton ID="img_c"  ImageUrl="~/Imagenes/Botones/off.png" class="img-circle"   runat="server" Width="30px" Height="30px" OnClick="Btn_cena"  />  </center>

                            </div>

                            <div class="col-xs-3" >
                              <center>   <asp:ImageButton ID="img_c2_2" ImageUrl="~/Imagenes/Almuerzos/cola_1.jpg"  runat="server" Cssclass="img-circle"  Width="100px" Height="100px" OnClick="acceso_c2"  /> 
                                
                           
                                    <h5>
                                     Colación Nocturna(C2)</h5>
                                           <asp:ImageButton ID="img_c2" ImageUrl="~/Imagenes/Botones/off.png" class="img-circle"   runat="server" Width="30px" Height="30px" OnClick="Btn_colacion_noc"  />  </center>

                            </div>

                              <div class="col-xs-3" >
                             <center>  <asp:ImageButton ID="img_ce_2" ImageUrl="~/Imagenes/Almuerzos/cola_1.jpg"  runat="server" Cssclass="img-circle"  Width="100px" Height="100px" OnClick="acceso_ce"  /> 
                                
                             
                                    <h5>
                                        Colación Extra(CE)</h5>
                                       
             
                                             <asp:ImageButton ID="img_ce"  ImageUrl="~/Imagenes/Botones/off.png" runat="server" Width="30px" Height="30px" OnClick="Btn_colacion_ext"  />  </center>
                            </div>
                           
                            
                            <div class="col-xs-3" >
                              <center> <asp:ImageButton ID="img_hco_2" ImageUrl="~/Imagenes/Almuerzos/hidri_1.jpg"  runat="server" Cssclass="img-circle"  Width="100px" Height="100px" OnClick="acceso_hco"  /> 
                                
                              
                                  <h5>
                                        Hidricos(HCO)</h5>

                     
                        <asp:ImageButton ID="img_hco"  ImageUrl="~/Imagenes/Botones/off.png" runat="server" Width="30px" Height="30px" OnClick="Btn_hidricos"  />  </center>
                            </div>



                            </div>

                    
                </div>
               
                
            </div>
        </div>
    </div>




            
         


                   <div class="modal fade" id="comentario" tabindex="-1" role="dialog" aria-labelledby="contactLabel"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×</button>
                        <h4 class="panel-title" id="H10">
                            <span class="glyphicon glyphicon-info-sign"></span>Estimado Usuario, Ingrese Observación</h4>
                    </div>
                    <div class="modal-body" style="padding: 5px; height:100px">
                        <div class="col-sm-12">
                        <div class="form-group">
                        <label style="width: 100%" >Comentario    <asp:Label ID="comen"  runat="server"></asp:Label></label>
                            <asp:TextBox ID="txtobservacion" runat="server" TextMode="MultiLine"  Width="100%" placeholder="Comentario "></asp:TextBox>
                       
                      </div>
                       </div>

                    
                    </div>
                   
                       
                  
                </div>
            </div>
        </div>


               <div class="modal fade" id="mensajes" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×</button>
                        <h4 class="panel-title" id="H2">
                            <span class="glyphicon glyphicon-info-sign"></span>Estimado Usuario</h4>
                    </div>
                    <div class="modal-body" style="padding: 5px; height:100px">
                      
                      
                        <asp:Label ID="txtmsg" runat="server" />
                       
                    
                    </div>
                   
                       
                  
                </div>
            </div>
        </div>




  


</div>


            </ContentTemplate>
                <Triggers>
                
                
                   <asp:AsyncPostBackTrigger ControlID="cboregimen" EventName="selectedindexchanged"  />
                   <asp:AsyncPostBackTrigger ControlID="cboconsistencia" EventName="selectedindexchanged" />
                   <asp:AsyncPostBackTrigger ControlID="cbodigestabilidad" EventName="selectedindexchanged" />
                   <asp:AsyncPostBackTrigger ControlID="cbodulzor" EventName="selectedindexchanged" />
                   <asp:AsyncPostBackTrigger ControlID="cbolactosa" EventName="selectedindexchanged" />
                   <asp:AsyncPostBackTrigger ControlID="cbosal" EventName="selectedindexchanged" />
                   <asp:AsyncPostBackTrigger ControlID="cboaislamiento" EventName="selectedindexchanged" />
                  
                  <asp:AsyncPostBackTrigger ControlID="ck_ayuno" />
                  <asp:AsyncPostBackTrigger ControlID="ck_alimen_oral"  />
                  <asp:AsyncPostBackTrigger ControlID="ck_nut_oral"  />
                  <asp:AsyncPostBackTrigger ControlID="ck_nut_parenteral"  />
                  <asp:AsyncPostBackTrigger ControlID="ck_cero_boca"  />


                   <asp:AsyncPostBackTrigger ControlID="img_d" EventName="Click" />
                   <asp:AsyncPostBackTrigger ControlID="img_d_2" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="img_c1" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="img_c1_2" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="img_a" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="img_a_2" EventName="Click" />
                   <asp:AsyncPostBackTrigger ControlID="img_o" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="img_o_2" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="img_c" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="img_c_2" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="img_c2" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="img_c2_2" EventName="Click" />       
                 <asp:AsyncPostBackTrigger ControlID="img_ce" EventName="Click" />
                 <asp:AsyncPostBackTrigger ControlID="img_ce_2" EventName="Click" />
                 <asp:AsyncPostBackTrigger ControlID="img_hco" EventName="Click" />
                 <asp:AsyncPostBackTrigger ControlID="img_hco_2" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>  
              <div id='imagenFlotante'>

             <asp:ImageButton ID="ImageButton1" ImageUrl="~/Imagenes/Botones/menu_2.png" runat="server" Width="40px" Height="40px" ToolTip="Regresar a Listado de Pacientes"  OnClick="btn_volver" />
       

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

</asp:Content>
