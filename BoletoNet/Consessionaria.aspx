<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Consessionaria.aspx.vb" Inherits="Consessionaria" %>
<%@ Register src="Rodape.ascx" tagname="Rodape" tagprefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>BoletoASP.Net: T�tulo de Concessiona/Arrecada��o, C�digo de Barras</title>
    <meta name="Description" content="Prefeituras, �rg�os Governamentais (Saneamento, Energia El�trica e G�s), Telecomunica��es, Multas de tr�nsito, podem emitir t�tulos de arrecada��o (Boleto Concession�ria) com um c�digo de barras espec�fico" />
    <meta name="keywords" content="BoletoASP.Net, Boleto ASP, Boleto, ASP.Net, Concession�ria, arrecada��o, Identifica��o do Segmento, Prefeituras, Saneamento, Energia El�trica, G�s, Telecomunica��es, �rg�os Governamentais, Carnes, Multas de tr�nsito, Empresa/�rg�o, Identifica��o do Segmento"/>
    <style type="text/css">
        body
        {
        	font-family: Verdana;
        	font-size: 10pt;
        }
    </style></head>
<body>
    <form id="form1" runat="server">
    <table width=640 height=200 bgcolor="#ffffcc"><tr><td align=center>Conte�do Customizado<br><br>Monte aqui seu conteudo customizado</td></tr></table>
    <font ></font>
        <asp:Label ID="lblDigitos" runat="server" Font-Names="Courier New" Font-Size="9pt"></asp:Label><br />
        <asp:Label ID="lblCodBar" runat="server"></asp:Label>
        <br />
        <br />
        <pre>'Composi��o do C�digo de Barras
        'POSI��O    -  TAM  - CONTE�DO
        '01 � 01    -   1   - Identifica��o do Produto
        '                       Constante "8" para identificar arrecada��o
        '02 � 02	-   1   - Identifica��o do Segmento 
        '                       1. Prefeituras
        '                       2. Saneamento
        '                       3. Energia El�trica e G�s
        '                       4. Telecomunica��es
        ' 	                    5. �rg�os Governamentais
        '                       6. Carnes e Assemelhados ou demais Empresas / �rg�os que ser�o identificadas atrav�s do CNPJ.
        '                       7. Multas de tr�nsito
        '                       9. Uso interno do banco
        '03 � 03	-   1   - Identifica��o do valor real ou refer�ncia
        '                       Geralmente "6" valor a ser cobrado efetivamente em reais.
        '04 � 04	-   1   - D�gito verificador geral (m�dulo 10 )
        '05 � 15    -   11  - Valor
        '== op��o 1 ==
        '16 � 19	-   4   - Identifica��o da Empresa/�rg�o
        '20 � 44	-   25  - Campo livre de utiliza��o da Empresa/�rg�o
        '== op��o 2 ==
        '16 � 23    -   8   - CNPJ / MF
        '24 � 44    -   21  - Campo livre de utiliza��o da Empresa/�rg�o
        </pre>
        <uc1:Rodape ID="Rodape1" runat="server" />
        </form>
        </body>
</html>
