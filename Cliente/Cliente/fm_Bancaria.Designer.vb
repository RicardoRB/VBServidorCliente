<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_Bancaria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fm_Bancaria))
        Me.btn_Economia = New System.Windows.Forms.Button()
        Me.btn_Stocks = New System.Windows.Forms.Button()
        Me.btn_Bancaria = New System.Windows.Forms.Button()
        Me.btn_Venta = New System.Windows.Forms.Button()
        Me.btn_Compra = New System.Windows.Forms.Button()
        Me.dg_Bancarios = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbPedidosPendientes = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dg_Bancarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Economia
        '
        Me.btn_Economia.Location = New System.Drawing.Point(12, 343)
        Me.btn_Economia.Name = "btn_Economia"
        Me.btn_Economia.Size = New System.Drawing.Size(170, 77)
        Me.btn_Economia.TabIndex = 14
        Me.btn_Economia.Text = "Gestión Económica"
        Me.btn_Economia.UseVisualStyleBackColor = True
        '
        'btn_Stocks
        '
        Me.btn_Stocks.Location = New System.Drawing.Point(12, 261)
        Me.btn_Stocks.Name = "btn_Stocks"
        Me.btn_Stocks.Size = New System.Drawing.Size(170, 77)
        Me.btn_Stocks.TabIndex = 13
        Me.btn_Stocks.Text = "Gestión de Stocks"
        Me.btn_Stocks.UseVisualStyleBackColor = True
        '
        'btn_Bancaria
        '
        Me.btn_Bancaria.Enabled = False
        Me.btn_Bancaria.Location = New System.Drawing.Point(12, 178)
        Me.btn_Bancaria.Name = "btn_Bancaria"
        Me.btn_Bancaria.Size = New System.Drawing.Size(170, 77)
        Me.btn_Bancaria.TabIndex = 12
        Me.btn_Bancaria.Text = "Gestión Bancaria"
        Me.btn_Bancaria.UseVisualStyleBackColor = True
        '
        'btn_Venta
        '
        Me.btn_Venta.Location = New System.Drawing.Point(12, 95)
        Me.btn_Venta.Name = "btn_Venta"
        Me.btn_Venta.Size = New System.Drawing.Size(170, 77)
        Me.btn_Venta.TabIndex = 11
        Me.btn_Venta.Text = "Operaciones de Venta"
        Me.btn_Venta.UseVisualStyleBackColor = True
        '
        'btn_Compra
        '
        Me.btn_Compra.Location = New System.Drawing.Point(12, 12)
        Me.btn_Compra.Name = "btn_Compra"
        Me.btn_Compra.Size = New System.Drawing.Size(170, 77)
        Me.btn_Compra.TabIndex = 10
        Me.btn_Compra.Text = "Operaciones de Compra"
        Me.btn_Compra.UseVisualStyleBackColor = True
        '
        'dg_Bancarios
        '
        Me.dg_Bancarios.AllowUserToAddRows = False
        Me.dg_Bancarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Bancarios.Location = New System.Drawing.Point(195, 29)
        Me.dg_Bancarios.Name = "dg_Bancarios"
        Me.dg_Bancarios.ReadOnly = True
        Me.dg_Bancarios.Size = New System.Drawing.Size(657, 391)
        Me.dg_Bancarios.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(453, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 17)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Datos Bancarios"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(691, 76)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(300, 300)
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'lbPedidosPendientes
        '
        Me.lbPedidosPendientes.AutoSize = True
        Me.lbPedidosPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lbPedidosPendientes.Location = New System.Drawing.Point(835, 7)
        Me.lbPedidosPendientes.Name = "lbPedidosPendientes"
        Me.lbPedidosPendientes.Size = New System.Drawing.Size(17, 18)
        Me.lbPedidosPendientes.TabIndex = 26
        Me.lbPedidosPendientes.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(662, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(167, 18)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Pedidos Pendientes: "
        '
        'fm_Bancaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(864, 432)
        Me.Controls.Add(Me.lbPedidosPendientes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dg_Bancarios)
        Me.Controls.Add(Me.btn_Economia)
        Me.Controls.Add(Me.btn_Stocks)
        Me.Controls.Add(Me.btn_Bancaria)
        Me.Controls.Add(Me.btn_Venta)
        Me.Controls.Add(Me.btn_Compra)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "fm_Bancaria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestión Bancaria"
        CType(Me.dg_Bancarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Economia As System.Windows.Forms.Button
    Friend WithEvents btn_Stocks As System.Windows.Forms.Button
    Friend WithEvents btn_Bancaria As System.Windows.Forms.Button
    Friend WithEvents btn_Venta As System.Windows.Forms.Button
    Friend WithEvents btn_Compra As System.Windows.Forms.Button
    Friend WithEvents dg_Bancarios As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbPedidosPendientes As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
