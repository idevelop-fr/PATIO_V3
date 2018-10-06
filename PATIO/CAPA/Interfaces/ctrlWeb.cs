using System.Windows.Forms;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlWeb : UserControl
    {
        public string url;

        public ctrlWeb()
        {
            InitializeComponent();
            Initialise();
        }

        public void Initialise()
        {
            wb.Navigate(url);
        }
    }
}
