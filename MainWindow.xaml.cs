using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Parametrizador_PROCFIT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SqlDataReader Dr { get; set; } ///PARAMETRO PARA LEITURA DE DATAREADER GLOBAL

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (Validation.Check())
            {

                foreach (string impressora in PrinterSettings.InstalledPrinters)
                {
                    tImpressora.Items.Add(impressora);
                }
                var configImpressora = new PrinterSettings();
                tImpressora.SelectedItem = configImpressora.PrinterName;

                Dados.Armazenar(
                    "--",
                    "--",
                    "--",
                    "--",
                    false
                    );
            } 
            else
            {
                App.Current.MainWindow.Close();
            }
        }

        private bool Salvar()
        {
            string query = "UPDATE PARAMETROS SET " +
                "LOJA = @loja " +
                ",DB_SERVIDOR = @ipServidor " +
                ",CAIXA = @caixa " +
                ",RAZAO_SOCIAL = @razaoSocial " +
                ",ENDERECO = @logradouro " +
                ",NUMERO = @numero " +
                ",COMPLEMENTO = @complemento " +
                ",BAIRRO = @bairro " +
                ",CIDADE = @cidade " +
                ",CEP = @cep " +
                ",INSCRICAO_FEDERAL = @inscFederal " +
                ",INSCRICAO_ESTADUAL = @inscEstadual " +
                ",DEBUG = @debug " +
                ",TELEFONE = @telefone " +
                ",ESTADO = @uf " +
                ",LOJA_SITEF = @lojaSitef " +
                ",TERMINAL_SITEF = @terminalSitef " +
                ", EMPRESA = @empresa " +
                ", VIDALINK_ATIVADO = @vidalink " +
                ",VIDALINK_ENVIO = @vidalinkEnvio " +
                ",VIDALINK_RESPOSTA = @vidalinkResp " +
                ",EPHARMA_ATIVADO = @epharmaAtivo " +
                ",EPHARMA_ENVIO = @epharmaEnvio " +
                ",EPHARMA_RESPOSTA = @epharmaResp " +
                ",LIMITE_SANGRIA_DINHEIRO = @limiteSangria " +
                ",TAXA_ENTREGA = @taxaEntrega " +
                ",VERSAO = @versao " +
                ",FCARD_ENVIO = @funcionalEnvio " +
                ",FCARD_RESPOSTA = @funcionalResp " +
                ",CENTRAL_DICIONARIO = @dicionario " +
                ",PERMITIR_CONTROLADO_VENDA_DIRETA = @vendaControlado " +
                ",PERMITIR_CONSULTA_DESCRICAO = @consultaDescricao " +
                ",HABILITAR_CONSULTA_PRODUTOS = @consultaProdutos " +
                ",SAT_IMPRESSORA = @Impressora " +
                ",SAT_CODIGO_ATIVACAO = @ativacao " +
                ",SAT_ASSINATURA = @assinatura " +
                ",SAT_DLL = @dll " +
                ",TRAVAR_PREVENDA_SEM_ROMANEIO = @travaPrevendaSemRomaneio " +
                ",SENHA_BIOMETRIA = @biometria " +
                ",DIAS_FECHAMENTO_SEM_ROMANEIO = @diasFechamentoSemRomaneio " +
                ",DIAS_REAGENDAMENTO_ROMANEIO = @diasReagendamentoRomaneio " +
                ",ADICIONAR_CLIENTE_LIVREMENTE = @adicionarClienteLivremente " +
                ",VIAS_SANGRIAS_SUPRIMENTOS = @viasSangrias " +
                ",SAT_IP = @ipSat " +
                ",SAT_PORTA = @porta " +
                ",SAT_DIRETO = @comunicacaoSat " +
                ",QUANTIDADE_ROMANEIOS_PENDENTES_OPERADOR = @qtdRomaneiosPendentes " +
                ",LIMITE_SUPRIMENTO = @suprimento " +
                ",SOLICITAR_SENHA_REEIMPRESAO_TEF = @senhaReimpressao " +
                ",CONSULTA_ROMANEIO_FILTRO = @consultaRomeneio";

            using (SqlCommand cmd = new SqlCommand(query, Conect.Conectar(Dados.DadosList[0].Servidor, Dados.DadosList[0].Banco, Dados.DadosList[0].Senha)))
            {
                char debug;
                if (checkDebug.IsChecked == true) { debug = 'S'; } else { debug = 'N'; }

                char vidalink;
                if (checkVidalink.IsChecked == true) { vidalink = 'S'; } else { vidalink = 'N'; }

                char epharma;
                if (checkEpharma.IsChecked == true) { epharma = 'S'; } else { epharma = 'N'; }

                char funcional;
                if (checkFuncional.IsChecked == true) { funcional = 'S'; } else { funcional = 'N'; }

                char vendaControlado;
                if (checkHabilitarControlado.IsChecked == true) { vendaControlado = 'S'; } else { vendaControlado = 'N'; }

                char consultDescricao;
                if (checkHabilitarConsultaDescricao.IsChecked == true) { consultDescricao = 'S'; } else { consultDescricao = 'N'; }

                char consultProdutos;
                if (checkHabilitarConsultaProduto.IsChecked == true) { consultProdutos = 'S'; } else { consultProdutos = 'N'; }

                char travaPrevenda;
                if (checkTravaPrevendaSemRomaneio.IsChecked == true) { travaPrevenda = 'S'; } else { travaPrevenda = 'N'; }

                char biometria;
                if (checkHabilitarBiometria.IsChecked == true) { biometria = 'S'; } else { biometria = 'N'; }

                char addCliente;
                if (checkAddClienteLivremente.IsChecked == true) { addCliente = 'S'; } else { addCliente = 'N'; }

                char comunicSat;
                if (checkComunicacaoSat.IsChecked == true) { comunicSat = 'S'; } else { comunicSat = 'N'; }

                char senhaReimpressao;
                if (checkSolicitarSenhaReimpressaoTef.IsChecked == true) { senhaReimpressao = 'S'; } else { senhaReimpressao = 'N'; }


                cmd.Parameters.AddWithValue("@loja", tLoja.Text);
                cmd.Parameters.AddWithValue("@ipServidor", tIpServidor.Text + @"\SQLEXPRESS");
                cmd.Parameters.AddWithValue("@caixa", tCaixa.Text);
                cmd.Parameters.AddWithValue("@razaoSocial", tRazSocial.Text);
                cmd.Parameters.AddWithValue("@logradouro", tLogradouro.Text);
                cmd.Parameters.AddWithValue("@numero", tNumero.Text);
                cmd.Parameters.AddWithValue("@complemento", tComplemento.Text);
                cmd.Parameters.AddWithValue("@bairro", tBairro.Text);
                cmd.Parameters.AddWithValue("@cidade", tBairro.Text);
                cmd.Parameters.AddWithValue("@cep", tCep.Text);
                cmd.Parameters.AddWithValue("@inscFederal", tInscFederal.Text);
                cmd.Parameters.AddWithValue("@inscEstadual", tInscEstadual.Text);
                cmd.Parameters.AddWithValue("@debug", debug);
                cmd.Parameters.AddWithValue("@telefone", tTelefone.Text);
                cmd.Parameters.AddWithValue("@uf", tUf.Text);
                cmd.Parameters.AddWithValue("@lojaSitef", tLojaSitef.Text);
                cmd.Parameters.AddWithValue("@terminalSitef", tTerminalSitef.Text);
                cmd.Parameters.AddWithValue("@empresa", tEmpresa.Text);
                cmd.Parameters.AddWithValue("@vidalink", vidalink);
                cmd.Parameters.AddWithValue("@vidalinkEnvio", @"\\" + tIpVidalinkEnvio.Text + @"\pdv01\ENVIO\");
                cmd.Parameters.AddWithValue("@vidalinkResp", @"\\" + tIpVidalinkResp.Text + @"\pdv01\RESPOSTA\");
                cmd.Parameters.AddWithValue("@epharmaAtivo", epharma);
                cmd.Parameters.AddWithValue("@epharmaEnvio", @"\\" + tIpEpharmaEnvio.Text + @"\E-pharma\ENV\");
                cmd.Parameters.AddWithValue("@epharmaResp", @"\\" + tIpEpharmaResp.Text + @"\E-pharma\REC\");
                //cmd.Parameters.AddWithValue("@funcional", funcional);
                cmd.Parameters.AddWithValue("@funcionalEnvio", @"\\" + tIpFuncionalEnvio.Text + @"\Funcional\ENV\");
                cmd.Parameters.AddWithValue("@funcionalResp", @"\\" + tIpFuncionalResp.Text + @"\Funcional\REC\");
                cmd.Parameters.AddWithValue("@limiteSangria", tSangria.Text);
                cmd.Parameters.AddWithValue("@taxaEntrega", tEntrega.Text);
                cmd.Parameters.AddWithValue("@versao", tVersao.Text);
                cmd.Parameters.AddWithValue("@dicionario", tDicionario.Text);
                cmd.Parameters.AddWithValue("@vendaControlado", vendaControlado);
                cmd.Parameters.AddWithValue("@consultaDescricao", consultDescricao);
                cmd.Parameters.AddWithValue("@consultaProdutos", consultProdutos);
                cmd.Parameters.AddWithValue("@impressora", tImpressora.SelectedItem);
                cmd.Parameters.AddWithValue("@ativacao", tAtivacaoSat.Text);
                cmd.Parameters.AddWithValue("@assinatura", tAssinatura.Text.ToString());
                cmd.Parameters.AddWithValue("@dll", tDll.Text);
                cmd.Parameters.AddWithValue("@travaPrevendaSemRomaneio", travaPrevenda);
                cmd.Parameters.AddWithValue("@biometria", biometria);
                cmd.Parameters.AddWithValue("@diasFechamentoSemRomaneio", tDiasFechamentoSemRomaneio.Text);
                cmd.Parameters.AddWithValue("@diasReagendamentoRomaneio", tDiasReagendamentoSemRomaneio.Text);
                cmd.Parameters.AddWithValue("@adicionarClienteLivremente", addCliente);
                cmd.Parameters.AddWithValue("@viasSangrias", tQtdViasSangrias.Text);
                cmd.Parameters.AddWithValue("@ipSat", tIpSat.Text);
                cmd.Parameters.AddWithValue("@porta", tPorta.Text);
                cmd.Parameters.AddWithValue("@comunicacaoSat", comunicSat);
                cmd.Parameters.AddWithValue("@qtdRomaneiosPendentes", tQtdRomaneiosPendentes.Text);
                cmd.Parameters.AddWithValue("@suprimento", tLimitesSuprimentos.Text);
                cmd.Parameters.AddWithValue("@senhaReimpressao", senhaReimpressao);
                cmd.Parameters.AddWithValue("@consultaRomeneio", tFiltroConsultaRomaneio.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }

            }

            
        }

        private bool ConectarBanco()
        {
            string query = "SELECT " +
                       " LOJA " +
                       " ,CAIXA " +
                       " ,DEBUG " +
                       " ,DB_SERVIDOR " +
                       " ,RAZAO_SOCIAL " +
                       " ,ENDERECO " +
                       " ,NUMERO " +
                       " ,COMPLEMENTO " +
                       " ,BAIRRO " +
                       " ,CIDADE " +
                       " ,CEP " +
                       " ,TELEFONE " +
                       " ,INSCRICAO_FEDERAL " +
                       " ,INSCRICAO_ESTADUAL " +
                       " ,ESTADO " +
                       " ,LOJA_SITEF " +
                       " ,TERMINAL_SITEF " +
                       " ,EMPRESA " +
                       " ,VIDALINK_ATIVADO" +
                       " ,VIDALINK_ENVIO " +
                       " ,VIDALINK_RESPOSTA " +
                       " ,EPHARMA_ATIVADO " +
                       " ,EPHARMA_ENVIO " +
                       " ,EPHARMA_RESPOSTA " +
                       " ,LIMITE_SANGRIA_DINHEIRO " +
                       " ,TAXA_ENTREGA " +
                       " ,VERSAO " +
                       " ,FCARD_ENVIO " +
                       " ,FCARD_RESPOSTA " +
                       " ,CENTRAL_DICIONARIO " +
                       " ,PERMITIR_CONTROLADO_VENDA_DIRETA " +
                       " ,PERMITIR_CONSULTA_DESCRICAO " +
                       " ,HABILITAR_CONSULTA_PRODUTOS " +
                       " ,SAT_IMPRESSORA " +
                       " ,SAT_CODIGO_ATIVACAO " +
                       " ,SAT_ASSINATURA " +
                       " ,SAT_DLL " +
                       " ,TRAVAR_PREVENDA_SEM_ROMANEIO " +
                       " ,SENHA_BIOMETRIA " +
                       " ,DIAS_FECHAMENTO_SEM_ROMANEIO " +
                       " ,DIAS_REAGENDAMENTO_ROMANEIO " +
                       " ,ADICIONAR_CLIENTE_LIVREMENTE " +
                       " ,VIAS_SANGRIAS_SUPRIMENTOS " +
                       " ,SAT_IP " +
                       " ,SAT_PORTA " +
                       " ,SAT_DIRETO " +
                       " ,QUANTIDADE_ROMANEIOS_PENDENTES_OPERADOR " +
                       " ,LIMITE_SUPRIMENTO " +
                       " ,SOLICITAR_SENHA_REEIMPRESAO_TEF " +
                       " ,TRAVAR_PREVENDA_SEM_ROMANEIO " +
                       " ,DIAS_FECHAMENTO_SEM_ROMANEIO " +
                       " ,QUANTIDADE_ROMANEIOS_PENDENTES_OPERADOR " +
                       " ,DIAS_REAGENDAMENTO_ROMANEIO " +
                       " ,CONSULTA_ROMANEIO_FILTRO " +
                       " FROM PARAMETROS";


            try
            {
                using (SqlCommand cmd = new SqlCommand(query, Conect.Conectar(Dados.DadosList[0].Servidor, Dados.DadosList[0].Banco, Dados.DadosList[0].Senha)))
                {
                    Dr = cmd.ExecuteReader();

                    while (Dr.Read())
                    {
                        tLoja.Text = Dr["LOJA"].ToString();
                        tIpServidor.Text = Dr["DB_SERVIDOR"].ToString().Replace(@"\SQLEXPRESS", "");
                        tCaixa.Text = Dr["CAIXA"].ToString();
                        tRazSocial.Text = Dr["RAZAO_SOCIAL"].ToString();
                        tLogradouro.Text = Dr["ENDERECO"].ToString();
                        tNumero.Text = Dr["NUMERO"].ToString();
                        tComplemento.Text = Dr["COMPLEMENTO"].ToString();
                        tBairro.Text = Dr["BAIRRO"].ToString();
                        tCidade.Text = Dr["CIDADE"].ToString();
                        tCep.Text = Dr["CEP"].ToString();
                        tInscFederal.Text = Dr["INSCRICAO_FEDERAL"].ToString();
                        tInscEstadual.Text = Dr["INSCRICAO_ESTADUAL"].ToString();
                        checkDebug.IsChecked = (Dr["DEBUG"].ToString() == "S") ? true : false;
                        tTelefone.Text = Dr["TELEFONE"].ToString(); ;
                        tUf.Text = Dr["ESTADO"].ToString(); ;
                        tLojaSitef.Text = Dr["LOJA_SITEF"].ToString(); 
                        tTerminalSitef.Text = Dr["TERMINAL_SITEF"].ToString(); 
                        tEmpresa.Text = Dr["EMPRESA"].ToString(); 
                        checkVidalink.IsChecked = (Dr["VIDALINK_ATIVADO"].ToString() == "S") ? true : false;
                        tIpVidalinkEnvio.Text = Dr["VIDALINK_ENVIO"].ToString().Replace(@"\\", "").Replace(@"\pdv01\ENVIO\", "");
                        tIpVidalinkResp.Text = Dr["VIDALINK_RESPOSTA"].ToString().Replace(@"\\", "").Replace(@"\pdv01\RESPOSTA\", "");
                        checkEpharma.IsChecked = (Dr["EPHARMA_ATIVADO"].ToString() == "S") ? true : false;
                        tIpEpharmaEnvio.Text = Dr["EPHARMA_ENVIO"].ToString().Replace(@"\\", "").Replace(@"\E-pharma\ENV\", "");
                        tIpEpharmaResp.Text = Dr["EPHARMA_RESPOSTA"].ToString().Replace(@"\\", "").Replace(@"\E-pharma\REC\", "");
                        // "@funcional", funcional="";
                        tIpFuncionalEnvio.Text = Dr["FCARD_ENVIO"].ToString().Replace(@"\\", "").Replace(@"\Funcional\ENV\", "");
                        tIpFuncionalResp.Text = Dr["FCARD_RESPOSTA"].ToString().Replace(@"\\", "").Replace(@"\Funcional\REC\", "");
                        tSangria.Text = Dr["LIMITE_SANGRIA_DINHEIRO"].ToString().Replace(",", ".");
                        tEntrega.Text = Dr["TAXA_ENTREGA"].ToString();
                        tVersao.Text = Dr["VERSAO"].ToString();
                        tDicionario.Text = Dr["CENTRAL_DICIONARIO"].ToString();
                        checkHabilitarControlado.IsChecked = (Dr["PERMITIR_CONTROLADO_VENDA_DIRETA"].ToString() == "S") ? true : false;
                        checkHabilitarConsultaDescricao.IsChecked = (Dr["PERMITIR_CONSULTA_DESCRICAO"].ToString() == "S") ? true : false;
                        checkHabilitarConsultaProduto.IsChecked = (Dr["HABILITAR_CONSULTA_PRODUTOS"].ToString() == "S") ? true : false;
                        tImpressora.SelectedItem = (Dr["SAT_IMPRESSORA"].ToString() == "S") ? true : false;
                        tAtivacaoSat.Text = Dr["SAT_CODIGO_ATIVACAO"].ToString();
                        tAssinatura.Text = Dr["SAT_ASSINATURA"].ToString();
                        tDll.Text = Dr["SAT_DLL"].ToString();
                        checkTravaPrevendaSemRomaneio.IsChecked = (Dr["TRAVAR_PREVENDA_SEM_ROMANEIO"].ToString() == "S") ? true : false;
                        checkHabilitarBiometria.IsChecked = (Dr["SENHA_BIOMETRIA"].ToString() == "S") ? true : false;
                        tDiasFechamentoSemRomaneio.Text = Dr["DIAS_FECHAMENTO_SEM_ROMANEIO"].ToString();
                        tDiasReagendamentoSemRomaneio.Text = Dr["DIAS_REAGENDAMENTO_ROMANEIO"].ToString();
                        checkAddClienteLivremente.IsChecked = (Dr["ADICIONAR_CLIENTE_LIVREMENTE"].ToString() == "S") ? true : false;
                        tQtdViasSangrias.Text = Dr["VIAS_SANGRIAS_SUPRIMENTOS"].ToString();
                        tIpSat.Text = Dr["SAT_IP"].ToString();
                        tPorta.Text = Dr["SAT_PORTA"].ToString();
                        checkComunicacaoSat.IsChecked = (Dr["SAT_DIRETO"].ToString() == "S") ? true : false;
                        tQtdRomaneiosPendentes.Text = Dr["QUANTIDADE_ROMANEIOS_PENDENTES_OPERADOR"].ToString();
                        tLimitesSuprimentos.Text = Dr["LIMITE_SUPRIMENTO"].ToString().Replace(",", ".");
                        checkSolicitarSenhaReimpressaoTef.IsChecked = (Dr["SOLICITAR_SENHA_REEIMPRESAO_TEF"].ToString() == "S") ? true : false;
                        //tFiltroConsultaRomaneio.Text = Dr["CONSULTA_ROMANEIO_FILTRO"].ToString();
                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar os dados");
                return false;
            }

        }

        private bool ConectarServidor()
        {
            try
            {
                string servidor = tIpServidor.Text;
                string query = "SELECT A.EMPRESA, A.INSCRICAO_FEDERAL, B.NOME, A.INSCRICAO_ESTADUAL, A.CENTRAL_DICIONARIO FROM PARAMETROS AS A INNER JOIN ENTIDADES AS B ON REPLACE(REPLACE(REPLACE(B.INSCRICAO_FEDERAL, '/', ''),'-', ''),'.', '') = A.INSCRICAO_FEDERAL";
                using (SqlCommand cmd = new SqlCommand(query, Conect.Conectar(tIpServidor.Text + "\\SQLEXPRESS", "LOJA", Dados.DadosList[0].Senha)))
                {

                    Dr = cmd.ExecuteReader();

                    while (Dr.Read())
                    {
                        tLoja.Text = Dr["EMPRESA"].ToString();
                        tEmpresa.Text = Dr["EMPRESA"].ToString(); ;
                        tInscFederal.Text = Dr["INSCRICAO_FEDERAL"].ToString();
                        tInscEstadual.Text = Dr["INSCRICAO_ESTADUAL"].ToString();
                        tRazSocial.Text = Dr["NOME"].ToString();
                        tDicionario.Text = Dr["CENTRAL_DICIONARIO"].ToString();

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void btnConectar_Click(object sender, RoutedEventArgs e)
        {
            Dados.Armazenar(
                TServidor.Text,
                tBanco.Text,
                tUsuario.Text,
                tSenha.Text,
                true
                );

            if (ConectarBanco())
            {
                tcUpdate.SelectedIndex = 1;

            }
            else
            {
                Dados.Armazenar(
                    "--",
                    "--",
                    "--",
                    "--",
                    false
                    );
            }

            lServidorConectado.Content = Dados.DadosList[0].Servidor.ToUpper();
            lUsuarioConectado.Content = Dados.DadosList[0].Usuario.ToUpper();
            lBancoConectado.Content = Dados.DadosList[0].Banco.ToUpper();

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void menu_MouseEnter(object sender, MouseEventArgs e)
        {
            if (tcUpdate.SelectedIndex == 0)
            {
                menuLogout.Visibility = Visibility.Collapsed;
                menuConfiguracoes.Visibility = Visibility.Visible;
                menuTruncate.Visibility = Visibility.Collapsed;
                menuSair.Visibility = Visibility.Visible;
                menuNovo.Visibility = Visibility.Collapsed;
                menuRecarregar.Visibility = Visibility.Collapsed;
            }
            else if (tcUpdate.SelectedIndex == 2 && Dados.DadosList[0].Conectado == false)
            {
                menuLogout.Visibility = Visibility.Collapsed;
                menuConfiguracoes.Visibility = Visibility.Visible;
                menuTruncate.Visibility = Visibility.Collapsed;
                menuSair.Visibility = Visibility.Visible;
                menuNovo.Visibility = Visibility.Collapsed;
                menuRecarregar.Visibility = Visibility.Collapsed;
            }
            else
            {
                menuLogout.Visibility = Visibility.Visible;
                menuConfiguracoes.Visibility = Visibility.Visible;
                menuTruncate.Visibility = Visibility.Visible;
                menuSair.Visibility = Visibility.Visible;
                menuNovo.Visibility = Visibility.Visible;
                menuRecarregar.Visibility = Visibility.Visible;
            }
        }

        private void menuRecarregar_Click(object sender, RoutedEventArgs e)
        {
            if (ConectarBanco())
            {
                tcUpdate.SelectedIndex = 1;

            }
        }

        private void menuLogout_Click(object sender, RoutedEventArgs e)
        {
            Dados.Armazenar(
                "--",
                "--",
                "--",
                "--",
                false
                );

            tcUpdate.SelectedIndex = 1;
            lServidorConectado.Content = "--";
            lUsuarioConectado.Content = "--";
            lBancoConectado.Content = "--";

            TServidor.Text = "";
            tBanco.Text = "";
            tUsuario.Text = "";
            tSenha.Text = "";
            checkBox1.IsChecked = false;

            tcUpdate.SelectedIndex = 0;
        }

        private void menuTruncate_Click(object sender, RoutedEventArgs e)
        {
            if (Dados.DadosList[0].Conectado)
            {
                if (MessageBox.Show("Deseja limpar todos os dados do banco '" + Dados.DadosList[0].Banco.ToUpper() + "' ?", "Limpar bando de dados", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    using (SqlCommand cmd = new SqlCommand(tQuery.Text, Conect.Conectar(Dados.DadosList[0].Servidor, Dados.DadosList[0].Banco, Dados.DadosList[0].Senha)))
                    {
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Truncate executado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Para rodar este processo é necessário primeiro conectar em um Servidor!");
            }
            
        }

        private void menuConfiguracoes_Click(object sender, RoutedEventArgs e)
        {

            string path = Directory.GetCurrentDirectory() + "\\setting.dll";
            string text = System.IO.File.ReadAllText(path);
            tQuery.Text = text;

            tcUpdate.SelectedIndex = 2;
        }

        private void btnSalvarTruncate_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\setting.dll";
            File.Delete(path);
            string text = tQuery.Text;

            using StreamWriter file = new(path, append: true);
            file.WriteLineAsync(text);
        }

        private void menuSair_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }

        private void menuNovo_Click(object sender, RoutedEventArgs e)
        {
            tLoja.Text = "";
            tIpServidor.Text = "";
            tCaixa.Text = "";
            tRazSocial.Text = "";
            tLogradouro.Text = "";
            tNumero.Text = "";
            tComplemento.Text = "";
            tBairro.Text = "";
            tCidade.Text = "";
            tCep.Text = "";
            tInscFederal.Text = "";
            tInscEstadual.Text = "";
            checkDebug.IsChecked = false;
            tTelefone.Text = "";
            tUf.Text = "";
            tLojaSitef.Text = "";
            tTerminalSitef.Text = "";
            tEmpresa.Text = "";
            checkVidalink.IsChecked = true;
            tIpVidalinkEnvio.Text = "";
            tIpVidalinkResp.Text = "";
            checkEpharma.IsChecked = true;
            tIpEpharmaEnvio.Text = "";
            tIpEpharmaResp.Text = "";
            // "@funcional", funcional="";
            tIpFuncionalEnvio.Text = "";
            tIpFuncionalResp.Text = "";
            tSangria.Text = "";
            tEntrega.Text = "";
            tVersao.Text = "";
            tDicionario.Text = "";
            checkHabilitarControlado.IsChecked = false;
            checkHabilitarConsultaDescricao.IsChecked = false;
            checkHabilitarConsultaProduto.IsChecked = false;
            tImpressora.Items.Clear();
            tAtivacaoSat.Text = "";
            tAssinatura.Text = "";
            tDll.Text = "";
            checkTravaPrevendaSemRomaneio.IsChecked = false;
            checkHabilitarBiometria.IsChecked = false;
            tDiasFechamentoSemRomaneio.Text = "";
            tDiasReagendamentoSemRomaneio.Text = "";
            checkAddClienteLivremente.IsChecked = false;
            tQtdViasSangrias.Text = "";
            tIpSat.Text = "";
            tPorta.Text = "";
            checkComunicacaoSat.IsChecked = false;
            tQtdRomaneiosPendentes.Text = "";
            tLimitesSuprimentos.Text = "";
            checkSolicitarSenhaReimpressaoTef.IsChecked = false;
        }

        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            tDicionario.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tVersao.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tSangria.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tEntrega.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tFiltroConsultaRomaneio.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tDll.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tPorta.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tDiasFechamentoSemRomaneio.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tDiasReagendamentoSemRomaneio.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tQtdViasSangrias.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tQtdRomaneiosPendentes.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tLimitesSuprimentos.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tLojaSitef.IsEnabled = checkBox1.IsChecked == true ? true : false;
            tTerminalSitef.IsEnabled = checkBox1.IsChecked == true ? true : false;
            checkTravaPrevendaSemRomaneio.IsEnabled= checkBox1.IsChecked == true ? true : false;
            checkSolicitarSenhaReimpressaoTef.IsEnabled = checkBox1.IsChecked == true ? true : false;
        }

        private void btnSincronizar_Click(object sender, RoutedEventArgs e)
        {
            if (ConectarServidor())
            {
                MessageBox.Show("Sincronizado!");
            }            

        }

        private void btnEditarTruncate_Click(object sender, RoutedEventArgs e)
        {
            tQuery.IsEnabled = true;
            tQuery.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Dados.DadosList[0].Conectado)
            {
                tcUpdate.SelectedIndex = 1;
                tcParametros.SelectedIndex = 0;
            }
            else
            {
                tcUpdate.SelectedIndex = 0;
            }
        }

        private void checkVidalink_Click(object sender, RoutedEventArgs e)
        {
            tIpVidalinkEnvio.IsEnabled = checkVidalink.IsChecked == true ? true : false;
            tIpVidalinkResp.IsEnabled = checkVidalink.IsChecked == true ? true : false;
        }

        private void checkEpharma_Click(object sender, RoutedEventArgs e)
        {
            tIpEpharmaEnvio.IsEnabled = checkEpharma.IsChecked == true ? true : false;
            tIpEpharmaResp.IsEnabled = checkEpharma.IsChecked == true ? true : false;
        }

        private void checkFuncional_Click(object sender, RoutedEventArgs e)
        {
            tIpFuncionalEnvio.IsEnabled = checkFuncional.IsChecked == true ? true : false;
            tIpFuncionalResp.IsEnabled = checkFuncional.IsChecked == true ? true : false;
        }

        private void tIpServidor_LostFocus(object sender, RoutedEventArgs e)
        {
            tIpEpharmaEnvio.Text = tIpServidor.Text;
            tIpFuncionalEnvio.Text = tIpServidor.Text;
            tIpVidalinkEnvio.Text = tIpServidor.Text;
            tIpEpharmaResp.Text = tIpServidor.Text;
            tIpFuncionalResp.Text = tIpServidor.Text;
            tIpVidalinkResp.Text = tIpServidor.Text;
            tIpSat.Text = tIpServidor.Text;
        }

        private void tInscFederal_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tInscFederal.Text.Length > 0)
            {
                tLojaSitef.Text = tInscFederal.Text.Substring(0, 5) + "0" + tLoja.Text;
            }
        }

        private void tTerminalSitef_LostFocus(object sender, RoutedEventArgs e)
        {
            string terminal = tTerminalSitef.Text;
            tTerminalSitef.Text = terminal.PadLeft(8, '0');
        }

        private void checkComunicacaoSat_Click(object sender, RoutedEventArgs e)
        {
            tIpSat.IsEnabled = checkComunicacaoSat.IsChecked == false ? true : false;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (Salvar())
            {
                MessageBox.Show("Parametros alterados com sucesso!");
            }
        }

        private void tCaixa_LostFocus(object sender, RoutedEventArgs e)
        {
            string terminal = tCaixa.Text;
            tTerminalSitef.Text = terminal.PadLeft(8, '0');
        }
    }
}
