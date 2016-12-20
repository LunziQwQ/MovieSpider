using System.Drawing;
using System.Windows.Forms;

namespace Spider {
    public partial class MovieViewerForm: Form {
        public MovieViewerForm() {
            InitializeComponent();
        }
        
        public void init(MovieItem movie) {
            label_area.Text = movie.Area;
            label_category.Text = movie.Category;
            label_dir.Text = movie.Director;
            label_IMDB.Text = movie.IMDBScore;
            label_lang.Text = movie.Language;
            label_leading.Text = movie.LeadingRole;
            label_length.Text = movie.LengthOfFilm;
            label_name.Text = movie.Name;
            label_summary.Text = movie.Summary;
            label_time.Text = movie.Time;
            label_trans.Text = movie.TranslatedTerm;
            image_cover.Image = Image.FromFile(movie.CoverPath);
            this.Location = new Point(MainForm.location.X + MainForm.width, MainForm.location.Y);
        }
    }
}
