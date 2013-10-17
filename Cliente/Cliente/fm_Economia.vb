Imports System.Data.OleDb
Public Class fm_Economia
    Dim Con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath.ToString & "\..\..\..\..\Empresa_Aula.accdb")
    Dim adap_banco As OleDbDataAdapter
    Dim adap_emp As OleDbDataAdapter
    Dim DS As DataSet
    Dim Tabla As New DataTable
    Dim Consulta As String
    Private Sub btn_Venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Venta.Click
        Me.Hide()
        fm_Venta.Show()
    End Sub

    Private Sub fm_Economia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim respuesta As Integer
        respuesta = MsgBox("¿Esta seguro de que desea salir?", MsgBoxStyle.OkCancel)
        If respuesta = 1 Then
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btn_Compra_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Compra.Click
        Me.Hide()
        fm_Compra.Show()
    End Sub

    Private Sub btn_Bancaria_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Bancaria.Click
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

    Private Sub btn_Stocks_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Stocks.Click
        Me.Hide()
        fm_Stocks.Show()
    End Sub

    Private Sub btn_Prestamo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Prestamo.Click
        ep_error.Clear()
        'Comprobamos que los datos introducidos son correctos
        If txt_NumFactura.Text = "" Or Not IsNumeric(txt_NumFactura.Text) Then
            ep_error.SetError(txt_NumFactura, "El numero de factura no es correcto")
        ElseIf txt_Abono.Text = "" Or Not IsNumeric(txt_Abono.Text) Then
            ep_error.SetError(txt_Abono, "El numero de abono no es correcto")
        Else
            fm_Compra.ComprobarPedidoTimer.Enabled = False
            conectar_banco()
            insertar()
            fm_Compra.ComprobarPedidoTimer.Enabled = True
        End If
    End Sub

    Private Sub fm_Economia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cb_Empresa.SelectedIndex = 0
    End Sub

    Private Sub conectar_banco()
        Try
            Consulta = "SELECT * FROM BANCO"
            adap_banco = New OleDbDataAdapter(Consulta, Con)
            DS = New DataSet("DS_BANCO")
            Con.Open()
            adap_banco.Fill(DS, "BANCO")
            adap_banco.Fill(Tabla)
            adap_banco.FillSchema(Tabla, SchemaType.Source)
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub insertar()
        Dim Comando As New OleDbCommand
        Dim CadenaInsert As String
        Dim max_apunte As Integer
        Dim saldo As Integer
        Try
            If (Con.State = ConnectionState.Closed) Then
                Con.Open()
            End If
            'Insertamos los datos nuevos en la tabla banco, que hemos introducido
            Consulta = "SELECT MAX(APUNTE) FROM BANCO"
            Dim adap_inser As New OleDbDataAdapter(Consulta, Con)
            Dim ds_inser As New DataSet
            adap_inser.Fill(ds_inser, "DS_MAXAPUNTE")
            Dim registro As DataRowCollection = ds_inser.Tables("DS_MAXAPUNTE").Rows
            max_apunte = (registro.Item(0).Table.Rows(0).Item(0) + 1)
            Consulta = "SELECT Saldo FROM EMP_GESTION WHERE CIF_NIF = '" & fm_Bancaria_logueo.txt_Contraseña.Text & "'"
            adap_inser = New OleDbDataAdapter(Consulta, Con)
            adap_inser.Fill(DS, "DS_SALDO_EMP")
            Dim registro2 As DataRowCollection = DS.Tables("DS_SALDO_EMP").Rows
            Saldo = registro2.Item(0).Table.Rows(0).Item(0)

            'Inserccion de los datos a BANCO
            CadenaInsert = "INSERT INTO BANCO Values (" & max_apunte & ",'" & fm_Bancaria_logueo.txt_Contraseña.Text & "','" & Date.Today.ToShortDateString.ToString & "'," & CInt(txt_NumFactura.Text) & ",'" & cb_Empresa.SelectedItem & "'," & CInt(txt_Abono.Text) & "," & CInt(txt_Abono.Text) + saldo & ") "
            Comando.CommandText = CadenaInsert
            Comando.CommandType = CommandType.Text
            Comando.Connection = Con
            Comando.ExecuteNonQuery()

            'Actualizacion del saldo de la empresa en EMP_GESTION
            CadenaInsert = "UPDATE EMP_GESTION SET Saldo = " & CInt(txt_Abono.Text) + Saldo & " WHERE CIF_NIF = '" & fm_Bancaria_logueo.txt_Contraseña.Text & "'"
            Comando.CommandText = CadenaInsert
            Comando.CommandType = CommandType.Text
            Comando.Connection = Con
            Comando.ExecuteNonQuery()

            MsgBox("Prestamo realizada con exito")
            Comando.Dispose()
            Comando = Nothing
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub txt_NumFactura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_NumFactura.TextChanged

    End Sub
End Class