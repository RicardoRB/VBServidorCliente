<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_Cliente
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fm_Cliente))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbPedidosPendientes = New System.Windows.Forms.Label()
        Me.btn_Borrar = New System.Windows.Forms.Button()
        Me.dg_Articulos = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Confirmar = New System.Windows.Forms.Button()
        Me.btn_Cesta = New System.Windows.Forms.Button()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Lista_Productos = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dg_Pedidos = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dg_Bancarios = New System.Windows.Forms.DataGridView()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dg_Stock = New System.Windows.Forms.DataGridView()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_NumFactura = New System.Windows.Forms.TextBox()
        Me.btn_Prestamo = New System.Windows.Forms.Button()
        Me.txt_Abono = New System.Windows.Forms.TextBox()
        Me.cb_Empresa = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dg_Articulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.dg_Pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_Bancarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_Stock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(795, 421)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.lbPedidosPendientes)
        Me.TabPage1.Controls.Add(Me.btn_Borrar)
        Me.TabPage1.Controls.Add(Me.dg_Articulos)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.btn_Confirmar)
        Me.TabPage1.Controls.Add(Me.btn_Cesta)
        Me.TabPage1.Controls.Add(Me.cmb_proveedor)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Lista_Productos)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(787, 395)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Comprar Productos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(554, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(167, 18)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Pedidos Pendientes: "
        '
        'lbPedidosPendientes
        '
        Me.lbPedidosPendientes.AutoSize = True
        Me.lbPedidosPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lbPedidosPendientes.Location = New System.Drawing.Point(727, 17)
        Me.lbPedidosPendientes.Name = "lbPedidosPendientes"
        Me.lbPedidosPendientes.Size = New System.Drawing.Size(17, 18)
        Me.lbPedidosPendientes.TabIndex = 35
        Me.lbPedidosPendientes.Text = "0"
        '
        'btn_Borrar
        '
        Me.btn_Borrar.Enabled = False
        Me.btn_Borrar.Image = CType(resources.GetObject("btn_Borrar.Image"), System.Drawing.Image)
        Me.btn_Borrar.Location = New System.Drawing.Point(643, 279)
        Me.btn_Borrar.Name = "btn_Borrar"
        Me.btn_Borrar.Size = New System.Drawing.Size(100, 90)
        Me.btn_Borrar.TabIndex = 28
        Me.btn_Borrar.Text = "Borrar Pedido"
        Me.btn_Borrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Borrar.UseVisualStyleBackColor = True
        '
        'dg_Articulos
        '
        Me.dg_Articulos.AllowUserToAddRows = False
        Me.dg_Articulos.AllowUserToDeleteRows = False
        Me.dg_Articulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Articulos.Location = New System.Drawing.Point(23, 66)
        Me.dg_Articulos.MultiSelect = False
        Me.dg_Articulos.Name = "dg_Articulos"
        Me.dg_Articulos.ReadOnly = True
        Me.dg_Articulos.Size = New System.Drawing.Size(363, 135)
        Me.dg_Articulos.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(20, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 17)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Articulos"
        '
        'btn_Confirmar
        '
        Me.btn_Confirmar.Enabled = False
        Me.btn_Confirmar.Image = CType(resources.GetObject("btn_Confirmar.Image"), System.Drawing.Image)
        Me.btn_Confirmar.Location = New System.Drawing.Point(643, 168)
        Me.btn_Confirmar.Name = "btn_Confirmar"
        Me.btn_Confirmar.Size = New System.Drawing.Size(100, 90)
        Me.btn_Confirmar.TabIndex = 27
        Me.btn_Confirmar.Text = "Confirmar Pedido"
        Me.btn_Confirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Confirmar.UseVisualStyleBackColor = True
        '
        'btn_Cesta
        '
        Me.btn_Cesta.Enabled = False
        Me.btn_Cesta.Image = CType(resources.GetObject("btn_Cesta.Image"), System.Drawing.Image)
        Me.btn_Cesta.Location = New System.Drawing.Point(643, 49)
        Me.btn_Cesta.Name = "btn_Cesta"
        Me.btn_Cesta.Size = New System.Drawing.Size(100, 90)
        Me.btn_Cesta.TabIndex = 25
        Me.btn_Cesta.Text = "Meter en la Cesta"
        Me.btn_Cesta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cesta.UseVisualStyleBackColor = True
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(115, 18)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(213, 21)
        Me.cmb_proveedor.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(20, 227)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 17)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Cesta"
        '
        'Lista_Productos
        '
        Me.Lista_Productos.Location = New System.Drawing.Point(23, 247)
        Me.Lista_Productos.Name = "Lista_Productos"
        Me.Lista_Productos.Size = New System.Drawing.Size(480, 122)
        Me.Lista_Productos.TabIndex = 32
        Me.Lista_Productos.UseCompatibleStateImageBehavior = False
        Me.Lista_Productos.View = System.Windows.Forms.View.List
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(20, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 18)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Proveedor"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(369, 41)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(300, 300)
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.dg_Pedidos)
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.PictureBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(787, 395)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Vender Productos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.dg_Bancarios)
        Me.TabPage3.Controls.Add(Me.PictureBox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(787, 395)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Gestion Bancaria"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.Label13)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.dg_Stock)
        Me.TabPage4.Controls.Add(Me.PictureBox4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(787, 395)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Gestión de Stocks"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label15)
        Me.TabPage5.Controls.Add(Me.Label16)
        Me.TabPage5.Controls.Add(Me.txt_NumFactura)
        Me.TabPage5.Controls.Add(Me.btn_Prestamo)
        Me.TabPage5.Controls.Add(Me.txt_Abono)
        Me.TabPage5.Controls.Add(Me.cb_Empresa)
        Me.TabPage5.Controls.Add(Me.Label17)
        Me.TabPage5.Controls.Add(Me.Label18)
        Me.TabPage5.Controls.Add(Me.Label19)
        Me.TabPage5.Controls.Add(Me.PictureBox5)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(787, 395)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Gestión Económica"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(746, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 18)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(573, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 18)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Pedidos Pendientes: "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(44, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 17)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Pedidos"
        '
        'dg_Pedidos
        '
        Me.dg_Pedidos.AllowUserToAddRows = False
        Me.dg_Pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Pedidos.Location = New System.Drawing.Point(47, 55)
        Me.dg_Pedidos.Name = "dg_Pedidos"
        Me.dg_Pedidos.ReadOnly = True
        Me.dg_Pedidos.Size = New System.Drawing.Size(447, 139)
        Me.dg_Pedidos.TabIndex = 32
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(47, 256)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(447, 123)
        Me.DataGridView1.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(44, 223)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 17)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Artículos"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(576, 157)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 83)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Confirmar Pedido"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(521, 209)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(242, 180)
        Me.PictureBox2.TabIndex = 34
        Me.PictureBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(761, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 18)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(588, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(167, 18)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Pedidos Pendientes: "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(264, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 17)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Datos Bancarios"
        '
        'dg_Bancarios
        '
        Me.dg_Bancarios.AllowUserToAddRows = False
        Me.dg_Bancarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Bancarios.Location = New System.Drawing.Point(6, 25)
        Me.dg_Bancarios.Name = "dg_Bancarios"
        Me.dg_Bancarios.ReadOnly = True
        Me.dg_Bancarios.Size = New System.Drawing.Size(775, 364)
        Me.dg_Bancarios.TabIndex = 27
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(278, 65)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(418, 273)
        Me.PictureBox3.TabIndex = 29
        Me.PictureBox3.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(745, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(17, 18)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(572, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(167, 18)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Pedidos Pendientes: "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(64, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(290, 17)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Artículos por debajo del límite de stock"
        '
        'dg_Stock
        '
        Me.dg_Stock.AllowUserToAddRows = False
        Me.dg_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Stock.Location = New System.Drawing.Point(71, 36)
        Me.dg_Stock.Name = "dg_Stock"
        Me.dg_Stock.ReadOnly = True
        Me.dg_Stock.Size = New System.Drawing.Size(367, 332)
        Me.dg_Stock.TabIndex = 27
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(418, 37)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(344, 343)
        Me.PictureBox4.TabIndex = 29
        Me.PictureBox4.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(729, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(17, 18)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(556, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(167, 18)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Pedidos Pendientes: "
        '
        'txt_NumFactura
        '
        Me.txt_NumFactura.Location = New System.Drawing.Point(317, 71)
        Me.txt_NumFactura.Name = "txt_NumFactura"
        Me.txt_NumFactura.Size = New System.Drawing.Size(187, 20)
        Me.txt_NumFactura.TabIndex = 29
        '
        'btn_Prestamo
        '
        Me.btn_Prestamo.Image = CType(resources.GetObject("btn_Prestamo.Image"), System.Drawing.Image)
        Me.btn_Prestamo.Location = New System.Drawing.Point(221, 164)
        Me.btn_Prestamo.Name = "btn_Prestamo"
        Me.btn_Prestamo.Size = New System.Drawing.Size(234, 72)
        Me.btn_Prestamo.TabIndex = 32
        Me.btn_Prestamo.Text = "Confirmar Prestamo"
        Me.btn_Prestamo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Prestamo.UseVisualStyleBackColor = True
        '
        'txt_Abono
        '
        Me.txt_Abono.Location = New System.Drawing.Point(317, 124)
        Me.txt_Abono.Name = "txt_Abono"
        Me.txt_Abono.Size = New System.Drawing.Size(187, 20)
        Me.txt_Abono.TabIndex = 31
        '
        'cb_Empresa
        '
        Me.cb_Empresa.AccessibleName = ""
        Me.cb_Empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Empresa.FormattingEnabled = True
        Me.cb_Empresa.Items.AddRange(New Object() {"BBVA", "La Caixa", "Santander", "Banesto", "Unicaja"})
        Me.cb_Empresa.Location = New System.Drawing.Point(317, 97)
        Me.cb_Empresa.Name = "cb_Empresa"
        Me.cb_Empresa.Size = New System.Drawing.Size(187, 21)
        Me.cb_Empresa.TabIndex = 30
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(164, 127)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 17)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Abono"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(164, 98)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 17)
        Me.Label18.TabIndex = 34
        Me.Label18.Text = "Empresa"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(164, 71)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(147, 17)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "Número de Factura"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(434, 130)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(289, 250)
        Me.PictureBox5.TabIndex = 36
        Me.PictureBox5.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 445)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Cliente"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dg_Articulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.dg_Pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_Bancarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_Stock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbPedidosPendientes As System.Windows.Forms.Label
    Friend WithEvents btn_Borrar As System.Windows.Forms.Button
    Friend WithEvents dg_Articulos As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Confirmar As System.Windows.Forms.Button
    Friend WithEvents btn_Cesta As System.Windows.Forms.Button
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Lista_Productos As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dg_Pedidos As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dg_Bancarios As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dg_Stock As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_NumFactura As System.Windows.Forms.TextBox
    Friend WithEvents btn_Prestamo As System.Windows.Forms.Button
    Friend WithEvents txt_Abono As System.Windows.Forms.TextBox
    Friend WithEvents cb_Empresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
End Class
