using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Modelos.Utilidades;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System;
using Vista.Comun;

namespace Vista.Seguridad
{
    partial class frmRoles
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
            errores = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
            Text = "Roles y permisos";
            BackColor = Tema.Fondo;
            ClientSize = new Size(1000, 640);

            Label titulo = new Label { Text = "Roles y permisos", Dock = DockStyle.Top, Height = 56, Padding = new Padding(20, 12, 0, 0), Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold), ForeColor = Tema.PrimarioOscuro };

            TableLayoutPanel raiz = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Padding = new Padding(14, 4, 14, 14) };
            raiz.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380));
            raiz.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // ----- Roles -----
            PanelTarjeta pnlRoles = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 8, 0), Name = "pnlRoles" };
            Label t1 = new Label { Text = "Roles", Dock = DockStyle.Top, Height = 30, Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold) };
            lstRoles = new ListBox { Name = "lstRoles", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11F), BorderStyle = BorderStyle.None, ItemHeight = 24, IntegralHeight = false };
            Panel pie = new Panel { Dock = DockStyle.Bottom, Height = 214 };
            txtNombre = Ui.Caja("txtNombre", 0, 22, 330, 50, ModoEntrada.Letras);
            txtDescripcion = Ui.Caja("txtDescripcion", 0, 80, 330, 200, ModoEntrada.Libre);
            btnNuevo = Ui.Boton("btnNuevoRol", "Nuevo", Tema.PrimarioOscuro, 0, 134, 96, 36);
            btnGuardarRol = Ui.Boton("btnGuardarRol", "Guardar rol", Tema.Primario, 102, 134, 124, 36);
            btnEliminarRol = Ui.Boton("btnEliminarRol", "Eliminar", Tema.Peligro, 232, 134, 98, 36);
            pie.Controls.AddRange(new Control[] { Ui.Etiqueta("Nombre del rol *", 0, 0), txtNombre, Ui.Etiqueta("Descripción", 0, 58), txtDescripcion, btnNuevo, btnGuardarRol, btnEliminarRol });
            pnlRoles.Controls.Add(lstRoles);
            pnlRoles.Controls.Add(pie);
            pnlRoles.Controls.Add(t1);

            // ----- Permisos -----
            PanelTarjeta pnlPermisos = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(8, 0, 0, 0), Name = "pnlPermisos" };
            lblPermisosTitulo = new Label { Text = "Permisos del rol seleccionado", Dock = DockStyle.Top, Height = 30, Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold) };
            lblDescripcionRol = new Label { Dock = DockStyle.Top, Height = 26, ForeColor = Tema.TextoSuave };
            clbPermisos = new CheckedListBox { Name = "clbPermisos", Dock = DockStyle.Fill, CheckOnClick = true, BorderStyle = BorderStyle.None, Font = new Font("Segoe UI", 10F), IntegralHeight = false, ItemHeight = 26 };
            Panel pie2 = new Panel { Dock = DockStyle.Bottom, Height = 54, Padding = new Padding(0, 10, 0, 0) };
            btnGuardarPermisos = new BotonModerno { Name = "btnGuardarPermisos", Text = "Guardar permisos", BackColor = Tema.Primario, Dock = DockStyle.Fill };
            btnMarcarTodos = new BotonModerno { Name = "btnMarcarTodos", Text = "Marcar / desmarcar todos", BackColor = Tema.Neutro, Dock = DockStyle.Left, Width = 210 };
            pie2.Controls.Add(btnGuardarPermisos);
            pie2.Controls.Add(new Panel { Dock = DockStyle.Left, Width = 8 });
            pie2.Controls.Add(btnMarcarTodos);
            pnlPermisos.Controls.Add(clbPermisos);
            pnlPermisos.Controls.Add(pie2);
            pnlPermisos.Controls.Add(lblDescripcionRol);
            pnlPermisos.Controls.Add(lblPermisosTitulo);

            raiz.Controls.Add(pnlRoles, 0, 0);
            raiz.Controls.Add(pnlPermisos, 1, 0);
            Controls.Add(raiz);
            Controls.Add(titulo);

            txtNombre.TabIndex = 0; txtDescripcion.TabIndex = 1; btnNuevo.TabIndex = 2; btnGuardarRol.TabIndex = 3; btnEliminarRol.TabIndex = 4;
            lstRoles.TabIndex = 5; clbPermisos.TabIndex = 6; btnMarcarTodos.TabIndex = 7; btnGuardarPermisos.TabIndex = 8;

            tip.SetToolTip(lstRoles, "Seleccione un rol para ver y modificar sus permisos.");
            tip.SetToolTip(txtNombre, "Nombre del rol (solo letras y espacios).");
            tip.SetToolTip(txtDescripcion, "Descripción breve de lo que hace el rol.");
            tip.SetToolTip(btnNuevo, "Prepara el formulario para crear un rol nuevo.");
            tip.SetToolTip(btnGuardarRol, "Guarda el rol nuevo o los cambios del rol seleccionado.");
            tip.SetToolTip(btnEliminarRol, "Elimina el rol seleccionado (no puede tener usuarios asignados).");
            tip.SetToolTip(clbPermisos, "Marque las acciones que podrá realizar el rol seleccionado.");
            tip.SetToolTip(btnMarcarTodos, "Marca todos los permisos o los desmarca si ya estaban todos marcados.");
            tip.SetToolTip(btnGuardarPermisos, "Guarda los permisos marcados para el rol seleccionado.");

            lstRoles.SelectedIndexChanged += lstRoles_SelectedIndexChanged;
            btnNuevo.Click += (s, e) => NuevoRol();
            btnGuardarRol.Click += btnGuardarRol_Click;
            btnEliminarRol.Click += btnEliminarRol_Click;
            btnMarcarTodos.Click += (s, e) =>
            {
                bool marcar = clbPermisos.CheckedItems.Count < clbPermisos.Items.Count;
                for (int i = 0; i < clbPermisos.Items.Count; i++) clbPermisos.SetItemChecked(i, marcar);
            };
            btnGuardarPermisos.Click += btnGuardarPermisos_Click;
        }

        #endregion

        private ListBox lstRoles;
        private CheckedListBox clbPermisos;
        private CajaTexto txtNombre, txtDescripcion;
        private BotonModerno btnNuevo, btnGuardarRol, btnEliminarRol, btnGuardarPermisos, btnMarcarTodos;
        private Label lblDescripcionRol, lblPermisosTitulo;
        private ToolTip tip;
        private ErrorProvider errores;
    }
}
