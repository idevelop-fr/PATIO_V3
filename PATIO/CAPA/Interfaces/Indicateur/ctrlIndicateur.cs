using System.Windows.Forms;
using PATIO.CAPA.Classes;
using PATIO.MAIN.Classes;

namespace PATIO.CAPA.Interfaces
{
    public partial class ctrlIndicateur : UserControl
    {
        public AccesNet Acces;
        public TreeNode NodG;
        public string IndicateurId;

        public ctrlConsole Console = new ctrlConsole();

        public ctrlIndicateur()
        {
            InitializeComponent();
        }

        public void Affiche()
        {

        }
    }
}
