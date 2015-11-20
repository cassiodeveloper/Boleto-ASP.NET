Imports Impactro.Cobranca

Partial Class ExemploBanespa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Dados do Exemplo 1 da documenta��o: BANESPA-CODIGO_DE_BARRAS.doc
        ' C�digo de cedente : 400 13 01216 8 (exemplo 1) / 14813026478 (exemplo 2)
        ' Nosso n�mero      : 7469108 (exemplo 1) / 0004952 (exemplo 2)
        ' Data de Vencimento: 04/07/2000
        ' Valor             : 1.150,00

        'Exemplo re-adaptado ao exemplo de uso SANTANDER p�gna 8 vers�o 1.7

        'Defini��o dos dados do cedente
        Dim Cedente As New CedenteInfo
        Cedente.Cedente = "IMPACTRO Inform�tica (teste)"
        Cedente.Banco = "033"
        Cedente.Agencia = "4781-3"
        Cedente.Conta = "130017549"
        Cedente.CodCedente = "6348920"
        Cedente.Carteira = "101"
        '== ATEN��O ==
        'Informa para usar o nova logica do Santander/Banespa: CUIDADO!
        Cedente.useSantander = True ' // (PADR�O � FALSE)

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
        Boleto.NossoNumero = "2269" '"300010"
        Boleto.NumeroDocumento = Boleto.NossoNumero
        Boleto.ValorDocumento = 42.54
        Boleto.DataDocumento = Now
        Boleto.DataVencimento = CDate("02/01/2014 ") '2046 (ver FuncTeste_FatVenc.aspx) 'CDate("30/09/2009")
        Boleto.Instrucoes = "Todas as informa��es deste bloqueto s�o de exclusiva responsabilidade do cedente"

        'Monta o boleto com os dados espec�ficos nas classes
        bltPag.MakeBoleto(Cedente, Sacado, Boleto)

        If Cedente.useSantander Then
            'Veja o arquivo: ExemploSantander.aspx
            Me.lbl.Text = bltPag.Boleto.CodigoBarrasFormatado(New Integer() {1, 7, 12, 1, 1, 3})
        Else
            'Detalhes do campo livre: 
            'Codigo do Cedente      (11 digito)
            'Nosso Numeroo          (07 digito)
            'valor '00' fixo        (02 digito)
            'valor '033' fixo       (03 digito)
            'Digito DV1             (01 digito)
            'Digito DV2             (01 digito)
            '====================== TOTAL: 25 digitos no campo livre
            Me.lbl.Text = bltPag.Boleto.CodigoBarrasFormatado(New Integer() {11, 7, 2, 3, 1, 1})
        End If

    End Sub

End Class
