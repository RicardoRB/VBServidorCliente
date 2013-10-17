<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Timer_Pedidos = New System.Windows.Forms.Timer(Me.components)
        Me.dg_ArticulosP = New System.Windows.Forms.DataGridView()
        Me.Lista_Productos = New System.Windows.Forms.ListView()
        Me.Timer_Ventas = New System.Windows.Forms.Timer(Me.components)
        Me.dg_Pedidos = New System.Windows.Forms.DataGridView()
        Me.dg_Articulos = New System.Windows.Forms.DataGridView()
        CType(Me.dg_ArticulosP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_Pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_Articulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer_Pedidos
        '
        '
        'dg_ArticulosP
        '
        Me.dg_ArticulosP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_ArticulosP.Location = New System.Drawing.Point(12, 23)
        Me.dg_ArticulosP.Name = "dg_ArticulosP"
        Me.dg_ArticulosP.Size = New System.Drawing.Size(164, 41)
        Me.dg_ArticulosP.TabIndex = 0
        Me.dg_ArticulosP.Visible = False
        '
        'Lista_Productos
        '
        Me.Lista_Productos.Location = New System.Drawing.Point(12, 80)
        Me.Lista_Productos.Name = "Lista_Productos"
        Me.Lista_Productos.Size = New System.Drawing.Size(164, 35)
        Me.Lista_Productos.TabIndex = 21
        Me.Lista_Productos.UseCompatibleStateImageBehavior = False
        Me.Lista_Productos.View = System.Windows.Forms.View.List
        Me.Lista_Productos.Visible = False
        '
        'Timer_Ventas
        '
        '
        'dg_Pedidos
        '
        Me.dg_Pedidos.AllowUserToAddRows = False
        Me.dg_Pedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Pedidos.Location = New System.Drawing.Point(12, 121)
        Me.dg_Pedidos.Name = "dg_Pedidos"
        Me.dg_Pedidos.Size = New System.Drawing.Size(356, 91)
        Me.dg_Pedidos.TabIndex = 22
        Me.dg_Pedidos.Visible = False
        '
        'dg_Articulos
        '
        Me.dg_Articulos.AllowUserToAddRows = False
        Me.dg_Articulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_Articulos.Location = New System.Drawing.Point(12, 218)
        Me.dg_Articulos.Name = "dg_Articulos"
        Me.dg_Articulos.Size = New System.Drawing.Size(356, 72)
        Me.dg_Articulos.TabIndex = 23
        Me.dg_Articulos.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 302)
        Me.Controls.Add(Me.dg_Articulos)
        Me.Controls.Add(Me.dg_Pedidos)
        Me.Controls.Add(Me.Lista_Productos)
        Me.Controls.Add(Me.dg_ArticulosP)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dg_ArticulosP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_Pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_Articulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer_Pedidos As System.Windows.Forms.Timer
    Friend WithEvents dg_ArticulosP As System.Windows.Forms.DataGridView
    Friend WithEvents Lista_Productos As System.Windows.Forms.ListView
    Friend WithEvents Timer_Ventas As System.Windows.Forms.Timer
    Friend WithEvents dg_Pedidos As System.Windows.Forms.DataGridView
    Friend WithEvents dg_Articulos As System.Windows.Forms.DataGridView

End Class
