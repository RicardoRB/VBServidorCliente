<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_Compra
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fm_Compra))
        Me.btn_Compra = New System.Windows.Forms.Button()
        Me.btn_Venta = New System.Windows.Forms.Button()
        Me.btn_Bancaria = New System.Windows.Forms.Button()
        Me.btn_Stocks = New System.Windows.Forms.Button()
        Me.btn_Economia = New System.Windows.Forms.Button()
        Me.cmb_proveedor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Borrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dg_Articulos = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Contextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.op_borrar_producto = New System.Windows.Forms.ToolStripMenuItem()
        Me.op_quitarcantidad = New System.Windows.Forms.ToolStripMenuItem()
        Me.Lista_Productos = New System.Windows.Forms.ListView()
        Me.ComprobarPedidoTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbPedidosPendientes = New System.Windows.Forms.Label()
        Me.btn_Confirmar = New System.Windows.Forms.Button()
        Me.btn_Cesta = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.dg_Articulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Contextual.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Compra
        '
        Me.btn_Compra.Enabled = False
        Me.btn_Compra.Location = New System.Drawing.Point(12, 12)
        Me.btn_Compra.Name = "btn_Compra"
        Me.btn_Compra.Size = New System.Drawing.Size(170, 77)
        Me.btn_Compra.TabIndex = 0
        Me.btn_Compra.Text = "Operaciones de Compra"
        Me.btn_Compra.UseVisualStyleBackColor = True
        '
        'btn_Venta
        '
        Me.btn_Venta.Location = New System.Drawing.Point(12, 95)
        Me.btn_Venta.Name = "btn_Venta"
        Me.btn_Venta.Size = New System.Drawing.Size(170, 77)
        Me.btn_Venta.TabIndex = 1
        Me.btn_Venta.Text = "Operaciones de Venta"
        Me.btn_Venta.UseVisualStyleBackColor = True
        '
        'btn_Bancaria
        '
        Me.btn_Bancaria.Location = New System.Drawing.Point(12, 178)
        Me.btn_Bancaria.Name = "btn_Bancaria"
        Me.btn_Bancaria.Size = New System.Drawing.Size(170, 77)
        Me.btn_Bancaria.TabIndex = 2
        Me.btn_Bancaria.Text = "Gestión Bancaria"
        Me.btn_Bancaria.UseVisualStyleBackColor = True
        '
        'btn_Stocks
        '
        Me.btn_Stocks.Location = New System.Drawing.Point(12, 261)
        Me.btn_Stocks.Name = "btn_Stocks"
        Me.btn_Stocks.Size = New System.Drawing.Size(170, 77)
        Me.btn_Stocks.TabIndex = 3
        Me.btn_Stocks.Text = "Gestión de Stocks"
        Me.btn_Stocks.UseVisualStyleBackColor = True
        '
        'btn_Economia
        '
        Me.btn_Economia.Location = New System.Drawing.Point(12, 343)
        Me.btn_Economia.Name = "btn_Economia"
        Me.btn_Economia.Size = New System.Drawing.Size(170, 77)
        Me.btn_Economia.TabIndex = 4
        Me.btn_Economia.Text = "Gestión Económica"
        Me.btn_Economia.UseVisualStyleBackColor = True
        '
        'cmb_proveedor
        '
        Me.cmb_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_proveedor.FormattingEnabled = True
        Me.cmb_proveedor.Location = New System.Drawing.Point(287, 11)
        Me.cmb_proveedor.Name = "cmb_proveedor"
        Me.cmb_proveedor.Size = New System.Drawing.Size(213, 21)
        Me.cmb_proveedor.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(192, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 18)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Proveedor"
        '
        'btn_Borrar
        '
        Me.btn_Borrar.Enabled = False
        Me.btn_Borrar.Image = CType(resources.GetObject("btn_Borrar.Image"), System.Drawing.Image)
        Me.btn_Borrar.Location = New System.Drawing.Point(752, 312)
        Me.btn_Borrar.Name = "btn_Borrar"
        Me.btn_Borrar.Size = New System.Drawing.Size(100, 90)
        Me.btn_Borrar.TabIndex = 12
        Me.btn_Borrar.Text = "Borrar Pedido"
        Me.btn_Borrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Borrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(192, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Articulos"
        '
        'dg_Articulos
        '
        Me.dg_Articulos.AllowUserToAddRows = False
        Me.dg_Articulos.AllowUserToDeleteRows = False
        Me.dg_Articulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Articulos.Location = New System.Drawing.Point(195, 59)
        Me.dg_Articulos.MultiSelect = False
        Me.dg_Articulos.Name = "dg_Articulos"
        Me.dg_Articulos.ReadOnly = True
        Me.dg_Articulos.Size = New System.Drawing.Size(370, 165)
        Me.dg_Articulos.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(192, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Cesta"
        '
        'Contextual
        '
        Me.Contextual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.op_borrar_producto, Me.op_quitarcantidad})
        Me.Contextual.Name = "Contextual"
        Me.Contextual.Size = New System.Drawing.Size(159, 48)
        '
        'op_borrar_producto
        '
        Me.op_borrar_producto.Name = "op_borrar_producto"
        Me.op_borrar_producto.Size = New System.Drawing.Size(158, 22)
        Me.op_borrar_producto.Text = "Borrar Producto"
        '
        'op_quitarcantidad
        '
        Me.op_quitarcantidad.Name = "op_quitarcantidad"
        Me.op_quitarcantidad.Size = New System.Drawing.Size(158, 22)
        Me.op_quitarcantidad.Text = "Quitar Cantidad"
        '
        'Lista_Productos
        '
        Me.Lista_Productos.Location = New System.Drawing.Point(195, 255)
        Me.Lista_Productos.Name = "Lista_Productos"
        Me.Lista_Productos.Size = New System.Drawing.Size(506, 165)
        Me.Lista_Productos.TabIndex = 20
        Me.Lista_Productos.UseCompatibleStateImageBehavior = False
        Me.Lista_Productos.View = System.Windows.Forms.View.List
        '
        'ComprobarPedidoTimer
        '
        Me.ComprobarPedidoTimer.Enabled = True
        Me.ComprobarPedidoTimer.Interval = 10000
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(662, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(167, 18)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Pedidos Pendientes: "
        '
        'lbPedidosPendientes
        '
        Me.lbPedidosPendientes.AutoSize = True
        Me.lbPedidosPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lbPedidosPendientes.Location = New System.Drawing.Point(835, 7)
        Me.lbPedidosPendientes.Name = "lbPedidosPendientes"
        Me.lbPedidosPendientes.Size = New System.Drawing.Size(17, 18)
        Me.lbPedidosPendientes.TabIndex = 23
        Me.lbPedidosPendientes.Text = "0"
        '
        'btn_Confirmar
        '
        Me.btn_Confirmar.Enabled = False
        Me.btn_Confirmar.Image = CType(resources.GetObject("btn_Confirmar.Image"), System.Drawing.Image)
        Me.btn_Confirmar.Location = New System.Drawing.Point(752, 172)
        Me.btn_Confirmar.Name = "btn_Confirmar"
        Me.btn_Confirmar.Size = New System.Drawing.Size(100, 90)
        Me.btn_Confirmar.TabIndex = 11
        Me.btn_Confirmar.Text = "Confirmar Pedido"
        Me.btn_Confirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Confirmar.UseVisualStyleBackColor = True
        '
        'btn_Cesta
        '
        Me.btn_Cesta.Enabled = False
        Me.btn_Cesta.Image = CType(resources.GetObject("btn_Cesta.Image"), System.Drawing.Image)
        Me.btn_Cesta.Location = New System.Drawing.Point(752, 33)
        Me.btn_Cesta.Name = "btn_Cesta"
        Me.btn_Cesta.Size = New System.Drawing.Size(100, 90)
        Me.btn_Cesta.TabIndex = 8
        Me.btn_Cesta.Text = "Meter en la Cesta"
        Me.btn_Cesta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cesta.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(507, 51)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(300, 300)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'fm_Compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(864, 432)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbPedidosPendientes)
        Me.Controls.Add(Me.btn_Borrar)
        Me.Controls.Add(Me.dg_Articulos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_Confirmar)
        Me.Controls.Add(Me.btn_Cesta)
        Me.Controls.Add(Me.cmb_proveedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Lista_Productos)
        Me.Controls.Add(Me.btn_Economia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Compra)
        Me.Controls.Add(Me.btn_Venta)
        Me.Controls.Add(Me.btn_Stocks)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_Bancaria)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "fm_Compra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Operaciones de Compra"
        CType(Me.dg_Articulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Contextual.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Compra As System.Windows.Forms.Button
    Friend WithEvents btn_Venta As System.Windows.Forms.Button
    Friend WithEvents btn_Bancaria As System.Windows.Forms.Button
    Friend WithEvents btn_Stocks As System.Windows.Forms.Button
    Friend WithEvents btn_Economia As System.Windows.Forms.Button
    Friend WithEvents cmb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Cesta As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Confirmar As System.Windows.Forms.Button
    Friend WithEvents btn_Borrar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dg_Articulos As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Contextual As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents op_borrar_producto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents op_quitarcantidad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Lista_Productos As System.Windows.Forms.ListView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ComprobarPedidoTimer As System.Windows.Forms.Timer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbPedidosPendientes As System.Windows.Forms.Label
End Class
