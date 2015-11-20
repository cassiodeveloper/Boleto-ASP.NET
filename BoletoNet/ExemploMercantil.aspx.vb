Imports Impactro.Cobranca

Partial Class ExemploMercantil
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Defini��o dos dados do cedente
        Dim Cedente As New CedenteInfo
        Cedente.Cedente = "IMPACTRO Inform�tica (teste)"
        Cedente.Banco = "389"
        Cedente.Agencia = "1234-5"
        Cedente.Conta = "123456-7"
        Cedente.CodCedente = "999888777" 'Contrato
        Cedente.Modalidade = "2" 'Sem desconto

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
        Boleto.NossoNumero = "112233"
        Boleto.NumeroDocumento = "112233"
        Boleto.ValorDocumento = 75
        Boleto.DataDocumento = Now
        Boleto.DataVencimento = CDate("30/07/2000")
        Boleto.Instrucoes = "Todas as informa��es deste bloqueto s�o de exclusiva responsabilidade do cedente"

        'monta o boleto com os dados espec�ficos nas classes
        bltPag.MakeBoleto(Cedente, Sacado, Boleto)

    End Sub
End Class
