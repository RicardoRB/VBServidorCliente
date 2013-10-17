Imports System.Data.OleDb
Public Class fm_Bancaria

    Dim Con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath.ToString & "\..\..\..\..\Empresa_Aula.accdb")
    Dim Adap As OleDbDataAdapter
    Dim DS As DataSet
    Dim Tabla As New DataTable
    Dim Consulta As String
    Dim entra As Boolean = False

    Private Sub btn_Compra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Compra.Click
        Me.Hide()
        fm_Compra.Show()
    End Sub

    Private Sub btn_Venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Venta.Click
        Me.Hide()
        fm_Venta.Show()
    End Sub

    Private Sub btn_Economia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Economia.Click
        Me.Hide()
        fm_Economia.Show()
    End Sub

    Private Sub btn_Stocks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Stocks.Click
        Me.Hide()
        fm_Stocks.Show()
    End Sub

    Private Sub fm_Bancaria_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim respuesta As Integer
        respuesta = MsgBox("¿Esta seguro de que desea salir?", MsgBoxStyle.OkCancel)
        If respuesta = 1 Then
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Public Function getEntra()
        Return entra
    End Function

    Public Sub setEntra(ByVal valor As Boolean)
        entra = valor
    End Sub

    Public Sub conectar_bancaria()
        Dim Consulta As String
        'Visualiza el contenido del banco del que se ha logeado
        Try
            DS = New DataSet("DS_BANCO")
            Consulta = "SELECT * FROM BANCO WHERE CIF_Emp = '" & fm_Bancaria_logueo.txt_Contraseña.Text.ToString & "'"
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
        dg_Bancarios.DataSource = DS
        dg_Bancarios.DataMember = "DS_BANCO"
    End Sub

    Public Sub Resetear()
        conectar_bancaria()
        Mostrar_bancaria()
    End Sub
End Class