Imports Impactro.Cobranca

Partial Class BoletoVB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Defini��o dos dados do cedente - QUEM RECEBE / EMITE
        Dim Cedente As New CedenteInfo
        Cedente.Cedente = "Teste do Cedente"
        Cedente.Banco = "409-0"
        Cedente.Agencia = "1234"
        Cedente.Conta = "123456-0"
        Cedente.Carteira = "Especial"
        Cedente.Modalidade = ""
        Cedente.Convenio = "1878794"   ' ATEN��O: Alguns Bancos usam um c�digo de convenio para remapear a conta do clientes
        Cedente.CodCedente = "1878794" ' outros bancos chama isto de Codigo do Cedente ou C�digo do Cliente

        ' Novas Exigencias da FREBABAN: Exibir endere�o e CNPJ no campo de emitente!
        Cedente.CNPJ = "12.345.678/0001-12"
        Cedente.Endereco = "Rua Sei l� aonde, 123 - Br�s, S�o Paulo/SP"

        ' outros usam os 2 campos para controles distintos!
        ' Veja com aten��o qual � o seu caso e qual destas vari�veis deve ser usadas!
        ' Olhe sempre os exemplos em ASP.Net se tiver d�vidas, pois l� h� um exemplo para cada banco
        Cedente.UsoBanco = "CVT 7744-5" 'Obrigat�rio para unibanco

        'Defini��o dos dados do sacado - QUEM PAGA
        Dim Sacado As New SacadoInfo
        'Sacado.SacadoCOD = "teste" 'c�digo opcional interno do sacado (pode ser um /ID numeroco ou um udentificado alfacumerico)
        Sacado.Sacado = "Fabio Ferreira (Teste para homologa��o)"
        Sacado.Documento = "123.456.789-12"
        Sacado.Endereco = "Rua xxx, 1001 ap 24"
        Sacado.Cidade = "S�o Paulo"
        Sacado.Bairro = "Centro"
        Sacado.Cep = "12345-000"
        Sacado.UF = "SP"

        Dim nCont As Integer = 0
        'If Session("Cont") Is Nothing Then
        '    Session("Cont") = 7566
        'Else
        '    nCont = Session("Cont")
        '    nCont += 1
        '    Session("Cont") = nCont
        'End If

        nCont = txtNossoNumero.Text

        'Defini��o dos dados do boleto
        Dim Boleto As New BoletoInfo
        Boleto.NossoNumero = nCont
        Boleto.NumeroDocumento = nCont
        Boleto.ValorDocumento = txtValor.Text
        Boleto.DataDocumento = Now
        'Boleto.DataVencimento = CDate(txtVencimento.Text) 'Campo obrigat�rio

        'Campos especiais para sistemas de pagamento online e emiss�o com
        'valores de multa e desocntos (acrescimos/abatimentos), quantidades, e valor cobrado
        'ATEN��O: Estes valores s�o apenas informativos em tela, o valor de fato que ser� cobrado
        'ser� o "ValorDocumento", mas na maioria dos casos estes campos abaixo n�o precisam ser configurados
        'pois s�o preenchidos manualmente pelo caixa na hora do pagamento
        Boleto.Quantidade = 3
        Boleto.ValorUnitario = 10
        Boleto.ValorCobrado = 20
        Boleto.ValorAcrescimo = 30
        Boleto.ValorDesconto = 40
        Boleto.ValorMora = 50
        Boleto.ValorOutras = 60

        'Obrigat�rio para o UNIBANCO
        Boleto.LocalPagamento = "At� o vencimento, pag�vel em qualquer banco. Ap�s o vencimento, em qualquer ag�ncia do Unibanco"
        Boleto.Aceite = "N"
        Boleto.Instrucoes = "Todas as informa��es deste bloqueto s�o de exclusiva responsabilidade do cedente"
        Boleto.Demonstrativo = "Exemplo da desci��o dos servi�os..."

        'monta o boleto com os dados espec�ficos nas classes
        bltPag.MakeBoleto(Cedente, Sacado, Boleto)

        '� posivel imprimir (exibir) em tela um valor diferente do que est� no calculo do c�digo de barras
        'para isso primeiro efetue a configura��o normalmente do valor, e depois reconfigure como no exemplo abaixo
        bltPag.Boleto.ValorDocumento = Boleto.ValorDocumento * 10

    End Sub

End Class
