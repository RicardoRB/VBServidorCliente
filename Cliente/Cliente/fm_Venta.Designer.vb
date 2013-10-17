<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_Venta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fm_Venta))
        Me.btn_Economia = New System.Windows.Forms.Button()
        Me.btn_Stocks = New System.Windows.Forms.Button()
        Me.btn_Bancaria = New System.Windows.Forms.Button()
        Me.btn_Venta = New System.Windows.Forms.Button()
        Me.btn_Compra = New System.Windows.Forms.Button()
        Me.btn_Confirmar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dg_Articulos = New System.Windows.Forms.DataGridView()
        Me.dg_Pedidos = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbPedidosPendientes = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dg_Articulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_Pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Economia
        '
        Me.btn_Economia.Location = New System.Drawing.Point(12, 343)
        Me.btn_Economia.Name = "btn_Economia"
        Me.btn_Economia.Size = New System.Drawing.Size(170, 77)
        Me.btn_Economia.TabIndex = 9
        Me.btn_Economia.Text = "Gestión Económica"
        Me.btn_Economia.UseVisualStyleBackColor = True
        '
        'btn_Stocks
        '
        Me.btn_Stocks.Location = New System.Drawing.Point(12, 261)
        Me.btn_Stocks.Name = "btn_Stocks"
        Me.btn_Stocks.Size = New System.Drawing.Size(170, 77)
        Me.btn_Stocks.TabIndex = 8
        Me.btn_Stocks.Text = "Gestión de Stocks"
        Me.btn_Stocks.UseVisualStyleBackColor = True
        '
        'btn_Bancaria
        '
        Me.btn_Bancaria.Location = New System.Drawing.Point(12, 178)
        Me.btn_Bancaria.Name = "btn_Bancaria"
        Me.btn_Bancaria.Size = New System.Drawing.Size(170, 77)
        Me.btn_Bancaria.TabIndex = 7
        Me.btn_Bancaria.Text = "Gestión Bancaria"
        Me.btn_Bancaria.UseVisualStyleBackColor = True
        '
        'btn_Venta
        '
        Me.btn_Venta.Enabled = False
        Me.btn_Venta.Location = New System.Drawing.Point(12, 95)
        Me.btn_Venta.Name = "btn_Venta"
        Me.btn_Venta.Size = New System.Drawing.Size(170, 77)
        Me.btn_Venta.TabIndex = 6
        Me.btn_Venta.Text = "Operaciones de Venta"
        Me.btn_Venta.UseVisualStyleBackColor = True
        '
        'btn_Compra
        '
        Me.btn_Compra.Location = New System.Drawing.Point(12, 12)
        Me.btn_Compra.Name = "btn_Compra"
        Me.btn_Compra.Size = New System.Drawing.Size(170, 77)
        Me.btn_Compra.TabIndex = 5
        Me.btn_Compra.Text = "Operaciones de Compra"
        Me.btn_Compra.UseVisualStyleBackColor = True
        '
        'btn_Confirmar
        '
        Me.btn_Confirmar.Enabled = False
        Me.btn_Confirmar.Image = CType(resources.GetObject("btn_Confirmar.Image"), System.Drawing.Image)
        Me.btn_Confirmar.Location = New System.Drawing.Point(752, 172)
        Me.btn_Confirmar.Name = "btn_Confirmar"
        Me.btn_Confirmar.Size = New System.Drawing.Size(100, 90)
        Me.btn_Confirmar.TabIndex = 21
        Me.btn_Confirmar.Text = "Confirmar Pedido"
        Me.btn_Confirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Confirmar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(192, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Artículos"
        '
        'dg_Articulos
        '
        Me.dg_Articulos.AllowUserToAddRows = False
        Me.dg_Articulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Articulos.Location = New System.Drawing.Point(195, 242)
        Me.dg_Articulos.Name = "dg_Articulos"
        Me.dg_Articulos.ReadOnly = True
        Me.dg_Articulos.Size = New System.Drawing.Size(551, 180)
        Me.dg_Articulos.TabIndex = 23
        '
        'dg_Pedidos
        '
        Me.dg_Pedidos.AllowUserToAddRows = False
        Me.dg_Pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Pedidos.Location = New System.Drawing.Point(195, 39)
        Me.dg_Pedidos.Name = "dg_Pedidos"
        Me.dg_Pedidos.ReadOnly = True
        Me.dg_Pedidos.Size = New System.Drawing.Size(551, 180)
        Me.dg_Pedidos.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(192, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 17)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Pedidos"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(665, 261)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(390, 250)
        Me.PictureBox1.TabIndex = 26
        Me.PictureBox1.TabStop = False
        '
        'lbPedidosPendientes
        '
        Me.lbPedidosPendientes.AutoSize = True
        Me.lbPedidosPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lbPedidosPendientes.Location = New System.Drawing.Point(835, 7)
        Me.lbPedidosPendientes.Name = "lbPedidosPendientes"
        Me.lbPedidosPendientes.Size = New System.Drawing.Size(17, 18)
        Me.lbPedidosPendientes.TabIndex = 28
        Me.lbPedidosPendientes.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(662, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(167, 18)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Pedidos Pendientes: "
        '
        'fm_Venta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(864, 432)
        Me.Controls.Add(Me.lbPedidosPendientes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dg_Pedidos)
        Me.Controls.Add(Me.dg_Articulos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_Confirmar)
        Me.Controls.Add(Me.btn_Economia)
        Me.Controls.Add(Me.btn_Stocks)
        Me.Controls.Add(Me.btn_Bancaria)
        Me.Controls.Add(Me.btn_Venta)
        Me.Controls.Add(Me.btn_Compra)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "fm_Venta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Operaciones de Venta"
        CType(Me.dg_Articulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_Pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Economia As System.Windows.Forms.Button
    Friend WithEvents btn_Stocks As System.Windows.Forms.Button
    Friend WithEvents btn_Bancaria As System.Windows.Forms.Button
    Friend WithEvents btn_Venta As System.Windows.Forms.Button
    Friend WithEvents btn_Compra As System.Windows.Forms.Button
    Friend WithEvents btn_Confirmar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dg_Articulos As System.Windows.Forms.DataGridView
    Friend WithEvents dg_Pedidos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbPedidosPendientes As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
