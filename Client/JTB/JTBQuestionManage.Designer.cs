namespace Client.JTB
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Entity;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    partial class JTBQuestionManage
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

       
 private void InitializeComponent()
        {
            this.cbQuestion = new ComboBox();
            this.lblQueation = new Label();
            this.dataGridView1 = new DataGridView();
            this.btnStore = new Button();
            this.pnlBottom = new Panel();
            this.btnDel = new Button();
            this.btnNew = new Button();
            this.pnlTop = new Panel();
            this.lblNewQuestion = new Label();
            this.txtQuestion = new TextBox();
            this.Column1 = new DataGridViewTextBoxColumn();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            base.SuspendLayout();
            this.cbQuestion.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbQuestion.FormattingEnabled = true;
            this.cbQuestion.Location = new Point(93, 12);
            this.cbQuestion.Name = "cbQuestion";
            this.cbQuestion.Size = new Size(192, 20);
            this.cbQuestion.TabIndex = 0;
            this.cbQuestion.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cbQuestion.TextChanged += new EventHandler(this.cbQuestion_TextChanged);
            this.lblQueation.AutoSize = true;
            this.lblQueation.Location = new Point(46, 16);
            this.lblQueation.Name = "lblQueation";
            this.lblQueation.Size = new Size(41, 12);
            this.lblQueation.TabIndex = 1;
            this.lblQueation.Text = "问题：";
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.Column1 });
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Location = new Point(0, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new Size(371, 204);
            this.dataGridView1.TabIndex = 2;
            this.btnStore.Location = new Point(148, 12);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new Size(75, 23);
            this.btnStore.TabIndex = 3;
            this.btnStore.Text = "保存问题";
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new EventHandler(this.btnStore_Click);
            this.pnlBottom.Controls.Add(this.btnDel);
            this.pnlBottom.Controls.Add(this.btnNew);
            this.pnlBottom.Controls.Add(this.btnStore);
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Location = new Point(0, 275);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new Size(371, 47);
            this.pnlBottom.TabIndex = 4;
            this.btnDel.Location = new Point(263, 12);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new Size(75, 23);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "删除问题";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new EventHandler(this.btnDel_Click);
            this.btnNew.Location = new Point(33, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new Size(75, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "新增问题";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new EventHandler(this.btnNew_Click);
            this.pnlTop.Controls.Add(this.lblNewQuestion);
            this.pnlTop.Controls.Add(this.txtQuestion);
            this.pnlTop.Controls.Add(this.lblQueation);
            this.pnlTop.Controls.Add(this.cbQuestion);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Location = new Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(371, 71);
            this.pnlTop.TabIndex = 5;
            this.lblNewQuestion.AutoSize = true;
            this.lblNewQuestion.Location = new Point(22, 42);
            this.lblNewQuestion.Name = "lblNewQuestion";
            this.lblNewQuestion.Size = new Size(65, 12);
            this.lblNewQuestion.TabIndex = 3;
            this.lblNewQuestion.Text = "修改问题：";
            this.txtQuestion.Location = new Point(93, 38);
            this.txtQuestion.MaxLength = 100;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new Size(192, 21);
            this.txtQuestion.TabIndex = 2;
            this.Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "答案";
            this.Column1.MaxInputLength = 25;
            this.Column1.Name = "Column1";
            this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(371, 322);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.pnlBottom);
            base.Controls.Add(this.pnlTop);
            base.Name = "JTBQuestionManage";
            this.Text = "提问问题维护";
            base.Load += new EventHandler(this.JTBQuestionManage_Load);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private Button btnDel;
        private Button btnNew;
        private Button btnStore;
        private System.Windows.Forms.ComboBox cbQuestion;
        private DataGridViewTextBoxColumn Column1;
        private DataGridView dataGridView1;
        private DataTable dt;
        private Label lblNewQuestion;
        private Label lblQueation;
        private Panel pnlBottom;
        private Panel pnlTop;
        private TextBox txtQuestion;
    }
}