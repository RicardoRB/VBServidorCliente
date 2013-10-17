Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Net.Mail
Public Class fm_Venta
    Dim Con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath.ToString & "\..\..\..\..\Empresa_Aula.accdb")
    Dim DS As New DataSet
    Dim DSA As New DataSet
    Dim DSS As New DataSet
    Dim DSAA As New DataSet
    Dim Command As OleDbCommandBuilder
    Dim Tabla1 As New DataTable
    Dim Ruta As String
    Dim correcto As Boolean = True
    Dim num_pedi As String
    Dim cli_cif As String
    Dim wd As Word.Application
    Dim wdoc As Word.Document
    Dim rng As Word.Range
    Dim conIVA As Double
    Dim archivosalida_al As String
    Dim archivosalida_fa As String
    Dim EmailDestino As String
    Dim EmailOrigen As String
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

    Private Sub btn_Stocks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Stocks.Click
        Me.Hide()
        fm_Stocks.Show()
    End Sub

    Private Sub btn_Economia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Economia.Click
        Me.Hide()
        fm_Economia.Show()
    End Sub

    Private Sub btn_Compra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Compra.Click
        Me.Hide()
        fm_Compra.Show()
    End Sub


    Private Sub fm_Venta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim respuesta As Integer
        respuesta = MsgBox("¿Esta seguro de que desea salir?", MsgBoxStyle.OkCancel)
        If respuesta = 1 Then
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub fm_Venta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conectarPedidos()
        MostrarPedidos()
    End Sub
    Public Sub conectarPedidos()
        Dim Consulta As String
        Try
            Consulta = "SELECT Num_Ped, Fecha_Ped, Fecha_Entrega, Nombre AS Cliente, Importe_Total FROM PEDIDO, EMP_GESTION WHERE Prov_CIF = '" & fm_Logueo.txt_Contraseña.Text & "' AND Tramitado = " & False & " AND Cli_CIF = CIF_NIF"
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Con.Open()
            DS.Clear()
            adap.Fill(DS, "DS_PEDIDO")
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Public Sub MostrarPedidos()
        Try
            If Not DS.Tables(0).Rows.Count = 0 Then
                dg_Pedidos.DataSource = DS
                dg_Pedidos.DataMember = "DS_PEDIDO"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub conectarArticulos(ByVal num_pe As String)
        Dim Consulta As String
        Try
            Consulta = "SELECT a.Cod_art, a.Descripcion, ac.Cantidad " &
                        "FROM PEDIDO p, ART_CONTIENE ac, ARTICULO a " &
                        "WHERE p.Num_ped = " & num_pe & " AND ac.Tipo = 'Pedido' AND ac.Num_Doc = p.Num_ped AND ac.Cod_art = a.Cod_Art AND p.Tramitado = " & False & ""
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Con.Open()
            DSA.Clear()
            adap.Fill(DSA, "DS_ARTICULO")
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Public Sub MostrarArticulos()
        Try
            If Not DSA.Tables(0).Rows.Count = 0 Then
                btn_Confirmar.Enabled = True
                dg_Articulos.DataSource = DSA
                dg_Articulos.DataMember = "DS_ARTICULO"
            Else
                btn_Confirmar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub dg_Pedidos_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dg_Pedidos.CellMouseClick
        Try
            Dim fila As Integer
            'Al clickear sobre el datagrid pedido, que nos aparezca
            'en el datagrid de articulos, los articulos relacionados
            'con el pedido
            fila = dg_Pedidos.SelectedCells(0).RowIndex
            num_pedi = dg_Pedidos.Rows(fila).Cells.Item(0).Value
            cli_cif = dg_Pedidos.Rows(fila).Cells.Item(1).Value
            conectarArticulos(num_pedi)
            MostrarArticulos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub enviar_correo()
        Try
            Dim archivo_al As New Attachment(archivosalida_al)
            Dim archivo_fa As New Attachment(archivosalida_fa)
            Dim origen As New MailAddress(EmailOrigen)
            Dim usuario As String = EmailOrigen
            Dim pass As String = "Alumnodam2"

            Dim destino As MailAddress = Nothing
            Dim dsdestino As DataSet = Nothing

            destino = New MailAddress(EmailDestino)
            Dim mensaje As New MailMessage

            mensaje.To.Add(destino)
            mensaje.From = origen
            mensaje.Subject = "Pedido Trabajo Richy y Alban"
            mensaje.Body = "<p><font color=" & "#FF0000" & ">Tienes un pedido </font><font color=" & "#0000FF" & ">nuevo</font></p>"
            mensaje.Attachments.Add(archivo_al)
            mensaje.Attachments.Add(archivo_fa)
            mensaje.IsBodyHtml = True
            Dim cliente As New System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
            cliente.EnableSsl = True
            cliente.Credentials = New System.Net.NetworkCredential(usuario, pass)
            cliente.Send(mensaje)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_Confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Confirmar.Click
        'Quitamos el timer para que no haya problemas al conectarse simultaneamente a la base de datos
        fm_Compra.ComprobarPedidoTimer.Enabled = False
        Me.Hide()
        fm_Cargando.Show()
        confirmarPedido()
        fm_Cargando.Hide()
        Me.Show()
        fm_Compra.ComprobarPedidoTimer.Enabled = True
    End Sub

    Private Sub InsertarAlbaran(ByVal Consulta As String, ByVal Comando As OleDbCommand, ByVal max_albaran As Integer, ByRef impor_to As Double, ByVal Registros As DataRowCollection)
        Try
            Dim CadenaInsert As String
            'Calculamos con un bucle el importe total de los articulos que tenemos
            For i = 0 To dg_Articulos.RowCount - 1
                Consulta = "SELECT Precio_venta FROM ARTICULO WHERE Cod_Art = '" & dg_Articulos.Rows(i).Cells.Item(0).Value & "'"
                Dim adap As New OleDbDataAdapter(Consulta, Con)
                adap.Fill(DSAA, "DS_PRECIO")
                impor_to = impor_to + DSAA.Tables("DS_PRECIO").Rows.Item(0).Table.Rows(i).Item(0) * dg_Articulos.Rows(i).Cells.Item(2).Value
            Next

            'Aqui se calcula el importe total con el iva
            conIVA = impor_to + (impor_to * 0.21)
            conIVA = conIVA - (conIVA * (Registros.Item(0).Table.Rows(0).Item(2) / 100))

            'Inserccion de los datos a la tabla ALBARAN
            Con.Open()
            CadenaInsert = "INSERT INTO ALBARAN Values (" & max_albaran & "," & num_pedi & ",'" & cli_cif & "','" & fm_Logueo.txt_Contraseña.Text & "'," & conIVA.ToString.Replace(",", ".") & ") "
            Comando.CommandText = CadenaInsert
            Comando.CommandType = CommandType.Text
            Comando.Connection = Con
            Comando.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub InsertarFactura(ByVal Comando As OleDbCommand, ByVal max_albaran As Integer, ByVal impor_to As Double, ByVal max_num_factura As Integer, ByVal Registros As DataRowCollection)
        Dim CadenaInsert As String
        Dim fecha As String
        Dim dias As String
        Dim PlazoEntrega As String
        Dim condiciones As String
        Dim transporte As String
        Dim dias_tran As Integer
        Try
            PlazoEntrega = Registros.Item(0).Table.Rows(0).Item(0)
            dias = PlazoEntrega.Substring(0, PlazoEntrega.IndexOf("-"))
            fecha = DateAdd(DateInterval.Day, CInt(dias), Date.Today)
            condiciones = Registros.Item(0).Table.Rows(0).Item(1)
            transporte = Registros.Item(0).Table.Rows(0).Item(0)
            dias_tran = transporte.Substring(0, PlazoEntrega.IndexOf("-"))

            'Insercion de los datos a la tabla FACTURA
            Con.Open()
            CadenaInsert = "INSERT INTO FACTURA Values (" & max_num_factura & "," & max_albaran & ",'" & fm_Logueo.txt_Contraseña.Text & "','" & cli_cif & "','" & Date.Today & "','" & fecha & "','" & condiciones & "'," & dias_tran & "," & conIVA.ToString.Replace(",", ".") & "," & impor_to.ToString.Replace(",", ".") & ") "
            Comando.CommandText = CadenaInsert
            Comando.CommandType = CommandType.Text
            Comando.Connection = Con
            Comando.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub TramitarPedido(ByVal Comando As OleDbCommand)
        Dim CadenaInsert As String
        Try
            'Poner que el pedido ya ha sido tramitado
            Con.Open()
            CadenaInsert = "UPDATE PEDIDO SET Tramitado = " & True & " WHERE Num_ped = " & num_pedi & ""
            Comando.CommandText = CadenaInsert
            Comando.CommandType = CommandType.Text
            Comando.Connection = Con
            Comando.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Public Sub confirmarPedido()
        Dim Consulta As String
        Dim Comando As New OleDbCommand
        Dim max_albaran As Integer
        Dim impor_to As Double = 0
        Dim max_num_factura As Integer
        Try
            'Generamos la consulta necesaria para saber si hay articulos o no
            DSS.Clear()
            For i = 0 To dg_Articulos.RowCount - 1
                Consulta = "SELECT stock " &
                            "FROM emp_tiene_art " &
                            "WHERE CIF = '" & fm_Logueo.txt_Contraseña.Text & "'" &
                            " AND Cod_Art = '" & dg_Articulos.Rows(i).Cells.Item(0).Value & "'"
                Dim adap As New OleDbDataAdapter(Consulta, Con)
                Con.Open()
                adap.Fill(DSS, "DS_STOCK")
                If dg_Articulos.Rows(i).Cells.Item(2).Value > DSS.Tables("DS_STOCK").Rows.Item(0).Table.Rows(i).Item(0) Then
                    MsgBox("No hay suficientes articulos en stock del articulo " & dg_Articulos.Rows(i).Cells.Item(0).Value, MsgBoxStyle.Information)
                    correcto = False
                End If
                Con.Close()
            Next
            'Condicion de que si no hay articulos en la base de datos 
            'saltarnos todo el proceso y mostrar un mensaje
            If correcto = True Then
                Consulta = "SELECT Plazo_entrega, Cond_Pago, Descuentos, Email FROM EMP_GESTION WHERE CIF_NIF = '" + fm_Logueo.txt_Contraseña.Text + "'"
                Dim ds1 As New DataSet("DS_PLAZO")
                Dim adap1 As New OleDbDataAdapter(Consulta, Con)
                adap1.Fill(ds1, "DS_PLAZO")
                Dim Registros As DataRowCollection = ds1.Tables("DS_PLAZO").Rows

                'Ligamos el email del origen
                EmailOrigen = Registros.Item(0).Table.Rows(0).Item(3)

                'Cogemos el numero de albaran maximo para que luego no se duplique al insertarlo
                Consulta = "SELECT MAX(num_alb) FROM ALBARAN"
                Dim adap_num_alb As New OleDbDataAdapter(Consulta, Con)
                Dim ds_num_alb As New DataSet
                adap_num_alb.Fill(ds_num_alb, "DS_MAXALB")
                Consulta = "SELECT * FROM ALBARAN"
                Dim adap_tota_alba As New OleDbDataAdapter(Consulta, Con)
                Dim ds_tota_alba As New DataSet
                adap_tota_alba.Fill(ds_tota_alba, "DS_ALBATOTA")

                'Si no hay ningun registo, cogemos el numero 0
                If ds_tota_alba.Tables("DS_ALBATOTA").Rows.Count = 0 Then
                    max_albaran = 0
                Else
                    Dim registro As DataRowCollection = ds_num_alb.Tables("DS_MAXALB").Rows
                    max_albaran = (registro.Item(0).Table.Rows(0).Item(0) + 1)
                End If

                InsertarAlbaran(Consulta, Comando, max_albaran, impor_to, Registros)

                'Cogemos el numero de factura maximo para que luego no se duplique al insertarlo
                Consulta = "SELECT MAX(num_fact) FROM FACTURA"
                Dim adap_inser As New OleDbDataAdapter(Consulta, Con)
                Consulta = "SELECT * FROM FACTURA"
                Dim adap_tota As New OleDbDataAdapter(Consulta, Con)
                Dim ds_tota As New DataSet
                adap_tota.Fill(ds_tota, "DS_FACTOTA")
                Dim ds_inser As New DataSet
                adap_inser.Fill(ds_inser, "DS_MAXFACT")

                'Si no hay ningun registo, cogemos el numero 0
                If ds_tota.Tables("DS_FACTOTA").Rows.Count = 0 Then
                    max_num_factura = 0
                Else
                    Dim registro As DataRowCollection = ds_inser.Tables("DS_MAXFACT").Rows
                    max_num_factura = (registro.Item(0).Table.Rows(0).Item(0) + 1)
                End If

                InsertarFactura(Comando, max_albaran, impor_to, max_num_factura, Registros)
                TramitarPedido(Comando)
                DocumentosAlbaran(max_albaran)
                DocumentosFactura(max_num_factura, max_albaran)
                MatarProcesoWord()

                'Actualizamos de nuevos el datagrid de pedidos
                conectarPedidos()
                MostrarPedidos()

                DSA.Clear()

                'Actualizamos de nuevo el datagrid de articulos
                MostrarArticulos()

                'Enviamos el correo
                enviar_correo()

                'Actualizamos el datagrid de los stock
                fm_Stocks.resetear()

                'Actualizamos los numeros
                fm_Compra.ComprobarPedidoAuto()
            Else
                MsgBox("La confirmacion del pedido no ha podido ser llevada a cabo", MsgBoxStyle.Exclamation)
                correcto = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub DocumentosAlbaran(ByVal max_albaran As Integer)
        Dim Consulta As String
        Try
            'Obtenemos los datos necesarios para generar el documento
            Consulta = "SELECT * FROM EMP_GESTION WHERE CIF_NIF = '" & cli_cif & "'"
            Dim precio_to As Double
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Dim ds1 As New DataSet("DatosEmpresa")
            Con.Open()
            adap.Fill(ds1, "DatosEmpresa")
            EmailDestino = ds1.Tables("DatosEmpresa").Rows.Item(0).Table.Rows(0).Item(7)
            Con.Close()
            Dim Registros As DataRowCollection = ds1.Tables("DatosEmpresa").Rows
            Dim rutaword As String = Application.StartupPath.ToString & "\..\..\..\..\Documentos\Albaran_" + fm_Logueo.txt_Usuario.Text + ".docx"
            Dim archivosalida As String = Application.StartupPath.ToString & "\..\..\..\..\Documentos\Albaran_" + fm_Logueo.txt_Usuario.Text + "_salida_" + num_pedi + ".docx"
            archivosalida_al = archivosalida
            wd = New Word.Application
            wdoc = New Word.Document
            wd.Visible = False
            wdoc = wd.Documents.Open(rutaword, System.Reflection.Missing.Value, True)

            rng = wdoc.Bookmarks.Item("numalbaran").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(0)

            rng = wdoc.Bookmarks.Item("nombrecli").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(1)

            rng = wdoc.Bookmarks.Item("datos").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(2) & ", " & Registros.Item(0).Table.Rows(0).Item(3) & ", " & Registros.Item(0).Table.Rows(0).Item(4)

            rng = wdoc.Bookmarks.Item("telefono").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(8)

            rng = wdoc.Bookmarks.Item("cif").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(0)

            rng = wdoc.Bookmarks.Item("numpedido").Range
            rng.Text = num_pedi

            rng = wdoc.Bookmarks.Item("fecha").Range
            rng.Text = Date.Today

            'Este bucle sirve para mete cada articulo con su precio
            'Y calcular el precio total
            For i = 0 To dg_Articulos.RowCount - 1
                Consulta = "SELECT Precio_venta FROM ARTICULO WHERE Cod_Art = '" & dg_Articulos.Rows(i).Cells.Item(0).Value & "'"
                Dim adap1 As New OleDbDataAdapter(Consulta, Con)
                adap1.Fill(DSAA, "DS_PRECIO")
                precio_to = CDbl(dg_Articulos.Rows(i).Cells.Item(2).Value) * CDbl(DSAA.Tables("DS_PRECIO").Rows.Item(0).Table.Rows(i).Item(0))
                rng = wdoc.Bookmarks.Item("cod" & i + 1).Range
                rng.Text = dg_Articulos.Rows(i).Cells.Item(0).Value
                rng = wdoc.Bookmarks.Item("can" & i + 1).Range
                rng.Text = dg_Articulos.Rows(i).Cells.Item(2).Value
                rng = wdoc.Bookmarks.Item("des" & i + 1).Range
                rng.Text = dg_Articulos.Rows(i).Cells.Item(1).Value
                rng = wdoc.Bookmarks.Item("uni" & i + 1).Range
                rng.Text = DSAA.Tables("DS_PRECIO").Rows.Item(0).Table.Rows(i).Item(0)
                rng = wdoc.Bookmarks.Item("to" & i + 1).Range
                rng.Text = precio_to
            Next

            rng = wdoc.Bookmarks.Item("formapago").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(12)

            rng = wdoc.Bookmarks.Item("total").Range
            rng.Text = dg_Articulos.RowCount & "/10"

            rng = wdoc.Bookmarks.Item("portes").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(11)

            wdoc.SaveAs(archivosalida)

            If archivosalida <> Nothing Then
                wdoc.Close()
                wdoc = Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub DocumentosFactura(ByVal max_factura As Integer, ByVal max_albaran As Integer)
        Dim Consulta As String
        Try
            'Obtener los datos necesarios para el documento
            Consulta = "SELECT * FROM EMP_GESTION WHERE CIF_NIF = '" & cli_cif & "'"
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Dim ds1 As New DataSet("DatosEmpresa")
            Dim Comando As New OleDbCommand
            Con.Open()
            adap.Fill(ds1, "DatosEmpresa")
            Con.Close()
            Dim Registros As DataRowCollection = ds1.Tables("DatosEmpresa").Rows
            Dim rutaword As String = Application.StartupPath.ToString & "\..\..\..\..\Documentos\Factura_" + fm_Logueo.txt_Usuario.Text + ".docx"
            Dim archivosalida As String = Application.StartupPath.ToString & "\..\..\..\..\Documentos\Factura_" + fm_Logueo.txt_Usuario.Text + "_salida_" + num_pedi + ".docx"
            archivosalida_fa = archivosalida
            wd = New Word.Application
            wdoc = New Word.Document
            wd.Visible = False
            wdoc = wd.Documents.Open(rutaword, System.Reflection.Missing.Value, True)

            rng = wdoc.Bookmarks.Item("cliente").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(1)

            rng = wdoc.Bookmarks.Item("datos").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(2) & ", " & Registros.Item(0).Table.Rows(0).Item(3) & ", " & Registros.Item(0).Table.Rows(0).Item(4)

            rng = wdoc.Bookmarks.Item("telefono").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(8)

            rng = wdoc.Bookmarks.Item("numpedido").Range
            rng.Text = num_pedi

            rng = wdoc.Bookmarks.Item("fecha").Range
            rng.Text = Date.Today

            rng = wdoc.Bookmarks.Item("factura").Range
            rng.Text = max_factura

            rng = wdoc.Bookmarks.Item("cif").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(0)

            rng = wdoc.Bookmarks.Item("albaran").Range
            rng.Text = max_albaran

            Dim precio_to_uni As Double = 0
            Dim precio_to As Double
            'Este bucle sirve para meter en el albaran cada articulo con su precio
            'Y sumar el precio total
            'Tambien para quitar los productos del stock y sumarlos
            For i = 0 To dg_Articulos.RowCount - 1
                Consulta = "SELECT Precio_venta FROM ARTICULO WHERE Cod_Art = '" & dg_Articulos.Rows(i).Cells.Item(0).Value & "'"
                Dim adap1 As New OleDbDataAdapter(Consulta, Con)
                adap1.Fill(DSAA, "DS_PRECIO")
                precio_to_uni = dg_Articulos.Rows(i).Cells.Item(2).Value * DSAA.Tables("DS_PRECIO").Rows.Item(0).Table.Rows(i).Item(0)

                Consulta = "SELECT stock " &
                            "FROM emp_tiene_art " &
                            "WHERE CIF = '" & fm_Logueo.txt_Contraseña.Text & "'" &
                            "AND Cod_Art = '" & dg_Articulos.Rows(i).Cells.Item(0).Value & "'"
                Dim adap3 As New OleDbDataAdapter(Consulta, Con)
                Con.Open()
                adap3.Fill(DSS, "DS_STOCKSUMA")
                Con.Close()

                rng = wdoc.Bookmarks.Item("cod" & i + 1).Range
                rng.Text = dg_Articulos.Rows(i).Cells.Item(0).Value
                rng = wdoc.Bookmarks.Item("can" & i + 1).Range
                rng.Text = dg_Articulos.Rows(i).Cells.Item(2).Value
                rng = wdoc.Bookmarks.Item("des" & i + 1).Range
                rng.Text = dg_Articulos.Rows(i).Cells.Item(1).Value
                rng = wdoc.Bookmarks.Item("uni" & i + 1).Range
                rng.Text = DSAA.Tables("DS_PRECIO").Rows.Item(0).Table.Rows(i).Item(0)
                rng = wdoc.Bookmarks.Item("to" & i + 1).Range
                rng.Text = precio_to_uni
                precio_to = precio_to + precio_to_uni

                'Se le suma al stock al cliente
                Con.Open()
                Consulta = "UPDATE EMP_TIENE_ART SET Stock = " & DSS.Tables("DS_STOCKSUMA").Rows.Item(0).Table.Rows(i).Item(0) + dg_Articulos.Rows(i).Cells.Item(2).Value & " WHERE CIF = '" & cli_cif & "' AND Cod_Art = '" & dg_Articulos.Rows(i).Cells.Item(0).Value & "'"
                Comando.CommandText = Consulta
                Comando.CommandType = CommandType.Text
                Comando.Connection = Con
                Comando.ExecuteNonQuery()
                Con.Close()

                'Se le quita del stock a la empresa logeada
                Con.Open()
                Consulta = "UPDATE EMP_TIENE_ART SET Stock = " & DSS.Tables("DS_STOCK").Rows.Item(0).Table.Rows(i).Item(0) - dg_Articulos.Rows(i).Cells.Item(2).Value & " WHERE CIF = '" & fm_Logueo.txt_Contraseña.Text & "' AND Cod_Art = '" & dg_Articulos.Rows(i).Cells.Item(0).Value & "'"
                Comando.CommandText = Consulta
                Comando.CommandType = CommandType.Text
                Comando.Connection = Con
                Comando.ExecuteNonQuery()
                Con.Close()
            Next

            rng = wdoc.Bookmarks.Item("subtotal").Range
            rng.Text = precio_to

            rng = wdoc.Bookmarks.Item("descuento").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(15)

            rng = wdoc.Bookmarks.Item("cuota").Range
            rng.Text = (precio_to * 0.21)

            rng = wdoc.Bookmarks.Item("pago").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(12)

            rng = wdoc.Bookmarks.Item("total").Range
            rng.Text = conIVA

            rng = wdoc.Bookmarks.Item("cuenta").Range
            rng.Text = Registros.Item(0).Table.Rows(0).Item(13)

            'Se le resta el saldo al cliente
            Con.Open()
            Consulta = "UPDATE EMP_GESTION SET Saldo = " & CDbl((Registros.Item(0).Table.Rows(0).Item(16) - precio_to).ToString.Replace(",", ".")) & " WHERE CIF_NIF = '" & cli_cif & "'"
            Comando.CommandText = Consulta
            Comando.CommandType = CommandType.Text
            Comando.Connection = Con
            Comando.ExecuteNonQuery()
            Con.Close()

            'Se le suma el saldo a la empresa la cual se ha logeado
            Consulta = "SELECT * FROM EMP_GESTION WHERE CIF_NIF = '" & fm_Bancaria_logueo.txt_Contraseña.Text & "'"
            Dim adap2 As New OleDbDataAdapter(Consulta, Con)
            Dim ds2 As New DataSet("DatosEmpresa2")
            Con.Open()
            adap.Fill(ds1, "DatosEmpresa2")
            Con.Close()
            Dim Registros2 As DataRowCollection = ds1.Tables("DatosEmpresa2").Rows

            Con.Open()
            Consulta = "UPDATE EMP_GESTION SET Saldo = " & CDbl((CDbl(Registros2.Item(0).Table.Rows(0).Item(16)) + precio_to).ToString.Replace(",", ".")) & " WHERE CIF_NIF = '" & fm_Logueo.txt_Contraseña.Text & "'"
            Comando.CommandText = Consulta
            Comando.CommandType = CommandType.Text
            Comando.Connection = Con
            Comando.ExecuteNonQuery()
            Con.Close()

            wdoc.SaveAs(archivosalida)

            If archivosalida <> Nothing Then
                wdoc.Close()
                wdoc = Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub MatarProcesoWord()
        Try
            Dim proceso As System.Diagnostics.Process()
            proceso = System.Diagnostics.Process.GetProcessesByName("WINWORD")
            For Each opro As System.Diagnostics.Process In proceso
                If opro.StartTime >= Today Then
                    opro.Kill()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Program Exception: 'Cerrar proceso WORD'", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class