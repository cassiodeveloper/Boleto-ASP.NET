<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FuncTeste_Modulo10.aspx.vb" Inherits="FuncTeste_Modulo10" %>
<%@ Register src="Rodape.ascx" tagname="Rodape" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BoletoASP.Net: Calculo do Modulo 10 em C# para Gera��o de Boletos</title>
    <meta name="Description" content="O Calculo do Modulo 10 � usado para calcular os d�gitos verificadores dos Campos 1,2,3 da linha digit�vel (IPTE), e por alguns bancos na montagem da linha digit�vel" />
    <meta name="keywords" content="BoletoASP.Net, Boleto ASP, Boleto, ASP.Net, T�tulo de Cobran�a, Algorimtimo, c�digo, C#, exemplo, modulo, modulo 10, calculo do digito verificador, digito boleto"/>
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
        <p>Calculo do Modulo 10 � usado para calcular os d�gitos verificadores dos Campos 1,2,3 da linha digit�vel (IPTE), e por alguns bancos na montagem da linha digit�vel<br>
        Mesmo sem adquirir os fontes do componente, vem o metodo dentro da classe Funcoes em C#, totalmente aberto, para analise e estudo</p>
        Numero de Entrada: <asp:TextBox ID="txtDigitos" runat="server" Text="12345"></asp:TextBox>
        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" />
        <br />
        Resultado: <asp:Label ID="lblResultado" runat="server"></asp:Label>
        <uc1:Rodape ID="Rodape1" runat="server" />
    </form>

</body>
</html>
