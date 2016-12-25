using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Spider {
    public partial class MovieViewerForm: Form {
        FileManager fileManager = FileManager.getInstance();
        public MovieViewerForm() {
            InitializeComponent();
        }
        
        public void init(MovieItem movie) {
            label_area.Text += movie.area;
            label_category.Text += movie.category;
            label_sub.Text += movie.subtitle;
            label_IMDB.Text += movie.imdbScore;
            label_lang.Text += movie.language;
            label_leading.Text += movie.leadingRole;
            label_length.Text += movie.lengthOfFilm;
            label_name.Text += movie.name;
            label_summary.Text += movie.summary;
            label_time.Text += movie.time;
            label_trans.Text += movie.translatedTerm;
            if (movie.coverURL != "") {
                try {
                    image_cover.Image = Image.FromFile(fileManager.getPath(movie) + "\\cover.jpg");
                }catch(Exception e) {
                    Debug.Print("MVF line:29:" + e.Message);
                }
            }
            this.Show();
            updateLocation();
        }

        public void updateLocation() {
            this.Location = new Point(MainForm.location.X + MainForm.width - 12, MainForm.location.Y);
        }
    }
}
