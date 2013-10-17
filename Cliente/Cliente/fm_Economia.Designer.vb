<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_Economia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fm_Economia))
        Me.btn_Economia = New System.Windows.Forms.Button()
        Me.btn_Stocks = New System.Windows.Forms.Button()
        Me.btn_Bancaria = New System.Windows.Forms.Button()
        Me.btn_Venta = New System.Windows.Forms.Button()
        Me.btn_Compra = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb_Empresa = New System.Windows.Forms.ComboBox()
        Me.txt_Abono = New System.Windows.Forms.TextBox()
        Me.btn_Prestamo = New System.Windows.Forms.Button()
        Me.txt_NumFactura = New System.Windows.Forms.TextBox()
        Me.ep_error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbPedidosPendientes = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.ep_error, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Economia
        '
        Me.btn_Economia.Enabled = False
        Me.btn_Economia.Location = New System.Drawing.Point(12, 343)
        Me.btn_Economia.Name = "btn_Economia"
        Me.btn_Economia.Size = New System.Drawing.Size(170, 77)
        Me.btn_Economia.TabIndex = 8
        Me.btn_Economia.Text = "Gestión Económica"
        Me.btn_Economia.UseVisualStyleBackColor = True
        '
        'btn_Stocks
        '
        Me.btn_Stocks.Location = New System.Drawing.Point(12, 261)
        Me.btn_Stocks.Name = "btn_Stocks"
        Me.btn_Stocks.Size = New System.Drawing.Size(170, 77)
        Me.btn_Stocks.TabIndex = 7
        Me.btn_Stocks.Text = "Gestión de Stocks"
        Me.btn_Stocks.UseVisualStyleBackColor = True
        '
        'btn_Bancaria
        '
        Me.btn_Bancaria.Location = New System.Drawing.Point(12, 178)
        Me.btn_Bancaria.Name = "btn_Bancaria"
        Me.btn_Bancaria.Size = New System.Drawing.Size(170, 77)
        Me.btn_Bancaria.TabIndex = 6
        Me.btn_Bancaria.Text = "Gestión Bancaria"
        Me.btn_Bancaria.UseVisualStyleBackColor = True
        '
        'btn_Venta
        '
        Me.btn_Venta.Location = New System.Drawing.Point(12, 95)
        Me.btn_Venta.Name = "btn_Venta"
        Me.btn_Venta.Size = New System.Drawing.Size(170, 77)
        Me.btn_Venta.TabIndex = 5
        Me.btn_Venta.Text = "Operaciones de Venta"
        Me.btn_Venta.UseVisualStyleBackColor = True
        '
        'btn_Compra
        '
        Me.btn_Compra.Location = New System.Drawing.Point(12, 12)
        Me.btn_Compra.Name = "btn_Compra"
        Me.btn_Compra.Size = New System.Drawing.Size(170, 77)
        Me.btn_Compra.TabIndex = 4
        Me.btn_Compra.Text = "Operaciones de Compra"
        Me.btn_Compra.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(303, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 17)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Número de Factura"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(303, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 17)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Empresa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(303, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 17)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Abono"
        '
        'cb_Empresa
        '
        Me.cb_Empresa.AccessibleName = ""
        Me.cb_Empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Empresa.FormattingEnabled = True
        Me.cb_Empresa.Items.AddRange(New Object() {"BBVA", "La Caixa", "Santander", "Banesto", "Unicaja"})
        Me.cb_Empresa.Location = New System.Drawing.Point(456, 146)
        Me.cb_Empresa.Name = "cb_Empresa"
        Me.cb_Empresa.Size = New System.Drawing.Size(187, 21)
        Me.cb_Empresa.TabIndex = 1
        '
        'txt_Abono
        '
        Me.txt_Abono.Location = New System.Drawing.Point(456, 173)
        Me.txt_Abono.Name = "txt_Abono"
        Me.txt_Abono.Size = New System.Drawing.Size(187, 20)
        Me.txt_Abono.TabIndex = 2
        '
        'btn_Prestamo
        '
        Me.btn_Prestamo.Image = CType(resources.GetObject("btn_Prestamo.Image"), System.Drawing.Image)
        Me.btn_Prestamo.Location = New System.Drawing.Point(360, 213)
        Me.btn_Prestamo.Name = "btn_Prestamo"
        Me.btn_Prestamo.Size = New System.Drawing.Size(234, 72)
        Me.btn_Prestamo.TabIndex = 3
        Me.btn_Prestamo.Text = "Confirmar Prestamo"
        Me.btn_Prestamo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Prestamo.UseVisualStyleBackColor = True
        '
        'txt_NumFactura
        '
        Me.txt_NumFactura.Location = New System.Drawing.Point(456, 120)
        Me.txt_NumFactura.Name = "txt_NumFactura"
        Me.txt_NumFactura.Size = New System.Drawing.Size(187, 20)
        Me.txt_NumFactura.TabIndex = 0
        '
        'ep_error
        '
        Me.ep_error.ContainerControl = Me
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(573, 179)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(289, 250)
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
        'fm_Economia
        '
        Me.AcceptButton = Me.btn_Prestamo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(864, 432)
        Me.Controls.Add(Me.lbPedidosPendientes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_NumFactura)
        Me.Controls.Add(Me.btn_Prestamo)
        Me.Controls.Add(Me.txt_Abono)
        Me.Controls.Add(Me.cb_Empresa)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_Economia)
        Me.Controls.Add(Me.btn_Stocks)
        Me.Controls.Add(Me.btn_Bancaria)
        Me.Controls.Add(Me.btn_Venta)
        Me.Controls.Add(Me.btn_Compra)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "fm_Economia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestión Económica"
        CType(Me.ep_error, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Economia As System.Windows.Forms.Button
    Friend WithEvents btn_Stocks As System.Windows.Forms.Button
    Friend WithEvents btn_Bancaria As System.Windows.Forms.Button
    Friend WithEvents btn_Venta As System.Windows.Forms.Button
    Friend WithEvents btn_Compra As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cb_Empresa As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Abono As System.Windows.Forms.TextBox
    Friend WithEvents btn_Prestamo As System.Windows.Forms.Button
    Friend WithEvents txt_NumFactura As System.Windows.Forms.TextBox
    Friend WithEvents ep_error As System.Windows.Forms.ErrorProvider
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbPedidosPendientes As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
