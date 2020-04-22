namespace CapaPresentacion.GestionNegocio
{
    partial class FrmCargo
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
            this.btnDesautorizar = new System.Windows.Forms.Button();
            this.btnAutorizar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnInactivo = new System.Windows.Forms.RadioButton();
            this.rbtnActivo = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRegistrado = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAutorizado = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Franklin Gothic Book", 12F);
            this.tabControl1.Location = new System.Drawing.Point(9, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 467);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.tabPage1.Controls.Add(this.btnDesautorizar);
            this.tabPage1.Controls.Add(this.btnAutorizar);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.dataListado);
            this.tabPage1.Controls.Add(this.txtBuscar);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            // 
            // btnDesautorizar
            // 
            this.btnDesautorizar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnDesautorizar.Location = new System.Drawing.Point(400, 395);
            this.btnDesautorizar.Name = "btnDesautorizar";
            this.btnDesautorizar.Size = new System.Drawing.Size(180, 35);
            this.btnDesautorizar.TabIndex = 19;
            this.btnDesautorizar.Text = "Desautorizar";
            this.btnDesautorizar.UseVisualStyleBackColor = true;
            this.btnDesautorizar.Click += new System.EventHandler(this.btnDesautorizar_Click);
            // 
            // btnAutorizar
            // 
            this.btnAutorizar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnAutorizar.Location = new System.Drawing.Point(180, 395);
            this.btnAutorizar.Name = "btnAutorizar";
            this.btnAutorizar.Size = new System.Drawing.Size(180, 35);
            this.btnAutorizar.TabIndex = 18;
            this.btnAutorizar.Text = "Autorizar";
            this.btnAutorizar.UseVisualStyleBackColor = true;
            this.btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.xmag_search_find_export_locate_59842;
            this.btnBuscar.Location = new System.Drawing.Point(381, 66);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(50, 40);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnInactivo);
            this.groupBox1.Controls.Add(this.rbtnActivo);
            this.groupBox1.Controls.Add(this.rbtnTodos);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(501, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 120);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro por Estado";
            // 
            // rbtnInactivo
            // 
            this.rbtnInactivo.AutoSize = true;
            this.rbtnInactivo.Location = new System.Drawing.Point(20, 90);
            this.rbtnInactivo.Name = "rbtnInactivo";
            this.rbtnInactivo.Size = new System.Drawing.Size(87, 25);
            this.rbtnInactivo.TabIndex = 6;
            this.rbtnInactivo.TabStop = true;
            this.rbtnInactivo.Text = "Inactivos";
            this.rbtnInactivo.UseVisualStyleBackColor = true;
            this.rbtnInactivo.CheckedChanged += new System.EventHandler(this.rbtnInactivo_CheckedChanged);
            // 
            // rbtnActivo
            // 
            this.rbtnActivo.AutoSize = true;
            this.rbtnActivo.Location = new System.Drawing.Point(20, 60);
            this.rbtnActivo.Name = "rbtnActivo";
            this.rbtnActivo.Size = new System.Drawing.Size(75, 25);
            this.rbtnActivo.TabIndex = 5;
            this.rbtnActivo.TabStop = true;
            this.rbtnActivo.Text = "Activos";
            this.rbtnActivo.UseVisualStyleBackColor = true;
            this.rbtnActivo.CheckedChanged += new System.EventHandler(this.rbtnActivo_CheckedChanged);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(20, 30);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(68, 25);
            this.rbtnTodos.TabIndex = 4;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(31, 116);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 21);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "Total";
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Location = new System.Drawing.Point(16, 146);
            this.dataListado.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.RowTemplate.Height = 24;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(750, 240);
            this.dataListado.TabIndex = 14;
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListado_CellContentClick);
            this.dataListado.DoubleClick += new System.EventHandler(this.dataListado_DoubleClick);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(118, 71);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(247, 26);
            this.txtBuscar.TabIndex = 13;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nombre:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.tabPage2.Controls.Add(this.txtAutorizado);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.cbEstado);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtRegistrado);
            this.tabPage2.Controls.Add(this.txtDescripcion);
            this.tabPage2.Controls.Add(this.txtNombre);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.MenuVertical);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(782, 433);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(250, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 21);
            this.label7.TabIndex = 69;
            this.label7.Text = "Datos del Cargo";
            // 
            // txtRegistrado
            // 
            this.txtRegistrado.Enabled = false;
            this.txtRegistrado.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtRegistrado.Location = new System.Drawing.Point(400, 235);
            this.txtRegistrado.Name = "txtRegistrado";
            this.txtRegistrado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRegistrado.Size = new System.Drawing.Size(280, 27);
            this.txtRegistrado.TabIndex = 67;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtDescripcion.Location = new System.Drawing.Point(400, 130);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(280, 80);
            this.txtDescripcion.TabIndex = 66;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtNombre.Location = new System.Drawing.Point(400, 80);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(280, 27);
            this.txtNombre.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(250, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 21);
            this.label5.TabIndex = 63;
            this.label5.Text = "Registrado Por:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(250, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 21);
            this.label4.TabIndex = 61;
            this.label4.Text = "Descripción:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(250, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 21);
            this.label3.TabIndex = 60;
            this.label3.Text = "Nombre:";
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(69)))), ((int)(((byte)(118)))));
            this.MenuVertical.Controls.Add(this.btnSalir);
            this.MenuVertical.Controls.Add(this.label14);
            this.MenuVertical.Controls.Add(this.btnMenu);
            this.MenuVertical.Controls.Add(this.btnDeshacer);
            this.MenuVertical.Controls.Add(this.btnEditar);
            this.MenuVertical.Controls.Add(this.btnGuardar);
            this.MenuVertical.Controls.Add(this.btnNuevo);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(3, 3);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(181, 427);
            this.MenuVertical.TabIndex = 59;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(69)))), ((int)(((byte)(118)))));
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnSalir.FlatAppearance.BorderSize = 2;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSalir.Image = global::CapaPresentacion.Properties.Resources.cancel;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(22, 315);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(153, 42);
            this.btnSalir.TabIndex = 22;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(31, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 28);
            this.label14.TabIndex = 17;
            this.label14.Text = "Acciones";
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(16, 427);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMenu.TabIndex = 15;
            this.btnMenu.TabStop = false;
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(69)))), ((int)(((byte)(118)))));
            this.btnDeshacer.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDeshacer.FlatAppearance.BorderSize = 2;
            this.btnDeshacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeshacer.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnDeshacer.ForeColor = System.Drawing.Color.White;
            this.btnDeshacer.Image = global::CapaPresentacion.Properties.Resources.undo;
            this.btnDeshacer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeshacer.Location = new System.Drawing.Point(22, 255);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(153, 42);
            this.btnDeshacer.TabIndex = 14;
            this.btnDeshacer.Text = "    Deshacer";
            this.btnDeshacer.UseVisualStyleBackColor = false;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(69)))), ((int)(((byte)(118)))));
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnEditar.FlatAppearance.BorderSize = 2;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.document;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(22, 195);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(153, 42);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "    Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(69)))), ((int)(((byte)(118)))));
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.savedisk_floppydisk_guardar_1543;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(22, 135);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(153, 42);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "    Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.FlatAppearance.BorderSize = 2;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.Window;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.New_File_36861;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(22, 75);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(153, 42);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "    Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(335, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 39);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cargos";
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(254, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 21);
            this.label6.TabIndex = 70;
            this.label6.Text = "Estado:";
            // 
            // cbEstado
            // 
            this.cbEstado.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbEstado.Location = new System.Drawing.Point(400, 285);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(200, 29);
            this.cbEstado.TabIndex = 71;
            this.cbEstado.Text = "-Seleccione un Estado-";
            this.cbEstado.SelectedIndexChanged += new System.EventHandler(this.cbEstado_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(254, 335);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 21);
            this.label13.TabIndex = 72;
            this.label13.Text = "Autorizado Por:";
            // 
            // txtAutorizado
            // 
            this.txtAutorizado.Enabled = false;
            this.txtAutorizado.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtAutorizado.Location = new System.Drawing.Point(400, 335);
            this.txtAutorizado.Name = "txtAutorizado";
            this.txtAutorizado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAutorizado.Size = new System.Drawing.Size(280, 27);
            this.txtAutorizado.TabIndex = 73;
            // 
            // FrmCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCargo";
            this.Text = "FrmCargo";
            this.Load += new System.EventHandler(this.FrmCargo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.MenuVertical.ResumeLayout(false);
            this.MenuVertical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnInactivo;
        private System.Windows.Forms.RadioButton rbtnActivo;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtRegistrado;
        private System.Windows.Forms.Button btnDesautorizar;
        private System.Windows.Forms.Button btnAutorizar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbEstado;
        public System.Windows.Forms.TextBox txtAutorizado;
        private System.Windows.Forms.Label label13;
    }
}