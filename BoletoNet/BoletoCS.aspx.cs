using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Impactro.Cobranca;
using Impactro.WebControls;

public partial class BoletoCS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Defini��o dos dados do cedente - QUEM RECEBE / EMITE
        CedenteInfo Cedente = new CedenteInfo();
        Cedente.Cedente = "Exemplo de empresa cedente";
        Cedente.Banco = "237-";
        Cedente.Agencia = "1234";       // use somente "-" para separa o c�digo da agencia e digito
        Cedente.Conta = "56789-1";      // use somente "-" para separa o c�digo da conta e digito
        Cedente.Carteira = "6";
        Cedente.Modalidade = "";        // Em geral faz parte do nosso numero
        Cedente.Convenio = "1878794";   // ATEN��O: Alguns Bancos usam um c�digo de convenio para remapear a conta do clientes
        Cedente.CodCedente = "1878794"; // outros bancos chama isto de Codigo do Cedente ou C�digo do Cliente

        // Novas Exigencias da FREBABAN: Exibir endere�o e CNPJ no campo de emitente!
        //Cedente.ExibirCedenteDocumento = true; // N�o � mais necess�rio pois agora � obrigat�rio para homologar
        Cedente.CNPJ = "12.345.678/0001-12";
        //Cedente.ExibirCedenteEndereco = true; // N�o � mais necess�rio pois agora � obrigat�rio para homologar
        Cedente.Endereco = "Rua Sei l� aonde, 123 - Br�s, S�o Paulo/SP";

        // outros usam os 2 campos para controles distintos!
        // Veja com aten��o qual � o seu caso e qual destas vari�veis deve ser usadas!
        // Olhe sempre os exemplos em ASP.Net se tiver d�vidas, pois l� h� um exemplo para cada banco

        // Para casos especiais
        Cedente.UsoBanco = "123";
        Cedente.CIP = "456";
        Cedente.UsoBanco = "CVT 7744-5";

        // Defini��o dos dados do sacado -  QUEM PAGA
        SacadoInfo Sacado = new SacadoInfo();
        Sacado.SacadoCodigo = "123"; // C�digo interno de controle
        Sacado.Sacado = "Fabio Ferreira (Teste para homologa��o)";
        Sacado.Documento = "123.456.789-99";
        Sacado.Endereco = "Av. Paulista, 1234";
        Sacado.Cidade = "S�o Paulo";
        Sacado.Bairro = "Centro";
        Sacado.Cep = "12345-123";
        Sacado.UF = "SP";
        Sacado.Avalista = "Banco XPTO - CNPJ: 123.456.789/00001-23";

        // Defini��o dos dados do boleto
        BoletoInfo Boleto = new BoletoInfo();
        Boleto.NossoNumero = "123400";
        Boleto.NumeroDocumento = "123400";
        Boleto.ValorDocumento = 423.45;
        Boleto.DataDocumento = DateTime.Now;
        Boleto.DataVencimento = new DateTime(2006, 5, 31);
        Boleto.ParcelaNumero = 2;
        Boleto.ParcelaTotal = 10;

        // Obrigat�rio para o UNIBANCO
        Boleto.LocalPagamento = "Pag�vel em qualquer ag�ncia banc�ria";
        Boleto.Especie = Especies.RC;
        Boleto.DataDocumento = DateTime.Now.AddDays(-2);     // Por padr�o � a data atual, geralmente � a data em que foi feita a compra/pedido, antes de ser gerado o boleto para pagamento
        Boleto.DataProcessamento = DateTime.Now.AddDays(-1); // Por padr�o � a data atual, pode ser usado como a data em que foi impresso o boleto
        
        Boleto.Instrucoes = "Todas as as informa��es deste bloqueto s�o de exclusiva responsabilidade do cedente";

        // � possivel alterar alguns textos padr�es conforme abaixo
        // conforme circulares BACEN 3.598 e 3.656 em vigor a partir de 28/06/2013 titulo fora mudados de cedente para benefici�rio, e sacado para pagador
        // BoletoTextos.Cedente= "Cedente"; 
        //BoletoTextos.Sacado = "Sacador";

        // � possive exibir a linha digit�vel tamb�m no recibo do sacado
        //bltPag.ExibeReciboIPTE = true;

        // � possivel ocultar totalmente o recibo do sacado e customizar o layout deste
        //bltPag.ExibeReciboSacado = false;

        // personalize com o logo de sua empresa, e o caminho base das imagens
        bltPag.ImagePath = "imagens/";
        bltPag.ImageLogo = "Impactro-Logo.gif";
        bltPag.ImageType = BoletoImageType.gif; // Define que as imagens vir�o de arquivos esternos 

        //  // op��es especiais: use com cuidado
        //  bltPag.Boleto.Especie = "?USD?";    // � possivel fazer cobran�as em outras moedas
        //  bltPag.Boleto.Moeda = "3";          // mas deve ser analisado o c�digo da moeda
        //  bltPag.ImageType = BoletoImageType.gif; // voc� pode customizar as imagens dos bancos
        //  bltPag.ImagePath = "imagens/";          // desde que informe um diret�rio onde as imagens estar�o

        // monta o boleto com os dados espec�ficos nas classes
        bltPag.MakeBoleto(Cedente, Sacado, Boleto);
    }
}