<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="usuWeb.Formulario_web1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1 style="font-size:xx-large">Página de usuarios</h1>
        <h2 style="font-family: Arial; font-size:medium"> 
            Nif:   <asp:TextBox ID="TextBoxNIF" runat="server" Text=""></asp:TextBox>
        </h2>
        <h2 style="font-family: Arial; font-size:medium">
            Nombre: <asp:TextBox ID="TextBoxNombre" runat="server" Text=""></asp:TextBox>
        </h2>
        <h2 style="font-family: Arial; font-size: medium">
            Edad: <asp:TextBox ID="TextBoxEdad" runat="server" Text=""></asp:TextBox>
        </h2>

        &nbsp;<asp:Button ID="btnLeer"            runat="server" Text="Leer"            Width="39px"   OnClick="btnLeer_Click" />
        &nbsp;<asp:Button ID="btnLeerPrimero"     runat="server" Text="Leer Primero"    Width="100px"  OnClick="btnLeerPrimero_Click" />
        &nbsp;<asp:Button ID="btnLeerAnterior"    runat="server" Text="Leer Anterior"   Width="100px"  OnClick="btnLeerAnterior_Click" />
        &nbsp;<asp:Button ID="btnLeerSiguiente"   runat="server" Text="Leer Siguiente"  Width="110px"  OnClick="btnLeerSiguiente_Click" />
        &nbsp;<asp:Button ID="btnCrear"           runat="server" Text="Crear"           Width="70"     OnClick="btnCrear_Click" />
        &nbsp;<asp:Button ID="btnActualizar"      runat="server" Text="Actualizar"      Width="80px"   OnClick="btnActualizar_Click" />
        &nbsp;<asp:Button ID="btnBorrar"          runat="server" Text="Borrar"          Width="70px"   OnClick="btnBorrar_Click" />
        <br />
        <br />
        <br />
        <asp:Label ID="InformationLbl" runat="server" Text=""></asp:Label>
        
</asp:Content>

