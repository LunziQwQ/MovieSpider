﻿namespace Spider {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox_Net = new System.Windows.Forms.GroupBox();
            this.textBox_setInterval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.textBox_setDeep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Grab = new System.Windows.Forms.Button();
            this.groupBox_Local = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.staticLabel2 = new System.Windows.Forms.Label();
            this.label_ItemCount = new System.Windows.Forms.Label();
            this.staticLabel1 = new System.Windows.Forms.Label();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_CopyLink = new System.Windows.Forms.Button();
            this.groupBox_Net.SuspendLayout();
            this.groupBox_Local.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Net
            // 
            this.groupBox_Net.Controls.Add(this.textBox_setInterval);
            this.groupBox_Net.Controls.Add(this.label1);
            this.groupBox_Net.Controls.Add(this.btn_Stop);
            this.groupBox_Net.Controls.Add(this.textBox_setDeep);
            this.groupBox_Net.Controls.Add(this.label3);
            this.groupBox_Net.Controls.Add(this.btn_Grab);
            this.groupBox_Net.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Net.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Net.Name = "groupBox_Net";
            this.groupBox_Net.Size = new System.Drawing.Size(528, 130);
            this.groupBox_Net.TabIndex = 0;
            this.groupBox_Net.TabStop = false;
            this.groupBox_Net.Text = "NetSpider";
            // 
            // textBox_setInterval
            // 
            this.textBox_setInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_setInterval.Location = new System.Drawing.Point(148, 85);
            this.textBox_setInterval.Name = "textBox_setInterval";
            this.textBox_setInterval.Size = new System.Drawing.Size(114, 27);
            this.textBox_setInterval.TabIndex = 8;
            this.textBox_setInterval.Text = "100";
            this.textBox_setInterval.TextChanged += new System.EventHandler(this.textBox_setInterval_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Set grab interval:";
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(327, 41);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(67, 64);
            this.btn_Stop.TabIndex = 6;
            this.btn_Stop.Text = "Stop :(";
            this.btn_Stop.UseVisualStyleBackColor = true;
            // 
            // textBox_setDeep
            // 
            this.textBox_setDeep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_setDeep.Location = new System.Drawing.Point(148, 38);
            this.textBox_setDeep.Name = "textBox_setDeep";
            this.textBox_setDeep.Size = new System.Drawing.Size(114, 27);
            this.textBox_setDeep.TabIndex = 5;
            this.textBox_setDeep.Text = "100";
            this.textBox_setDeep.TextChanged += new System.EventHandler(this.textBox_setDeep_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Set grab deep:";
            // 
            // btn_Grab
            // 
            this.btn_Grab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Grab.Location = new System.Drawing.Point(405, 21);
            this.btn_Grab.Margin = new System.Windows.Forms.Padding(8);
            this.btn_Grab.Name = "btn_Grab";
            this.btn_Grab.Size = new System.Drawing.Size(110, 95);
            this.btn_Grab.TabIndex = 1;
            this.btn_Grab.Text = "Grab!";
            this.btn_Grab.UseVisualStyleBackColor = true;
            // 
            // groupBox_Local
            // 
            this.groupBox_Local.Controls.Add(this.treeView1);
            this.groupBox_Local.Controls.Add(this.label2);
            this.groupBox_Local.Controls.Add(this.staticLabel2);
            this.groupBox_Local.Controls.Add(this.label_ItemCount);
            this.groupBox_Local.Controls.Add(this.staticLabel1);
            this.groupBox_Local.Controls.Add(this.btn_Reload);
            this.groupBox_Local.Controls.Add(this.btn_Remove);
            this.groupBox_Local.Controls.Add(this.btn_CopyLink);
            this.groupBox_Local.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Local.Location = new System.Drawing.Point(12, 148);
            this.groupBox_Local.Name = "groupBox_Local";
            this.groupBox_Local.Size = new System.Drawing.Size(528, 393);
            this.groupBox_Local.TabIndex = 2;
            this.groupBox_Local.TabStop = false;
            this.groupBox_Local.Text = "Local Viewer";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(163, 29);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(349, 348);
            this.treeView1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "NaN";
            // 
            // staticLabel2
            // 
            this.staticLabel2.AutoSize = true;
            this.staticLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staticLabel2.Location = new System.Drawing.Point(11, 110);
            this.staticLabel2.Name = "staticLabel2";
            this.staticLabel2.Size = new System.Drawing.Size(121, 20);
            this.staticLabel2.TabIndex = 5;
            this.staticLabel2.Text = "space usage:";
            // 
            // label_ItemCount
            // 
            this.label_ItemCount.AutoSize = true;
            this.label_ItemCount.Location = new System.Drawing.Point(45, 72);
            this.label_ItemCount.Name = "label_ItemCount";
            this.label_ItemCount.Size = new System.Drawing.Size(54, 25);
            this.label_ItemCount.TabIndex = 4;
            this.label_ItemCount.Text = "NaN";
            // 
            // staticLabel1
            // 
            this.staticLabel1.AutoSize = true;
            this.staticLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staticLabel1.Location = new System.Drawing.Point(11, 52);
            this.staticLabel1.Name = "staticLabel1";
            this.staticLabel1.Size = new System.Drawing.Size(103, 20);
            this.staticLabel1.TabIndex = 3;
            this.staticLabel1.Text = "item count:";
            // 
            // btn_Reload
            // 
            this.btn_Reload.Location = new System.Drawing.Point(15, 230);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(125, 45);
            this.btn_Reload.TabIndex = 2;
            this.btn_Reload.Text = "Reload";
            this.btn_Reload.UseVisualStyleBackColor = true;
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(15, 281);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(125, 45);
            this.btn_Remove.TabIndex = 1;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            // 
            // btn_CopyLink
            // 
            this.btn_CopyLink.Location = new System.Drawing.Point(15, 332);
            this.btn_CopyLink.Name = "btn_CopyLink";
            this.btn_CopyLink.Size = new System.Drawing.Size(125, 45);
            this.btn_CopyLink.TabIndex = 0;
            this.btn_CopyLink.Text = "Copy Link";
            this.btn_CopyLink.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(552, 553);
            this.Controls.Add(this.groupBox_Local);
            this.Controls.Add(this.groupBox_Net);
            this.Name = "MainForm";
            this.Text = "MovieSpider";
            this.groupBox_Net.ResumeLayout(false);
            this.groupBox_Net.PerformLayout();
            this.groupBox_Local.ResumeLayout(false);
            this.groupBox_Local.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Net;
        private System.Windows.Forms.Button btn_Grab;
        private System.Windows.Forms.GroupBox groupBox_Local;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_CopyLink;
        private System.Windows.Forms.Label label_ItemCount;
        private System.Windows.Forms.Label staticLabel1;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.Label staticLabel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_setDeep;
        private System.Windows.Forms.TextBox textBox_setInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.TreeView treeView1;
    }
}

