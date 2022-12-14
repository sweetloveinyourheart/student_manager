namespace Quản_lý_điểm_sinh_vien_CNTT
{
    partial class ReportDSSV
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetDSSV = new Quản_lý_điểm_sinh_vien_CNTT.DataSetDSSV();
            this.tblSINH_VIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblSINH_VIENTableAdapter = new Quản_lý_điểm_sinh_vien_CNTT.DataSetDSSVTableAdapters.tblSINH_VIENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetDSSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSINH_VIENBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetDSSV_tblSINH_VIEN";
            reportDataSource1.Value = this.tblSINH_VIENBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Quản_lý_điểm_sinh_vien_CNTT.DSSV.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(714, 439);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetDSSV
            // 
            this.DataSetDSSV.DataSetName = "DataSetDSSV";
            this.DataSetDSSV.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblSINH_VIENBindingSource
            // 
            this.tblSINH_VIENBindingSource.DataMember = "tblSINH_VIEN";
            this.tblSINH_VIENBindingSource.DataSource = this.DataSetDSSV;
            // 
            // tblSINH_VIENTableAdapter
            // 
            this.tblSINH_VIENTableAdapter.ClearBeforeFill = true;
            // 
            // ReportDSSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 439);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportDSSV";
            this.Text = "ReportDSSV";
            this.Load += new System.EventHandler(this.ReportDSSV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetDSSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSINH_VIENBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblSINH_VIENBindingSource;
        private DataSetDSSV DataSetDSSV;
        private Quản_lý_điểm_sinh_vien_CNTT.DataSetDSSVTableAdapters.tblSINH_VIENTableAdapter tblSINH_VIENTableAdapter;
    }
}