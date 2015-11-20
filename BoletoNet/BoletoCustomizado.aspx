<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BoletoCustomizado.aspx.vb" Inherits="BoletoCustomizado" %>
<%@ Register src="Rodape.ascx" tagname="Rodape" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BoletoASP.Net: Boleto com Layout Customizado / Personalizado</title>
    <meta name="Description" content="� possivel sair completamente do padr�o visual e criar seu proprio layout de boleto, sem ter que se preoculpar com as rotinas de calculo, veja esse exemplo" />
    <meta name="keywords" content="BoletoASP.Net, Boleto ASP, Boleto, ASP.Net, T�tulo de Cobran�a, layout, customizado, c�digo fonte, boleto personalizado, layout personalizado"/>
    <style type="text/css">
        body
        {
        	font-family: Verdana;
        	font-size: 10pt;
        }
		.BolCell { FONT-SIZE: 7pt; FONT-FAMILY: Verdana }
	    .BolField { FONT-WEIGHT: bold; FONT-SIZE: 8pt; FONT-FAMILY: Verdana }
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <p>Este exemplo embora use o layout visto nos demais exemplo ele � totalmente aberto, ou seja, todos os textos, s�o LABEL, ele � formado por TABLE<br/>
    Desta forma voc� pode melhorar, e customizar o layour do boleto, aumentar campos, descri��es etc...<br/>
    Vale lembrar que o BANCO tem que aprovar seu layout, veja isso com seu gerente<br/>
    Mas os calculos, e rotinas, voc� pode chama-las direto de acordo com sua necessidade, veja abaixo o c�digo fonte tamb�m!</p>
    <table width=640 height=200><tr><td align=center bgcolor=yellow>
        <strong><span style="font-size: 24pt">Parte Superior: <br>RECIBO DO SACADO<br><br>Fa�a aqui o que desejar<br> (layout livre)</span></strong></td></tr></table>
        <img src="Imagens/corte.gif" /><br />
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 640px; border-collapse: collapse">
            <tr>
                <td style="width: 160px">
                    <img src="Imagens/356.gif" /></td>
                <td style="width: 2px" valign="bottom">
                    <img height="30" src="Imagens/p.gif" width="2" /></td>
                <td align="middle" class="BolField" style="width: 50px">
                    356-5</td>
                <td style="width: 2px" valign="bottom">
                    <img height="30" src="Imagens/p.gif" width="2" /></td>
                <td align="right" class="BolField">
                    <asp:Label ID="lblIPTE" runat="server"></asp:Label></td>
            </tr>
        </table>
        <table border="1" bordercolordark="#000000" bordercolorlight="#000000" cellpadding="1"
            cellspacing="0" rules="all" style="border-right: black 1px solid; border-top: black 1px solid;
            border-left: black 1px solid; width: 640px; border-bottom: black 1px solid; border-collapse: collapse">
            <tr>
                <td class="BolCell" colspan="6" style="width: 480px">
                    Local de pagamento<br />
                    <font class="BolField"><strong><span style="font-size: 8pt">&nbsp;At� o vencimento,
                        pag�vel em qualquer banco.</span></strong></font></td>
                <td class="BolCell" style="font-weight: bold; font-size: 8pt; width: 130px; background-color: lightgrey">
                    Vencimento<br />
                    <div align="right" class="BolField">
                        <asp:Label ID="lblVencimento" runat="server"></asp:Label>&nbsp;</div>
                </td>
            </tr>
            <tr>
                <td class="BolCell" colspan="6">
                    Cedente<br />
                    <font class="BolField"><strong><span style="font-size: 8pt">&nbsp;Impactro Inform�tica</span></strong></font></td>
                <td class="BolCell" style="font-weight: bold; font-size: 8pt; white-space: nowrap">
                    Ag�ncia/Conta Cedente<br />
                    <div align="right" class="BolField">
                        <asp:Label ID="lblAgenciaConta" runat="server"></asp:Label>&nbsp;</div>
                </td>
            </tr>
            <tr>
                <td class="BolCell" style="width: 120px">
                    Data Documento<br />
                    <font class="BolField"><strong><span style="font-size: 8pt">&nbsp;<asp:Label ID="lblDataDoc"
                        runat="server"></asp:Label></span></strong></font></td>
                <td class="BolCell" colspan="2" style="font-weight: bold; font-size: 8pt; width: 120px">
                    N� Documento<br />
                    <font class="BolField">&nbsp;<asp:Label ID="lblNumDoc" runat="server"></asp:Label></font></td>
                <td class="BolCell" style="font-size: 8pt">
                    Esp. Doc.<br />
                    <font class="BolField"><strong>&nbsp;RC</strong></font></td>
                <td class="BolCell" style="font-weight: bold; font-size: 8pt">
                    Aceite<br />
                    <font class="BolField">&nbsp;N</font></td>
                <td class="BolCell" style="font-size: 8pt; width: 110px">
                    Data Proces.<br />
                    <font class="BolField"><strong>&nbsp;<asp:Label ID="lblData" runat="server"></asp:Label></strong></font></td>
                <td class="BolCell" style="font-weight: bold; font-size: 8pt; white-space: nowrap">
                    Nosso N�mero<br />
                    <div align="right" class="BolField">
                        <asp:Label ID="lblNossoNumero" runat="server"></asp:Label>&nbsp;</div>
                </td>
            </tr>
            <tr>
                <td class="BolCell">
                    Uso do Banco<br />
                    <font class="BolField"><strong><span style="font-size: 8pt">&nbsp;</span></strong></font></td>
                <td class="BolCell" style="font-weight: bold; font-size: 8pt">
                    Carteira<br />
                    <font class="BolField">Padr�o</font></td>
                <td class="BolCell" style="font-size: 8pt; background-color: lightgrey">
                    Esp�cie<br />
                    <font class="BolField"><strong>&nbsp;R$</strong></font></td>
                <td class="BolCell" colspan="2" style="font-weight: bold; font-size: 8pt; width: 120px">
                    Quantidade<br />
                    <font class="BolField">&nbsp;</font></td>
                <td class="BolCell" style="font-size: 8pt">
                    (x)Valor<br />
                    <font class="BolField"><strong>&nbsp;</strong></font></td>
                <td class="BolCell" style="font-weight: bold; font-size: 8pt; background-color: lightgrey">
                    (=)Valor Documento<br />
                    <div align="right" class="BolField">
                        <asp:Label ID="lblValorDocumento" runat="server"></asp:Label>&nbsp;</div>
                </td>
            </tr>
            <tr>
                <td class="BolCell" colspan="6" rowspan="5" valign="top">
                    Instru��es<br />
                    <font class="BolField"><strong><span style="font-size: 8pt">Todas as informa��es deste
                        bloqueto s�o de exclusiva responsabilidade do cedente<br><br>Vers�o de demostra��o N�O PAGUE</span></strong></font></td>
                <td class="BolCell" style="font-weight: bold; font-size: 8pt">
                    (-)Descontos/Abatim.<br />
                    <div align="right" class="BolField">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td class="BolCell">
                    (-)Outras Dedu��es<br />
                    <div align="right" class="BolField">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td class="BolCell">
                    (+)Mora/Multa<br />
                    <div align="right" class="BolField">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td class="BolCell">
                    (+)Outros Acr�scimos<br />
                    <div align="right" class="BolField">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td class="BolCell">
                    (=)Valor<br />
                    <div align="right" class="BolField">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td class="BolCell" colspan="7" style="height: 70px" valign="top">
                    Sacador/Avalista<br />
                    <font class="BolField"><strong><span style="font-size: 8pt">
                        <asp:Label ID="lblSacado" runat="server"></asp:Label></span></strong></font></td>
            </tr>
        </table>
        <table style="font-weight: bold; font-size: 8pt" width="640">
            <tr>
                <td align="right" class="BolCell">
                    Autentica��o Mec�nica - FICHA DE COMPENSA��O</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblcodBar" runat="server"></asp:Label></td>
            </tr>
        </table>
    </div>
    <br/>
    <b>C�digo Fonte:</b>
    <pre>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Este exemplo, � um layoout, e calculo livre, 100% customizado, que n�o utiliza a Impactro.Cobranca.DLL
        'Mas este exemplo utiliza as classes de fun��es em C# da pasta APP_CODE, 
        'que tem todas as fun��e nescess�rias para a gera��o do boleto

        'Baseado no exemplo do documento (p�gina 11) http://www.boletoasp.com.br/doc/Real_COBRANCA_240_POSICOES_REAL_v2.pdf

        'Vari�veis principais para o calculo
        Dim cAgenciaNumero As String = "501"            'N�mero da Agencia do Cedente
        Dim cContaNumero As String = "6703255"          'N�mero da Conta do Cedente
        Dim cNossoNumero As String = "3020"             'N�mero principal do boleto a ser gerado
        Dim nValor As Double = 35.0                     'Valor do boleto
        Dim dtVenc As DateTime = CDate("2/10/2001")    'Data de vencimento




        '1�) parte ======================================
        '	04. LEIAUTE DO C�DIGO DE BARRAS PADR�O (vale para qualquer banco)
        '...............................................................    
        '   N.    POSI��ES     PICTURE     USAGE        CONTE�O                
        '...............................................................    
        '    01    001 a 003    9/003/      Display      Identifica��o do banco
        '    02    004 a 004    9/001/      Display      9 /Real/
        '(a) 03    005 a 005    9/001/      Display      DV /*/
        '(b) 04    006 a 009    9/004/      Display      fator de vencimento
        '    05    010 a 019    9/008/v99   Display      Valor
        '    06    020 a 044    9/025/      Display      CAMPO LIVRE
        '...............................................................    
        'OBS: 1 - o digito verificador da 5 (quinta) posi��o � calculado     
        '         com base no m�dulo 11 espec�fico previsto no item 12;         
        'OBS: 2 - o fator de vencimento � calculado com base na metodologia 
        '         descrita no item 05.                                          

        Dim cValor As String = CInt(nValor * 100)               'Multiplicando por 100 a centenas somem, e elimina-se o ponto decimal (cuidado com arredondamentos)
        Dim nFatVenc As Integer = Funcoes.CalcFatVenc(dtVenc)   'calcula o fator do vencimento
        'Concatena-se o Numero do banco (3 digitos), o c�digo da moeda ('9' Real), o Fator de vencimento e o Valor
        Dim cCodePadrao As String = _
            "356" & _
            "9" & _
            Right("000" & nFatVenc, 4) & _
            Right("0000000000" & cValor, 10)




        '2�) parte ======================================
        'Monta o campo livre que varia de acordo com o banco, neste caso o banco Real

        'Fixa os tamanhos das vari�veis
        cNossoNumero = Right("000000000000" & cNossoNumero, 13)
        cAgenciaNumero = Right("000" & cAgenciaNumero, 4)
        cContaNumero = Right("000000" & cContaNumero, 7)

        'Calcula o Digito de controle
        Dim cDAC As String = Funcoes.Modulo10(cNossoNumero + cAgenciaNumero + cContaNumero)

        'Finaliza o campo livre
        Dim cLivre As String = cAgenciaNumero & cContaNumero & cDAC & cNossoNumero





        '3�) parte ======================================
        'Finaliza o c�digo de barras inserindo o digito de controle final
        Dim cDV As String = Funcoes.Modulo11Padrao(cCodePadrao & cLivre, 9)
        Dim cCodBarras As String = cCodePadrao.Substring(0, 4) & cDV & cCodePadrao.Substring(4, 14) & cLivre

        'com o c�digo de barras, monta-se a linha digit�vel
        Dim cIPTE As String = Funcoes.CalcLinDigitavel(cCodBarras)

        'Transforma-se a sequencia numerica em uma string que representa o c�digo de barras
        Dim cBarras As String = Funcoes.BarCode(cCodBarras)
        'substiue-se as duplas de caracteres que representam as barras por suas respectivas imagens
        cBarras = cBarras.Replace("bf", "<img src='imagens/b.gif' width=1 height=50>")
        cBarras = cBarras.Replace("bl", "<img src='imagens/b.gif' width=3 height=50>")
        cBarras = cBarras.Replace("pf", "<img src='imagens/p.gif' width=1 height=50>")
        cBarras = cBarras.Replace("pl", "<img src='imagens/p.gif' width=3 height=50>")






        '4�) parte ======================================
        'Daqui para baixo � s� atribuir os valores calculados aos controles na p�gina
        lblAgenciaConta.Text = cAgenciaNumero & "/" & cContaNumero & "-" & cDAC
        lblData.Text = Now.ToShortDateString()
        lblDataDoc.Text = Now.ToShortDateString()
        lblValorDocumento.Text = String.Format("{0:C}", nValor)
        lblVencimento.Text = dtVenc.ToShortDateString()
        lblNumDoc.Text = cNossoNumero
        lblNossoNumero.Text = cNossoNumero
        lblSacado.Text = "F�bio F RG: 123.456.789-X<br>Rua xyz, 123<br>Bras - SP - CEP 12345-123"
        lblIPTE.Text = cIPTE
        lblcodBar.Text = cBarras

</pre>
    <uc1:Rodape ID="Rodape1" runat="server" />
    </form>
</body>
</html>
