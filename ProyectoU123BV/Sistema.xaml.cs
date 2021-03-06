using Microsoft.EntityFrameworkCore;
using ProyectoU123BV.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProyectoU123BV.Modelo;

namespace ProyectoU123BV
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
           public List<Roles> Roles { get; set; }
        public Sistema()
        {
            InitializeComponent();
            GetUsers();
            GetRoles();
        }
          



        private void GetUsers()
        {
            //ProductDG.ItemsSource = context.Products.ToList();

            using (var _context = new AplicationdbContext())
            {
                UserTable.ItemsSource = _context.Usuarios.ToList();

            }

          

        }



        public void GetRoles()
        {

            using (var _context = new AplicationdbContext())
            {
                var rol = _context.Roles.ToList();

                Roles = rol;


            }

            SelectRol.ItemsSource = Roles;
            //SelectRol.DisplayMemberPath = "Nombre";

        }

        private void SelectItem(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario = (sender as FrameworkElement).DataContext as Usuario;

                txtId.Text = usuario.Id.ToString();
                txtNombre.Text = usuario.Nombre.ToString();
                txtUser.Text = usuario.User.ToString();
                txtPassword.Text = usuario.Password.ToString();
           

            }
            catch (Exception ex)
            {

                throw new Exception ("Error interno: "+ ex.Message);
            }

        }

        private void Button_Editar(object sender, RoutedEventArgs e)
        {
            try
            {

                Usuario user = new Usuario();

                if (txtId.Text == "")
                {
                    using (var _context = new AplicationdbContext())
                    {
                        user.Nombre = txtNombre.Text;
                        user.User = txtUser.Text;
                        user.Password = txtPassword.Text;
                        



                        _context.Usuarios.Add(user);
                        _context.SaveChanges();

                    }

                    GetUsers();

                }
                else
                {


                    user.Id = int.Parse(txtId.Text);

                    using (var _context = new AplicationdbContext())
                    {
                        user = _context.Usuarios.Find(user.Id);
                        user.Nombre = txtNombre.Text;
                        user.User = txtUser.Text;
                        user.Password = txtPassword.Text;

                        _context.Entry(user).State = EntityState.Modified;
                        _context.SaveChanges();




                    }

                    GetUsers();
                }





            }
            catch (Exception ex )
            {

                throw new Exception("Error interno"+ex.Message);
            }

        }
    }
}
