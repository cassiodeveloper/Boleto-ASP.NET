<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FuncTeste_IPTE.aspx.cs" Inherits="FuncTeste_IPTE" %>

<%@ Register src="Rodape.ascx" tagname="Rodape" tagprefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BoletoASP.Net: Convers�o do C�digo de Barras em IPTE (Linha digit�vel)</title>
    <meta name="Description" content="Veja como converter o c�digo de barras de um boleto em linha digit�vel (IPTE), este exemplo acompanha os fontes em C#" />
    <meta name="keywords" content="BoletoASP.Net, Boleto ASP, Boleto, ASP.Net, T�tulo de Cobran�a, IPTE, linha digit�vel, C�digo de Barras, C#, Algoritimo, Convers�o, C�digo Fonte"/>
    <style type="text/css">
        body
        {
        	font-family: Verdana;
        	font-size: 10pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p>Veja como converter o c�digo de barras de um boleto em linha digit�vel (IPTE), este exemplo acompanha os fontes em C#<br>
    alguns geradores de boleto se baseiam no IPTE para gerar o boleto e em seguida o c�digo de barras<br>
    mas a maioria gera o c�digo de barras e depois o IPTE<br>
    Digite e c�digo de barras e veja o IPTE gerado, com sua respectiva imagem de c�digo de barras</p>
        C�digo de Barras:
        <asp:TextBox ID="txtCodBar" runat="server" Width="400px">409  9  2  1546  0000100000  5  1234561  00  112233445566777</asp:TextBox>
        <asp:Button ID="btnExecute" runat="server" OnClick="btnExecute_Click" Text="Gerar" /><br />
        IPTE:
        <b><asp:Label ID="lblIPTE" runat="server" Text="?"></asp:Label></b>
        <br><br>
        C�digo de Barras:<br>
        <asp:Label ID="lblCodBar" runat="server" Text="?"></asp:Label>
    <uc1:Rodape ID="Rodape1" runat="server" />
    </form>
</body>
</html>
