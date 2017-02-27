namespace CScherp_Game
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.panelEditor = new System.Windows.Forms.Panel();
            this.entityInfoEditor = new System.Windows.Forms.GroupBox();
            this.directionInputEntityEditor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nameEntity = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yEntityEditor = new System.Windows.Forms.Label();
            this.xEntityEditor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.spritePreviewEditor = new System.Windows.Forms.PictureBox();
            this.entitySelectEditor = new System.Windows.Forms.GroupBox();
            this.entityListEditor = new System.Windows.Forms.ComboBox();
            this.messageBoxEditor = new System.Windows.Forms.GroupBox();
            this.messageTextEditor = new System.Windows.Forms.Label();
            this.cancelButtonEditor = new System.Windows.Forms.Button();
            this.saveButtonEditor = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.entityInfoEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritePreviewEditor)).BeginInit();
            this.entitySelectEditor.SuspendLayout();
            this.messageBoxEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEditor
            // 
            this.panelEditor.BackColor = System.Drawing.SystemColors.Desktop;
            this.panelEditor.Location = new System.Drawing.Point(12, 12);
            this.panelEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelEditor.Name = "panelEditor";
            this.panelEditor.Size = new System.Drawing.Size(567, 310);
            this.panelEditor.TabIndex = 0;
            this.panelEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelEditor_MouseDown);
            this.panelEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEditor_MouseMove);
            // 
            // entityInfoEditor
            // 
            this.entityInfoEditor.Controls.Add(this.directionInputEntityEditor);
            this.entityInfoEditor.Controls.Add(this.label6);
            this.entityInfoEditor.Controls.Add(this.nameEntity);
            this.entityInfoEditor.Controls.Add(this.label5);
            this.entityInfoEditor.Controls.Add(this.yEntityEditor);
            this.entityInfoEditor.Controls.Add(this.xEntityEditor);
            this.entityInfoEditor.Controls.Add(this.label4);
            this.entityInfoEditor.Controls.Add(this.label3);
            this.entityInfoEditor.Controls.Add(this.spritePreviewEditor);
            this.entityInfoEditor.Location = new System.Drawing.Point(479, 480);
            this.entityInfoEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.entityInfoEditor.Name = "entityInfoEditor";
            this.entityInfoEditor.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.entityInfoEditor.Size = new System.Drawing.Size(267, 160);
            this.entityInfoEditor.TabIndex = 1;
            this.entityInfoEditor.TabStop = false;
            this.entityInfoEditor.Text = "Entity Info";
            // 
            // directionInputEntityEditor
            // 
            this.directionInputEntityEditor.Location = new System.Drawing.Point(87, 114);
            this.directionInputEntityEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.directionInputEntityEditor.Name = "directionInputEntityEditor";
            this.directionInputEntityEditor.Size = new System.Drawing.Size(100, 22);
            this.directionInputEntityEditor.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Direction: ";
            // 
            // nameEntity
            // 
            this.nameEntity.AutoSize = true;
            this.nameEntity.Location = new System.Drawing.Point(73, 26);
            this.nameEntity.Name = "nameEntity";
            this.nameEntity.Size = new System.Drawing.Size(13, 17);
            this.nameEntity.TabIndex = 8;
            this.nameEntity.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Name: ";
            // 
            // yEntityEditor
            // 
            this.yEntityEditor.AutoSize = true;
            this.yEntityEditor.Location = new System.Drawing.Point(44, 71);
            this.yEntityEditor.Name = "yEntityEditor";
            this.yEntityEditor.Size = new System.Drawing.Size(13, 17);
            this.yEntityEditor.TabIndex = 4;
            this.yEntityEditor.Text = "-";
            // 
            // xEntityEditor
            // 
            this.xEntityEditor.AutoSize = true;
            this.xEntityEditor.Location = new System.Drawing.Point(44, 50);
            this.xEntityEditor.Name = "xEntityEditor";
            this.xEntityEditor.Size = new System.Drawing.Size(17, 17);
            this.xEntityEditor.TabIndex = 3;
            this.xEntityEditor.Text = "- ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "X: ";
            // 
            // spritePreviewEditor
            // 
            this.spritePreviewEditor.Location = new System.Drawing.Point(173, 50);
            this.spritePreviewEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spritePreviewEditor.Name = "spritePreviewEditor";
            this.spritePreviewEditor.Size = new System.Drawing.Size(44, 39);
            this.spritePreviewEditor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spritePreviewEditor.TabIndex = 0;
            this.spritePreviewEditor.TabStop = false;
            // 
            // entitySelectEditor
            // 
            this.entitySelectEditor.Controls.Add(this.entityListEditor);
            this.entitySelectEditor.Location = new System.Drawing.Point(273, 478);
            this.entitySelectEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.entitySelectEditor.Name = "entitySelectEditor";
            this.entitySelectEditor.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.entitySelectEditor.Size = new System.Drawing.Size(200, 160);
            this.entitySelectEditor.TabIndex = 3;
            this.entitySelectEditor.TabStop = false;
            this.entitySelectEditor.Text = "Entity Select";
            // 
            // entityListEditor
            // 
            this.entityListEditor.FormattingEnabled = true;
            this.entityListEditor.Location = new System.Drawing.Point(5, 34);
            this.entityListEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.entityListEditor.Name = "entityListEditor";
            this.entityListEditor.Size = new System.Drawing.Size(121, 24);
            this.entityListEditor.TabIndex = 1;
            this.entityListEditor.SelectedIndexChanged += new System.EventHandler(this.entityListEditor_SelectedIndexChanged);
            // 
            // messageBoxEditor
            // 
            this.messageBoxEditor.Controls.Add(this.messageTextEditor);
            this.messageBoxEditor.Location = new System.Drawing.Point(12, 478);
            this.messageBoxEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.messageBoxEditor.Name = "messageBoxEditor";
            this.messageBoxEditor.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.messageBoxEditor.Size = new System.Drawing.Size(255, 160);
            this.messageBoxEditor.TabIndex = 4;
            this.messageBoxEditor.TabStop = false;
            this.messageBoxEditor.Text = "Message";
            // 
            // messageTextEditor
            // 
            this.messageTextEditor.AutoSize = true;
            this.messageTextEditor.Location = new System.Drawing.Point(16, 55);
            this.messageTextEditor.Name = "messageTextEditor";
            this.messageTextEditor.Size = new System.Drawing.Size(87, 17);
            this.messageTextEditor.TabIndex = 0;
            this.messageTextEditor.Text = "No message";
            // 
            // cancelButtonEditor
            // 
            this.cancelButtonEditor.Location = new System.Drawing.Point(661, 644);
            this.cancelButtonEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButtonEditor.Name = "cancelButtonEditor";
            this.cancelButtonEditor.Size = new System.Drawing.Size(84, 32);
            this.cancelButtonEditor.TabIndex = 5;
            this.cancelButtonEditor.Text = "Return";
            this.cancelButtonEditor.UseVisualStyleBackColor = true;
            this.cancelButtonEditor.Click += new System.EventHandler(this.cancelButtonEditor_Click);
            // 
            // saveButtonEditor
            // 
            this.saveButtonEditor.Location = new System.Drawing.Point(581, 645);
            this.saveButtonEditor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButtonEditor.Name = "saveButtonEditor";
            this.saveButtonEditor.Size = new System.Drawing.Size(75, 32);
            this.saveButtonEditor.TabIndex = 6;
            this.saveButtonEditor.Text = "Save";
            this.saveButtonEditor.UseVisualStyleBackColor = true;
            this.saveButtonEditor.Click += new System.EventHandler(this.saveButtonEditor_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 688);
            this.Controls.Add(this.saveButtonEditor);
            this.Controls.Add(this.cancelButtonEditor);
            this.Controls.Add(this.messageBoxEditor);
            this.Controls.Add(this.entitySelectEditor);
            this.Controls.Add(this.entityInfoEditor);
            this.Controls.Add(this.panelEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Editor";
            this.Text = "Editor";
            this.entityInfoEditor.ResumeLayout(false);
            this.entityInfoEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritePreviewEditor)).EndInit();
            this.entitySelectEditor.ResumeLayout(false);
            this.messageBoxEditor.ResumeLayout(false);
            this.messageBoxEditor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEditor;
        private System.Windows.Forms.GroupBox entityInfoEditor;
        private System.Windows.Forms.GroupBox entitySelectEditor;
        private System.Windows.Forms.ComboBox entityListEditor;
        private System.Windows.Forms.GroupBox messageBoxEditor;
        private System.Windows.Forms.Button cancelButtonEditor;
        private System.Windows.Forms.Button saveButtonEditor;
        private System.Windows.Forms.PictureBox spritePreviewEditor;
        private System.Windows.Forms.Label yEntityEditor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label messageTextEditor;
        private System.Windows.Forms.Label nameEntity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox directionInputEntityEditor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label xEntityEditor;
    }
}