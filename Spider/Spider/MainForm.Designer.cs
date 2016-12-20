namespace Spider {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox_Net = new System.Windows.Forms.GroupBox();
            this.label_netStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_setInterval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.textBox_setDeep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Grab = new System.Windows.Forms.Button();
            this.groupBox_Local = new System.Windows.Forms.GroupBox();
            this.label_spaceUsage = new System.Windows.Forms.Label();
            this.staticLabel2 = new System.Windows.Forms.Label();
            this.label_ItemCount = new System.Windows.Forms.Label();
            this.staticLabel1 = new System.Windows.Forms.Label();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_CopyLink = new System.Windows.Forms.Button();
            this.timer_Main = new System.Windows.Forms.Timer(this.components);
            this.listBox_category = new System.Windows.Forms.ListBox();
            this.listBox_movie = new System.Windows.Forms.ListBox();
            this.groupBox_Net.SuspendLayout();
            this.groupBox_Local.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Net
            // 
            this.groupBox_Net.Controls.Add(this.label_netStatus);
            this.groupBox_Net.Controls.Add(this.label4);
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
            // label_netStatus
            // 
            this.label_netStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_netStatus.Location = new System.Drawing.Point(268, 46);
            this.label_netStatus.Name = "label_netStatus";
            this.label_netStatus.Size = new System.Drawing.Size(131, 66);
            this.label_netStatus.TabIndex = 9;
            this.label_netStatus.Text = "Testing";
            this.label_netStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(268, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Net status:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox_setInterval
            // 
            this.textBox_setInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_setInterval.Location = new System.Drawing.Point(148, 85);
            this.textBox_setInterval.Name = "textBox_setInterval";
            this.textBox_setInterval.Size = new System.Drawing.Size(114, 23);
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
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Set grab interval:";
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(405, 81);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(110, 45);
            this.btn_Stop.TabIndex = 6;
            this.btn_Stop.Text = "Stop :(";
            this.btn_Stop.UseVisualStyleBackColor = true;
            // 
            // textBox_setDeep
            // 
            this.textBox_setDeep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_setDeep.Location = new System.Drawing.Point(148, 38);
            this.textBox_setDeep.Name = "textBox_setDeep";
            this.textBox_setDeep.Size = new System.Drawing.Size(114, 23);
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
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Set grab deep:";
            // 
            // btn_Grab
            // 
            this.btn_Grab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Grab.Location = new System.Drawing.Point(405, 15);
            this.btn_Grab.Margin = new System.Windows.Forms.Padding(8);
            this.btn_Grab.Name = "btn_Grab";
            this.btn_Grab.Size = new System.Drawing.Size(110, 62);
            this.btn_Grab.TabIndex = 1;
            this.btn_Grab.Text = "Grab!";
            this.btn_Grab.UseVisualStyleBackColor = true;
            this.btn_Grab.Click += new System.EventHandler(this.btn_Grab_Click);
            // 
            // groupBox_Local
            // 
            this.groupBox_Local.Controls.Add(this.listBox_movie);
            this.groupBox_Local.Controls.Add(this.listBox_category);
            this.groupBox_Local.Controls.Add(this.label_spaceUsage);
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
            // label_spaceUsage
            // 
            this.label_spaceUsage.AutoSize = true;
            this.label_spaceUsage.Location = new System.Drawing.Point(45, 130);
            this.label_spaceUsage.Name = "label_spaceUsage";
            this.label_spaceUsage.Size = new System.Drawing.Size(0, 20);
            this.label_spaceUsage.TabIndex = 6;
            // 
            // staticLabel2
            // 
            this.staticLabel2.AutoSize = true;
            this.staticLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staticLabel2.Location = new System.Drawing.Point(11, 110);
            this.staticLabel2.Name = "staticLabel2";
            this.staticLabel2.Size = new System.Drawing.Size(105, 17);
            this.staticLabel2.TabIndex = 5;
            this.staticLabel2.Text = "space usage:";
            // 
            // label_ItemCount
            // 
            this.label_ItemCount.AutoSize = true;
            this.label_ItemCount.Location = new System.Drawing.Point(45, 72);
            this.label_ItemCount.Name = "label_ItemCount";
            this.label_ItemCount.Size = new System.Drawing.Size(0, 20);
            this.label_ItemCount.TabIndex = 4;
            // 
            // staticLabel1
            // 
            this.staticLabel1.AutoSize = true;
            this.staticLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staticLabel1.Location = new System.Drawing.Point(11, 52);
            this.staticLabel1.Name = "staticLabel1";
            this.staticLabel1.Size = new System.Drawing.Size(88, 17);
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
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(15, 281);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(125, 45);
            this.btn_Remove.TabIndex = 1;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_CopyLink
            // 
            this.btn_CopyLink.Location = new System.Drawing.Point(15, 332);
            this.btn_CopyLink.Name = "btn_CopyLink";
            this.btn_CopyLink.Size = new System.Drawing.Size(125, 45);
            this.btn_CopyLink.TabIndex = 0;
            this.btn_CopyLink.Text = "Copy Link";
            this.btn_CopyLink.UseVisualStyleBackColor = true;
            this.btn_CopyLink.Click += new System.EventHandler(this.btn_CopyLink_Click);
            // 
            // timer_Main
            // 
            this.timer_Main.Enabled = true;
            this.timer_Main.Interval = 10;
            this.timer_Main.Tick += new System.EventHandler(this.timer_Main_Tick);
            // 
            // listBox_category
            // 
            this.listBox_category.FormattingEnabled = true;
            this.listBox_category.ItemHeight = 20;
            this.listBox_category.Location = new System.Drawing.Point(146, 13);
            this.listBox_category.Name = "listBox_category";
            this.listBox_category.Size = new System.Drawing.Size(128, 364);
            this.listBox_category.TabIndex = 7;
            this.listBox_category.SelectedIndexChanged += new System.EventHandler(this.listBox_category_SelectedIndexChanged);
            // 
            // listBox_movie
            // 
            this.listBox_movie.FormattingEnabled = true;
            this.listBox_movie.ItemHeight = 20;
            this.listBox_movie.Location = new System.Drawing.Point(280, 13);
            this.listBox_movie.Name = "listBox_movie";
            this.listBox_movie.Size = new System.Drawing.Size(235, 364);
            this.listBox_movie.TabIndex = 8;
            this.listBox_movie.SelectedIndexChanged += new System.EventHandler(this.listBox_movie_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(552, 553);
            this.Controls.Add(this.groupBox_Local);
            this.Controls.Add(this.groupBox_Net);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MovieSpider";
            this.Load += new System.EventHandler(this.MainForm_Load);
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
        private System.Windows.Forms.Label label_spaceUsage;
        private System.Windows.Forms.TextBox textBox_setDeep;
        private System.Windows.Forms.TextBox textBox_setInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label label_netStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer_Main;
        private System.Windows.Forms.ListBox listBox_movie;
        private System.Windows.Forms.ListBox listBox_category;
    }
}

