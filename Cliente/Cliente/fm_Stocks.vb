Imports System.Data.OleDb

Public Class fm_Stocks

    Dim Con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath.ToString & "\..\..\..\..\Empresa_Aula.accdb")
    Dim DS As New DataSet


    Private Sub btn_Compra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Compra.Click
        Me.Hide()
        fm_Compra.Show()
    End Sub

    Private Sub btn_Venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Venta.Click
        Me.Hide()
        fm_Venta.Show()
    End Sub

    Private Sub btn_Bancaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Bancaria.Click
        Me.Hide()
        fm_Bancaria.Show()
        'Condicion para saber si se ha logeado en bancaria
        'anteriormente o no
        If fm_Bancaria.getEntra = False Then
            fm_Bancaria.setEntra(True)
            fm_Bancaria_logueo.Show()
        Else
            fm_Bancaria.Resetear()
        End If
    End Sub

    Private Sub btn_Economia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Economia.Click
        Me.Hide()
        fm_Economia.Show()
    End Sub

    Private Sub fm_Stocks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim respuesta As Integer
        respuesta = MsgBox("¿Esta seguro de que desea salir?", MsgBoxStyle.OkCancel)
        If respuesta = 1 Then
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub fm_Stocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Mostrar los articulos requeridos con la consulta al mostrar la pantalla
        conectar()
        Mostrar()
    End Sub

    Public Sub conectar()
        Dim Consulta As String
        Try
            Consulta = "SELECT ARTICULO.Cod_Art, Descripcion, Stock FROM ARTICULO, EMP_TIENE_ART WHERE ARTICULO.Cod_Art = EMP_TIENE_ART.Cod_Art AND stock<=5"
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Con.Open()
            adap.Fill(DS, "DS_ARTICULO")
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Public Sub Mostrar()
        dg_Stock.DataSource = DS
        dg_Stock.DataMember = "DS_ARTICULO"
    End Sub

    Public Sub resetear()
        conectar()
        Mostrar()
    End Sub

End Class