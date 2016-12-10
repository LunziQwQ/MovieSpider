namespace Spider {
    partial class MovieViewerForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieViewerForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_name = new System.Windows.Forms.Label();
            this.label_trans = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.label_lang = new System.Windows.Forms.Label();
            this.label_length = new System.Windows.Forms.Label();
            this.label_IMDB = new System.Windows.Forms.Label();
            this.label_dir = new System.Windows.Forms.Label();
            this.label_leading = new System.Windows.Forms.Label();
            this.label_area = new System.Windows.Forms.Label();
            this.label_category = new System.Windows.Forms.Label();
            this.label_summary = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label_name
            // 
            resources.ApplyResources(this.label_name, "label_name");
            this.label_name.Name = "label_name";
            // 
            // label_trans
            // 
            resources.ApplyResources(this.label_trans, "label_trans");
            this.label_trans.Name = "label_trans";
            // 
            // label_time
            // 
            resources.ApplyResources(this.label_time, "label_time");
            this.label_time.Name = "label_time";
            // 
            // label_lang
            // 
            resources.ApplyResources(this.label_lang, "label_lang");
            this.label_lang.Name = "label_lang";
            // 
            // label_length
            // 
            resources.ApplyResources(this.label_length, "label_length");
            this.label_length.Name = "label_length";
            // 
            // label_IMDB
            // 
            resources.ApplyResources(this.label_IMDB, "label_IMDB");
            this.label_IMDB.Name = "label_IMDB";
            // 
            // label_dir
            // 
            resources.ApplyResources(this.label_dir, "label_dir");
            this.label_dir.Name = "label_dir";
            // 
            // label_leading
            // 
            resources.ApplyResources(this.label_leading, "label_leading");
            this.label_leading.Name = "label_leading";
            // 
            // label_area
            // 
            resources.ApplyResources(this.label_area, "label_area");
            this.label_area.Name = "label_area";
            // 
            // label_category
            // 
            resources.ApplyResources(this.label_category, "label_category");
            this.label_category.Name = "label_category";
            // 
            // label_summary
            // 
            resources.ApplyResources(this.label_summary, "label_summary");
            this.label_summary.Name = "label_summary";
            // 
            // MovieViewerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.label_summary);
            this.Controls.Add(this.label_category);
            this.Controls.Add(this.label_area);
            this.Controls.Add(this.label_leading);
            this.Controls.Add(this.label_dir);
            this.Controls.Add(this.label_IMDB);
            this.Controls.Add(this.label_length);
            this.Controls.Add(this.label_lang);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_trans);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MovieViewerForm";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_trans;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label_lang;
        private System.Windows.Forms.Label label_length;
        private System.Windows.Forms.Label label_IMDB;
        private System.Windows.Forms.Label label_dir;
        private System.Windows.Forms.Label label_leading;
        private System.Windows.Forms.Label label_area;
        private System.Windows.Forms.Label label_category;
        private System.Windows.Forms.Label label_summary;
    }
}