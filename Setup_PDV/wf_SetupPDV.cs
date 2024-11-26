using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Diagnostics;

namespace Setup_PDV
{
    public partial class wf_SetupPDV : DevExpress.XtraEditors.XtraForm
    {
        public wf_SetupPDV()
        {
            InitializeComponent();

            ////habilitar o evento de click do botão de finalizar
            wizardControl1.FinishClick += wizardControl1_FinishClick_1;

            ////habilitar o evento de click do botão de cancelar
            wizardControl1.CancelClick += wizardControl1_CancelClick;

            //habilitar o evento de click do botão de next
            wizardControl1.NextClick += wizardControl1_NextClick;
        }

        // Função para copiar todos os arquivos e diretórios recursivamente
        private void CopiarDiretorio(string origem, string destino)
        {
            // Copiar os arquivos da pasta de origem para o destino
            foreach (var arquivo in Directory.GetFiles(origem))
            {
                string nomeArquivo = Path.GetFileName(arquivo);
                string caminhoDestino = Path.Combine(destino, nomeArquivo);
                System.IO.File.Copy(arquivo, caminhoDestino, true); // Sobrescrever se já existir
            }

            // Copiar as subpastas
            foreach (var subDiretorio in Directory.GetDirectories(origem))
            {
                string nomeSubDiretorio = Path.GetFileName(subDiretorio);
                string caminhoSubDestino = Path.Combine(destino, nomeSubDiretorio);

                // Cria a subpasta no destino, caso não exista
                if (!Directory.Exists(caminhoSubDestino))
                {
                    Directory.CreateDirectory(caminhoSubDestino);
                }

                // Chama recursivamente para copiar subdiretórios
                CopiarDiretorio(subDiretorio, caminhoSubDestino);
            }
        }

        private void wizardControl1_FinishClick_1(object sender, CancelEventArgs e)
        {
            Process.Start(@"C:\App_System\App_System_PDV\App_PDV.exe");

            this.Close();
        }

        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (wizardPage1.Visible == true)
            {
                // Defina o valor máximo da ProgressBar com base no número de etapas
                progressBarInstalacao.Properties.Maximum = 5;
                progressBarInstalacao.Properties.Step = 1; // Cada etapa representa um incremento
                lblPorcentagemInstalacao.Text = "Instalação: 0%";

                // Execute cada etapa e atualize a barra de progresso

                InstalarAtualizacaoAutomatica();
                progressBarInstalacao.PerformStep(); // Incrementa a barra de progresso
                lblPorcentagemInstalacao.Text = "Instalação: 20%";

                CriarLogs();
                progressBarInstalacao.PerformStep(); // Incrementa a barra de progresso
                lblPorcentagemInstalacao.Text = "Instalação: 40%";

                InstalarBanco();
                progressBarInstalacao.PerformStep(); // Incrementa a barra de progresso
                lblPorcentagemInstalacao.Text = "Instalação: 60%";

                InstalarPDV();
                progressBarInstalacao.PerformStep(); // Incrementa a barra de progresso
                lblPorcentagemInstalacao.Text = "Instalação: 80%";

                CriarAtalhoNaAreaDeTrabalho(@"C:\App_System\App_System_PDV\App_PDV.exe", "App System PDV", "App System PDV");
                progressBarInstalacao.PerformStep(); // Incrementa a barra de progresso
                lblPorcentagemInstalacao.Text = "Instalação concluida: 100%";
            }
        }

        private void CriarLogs()
        {
            try
            {
                // Defina o caminho da pasta
                string folderPath = @"C:\App_System\App_System_Logs";

                // Crie a pasta (se ela não existir)
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Caminhos dos arquivos .txt
                string filePath1 = Path.Combine(folderPath, "LogErros.txt");
                string filePath2 = Path.Combine(folderPath, "LogVerificacao.txt");

                // Conteúdo dos arquivos
                string conteudoArquivo1 = "Inicializando os logs de erro.";
                string conteudoArquivo2 = "Inicializando os logs de verificacao.";

                // Crie e escreva o conteúdo nos arquivos
                System.IO.File.WriteAllText(filePath1, conteudoArquivo1);
                System.IO.File.WriteAllText(filePath2, conteudoArquivo2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro durante a criação dos arquivos de Log: {ex.Message}");
            }
        }

        private void InstalarBanco()
        {
            try
            {
                // Definir a origem (pasta Release dentro do projeto)
                string pastaOrigem = Path.Combine(Application.StartupPath, "App_System_Banco");

                // Verificar se a pasta de origem existe antes de copiar
                if (!Directory.Exists(pastaOrigem))
                {
                    Directory.CreateDirectory(pastaOrigem);
                }

                // Obter o diretório de instalação selecionado pelo usuário
                string diretorioInstalacao = @"C:\App_System"; // Exemplo, você pode adaptar isso

                // Verificar se o diretório de instalação existe, e se não, criar
                if (!Directory.Exists(diretorioInstalacao))
                {
                    Directory.CreateDirectory(diretorioInstalacao);
                }

                // Definir o destino onde a aplicação será instalada
                string pastaDestino = Path.Combine(diretorioInstalacao, "App_System_Banco");

                // Verificar se o diretório de destino existe, e se não, criar
                if (!Directory.Exists(pastaDestino))
                {
                    Directory.CreateDirectory(pastaDestino);
                }

                // Copiar todos os arquivos e subpastas da pasta de origem para o destino
                CopiarDiretorio(pastaOrigem, pastaDestino);

                // Definir o diretório de backup
                string diretorioArmazenamentoBackup = Path.Combine(pastaDestino, "Backup");

                // Verificar se o diretório de backup existe, e se não, criar
                if (!Directory.Exists(diretorioArmazenamentoBackup))
                {
                    Directory.CreateDirectory(diretorioArmazenamentoBackup);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro durante a instalação do Banco de dados: {ex.Message}");
            }

            // Método para copiar o diretório e subdiretórios
            void CopiarDiretorio(string origem, string destino)
            {
                DirectoryInfo dirOrigem = new DirectoryInfo(origem);
                DirectoryInfo[] subDiretorios = dirOrigem.GetDirectories();

                // Copiar todos os arquivos para o diretório de destino
                foreach (FileInfo arquivo in dirOrigem.GetFiles())
                {
                    string caminhoDestino = Path.Combine(destino, arquivo.Name);
                    arquivo.CopyTo(caminhoDestino, true);
                }

                // Recursivamente copiar subdiretórios
                foreach (DirectoryInfo subDiretorio in subDiretorios)
                {
                    string subDestino = Path.Combine(destino, subDiretorio.Name);
                    Directory.CreateDirectory(subDestino);
                    CopiarDiretorio(subDiretorio.FullName, subDestino);
                }
            }
        }

        private void InstalarAtualizacaoAutomatica()
        {
            try
            {
                // Definir a origem (pasta Release dentro do projeto)
                string pastaOrigem = Path.Combine(Application.StartupPath, "App_System_Update");

                // Obter o diretório de instalação selecionado pelo usuário (modifique conforme sua lógica)
                string diretorioInstalacao = @"C:\App_System"; // Exemplo, um TextBox onde o usuário escolhe o diretório

                // Verifica se o diretório já existe
                if (!Directory.Exists(diretorioInstalacao))
                {
                    // Se não existir, cria o diretório
                    Directory.CreateDirectory(diretorioInstalacao);
                }

                // Agora o diretório está garantido e você pode proceder com a cópia dos arquivos

                // Definir o destino onde a aplicação será instalada
                string pastaDestino = Path.Combine(diretorioInstalacao, "App_System_Update");

                // Verificar se o diretório de destino existe, se não, criar
                if (!Directory.Exists(pastaDestino))
                {
                    Directory.CreateDirectory(pastaDestino);
                }

                // Copiar todos os arquivos e subpastas da pasta de origem para o destino
                CopiarDiretorio(pastaOrigem, pastaDestino);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro durante a instalação da atualização automatica: {ex.Message}");
            }
        }

        private void InstalarPDV()
        {
            try
            {
                // Definir a origem (pasta Release dentro do projeto)
                string pastaOrigem = Path.Combine(Application.StartupPath, "App_System_PDV");

                // Obter o diretório de instalação selecionado pelo usuário (modifique conforme sua lógica)
                string diretorioInstalacao = @"C:\App_System"; // Exemplo, um TextBox onde o usuário escolhe o diretório

                // Verifica se o diretório já existe
                if (!Directory.Exists(diretorioInstalacao))
                {
                    // Se não existir, cria o diretório
                    Directory.CreateDirectory(diretorioInstalacao);
                }

                // Agora o diretório está garantido e você pode proceder com a cópia dos arquivos

                // Definir o destino onde a aplicação será instalada
                string pastaDestino = Path.Combine(diretorioInstalacao, "App_System_PDV");

                // Verificar se o diretório de destino existe, se não, criar
                if (!Directory.Exists(pastaDestino))
                {
                    Directory.CreateDirectory(pastaDestino);
                }

                // Copiar todos os arquivos e subpastas da pasta de origem para o destino
                CopiarDiretorio(pastaOrigem, pastaDestino);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro durante a instalação do PDV: {ex.Message}");
            }
        }

        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            var result = XtraMessageBox.Show("Tem certeza que deseja cancelar a instalação?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void CriarAtalhoNaAreaDeTrabalho(string caminhoExecutavel, string nomeAtalho, string descricaoAtalho)
        {
            // Caminho onde o atalho será criado na área de trabalho
            string caminhoAtalho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{nomeAtalho}.lnk");

            // Caminho do ícone na mesma pasta do executável
            string caminhoIcone = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gerar-icone-para-sistema-chamdo-PDV12.ico");

            // Cria o objeto WshShell
            var shell = new WshShell();
            IWshShortcut atalho = (IWshShortcut)shell.CreateShortcut(caminhoAtalho);

            // Define o caminho do executável e outras propriedades do atalho
            atalho.TargetPath = caminhoExecutavel;
            atalho.WorkingDirectory = Path.GetDirectoryName(caminhoExecutavel);
            atalho.Description = descricaoAtalho;

            // Define o ícone do atalho, se o arquivo de ícone existir
            if (System.IO.File.Exists(caminhoIcone))
            {
                atalho.IconLocation = caminhoIcone;
            }
            else
            {
                Console.WriteLine("Ícone não encontrado: " + caminhoIcone);
            }

            // Salva o atalho na área de trabalho
            atalho.Save();
        }
    }
}