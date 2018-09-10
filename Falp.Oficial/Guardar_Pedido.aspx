<%@ Page Title="" Language="C#" MasterPageFile="~/Paciente_Pedido.Master" AutoEventWireup="true"  EnableEventValidation = "false"
    CodeBehind="Guardar_Pedido.aspx.cs" Inherits="Falp.Oficial.Guardar_Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

 
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
        if (history.forward(1)) {
            history.replace(history.forward(1));
        }
    </script>

     <script type="text/javascript">
         function mensajes() {

             $('#myModal').modal();
         }
         function Agregar() {

             $('#agregar_alimentos').modal();
         }

    </script>

    <div class="row">
        <div class="col-sm-8" style="padding: 1px 1px 1px 6px">
            <div class="form-group">
                <h4>
                    GUARDAR PEDIDO :
                    <asp:Label ID="txtalimento" runat="server" ForeColor="Red"></asp:Label>

       
                </h4>
            </div>
        </div>

        <div class="col-sm-2" style="padding: 1px 1px 1px 1px">
            <div class="form-group">
            </div>
        </div>
        <div class="col-sm-2" style="padding: 1px 1px 1px 1px">
            <div class="form-group">

                  
            </div>
        </div>
    </div>
    <div class="row" style="padding: 1px 1px 1px 1px">
        <div class="col-sm-9" style="padding: 1px 1px 1px 4px">
            <div class="panel panel-info">
                <div class="panel-heading" style="height: 29px">
                    Filtro Distribuciòn</div>
                <div class="panel-body">
                    <div class="row" style="padding: 1px 1px 1px 1px">
                        <div class="col-sm-10" style="padding: 1px 1px 1px 1px">
                            <div class="form-group">
                              <center>
                            <div id="lblMensaje" style="visibility:hidden;">    <asp:Label ID="txtmsg" runat="server" ForeColor="Red"></asp:Label> </div>    </center>
                               <br />
                            </div>
                        </div>
                        
                        <div class="col-sm-2" style="padding: 1px 1px 1px 1px">

                            <asp:Button ID="btn_origen" CssClass="btn btn-info" runat="server" Text="Distr. Original"
                                OnClick="Volver_valores" />
                        </div>
                    </div>
                    <div class="col-sm-12" id="desa_liquido" runat="server" style="padding: 1px 1px 1px 1px">
                              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                <div class="panel panel-info">
                           
                                    <div class="panel-heading" style="height: 40px">
                                        <div class="col-sm-12" style="padding-right: 3px; padding-left: 3px">
                                            <div class="form-group">
                                                <asp:Button ID="btn_ag_liquidos_2" CssClass="btn btn-success" runat="server" Width="160px"
                                                    Height="27px" Text="Agr. Liquido" ToolTip="Agregar Liquido" OnClick="btn_agregar_liquido" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body" style="width: 100%;">
                                   
                                        <div class="grilla">
                                            <asp:GridView ID="grilla_liquido" runat="server" AllowPaging="True" CssClass="mydatagrid"
                                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                                OnRowDataBound="grilla_liquido_RowDataBound" OnSelectedIndexChanged="grilla_liquido_SelectedIndexChanged"
                                                AutoGenerateColumns="False" CellPadding="4" GridLines="Both" PageSize="5000" DataKeyNames="_Id_tipo_alimento,_Cod_tipo_alimento,_Cod_tipo_distribucion,_Vigencia,_Nom_tipo_distribucion ,
                                        _Cod_tipo_consistencia,_Cod_tipo_digestabilidad,_Cod_lactosa,_Cod_dulzor,_Cod_tipo_sales,_Cod_tipo_temperatura,_Cod_tipo_volumen,_Observacion,_Mixto"
                                                EmptyDataText="Estimado  Usuario, No existen Datos">
                                                <Columns>
                                                    <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="10%"
                                                        HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText=" Alimento" HeaderStyle-Width="60%"
                                                        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Estado" HeaderText="Tipo " HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="center" />
                                                    <asp:TemplateField HeaderText="Elim" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_estado2" ImageUrl="~/Imagenes/Botones/error.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Eliminar Alimento" OnClick="btn_eliminar_liquido" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Cant" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_cant1" ImageUrl="~/Imagenes/Botones/agregar.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Agregar 1 porcion mas Alimento" OnClick="btn_agregar_cant_li" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                   
                                    </div>
                   
                         </div>
                          </ContentTemplate>
                          <Triggers>
                          </Triggers>
                         </asp:UpdatePanel>
                        
                    </div>
                    <div class="col-sm-12" id="desa_solidos" runat="server" style="padding: 1px 1px 1px 1px">
                      <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                        <div class="panel panel-info">
                          
                                    <div class="panel-heading" style="height: 40px">
                                        <div class="col-sm-11" style="padding-right: 3px; padding-left: 3px">
                                            <div class="form-group">
                                                <asp:Button ID="btn_ag_solido_2" CssClass="btn btn-success" runat="server" Width="160px"
                                                    Height="27px" Text="Agr. Solido" ToolTip="Agregar Solido" OnClick="btn_agregar_solido" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body" style="width: 100%;">
                                        <div class="grilla">
                                            <asp:GridView ID="grilla_solido" runat="server" AllowPaging="True" CssClass="mydatagrid"
                                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                                OnRowDataBound="grilla_solido_RowDataBound" OnSelectedIndexChanged="grilla_solido_SelectedIndexChanged"
                                                AutoGenerateColumns="False" CellPadding="4" GridLines="Both" PageSize="1000" DataKeyNames="_Id_tipo_alimento,_Cod_tipo_alimento,_Cod_tipo_distribucion,_Vigencia,_Nom_tipo_distribucion,
                                         _Cod_tipo_consistencia,_Cod_tipo_digestabilidad,_Cod_lactosa,_Cod_dulzor,_Cod_tipo_sales,_Cod_tipo_temperatura,_Cod_tipo_volumen,_Observacion,_Mixto"
                                                EmptyDataText="Estimado  Usuario, No existen Datos">
                                                <Columns>
                                                    <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="10%"
                                                        HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText=" Alimento" HeaderStyle-Width="60%"
                                                        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Estado" HeaderText="Tipo" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="center" />
                                                    <asp:TemplateField HeaderText="Elim" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_estado2" ImageUrl="~/Imagenes/Botones/error.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Eliminar Alimento" OnClick="btn_eliminar_solido" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                      <asp:TemplateField HeaderText="Cant" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_cant2" ImageUrl="~/Imagenes/Botones/agregar.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Agregar 1 porcion mas Alimento" OnClick="btn_agregar_cant_so" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                        </div>
                         </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-12" id="desa_agregados" runat="server" style="padding: 1px 1px 1px 1px">
                       <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                         <ContentTemplate>
                        <div class="panel panel-info">
                                    <div class="panel-heading" style="height: 40px">
                                        <div class="col-sm-12" style="padding-right: 3px; padding-left: 3px">
                                            <div class="form-group">
                                                <asp:Button ID="btn_ag_agregado_2" CssClass="btn btn-success" runat="server" Width="160px"
                                                    Height="27px" Text="Agr. Agregados" ToolTip="Agregar Agregados" OnClick="btn_agregar_agregado" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body" style="width: 100%;">
                                        <div class="grilla">
                                            <asp:GridView ID="grilla_agregado" runat="server" AllowPaging="True" CssClass="mydatagrid"
                                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                                OnRowDataBound="grilla_agregado_RowDataBound" OnSelectedIndexChanged="grilla_agregado_SelectedIndexChanged"
                                                AutoGenerateColumns="False" CellPadding="4" GridLines="Both" PageSize="1000" DataKeyNames="_Id_tipo_alimento,_Cod_tipo_alimento,_Cod_tipo_distribucion,_Vigencia,_Nom_tipo_distribucion,
                                         _Cod_tipo_consistencia,_Cod_tipo_digestabilidad,_Cod_lactosa,_Cod_dulzor,_Cod_tipo_sales,_Cod_tipo_temperatura,_Cod_tipo_volumen,_Observacion,_Mixto"
                                                EmptyDataText="Estimado  Usuario, No existen Datos">
                                                <Columns>
                                                    <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="10%"
                                                        HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText=" Alimento" HeaderStyle-Width="60%"
                                                        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Estado" HeaderText="Tipo " HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="center" />
                                                    <asp:TemplateField HeaderText="Elim" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_estado2" ImageUrl="~/Imagenes/Botones/error.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Eliminar Alimento" OnClick="btn_eliminar_agregado" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Cant" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_cant3" ImageUrl="~/Imagenes/Botones/agregar.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Agregar 1 porcion mas Alimento" OnClick="btn_agregar_cant_ag" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                        </div>
                         </ContentTemplate>
                         <Triggers>
                         </Triggers>
                         </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-12" id="alm_1" runat="server" style="padding: 1px 1px 1px 1px">
                      <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                      <ContentTemplate>
                        <div class="panel panel-info">

                                    <div class="panel-heading" style="height: 40px">
                                        <div class="col-sm-12" style="padding-right: 3px; padding-left: 3px;">
                                            <div class="form-group">
                                                <asp:Button ID="btn_ag_sopa_2" CssClass="btn btn-success" runat="server" Width="160px"
                                                    Height="27px" Text="Agr. Sopa" ToolTip="Agregar Sopa" OnClick="btn_agregar_sopa" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body" style="width: 100%;">
                                        <div class="grilla">
                                            <asp:GridView ID="grilla_sopa" runat="server" AllowPaging="True" CssClass="mydatagrid"
                                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                                AutoGenerateColumns="False" CellPadding="4" GridLines="Both" OnRowDataBound="grilla_sopa_RowDataBound"
                                                OnSelectedIndexChanged="grilla_sopa_SelectedIndexChanged" PageSize="5000" DataKeyNames="_Id_tipo_alimento,_Cod_tipo_alimento,_Cod_tipo_distribucion,_Vigencia,_Nom_tipo_distribucion,
                                         _Cod_tipo_consistencia,_Cod_tipo_digestabilidad,_Cod_lactosa,_Cod_dulzor,_Cod_tipo_sales,_Cod_tipo_temperatura,_Cod_tipo_volumen,_Observacion,_Mixto"
                                                EmptyDataText="Estimado  Usuario, No existen Datos">
                                                <Columns>
                                                    <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="10%"
                                                        HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText="Seleccionar Alimentos"
                                                        HeaderStyle-Width="60%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Estado" HeaderText="Tipo" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="center" />
                                                    <asp:TemplateField HeaderText="Elim" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_estado2" ImageUrl="~/Imagenes/Botones/error.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Eliminar Alimento" OnClick="btn_eliminar_sopa" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Cant" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_cant4" ImageUrl="~/Imagenes/Botones/agregar.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Agregar 1 porcion mas Alimento" OnClick="btn_agregar_cant_sop" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                        </div>
                         </ContentTemplate>
                         <Triggers>
                         </Triggers>
                         </asp:UpdatePanel>
                        </div>
                    <div class="col-sm-12" id="alm_2" runat="server" style="padding: 1px 1px 1px 1px">
                     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                        <div class="panel panel-info">
                                    <div class="panel-heading" style="height: 40px">
                                        <div class="col-sm-12" style="padding-right: 3px; padding-left: 3px">
                                            <div class="form-group">
                                                <asp:Button ID="btn_ag_ensaladas_2" CssClass="btn btn-success" runat="server" Width="160px"
                                                    Height="27px" Text="Agr. Ensaladas" ToolTip="Agregar Ensaladas" OnClick="btn_agregar_ensalada" />
                                                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                                &nbsp;&nbsp;&nbsp; &nbsp;
                                                <asp:CheckBox ID="ck_mixto" runat="server" />
                                                &nbsp;&nbsp;&nbsp; &nbsp;
                                                <asp:Label ID="Label1" runat="server" Text="MIXTAS" ForeColor="Red"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body" style="width: 100%;">
                                        <div class="grilla">
                                            <asp:GridView ID="grilla_ensalada" runat="server" AllowPaging="True" CssClass="mydatagrid"
                                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" OnRowDataBound="grilla_ensalada_RowDataBound"
                                                OnSelectedIndexChanged="grilla_ensalada_SelectedIndexChanged" RowStyle-CssClass="rows"
                                                AutoGenerateColumns="False" CellPadding="4" GridLines="Both" PageSize="5000" DataKeyNames="_Id_tipo_alimento,_Cod_tipo_alimento,_Cod_tipo_distribucion,_Vigencia,_Nom_tipo_distribucion,
                                         _Cod_tipo_consistencia,_Cod_tipo_digestabilidad,_Cod_lactosa,_Cod_dulzor,_Cod_tipo_sales,_Cod_tipo_temperatura,_Cod_tipo_volumen,_Observacion,_Mixto"
                                                EmptyDataText="Estimado  Usuario, No existen Datos">
                                                <Columns>
                                                    <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="10%"
                                                        HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText="Seleccionar Alimentos"
                                                        HeaderStyle-Width="60%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Estado" HeaderText="Tipo " HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="center" />
                                                    <asp:TemplateField HeaderText="Elim" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_estado2" ImageUrl="~/Imagenes/Botones/error.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Eliminar Alimento" OnClick="btn_eliminar_ensalada" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Cant" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_cant5" ImageUrl="~/Imagenes/Botones/agregar.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Agregar 1 porcion mas Alimento" OnClick="btn_agregar_cant_en" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                        </div>
                         </ContentTemplate>
                        <Triggers>
                        </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-12" id="alm_3" runat="server" style="padding: 1px 1px 1px 1px">
                     <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <div class="panel panel-info">

                                    <div class="panel-heading" style="height: 40px">
                                        <div class="col-sm-12" style="padding-right: 3px; padding-left: 3px">
                                            <div class="form-group">
                                                <asp:Button ID="btn_ag_plato_fondo_2" CssClass="btn btn-success" runat="server" Width="160px"
                                                    Height="27px" Text="Agr. Plato Fondo" ToolTip="Agregar Plato de Fondo" OnClick="btn_agregar_plato_fondo" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body" style="width: 100%;">
                                        <div class="grilla">
                                            <asp:GridView ID="grilla_plato_fondo" runat="server" AllowPaging="True" CssClass="mydatagrid"
                                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" OnRowDataBound="grilla_plato_fondo_RowDataBound"
                                                OnSelectedIndexChanged="grilla_plato_fondo_SelectedIndexChanged" RowStyle-CssClass="rows"
                                                AutoGenerateColumns="False" CellPadding="4" GridLines="Both" PageSize="5000" DataKeyNames="_Id_tipo_alimento,_Cod_tipo_alimento,_Cod_tipo_distribucion,_Vigencia,_Nom_tipo_distribucion,
                                         _Cod_tipo_consistencia,_Cod_tipo_digestabilidad,_Cod_lactosa,_Cod_dulzor,_Cod_tipo_sales,_Cod_tipo_temperatura,_Cod_tipo_volumen,_Observacion,_Mixto"
                                                EmptyDataText="Estimado  Usuario, No existen Datos">
                                                <Columns>
                                                    <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="10%"
                                                        HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText="Seleccionar Alimentos"
                                                        HeaderStyle-Width="60%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Estado" HeaderText="Tipo" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="center" />
                                                    <asp:TemplateField HeaderText="Elim" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_estado2" ImageUrl="~/Imagenes/Botones/error.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Eliminar Alimento" OnClick="btn_eliminar_plato_fondo" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Cant" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_cant6" ImageUrl="~/Imagenes/Botones/agregar.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Agregar 1 porcion mas Alimento" OnClick="btn_agregar_cant_pf" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                        </div>
                         </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-12" id="alm_4" runat="server" style="padding: 1px 1px 1px 1px">
                     <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                      <ContentTemplate>
                        <div class="panel panel-info">

                                    <div class="panel-heading" style="height: 40px">
                                        <div class="col-sm-12" style="padding-right: 3px; padding-left: 3px">
                                            <div class="form-group">
                                                <asp:Button ID="btn_ag_acompañamiento_2" CssClass="btn btn-success" runat="server"
                                                    Width="160px" Height="27px" Text="Agr. Acompañamiento" ToolTip="Agregar Acompañamiento"
                                                    OnClick="btn_agregar_acompañamiento" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body" style="width: 100%;">
                                        <div class="grilla">
                                            <asp:GridView ID="grilla_acompañamiento" runat="server" AllowPaging="True" CssClass="mydatagrid"
                                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" OnRowDataBound="grilla_acompañamiento_RowDataBound"
                                                OnSelectedIndexChanged="grilla_acompañamiento_SelectedIndexChanged" RowStyle-CssClass="rows"
                                                AutoGenerateColumns="False" CellPadding="4" GridLines="Both" PageSize="5000" DataKeyNames="_Id_tipo_alimento,_Cod_tipo_alimento,_Cod_tipo_distribucion,_Vigencia,_Nom_tipo_distribucion,
                                         _Cod_tipo_consistencia,_Cod_tipo_digestabilidad,_Cod_lactosa,_Cod_dulzor,_Cod_tipo_sales,_Cod_tipo_temperatura,_Cod_tipo_volumen,_Observacion,_Mixto"
                                                EmptyDataText="Estimado  Usuario, No existen Datos">
                                                <Columns>
                                                    <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="10%"
                                                        HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText="Seleccionar Alimentos"
                                                        HeaderStyle-Width="60%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Estado" HeaderText="Tipo" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="center" />
                                                    <asp:TemplateField HeaderText="Elim" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_estado2" ImageUrl="~/Imagenes/Botones/error.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Eliminar Alimento" OnClick="btn_eliminar_acompañamiento" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Cant" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_cant7" ImageUrl="~/Imagenes/Botones/agregar.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Agregar 1 porcion mas Alimento" OnClick="btn_agregar_cant_ac" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                        </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                        </asp:UpdatePanel>
                    </div>


                    <div class="col-sm-12" id="alm_5" runat="server" style="padding: 1px 1px 1px 1px">
                     <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                      <ContentTemplate>
                        <div class="panel panel-info">
                                    <div class="panel-heading" style="height: 40px">
                                        <div class="col-sm-12" style="padding-right: 3px; padding-left: 3px">
                                            <div class="form-group">
                                                <asp:Button ID="btn_ag_postre_2" CssClass="btn btn-success" runat="server" Width="160px"
                                                    Height="27px" Text="Agr. Postres" ToolTip="Agregar Postre" OnClick="btn_agregar_postre" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body" style="width: 100%;">
                                        <div class="grilla">
                                            <asp:GridView ID="grilla_postre" runat="server" AllowPaging="True" CssClass="mydatagrid"
                                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                                AutoGenerateColumns="False" CellPadding="4" GridLines="Both" OnRowDataBound="grilla_postre_RowDataBound"
                                                OnSelectedIndexChanged="grilla_postre_SelectedIndexChanged" PageSize="5000" DataKeyNames="_Id_tipo_alimento,_Cod_tipo_alimento,_Cod_tipo_distribucion,_Vigencia,_Nom_tipo_distribucion,
                                         _Cod_tipo_consistencia,_Cod_tipo_digestabilidad,_Cod_lactosa,_Cod_dulzor,_Cod_tipo_sales,_Cod_tipo_temperatura,_Cod_tipo_volumen,_Observacion,_Mixto"
                                                EmptyDataText="Estimado  Usuario, No existen Datos">
                                                <Columns>
                                                    <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="10%"
                                                        HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText="Seleccionar Alimentos"
                                                        HeaderStyle-Width="60%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Estado" HeaderText="Tipo " HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="center" />
                                                    <asp:TemplateField HeaderText="Elim" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_estado2" ImageUrl="~/Imagenes/Botones/error.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Eliminar Alimento" OnClick="btn_eliminar_postre" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Cant" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_cant1" ImageUrl="~/Imagenes/Botones/agregar.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Agregar 1 porcion mas Alimento" OnClick="btn_agregar_cant_po" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                        </div>
                         </ContentTemplate>
                         <Triggers>
                        </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-12" id="hco" runat="server" style="padding: 1px 1px 1px 1px">
                     <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                      <ContentTemplate>
                        <div class="panel panel-info">
                                    <div class="panel-heading" style="height: 40px">
                                        <div class="col-sm-11" style="padding-right: 3px; padding-left: 3px">
                                            <div class="form-group">
                                                <asp:Button ID="btn_ag_hidrico_2" CssClass="btn btn-success" runat="server" Width="160px"
                                                    Height="27px" Text="Agr. Hidricos" ToolTip="Agregar Hidricos" OnClick="btn_agregar_hidrico" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-body" style="width: 100%;">
                                        <div class="grilla">
                                            <asp:GridView ID="grilla_hidrico" runat="server" AllowPaging="True" CssClass="mydatagrid"
                                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                                OnRowDataBound="grilla_hidrico_RowDataBound" OnSelectedIndexChanged="grilla_hidrico_SelectedIndexChanged"
                                                AutoGenerateColumns="False" CellPadding="4" GridLines="Both" PageSize="1000" DataKeyNames="_Id_tipo_alimento,_Cod_tipo_alimento,_Cod_tipo_distribucion,_Vigencia,_Nom_tipo_distribucion,
                                         _Cod_tipo_consistencia,_Cod_tipo_digestabilidad,_Cod_lactosa,_Cod_dulzor,_Cod_tipo_sales,_Cod_tipo_temperatura,_Cod_tipo_volumen,_Observacion,_Mixto"
                                                EmptyDataText="Estimado  Usuario, No existen Datos">
                                                <Columns>
                                                    <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="10%"
                                                        HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText=" Alimento" HeaderStyle-Width="60%"
                                                        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Estado" HeaderText="Tipo" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="center" />
                                                    <asp:TemplateField HeaderText="Elim" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_estado2" ImageUrl="~/Imagenes/Botones/error.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Eliminar Alimento" OnClick="btn_eliminar_hidrico" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Cant" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btn_cant9" ImageUrl="~/Imagenes/Botones/agregar.png" runat="server"
                                                                Width="16px" Height="16px" ToolTip="Agregar 1 porcion mas Alimento" OnClick="btn_agregar_cant_hi" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
          
                        </div>
                         </ContentTemplate>
                        <Triggers>
                       </Triggers>
                       </asp:UpdatePanel>
                    </div>


                    </div>
                </div>
            </div>

            
     


        <div class="col-sm-3">
            <asp:UpdatePanel ID="UpdatePanel145" runat="server">
                <ContentTemplate>
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label ID="txtal" runat="server" ForeColor="Red"></asp:Label>
                            <br />
                            Descripción Componentes
                        </div>
                        <div class="panel-body" style="width: 100%">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Consistencia</label>
                                    <asp:DropDownList ID="cboconsistencia" Style="height: 29px; width: 100%" runat="server"
                                        OnSelectedIndexChanged="cboconsistencia_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">Selec. Consistencia</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Digestibilidad</label>
                                    <asp:DropDownList ID="cbodigestabilidad" Style="height: 29px; width: 100%" runat="server"
                                        OnSelectedIndexChanged="cbodigestabilidad_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">Selec. Digestabilidad</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Dulzor</label>
                                    <asp:DropDownList ID="cbodulzor" Style="height: 29px; width: 100%" runat="server"
                                        OnSelectedIndexChanged="cbodulzor_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">Selec. Dulzor</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Lactosa</label>
                                    <asp:DropDownList ID="cbolactosa" Style="height: 29px; width: 100%" runat="server"
                                        OnSelectedIndexChanged="cbolactosa_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">Selec. Lactosa</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Sal</label>
                                    <asp:DropDownList ID="cbotipo_sal" Style="height: 29px; width: 100%" runat="server"
                                        OnSelectedIndexChanged="cbotipo_sal_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">Selec.  Sal</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Temperatura</label>
                                    <asp:DropDownList ID="cbotemperatura2" Style="height: 29px; width: 100%" runat="server"
                                        OnSelectedIndexChanged="cbotemperatura2_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">Selec.  Sal</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Volumen</label>
                                    <asp:DropDownList ID="cbovolumen2" Style="height: 29px; width: 100%" runat="server"
                                        OnSelectedIndexChanged="cbovolumen2_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0">Selec.  Sal</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label style="width: 100%">
                                        Observación
                                    </label>
                                    <asp:TextBox type="text" ID="txtcomentario" placeholder="Observación " TextMode="MultiLine"
                                        Style="height: 150px; resize: none; width: 100%" runat="server" AutoPostBack="True"
                                        OnTextChanged="txtcomentario_TextChanged" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
          <div class="modal fade" id="mensajes" tabindex="-1" role="dialog" aria-labelledby="contactLabel"
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
                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                        <ContentTemplate>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <asp:Label type="text" ID="txtmsg2" runat="server" />
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModal">
    <div class="modal-dialog">
      <div class="modal-content">
      
        <!-- Modal Header -->
        <div class="modal-header">
          <h4 class="modal-title">Modal Heading</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>
        
        <!-- Modal body -->
        <div class="modal-body">
          Modal body..
        </div>
        
        <!-- Modal footer -->
        <div class="modal-footer">
          <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
        </div>
        
      </div>
    </div>
  </div>

       
    <div class="modal fade" id="agregar_alimentos" tabindex="-1" role="dialog" aria-labelledby="contactLabel"
        aria-hidden="false">
     
        <div class="modal-dialog" style="width: 90%; height: 500px" >
            <div class="panel panel-success" >
        
                <div class="panel-heading">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="false">
                        ×</button>
                    <h4 class="panel-title" id="H3">
                        <span class="glyphicon glyphicon-info-sign"></span>Agregar Informaciòn      </h4>
                </div>
           
                <div class="modal-body" style="padding: 5px; height: 400px; overflow: scroll"">
                    <div class="col-sm-6">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                Alimentos Extra
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                <ContentTemplate>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <right>
                                   
                                    <asp:TextBox type="text" ID="txtextra" runat="server" placeholder=" ALIMENTOS" Style="height: 29px; width: 85%" /><asp:ImageButton ID="btn_extra" ImageUrl="~/Imagenes/Botones/buscar.png" runat="server" Width="22px" Height="22px" ToolTip="Limpiar" OnClick="buscar_extras"  /></right>
                                        </div>
                                    </div>
                                    <div class="panel-body" style="width: 100%; height: 280px; overflow: scroll">
                                        <div class="grilla">
                                            <asp:GridView ID="grilla_extra" runat="server" AllowPaging="True" CssClass="mydatagrid"
                                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                                OnRowDataBound="grilla_extra_RowDataBound" OnSelectedIndexChanged="grilla_extra_SelectedIndexChanged"
                                                AutoGenerateColumns="False" CellPadding="4" GridLines="Both" PageSize="5000" DataKeyNames="_Id_tipo_alimento,_Cod_tipo_alimento,_Cod_tipo_distribucion,_Vigencia,_Nom_alimento_especial,_Cod_alimento_especial, _Cod_tipo_consistencia,_Cod_tipo_digestabilidad,_Cod_lactosa,_Cod_dulzor,_Cod_tipo_sales,_Cod_tipo_temperatura,_Cod_tipo_volumen,_Mixto,
                                    _No_sal,_No_dulzor,_No_lactosa,_Cod_sales_pref,_Cod_dulzor_pref,_Cod_lactosa_pref ,_Cod_consistencia_pref,_Cod_digestabilidad_pref" EmptyDataText="Estimado  Usuario, No existen Datos">
                                                <Columns>
                                                    <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="15%"
                                                        HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="_Nom_tipo_distribucion" HeaderText="Distribución" HeaderStyle-Width="30%"
                                                        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText=" Alimento" HeaderStyle-Width="50%"
                                                        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Estado" HeaderText="Tipo " HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="center" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                Alimentos Especiales
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                </div>
                            </div>
                            <div class="col-sm-8">
                                <div class="col-sm-10">
                                    <div class="form-group">
                                    
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox type="text" ID="txtespecial" runat="server" placeholder=" ALIMENTO ESPECIALES" OnTextChanged="txtespecial_TextChanged" ToolTip="Ingrese el Alimento  Deseado  y Presione Enter" AutoPostBack="true" CausesValidation="true" Style="height: 29px; width: 85%" />
                                                <asp:ImageButton ID="btn_agregar_ali" ImageUrl="~/Imagenes/Botones/add.png" runat="server"
                                                    Width="22px" Height="22px" ToolTip="Limpiar" OnClick="agregar_especial" />
                                                <asp:HiddenField ID="especial3" runat="server" />
                                            </ContentTemplate>
                                            <Triggers>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>
                            <div class="panel-body" style="width: 100%; height: 280px; overflow: scroll">
                                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate>
                                        <div class="grilla">
                                            <asp:GridView ID="grilla_especial" runat="server" AllowPaging="True" CssClass="mydatagrid"
                                                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                                OnRowDataBound="grilla_especial2_RowDataBound" OnSelectedIndexChanged="grilla_especial2_SelectedIndexChanged"
                                                AutoGenerateColumns="False" CellPadding="4" GridLines="Both" PageSize="5000" DataKeyNames="_Cod_tipo_alimento,_Cod_tipo_distribucion,_Vigencia, _Cod_tipo_consistencia,_Cod_tipo_digestabilidad,_Cod_lactosa,_Cod_dulzor,_Cod_tipo_sales,_Cod_tipo_temperatura,_Cod_tipo_volumen,_Mixto,
                                    _No_sal,_No_dulzor,_No_lactosa,_Cod_sales_pref,_Cod_dulzor_pref,_Cod_lactosa_pref" EmptyDataText="Estimado  Usuario, No existen Datos">
                                                <Columns>
                                                    <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="15%"
                                                        HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="center" />
                                                    <asp:BoundField DataField="_Nom_tipo_distribucion" HeaderText="Distribución" HeaderStyle-Width="30%"
                                                        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText=" Alimento" HeaderStyle-Width="50%"
                                                        HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField DataField="_Estado" HeaderText="Tipo " HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="center" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>                   
                </div>        
            </div>
        </div>
 </div>
  

           
    <div id='imagenFlotante'>
                 
                <asp:ImageButton ID="btn_guardar_1" ImageUrl="~/Imagenes/Botones/save_1.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Guardar" OnClick="Guardar" /><br />
                <asp:ImageButton ID="ImageButton1" ImageUrl="~/Imagenes/Botones/volver_1.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Volver Pedido" OnClick="volver" /><br />
                <asp:ImageButton ID="btn_guardar1" ImageUrl="~/Imagenes/Botones/menu_2.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Regresar a Listado de Pacientes" OnClick="btn_volver" />
          
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
