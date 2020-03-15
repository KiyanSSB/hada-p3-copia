<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="usuWeb.Formulario_web1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="font-size:xx-large">Página de usuarios</h1>
    
    <h2 style="font-family: Arial; font-size:medium"> 
        Nif:   <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </h2>
    
    <h2 style="font-family: Arial; font-size:medium">
        Nombre: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </h2>

    <h2 style="font-family: Arial; font-size: medium">
        Edad: <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </h2>


    
    <asp:Button ID="btnLeer"            runat="server" Text="Leer" Width="39px" />
    &nbsp;
    <asp:Button ID="btnLeerPrimero"     runat="server" Text="Leer Primero" Width="100px" />
    &nbsp;
    <asp:Button ID="btnLeerAnterior"    runat="server" Text="Leer Anterior" Width="96px" />
    &nbsp;
    <asp:Button ID="btnLeerSiguiente"   runat="server" Text="Leer Siguiente" Width="109px" />
    &nbsp;
    <asp:Button ID="btnCrear"           runat="server" Text="Crear" />
    &nbsp;
    <asp:Button ID="btnActualizar"      runat="server" Text="Actualizar" Width="81px" />
    &nbsp;
    <asp:Button ID="btnBorrar"          runat="server" Text="Borrar" />

</asp:Content>

