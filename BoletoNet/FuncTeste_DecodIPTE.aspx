<%@ Page Language="VB" %>

<%@ Register src="Rodape.ascx" tagname="Rodape" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub btnGetCodBar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.lblCodBar.Text = Funcoes.CalcCodBar(Me.txtIPTE.Text)
        'remove o ponto e o tra�o restando apenas numeros
        Dim cCodBar As String = Me.lblCodBar.Text.Replace(".", "").Replace("-", "")
        Me.lblCodBar.Text &= "<br><img src='CodigoBarras.ashx?c=" & cCodBar & "' alt='Gerador de C�digo de Barras'>"
    End Sub
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BoletoASP.Net: Convers�o do IPTE (Linha digit�vel) em C�digo de Barras</title>
    <meta name="Description" content="Veja como converter o IPTE (linh adigit�vel) em c�digo de barras, este exemplo acompanha os fontes em C#" />
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
    <div>
        Digite o IPTE:<br />
        <asp:TextBox ID="txtIPTE" runat="server" Width="400px">422 9 70040 8 0000278247 2 2617300111 1 8 10010000018084</asp:TextBox>
        <asp:Button ID="btnGetCodBar" runat="server" Text="Calcular" OnClick="btnGetCodBar_Click" /><br />
        <br />
        C�digo de Barras:<br />
        Banco.Moeda.Digito.VencimentoValor.CampoLivre<br>
        <asp:Label ID="lblCodBar" runat="server" Font-Bold=true></asp:Label></div>
    </form>
    <uc1:Rodape ID="Rodape1" runat="server" />

</body>
</html>
