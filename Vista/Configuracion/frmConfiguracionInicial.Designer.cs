using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Utilidades;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System;
using Vista.Comun;
using Vista.Seguridad;

namespace Vista.Configuracion
{
    partial class frmConfiguracionInicial
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
            _errores = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
            Text = "PlanillaRH - Configuración inicial";
            ClientSize = new Size(1000, 700);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Tema.Fondo;

            Label titulo = Ui.Etiqueta("Bienvenido a PlanillaRH", 30, 16, 940, true, "lblTitulo");
            titulo.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            titulo.ForeColor = Tema.PrimarioOscuro;
            titulo.Height = 36;
            Label sub = Ui.Etiqueta("Antes de comenzar, registre los datos de su empresa y cree el primer usuario administrador. Los campos con * son obligatorios.", 32, 54, 940, false, "lblSubtitulo");

            // ----- Tarjeta empresa -----
            PanelTarjeta empresa = new PanelTarjeta { Name = "pnlEmpresa", Location = new Point(24, 88), Size = new Size(470, 530) };
            Label t1 = Ui.Etiqueta("1. Datos de la empresa", 18, 14, 420, true, "lblEmpresaTitulo");
            t1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtEmpresa = Ui.Caja("txtEmpresa", 18, 66, 430, 150, ModoEntrada.Alfanumerico);
            txtNit = new CajaTexto { Name = "txtNit", Location = new Point(18, 126), Size = new Size(205, 28), Mascara = "####-######-###-#", MaxLength = 17 };
            txtNrc = Ui.Caja("txtNrc", 243, 126, 205, 9, ModoEntrada.Libre);
            txtNrc.Mascara = "";
            txtNrc.Modo = ModoEntrada.Libre;
            txtDireccion = Ui.Caja("txtDireccion", 18, 186, 430, 250, ModoEntrada.Libre);
            txtTelefono = new CajaTexto { Name = "txtTelefono", Location = new Point(18, 246), Size = new Size(205, 28), Mascara = "####-####", MaxLength = 9 };
            txtCorreoEmpresa = Ui.Caja("txtCorreoEmpresa", 243, 246, 205, 100, ModoEntrada.Correo);
            picLogo = new PictureBox { Name = "picLogo", Location = new Point(18, 322), Size = new Size(120, 120), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.FromArgb(248, 249, 251) };
            btnLogo = Ui.Boton("btnLogo", "Elegir logotipo", Tema.PrimarioOscuro, 150, 340, 160, 34);
            btnQuitarLogo = Ui.Boton("btnQuitarLogo", "Quitar", Tema.Neutro, 320, 340, 100, 34);
            Label ayudaLogo = Ui.Etiqueta("Imagen PNG o JPG de hasta 1 MB. Es opcional.", 150, 384, 300, false, "lblAyudaLogo");
            ayudaLogo.Height = 40;
            empresa.Controls.AddRange(new Control[]
            {
                t1, Ui.Etiqueta("Nombre de la empresa *", 18, 42), txtEmpresa, Ui.Etiqueta("NIT", 18, 102), txtNit, Ui.Etiqueta("NRC", 243, 102), txtNrc,
                Ui.Etiqueta("Dirección", 18, 162), txtDireccion, Ui.Etiqueta("Teléfono", 18, 222), txtTelefono, Ui.Etiqueta("Correo de la empresa", 243, 222),
                txtCorreoEmpresa, Ui.Etiqueta("Logotipo", 18, 298), picLogo, btnLogo, btnQuitarLogo, ayudaLogo
            });

            // ----- Tarjeta administrador -----
            PanelTarjeta admin = new PanelTarjeta { Name = "pnlAdmin", Location = new Point(506, 88), Size = new Size(470, 530) };
            Label t2 = Ui.Etiqueta("2. Primer usuario administrador", 18, 14, 420, true, "lblAdminTitulo");
            t2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            txtNombreAdmin = Ui.Caja("txtNombreAdmin", 18, 66, 430, 160, ModoEntrada.Letras);
            txtUsuario = Ui.Caja("txtUsuario", 18, 126, 205, 30, ModoEntrada.Usuario);
            txtCorreoAdmin = Ui.Caja("txtCorreoAdmin", 243, 126, 205, 100, ModoEntrada.Correo);
            txtContrasena = Ui.Caja("txtContrasena", 18, 186, 205, 30, ModoEntrada.Libre, true);
            txtConfirmar = Ui.Caja("txtConfirmar", 243, 186, 205, 30, ModoEntrada.Libre, true);
            cmbPregunta = Ui.Combo("cmbPregunta", 18, 246, 430);
            cmbPregunta.Items.AddRange(frmUsuarios.Preguntas);
            txtRespuesta = Ui.Caja("txtRespuesta", 18, 306, 430, 60, ModoEntrada.Libre);
            Label nota = Ui.Etiqueta("La contraseña debe tener de 8 a 30 caracteres con mayúscula, minúscula, número y símbolo. Se guarda cifrada con BCrypt. La pregunta de seguridad permite recuperar el acceso si olvida la contraseña.", 18, 350, 430, false, "lblNota");
            nota.Height = 80;
            admin.Controls.AddRange(new Control[]
            {
                t2, Ui.Etiqueta("Nombre completo *", 18, 42), txtNombreAdmin, Ui.Etiqueta("Usuario *", 18, 102), txtUsuario, Ui.Etiqueta("Correo electrónico", 243, 102), txtCorreoAdmin,
                Ui.Etiqueta("Contraseña *", 18, 162), txtContrasena, Ui.Etiqueta("Confirmar contraseña *", 243, 162), txtConfirmar,
                Ui.Etiqueta("Pregunta de seguridad *", 18, 222), cmbPregunta, Ui.Etiqueta("Respuesta de seguridad *", 18, 282), txtRespuesta, nota
            });

            btnGuardar = Ui.Boton("btnGuardar", "Guardar configuración y comenzar", Tema.Primario, 506, 634, 300, 44);
            btnSalir = Ui.Boton("btnSalir", "Salir del sistema", Tema.Neutro, 820, 634, 156, 44);

            int i = 0;
            foreach (Control c in new Control[] { txtEmpresa, txtNit, txtNrc, txtDireccion, txtTelefono, txtCorreoEmpresa, btnLogo, btnQuitarLogo,
                                                  txtNombreAdmin, txtUsuario, txtCorreoAdmin, txtContrasena, txtConfirmar, cmbPregunta, txtRespuesta, btnGuardar, btnSalir })
                c.TabIndex = i++;

            Controls.AddRange(new Control[] { titulo, sub, empresa, admin, btnGuardar, btnSalir });

            tip.SetToolTip(txtEmpresa, "Razón social o nombre comercial; aparece en las boletas de pago y reportes.");
            tip.SetToolTip(txtNit, "NIT de la empresa: 14 dígitos, los guiones se colocan solos.");
            tip.SetToolTip(txtNrc, "Número de registro de contribuyente (opcional).");
            tip.SetToolTip(txtDireccion, "Dirección de la empresa (opcional).");
            tip.SetToolTip(txtTelefono, "8 dígitos; debe iniciar con 2, 6 o 7.");
            tip.SetToolTip(txtCorreoEmpresa, "Correo de contacto de la empresa (opcional).");
            tip.SetToolTip(btnLogo, "Selecciona la imagen del logotipo de la empresa.");
            tip.SetToolTip(btnQuitarLogo, "Quita el logotipo seleccionado.");
            tip.SetToolTip(txtNombreAdmin, "Nombre y apellidos del administrador (solo letras).");
            tip.SetToolTip(txtUsuario, "Usuario para iniciar sesión: 4 a 30 caracteres, inicia con letra.");
            tip.SetToolTip(txtCorreoAdmin, "Correo del administrador (opcional).");
            tip.SetToolTip(txtContrasena, "Contraseña segura: 8 a 30 caracteres con mayúscula, minúscula, número y símbolo.");
            tip.SetToolTip(txtConfirmar, "Repita la contraseña.");
            tip.SetToolTip(cmbPregunta, "Pregunta que se usará para recuperar la contraseña.");
            tip.SetToolTip(txtRespuesta, "Respuesta a la pregunta de seguridad (no distingue mayúsculas).");
            tip.SetToolTip(btnGuardar, "Guarda los datos de la empresa y crea el usuario administrador.");
            tip.SetToolTip(btnSalir, "Cierra la aplicación sin configurar.");

            btnLogo.Click += btnLogo_Click;
            btnQuitarLogo.Click += (s, e) => { _logo = null; picLogo.Image = null; };
            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        #endregion

        private CajaTexto txtEmpresa, txtNit, txtNrc, txtDireccion, txtTelefono, txtCorreoEmpresa;
        private CajaTexto txtNombreAdmin, txtUsuario, txtCorreoAdmin, txtContrasena, txtConfirmar, txtRespuesta;
        private ComboBox cmbPregunta;
        private PictureBox picLogo;
        private BotonModerno btnLogo, btnQuitarLogo, btnGuardar, btnSalir;
        private ToolTip tip;
        private ErrorProvider _errores;
    }
}
