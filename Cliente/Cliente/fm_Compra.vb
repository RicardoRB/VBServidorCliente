Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Net.Mail


Public Class fm_Compra

    Dim wd As Word.Application
    Dim wdoc As Word.Document
    Dim rng As Word.Range
    Dim rutaword As String
    Dim archivosalida As String

    Dim Con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath.ToString & "\..\..\..\..\Empresa_Aula.accdb")
    Dim Adap As OleDbDataAdapter
    Dim Consulta As String
    Dim Ruta As String
    Dim NumeroProductos As Integer
    Dim total As Double
    Dim Transporte As String
    Dim EmailDestino As String
    Dim EmailOrigen As String



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

    Private Sub btn_Stocks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Stocks.Click
        Me.Hide()
        fm_Stocks.Show()
    End Sub

    Private Sub btn_Economia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Economia.Click
        Me.Hide()
        fm_Economia.Show()
    End Sub

    Private Sub fm_Compra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim respuesta As Integer
        respuesta = MsgBox("¿Esta seguro de que desea salir?", MsgBoxStyle.OkCancel)
        If respuesta = 1 Then
            End
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub ComprobarPedidos()
        Dim Consulta As String
        Dim numero_pedidos_pendientes As Integer
        'Comprobamos los pedidos pendientes para la empresa con la cual entramos.
        Try
            Consulta = "SELECT COUNT(Num_Ped) FROM PEDIDO WHERE Prov_CIF = '" & fm_Logueo.txt_Contraseña.Text & "' AND Tramitado = " & False & ""
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Dim ds As New DataSet("Numero_PEDIDOS")
            Con.Open()
            adap.Fill(ds, "Numero_PEDIDOS")
            Con.Close()
            Dim Reg As DataRowCollection = ds.Tables("Numero_PEDIDOS").Rows
            numero_pedidos_pendientes = Reg.Item(0).Table.Rows(0).Item(0)
            lbPedidosPendientes.Text = numero_pedidos_pendientes
            fm_Bancaria.lbPedidosPendientes.Text = numero_pedidos_pendientes
            fm_Economia.lbPedidosPendientes.Text = numero_pedidos_pendientes
            fm_Stocks.lbPedidosPendientes.Text = numero_pedidos_pendientes
            fm_Venta.lbPedidosPendientes.Text = numero_pedidos_pendientes
            'Indicamos si tiene o no pedidos pendientes.
            If numero_pedidos_pendientes > 0 Then
                MsgBox("Tienes " & numero_pedidos_pendientes & " pedidos pendientes.", MsgBoxStyle.Information)
            Else
                MsgBox("No tiene pedidos pendientes.", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox("Fallo en la comprobacion de los pedidos.")
            If (Con.State = ConnectionState.Open) Then
                Con.Close()
            End If
        End Try

    End Sub
    Public Sub ComprobarPedidoAuto()
        Dim Consulta As String
        'Comprobamos los pedidos pendientes para la empresa con la cual entramos.
        Try
            Consulta = "SELECT COUNT(Num_Ped) FROM PEDIDO WHERE Prov_CIF = '" & fm_Logueo.txt_Contraseña.Text & "' AND Tramitado = " & False & ""
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Dim ds As New DataSet("Numero_PEDIDOS")
            Con.Open()
            adap.Fill(ds, "Numero_PEDIDOS")
            Con.Close()
            Dim Reg As DataRowCollection = ds.Tables("Numero_PEDIDOS").Rows

            lbPedidosPendientes.Text = Reg.Item(0).Table.Rows(0).Item(0)
            fm_Bancaria.lbPedidosPendientes.Text = Reg.Item(0).Table.Rows(0).Item(0)
            fm_Economia.lbPedidosPendientes.Text = Reg.Item(0).Table.Rows(0).Item(0)
            fm_Stocks.lbPedidosPendientes.Text = Reg.Item(0).Table.Rows(0).Item(0)
            fm_Venta.lbPedidosPendientes.Text = Reg.Item(0).Table.Rows(0).Item(0)
            'Indicamos si tiene o no pedidos pendientes.

        Catch ex As Exception
            MsgBox("Fallo en la comprobacion de los pedidos.")
            If (Con.State = ConnectionState.Open) Then
                Con.Close()
            End If
        End Try

    End Sub

    Private Sub MostrarProveedores()
        Try
            'Seleccionamos los nombres de todas las empresas de gestion, exceptuando nuestro propio nombre.
            Consulta = "SELECT NOMBRE FROM EMP_GESTION WHERE NOMBRE <> '" + fm_Logueo.txt_Usuario.Text + "'"
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Dim ds As New DataSet("NombreEMP")
            Con.Open()
            adap.Fill(ds, "NombreEMP")

            Con.Close()

            Dim Registros As DataRowCollection = ds.Tables("NombreEMP").Rows

            cmb_proveedor.Items.Add(Registros.Item(0).Table.Rows(0).Item(0))
            cmb_proveedor.Items.Add(Registros.Item(0).Table.Rows(1).Item(0))
            'Generamos la nueva cesta de la compra, vacia de artículos.
            BorrarLista()
        Catch ex As Exception
            MsgBox(ex.Message)
            If (Con.State = ConnectionState.Open) Then
                Con.Close()
            End If
        End Try
    End Sub
    Private Sub fm_Compra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ComprobarPedidoTimer.Enabled = True
        ComprobarPedidoTimer.Start()
        ComprobarPedidos()
        MostrarProveedores()
        GuardarDatos()
    End Sub

    Private Sub GuardarDatos()
        Try
            'Seleccionamos los nombres de todas las empresas de gestion, exceptuando nuestro propio nombre.
            Consulta = "SELECT Email FROM EMP_GESTION WHERE NOMBRE = '" + fm_Logueo.txt_Usuario.Text + "'"
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Dim ds As New DataSet("NombreEMP")
            Con.Open()
            adap.Fill(ds, "NombreEMP")

            Con.Close()

            Dim Registros As DataRowCollection = ds.Tables("NombreEMP").Rows

            EmailOrigen = Registros.Item(0).Table.Rows(0).Item(0)

        Catch ex As Exception
            MsgBox(ex.Message)
            If (Con.State = ConnectionState.Open) Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub MostrarArticulosProveedor()
        'Cuando seleccionamos una empresa de entre todas las disponibles, almacena los datos de sus productos en un DataGrid.
        Try
            Consulta = "SELECT ARTICULO.Cod_Art, ARTICULO.Descripcion, ARTICULO.Precio_Compra FROM ARTICULO, EMP_TIENE_ART, EMP_GESTION WHERE ARTICULO.Cod_Art = EMP_TIENE_ART.Cod_Art AND EMP_TIENE_ART.CIF = EMP_GESTION.CIF_NIF AND EMP_GESTION.NOMBRE = '" + cmb_proveedor.Text + "'"
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Dim ds As New DataSet("Articulos")
            Con.Open()
            adap.Fill(ds, "Articulos")
            dg_Articulos.DataSource = ds
            dg_Articulos.DataMember = "Articulos"

            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If (Con.State = ConnectionState.Open) Then
                Con.Close()
            End If
        End Try
    End Sub
    Private Sub cmb_proveedor_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_proveedor.SelectedValueChanged

        MostrarArticulosProveedor()

    End Sub

    Private Sub dg_Articulos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_Articulos.CellClick
        btn_Cesta.Enabled = True
    End Sub

    Private Sub btn_Cesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cesta.Click
        Dim cantidad As Integer
        Dim cadenacantidad As String
        Dim fila As Integer
        Dim columnastotal As Integer
        Dim i As Integer
        Dim cadena As String = ""
        Dim precio As Double
        Dim items As ListViewItem

        cmb_proveedor.Enabled = False

        Try
            'Solicita cantidad mientras que la cantidad introducida sea igual a 0.
            Do
                cadenacantidad = InputBox("Introduce la cantidad deseada", "Introducir cantidad", 0)
            Loop While CInt(cadenacantidad) = 0
            'Almacena como valores la cantidad y el elemento seleccionado de nuestra DataGrid
            cantidad = CInt(cadenacantidad)

            fila = dg_Articulos.SelectedCells(0).RowIndex
            'Comprueba si ya se han introducido o no elementos en nuestra cesta. En caso afirmativo, revisa todos los elementos, buscando si el producto ya ha sido introducido en la cesta.
            If NumeroProductos > 0 Then
                For i = 0 To NumeroProductos - 1
                    If dg_Articulos.Rows(fila).Cells.Item(0).Value = Lista_Productos.Items.Item(i).SubItems.Item(0).Text Then
                        'Si lo encuentra, incrementa su cantidad y su precio y sale.
                        Lista_Productos.Items.Item(i).SubItems.Item(3).Text = Lista_Productos.Items.Item(i).SubItems.Item(3).Text + cantidad
                        Lista_Productos.Items.Item(i).SubItems.Item(4).Text = Lista_Productos.Items.Item(i).SubItems.Item(4).Text + (Lista_Productos.Items.Item(i).SubItems.Item(2).Text * cantidad)
                        total = total + (Lista_Productos.Items.Item(i).SubItems.Item(2).Text * cantidad)
                        Exit Sub
                    End If
                Next
            End If
            'En caso de que no haya salido (es decir, que no haya encontrado el producto en la cesta), lo introduce. 
            columnastotal = dg_Articulos.ColumnCount

            items = Lista_Productos.Items.Add(dg_Articulos.Rows(fila).Cells.Item(0).Value)

            For i = 1 To columnastotal - 1
                items.SubItems.Add(dg_Articulos.Rows(fila).Cells.Item(i).Value)
                If i = columnastotal - 1 Then
                    precio = dg_Articulos.Rows(fila).Cells.Item(i).Value
                End If
            Next

            items.SubItems.Add(cantidad)
            items.SubItems.Add(precio * cantidad)

            total = total + (Lista_Productos.Items.Item(NumeroProductos).SubItems.Item(2).Text * cantidad)
            'Activa los botones de Confirmar y de Borrar la lista.
            If btn_Confirmar.Enabled = False Then
                btn_Confirmar.Enabled = True
            End If
            If btn_Borrar.Enabled = False Then
                btn_Borrar.Enabled = True
            End If
            'Incrementamos la cantidad de productos en la cesta.
            NumeroProductos = NumeroProductos + 1
        Catch ex As Exception
            'MsgBox("Valor introducido incorrecto")
        End Try
    End Sub

    Private Sub btn_Borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Borrar.Click
        BorrarLista()
    End Sub

    Private Sub btn_Confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Confirmar.Click
        Dim Consulta1 As String
        Dim Consulta2 As String
        Dim Insercion As String
        Dim InsercionProducto As String
        Dim Comando As New OleDbCommand
        Dim Cuantos As Integer
        Dim NumRegistros As String
        Dim PlazoEntrega As String
        Dim Portes As String
        Dim PrecioPortes As String
        Dim TipoPortes As String
        Dim dias As String
        Dim condiciones As String
        Dim fecha As String
        Try
            ComprobarPedidoTimer.Stop()
            Me.Hide()
            fm_Cargando.Show()
            'Seleccionamos el valor del último pedido realizado y los datos necesarios de la empresa a la cual realizaremos el pedido.
            Consulta1 = "SELECT CIF_NIF, Plazo_entrega, Portes, Email FROM EMP_GESTION WHERE Nombre = '" + cmb_proveedor.Text + "'"
            Consulta2 = "SELECT MAX(Num_ped) FROM PEDIDO"

            Dim adap As New OleDbDataAdapter(Consulta1, Con)
            Dim ds1 As New DataSet("DatosEmpresa")
            Con.Open()
            adap.Fill(ds1, "DatosEmpresa")
            Con.Close()
            Dim Registros As DataRowCollection = ds1.Tables("DatosEmpresa").Rows

            Dim adap2 As New OleDbDataAdapter(Consulta2, Con)
            Dim ds2 As New DataSet("Registros")
            Con.Open()
            adap2.Fill(ds2, "Registros")
            Con.Close()
            Dim Registros2 As DataRowCollection = ds2.Tables("Registros").Rows

            NumRegistros = Registros2.Item(0).Table.Rows(0).Item(0) + 1
            'Obtenemos el plazo de entrega y, en función del plazo de entrega y de los portes, el dia en el que llegará.
            PlazoEntrega = Registros.Item(0).Table.Rows(0).Item(1)
            'Obtenemos el email del destinatario
            EmailDestino = Registros.Item(0).Table.Rows(0).Item(3)
            'Obtenemos los portes, su precio y su tipo
            Portes = Registros.Item(0).Table.Rows(0).Item(2)
            PrecioPortes = Portes.Substring(0, Portes.IndexOf("-"))
            TipoPortes = Portes.Substring((Portes.IndexOf("-") + 1), (Portes.Length - 1) - PrecioPortes.Length)

            'Obtenemos el numero de dias y las condiciones de pago
            dias = PlazoEntrega.Substring(0, PlazoEntrega.IndexOf("-"))
            condiciones = PlazoEntrega.Substring((PlazoEntrega.IndexOf("-") + 1), ((PlazoEntrega.Length - 1) - (dias.Length)))
            'En función de los valores, guardaremos unos datos u otros
            If condiciones = "Ahora" Then
                fecha = DateAdd(DateInterval.Day, CInt(dias), Date.Today)
            Else
                fecha = ""
            End If

            If TipoPortes = "Comprador" Then
                Transporte = "A Nuestro Cargo"
            ElseIf TipoPortes = "Proveedor" Then
                Transporte = "A su Cargo"
            Else
                Transporte = "Sin Portes"
            End If

            'Creamos el nuevo pedido en nuestra base de datos.
            'FALLO NO ES 1000, HAY QUE SUSTITUIRLO POR EL TOTAL
            Insercion = "INSERT INTO PEDIDO VALUES (" + NumRegistros + ", '" + fm_Logueo.txt_Contraseña.Text + "', '" + DateString + "', 'La misma', '" + fecha + "', '" + Transporte + "', '" + Registros.Item(0).Table.Rows(0).Item(0) + "', " & total.ToString.Replace(",", ".") & ", 0)"

            Con.Open()
            Comando.CommandText = Insercion
            Comando.CommandType = CommandType.Text
            Comando.Connection = Con
            Cuantos = Comando.ExecuteNonQuery

            Comando.Dispose()
            Comando = Nothing
            Con.Close()
            'Insertamos todos los productos en el pedido.
            For i = 0 To NumeroProductos - 1
                InsercionProducto = "INSERT INTO ART_CONTIENE VALUES (" & NumRegistros & ", 'Pedido', '" & Lista_Productos.Items.Item(i).SubItems.Item(0).Text & "', " & Lista_Productos.Items.Item(i).SubItems.Item(3).Text & ", " & Lista_Productos.Items.Item(i).SubItems.Item(4).Text.Replace(",", ".") & ")"
                Con.Open()
                Comando = New OleDbCommand
                Comando.CommandText = InsercionProducto
                Comando.CommandType = CommandType.Text
                Comando.Connection = Con
                Cuantos = Comando.ExecuteNonQuery

                Comando.Dispose()
                Comando = Nothing
                Con.Close()
            Next

            Try
                'Ejecutamos la función GuardarDoc, que creará el nuevo documento de Pedido.
                GuardarDoc(NumRegistros, fecha)
            Catch ex As Exception
                MsgBox("Error. No se pudo generar el documento.")
                If (Con.State = ConnectionState.Open) Then
                    Con.Close()
                End If
            End Try
            'Enviamos el pedido por correo electrónico
            enviar_correo()
            'Limpiamos la cesta.
            BorrarLista()
            fm_Cargando.Close()
            Me.Show()
            ComprobarPedidoTimer.Start()
        Catch ex As Exception
            MsgBox("Error. Pedido cancelado.")
            If (Con.State = ConnectionState.Open) Then
                Con.Close()
            End If
            fm_Cargando.Hide()
            Me.Show()
        End Try


    End Sub

    Private Sub enviar_correo()
        Try
            'Creamos el archivo que enviaremos por correo, el email de origen, el nombre del usuario y el pass.
            Dim archivo As New Attachment(archivosalida)
            Dim origen As New MailAddress(EmailOrigen)
            Dim usuario As String = EmailOrigen
            Dim pass As String = "Alumnodam2"
            'Creamos la direccion de destino
            Dim destino As MailAddress = Nothing
            Dim dsdestino As DataSet = Nothing

            destino = New MailAddress(EmailDestino)
            Dim mensaje As New MailMessage
            'Añadimos al mensaje el destinatario, el origen, el tema, el cuerpo del mensaje y el documento adjunto.
            mensaje.To.Add(destino)
            mensaje.From = origen
            mensaje.Subject = "Pedido Trabajo Richy y Alban"
            mensaje.Body = "<p><font color=" & "#FF0000" & ">Tienes un pedido  </font><font color=" & "#0000FF" & ">nuevo</font></p>"
            mensaje.Attachments.Add(archivo)
            mensaje.IsBodyHtml = True
            'Cargamos las credenciales del cliente y enviamos el correo.
            Dim cliente As New System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
            cliente.EnableSsl = True
            cliente.Credentials = New System.Net.NetworkCredential(usuario, pass)
            cliente.Send(mensaje)
        Catch ex As Exception
            MsgBox(ex.Message)
            If (Con.State = ConnectionState.Open) Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub BorrarLista()
        btn_Borrar.Enabled = False
        btn_Confirmar.Enabled = False
        cmb_proveedor.Enabled = True
        'Limpiamos la lista
        Lista_Productos.Clear()
        'Añadimos las columnas
        Lista_Productos.Columns.Add("Codigo", 100, HorizontalAlignment.Center)
        Lista_Productos.Columns.Add("Nombre", 100, HorizontalAlignment.Center)
        Lista_Productos.Columns.Add("Precio/unidad", 100, HorizontalAlignment.Center)
        Lista_Productos.Columns.Add("Cantidad", 100, HorizontalAlignment.Center)
        Lista_Productos.Columns.Add("Precio total", 100, HorizontalAlignment.Center)
        'Definimos las propiedades de la lista
        Lista_Productos.View = View.Details
        Lista_Productos.GridLines = True
        Lista_Productos.FullRowSelect = True
        Lista_Productos.HideSelection = False
        Lista_Productos.MultiSelect = False
        'Establecemos el numero de productos de la lista a 0
        NumeroProductos = 0
        total = 0
    End Sub

    Private Sub GuardarDoc(ByVal NumRegistros As String, ByVal fecha As String)

        Dim Consulta1 As String
        'Obtenemos todos los datos de la empresa que hace el pedido
        Consulta1 = "SELECT * FROM EMP_GESTION WHERE Nombre = '" + cmb_proveedor.Text + "'"
        Dim adap As New OleDbDataAdapter(Consulta1, Con)
        Dim ds1 As New DataSet("DatosEmpresa")
        Con.Open()
        adap.Fill(ds1, "DatosEmpresa")
        Con.Close()
        Dim Registros As DataRowCollection = ds1.Tables("DatosEmpresa").Rows
        'Cargamos la ruta del documento de origen y el nuevo documento de salida.
        rutaword = Application.StartupPath.ToString & "\..\..\..\..\Documentos\Pedido_" + fm_Logueo.txt_Usuario.Text + ".docx"
        archivosalida = Application.StartupPath.ToString & "\..\..\..\..\Documentos\Pedido_" + fm_Logueo.txt_Usuario.Text + "_salida_" + NumRegistros + ".docx"
        'Creamos un nuevo Word Application y Document
        wd = New Word.Application
        wdoc = New Word.Document
        'Abrimos la aplicación en modo visible false, y abrimos el documentos desde la ruta del documento de origen.
        Try
            wd.Visible = False
            wdoc = wd.Documents.Open(rutaword, System.Reflection.Missing.Value, True)
        Catch ex As Exception
            If (Con.State = ConnectionState.Open) Then
                Con.Close()
            End If
            MsgBox("Error: No se ha podido abrir el documento.")
        End Try
        'Insertamos todos los datos en el documento, a partir de distintos marcadores des documento.

        rng = wdoc.Bookmarks.Item("numpe").Range
        rng.Text = NumRegistros

        rng = wdoc.Bookmarks.Item("fecha").Range
        rng.Text = Date.Today

        rng = wdoc.Bookmarks.Item("entrega").Range
        rng.Text = fecha

        rng = wdoc.Bookmarks.Item("transporte").Range
        rng.Text = Transporte

        rng = wdoc.Bookmarks.Item("conpa").Range
        rng.Text = Registros.Item(0).Table.Rows(0).Item(12)

        rng = wdoc.Bookmarks.Item("nompro").Range
        rng.Text = cmb_proveedor.Text

        rng = wdoc.Bookmarks.Item("dirpro").Range
        rng.Text = Registros.Item(0).Table.Rows(0).Item(2)

        rng = wdoc.Bookmarks.Item("popro").Range
        rng.Text = Registros.Item(0).Table.Rows(0).Item(3)

        rng = wdoc.Bookmarks.Item("cppro").Range
        rng.Text = Registros.Item(0).Table.Rows(0).Item(4)

        Try
            GuardarProducto()
        Catch ex As Exception
            MsgBox("Error. No se pudieron guardar articulos.")
            If (Con.State = ConnectionState.Open) Then
                Con.Close()
            End If
        End Try

        'Guardamos el nuevo documento
        Try
            wdoc.SaveAs(archivosalida)
        Catch ex As Exception
            MsgBox("Error. No se pudo salvar el documento nuevo.")
            If (Con.State = ConnectionState.Open) Then
                Con.Close()
            End If
        End Try
        'Cerramos el documento
        If archivosalida <> Nothing Then
            wdoc.Close()
            wdoc = Nothing
        End If
        'Terminamos con el proceso Word.
        MatarProcesoWord()

    End Sub

    Private Sub GuardarProducto()
        Dim suma As Double
        'Almacenamos los productos en el documento desde la lista de productos.
        Try
            For i = 0 To NumeroProductos - 1

                rng = wdoc.Bookmarks.Item("cod" & (i + 1)).Range
                rng.Text = Lista_Productos.Items.Item(i).SubItems.Item(0).Text

                rng = wdoc.Bookmarks.Item("can" & (i + 1)).Range
                rng.Text = Lista_Productos.Items.Item(i).SubItems.Item(3).Text

                rng = wdoc.Bookmarks.Item("des" & (i + 1)).Range
                rng.Text = Lista_Productos.Items.Item(i).SubItems.Item(1).Text

                rng = wdoc.Bookmarks.Item("pre" & (i + 1)).Range
                rng.Text = Lista_Productos.Items.Item(i).SubItems.Item(2).Text

                rng = wdoc.Bookmarks.Item("im" & (i + 1)).Range
                rng.Text = Lista_Productos.Items.Item(i).SubItems.Item(4).Text
                suma = suma + rng.Text
            Next

            rng = wdoc.Bookmarks.Item("total").Range
            rng.Text = suma

        Catch ex As Exception
            MsgBox("Error al introducir los articulos en la lista.")
            If (Con.State = ConnectionState.Open) Then
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

    Private Sub Lista_Productos_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Lista_Productos.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Contextual.Show(MousePosition.X, MousePosition.Y)
        End If
    End Sub


    Private Sub op_borrar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles op_borrar_producto.Click
        BorrarProducto()
    End Sub

    Private Sub op_quitarcantidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles op_quitarcantidad.Click
        'Este proceso nos permite eliminar una cierta cantidad de productos de nuestra lista
        Dim cantidad As Integer
        Dim cadenacantidad As String
        Try
            Do
                cadenacantidad = InputBox("Introduce la cantidad deseada", "Introducir cantidad", 0)
            Loop While CInt(cadenacantidad) = 0

            cantidad = CInt(cadenacantidad)
            'Si la cantidad introducida es mayor que la que hay en la lista, la borra.
            If cantidad >= Lista_Productos.FocusedItem.SubItems.Item(3).Text Then
                total = total - Lista_Productos.FocusedItem.SubItems.Item(4).Text
                BorrarProducto()
            Else
                'Si no, simplemente la descuenta, quitando tanto una cierta cantidad de productos como disminuyendo el precio introducido.
                Lista_Productos.FocusedItem.SubItems.Item(3).Text = Lista_Productos.FocusedItem.SubItems.Item(3).Text - cantidad
                Lista_Productos.FocusedItem.SubItems.Item(4).Text = Lista_Productos.FocusedItem.SubItems.Item(4).Text - (Lista_Productos.FocusedItem.SubItems.Item(2).Text * cantidad)
                total = total - (Lista_Productos.FocusedItem.SubItems.Item(2).Text * cantidad)
            End If

        Catch ex As Exception
            MsgBox("No existe ningún elemento en la lista de la compra o no ha sido seleccionado.")
        End Try
    End Sub

    Private Sub BorrarProducto()
        Try
            'Obtiene de la lista el producto seleccionado y lo borra. Hecho esto, disminuye en 1 el numero de productos de la lista.
            total = total - Lista_Productos.FocusedItem.SubItems.Item(4).Text
            Lista_Productos.FocusedItem.Remove()
            NumeroProductos = NumeroProductos - 1
            'Comprueba el numero de productos. Si es 0, deshabilita los botones de confirmación y borrado y habilita el ComboBox de proveedores.
            If NumeroProductos = 0 Then
                btn_Borrar.Enabled = False
                btn_Confirmar.Enabled = False
                cmb_proveedor.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("No existe ningún elemento en la lista de la compra o no ha sido seleccionado.")
        End Try
    End Sub


    Private Sub ComprobarPedidoTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComprobarPedidoTimer.Tick
        Try
            ComprobarPedidoTimer.Enabled = False
            ComprobarPedidoAuto()
            fm_Venta.conectarPedidos()
            fm_Venta.MostrarPedidos()
            ComprobarPedidoTimer.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
            If (Con.State = ConnectionState.Open) Then
                Con.Close()
            End If
        End Try
    End Sub
End Class