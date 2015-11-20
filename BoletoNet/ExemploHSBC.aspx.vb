Imports Impactro.Cobranca

Partial Class ExemploHSBC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'De acordo com o exemplo da documenta��o: HSBC-Cobran�a-CNR.pdf, pagina 13
        '6.5.1 � Exemplo de C�lculo do D�gito de Autoconfer�ncia (DAC)
        'Tomando como base para o exemplo os dados do subitem 5.3:
        'C�digo do HSBC na C�mara de Compensa��o ....................... 399
        'Tipo de Moeda (Real) ............................................ 9
        'Fator de Vencimento (Data de Vencimento 04/07/2008) .......... 3923
        'Valor do Documento (R$ 1.200,00) ....................... 0000120000
        'C�digo do Cedente ......................................... 8351202
        'C�digo do Documento (sem os 3 d�gitos calculados) ... 0000239104761
        'Data de Vencimento no Formato Juliano ........................ 1868
        'C�digo do Produto CNR ........................................... 2

        'Defini��o dos dados do cedente
        Dim Cedente As New CedenteInfo
        Cedente.Cedente = "IMPACTRO Inform�tica (teste)"
        Cedente.Banco = "399"
        Cedente.Agencia = "1566"
        Cedente.Conta = "111111"
        Cedente.CodCedente = "4076729" '"09110011663"
        Cedente.Carteira = "01" 'Carteira CNR: Sem Registro
        Cedente.Modalidade = "4" 'Vincula: �vencimento�, �c�digo do cedente� e �c�digo do documento�
        'Cedente.Modalidade = "5" 'Vincula: �c�digo do cedente� e �c�digo do documento�

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

        Boleto.ValorDocumento = 923.81
        Boleto.DataVencimento = CDate("25/07/2010")
        Boleto.NossoNumero = "50311"
        Boleto.NumeroDocumento = Boleto.NossoNumero
        Boleto.DataDocumento = Now
        Boleto.Instrucoes = "Todas as informa��es deste bloqueto s�o de exclusiva responsabilidade do cedente"

        'Monta o boleto com os dados espec�ficos nas classes
        'AddHandler bltPag.MontaCampoLivre, AddressOf HSBCRegistrado
        bltPag.MakeBoleto(Cedente, Sacado, Boleto)

        'S� pode-se ler a linha digitavel ou o codigo de barras apois executar o 'CalculaBoleto()' ou  'MakeBoleto'
        Me.lblCodBar.Text = bltPag.Boleto.CodigoBarrasFormatado(New Integer() {7, 13, 4, 1})
        Me.lblLinhaDigitavel.Text = bltPag.Boleto.LinhaDigitavel

    End Sub

    Function HSBCRegistrado(ByVal blt As Boleto) As String

        'Posi��o de Posi��o at� Tamanho Conte�do

        '03 C�digo do HSBC na compensa��o. Igual a �399�
        '01 Tipo de Moeda. Real igual a �9� � Moeda vari�vel igual a �0�
        '01 D�gito de autoconfer�ncia do c�digo de barras (DAC). Ver orienta��o de c�lculo a seguir.
        '04 Fator de vencimento (obrigat�rio a partir de 03/07/2000)

        '10 Valor do documento / t�tulo. Para t�tulo em moeda vari�vel, ou t�tulo com valor zerado ou n�o definido, gravar �zeros�.
        '11 N�mero Banc�rio ( Nosso N�mero ).

        '11 C�digo do Cedente composto por:
        '	- 4 posi��es ( 31 a 34 ) = C�digo da Ag�ncia.
        '	- 7 posi��es ( 35 a 41 ) = Conta de cobran�a.

        '01 C�digo da carteira = �00�
        '01 C�digo do aplicativo Cobran�a (COB) = �1�

        Dim cLivre As String
        Dim cNossoNumero As String = CobUtil.Right(blt.NossoNumero, 11)
        Dim cAgencia As String = CobUtil.Right(blt.Agencia, 4)
        Dim cConta As String = CobUtil.Right(blt.Conta.Replace("-", ""), 7)

        blt.NossoNumeroExibicao = cNossoNumero

        Dim cSuper As String = CobUtil.Modulo11Especial("1" & cNossoNumero, 9)

        cLivre = cNossoNumero & cAgencia & cConta & "001"

        Return cLivre

    End Function

End Class
