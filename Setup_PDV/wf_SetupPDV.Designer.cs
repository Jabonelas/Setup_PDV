namespace Setup_PDV
{
    partial class wf_SetupPDV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.lblPorcentagemInstalacao = new DevExpress.XtraEditors.LabelControl();
            this.progressBarInstalacao = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtLocalInstalacao = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarInstalacao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalInstalacao.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelText = "Cancelar";
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.FinishText = "&Concluir";
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "&Avençar >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< &Voltar";
            this.wizardControl1.Size = new System.Drawing.Size(677, 432);
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.IntroductionText = "Bem-vindo(a) ao assistente de instalação do App System - PDV. Este processo o gui" +
    "ará pelos passos necessários para instalar o software no seu computador.";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "Clique em Avançar para continuar.";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(460, 277);
            this.welcomeWizardPage1.Text = "Bem-vindo(a) ao Instalador do App System - PDV";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.lblPorcentagemInstalacao);
            this.wizardPage1.Controls.Add(this.progressBarInstalacao);
            this.wizardPage1.Controls.Add(this.labelControl2);
            this.wizardPage1.Controls.Add(this.txtLocalInstalacao);
            this.wizardPage1.Controls.Add(this.labelControl1);
            this.wizardPage1.Controls.Add(this.labelControl3);
            this.wizardPage1.DescriptionText = "O Programa de instalação está pronto para começar a instalação do App System - PD" +
    "V no seu computaro.";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(645, 289);
            this.wizardPage1.Text = "Diretório de Instalação";
            // 
            // lblPorcentagemInstalacao
            // 
            this.lblPorcentagemInstalacao.Location = new System.Drawing.Point(31, 141);
            this.lblPorcentagemInstalacao.Name = "lblPorcentagemInstalacao";
            this.lblPorcentagemInstalacao.Size = new System.Drawing.Size(74, 13);
            this.lblPorcentagemInstalacao.TabIndex = 10;
            this.lblPorcentagemInstalacao.Text = "Instalação: 0%";
            // 
            // progressBarInstalacao
            // 
            this.progressBarInstalacao.Location = new System.Drawing.Point(31, 160);
            this.progressBarInstalacao.Name = "progressBarInstalacao";
            this.progressBarInstalacao.Size = new System.Drawing.Size(583, 20);
            this.progressBarInstalacao.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(94, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Local de instalação:";
            // 
            // txtLocalInstalacao
            // 
            this.txtLocalInstalacao.EditValue = "C:\\App_System";
            this.txtLocalInstalacao.Enabled = false;
            this.txtLocalInstalacao.Location = new System.Drawing.Point(31, 90);
            this.txtLocalInstalacao.Name = "txtLocalInstalacao";
            this.txtLocalInstalacao.Size = new System.Drawing.Size(583, 20);
            this.txtLocalInstalacao.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 273);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(166, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Clique em Avançar para continuar.";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(31, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(400, 26);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "O App System - PDV será instalado no diretório padrão: C:\\App_System. \r\nCertifiqu" +
    "e-se de que há espaço suficiente no disco para continuar com a instalação.";
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.FinishText = "A instalação do App System - PDV foi concluída com sucesso!\r\n\r\nO App System - PDV" +
    " será iniciado automaticamente ao concluir o assistente. Aproveite para explorar" +
    " seus recursos e funcionalidades.\r\n";
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "Clique em Concluir para sair do assistente de instalação.";
            this.completionWizardPage1.Size = new System.Drawing.Size(460, 300);
            this.completionWizardPage1.Text = "Conclusão da Instalação";
            // 
            // wf_SetupPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 432);
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wf_SetupPDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup App System - PDV";
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarInstalacao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalInstalacao.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblPorcentagemInstalacao;
        private DevExpress.XtraEditors.ProgressBarControl progressBarInstalacao;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtLocalInstalacao;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}