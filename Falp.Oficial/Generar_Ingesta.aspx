<%@ Page Title="" Language="C#" MasterPageFile="~/General2.Master" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="Generar_Ingesta.aspx.cs" Inherits="Falp.Oficial.Generar_Ingesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    //<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/flick/jquery-ui.min.css"><script src="http://code.jquery.com/jquery-1.10.0.min.js"/></script><script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"/></script><link href="Styles/estilo_bos.css" rel="stylesheet" type="text/css" /><script src="Scripts/js_bos.js" type="text/javascript"></script><style type="text/css">
    table {
        border-collapse: collapse;
        width: 98%;
       padding: 2px 2px 2px 2px;
    }

    th, td {
        text-align: left;
        padding: 8px;
    }

    tr:nth-child(even){background-color: #f2f2f2}
</style><script type="text/javascript">
     $(document).ready(function () {
         $("form").keypress(function (e) {
             if (e.which == 13) {
                 return false;
             }
         });

         $('#ContentPlaceHolder1_y').focusout(function (e) {
             $('#ContentPlaceHolder1_x').text($(this).val());

         });
     });
</script><script type="text/javascript">

     function cerrar() {

         $('#selec_msg').modal('hide');

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



    </script><div class="Subtitulo_1" style="height: 53px"> <div class="row">
            <div class="col-sm-6">
                <div class="form-group">
                    <h4>
                        Generar Ingesta
                         
                    </h4>
                </div>
            </div>
       
            <div class="col-sm-5">
                <div class="form-group">
                   
                      <div id="lblMensaje" style="visibility:hidden;">    <asp:Label ID="txtmsg" runat="server" ForeColor="Red"></asp:Label> </div>    </center>
                    
                </div>
            </div>
            <div class="col-sm-1">
                <div class="form-group">

                  

                </div>
            </div>
        </div></div><br />
    <div class="panel panel-success">
        <div class="panel-heading" style="height: 29px">
            Antecedentes Paciente
        </div>
        <div class="panel-body" style="width: 100%; display: inline-block; padding: 3px 3px 3px 10px">
            <div class="row" style="padding-right: 3px; padding-left: 3px">

                
                <div class="col-sm-2" style="padding-right: 3px; padding-left: 8px">
                    <div class="form-group">
                        <label style="width: 100%; padding-bottom: 5px">
                            Rut</label>
                        <asp:TextBox type="text" id="txtrut" runat="server" placeholder="Ingresar Rut" name="txtrut1" style="height: 29px;
                            width: 85%" />
                    </div>
                </div>

                 <div class="col-sm-4" style="padding-right: 3px; padding-left: 8px">
                    <div class="form-group">
                        <label style="width: 100%; padding-bottom: 5px">
                            Nombre</label>
                        <asp:TextBox type="text" id="txtnombre" placeholder="Nombre" runat="server"  name="txtnombre1" style="height: 29px;
                            width: 85%" />
                    </div>
                </div>

                <div class="col-sm-1" style="padding-right: 3px; padding-left: 8px">
                    <div class="form-group">
                        <label style="width: 100%; padding-bottom: 5px">
                            Ficha</label>
                       <asp:TextBox type="text" id="txtficha" placeholder="Ficha" runat="server"   name="txtficha1" style="height: 29px;
                            width: 85%" />
                    </div>
                </div>

                <div class="col-sm-1" style="padding-right: 3px; padding-left: 8px">
                    <div class="form-group">
                        <label style="width: 100%; padding-bottom: 5px">
                            Habitacion</label>
                        <asp:TextBox type="text" id="txthabitacion" runat="server"  placeholder="Ficha" style="height: 29px;
                            width: 85%" />
                    </div>
                </div>

                 <div class="col-sm-1" style="padding-right: 3px; padding-left: 8px">
                    <div class="form-group">
                        <label style="width: 100%; padding-bottom: 5px">
                                Cama</label>
                     <asp:TextBox type="text" id="txtcama" runat="server"  placeholder="N° Cama" style="height: 29px;
                            width: 85%" />
                    </div>
                </div>

                 <div class="col-sm-3" style="padding-right: 3px; padding-left: 8px">
                    <div class="form-group">
                        <label style="width: 100%; padding-bottom: 5px">
                            Servicio</label>
                       <asp:TextBox type="text" runat="server" id="txtservicio" placeholder="Servicio" style="height: 29px;
                            width: 85%" />
                    </div>
                </div>

                 
               
               
                
            </div>
        </div>
    </div>

        <div class="panel panel-success">
 

                <div class="panel-heading" style="width: 100%; height: 40px;">
                    <div class="col-sm-10">
                        <div class="form-group">
                             Resumen     
                                
    
                        </div>
                    </div>
                </div>
                <div class="panel-body" style="width: 100%">

                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
                  <asp:GridView ID="grillaresumen" runat="server" Width="100%" HorizontalAlign="Center" OnPageIndexChanging="grillaresumen_PageIndexChanging"
                        AutoGenerateColumns="false" AllowPaging="true"  GridLines="Both" PageSize="12000"
                        DataKeyNames=""  CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"  CellPadding="4"  Font-Size="11px" >
                        <Columns>
                       
                            <asp:TemplateField HeaderText="" HeaderStyle-Width="0.01%"  ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate   >
                                <asp:HiddenField ID="var_cod_comida" runat="server" Value='<%#Eval("_Cod_tipo_comida") %>'> </asp:HiddenField>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="_Nom_tipo_distribucion" HeaderText="Tipo Comida" HeaderStyle-Width="4%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                                   <asp:BoundField DataField="_Ing_gr_c" HeaderText="Gr. c." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                                 
                                 <asp:BoundField DataField="_Calorias" HeaderText="Calorias" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                                 <asp:BoundField DataField="_Proteinas" HeaderText="Proteinas" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                                 <asp:BoundField DataField="_Lipidos" HeaderText="Lipidos" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                                 <asp:BoundField DataField="_Hyc" HeaderText="H&C" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                                <asp:BoundField DataField="_Sodio" HeaderText="Sodio" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                                <asp:BoundField DataField="_Hc" HeaderText="CC. C." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                           
                        </Columns>
                    </asp:GridView>
           
                   </ContentTemplate>
            <Triggers>
         
            </Triggers>
        </asp:UpdatePanel>
                </div>
            </div>

         
               <div class="panel panel-success">
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="panel-heading" style="width: 100%; height: 40px;">
                    <div class="col-sm-12">
                        <div class="form-group">
                       
                         <asp:Label ID="ttxt1" runat="server" Text="Desayuno"  Font-Size="16px"  style=" color:#3498DB; font-weight:bold" ></asp:Label>   
                     
            
                   <div style="text-align:right;  margin-top:0;" >
                   
                     <asp:Button ID="btn_todo_d" CssClass="btn btn-success" runat="server"  Width="120px" Height="27px" Text="Comio Todo"  ToolTip="El Paciente comio toda su comida"   OnClick="Calcular_d" />
                     <asp:Button ID="btn_rd_2" CssClass="btn btn-danger" runat="server"  Width="120px" Height="27px" Text="Restaurar"  ToolTip="Restaurar valores originales"  OnClick="Restablecer_d"  />
                       N° Reg.  <asp:Label type="text" id="num_d"  runat="server"  />
                       </div>
                        </div>
                    </div>
              
                </div>
                <div class="panel-body" style="width: 100% ; margin:10px;">

       

                  <asp:GridView ID="grilladesayuno" runat="server" Width="100%" 
                        HorizontalAlign="Right" OnPageIndexChanging="grilladesayuno_PageIndexChanging"
                        AutoGenerateColumns="false" AllowPaging="true"  GridLines="Both" 
                        PageSize="12000"  HeaderStyle-HorizontalAlign="Right" 
                        
                        DataKeyNames="_Cod_pedido,_Cod_tipo_comida,_Cod_tipo_alimentos,_Calorias, _Proteinas, _Lipidos,_Hyc,_Sodio,_Ing_gr_c,_Ing_cc_c,_Ing_id,_Ing_cc_total,_Cod_tipo_distribucion,_Porcentaje,
                       _Sub_calorias,_Sub_proteinas,_Sub_lipidos,_Sub_hyc,_Sub_sodio,_Sub_cc_total, _Ajuste_calorias,_Ajuste_proteinas,_Ajuste_lipidos,_Ajuste_hyc,_Ajuste_sodio,_Ajuste_cc_total,_Mixto"  
                        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"     EmptyDataText="Estimado  Usuario, No existen Datos"
                        RowStyle-CssClass="rows"  CellPadding="4"  Font-Size="11px" 
                       >
                        <Columns>
                               
                                  
                                      
                                 <asp:BoundField DataField="_Nom_tipo_alimentos" HeaderText="Alimento" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Cantidad" HeaderText="Cant." HeaderStyle-Width="0.5%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                    <asp:TemplateField HeaderText="% C." HeaderStyle-Width="1%"  ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate   >
                                     <asp:TextBox type="text" ID="txtporcentaje_d" runat="server" placeholder="0"   MaxLength="4"  onkeypress="return validNumericos(event)"   OnTextChanged="txtporcentaje_d_TextChanged"  AutoPostBack="true"   Style="height: 25px; width: 35px" />                  
                                      <asp:HiddenField ID="h_c" runat="server" Value='<%#Eval("_Calorias") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="h_p" runat="server" Value='<%#Eval("_Proteinas") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="h_l" runat="server" Value='<%#Eval("_Lipidos") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="h_hyc" runat="server" Value='<%#Eval("_Hyc") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="h_s" runat="server" Value='<%#Eval("_Sodio") %>'> </asp:HiddenField>
                                      <asp:HiddenField ID="h_mixto" runat="server" Value='<%#Eval("_Mixto") %>'> </asp:HiddenField>
                                       <asp:HiddenField ID="h_distribucion" runat="server" Value='<%#Eval("_Cod_tipo_distribucion") %>'> </asp:HiddenField>
                                    
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="_Gr_i" HeaderText="GR. I." HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="Right" />
                                  <asp:BoundField DataField="_Ing_gr_c" HeaderText="GR. C." HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="Right" />
                              
                                 <asp:BoundField DataField="_Ing_calorias" HeaderText="Calorias" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_proteinas" HeaderText="Proteinas" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_lipidos" HeaderText="Lipidos" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_hyc" HeaderText="H&C" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_sodio" HeaderText="Sodio" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                <asp:BoundField DataField="_Cc_i" HeaderText="CC I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />

                                  <asp:TemplateField HeaderText="CC C." HeaderStyle-Width="1%"  ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate   >
                                     <asp:TextBox type="text" ID="txtccd_c" runat="server" placeholder="0"   MaxLength="4"  onkeypress="return validNumericos(event)"  onchange="ingesta_d();"  Enabled="false"  Style="height: 25px; width: 35px" />                  
                                                              
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    
      
                        </div>  
             
<div style="overflow-x:auto; padding-left:20px">
  <table>
    <tr>
      <th  style=" width:5%"></th>
       <th style=" width:1%; text-align:right"></th>
       <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
    </tr>
    
 
    <tr>
      <td>SUB TOTALES</td>

       <td style=" width:1%; text-align:right"></td>
       <td style=" width:1%; text-align:right"></td>
       <td style=" width:1%; text-align:right"> </td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sd_gr_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sd_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sd_p" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sd_l" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sd_hyc" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sd_s" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sd_total" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>

      <tr>
      <td>  AJUSTE</td>
       <td style=" width:1%; text-align:right"></td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
      <td style=" width:0.3%; text-align:right"> <asp:TextBox type="text" ID="d_c" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" />   </td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="d_p" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"    Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="d_l" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"    Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="d_hyc" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="d_s" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"      Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="d_total" runat="server" placeholder="0"  MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"    Style="height: 25px; width: 50px; text-align:right" /></td>
    </tr>
  </table>
</div>
            </ContentTemplate>
            <Triggers>
              
            </Triggers>
        </asp:UpdatePanel>

            </div>

               <div class="panel panel-success">
           <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>

                <div class="panel-heading" style="width: 100%; height: 40px;">
                    <div class="col-sm-12">
                        <div class="form-group">
                    
                     <asp:Label ID="Label1" runat="server" Text=" Colaciòn Mañana"  Font-Size="16px"  style=" color:#3498DB; font-weight:bold" ></asp:Label>   
               
                     <div style="text-align:right;  margin-top:0;" >
                     <asp:Button ID="btn_todo_c1" CssClass="btn btn-success" runat="server"  Width="120px" Height="27px" Text="Comio Todo"  ToolTip="El Paciente comio toda su comida"   OnClick="Calcular_c1" />
                     <asp:Button ID="btn_rc1_2" CssClass="btn btn-danger" runat="server"  Width="120px" Height="27px" Text="Restaurar"  ToolTip="Restaurar valores originales"  OnClick="Restablecer_c1"  />
                      N° Reg.  <asp:Label type="text" id="num_c1"  runat="server"  />
                     </div>
                        </div>
                    </div>
                    
                </div>
                <div class="panel-body" style="width: 100%; margin:10px;">
                
                 <asp:GridView ID="grillacolacion_man" runat="server" Width="100%" HorizontalAlign="Right" OnPageIndexChanging="grillacolacion_man_PageIndexChanging"
                        AutoGenerateColumns="false" AllowPaging="true"  GridLines="Both" PageSize="12000"    EmptyDataText="Estimado  Usuario, No existen Datos"
                               DataKeyNames="_Cod_pedido,_Cod_tipo_comida,_Cod_tipo_alimentos,_Calorias, _Proteinas, _Lipidos,_Hyc,_Sodio,_Ing_gr_c,_Ing_cc_c,_Ing_id,_Ing_cc_total,_Cod_tipo_distribucion,_Porcentaje,
                                  _Sub_calorias,_Sub_proteinas,_Sub_lipidos,_Sub_hyc,_Sub_sodio,_Sub_cc_total, _Ajuste_calorias,_Ajuste_proteinas,_Ajuste_lipidos,_Ajuste_hyc,_Ajuste_sodio,_Ajuste_cc_total,_Mixto" 
                          CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"  CellPadding="4"  Font-Size="11px" >
                        <Columns>
                         
                                 <asp:BoundField DataField="_Nom_tipo_alimentos" HeaderText="Alimento" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT"  ControlStyle-Font-Size="12px" />
                                   <asp:BoundField DataField="_Cantidad" HeaderText="Cant." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                   <asp:TemplateField HeaderText="% C." HeaderStyle-Width="1%">
                                    <ItemTemplate   >
                                               <asp:TextBox type="text" ID="txtporcentaje_c1" runat="server" placeholder="0"   MaxLength="4"  onkeypress="return validNumericos(event)"  OnTextChanged="txtporcentaje_c1_TextChanged"  AutoPostBack="true"     Style="height: 25px; width: 35px" />                  
                                              <asp:HiddenField ID="hc1_c" runat="server" Value='<%#Eval("_Calorias") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hc1_p" runat="server" Value='<%#Eval("_Proteinas") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hc1_l" runat="server" Value='<%#Eval("_Lipidos") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hc1_hyc" runat="server" Value='<%#Eval("_Hyc") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hc1_s" runat="server" Value='<%#Eval("_Sodio") %>'> </asp:HiddenField>
                                      <asp:HiddenField ID="hc1_mixto" runat="server" Value='<%#Eval("_Mixto") %>'> </asp:HiddenField>
                                      <asp:HiddenField ID="hc1_distribucion" runat="server" Value='<%#Eval("_Cod_tipo_distribucion") %>'> </asp:HiddenField>
                                    
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="_Gr_i" HeaderText="GR. I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="_Ing_gr_c" HeaderText="GR. C." HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="Right" />                              
                                 <asp:BoundField DataField="_Ing_calorias" HeaderText="Calorias" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_proteinas" HeaderText="Proteinas" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_lipidos" HeaderText="Lipidos" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_hyc" HeaderText="H&C" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_sodio" HeaderText="Sodio" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                  <asp:BoundField DataField="_Cc_i" HeaderText="CC I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                  <asp:TemplateField HeaderText="CC C." HeaderStyle-Width="1%"  ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate   >
                                        <asp:TextBox type="text" ID="txtccc1_c" runat="server" placeholder="0"   MaxLength="4" Enabled="false"  onkeypress="return validNumericos(event)" onchange="ingesta_c1();"    Style="height: 25px; width: 35px" />           
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
           

                </div>

                <div style="overflow-x:auto; padding-left:20px">
  <table>
    <tr>
      <th  style=" width:5%"></th>
       <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
    </tr>
    
 
    <tr>
      <td>SUB TOTALES</td>
       <td style=" width:1%; text-align:right"></td>
        <td style=" width:1%; text-align:right"> </td>
        <td style=" width:1%; text-align:right"> </td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sc1_gr_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sc1_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sc1_p" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sc1_l" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sc1_hyc" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sc1_s" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sc1_total" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>

      <tr>
      <td>  AJUSTE</td>
       <td style=" width:1%; text-align:right"></td>
      <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
         <td style=" width:1%; text-align:right"> </td>
      <td style=" width:0.3%; text-align:right"> <asp:TextBox type="text" ID="c1_c" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"    Style="height: 25px; width: 50px; text-align:right" />   </td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c1_p" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"    Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c1_l" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"   Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c1_hyc" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"       Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c1_s" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"      ID="c1_total" runat="server"  Style="height: 25px; width: 50px; text-align:right" /></td>
    </tr>
  </table>
</div>
  
        </ContentTemplate>
            <Triggers>
              
            </Triggers>
        </asp:UpdatePanel>
            </div>


               <div class="panel panel-success">

                          <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>

                <div class="panel-heading" style="width: 100%; height: 40px;">
                    <div class="col-sm-12">
                        <div class="form-group">

                      <asp:Label ID="Label2" runat="server" Text="Almuerzo"  Font-Size="16px"  style=" color:#3498DB; font-weight:bold" ></asp:Label>   
                <div style="text-align:right;  margin-top:0;" >
                     <asp:Button ID="btn_todo_a" CssClass="btn btn-success" runat="server"  Width="120px" Height="27px" Text="Comio Todo"  ToolTip="El Paciente comio toda su comida"   OnClick="Calcular_a" />
                     <asp:Button ID="btn_ra_2" CssClass="btn btn-danger" runat="server"  Width="120px" Height="27px" Text="Restaurar"  ToolTip="Restaurar valores originales"  OnClick="Restablecer_a"  />
                    
                      N° Reg.  <asp:Label type="text" id="num_a"  runat="server"  />
                     </div>
                        </div>
                    </div>
                     
                </div>
                <div class="panel-body" style="width: 100%; margin:10px;">
                
                 <asp:GridView ID="grillaalmuerzo" runat="server" Width="100%" HorizontalAlign="Center" OnPageIndexChanging="grillaalmuerzo_PageIndexChanging"
                        AutoGenerateColumns="false" AllowPaging="true"  GridLines="Both" PageSize="12000"
                         DataKeyNames="_Cod_pedido,_Cod_tipo_comida,_Cod_tipo_alimentos,_Calorias, _Proteinas, _Lipidos,_Hyc,_Sodio,_Ing_gr_c,_Ing_cc_c,_Ing_id,_Ing_cc_total, _Cod_tipo_distribucion,_Porcentaje,
                                  _Sub_calorias,_Sub_proteinas,_Sub_lipidos,_Sub_hyc,_Sub_sodio,_Sub_cc_total, _Ajuste_calorias,_Ajuste_proteinas,_Ajuste_lipidos,_Ajuste_hyc,_Ajuste_sodio,_Ajuste_cc_total,_Mixto"  
                               CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"   EmptyDataText="Estimado  Usuario, No existen Datos"  RowStyle-CssClass="rows"  CellPadding="4"  Font-Size="11px" >
                        <Columns>
                         
                                 <asp:BoundField DataField="_Nom_tipo_alimentos" HeaderText="Alimento" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT"  ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Cantidad" HeaderText="Cant." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                   <asp:TemplateField HeaderText="% C." HeaderStyle-Width="1%">
                                    <ItemTemplate   >
                                         <asp:TextBox type="text" ID="txtporcentaje_a" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  OnTextChanged="txtporcentaje_a_TextChanged"  AutoPostBack="true"     Style="height: 25px; width: 35px" />                                   
                                              <asp:HiddenField ID="ha_c" runat="server" Value='<%#Eval("_Calorias") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="ha_p" runat="server" Value='<%#Eval("_Proteinas") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="ha_l" runat="server" Value='<%#Eval("_Lipidos") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="ha_hyc" runat="server" Value='<%#Eval("_Hyc") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="ha_s" runat="server" Value='<%#Eval("_Sodio") %>'> </asp:HiddenField>
                                      <asp:HiddenField ID="ha_mixto" runat="server" Value='<%#Eval("_Mixto") %>'> </asp:HiddenField>
                                      <asp:HiddenField ID="ha_distribucion" runat="server" Value='<%#Eval("_Cod_tipo_distribucion") %>'> </asp:HiddenField>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="_Gr_i" HeaderText="GR. I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="_Ing_gr_c" HeaderText="GR. C." HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="Right" />  
                                 <asp:BoundField DataField="_Ing_calorias" HeaderText="Calorias" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_proteinas" HeaderText="Proteinas" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_lipidos" HeaderText="Lipidos" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_hyc" HeaderText="H&C" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_sodio" HeaderText="Sodio" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Cc_i" HeaderText="CC I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                  <asp:TemplateField HeaderText="CC C." HeaderStyle-Width="1%"  ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate   >
                                        <asp:TextBox type="text" ID="txtcca_c" runat="server" placeholder="0"  Enabled="false"  MaxLength="4" onkeypress="return validNumericos(event)"  onchange="ingesta_a();"    Style="height: 25px; width: 35px" />           
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
           

                </div>

                               <div style="overflow-x:auto; padding-left:20px">
  <table>
    <tr>
      <th  style=" width:5%"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
    </tr>
    
 
    <tr>
      <td>SUB TOTALES</td>
       <td style=" width:1%; text-align:right"></td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> <asp:Label ID="sa_gr_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sa_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sa_p" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sa_l" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sa_hyc" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sa_s" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sa_total" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>

      <tr>
      <td>  AJUSTE</td>
       <td style=" width:1%; text-align:right"></td>
       <td style=" width:1%; text-align:right">  </td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
      <td style=" width:0.3%; text-align:right"> <asp:TextBox type="text" ID="a_c" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"      Style="height: 25px; width: 50px; text-align:right" />   </td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="a_p" runat="server"  placeholder="0"    MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"      Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="a_l" runat="server" placeholder="0"    MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"      Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="a_hyc" runat="server" placeholder="0"     MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"      Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="a_s" runat="server" placeholder="0"    MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="a_total" runat="server"  placeholder="0"  MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"   Style="height: 25px; width: 50px; text-align:right" /></td>
    </tr>
  </table>
</div>
         
        </ContentTemplate>
            <Triggers>
           
            </Triggers>
        </asp:UpdatePanel>
            </div>

           


               <div class="panel panel-success">
                          <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>


                <div class="panel-heading" style="width: 100%; height: 40px;">
                    <div class="col-sm-12">
                        <div class="form-group">
           
                       <asp:Label ID="Label3" runat="server" Text="Once "  Font-Size="16px"  style=" color:#3498DB; font-weight:bold" ></asp:Label>   
                 <div style="text-align:right;  margin-top:0;" >
                     <asp:Button ID="btn_todo_o" CssClass="btn btn-success" runat="server"  Width="120px" Height="27px" Text="Comio Todo"  ToolTip="El Paciente comio toda su comida"   OnClick="Calcular_o" />
                     <asp:Button ID="btn_ro_2" CssClass="btn btn-danger" runat="server"  Width="120px" Height="27px" Text="Restaurar"  ToolTip="Restaurar valores originales"  OnClick="Restablecer_o"  />
                    
                       N° Reg.  <asp:Label type="text" id="num_o"  runat="server"  />
                     </div>
                        </div>
                    </div>
                     
                </div>
                <div class="panel-body" style="width: 100%; margin:10px;">

                
                     <asp:GridView ID="grillaonce" runat="server" Width="100%" HorizontalAlign="Center" OnPageIndexChanging="grillaonce_PageIndexChanging"
                        AutoGenerateColumns="false" AllowPaging="true"  GridLines="Both" PageSize="12000"
               DataKeyNames="_Cod_pedido,_Cod_tipo_comida,_Cod_tipo_alimentos,_Calorias, _Proteinas, _Lipidos,_Hyc,_Sodio,_Ing_gr_c,_Ing_cc_c,_Ing_id,_Ing_cc_total,_Cod_tipo_distribucion,_Porcentaje,
                       _Sub_calorias,_Sub_proteinas,_Sub_lipidos,_Sub_hyc,_Sub_sodio,_Sub_cc_total, _Ajuste_calorias,_Ajuste_proteinas,_Ajuste_lipidos,_Ajuste_hyc,_Ajuste_sodio,_Ajuste_cc_total,_Mixto"  
                 CssClass="mydatagrid" PagerStyle-CssClass="pager"   EmptyDataText="Estimado  Usuario, No existen Datos"  HeaderStyle-CssClass="header" RowStyle-CssClass="rows"  CellPadding="4"  Font-Size="11px" >
                        <Columns>
                         
                                 <asp:BoundField DataField="_Nom_tipo_alimentos" HeaderText="Alimento" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT"  ControlStyle-Font-Size="12px" />
                             <asp:BoundField DataField="_Cantidad" HeaderText="Cant." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                   <asp:TemplateField HeaderText="% C." HeaderStyle-Width="1%">
                                    <ItemTemplate   >
                                              <asp:TextBox type="text" ID="txtporcentaje_o" runat="server" placeholder="0"   MaxLength="4"  onkeypress="return validNumericos(event)"   OnTextChanged="txtporcentaje_o_TextChanged"  AutoPostBack="true"     Style="height: 25px; width: 35px" />                         
                                              <asp:HiddenField ID="ho_c" runat="server" Value='<%#Eval("_Calorias") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="ho_p" runat="server" Value='<%#Eval("_Proteinas") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="ho_l" runat="server" Value='<%#Eval("_Lipidos") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="ho_hyc" runat="server" Value='<%#Eval("_Hyc") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="ho_s" runat="server" Value='<%#Eval("_Sodio") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="ho_mixto" runat="server" Value='<%#Eval("_Mixto") %>'> </asp:HiddenField>
                                      <asp:HiddenField ID="ho_distribucion" runat="server" Value='<%#Eval("_Cod_tipo_distribucion") %>'> </asp:HiddenField>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="_Gr_i" HeaderText="GR. I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="_Ing_gr_c" HeaderText="GR. C." HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="Right" />  
                                 <asp:BoundField DataField="_Ing_calorias" HeaderText="Calorias" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_proteinas" HeaderText="Proteinas" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_lipidos" HeaderText="Lipidos" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_hyc" HeaderText="H&C" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_sodio" HeaderText="Sodio" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                      <asp:BoundField DataField="_Cc_i" HeaderText="CC I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                  <asp:TemplateField HeaderText="CC C." HeaderStyle-Width="1%"  ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate   >
                                        <asp:TextBox type="text" ID="txtcco_c" runat="server" MaxLength="4" Enabled="false" placeholder="0"  onkeypress="return validNumericos(event)"   onchange="ingesta_o();"      Style="height: 25px; width: 35px" />           
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
           
                 

                </div>

                                             <div style="overflow-x:auto; padding-left:20px">
  <table>
    <tr>
      <th  style=" width:5%"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
    </tr>
    
 
    <tr>
      <td>SUB TOTALES</td>
       <td style=" width:1%; text-align:right"></td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> <asp:Label ID="so_gr_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="so_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="so_p" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="so_l" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="so_hyc" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="so_s" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="so_total" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>

      <tr>
      <td>  AJUSTE TOTAL</td>
       <td style=" width:1%; text-align:right"></td>
      <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
      <td style=" width:0.3%; text-align:right"> <asp:TextBox type="text" ID="o_c" runat="server" placeholder="0"  onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" />   </td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="o_p" runat="server" placeholder="0"  onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="o_l" runat="server" placeholder="0"  onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="o_hyc" runat="server" placeholder="0" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="o_s" runat="server" placeholder="0"  onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"      Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="o_total" runat="server" placeholder="0"  onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"       Style="height: 25px; width: 50px; text-align:right" /></td>
    </tr>
  </table>
</div>


        </ContentTemplate>
            <Triggers>
          
            </Triggers>
        </asp:UpdatePanel>
            </div>


                <div class="panel panel-success">

             <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>


                <div class="panel-heading" style="width: 100%; height: 40px;">
                    <div class="col-sm-12">
                        <div class="form-group">

                           <asp:Label ID="Label4" runat="server" Text="Cena "  Font-Size="16px"  style=" color:#3498DB; font-weight:bold" ></asp:Label>   
                <div style="text-align:right;  margin-top:0;" >
                     <asp:Button ID="btn_todo_c" CssClass="btn btn-success" runat="server"  Width="120px" Height="27px" Text="Comio Todo"  ToolTip="El Paciente comio toda su comida"   OnClick="Calcular_c" />
                     <asp:Button ID="btn_rc_2" CssClass="btn btn-danger" runat="server"  Width="120px" Height="27px" Text="Restaurar"  ToolTip="Restaurar valores originales"  OnClick="Restablecer_c"  />
                           N° Reg.  <asp:Label type="text" id="num_c"  runat="server"  />
                     </div>
                        </div>
                    </div>
                
                </div>
                <div class="panel-body" style="width: 100%; margin:10px;">
                
                 <asp:GridView ID="grillacena" runat="server" Width="100%" HorizontalAlign="Center" OnPageIndexChanging="grillacena_PageIndexChanging"
                        AutoGenerateColumns="false" AllowPaging="true"  GridLines="Both" PageSize="12000"
                         DataKeyNames="_Cod_pedido,_Cod_tipo_comida,_Cod_tipo_alimentos,_Calorias, _Proteinas, _Lipidos,_Hyc,_Sodio,_Ing_gr_c,_Ing_cc_c,_Ing_id,_Ing_cc_total,_Cod_tipo_distribucion,_Porcentaje,
                                _Sub_calorias,_Sub_proteinas,_Sub_lipidos,_Sub_hyc,_Sub_sodio,_Sub_cc_total, _Ajuste_calorias,_Ajuste_proteinas,_Ajuste_lipidos,_Ajuste_hyc,_Ajuste_sodio,_Ajuste_cc_total,_Mixto"  
                           CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"   EmptyDataText="Estimado  Usuario, No existen Datos"  RowStyle-CssClass="rows"  CellPadding="4"  Font-Size="11px" >
                        <Columns>
                         
                                 <asp:BoundField DataField="_Nom_tipo_alimentos" HeaderText="Alimento" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT"  ControlStyle-Font-Size="12px" />
                               <asp:BoundField DataField="_Cantidad" HeaderText="Cant." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                   <asp:TemplateField HeaderText="% C." HeaderStyle-Width="1%">
                                    <ItemTemplate   >
                                           <asp:TextBox type="text" ID="txtporcentaje_c" runat="server" MaxLength="4" placeholder="0"   onkeypress="return validNumericos(event)"   OnTextChanged="txtporcentaje_c_TextChanged"  AutoPostBack="true"    Style="height: 25px; width: 35px" />                          
                                             <asp:HiddenField ID="hc_c" runat="server" Value='<%#Eval("_Calorias") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hc_p" runat="server" Value='<%#Eval("_Proteinas") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hc_l" runat="server" Value='<%#Eval("_Lipidos") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hc_hyc" runat="server" Value='<%#Eval("_Hyc") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hc_s" runat="server" Value='<%#Eval("_Sodio") %>'> </asp:HiddenField>
                                      <asp:HiddenField ID="hc_mixto" runat="server" Value='<%#Eval("_Mixto") %>'> </asp:HiddenField>
                                   <asp:HiddenField ID="hc_distribucion" runat="server" Value='<%#Eval("_Cod_tipo_distribucion") %>'> </asp:HiddenField>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:BoundField DataField="_Gr_i" HeaderText="GR. I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="_Ing_gr_c" HeaderText="GR. C." HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="Right" />  
                                 
                                 <asp:BoundField DataField="_Ing_calorias" HeaderText="Calorias" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_proteinas" HeaderText="Proteinas" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_lipidos" HeaderText="Lipidos" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_hyc" HeaderText="H&C" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_sodio" HeaderText="Sodio" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                    <asp:BoundField DataField="_Cc_i" HeaderText="CC I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                  <asp:TemplateField HeaderText="CC C." HeaderStyle-Width="1%"  ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate   >
                                        <asp:TextBox type="text" ID="txtccc_c" runat="server" MaxLength="4" Enabled="false"  placeholder="0"   onkeypress="return validNumericos(event)"   onchange="ingesta_c();"     Style="height: 25px; width: 35px" />           
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
           

                </div>

                                                           <div style="overflow-x:auto; padding-left:20px">
  <table>
    <tr>
      <th  style=" width:5%"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
    </tr>
    
 
    <tr>
      <td>SUB TOTALES</td>
       <td style=" width:1%; text-align:right"></td>
        <td style=" width:1%; text-align:right"> </td>
        <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> <asp:Label ID="sc_gr_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sc_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sc_p" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sc_l" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sc_hyc" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sc_s" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sc_total" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>

      <tr>
      <td>  AJUSTE TOTAL</td>
       <td style=" width:1%; text-align:right"></td>
      <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
      <td style=" width:0.3%; text-align:right"> <asp:TextBox type="text" ID="c_c" runat="server" placeholder="0"  MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"      Style="height: 25px; width: 50px; text-align:right" />   </td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c_p" runat="server" placeholder="0"  MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c_l" runat="server" placeholder="0"  MaxLength="4" onkeypress="return validNumericos(event)"    onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c_hyc" runat="server" placeholder="0"  MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"      Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c_s" runat="server" placeholder="0"  MaxLength="4" onkeypress="return validNumericos(event)"   onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c_total" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"       Style="height: 25px; width: 50px; text-align:right" /></td>
    </tr>
  </table>
</div>

        
        </ContentTemplate>
            <Triggers>
            
            </Triggers>
        </asp:UpdatePanel>
            </div>
            

                   <div class="panel panel-success">

                              <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
   
                <div class="panel-heading" style="width: 100%; height: 40px;">
                    <div class="col-sm-12">
                        <div class="form-group">

                        <asp:Label ID="Label5" runat="server" Text="Colaciòn Nocturna "  Font-Size="16px"  style=" color:#3498DB; font-weight:bold" ></asp:Label>   
                  <div style="text-align:right;  margin-top:0;" >
                     <asp:Button ID="btn_todo_c2" CssClass="btn btn-success" runat="server"  Width="120px" Height="27px" Text="Comio Todo"  ToolTip="El Paciente comio toda su comida"   OnClick="Calcular_c2" />
                     <asp:Button ID="btn_rc2_2" CssClass="btn btn-danger" runat="server"  Width="120px" Height="27px" Text="Restaurar"  ToolTip="Restaurar valores originales"  OnClick="Restablecer_c2"  />
                     N° Reg.  <asp:Label type="text" id="num_c2"  runat="server"  />
                   
                     </div>
                        </div>
                    </div>

                  
                </div>
                <div class="panel-body" style="width: 100%; margin:10px;">
                 <asp:GridView ID="grillacolacion_noc" runat="server" Width="100%" HorizontalAlign="Center" OnPageIndexChanging="grillacolacion_noc_PageIndexChanging"
                        AutoGenerateColumns="false" AllowPaging="true"  GridLines="Both" PageSize="12000"
                        DataKeyNames="_Cod_pedido,_Cod_tipo_comida,_Cod_tipo_alimentos,_Calorias, _Proteinas, _Lipidos,_Hyc,_Sodio,_Ing_gr_c,_Ing_cc_c,_Ing_id,_Ing_cc_total,_Cod_tipo_distribucion,_Porcentaje,
                                _Sub_calorias,_Sub_proteinas,_Sub_lipidos,_Sub_hyc,_Sub_sodio,_Sub_cc_total, _Ajuste_calorias,_Ajuste_proteinas,_Ajuste_lipidos,_Ajuste_hyc,_Ajuste_sodio,_Ajuste_cc_total,_Mixto"  
                          CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"    EmptyDataText="Estimado  Usuario, No existen Datos"  RowStyle-CssClass="rows"  CellPadding="4"  Font-Size="11px" >
                        <Columns>
                         
                                 <asp:BoundField DataField="_Nom_tipo_alimentos" HeaderText="Alimento" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT"  ControlStyle-Font-Size="12px" />
                                  <asp:BoundField DataField="_Cantidad" HeaderText="Cant." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                   <asp:TemplateField HeaderText="% C." HeaderStyle-Width="1%">
                                    <ItemTemplate   >
                                         <asp:TextBox type="text" ID="txtporcentaje_c2" runat="server"  placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"   OnTextChanged="txtporcentaje_c2_TextChanged"  AutoPostBack="true"    Style="height: 25px; width: 35px" /> 
                                                  <asp:HiddenField ID="hc2_c" runat="server" Value='<%#Eval("_Calorias") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hc2_p" runat="server" Value='<%#Eval("_Proteinas") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hc2_l" runat="server" Value='<%#Eval("_Lipidos") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hc2_hyc" runat="server" Value='<%#Eval("_Hyc") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hc2_s" runat="server" Value='<%#Eval("_Sodio") %>'> </asp:HiddenField> 
                                      <asp:HiddenField ID="hc2_mixto" runat="server" Value='<%#Eval("_Mixto") %>'> </asp:HiddenField>  
                                        <asp:HiddenField ID="hc2_distribucion" runat="server" Value='<%#Eval("_Cod_tipo_distribucion") %>'> </asp:HiddenField>                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="_Gr_i" HeaderText="GR. I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="_Ing_gr_c" HeaderText="GR. C." HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="_Ing_calorias" HeaderText="Calorias" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_proteinas" HeaderText="Proteinas" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_lipidos" HeaderText="Lipidos" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_hyc" HeaderText="H&C" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_sodio" HeaderText="Sodio" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Cc_i" HeaderText="CC I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                  <asp:TemplateField HeaderText="CC C." HeaderStyle-Width="1%"  ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate   >
                                        <asp:TextBox type="text" ID="txtccc2_c" runat="server" placeholder="0"  Enabled="false"  MaxLength="4" onkeypress="return validNumericos(event)"   onchange="ingesta_c2();"       Style="height: 25px; width: 35px" />           
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>

                                                                         <div style="overflow-x:auto; padding-left:20px">
  <table>
    <tr>
      <th  style=" width:5%"></th>
       <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
    </tr>
    
 
    <tr>
      <td>SUB TOTALES</td>
       <td style=" width:1%; text-align:right"></td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> <asp:Label ID="sc2_gr_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sc2_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sc2_p" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sc2_l" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sc2_hyc" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sc2_s" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sc2_total" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>

      <tr>
      <td>  AJUSTE TOTAL</td>
       <td style=" width:1%; text-align:right"></td>
       <td style=" width:1%; text-align:right"></td>
        <td style=" width:1%; text-align:right"> </td>
        <td style=" width:1%; text-align:right"> </td>
      <td style=" width:0.3%; text-align:right"> <asp:TextBox type="text" ID="c2_c"  runat="server" placeholder="0"  MaxLength="4" onkeypress="return validNumericos(event)"   onchange="Calcular_resumen();"       Style="height: 25px; width: 50px; text-align:right" />   </td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c2_p" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"       Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c2_l" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"       Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c2_hyc" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"      Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c2_s" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="c2_total" runat="server" placeholder="0"  MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"       Style="height: 25px; width: 50px; text-align:right" /></td>
    </tr>
  </table>
</div>
      
        </ContentTemplate>
            <Triggers>
              
            </Triggers>
        </asp:UpdatePanel>
            </div>

                      <div class="panel panel-success">
                                 <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
   
                <div class="panel-heading" style="width: 100%; height: 40px;">
                    <div class="col-sm-12">
                        <div class="form-group">


                           <asp:Label ID="Label6" runat="server" Text="Colaciòn Extra "  Font-Size="16px"  style=" color:#3498DB; font-weight:bold" ></asp:Label>   
                 <div style="text-align:right;  margin-top:0;" >
                     <asp:Button ID="btn_todo_ce" CssClass="btn btn-success" runat="server"  Width="120px" Height="27px" Text="Comio Todo"  ToolTip="El Paciente comio toda su comida"   OnClick="Calcular_ce" />
                     <asp:Button ID="btn_rce_2" CssClass="btn btn-danger" runat="server"  Width="120px" Height="27px" Text="Restaurar"  ToolTip="Restaurar valores originales"  OnClick="Restablecer_ce"  />
                        N° Reg.  <asp:Label type="text" id="num_ce"  runat="server"  />
                        </div>
                        </div>
                    </div>
                   
                </div>
                <div class="panel-body" style="width: 100%; margin:10px;">
                 <asp:GridView ID="grillaextra" runat="server" Width="100%" HorizontalAlign="Center" OnPageIndexChanging="grillaextra_PageIndexChanging"
                        AutoGenerateColumns="false" AllowPaging="true"  GridLines="Both" PageSize="12000"
                        DataKeyNames="_Cod_pedido,_Cod_tipo_comida,_Cod_tipo_alimentos,_Calorias, _Proteinas, _Lipidos,_Hyc,_Sodio,_Ing_gr_c,_Ing_cc_c,_Ing_id,_Ing_cc_total,_Cod_tipo_distribucion,_Porcentaje,
                                _Sub_calorias,_Sub_proteinas,_Sub_lipidos,_Sub_hyc,_Sub_sodio,_Sub_cc_total, _Ajuste_calorias,_Ajuste_proteinas,_Ajuste_lipidos,_Ajuste_hyc,_Ajuste_sodio,_Ajuste_cc_total,_Mixto"  
                          CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"   EmptyDataText="Estimado  Usuario, No existen Datos"  RowStyle-CssClass="rows"  CellPadding="4"  Font-Size="11px" >
                        <Columns>
                         
                                 <asp:BoundField DataField="_Nom_tipo_alimentos" HeaderText="Alimento" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT"  ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Cantidad" HeaderText="Cant." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                   <asp:TemplateField HeaderText="% C." HeaderStyle-Width="1%">
                                    <ItemTemplate   >
                                             <asp:TextBox type="text" ID="txtporcentaje_ce" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"   OnTextChanged="txtporcentaje_ce_TextChanged"  AutoPostBack="true"       Style="height: 25px; width: 35px" />                           
                                                <asp:HiddenField ID="hce_c" runat="server" Value='<%#Eval("_Calorias") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hce_p" runat="server" Value='<%#Eval("_Proteinas") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hce_l" runat="server" Value='<%#Eval("_Lipidos") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hce_hyc" runat="server" Value='<%#Eval("_Hyc") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hce_s" runat="server" Value='<%#Eval("_Sodio") %>'> </asp:HiddenField>
                                      <asp:HiddenField ID="hce_mixto" runat="server" Value='<%#Eval("_Mixto") %>'> </asp:HiddenField>
                                      <asp:HiddenField ID="hce_distribucion" runat="server" Value='<%#Eval("_Cod_tipo_distribucion") %>'> </asp:HiddenField>  
                                   
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:BoundField DataField="_Gr_i" HeaderText="GR. I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="_Ing_gr_c" HeaderText="GR. C." HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="_Ing_calorias" HeaderText="Calorias" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_proteinas" HeaderText="Proteinas" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_lipidos" HeaderText="Lipidos" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_hyc" HeaderText="H&C" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_sodio" HeaderText="Sodio" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                  <asp:BoundField DataField="_Cc_i" HeaderText="CC I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                  <asp:TemplateField HeaderText="CC C." HeaderStyle-Width="1%"  ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate   >
                                        <asp:TextBox type="text" ID="txtccce_c" runat="server" placeholder="0" Enabled="false"   MaxLength="4" onkeypress="return validNumericos(event)"   onchange="ingesta_ce();"      Style="height: 25px; width: 35px" />           
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
                
                                                                         <div style="overflow-x:auto; padding-left:20px">
  <table>
    <tr>
      <th  style=" width:5%"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
    </tr>
    
 
    <tr>
      <td>SUB TOTALES</td>
        <td style=" width:1%; text-align:right"></td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> <asp:Label ID="sce_gr_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sce_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="sce_p" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sce_l" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sce_hyc" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sce_s" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="sce_total" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>

      <tr>
      <td>  AJUSTE TOTAL</td>
       <td style=" width:1%; text-align:right"></td>
      <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> </td>
      <td style=" width:0.3%; text-align:right"> <asp:TextBox type="text" ID="ce_c" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"       Style="height: 25px; width: 50px; text-align:right" />   </td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="ce_p" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"        Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="ce_l" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"    Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="ce_hyc" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"       Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="ce_s" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"      Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="ce_total" runat="server" placeholder="0"  MaxLength="4" onkeypress="return validNumericos(event)"   onchange="Calcular_resumen();"       Style="height: 25px; width: 50px; text-align:right" /></td>
    </tr>
  </table>
</div>
       
        </ContentTemplate>
            <Triggers>
           
            </Triggers>
        </asp:UpdatePanel>
            </div>

                      <div class="panel panel-success">

                                 <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
   

                <div class="panel-heading" style="width: 100%; height: 40px;">
                    <div class="col-sm-12">
                        <div class="form-group">


                      <asp:Label ID="Label7" runat="server" Text="Hidricos "  Font-Size="16px"  style=" color:#3498DB; font-weight:bold" ></asp:Label>   
               <div style="text-align:right;  margin-top:0;" >
                     <asp:Button ID="btn_todo_hco" CssClass="btn btn-success" runat="server"  Width="120px" Height="27px" Text="Comio Todo"  ToolTip="El Paciente comio toda su comida"   OnClick="Calcular_hco" />
                     <asp:Button ID="btn_rhco_2" CssClass="btn btn-danger" runat="server"  Width="120px" Height="27px" Text="Restaurar"  ToolTip="Restaurar valores originales"  OnClick="Restablecer_hco"  />
                   
                    N° Reg.  <asp:Label type="text" id="num_h"  runat="server"  />
                     </div>
                        </div>
                    </div>
                    
                </div>
                <div class="panel-body" style="width: 100%; margin:10px;">
                 <asp:GridView ID="grillahidrico" runat="server" Width="100%" HorizontalAlign="Center" OnPageIndexChanging="grillahidrico_PageIndexChanging"
                        AutoGenerateColumns="false" AllowPaging="true"  GridLines="Both" PageSize="12000"
                        DataKeyNames="_Cod_pedido,_Cod_tipo_comida,_Cod_tipo_alimentos,_Calorias, _Proteinas, _Lipidos,_Hyc,_Sodio,_Ing_gr_c,_Ing_cc_c,_Ing_id,_Ing_cc_total,_Cod_tipo_distribucion,_Porcentaje,
                                _Sub_calorias,_Sub_proteinas,_Sub_lipidos,_Sub_hyc,_Sub_sodio,_Sub_cc_total, _Ajuste_calorias,_Ajuste_proteinas,_Ajuste_lipidos,_Ajuste_hyc,_Ajuste_sodio,_Ajuste_cc_total,_Mixto"     EmptyDataText="Estimado  Usuario, No existen Datos" 
                              CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"  CellPadding="4"  Font-Size="11px" >
                        <Columns>
                         
                                 <asp:BoundField DataField="_Nom_tipo_alimentos" HeaderText="Alimento" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT"  ControlStyle-Font-Size="12px" />
                               <asp:BoundField DataField="_Cantidad" HeaderText="Cant." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                   <asp:TemplateField HeaderText="% C." HeaderStyle-Width="1%">
                                    <ItemTemplate   >
                                          <asp:TextBox type="text" ID="txtporcentaje_hco" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"   OnTextChanged="txtporcentaje_hco_TextChanged"  AutoPostBack="true"      Style="height: 25px; width: 35px" />                          
                                                 <asp:HiddenField ID="hhco_c" runat="server" Value='<%#Eval("_Calorias") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hhco_p" runat="server" Value='<%#Eval("_Proteinas") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hhco_l" runat="server" Value='<%#Eval("_Lipidos") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hhco_hyc" runat="server" Value='<%#Eval("_Hyc") %>'> </asp:HiddenField>
                                     <asp:HiddenField ID="hhco_s" runat="server" Value='<%#Eval("_Sodio") %>'> </asp:HiddenField>
                                      <asp:HiddenField ID="hhco_mixto" runat="server" Value='<%#Eval("_Mixto") %>'> </asp:HiddenField>
                                       <asp:HiddenField ID="hhco_distribucion" runat="server" Value='<%#Eval("_Cod_tipo_distribucion") %>'> </asp:HiddenField>  
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                 <asp:BoundField DataField="_Gr_i" HeaderText="GR. I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="_Ing_gr_c" HeaderText="GR. C." HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="_Gr_i" HeaderText="GR. I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="_Ing_gr_c" HeaderText="GR. C." HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="Right" />
                                 <asp:BoundField DataField="_Ing_calorias" HeaderText="Calorias" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_proteinas" HeaderText="Proteinas" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_lipidos" HeaderText="Lipidos" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_hyc" HeaderText="H&C" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                 <asp:BoundField DataField="_Ing_sodio" HeaderText="Sodio" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                     <asp:BoundField DataField="_Cc_i" HeaderText="CC I." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" ControlStyle-Font-Size="12px" />
                                  <asp:TemplateField HeaderText="CC C." HeaderStyle-Width="1%"  ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate   >
                                        <asp:TextBox type="text" ID="txtcchco_c" runat="server" placeholder="0" Enabled="false"  MaxLength="4" onkeypress="return validNumericos(event)"   onchange="ingesta_hco();"      Style="height: 25px; width: 35px" />           
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>

                                                                                         <div style="overflow-x:auto; padding-left:20px">
  <table>
    <tr>
      <th  style=" width:5%"></th>
       <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%;  text-align:right"></th>
      <th style=" width:1%; text-align:right"></th>
    </tr>
    
 
    <tr>
      <td>SUB TOTALES</td>
       <td style=" width:1%; text-align:right"></td>
        <td style=" width:1%; text-align:right"> </td>
        <td style=" width:1%; text-align:right"> </td>
       <td style=" width:1%; text-align:right"> <asp:Label ID="shco_gr_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="shco_c" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"> <asp:Label ID="shco_p" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="shco_l" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="shco_hyc" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="shco_s" runat="server" ForeColor="Red"></asp:Label></td>
      <td style=" width:1%; text-align:right"></td>
      <td style=" width:1%; text-align:right"><asp:Label ID="shco_total" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>

      <tr>
      <td>  AJUSTE TOTAL</td>
       <td style=" width:1%; text-align:right"></td>
       <td style=" width:1%; text-align:right"> </td>
        <td style=" width:1%; text-align:right"> </td>
      <td style=" width:1%; text-align:right"> </td>
      <td style=" width:0.3%; text-align:right"> <asp:TextBox type="text" ID="hco_c" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"      Style="height: 25px; width: 50px; text-align:right" />   </td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="hco_p" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"    Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="hco_l" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"   onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="hco_hyc" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"     Style="height: 25px; width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="hco_s" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)"  onchange="Calcular_resumen();"      Style="height: 25px;width: 50px; text-align:right" /></td>
      <td style=" width:0.3%; text-align:right"></td>
      <td style=" width:0.3%; text-align:right"><asp:TextBox type="text" ID="hco_total" runat="server" placeholder="0"   MaxLength="4" onkeypress="return validNumericos(event)" onchange="Calcular_resumen();"    Style="height: 25px; width: 50px; text-align:right" /></td>
    </tr>
  </table>
</div>

       
        </ContentTemplate>
            <Triggers>
             
            </Triggers>
        </asp:UpdatePanel>

       




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
                                        <asp:Label type="text" ID="txtmsg_21" runat="server"  Text="Estimado Usuario, Fue  Guardado Correctamente la Ingesta" />
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

<div id='imagenFlotante'>
    <asp:ImageButton ID="btn_guardar" ImageUrl="~/Imagenes/Botones/save_1.png" runat="server" Width="40px" Height="40px" ToolTip="Guardar" OnClick="Guardar" /><br />
   <asp:ImageButton ID="ImageButton1" ImageUrl="~/Imagenes/Botones/menu_2.png" runat="server" Width="40px" Height="40px" ToolTip="Regresar Al Listado" OnClick="btnatras" /><br />
    <asp:ImageButton ID="btn_restablecer_total" ImageUrl="~/Imagenes/Botones/refrescar.png" runat="server"  Width="40px" Height="40px" ToolTip="Restablecer los valores originales" OnClick="Restablecer_total" />   

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

 <script type="text/javascript" >

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

 <script type="text/javascript" >

           function validNumericos(evt) {
               var nav4 = window.Event ? true : false;

               var key = nav4 ? evt.which : evt.keyCode;

               return (key <= 13 || (key >= 48 && key <= 57) || key == 44);
           }


      
    </script>  

 



 <script language="javascript" type="text/javascript">


    /* function calcular_d() {
 

       var grilla = "#<%=grilladesayuno.ClientID%> tbody tr";
       var var_c = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_c]";
       var var_p = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_p]";
       var var_l = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_l]";
       var var_hyc = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_hyc]";
       var var_s = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_s]";
       var var_mixto = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_mixto]";
       var var_cc_c = "input[type=text][id*=ContentPlaceHolder1_grilladesayuno_txtccd_c]";
       var var_sub_gr_c = "input[type=text][id*=ContentPlaceHolder1_grilladesayuno_txtgrd_c]";

       var var_sub_c = '#ContentPlaceHolder1_sd_c';
       var var_sub_p = '#ContentPlaceHolder1_sd_p';
       var var_sub_l = '#ContentPlaceHolder1_sd_l';
       var var_sub_hyc = '#ContentPlaceHolder1_sd_hyc';
       var var_sub_s = '#ContentPlaceHolder1_sd_s';
       var var_sub_total = '#ContentPlaceHolder1_sd_total';
       var var_gr_total = '#ContentPlaceHolder1_sd_gr_c';

       var var_aj_c = '#ContentPlaceHolder1_d_c';
       var var_aj_p = '#ContentPlaceHolder1_d_p';
       var var_aj_l = '#ContentPlaceHolder1_d_l';
       var var_aj_hyc = '#ContentPlaceHolder1_d_hyc';
       var var_aj_s = '#ContentPlaceHolder1_d_s';
       var var_aj_total = '#ContentPlaceHolder1_d_total';

         var num = 0;
         num = parseInt($('#ContentPlaceHolder1_num_d').html()) + parseInt(1);

         // gramos consumidos


         var cont_3 = 0;
         var v_gra_c = 0;
         var v_cc_c = 0;
         var calorias = 0;
         $(grilla).each(function () {
             // alert('paso2');
           //  if (parseInt(cont_3) < parseInt(num)) {

                 $this = $(this);

                 var v_gra_c = parseInt($(this).find("td").eq(1).html());
                 //alert(v_gra_c);
                 if (!isNaN(v_gra_c)) {
                     parseInt($(this).closest("tr").find(var_sub_gr_c).val(v_gra_c));
                
                 }

                 var v_cc_c = parseInt($(this).find("td").eq(8).html());
                 // alert(v_cc_c);
                 if (!isNaN(v_cc_c)) {
                     parseInt($(this).closest("tr").find(var_cc_c).val(v_cc_c));

                 }
                 var cal = $(this).closest("tr").find(var_c).val();
               
                 if (!isNaN(cal)) {
                   //  alert($(this).find("td").eq(3).html(cal));
                     $(this).find("td").eq(3).html(cal);
                 }

            // }

           //  cont_3++;

         });
             //  llenar(grilla, var_c, var_p, var_l, var_hyc, var_s, $this)
     calcular_componetes(grilla, var_c, var_p, var_l, var_hyc, var_s, var_sub_gr_c, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c, num, var_gr_total,var_mixto);
      //Calcular_resumen();
  
    }*/



     function calcular_componetes(grilla, var_c, var_p, var_l, var_hyc, var_s, var_porcentaje, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c, num, var_gr_total,var_mixto,var_distribucion) {
        
         // variables

         var gr_c = 0; var gr_i = 0; var aux = 0;  var valor = 0;
         var t1_c = 0; var t1_p = 0; var t1_l = 0; var t1_hyc = 0; var t1_s = 0; var t1_total = 0;
         var t1_gr_c = 0;
         var total_c = 0;
          var calorias=0;

         $(grilla).each(function () {

             var t_c = 0; var t_p = 0; var t_l = 0; var t_hyc = 0; var t_s = 0;


             $this = $(this);
             if ($this.find('input[type=text]').val() != undefined) {

                 aux = parseInt($this.find('input[type=text]').val());
                 gr_i = parseInt($(this).find("td").eq(2).html());

                 // valido  que sea distinto de vacio

                 if (!isNaN(aux)) { gr_c = aux; } else {

                     var nom = $(this).find("td").eq(0).html();
                     //alert("El Valor Gr Consumido  es menor que cero en el alimento " + nom);
                     $this.find('input[type=text]').val(0);
                     $(this).find("td").eq(3).html(0);
                     $(this).find("td").eq(4).html(0);
                     $(this).find("td").eq(5).html(0);
                     $(this).find("td").eq(6).html(0);
                     $(this).find("td").eq(7).html(0);
                     $(this).find("td").eq(8).html(0);

                 }

                 if (parseInt(aux) < 1 || parseInt(gr_c) > 100) {

                     $this.find('input[type=text]').val(0);
                     $(this).find("td").eq(3).html(0);
                     $(this).find("td").eq(4).html(0);
                     $(this).find("td").eq(5).html(0);
                     $(this).find("td").eq(6).html(0);
                     $(this).find("td").eq(7).html(0);
                     $(this).find("td").eq(8).html(0);
                     $(this).closest("tr").find(var_cc_c).val(0)

                 }
                 else {

                         // calcular porcentaje  
                         //  valor = Math.ceil(parseInt(gr_c) * 100 / parseInt(gr_i));
                         valor = parseFloat(gr_c);

                         // gramos consumidos de calorias 
                         /* v_mixto = $(this).closest("tr").find(var_mixto).val();
                         v_cod_distribucion = $(this).closest("tr").find(var_distribucion).val();
                         var calorias = 0;*/

                         // gramos consumido

                         var total_G = ((parseFloat(valor).toFixed(1) * parseFloat(gr_i).toFixed(1)) / 100);
                         $(this).find("td").eq(3).html(total_G.toFixed(1));



                         // gramos consumidos de calorias
                         calorias = $(this).closest("tr").find(var_c).val();
                         alert(calorias);

                         total_c = ((parseFloat(valor).toFixed(1)) * (parseFloat(calorias).toFixed(1)) / 100);
                         $(this).find("td").eq(4).html(total_c);
                         alert(total_c);

                         // gramos consumidos de proteinas
                         var proteinas = $(this).closest("tr").find(var_p).val();
                         alert(proteinas);
                         var total_p = (parseFloat(valor).toFixed(1) * parseFloat(proteinas).toFixed(1) / 100);
                         $(this).find("td").eq(5).html(total_p.toFixed(1));

                         // gramos consumidos de lipidos
                         var lipidos = $(this).closest("tr").find(var_l).val();
                         var total_l = (parseFloat(valor).toFixed(1) * parseFloat(lipidos).toFixed(1) / 100);
                         $(this).find("td").eq(6).html(total_l.toFixed(1));

                         // gramos consumidos de hyc
                         var hyc = $(this).closest("tr").find(var_hyc).val();
                         var total_hyc = (parseFloat(valor).toFixed(1) * parseFloat(hyc).toFixed(1) / 100);
                         $(this).find("td").eq(7).html(total_hyc.toFixed(1));

                         // cc consumidos de solido
                         var solido = $(this).closest("tr").find(var_s).val();
                         var total_s = (parseFloat(valor).toFixed(1) * parseFloat(solido).toFixed(1) / 100);
                         $(this).find("td").eq(8).html(total_s.toFixed(1));



                         // cc consumidos
                         var cc = parseFloat($(this).find("td").eq(9).html());
                         var total_c_c = (parseFloat(valor).toFixed(1) * parseFloat(cc).toFixed(1) / 100);
                         $(this).closest("tr").find(var_cc_c).val(total_c_c.toFixed(1))

                 }


             }


         });



         SumarColumna(grilla, 3, var_sub_c, var_aj_c, num, var_gr_total);
         SumarColumna(grilla, 4, var_sub_c, var_aj_c, num, var_gr_total);
         SumarColumna(grilla, 5, var_sub_p, var_aj_p, num, var_gr_total);
         SumarColumna(grilla, 6, var_sub_l, var_aj_l, num, var_gr_total);
         SumarColumna(grilla, 7, var_sub_hyc, var_aj_hyc, num, var_gr_total);
         SumarColumna(grilla, 8, var_sub_s, var_aj_s, num, var_gr_total);
     

         var cont_2 = 0;
         $(grilla).each(function () {

             if (parseInt(cont_2) < parseInt(num)) {
                 var v_total = 0;
                 $this = $(this);


                 var v_total = parseFloat($(this).closest("tr").find(var_cc_c).val());
                 if (!isNaN(v_total)) {
                     t1_total += parseFloat(v_total.toFixed(1));

                 }
                 else {
                     $(this).closest("tr").find(var_cc_c).val(0);
                 }


             }

             cont_2++;

         });

         if (isNaN(t1_total)) {
             t1_total = 0;
         }
         $(var_sub_total).html(t1_total.toFixed(1));
         $(var_aj_total).val(t1_total.toFixed(1));

     }

     function SumarColumna(grilla, columna, var_sub_c, var_aj_c, v_cont, var_gr_total) {
   
         var cal = 0;
         var total = 0;
         var co = 0;
         
 
         var cont_1 = 0;
         $(grilla).each(function () {

             $this = $(this);

             if (cont_1 < v_cont) {


                 var cal = parseFloat($(this).find("td").eq(columna).html());

                 if (!isNaN(cal)) {
                     total += parseFloat(cal.toFixed(1));
                   
                 }

             }
             cont_1++;

         });

         if (columna == 3)
          {
              $(var_gr_total).html(total.toFixed(1));
         }
         else{
             $(var_sub_c).html(total.toFixed(1));
             $(var_aj_c).val(total.toFixed(1));
         }


        
             

     }

   



     function Calcular_resumen() {


         var totalgr_1 = 0; var totald_1 = 0; var totald_2 = 0; var totald_3 = 0; var totald_4 = 0; var totald_5 = 0; var totald_6 = 0;
         var gr_1 = 0; var gr_2 = 0; var gr_3 = 0; var gr_4 = 0; var gr_5 = 0; var gr_6 = 0; var gr_7 = 0; var gr_8 = 0;
         var d_1 = 0; var d_2 = 0; var d_3 = 0; var d_4 = 0; var d_5 = 0; var d_6 = 0;
         var c1_1 = 0; var c1_2 = 0; var c1_3 = 0; var c1_4 = 0; var c1_5 = 0; var c1_6 = 0;
         var a_1 = 0; var a_2 = 0; var a_3 = 0; var a_4 = 0; var a_5 = 0; var a_6 = 0;
         var o_1 = 0; var o_2 = 0; var o_3 = 0; var o_4 = 0; var o_5 = 0; var o_6 = 0;
         var c_1 = 0; var c_2 = 0; var c_3 = 0; var c_4 = 0; var c_5 = 0; var c_6 = 0;
         var ce_1 = 0; var ce_2 = 0; var ce_3 = 0; var ce_4 = 0; var ce_5 = 0; var ce_6 = 0;
         var hco_1 = 0; var hco_2 = 0; var hco_3 = 0; var hco_4 = 0; var hco_5 = 0; var hco_6 = 0;

         $('#<%=grillaresumen.ClientID%> tr').each(function () {



             var com_d = parseInt($(this).closest("tr").find("input[type=hidden][id*=ContentPlaceHolder1_grillaresumen_var_cod_comida]").val());



             if (com_d == 1) {


                 gr_1 = parseFloat($('#ContentPlaceHolder1_sd_gr_c').html()); if (!isNaN(gr_1)) { $(this).find("td").eq(2).html(gr_1.toFixed(1)); } else { gr_1 = 0; }
                 d_1 = parseFloat($('#ContentPlaceHolder1_d_c').val()); if (!isNaN(d_1)) { $(this).find("td").eq(3).html(d_1.toFixed(1)); } else { d_1 = 0; }
                 d_2 = parseFloat($('#ContentPlaceHolder1_d_p').val()); if (!isNaN(d_2)) { $(this).find("td").eq(4).html(d_2.toFixed(1)); } else { d_2 = 0; }
                 d_3 = parseFloat($('#ContentPlaceHolder1_d_l').val()); if (!isNaN(d_3)) { $(this).find("td").eq(5).html(d_3.toFixed(1)); } else { d_3 = 0; }
                 d_4 = parseFloat($('#ContentPlaceHolder1_d_hyc').val()); if (!isNaN(d_4)) { $(this).find("td").eq(6).html(d_4.toFixed(1)); } else { d_4 = 0; }
                 d_5 = parseFloat($('#ContentPlaceHolder1_d_s').val()); if (!isNaN(d_5)) { $(this).find("td").eq(7).html(d_5.toFixed(1)); } else { d_5 = 0; }
                 d_6 = parseFloat($('#ContentPlaceHolder1_d_total').val()); if (!isNaN(d_6)) { $(this).find("td").eq(8).html(d_6.toFixed(1)); } else { d_6 = 0; }

             }

             if (com_d == 2) {
                 gr_2 = parseFloat($('#ContentPlaceHolder1_sc1_gr_c').html()); if (!isNaN(gr_2)) { $(this).find("td").eq(2).html(gr_2.toFixed(1)); } else { gr_2 = 0; }
                 c1_1 = parseFloat($('#ContentPlaceHolder1_c1_c').val()); if (!isNaN(c1_1)) { $(this).find("td").eq(3).html(c1_1.toFixed(1)); } else { c1_1 = 0; }
                 c1_2 = parseFloat($('#ContentPlaceHolder1_c1_p').val()); if (!isNaN(c1_2)) { $(this).find("td").eq(4).html(c1_2.toFixed(1)); } else { c1_2 = 0; }
                 c1_3 = parseFloat($('#ContentPlaceHolder1_c1_l').val()); if (!isNaN(c1_3)) { $(this).find("td").eq(5).html(c1_3.toFixed(1)); } else { c1_3 = 0; }
                 c1_4 = parseFloat($('#ContentPlaceHolder1_c1_hyc').val()); if (!isNaN(c1_4)) { $(this).find("td").eq(6).html(c1_4.toFixed(1)); } else { c1_4 = 0; }
                 c1_5 = parseFloat($('#ContentPlaceHolder1_c1_s').val()); if (!isNaN(c1_5)) { $(this).find("td").eq(7).html(c1_5.toFixed(1)); } else { c1_5 = 0; }
                 c1_6 = parseFloat($('#ContentPlaceHolder1_c1_total').val()); if (!isNaN(c1_6)) { $(this).find("td").eq(8).html(c1_6.toFixed(1)); } else { c1_6 = 0; }

             }

             if (com_d == 3) {
                 gr_3 = parseFloat($('#ContentPlaceHolder1_sa_gr_c').html()); if (!isNaN(gr_3)) { $(this).find("td").eq(2).html(gr_3.toFixed(1)); } else { gr_3 = 0; }
                 a_1 = parseFloat($('#ContentPlaceHolder1_a_c').val()); if (!isNaN(a_1)) { $(this).find("td").eq(3).html(a_1.toFixed(1)); } else { a_1 = 0; }
                 a_2 = parseFloat($('#ContentPlaceHolder1_a_p').val()); if (!isNaN(a_2)) { $(this).find("td").eq(4).html(a_2.toFixed(1)); } else { a_2 = 0; }
                 a_3 = parseFloat($('#ContentPlaceHolder1_a_l').val()); if (!isNaN(a_3)) { $(this).find("td").eq(5).html(a_3.toFixed(1)); } else { a_3 = 0; }
                 a_4 = parseFloat($('#ContentPlaceHolder1_a_hyc').val()); if (!isNaN(a_4)) { $(this).find("td").eq(6).html(a_4.toFixed(1)); } else { a_4 = 0; }
                 a_5 = parseFloat($('#ContentPlaceHolder1_a_s').val()); if (!isNaN(a_5)) { $(this).find("td").eq(7).html(a_5.toFixed(1)); } else { a_5 = 0; }
                 a_6 = parseFloat($('#ContentPlaceHolder1_a_total').val()); if (!isNaN(a_6)) { $(this).find("td").eq(9).html(a_6.toFixed(1)); } else { a_6 = 0; }

             }

             if (com_d == 4) {
                 gr_4 = parseFloat($('#ContentPlaceHolder1_so_gr_c').html()); if (!isNaN(gr_4)) { $(this).find("td").eq(2).html(gr_4.toFixed(1)); } else { gr_4 = 0; }
                 o_1 = parseFloat($('#ContentPlaceHolder1_o_c').val()); if (!isNaN(o_1)) { $(this).find("td").eq(3).html(o_1.toFixed(1)); } else { o_1 = 0; }
                 o_2 = parseFloat($('#ContentPlaceHolder1_o_p').val()); if (!isNaN(o_2)) { $(this).find("td").eq(4).html(o_2.toFixed(1)); } else { o_2 = 0; }
                 o_3 = parseFloat($('#ContentPlaceHolder1_o_l').val()); if (!isNaN(o_3)) { $(this).find("td").eq(5).html(o_3.toFixed(1)); } else { o_3 = 0; }
                 o_4 = parseFloat($('#ContentPlaceHolder1_o_hyc').val()); if (!isNaN(o_4)) { $(this).find("td").eq(6).html(o_4.toFixed(1)); } else { o_4 = 0; }
                 o_5 = parseFloat($('#ContentPlaceHolder1_o_s').val()); if (!isNaN(o_5)) { $(this).find("td").eq(7).html(o_5.toFixed(1)); } else { o_5 = 0; }
                 o_6 = parseFloat($('#ContentPlaceHolder1_o_total').val()); if (!isNaN(o_6)) { $(this).find("td").eq(8).html(o_6.toFixed(1)); } else { o_6 = 0; }

             }

             if (com_d == 5) {
                 gr_5 = parseFloat($('#ContentPlaceHolder1_sc_gr_c').html()); if (!isNaN(gr_5)) { $(this).find("td").eq(2).html(gr_5.toFixed(1)); } else { gr_5 = 0; }
                 c_1 = parseFloat($('#ContentPlaceHolder1_c_c').val()); if (!isNaN(c_1)) { $(this).find("td").eq(3).html(c_1.toFixed(1)); } else { c_1 = 0; }
                 c_2 = parseFloat($('#ContentPlaceHolder1_c_p').val()); if (!isNaN(c_2)) { $(this).find("td").eq(4).html(c_2.toFixed(1)); } else { c_2 = 0; }
                 c_3 = parseFloat($('#ContentPlaceHolder1_c_l').val()); if (!isNaN(c_3)) { $(this).find("td").eq(5).html(c_3.toFixed(1)); } else { c_3 = 0; }
                 c_4 = parseFloat($('#ContentPlaceHolder1_c_hyc').val()); if (!isNaN(c_4)) { $(this).find("td").eq(6).html(c_4.toFixed(1)); } else { c_4 = 0; }
                 c_5 = parseFloat($('#ContentPlaceHolder1_c_s').val()); if (!isNaN(c_5)) { $(this).find("td").eq(7).html(c_5.toFixed(1)); } else { c_5 = 0; }
                 c_6 = parseFloat($('#ContentPlaceHolder1_c_total').val()); if (!isNaN(c_6)) { $(this).find("td").eq(8).html(c_6.toFixed(1)); } else { c_6 = 0; }

             }

             if (com_d == 6) {
                 gr_6 = parseFloat($('#ContentPlaceHolder1_sc2_gr_c').html()); if (!isNaN(gr_6)) { $(this).find("td").eq(2).html(gr_6.toFixed(1)); } else { gr_6 = 0; }
                 c2_1 = parseFloat($('#ContentPlaceHolder1_c2_c').val()); if (!isNaN(c2_1)) { $(this).find("td").eq(3).html(c2_1.toFixed(1)); } else { c2_1 = 0; }
                 c2_2 = parseFloat($('#ContentPlaceHolder1_c2_p').val()); if (!isNaN(c2_2)) { $(this).find("td").eq(4).html(c2_2.toFixed(1)); } else { c2_2 = 0; }
                 c2_3 = parseFloat($('#ContentPlaceHolder1_c2_l').val()); if (!isNaN(c2_3)) { $(this).find("td").eq(5).html(c2_3.toFixed(1)); } else { c2_3 = 0; }
                 c2_4 = parseFloat($('#ContentPlaceHolder1_c2_hyc').val()); if (!isNaN(c2_4)) { $(this).find("td").eq(6).html(c2_4.toFixed(1)); } else { c2_4 = 0; }
                 c2_5 = parseFloat($('#ContentPlaceHolder1_c2_s').val()); if (!isNaN(c2_5)) { $(this).find("td").eq(7).html(c2_5.toFixed(1)); } else { c2_5 = 0; }
                 c2_6 = parseFloat($('#ContentPlaceHolder1_c2_total').val()); if (!isNaN(c2_6)) { $(this).find("td").eq(8).html(c2_6.toFixed(1)); } else { c2_6 = 0; }

             }

             if (com_d == 7) {
                 gr_7 = parseFloat($('#ContentPlaceHolder1_sce_gr_c').html()); if (!isNaN(gr_7)) { $(this).find("td").eq(2).html(gr_7.toFixed(1)); } else { gr_7 = 0; }
                 ce_1 = parseFloat($('#ContentPlaceHolder1_ce_c').val()); if (!isNaN(ce_1)) { $(this).find("td").eq(3).html(ce_1.toFixed(1)); } else { ce_1 = 0; }
                 ce_2 = parseFloat($('#ContentPlaceHolder1_ce_p').val()); if (!isNaN(ce_2)) { $(this).find("td").eq(4).html(ce_2.toFixed(1)); } else { ce_2 = 0; }
                 ce_3 = parseFloat($('#ContentPlaceHolder1_ce_l').val()); if (!isNaN(ce_3)) { $(this).find("td").eq(5).html(ce_3.toFixed(1)); } else { ce_3 = 0; }
                 ce_4 = parseFloat($('#ContentPlaceHolder1_ce_hyc').val()); if (!isNaN(ce_4)) { $(this).find("td").eq(6).html(ce_4.toFixed(1)); } else { ce_4 = 0; }
                 ce_5 = parseFloat($('#ContentPlaceHolder1_ce_s').val()); if (!isNaN(ce_5)) { $(this).find("td").eq(7).html(ce_5.toFixed(1)); } else { ce_5 = 0; }
                 ce_6 = parseFloat($('#ContentPlaceHolder1_ce_total').val()); if (!isNaN(ce_6)) { $(this).find("td").eq(8).html(ce_6.toFixed(1)); } else { ce_6 = 0; }

             }

             if (com_d == 8) {
                 gr_8 = parseFloat($('#ContentPlaceHolder1_shco_gr_c').html()); if (!isNaN(gr_8)) { $(this).find("td").eq(2).html(gr_8.toFixed(1)); } else { gr_8 = 0; }
                 hco_1 = parseFloat($('#ContentPlaceHolder1_hco_c').val()); if (!isNaN(hco_1)) { $(this).find("td").eq(3).html(hco_1.toFixed(1)); } else { hco_1 = 0; }
                 hco_2 = parseFloat($('#ContentPlaceHolder1_hco_p').val()); if (!isNaN(hco_2)) { $(this).find("td").eq(4).html(hco_2.toFixed(1)); } else { hco_2 = 0; }
                 hco_3 = parseFloat($('#ContentPlaceHolder1_hco_l').val()); if (!isNaN(hco_3)) { $(this).find("td").eq(5).html(hco_3.toFixed(1)); } else { hco_3 = 0; }
                 hco_4 = parseFloat($('#ContentPlaceHolder1_hco_hyc').val()); if (!isNaN(hco_4)) { $(this).find("td").eq(6).html(hco_4.toFixed(1)); } else { hco_4 = 0; }
                 hco_5 = parseFloat($('#ContentPlaceHolder1_hco_s').val()); if (!isNaN(hco_5)) { $(this).find("td").eq(7).html(hco_5.toFixed(1)); } else { hco_5 = 0; }
                 hco_6 = parseFloat($('#ContentPlaceHolder1_hco_total').val()); if (!isNaN(hco_6)) { $(this).find("td").eq(8).html(hco_6.toFixed(1)); } else { hco_6 = 0; }

             }


         });


         $('#<%=grillaresumen.ClientID%> tr').each(function () {



             var com_d = parseInt($(this).closest("tr").find("input[type=hidden][id*=ContentPlaceHolder1_grillaresumen_var_cod_comida]").val());

             if (com_d == 9) {

                 totalgr_1 = parseFloat(gr_1) + parseFloat(gr_2.toFixed(1)) + parseFloat(gr_3.toFixed(1)) + parseFloat(gr_4.toFixed(1)) + parseFloat(gr_5.toFixed(1)) + parseFloat(gr_6.toFixed(1))
                      + parseFloat(gr_7.toFixed(1)) + parseFloat(gr_8.toFixed(1));

                 $(this).find("td").eq(2).html(totalgr_1.toFixed(1));

                 totald_1 = parseFloat(d_1.toFixed(1)) + parseFloat(c1_1.toFixed(1)) + parseFloat(a_1.toFixed(1)) + parseFloat(o_1.toFixed(1)) + parseFloat(c_1.toFixed(1)) + parseFloat(c2_1.toFixed(1))
                      + parseFloat(ce_1.toFixed(1)) + parseFloat(hco_1.toFixed(1));

                 $(this).find("td").eq(3).html(totald_1.toFixed(1));


                 totald_2 = parseFloat(d_2.toFixed(1)) + parseFloat(c1_2.toFixed(1)) + parseFloat(a_2.toFixed(1)) + parseFloat(o_2.toFixed(1)) + parseFloat(c_2.toFixed(1)) + parseFloat(c2_2.toFixed(1)) + parseFloat(ce_2.toFixed(1)) + parseFloat(hco_2.toFixed(1));
                 $(this).find("td").eq(4).html(totald_2.toFixed(1));

                 totald_3 = parseFloat(d_3.toFixed(1)) + parseFloat(c1_3.toFixed(1)) + parseFloat(a_3.toFixed(1)) +
                                    parseFloat(o_3.toFixed(1)) + parseFloat(c_3.toFixed(1)) + parseFloat(c2_3.toFixed(1))
                                    + parseFloat(ce_3.toFixed(1)) + parseFloat(hco_1.toFixed(1));
                 $(this).find("td").eq(5).html(totald_3.toFixed(1));


                 totald_4 = parseFloat(d_4.toFixed(1)) + parseFloat(c1_4.toFixed(1)) + parseFloat(a_4.toFixed(1)) +
                                    parseFloat(o_4.toFixed(1)) + parseFloat(c_4.toFixed(1)) + parseFloat(c2_4.toFixed(1))
                                    + parseFloat(ce_4.toFixed(1)) + parseFloat(hco_4.toFixed(1));
                 $(this).find("td").eq(6).html(totald_4.toFixed(1));

                 totald_5 = parseFloat(d_5.toFixed(1)) + parseFloat(c1_5.toFixed(1)) + parseFloat(a_5.toFixed(1)) +
                                    parseFloat(o_5.toFixed(1)) + parseFloat(c_5.toFixed(1)) + parseFloat(c2_5.toFixed(1))
                                    + parseFloat(ce_5.toFixed(1)) + parseFloat(hco_5.toFixed(1));
                 $(this).find("td").eq(7).html(totald_5.toFixed(1));


                 totald_6 = parseFloat(d_6.toFixed(1)) + parseFloat(c1_6.toFixed(1)) + parseFloat(a_6.toFixed(1)) +
                                    parseFloat(o_6.toFixed(1)) + parseFloat(c_6.toFixed(1)) + parseFloat(c2_6.toFixed(1))
                                    + parseFloat(ce_6.toFixed(1)) + parseFloat(hco_6.toFixed(1));
                 $(this).find("td").eq(8).html(totald_6.toFixed(1));



             }

         });


     }

     function ingesta_d() {

             
             var grilla = "#<%=grilladesayuno.ClientID%> tbody tr";
             var var_c = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_c]";
             var var_p = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_p]";
             var var_l = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_l]";
             var var_hyc = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_hyc]";
             var var_s = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_s]";
             var var_mixto = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_mixto]";
             var var_distribucion = "input[type=hidden][id*=ContentPlaceHolder1_grilladesayuno_h_distribucion]";
             var var_cc_c = "input[type=text][id*=ContentPlaceHolder1_grilladesayuno_txtccd_c]";
             var var_porcentaje = "input[type=text][id*=ContentPlaceHolder1_grilladesayuno_txtporcentaje_d]";
           

             var var_sub_c = '#ContentPlaceHolder1_sd_c';
             var var_sub_p = '#ContentPlaceHolder1_sd_p';
             var var_sub_l = '#ContentPlaceHolder1_sd_l';
             var var_sub_hyc = '#ContentPlaceHolder1_sd_hyc';
             var var_sub_s = '#ContentPlaceHolder1_sd_s';
             var var_sub_total = '#ContentPlaceHolder1_sd_total';
             var var_gr_total = '#ContentPlaceHolder1_sd_gr_c';

             var var_aj_c = '#ContentPlaceHolder1_d_c';
             var var_aj_p = '#ContentPlaceHolder1_d_p';
             var var_aj_l = '#ContentPlaceHolder1_d_l';
             var var_aj_hyc = '#ContentPlaceHolder1_d_hyc';
             var var_aj_s = '#ContentPlaceHolder1_d_s';
             var var_aj_total = '#ContentPlaceHolder1_d_total';
             var num = 0;
             num= parseInt($('#ContentPlaceHolder1_num_d').html()) + parseInt(1);

           

             calcular_componetes(grilla, var_c, var_p, var_l, var_hyc, var_s, var_porcentaje, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c, num, var_gr_total, var_mixto, var_distribucion);
            // recalcular(grilla, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c);
             Calcular_resumen();
         }


         function ingesta_c1() {
             var grilla = "#<%=grillacolacion_man.ClientID%> tbody tr";
             var var_c = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_man_hc1_c]";
             var var_p = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_man_hc1_p]";
             var var_l = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_man_hc1_l]";
             var var_hyc = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_man_hc1_hyc]";
             var var_s = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_man_hc1_s]";
             var var_mixto = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_man_hc1_mixto]";
             var var_distribucion = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_man_hc1_distribucion]";
             var var_cc_c = "input[type=text][id*=ContentPlaceHolder1_grillacolacion_man_txtccc1_c]";
             var var_porcentaje = "input[type=text][id*=ContentPlaceHolder1_grillacolacion_man_txtporcentaje_c1]";

             var var_sub_c = '#ContentPlaceHolder1_sc1_c';
             var var_sub_p = '#ContentPlaceHolder1_sc1_p';
             var var_sub_l = '#ContentPlaceHolder1_sc1_l';
             var var_sub_hyc = '#ContentPlaceHolder1_sc1_hyc';
             var var_sub_s = '#ContentPlaceHolder1_sc1_s';
             var var_sub_total = '#ContentPlaceHolder1_sc1_total';
             var var_gr_total = '#ContentPlaceHolder1_sc1_gr_c';
          

             var var_aj_c = '#ContentPlaceHolder1_c1_c';
             var var_aj_p = '#ContentPlaceHolder1_c1_p';
             var var_aj_l = '#ContentPlaceHolder1_c1_l';
             var var_aj_hyc = '#ContentPlaceHolder1_c1_hyc';
             var var_aj_s = '#ContentPlaceHolder1_c1_s';
             var var_aj_total = '#ContentPlaceHolder1_c1_total';
             var num = 0;
             num = parseInt($('#ContentPlaceHolder1_num_c1').html()) + parseInt(1);

             calcular_componetes(grilla, var_c, var_p, var_l, var_hyc, var_s, var_porcentaje, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c, num, var_gr_total, var_mixto, var_distribucion);
             Calcular_resumen();
             //recalcular(grilla, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c);
             
         }

         function ingesta_a() {
             var grilla = "#<%=grillaalmuerzo.ClientID%> tbody tr";
             var var_c = "input[type=hidden][id*=ContentPlaceHolder1_grillaalmuerzo_ha_c]";
             var var_p = "input[type=hidden][id*=ContentPlaceHolder1_grillaalmuerzo_ha_p]";
             var var_l = "input[type=hidden][id*=ContentPlaceHolder1_grillaalmuerzo_ha_l]";
             var var_hyc = "input[type=hidden][id*=ContentPlaceHolder1_grillaalmuerzo_ha_hyc]";
             var var_s = "input[type=hidden][id*=ContentPlaceHolder1_grillaalmuerzo_ha_s]";
             var var_mixto = "input[type=hidden][id*=ContentPlaceHolder1_grillaalmuerzo_ha_mixto]";
             var var_distribucion = "input[type=hidden][id*=ContentPlaceHolder1_grillaalmuerzo_ha_distribucion]";
             var var_cc_c = "input[type=text][id*=ContentPlaceHolder1_grillaalmuerzo_txtcca_c]";
             var var_sub_gr_c = "input[type=text][id*=ContentPlaceHolder1_grillaalmuerzo_txtgra_c]";
             var var_porcentaje = "input[type=text][id*=ContentPlaceHolder1_grillaalmuerzo_txtporcentaje_a]";

             var var_sub_c = '#ContentPlaceHolder1_sa_c';
             var var_sub_p = '#ContentPlaceHolder1_sa_p';
             var var_sub_l = '#ContentPlaceHolder1_sa_l';
             var var_sub_hyc = '#ContentPlaceHolder1_sa_hyc';
             var var_sub_s = '#ContentPlaceHolder1_sa_s';
             var var_sub_total = '#ContentPlaceHolder1_sa_total';
             var var_gr_total = '#ContentPlaceHolder1_sa_gr_c';
          

             var var_aj_c = '#ContentPlaceHolder1_a_c';
             var var_aj_p = '#ContentPlaceHolder1_a_p';
             var var_aj_l = '#ContentPlaceHolder1_a_l';
             var var_aj_hyc = '#ContentPlaceHolder1_a_hyc';
             var var_aj_s = '#ContentPlaceHolder1_a_s';
             var var_aj_total = '#ContentPlaceHolder1_a_total';
             var num = 0;
             num = parseInt($('#ContentPlaceHolder1_num_a').html()) + parseInt(1);

             calcular_componetes(grilla, var_c, var_p, var_l, var_hyc, var_s, var_porcentaje, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c, num, var_gr_total, var_mixto, var_distribucion);
            // recalcular(grilla, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c);
             Calcular_resumen();
         }

         function ingesta_o() {
             var grilla = "#<%=grillaonce.ClientID%> tbody tr";
             var var_c = "input[type=hidden][id*=ContentPlaceHolder1_grillaonce_ho_c]";
             var var_p = "input[type=hidden][id*=ContentPlaceHolder1_grillaonce_ho_p]";
             var var_l = "input[type=hidden][id*=ContentPlaceHolder1_grillaonce_ho_l]";
             var var_hyc = "input[type=hidden][id*=ContentPlaceHolder1_grillaonce_ho_hyc]";
             var var_s = "input[type=hidden][id*=ContentPlaceHolder1_grillaonce_ho_s]";
             var var_mixto = "input[type=hidden][id*=ContentPlaceHolder1_grillaonce_ho_mixto]";
             var var_distribucion = "input[type=hidden][id*=ContentPlaceHolder1_grillaonce_ho_distribucion]";
             var var_cc_c = "input[type=text][id*=ContentPlaceHolder1_grillaonce_txtcco_c]";
             var var_sub_gr_c = "input[type=text][id*=ContentPlaceHolder1_grillaonce_txtgro_c]";
             var var_porcentaje = "input[type=text][id*=ContentPlaceHolder1_grillaonce_txtporcentaje_o]";

             var var_sub_c = '#ContentPlaceHolder1_so_c';
             var var_sub_p = '#ContentPlaceHolder1_so_p';
             var var_sub_l = '#ContentPlaceHolder1_so_l';
             var var_sub_hyc = '#ContentPlaceHolder1_so_hyc';
             var var_sub_s = '#ContentPlaceHolder1_so_s';
             var var_sub_total = '#ContentPlaceHolder1_so_total';
             var var_gr_total = '#ContentPlaceHolder1_so_gr_c';

             var var_aj_c = '#ContentPlaceHolder1_o_c';
             var var_aj_p = '#ContentPlaceHolder1_o_p';
             var var_aj_l = '#ContentPlaceHolder1_o_l';
             var var_aj_hyc = '#ContentPlaceHolder1_o_hyc';
             var var_aj_s = '#ContentPlaceHolder1_o_s';
             var var_aj_total = '#ContentPlaceHolder1_o_total';
             var num = 0;
             num = parseInt($('#ContentPlaceHolder1_num_o').html()) + parseInt(1);

             calcular_componetes(grilla, var_c, var_p, var_l, var_hyc, var_s, var_sub_gr_c, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c, num, var_gr_total,var_mixto,var_distribucion);
           
            // recalcular(grilla, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c);
             Calcular_resumen();
         }


         function ingesta_c() {
             var grilla = "#<%=grillacena.ClientID%> tbody tr";
             var var_c = "input[type=hidden][id*=ContentPlaceHolder1_grillacena_hc_c]";
             var var_p = "input[type=hidden][id*=ContentPlaceHolder1_grillacena_hc_p]";
             var var_l = "input[type=hidden][id*=ContentPlaceHolder1_grillacena_hc_l]";
             var var_hyc = "input[type=hidden][id*=ContentPlaceHolder1_grillacena_hc_hyc]";
             var var_s = "input[type=hidden][id*=ContentPlaceHolder1_grillacena_hc_s]";
             var var_mixto = "input[type=hidden][id*=ContentPlaceHolder1_grillacena_hc_mixto]";
             var var_distribucion = "input[type=hidden][id*=ContentPlaceHolder1_grillacena_hc_distribucion]";
             var var_cc_c = "input[type=text][id*=ContentPlaceHolder1_grillacena_txtccc_c]";
             var var_sub_gr_c = "input[type=text][id*=ContentPlaceHolder1_grillacena_txtgrc_c]";
             var var_porcentaje = "input[type=text][id*=ContentPlaceHolder1_grillacena_txtporcentaje_c]";

             var var_sub_c = '#ContentPlaceHolder1_sc_c';
             var var_sub_p = '#ContentPlaceHolder1_sc_p';
             var var_sub_l = '#ContentPlaceHolder1_sc_l';
             var var_sub_hyc = '#ContentPlaceHolder1_sc_hyc';
             var var_sub_s = '#ContentPlaceHolder1_sc_s';
             var var_sub_total = '#ContentPlaceHolder1_sc_total';
             var var_gr_total = '#ContentPlaceHolder1_sc_gr_c';
           

             var var_aj_c = '#ContentPlaceHolder1_c_c';
             var var_aj_p = '#ContentPlaceHolder1_c_p';
             var var_aj_l = '#ContentPlaceHolder1_c_l';
             var var_aj_hyc = '#ContentPlaceHolder1_c_hyc';
             var var_aj_s = '#ContentPlaceHolder1_c_s';
             var var_aj_total = '#ContentPlaceHolder1_c_total';
             var num = 0;
             num = parseInt($('#ContentPlaceHolder1_num_c').html()) + parseInt(1);

             calcular_componetes(grilla, var_c, var_p, var_l, var_hyc, var_s, var_sub_gr_c, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c, num, var_gr_total, var_mixto, var_distribucion);
           
            // recalcular(grilla, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c);
             Calcular_resumen();
         }


         function ingesta_c2() {
             var grilla = "#<%=grillacolacion_noc.ClientID%> tbody tr";
             var var_c = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_noc_hc2_c]";
             var var_p = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_noc_hc2_p]";
             var var_l = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_noc_hc2_l]";
             var var_hyc = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_noc_hc2_hyc]";
             var var_s = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_noc_hc2_s]";
             var var_mixto = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_noc_hc2_mixto]";
             var var_distribucion = "input[type=hidden][id*=ContentPlaceHolder1_grillacolacion_noc_hc2_distribucion]";
             var var_cc_c = "input[type=text][id*=ContentPlaceHolder1_grillacolacion_noc_txtccc2_c]";
             var var_sub_gr_c = "input[type=text][id*=ContentPlaceHolder1_grillacolacion_noc_txtgrc2_c]";
             var var_porcentaje = "input[type=text][id*=ContentPlaceHolder1_grillacolacion_noc_txtporcentaje_c2]";

             var var_sub_c = '#ContentPlaceHolder1_sc2_c';
             var var_sub_p = '#ContentPlaceHolder1_sc2_p';
             var var_sub_l = '#ContentPlaceHolder1_sc2_l';
             var var_sub_hyc = '#ContentPlaceHolder1_sc2_hyc';
             var var_sub_s = '#ContentPlaceHolder1_sc2_s';
             var var_sub_total = '#ContentPlaceHolder1_sc2_total';
             var var_gr_total = '#ContentPlaceHolder1_sc2_gr_c';
          

             var var_aj_c = '#ContentPlaceHolder1_c2_c';
             var var_aj_p = '#ContentPlaceHolder1_c2_p';
             var var_aj_l = '#ContentPlaceHolder1_c2_l';
             var var_aj_hyc = '#ContentPlaceHolder1_c2_hyc';
             var var_aj_s = '#ContentPlaceHolder1_c2_s';
             var var_aj_total = '#ContentPlaceHolder1_c2_total';
             var num = 0;
             num = parseInt($('#ContentPlaceHolder1_num_c2').html()) + parseInt(1);

             calcular_componetes(grilla, var_c, var_p, var_l, var_hyc, var_s, var_sub_gr_c, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c, num, var_gr_total,var_mixto,var_distribucion);
           
           //  recalcular(grilla, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c);
             Calcular_resumen();
         }


         function ingesta_ce() {
             var grilla = "#<%=grillaextra.ClientID%> tbody tr";
             var var_c = "input[type=hidden][id*=ContentPlaceHolder1_grillaextra_hce_c]";
             var var_p = "input[type=hidden][id*=ContentPlaceHolder1_grillaextra_hce_p]";
             var var_l = "input[type=hidden][id*=ContentPlaceHolder1_grillaextra_hce_l]";
             var var_hyc = "input[type=hidden][id*=ContentPlaceHolder1_grillaextra_hce_hyc]";
             var var_s = "input[type=hidden][id*=ContentPlaceHolder1_grillaextra_hce_s]";
             var var_mixto = "input[type=hidden][id*=ContentPlaceHolder1_grillaextra_hce_mixto]";
             var var_mixto = "input[type=hidden][id*=ContentPlaceHolder1_grillaextra_hce_mixto]";
             var var_cc_c = "input[type=text][id*=ContentPlaceHolder1_grillaextra_txtccce_c]";
             var var_sub_gr_c = "input[type=text][id*=ContentPlaceHolder1_grillaextra_txtgrce_c]";
             var var_porcentaje = "input[type=text][id*=ContentPlaceHolder1_grillaextra_txtporcentaje_ce]";

             var var_sub_c = '#ContentPlaceHolder1_sce_c';
             var var_sub_p = '#ContentPlaceHolder1_sce_p';
             var var_sub_l = '#ContentPlaceHolder1_sce_l';
             var var_sub_hyc = '#ContentPlaceHolder1_sce_hyc';
             var var_sub_s = '#ContentPlaceHolder1_sce_s';
             var var_sub_total = '#ContentPlaceHolder1_sce_total';
             var var_gr_total = '#ContentPlaceHolder1_sce_gr_c';
          

             var var_aj_c = '#ContentPlaceHolder1_ce_c';
             var var_aj_p = '#ContentPlaceHolder1_ce_p';
             var var_aj_l = '#ContentPlaceHolder1_ce_l';
             var var_aj_hyc = '#ContentPlaceHolder1_ce_hyc';
             var var_aj_s = '#ContentPlaceHolder1_ce_s';
             var var_aj_total = '#ContentPlaceHolder1_ce_total';
             var num = 0;
             num = parseInt($('#ContentPlaceHolder1_num_ce').html()) + parseInt(1);

             calcular_componetes(grilla, var_c, var_p, var_l, var_hyc, var_s, var_sub_gr_c, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c, num, var_gr_total);
           
           //  recalcular(grilla, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c);
             Calcular_resumen();
         }

         function ingesta_hco() {
             var grilla = "#<%=grillahidrico.ClientID%> tbody tr";
             var var_c = "input[type=hidden][id*=ContentPlaceHolder1_grillahidrico_hhco_c]";
             var var_p = "input[type=hidden][id*=ContentPlaceHolder1_grillahidrico_hhco_p]";
             var var_l = "input[type=hidden][id*=ContentPlaceHolder1_grillahidrico_hhco_l]";
             var var_hyc = "input[type=hidden][id*=ContentPlaceHolder1_grillahidrico_hhco_hyc]";
             var var_s = "input[type=hidden][id*=ContentPlaceHolder1_grillahidrico_hhco_s]";
             var var_cc_c = "input[type=text][id*=ContentPlaceHolder1_grillahidrico_txtcchco_c]";
             var var_sub_gr_c = "input[type=text][id*=ContentPlaceHolder1_grillahidrico_txtgrhco_c]";
             var var_porcentaje = "input[type=text][id*=ContentPlaceHolder1_grillahidrico_txtporcentaje_hco]";

             var var_sub_c = '#ContentPlaceHolder1_shco_c';
             var var_sub_p = '#ContentPlaceHolder1_shco_p';
             var var_sub_l = '#ContentPlaceHolder1_shco_l';
             var var_sub_hyc = '#ContentPlaceHolder1_shco_hyc';
             var var_sub_s = '#ContentPlaceHolder1_shco_s';
             var var_sub_total = '#ContentPlaceHolder1_shco_total';
             var var_gr_total = '#ContentPlaceHolder1_shco_gr_c';


             var var_aj_c = '#ContentPlaceHolder1_hco_c';
             var var_aj_p = '#ContentPlaceHolder1_hco_p';
             var var_aj_l = '#ContentPlaceHolder1_hco_l';
             var var_aj_hyc = '#ContentPlaceHolder1_hco_hyc';
             var var_aj_s = '#ContentPlaceHolder1_hco_s';
             var var_aj_total = '#ContentPlaceHolder1_hco_total';
             var num = 0;
             num = parseInt($('#ContentPlaceHolder1_num_h').html()) + parseInt(1);



             calcular_componetes(grilla, var_c, var_p, var_l, var_hyc, var_s, var_sub_gr_c, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c, num, var_gr_total);
           
          //  recalcular(grilla, var_sub_c, var_sub_p, var_sub_l, var_sub_hyc, var_sub_s, var_sub_total, var_aj_c, var_aj_p, var_aj_l, var_aj_hyc, var_aj_s, var_aj_total, var_cc_c);
             Calcular_resumen();
         }
       
    
  
     
</script>

</asp:Content>
