namespace CapaPresentacion
{
    partial class Frm_Cliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbTipoBusqueda = new System.Windows.Forms.ComboBox();
            this.tblCliente = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNumIdent = new System.Windows.Forms.TextBox();
            this.cmbTipoIdent = new System.Windows.Forms.ComboBox();
            this.dtFechaNac = new System.Windows.Forms.DateTimePicker();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblIdent = new System.Windows.Forms.Label();
            this.lblTipoIdent = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cmbTipoCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblAcciones = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btbCerrar = new System.Windows.Forms.Button();
            this.tltCliente = new System.Windows.Forms.ToolTip(this.components);
            this.errorIcon = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblCliente)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.tabControl1.Location = new System.Drawing.Point(2, 51);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(980, 497);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.cmbTipoBusqueda);
            this.tabPage1.Controls.Add(this.tblCliente);
            this.tabPage1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(972, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(11, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buscar por:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.xmag_search_find_export_locate_5984;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(347, 107);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(153, 42);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 26);
            this.textBox1.TabIndex = 2;
            // 
            // cmbTipoBusqueda
            // 
            this.cmbTipoBusqueda.FormattingEnabled = true;
            this.cmbTipoBusqueda.Items.AddRange(new object[] {
            "Identifacación",
            "Apellidos"});
            this.cmbTipoBusqueda.Location = new System.Drawing.Point(112, 87);
            this.cmbTipoBusqueda.Name = "cmbTipoBusqueda";
            this.cmbTipoBusqueda.Size = new System.Drawing.Size(208, 28);
            this.cmbTipoBusqueda.TabIndex = 1;
            // 
            // tblCliente
            // 
            this.tblCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblCliente.Location = new System.Drawing.Point(15, 182);
            this.tblCliente.Name = "tblCliente";
            this.tblCliente.Size = new System.Drawing.Size(950, 270);
            this.tblCliente.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.tabPage2.Controls.Add(this.txtCorreo);
            this.tabPage2.Controls.Add(this.txtTelefono);
            this.tabPage2.Controls.Add(this.txtDireccion);
            this.tabPage2.Controls.Add(this.txtNumIdent);
            this.tabPage2.Controls.Add(this.cmbTipoIdent);
            this.tabPage2.Controls.Add(this.dtFechaNac);
            this.tabPage2.Controls.Add(this.cmbGenero);
            this.tabPage2.Controls.Add(this.txtApellido);
            this.tabPage2.Controls.Add(this.txtNombre);
            this.tabPage2.Controls.Add(this.lblCorreo);
            this.tabPage2.Controls.Add(this.lblTelefono);
            this.tabPage2.Controls.Add(this.lblDireccion);
            this.tabPage2.Controls.Add(this.lblIdent);
            this.tabPage2.Controls.Add(this.lblTipoIdent);
            this.tabPage2.Controls.Add(this.lblFecha);
            this.tabPage2.Controls.Add(this.lblGenero);
            this.tabPage2.Controls.Add(this.lblApellido);
            this.tabPage2.Controls.Add(this.lblNombre);
            this.tabPage2.Controls.Add(this.cmbTipoCliente);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(972, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(401, 420);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(361, 27);
            this.txtCorreo.TabIndex = 21;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(401, 380);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(140, 27);
            this.txtTelefono.TabIndex = 20;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(401, 310);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(361, 60);
            this.txtDireccion.TabIndex = 19;
            // 
            // txtNumIdent
            // 
            this.txtNumIdent.Location = new System.Drawing.Point(401, 270);
            this.txtNumIdent.Name = "txtNumIdent";
            this.txtNumIdent.Size = new System.Drawing.Size(140, 27);
            this.txtNumIdent.TabIndex = 18;
            // 
            // cmbTipoIdent
            // 
            this.cmbTipoIdent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIdent.FormattingEnabled = true;
            this.cmbTipoIdent.Items.AddRange(new object[] {
            "RUC",
            "Cédula",
            "Pasaporte"});
            this.cmbTipoIdent.Location = new System.Drawing.Point(401, 230);
            this.cmbTipoIdent.Name = "cmbTipoIdent";
            this.cmbTipoIdent.Size = new System.Drawing.Size(140, 29);
            this.cmbTipoIdent.TabIndex = 17;
            // 
            // dtFechaNac
            // 
            this.dtFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaNac.Location = new System.Drawing.Point(401, 190);
            this.dtFechaNac.Name = "dtFechaNac";
            this.dtFechaNac.Size = new System.Drawing.Size(140, 27);
            this.dtFechaNac.TabIndex = 16;
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Femenino",
            "Másculino",
            "Neutro"});
            this.cmbGenero.Location = new System.Drawing.Point(401, 142);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(140, 29);
            this.cmbGenero.TabIndex = 15;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(401, 101);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(361, 27);
            this.txtApellido.TabIndex = 14;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(401, 62);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(361, 27);
            this.txtNombre.TabIndex = 13;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCorreo.Location = new System.Drawing.Point(224, 420);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(60, 21);
            this.lblCorreo.TabIndex = 12;
            this.lblCorreo.Text = "E-Mail:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTelefono.Location = new System.Drawing.Point(224, 380);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(80, 21);
            this.lblTelefono.TabIndex = 11;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDireccion.Location = new System.Drawing.Point(224, 310);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(97, 21);
            this.lblDireccion.TabIndex = 10;
            this.lblDireccion.Text = "Direccción:";
            // 
            // lblIdent
            // 
            this.lblIdent.AutoSize = true;
            this.lblIdent.ForeColor = System.Drawing.SystemColors.Control;
            this.lblIdent.Location = new System.Drawing.Point(224, 270);
            this.lblIdent.Name = "lblIdent";
            this.lblIdent.Size = new System.Drawing.Size(163, 21);
            this.lblIdent.TabIndex = 9;
            this.lblIdent.Text = "# de Identificación:";
            // 
            // lblTipoIdent
            // 
            this.lblTipoIdent.AutoSize = true;
            this.lblTipoIdent.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTipoIdent.Location = new System.Drawing.Point(224, 230);
            this.lblTipoIdent.Name = "lblTipoIdent";
            this.lblTipoIdent.Size = new System.Drawing.Size(179, 21);
            this.lblTipoIdent.TabIndex = 8;
            this.lblTipoIdent.Text = "Tipo de Identificación";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFecha.Location = new System.Drawing.Point(224, 190);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(158, 21);
            this.lblFecha.TabIndex = 7;
            this.lblFecha.Text = "Fecha Nacimiento:";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.ForeColor = System.Drawing.SystemColors.Control;
            this.lblGenero.Location = new System.Drawing.Point(224, 150);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(73, 21);
            this.lblGenero.TabIndex = 6;
            this.lblGenero.Text = "Género:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.ForeColor = System.Drawing.SystemColors.Control;
            this.lblApellido.Location = new System.Drawing.Point(224, 110);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(78, 21);
            this.lblApellido.TabIndex = 5;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNombre.Location = new System.Drawing.Point(224, 70);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(77, 21);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            // 
            // cmbTipoCliente
            // 
            this.cmbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCliente.FormattingEnabled = true;
            this.cmbTipoCliente.Items.AddRange(new object[] {
            "Jurídico",
            "Natural"});
            this.cmbTipoCliente.Location = new System.Drawing.Point(401, 22);
            this.cmbTipoCliente.Name = "cmbTipoCliente";
            this.cmbTipoCliente.Size = new System.Drawing.Size(208, 29);
            this.cmbTipoCliente.TabIndex = 3;
            this.cmbTipoCliente.SelectedIndexChanged += new System.EventHandler(this.cmbTipoCliente_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(224, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo de Cliente";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(69)))), ((int)(((byte)(118)))));
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnDeshacer);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.lblAcciones);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(19, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 455);
            this.panel1.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(14, 316);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(153, 42);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "    Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeshacer.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDeshacer.Image = global::CapaPresentacion.Properties.Resources.undo1;
            this.btnDeshacer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeshacer.Location = new System.Drawing.Point(14, 256);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(153, 42);
            this.btnDeshacer.TabIndex = 5;
            this.btnDeshacer.Text = "     Deshacer";
            this.btnDeshacer.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.note_edit_12872;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(14, 196);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(153, 42);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "     Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.savedisk_floppydisk_guardar_15431;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(16, 136);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(153, 42);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "     Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.New_File_36861;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(16, 76);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(153, 42);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "    Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblAcciones
            // 
            this.lblAcciones.AutoSize = true;
            this.lblAcciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAcciones.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.lblAcciones.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAcciones.Location = new System.Drawing.Point(31, 18);
            this.lblAcciones.Name = "lblAcciones";
            this.lblAcciones.Size = new System.Drawing.Size(121, 28);
            this.lblAcciones.TabIndex = 2;
            this.lblAcciones.Text = "Acciones";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 455);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(460, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(127, 39);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Cliente";
            // 
            // btbCerrar
            // 
            this.btbCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btbCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btbCerrar.Image = global::CapaPresentacion.Properties.Resources.cerrar;
            this.btbCerrar.Location = new System.Drawing.Point(948, 12);
            this.btbCerrar.Name = "btbCerrar";
            this.btbCerrar.Size = new System.Drawing.Size(27, 26);
            this.btbCerrar.TabIndex = 13;
            this.btbCerrar.UseVisualStyleBackColor = true;
            this.btbCerrar.Click += new System.EventHandler(this.btbCerrar_Click);
            // 
            // errorIcon
            // 
            this.errorIcon.ContainerControl = this;
            // 
            // Frm_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(987, 554);
            this.Controls.Add(this.btbCerrar);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Franklin Gothic Book", 10.2F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(74)))), ((int)(((byte)(165)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Cliente";
            this.Load += new System.EventHandler(this.Frm_Cliente_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblCliente)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAcciones;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoCliente;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblIdent;
        private System.Windows.Forms.Label lblTipoIdent;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNumIdent;
        private System.Windows.Forms.ComboBox cmbTipoIdent;
        private System.Windows.Forms.DateTimePicker dtFechaNac;
        private System.Windows.Forms.Button btbCerrar;
        private System.Windows.Forms.ToolTip tltCliente;
        private System.Windows.Forms.ErrorProvider errorIcon;
        private System.Windows.Forms.DataGridView tblCliente;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbTipoBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
    }
}