Imports Impactro.Cobranca

Partial Class ExemploUnibanco
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Defini��o dos dados do cedente
        Dim Cedente As New CedenteInfo
        Cedente.Cedente = "IMPACTRO Inform�tica (teste)"
        Cedente.Banco = "409"
        Cedente.Agencia = "0352-2"
        Cedente.Conta = "123789-0"
        Cedente.Carteira = "COB"
        Cedente.CodCedente = "1111111"
        Cedente.Modalidade = "14" '14 digitos de nosso numero
        'Qualquer outro valor na modalidade, ou n�o especificada, implica em nosso numerocom 7 digitos, e prefixo com o codCedente

        'Defini��o dos dados do sacado
        Dim Sacado As New SacadoInfo
        Sacado.Sacado = "Fabio Ferreira (Teste)"
        Sacado.Documento = "123.456.789-99"
        Sacado.Endereco = "Av. Paulista, 1234"
        Sacado.Cidade = "S�o Paulo"
        Sacado.Bairro = "Centro"
        Sacado.Cep = "12345-123"
        Sacado.UF = "SP"

        'Defini��o das Vari�veis do boleto
        Dim Boleto As New BoletoInfo

        Boleto.ValorDocumento = 2335.67
        Boleto.DataVencimento = CDate("12/07/2008")
        Boleto.NumeroDocumento = "6119648609"
        Boleto.NossoNumero = "61196486094"
        Boleto.DataDocumento = Now
        Boleto.Instrucoes = "Todas as informa��es deste bloqueto s�o de exclusiva responsabilidade do cedente"

        'Monta o boleto com os dados espec�ficos nas classes
        AddHandler bltPag.MontaCampoLivre, AddressOf UnibancoRegistrado
        bltPag.MakeBoleto(Cedente, Sacado, Boleto)

        'S� pode-se ler a linha digitavel ou o codigo de barras apois executar o 'CalculaBoleto()' ou  'MakeBoleto'
        Me.lblCodBar.Text = bltPag.Boleto.CodigoBarras
        Me.lblLinhaDigitavel.Text = bltPag.Boleto.LinhaDigitavel

    End Sub

    Function UnibancoRegistrado(ByVal blt As Boleto) As String
        'Posi��o	Tamanho	Descri��o
        '1 a 3	3	N�mero de identifica��o do Unibanco: 409 (n�mero FIXO)
        '4	1	C�digo da moeda. Real (R$)=9 (n�mero FIXO)
        '5	1	d�gito verificador do C�DIGO DE BARRAS
        'Calculado pelo m�dulo 11 (p�gina 11), onde dever� ser utilizado as 43 d�gitos desta seq��ncia num�rica que dar� origem ao C�DIGO DE BARRAS
        '6 a 9	4	fator de vencimento em 4 algarismos, conforme tabela da p�gina 14 
        '10 a 19	10	valor do t�tulo com zeros � esquerda
        '--- CAMPO LIVRE ---
        '20 a 21	2	C�digo para transa��o CVT =  04 (n�mero FIXO) '(04=5539-5)
        '22 a 27	6	data de vencimento (AAMMDD)
        '28 a 32	5	C�digo da ag�ncia + d�gito verificador
        '33 a 43	11	�Nosso N�mero� (NNNNNNNNNND) onde D � o d�gito a ser calculado pelo M�dulo 11 (p�gina 11)
        '44	1	Super d�gito do �Nosso N�mero� onde S � o Super D�gito calculado pelo m�dulo 11 (p�gina 11) � utilizando os algarismos do �Nosso N�mero� acrescido do n�mero 1 � esquerda = 1NNNNNNNNNNDS

        Dim cLivre As String
        Dim cAgenciaDIG As String = CobUtil.Right(blt.Agencia.Replace("-", ""), 5)
        Dim cNossoNumero As String = CobUtil.Right(blt.NossoNumero, 10)
        Dim cDAC As String = CobUtil.Modulo11Especial(cNossoNumero, 9)

        blt.NossoNumeroExibicao = cNossoNumero & "-" & cDAC

        cNossoNumero &= cDAC

        Dim cSuper As String = CobUtil.Modulo11Especial("1" & cNossoNumero, 9)

        cLivre = "04" & _
            String.Format("{0:yyMMdd}", blt.DataVencimento) & _
            cAgenciaDIG & _
            cNossoNumero & _
            cSuper

        Return cLivre

    End Function

End Class
