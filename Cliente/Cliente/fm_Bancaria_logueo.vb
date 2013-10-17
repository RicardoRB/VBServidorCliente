Imports System.Data.OleDb

Public Class fm_Bancaria_logueo
    Dim Con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath.ToString & "\..\..\..\..\Empresa_Aula.accdb")
    Dim Adap As OleDbDataAdapter
    Dim DS As DataSet
    Dim Tabla As New DataTable
    Dim Consulta As String

    Private Sub fm_Bancaria_logueo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim respuesta As Integer
        respuesta = MsgBox("¿Esta seguro de que desea salir?", MsgBoxStyle.OkCancel)
        If respuesta = 1 Then
            fm_Bancaria.setEntra(False)
            Me.Hide()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btn_Acceder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Acceder.Click
        ep_usuario.Clear()
        If txt_Usuario.Text = "" Or txt_Contraseña.Text = "" Then
            ep_usuario.SetError(txt_Usuario, "Alguno de los campos estan vacios")
        Else
            Try
                conectar()
                Dim Registros As DataRowCollection = Tabla.Rows
                If (Registros.Contains(txt_Contraseña.Text)) Then
                    Dim fila As DataRow = Registros.Find(txt_Contraseña.Text)
                    If fila.Item(1) = txt_Usuario.Text Then
                        fm_Bancaria.dg_Bancarios.DataSource = Nothing
                        Me.Hide()
                        'Mostrara los datos de bancaria si el usuario y contraseña son correctos
                        conectar_bancaria()
                        Mostrar_bancaria()
                    Else
                        ep_usuario.SetError(txt_Usuario, "El usuario no es correcto o no esta en la base de datos")
                    End If
                Else
                    ep_usuario.SetError(txt_Contraseña, "La contraseña es incorrecta")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub conectar()
        Try
            Consulta = "SELECT * FROM EMP_GESTION"
            Adap = New OleDbDataAdapter(Consulta, Con)
            DS = New DataSet("DS_EMP_GESTION")
            Con.Open()
            Adap.Fill(DS, "EMP_GESTION")
            Adap.Fill(Tabla)
            Adap.FillSchema(Tabla, SchemaType.Source)
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Public Sub conectar_bancaria()
        Dim Consulta As String
        Try
            Consulta = "SELECT * FROM BANCO WHERE CIF_Emp = '" & txt_Contraseña.Text.ToString & "'"
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Con.Open()
            adap.Fill(DS, "DS_BANCO")
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub
    Public Sub Mostrar_bancaria()
        fm_Bancaria.dg_Bancarios.DataSource = DS
        fm_Bancaria.dg_Bancarios.DataMember = "DS_BANCO"
    End Sub
End Class