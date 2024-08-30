using System.Collections.ObjectModel;

namespace UIDesign.Images
{
    /// <summary>
    /// Se crea una nueva clase que extiende de OC, con la finalidad
    /// que esta se mande llamar cuando se quiera crear un objeto o referencia
    /// este tipo de colleciones "ObservableCollection<Persona>"
    /// </summary>
    //public class PersonaCollection : ObservableCollection<Persona>
    //{

    //}

    public class Persona : Implementaciones
    {
        #region Atributos / Propiedades
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("id"); }
        }


        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; OnPropertyChanged("nombre"); }
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
        #endregion

        ////---Constructores---
        //public Persona(int id, string name, string position, string email, string phone)
        //{
        //    ID = id;
        //    Name = name;
        //    Position = position;
        //    Email = email;
        //    Phone = phone;
        //}
    }
}
