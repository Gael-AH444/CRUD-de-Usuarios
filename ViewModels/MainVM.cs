using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using UIDesign.Connector;
using UIDesign.Core;
using UIDesign.Model;
using UIDesign.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UIDesign.ViewModels
{
    public class MainVM : Implementaciones
    {
        /// <summary>
        /// ---ATRIBUTOS/ PROPIEDADES---
        /// Atributos para los TextBox
        /// </summary> 

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; OnPropertyChanged("Nombre"); }
        }

        private string _posicion;
        public string Posicion
        {
            get { return _posicion; }
            set { _posicion = value; OnPropertyChanged("Posicion"); }
        }

        private string _correo;
        public string Correo
        {
            get { return _correo; }
            set { _correo = value; OnPropertyChanged("Correo"); }
        }

        private string _telefono;
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; OnPropertyChanged("Telefono"); }
        }


        //Atributo para llenar el DG
        private ObservableCollection<ContactoModel> _contactos;
        public ObservableCollection<ContactoModel> Contactos
        {
            get => _contactos;
            set
            {
                _contactos = value;
                OnPropertyChanged(nameof(Contactos));
            }
        }


        //ICommand / Accion para limpiar los campos 
        private ICommand _limpiarCamposCommand;
        public ICommand LimpiarCamposCommand
        {
            get
            {
                if (_limpiarCamposCommand == null)
                    _limpiarCamposCommand = new RelayCommand(new Action(LimpiarCampos));
                return _limpiarCamposCommand;
            }
        }

        //Atributo para la seleccion de un item en el DG
        private ContactoModel _selectedContact;
        public ContactoModel SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value; OnPropertyChanged("SelectedContact"); }
        }

        //ICommand / Accion para agregar un nuevo usuario
        private ICommand _agregarContactoCommand;
        public ICommand AgregarContactoCommand
        {
            get
            {
                if (_agregarContactoCommand == null)
                    _agregarContactoCommand = new RelayCommand(new Action(AgregarContacto));
                return _agregarContactoCommand;
            }
        }

        //ICommand / Accion que para eliminar un registro
        private ICommand _eliminarPersona2Command;
        public ICommand EliminarPersona2Command
        {
            get
            {
                if (_eliminarPersona2Command == null)
                    _eliminarPersona2Command = new ParamCommand(new Action<object>(Eliminar2Persona));
                return _eliminarPersona2Command;
            }
        }

        //ICommand / Accion que para editar un registro
        private ICommand _editarPersonaCommand;
        public ICommand EditarPersonaCommand
        {
            get
            {
                if (_editarPersonaCommand == null)
                    _editarPersonaCommand = new RelayCommand(new Action(EditarPersona));
                return _editarPersonaCommand;
            }
        }



        //---CONSTRUSCTOR---
        public MainVM()
        {
            Contactos = MainData.ListarContactos();
        }



        /// <summary>
        /// ---*METODOS*---
        /// </summary>
        //Metodo para limpiar campos
        private void LimpiarCampos()
        {
            Nombre = string.Empty; Posicion = string.Empty; Correo = string.Empty; Telefono = string.Empty;
            var id = Id.ToString();
            id = string.Empty;
        }

        //Metodo para agregar un contacto nuevo
        private void AgregarContacto()
        {
            if (Nombre != null && Correo != null && Posicion != null && Telefono != null)
            {
                MainData.GuardarContacto(Nombre, Posicion, Correo, Telefono);

                Nombre = string.Empty; Posicion = string.Empty; Correo = string.Empty; Telefono = string.Empty;

                Contactos = MainData.ListarContactos();
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios");
            }
        }

        //Metodo para eliminar contacto
        private void Eliminar2Persona(object obj)
        {
            if (obj != null)
            {
                var res = MessageBox.Show($"Estas seguro que quieres eliminar a {SelectedContact.nombre}?", "Warning", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    MainData.Eliminar(SelectedContact.id);

                    Contactos = MainData.ListarContactos();
                }
                else
                {
                    return;
                }
            }
        }

        //Metodo para editar un registro
        private void EditarPersona()
        {
            Background bg = new Background();
            var dialog = new EditarUsuario(SelectedContact);
            bg.WindowState = WindowState.Maximized;
            bg.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            bg.Show();
            dialog.Owner = bg;
            if (dialog.ShowDialog().Value)
            {
                MainData.EditarContacto(dialog.id, dialog.Name, dialog.Position, dialog.Email, dialog.Phone);

                Contactos = MainData.ListarContactos();
            }
            bg.Close();
        }
    }
}
