<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FuncTeste_CampoLivre.aspx.cs" Inherits="FuncTeste_CampoLivre" %>
<%@ Register src="Rodape.ascx" tagname="Rodape" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>BoletoASP.Net: Calculo do Modulo 11 em C# base 7 ou 9</title>
    <meta name="Description" content="O Calculo do Campo Livre � o que muda de banco para banco, assim tendo montado o campo livre corretamente, implantar um novo banco � simples" />
    <meta name="keywords" content="BoletoASP.Net, Boleto ASP, Boleto, ASP.Net, T�tulo de Cobran�a, C#, Modulo 11, campo Livre c�digo de barras"/>
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
        <p>Este exemplo usa informa��es fixas para gerar o campo livre, o c�digo de barras e por fim a linha digit�vel!</p>
        Calculos: <br/>
        <pre runat="server" id="logOut"></pre>
        <hr/>
        <br/>
        Campo Livre: <asp:Label runat="server" id="CampoLivre" Font-Bold="true"/> <br/>
        C�digo de Barras: <asp:Label runat="server" id="CodigoBarras" Font-Bold="true" /> <br/>
        Linha Digit�vel: <asp:Label runat="server" id="LinhaDigitavel" Font-Bold="true"/> <br/>
        <asp:Literal runat="server" id="Barras"/>
        <br/>
        <br/><uc1:Rodape runat="server" />
    </form>
</body>
</html>
