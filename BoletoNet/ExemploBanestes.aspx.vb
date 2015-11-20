Imports Impactro.Cobranca

Partial Class ExemploBanestes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Dados montado por engenharia reversa dada uma linha digit�vel de exemplo da documenta��o:
        ' Banestes-Cobranca.doc
        ' Linha digit�vel de um t�tulo de R$ 75,00, vencido em 30/07/2000:
        ' 02190.00007 17800.006573 33154.021415 3 10270000007500
        ' Valor: 75,00
        ' Data de Vencimento: 30/07/2000
        ' Nosso Numero: 178
        ' Conta: 6573315
        ' Modalidade: 4 - Cobran�a com registro

        ' OBS: O exemplo na documenta��o traz apenas dados literais
        ' Realizando a logica inversa o campo livre foi encontrado,
        ' mas o digito verificado geral do IPTE resultou um valor diferente
        ' Esta rotina � padr�o febraban e funciona perfeitamente em todos os outros bancos.

        'Defini��o dos dados do cedente
        Dim Cedente As New CedenteInfo
        Cedente.Cedente = "IMPACTRO Inform�tica (teste)"
        Cedente.Banco = "21"
        Cedente.Agencia = "1234-5"
        Cedente.Conta = "123456-7"
        Cedente.CodCedente = "6573315"
        Cedente.Modalidade = "4"

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
        Boleto.NossoNumero = "178"
        Boleto.NumeroDocumento = "178"
        Boleto.ValorDocumento = 75
        Boleto.DataDocumento = Now
        Boleto.DataVencimento = CDate("30/07/2000")
        Boleto.Instrucoes = "Todas as informa��es deste bloqueto s�o de exclusiva responsabilidade do cedente"

        'monta o boleto com os dados espec�ficos nas classes
        bltPag.MakeBoleto(Cedente, Sacado, Boleto)

    End Sub
End Class
