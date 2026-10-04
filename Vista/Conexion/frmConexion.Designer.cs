using Modelos.Conexion_DB;
using Modelos.Utilidades;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using Vista.Comun;

namespace Vista.Conexion
{
    partial class frmConexion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            tip = new ToolTip();
            Text = "PlanillaRH - Conexión a SQL Server";
            ClientSize = new Size(640, 640);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;

            Label titulo = Ui.Etiqueta("Conexión a SQL Server", 30, 20, 560, true, "lblTitulo");
            titulo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            titulo.ForeColor = Tema.PrimarioOscuro;
            titulo.Height = 34;
            Label ayuda = Ui.Etiqueta("Indique el servidor donde se guardará la información. Si la base de datos aún no existe, el sistema la crea con todas sus tablas y datos iniciales.", 30, 58, 580, false, "lblAyuda");
            ayuda.Height = 40;

            txtServidor = new CajaTexto { Name = "txtServidor", Location = new Point(30, 124), Size = new Size(580, 28), MaxLength = 100 };
            rbWindows = new RadioButton { Name = "rbWindows", Text = "Autenticación de Windows", Location = new Point(30, 170), Size = new Size(240, 24), Checked = true };
            rbSql = new RadioButton { Name = "rbSql", Text = "Usuario y contraseña de SQL Server", Location = new Point(290, 170), Size = new Size(320, 24) };
            txtUsuario = new CajaTexto { Name = "txtUsuario", Location = new Point(30, 226), Size = new Size(280, 28), MaxLength = 50 };
            txtContrasena = new CajaTexto { Name = "txtContrasena", Location = new Point(330, 226), Size = new Size(280, 28), MaxLength = 50, UseSystemPasswordChar = true };
            txtBaseDatos = new CajaTexto { Name = "txtBaseDatos", Location = new Point(30, 292), Size = new Size(280, 28), MaxLength = 60, Modo = ModoEntrada.Usuario };

            btnProbar = Ui.Boton("btnProbar", "Probar conexión", Tema.PrimarioOscuro, 30, 342, 180);
            btnCrear = Ui.Boton("btnCrear", "Crear base de datos", Tema.Primario, 222, 342, 200);
            btnContinuar = Ui.Boton("btnContinuar", "Guardar y continuar", Tema.Primario, 434, 342, 176);
            btnSalir = Ui.Boton("btnSalir", "Salir del sistema", Tema.Neutro, 434, 584, 176, 34);
            lblEstado = Ui.Etiqueta("Sin probar", 30, 396, 580, true, "lblEstado");
            txtRegistro = new TextBox { Name = "txtRegistro", Location = new Point(30, 424), Size = new Size(580, 150), Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical, BackColor = Color.FromArgb(248, 249, 251), Font = new Font("Consolas", 9F) };

            txtServidor.TabIndex = 0; rbWindows.TabIndex = 1; rbSql.TabIndex = 2; txtUsuario.TabIndex = 3; txtContrasena.TabIndex = 4;
            txtBaseDatos.TabIndex = 5; btnProbar.TabIndex = 6; btnCrear.TabIndex = 7; btnContinuar.TabIndex = 8; btnSalir.TabIndex = 9;

            Controls.AddRange(new Control[]
            {
                titulo, ayuda, Ui.Etiqueta("Servidor o instancia  (ejemplos:  .\\SQLEXPRESS   (localdb)\\MSSQLLocalDB   192.168.1.10)", 30, 100, 580),
                txtServidor, rbWindows, rbSql, Ui.Etiqueta("Usuario de SQL Server", 30, 202), txtUsuario, Ui.Etiqueta("Contraseña", 330, 202), txtContrasena,
                Ui.Etiqueta("Nombre de la base de datos", 30, 268), txtBaseDatos, btnProbar, btnCrear, btnContinuar, lblEstado, txtRegistro, btnSalir
            });

            tip.SetToolTip(txtServidor, "Nombre del servidor o de la instancia de SQL Server.");
            tip.SetToolTip(rbWindows, "Usa la cuenta de Windows actual para conectarse.");
            tip.SetToolTip(rbSql, "Usa un usuario y contraseña definidos en SQL Server.");
            tip.SetToolTip(txtUsuario, "Usuario de SQL Server (por ejemplo sa).");
            tip.SetToolTip(txtContrasena, "Contraseña del usuario de SQL Server. Se guarda cifrada para su usuario de Windows.");
            tip.SetToolTip(txtBaseDatos, "Nombre de la base de datos del sistema (letras, números y guion bajo).");
            tip.SetToolTip(btnProbar, "Comprueba que el servidor responda y si la base de datos ya existe.");
            tip.SetToolTip(btnCrear, "Crea la base de datos con sus tablas, vistas, procedimientos, triggers y datos iniciales.");
            tip.SetToolTip(btnContinuar, "Guarda la conexión y abre el sistema.");
            tip.SetToolTip(btnSalir, "Cierra la aplicación.");

            rbWindows.CheckedChanged += (s, e) => AplicarModo();
            btnProbar.Click += btnProbar_Click;
            btnCrear.Click += btnCrear_Click;
            btnContinuar.Click += btnContinuar_Click;
            btnSalir.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        #endregion

        private TextBox txtServidor, txtBaseDatos, txtUsuario, txtContrasena;
        private RadioButton rbWindows, rbSql;
        private BotonModerno btnProbar, btnCrear, btnContinuar, btnSalir;
        private Label lblEstado;
        private TextBox txtRegistro;
        private ToolTip tip;
    }
}
