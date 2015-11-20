
Partial Class Consessionaria
    Inherits System.Web.UI.Page

    'Este c�digo fonte implementa apenas o c�digo de barras, utilizando as fun��es existentens na classe Funcoes em APP_CODE
    'Toda customiza��o � de respoons�bilidade do cliente.

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Composi��o do C�digo de Barras
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

        ' Exemplo baseado em uma conta de luz convencional

        Dim cCodBarras As String = ""

        cCodBarras += "8" 'Valor padr�o de arrecada��o
        cCodBarras += "3" 'Por exempo, conta de luz
        cCodBarras += "6" 'Valor padr�o que indica que a moeda � REAL (R$)
        'Posi��o referente ao Digito ser� calculado no final

        'Valor precisa perder o PONTO (.) um meio simples � multiplicar por 100
        Dim nValor As Double = 107.09 'Numero em dupla precis�o (float,double,decimal)
        'Valor multiplicado por 100 (original 107,09)
        'E insere-se 10 Zeros a frente do numero para totalizar os 11 digitos, pois
        'qualquer numero ter� no minimo 1 digito, assim se o numero contiver 5 digitos, como no exemplo
        'ficar� '10709' mais 10 digitos zeros a frente ficar�: 000000000010709, que totaliza 15 digitos
        '� nescess�rio excluir os digitos excessivos a esquerda, ou seja, 
        'vale apenas o conteudo dos 11 primeiros digitos a partir da DIREITA, por isso o uso da fun��o RIGHT()
        Dim cZeros As New String("0", 10) 'Gera um texto com 10 Zeros
        'Com isso as casa decimais somem, pos CINT, conterte para inteiro, for�ando qualquer arredondamento na terceira casa decimal
        nValor = CInt(nValor * 100)
        Dim cValor As String = Right(cZeros & nValor.ToString(), 11)
        cCodBarras += cValor


        'Dados livres de acordo com cada caso!

        'Baseando os dados na op��o 1:
        '              12345678 (8 posi�oes)
        cCodBarras += "00482919" 'cnpj / mf
        '              123456789012345678901 (21 posi��es)
        cCodBarras += "488099990952070600141" ' campo livre

        Dim cDig As String = Funcoes.Modulo10(cCodBarras)
        cCodBarras = cCodBarras.Substring(0, 3) & cDig & cCodBarras.Substring(3)

        'Quebra o codigo de barras em blocos de 11 digitos  - Valores Originais
        Dim cCampo1 As String = cCodBarras.Substring(0, 11)  '"83650000001"
        Dim cCampo2 As String = cCodBarras.Substring(11, 11) '"07090048291"
        Dim cCampo3 As String = cCodBarras.Substring(22, 11) '"94880999909"
        Dim cCampo4 As String = cCodBarras.Substring(33, 11) '"52070600141"

        'Calsula-se os digitos verificadores de cada bloco, e adiciona-o no final separado por tra�o("-")
        cCampo1 = cCampo1 & "-" & Funcoes.Modulo10(cCampo1)
        cCampo2 = cCampo2 & "-" & Funcoes.Modulo10(cCampo2)
        cCampo3 = cCampo3 & "-" & Funcoes.Modulo10(cCampo3)
        cCampo4 = cCampo4 & "-" & Funcoes.Modulo10(cCampo4)

        'Concatena-se o resultado dos blocos de cada campo, e tem-se a linha digitavel final
        Dim cDigitos As String = cCampo1 & " &nbsp;" & cCampo2 & " &nbsp;" & cCampo3 & " &nbsp;" & cCampo4
        lblDigitos.Text = cDigitos

        'Atraves da sequencia de digitos, � gerado a sequencia de barras (bf,bl,pl,pf) 
        'que segue a logica da legenda abaixo:
        ' bf -> Branco Fino
        ' bl -> Branco LArgo
        ' pf -> Preto Fino
        ' pl -> Preto Largo

        'E dado um numero, gera-se uma sequenca de caracteres no formato bfblblpfplbl...
        Dim cBarras As String = Funcoes.BarCode(cCodBarras)

        'substiue-se as duplas de caracteres que representam as barras por suas respectivas imagens
        cBarras = cBarras.Replace("bf", "<img src='imagens/b.gif' width=1 height=50>")
        cBarras = cBarras.Replace("bl", "<img src='imagens/b.gif' width=3 height=50>")
        cBarras = cBarras.Replace("pf", "<img src='imagens/p.gif' width=1 height=50>")
        cBarras = cBarras.Replace("pl", "<img src='imagens/p.gif' width=3 height=50>")

        'Estreve toda a string em tela
        lblCodBar.text = cBarras

        'Para futurar otimiza��es pode-se desligar a viewstate dos labels, para otimizar o tamanho final do html gerado

    End Sub

End Class
