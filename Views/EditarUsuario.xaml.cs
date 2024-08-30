using System.Windows;
using System.Windows.Input;
using UIDesign.Core;
using UIDesign.Model;

namespace UIDesign.Views
{
    public partial class EditarUsuario : Window
    {
        #region Atributos / Propiedades locales

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public new string Name
        {
            get { return txbName.Text.Trim(); }
            set { txbName.Text = value.Trim(); }
        }
        public string Position
        {
            get { return txbPosition.Text.Trim(); }
            set { txbPosition.Text = value.Trim(); }
        }
        public string Email
        {
            get { return txbEmail.Text.Trim(); }
            set { txbEmail.Text = value.Trim(); }
        }
        public string Phone
        {
            get { return txbPhone.Text.Trim(); }
            set { txbPhone.Text = value.Trim(); }
        }
        #endregion



        public EditarUsuario(ContactoModel contacto)
        {
            InitializeComponent();

            CloseCommand = new RelayCommand(() => this.Close());

            this.DataContext = this;

            id = contacto.id;
            Name = contacto.nombre;
            Position = contacto.posicion;
            Email = contacto.correo;
            Phone = contacto.telefono;
        }

        public ICommand CloseCommand { get; }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txbName.Text != "" && txbPosition.Text != "" && txbEmail.Text != "" && txbPhone.Text != "")
            {
                Name = txbName.Text.Trim();
                Position = txbPosition.Text.Trim();
                Email = txbEmail.Text.Trim();
                Phone = txbPhone.Text.Trim();

                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Todos los campos son necesrios");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
