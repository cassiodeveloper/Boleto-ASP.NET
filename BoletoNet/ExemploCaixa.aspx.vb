Imports Impactro.Cobranca

Partial Class ExemploCaixa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Dados do Exemplo da documenta��o: Caixa-ESPCODBARCOBSEMREG_16POSICOES_NN.pdf
        ' 104 Banco
        ' 9 Moeda
        ' 15/09/2000 Vencimento
        ' 1074 Fator de Vencimento
        ' 160,00 Valor
        ' 00011 C�digo do Cliente
        ' 0012 CNPJ do PV da conta do cliente
        ' 8 C�digo da Carteira
        ' 7 Constante
        ' 01000901200200 Nosso N�mero (14 posi��es)

        'Defini��o dos dados do cedente
        Dim Cedente As New CedenteInfo
        Cedente.Cedente = "IMPACTRO Inform�tica (teste)"
        Cedente.CNPJ = "12123123000101"
        Cedente.Banco = "104"
        Cedente.Agencia = "123-4"
        Cedente.Conta = "5678-9"
        Cedente.Carteira = "2"          ' C�digo da Carteira
        Cedente.Convenio = "02"         ' CNPJ do PV da conta do cliente
        Cedente.CodCedente = "455932"   ' C�digo do Cliente(cedente)
        'Cedente.ExibirCedenteDocumento = True ''N�o � mais necess�rio pois agora � obrigat�rio para homologar

        'Codigo de cedente especial, com 15 Digitos (obrigat�rio Zeros a Frente)
        'Cedente.CodCedente = "059100300000608"

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
        Boleto.NossoNumero = "910000000000065"
        Boleto.NumeroDocumento = Boleto.NossoNumero
        Boleto.ValorDocumento = 50
        Boleto.DataDocumento = Now
        Boleto.DataVencimento = CDate("05/04/2009")
        Boleto.Instrucoes = "Todas as informa��es deste bloqueto s�o de exclusiva responsabilidade do cedente"

        'monta o boleto com os dados espec�ficos nas classes
        bltPag.ExibeReciboLinhaDigitavel = True
        bltPag.MakeBoleto(Cedente, Sacado, Boleto)

    End Sub


End Class
