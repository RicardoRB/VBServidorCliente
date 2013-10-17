<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fm_Bancaria_logueo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fm_Bancaria_logueo))
        Me.txt_Contraseña = New System.Windows.Forms.TextBox()
        Me.txt_Usuario = New System.Windows.Forms.TextBox()
        Me.btn_Acceder = New System.Windows.Forms.Button()
        Me.lbl_Contraseña = New System.Windows.Forms.Label()
        Me.lbl_Usuario = New System.Windows.Forms.Label()
        Me.ep_usuario = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.ep_usuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_Contraseña
        '
        Me.txt_Contraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Contraseña.Location = New System.Drawing.Point(119, 97)
        Me.txt_Contraseña.Name = "txt_Contraseña"
        Me.txt_Contraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Contraseña.Size = New System.Drawing.Size(124, 24)
        Me.txt_Contraseña.TabIndex = 10
        Me.txt_Contraseña.Text = "N4504123T"
        '
        'txt_Usuario
        '
        Me.txt_Usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Usuario.Location = New System.Drawing.Point(119, 57)
        Me.txt_Usuario.Name = "txt_Usuario"
        Me.txt_Usuario.Size = New System.Drawing.Size(124, 24)
        Me.txt_Usuario.TabIndex = 9
        Me.txt_Usuario.Text = "Game"
        '
        'btn_Acceder
        '
        Me.btn_Acceder.Location = New System.Drawing.Point(80, 152)
        Me.btn_Acceder.Name = "btn_Acceder"
        Me.btn_Acceder.Size = New System.Drawing.Size(89, 30)
        Me.btn_Acceder.TabIndex = 8
        Me.btn_Acceder.Text = "Acceder"
        Me.btn_Acceder.UseVisualStyleBackColor = True
        '
        'lbl_Contraseña
        '
        Me.lbl_Contraseña.AutoSize = True
        Me.lbl_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Contraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_Contraseña.Location = New System.Drawing.Point(7, 100)
        Me.lbl_Contraseña.Name = "lbl_Contraseña"
        Me.lbl_Contraseña.Size = New System.Drawing.Size(95, 18)
        Me.lbl_Contraseña.TabIndex = 7
        Me.lbl_Contraseña.Text = "Contraseña"
        '
        'lbl_Usuario
        '
        Me.lbl_Usuario.AutoSize = True
        Me.lbl_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_Usuario.Location = New System.Drawing.Point(7, 59)
        Me.lbl_Usuario.Name = "lbl_Usuario"
        Me.lbl_Usuario.Size = New System.Drawing.Size(67, 18)
        Me.lbl_Usuario.TabIndex = 6
        Me.lbl_Usuario.Text = "Usuario"
        '
        'ep_usuario
        '
        Me.ep_usuario.ContainerControl = Me
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(128, 127)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 113)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'fm_Bancaria_logueo
        '
        Me.AcceptButton = Me.btn_Acceder
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(255, 236)
        Me.Controls.Add(Me.txt_Contraseña)
        Me.Controls.Add(Me.txt_Usuario)
        Me.Controls.Add(Me.btn_Acceder)
        Me.Controls.Add(Me.lbl_Contraseña)
        Me.Controls.Add(Me.lbl_Usuario)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "fm_Bancaria_logueo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fm_Bancaria_logueo"
        CType(Me.ep_usuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_Contraseña As System.Windows.Forms.TextBox
    Friend WithEvents txt_Usuario As System.Windows.Forms.TextBox
    Friend WithEvents btn_Acceder As System.Windows.Forms.Button
    Friend WithEvents lbl_Contraseña As System.Windows.Forms.Label
    Friend WithEvents lbl_Usuario As System.Windows.Forms.Label
    Friend WithEvents ep_usuario As System.Windows.Forms.ErrorProvider
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
