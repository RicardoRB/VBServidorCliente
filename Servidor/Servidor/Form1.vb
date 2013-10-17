Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Net.Mail

Public Class Form1

    Dim wd As Word.Application
    Dim wdoc As Word.Document
    Dim rng As Word.Range
    Dim rutaword As String
    Dim archivosalida As String
    Dim productoslista As Integer
    Dim Con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath.ToString & "\..\..\..\..\Empresa_Aula.accdb")
    Dim Adap As OleDbDataAdapter
    Dim DS As New DataSet("DatosEmpresa")
    Dim Tabla As New DataTable
    Dim Consulta As String
    Dim Ruta As String
    Dim NumeroProductos As Integer
    Dim total As Double
    Dim nombre As String
    Dim rnd As Random = New Random
    Dim Transporte As String
    Dim numPedidos As Integer
    Dim DSA As New DataSet
    Dim DSAA As New DataSet
    Dim conIVA As Double
    Dim cli_cif As String
    Dim num_pedi As Integer
    Dim DSS As New DataSet
    Dim EmailOrigen As String
    Dim EmailDestino As String
    Dim archivosalida_al As String
    Dim archivosalida_fa As String
    Dim EmailOrigen_a As String
    Dim EmailDestino_a As String



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer_Ventas.Interval = 1000 * rnd.Next(1, 30)
        Timer_Ventas.Enabled = True

        Timer_Pedidos.Interval = 1000 * rnd.Next(1, 30)
        Timer_Pedidos.Enabled = True
        BorrarLista()
    End Sub

    Private Sub GuardarDatos()
        Try
            'Guardamos los datos de origen de nuestro pedido (en este caso, el Email)
            Consulta = "SELECT Email FROM EMP_GESTION WHERE NOMBRE = 'MediaMarkt'"
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Dim ds As New DataSet("NombreEMP")
            Con.Open()
            adap.Fill(ds, "NombreEMP")

            Con.Close()

            Dim Registros As DataRowCollection = ds.Tables("NombreEMP").Rows

            EmailOrigen = Registros.Item(0).Table.Rows(0).Item(0)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SeleccionarEmpresa()
        Dim Consulta1 As String
        Dim Consulta2 As String
        Dim numeroproveedor As Integer

        Dim salir As Boolean = False
        Try
            'Para seleccionar nuestra empresa, primero tendremos que contar cuantas hay (incluyendonos)
            Consulta1 = "SELECT COUNT(Nombre) FROM EMP_GESTION"
            Dim adap2 As New OleDbDataAdapter(Consulta1, Con)
            Dim ds2 As New DataSet("NumeroEmpresas")
            Con.Open()
            adap2.Fill(ds2, "NumeroEmpresas")
            Con.Close()
            Dim Registros2 As DataRowCollection = ds2.Tables("NumeroEmpresas").Rows

            Dim rnd As Random = New Random
            'Una vez hecho esto, guardaremos la cantidad, restandole 1 (a nosotros mismos)
            Dim num As Integer = (Registros2.Item(0).Table.Rows(0).Item(0)) - 1
            'Despues, buscamos los nombres de todas las empresas que no sean la nuestra.
            Consulta2 = "SELECT Nombre FROM EMP_GESTION WHERE NOMBRE NOT LIKE 'MediaMarkt'"
            Dim adap As New OleDbDataAdapter(Consulta2, Con)
            Dim ds1 As New DataSet("NombreEmpresa")
            Con.Open()
            adap.Fill(ds1, "NombreEmpresa")
            Con.Close()
            Dim Registros As DataRowCollection = ds1.Tables("NombreEmpresa").Rows
            'con la cantidad, seleccionamos 1 al azar y obtenemos su nombre.
            numeroproveedor = rnd.Next(0, (num - 1))
            nombre = Registros.Item(0).Table.Rows(numeroproveedor).Item(0).ToString

        Consulta = "SELECT ARTICULO.Cod_Art, ARTICULO.Descripcion, ARTICULO.Precio_Compra FROM ARTICULO, EMP_TIENE_ART, EMP_GESTION WHERE ARTICULO.Cod_Art = EMP_TIENE_ART.Cod_Art AND EMP_TIENE_ART.CIF = EMP_GESTION.CIF_NIF AND EMP_GESTION.NOMBRE = '" + nombre + "'"

        Catch ex As Exception
            MsgBox("Error. No se ha podido acceder a la BD.")
        End Try

        Try
            'Hecho esto, obtenemos sus artículos.
            Dim adap3 As New OleDbDataAdapter(Consulta, Con)
            Dim ds3 As New DataSet("Articulos")
            Con.Open()
            adap3.Fill(ds3, "Articulos")
            dg_ArticulosP.DataSource = ds3
            dg_ArticulosP.DataMember = "Articulos"

            Con.Close()


        Catch ex As Exception
            MsgBox("Error. No se ha podido acceder a la BD.")
        End Try
    End Sub


    Private Sub SeleccionarArticulos()
        Dim rnd As Random = New Random
        Dim numeroproductos As Integer
        Dim cantidad As Integer
        Dim producto As Integer
        Dim columnastotal As Integer
        Dim items As ListViewItem
        Dim precio As Double

        Dim Encontrado As Boolean
        'Para seleccionar un artículo al azar, usaremos el mismo método que para seleccionar el proveedor:
        'contaremos el numero de articulos.
        Consulta = "SELECT COUNT(ARTICULO.Cod_Art) FROM ARTICULO, EMP_TIENE_ART, EMP_GESTION WHERE ARTICULO.Cod_Art = EMP_TIENE_ART.Cod_Art AND EMP_TIENE_ART.CIF = EMP_GESTION.CIF_NIF AND EMP_GESTION.NOMBRE = '" + nombre + "'"
        Dim adap2 As New OleDbDataAdapter(Consulta, Con)
        Dim ds2 As New DataSet("NumeroArticulos")
        Con.Open()
        adap2.Fill(ds2, "NumeroArticulos")
        Con.Close()
        Dim Registros2 As DataRowCollection = ds2.Tables("NumeroArticulos").Rows

        Dim numproductos As Integer = Registros2.Item(0).Table.Rows(0).Item(0)
        'Decidiremos un numero de productos al azar (siempre entre 1 y numproductos - 1)
        numeroproductos = rnd.Next(1, (numproductos - 1))
        'Y para cada uno de ellos, seleccionaremos uno al azar de la lista y una cantidad al azar, puesta entre 1 y 10 (podríamos haber puesto mas, pero pensamos que un máximo de 10 unidades de cada por pedido era razonable.)
        For i = 0 To numeroproductos
            producto = rnd.Next(0, (numproductos - 1))
            cantidad = rnd.Next(1, 10)
            'Si ya hay productos en la lista, comprobamos si ya está en ella.
            If productoslista > 0 Then
                For j = 0 To productoslista - 1
                    'Si lo está, lo incrementamos, tanto su número como su precio.
                    If dg_ArticulosP.Rows(producto).Cells.Item(0).Value = Lista_Productos.Items.Item(j).SubItems.Item(0).Text Then
                        Lista_Productos.Items.Item(j).SubItems.Item(3).Text = Lista_Productos.Items.Item(j).SubItems.Item(3).Text + cantidad
                        Lista_Productos.Items.Item(j).SubItems.Item(4).Text = Lista_Productos.Items.Item(j).SubItems.Item(4).Text + (Lista_Productos.Items.Item(j).SubItems.Item(2).Text * cantidad)
                        Encontrado = True
                    End If
                Next
                'Si no está, se añade a la lista.
                If Encontrado = False Then
                    columnastotal = dg_ArticulosP.ColumnCount

                    items = Lista_Productos.Items.Add(dg_ArticulosP.Rows(producto).Cells.Item(0).Value)

                    For j = 1 To columnastotal - 1
                        items.SubItems.Add(dg_ArticulosP.Rows(producto).Cells.Item(j).Value)
                        If j = columnastotal - 1 Then
                            precio = dg_ArticulosP.Rows(producto).Cells.Item(j).Value
                        End If
                    Next

                    items.SubItems.Add(cantidad)
                    items.SubItems.Add(precio * cantidad)

                    productoslista = productoslista + 1
                End If
                'Si no está en la lista, se añade.
            Else
                columnastotal = dg_ArticulosP.ColumnCount

                items = Lista_Productos.Items.Add(dg_ArticulosP.Rows(producto).Cells.Item(0).Value)

                For j = 1 To columnastotal - 1
                    items.SubItems.Add(dg_ArticulosP.Rows(producto).Cells.Item(j).Value)
                    If j = columnastotal - 1 Then
                        precio = dg_ArticulosP.Rows(producto).Cells.Item(j).Value
                    End If
                Next

                items.SubItems.Add(cantidad)
                items.SubItems.Add(precio * cantidad)
                'Si se añade un producto a la lista, se incrementa el numero de preductos diferentes en la lista.
                productoslista = productoslista + 1
            End If
        Next

    End Sub


    Private Sub BorrarLista()
        'Borramos la lista.
        Lista_Productos.Clear()
        'Creamos las cabeceras.
        Lista_Productos.Columns.Add("Codigo", 100, HorizontalAlignment.Center)
        Lista_Productos.Columns.Add("Nombre", 100, HorizontalAlignment.Center)
        Lista_Productos.Columns.Add("Precio/unidad", 100, HorizontalAlignment.Center)
        Lista_Productos.Columns.Add("Cantidad", 100, HorizontalAlignment.Center)
        Lista_Productos.Columns.Add("Precio total", 100, HorizontalAlignment.Center)
        'Definimos las propiedades.
        Lista_Productos.View = View.Details
        Lista_Productos.GridLines = True
        Lista_Productos.FullRowSelect = True
        Lista_Productos.HideSelection = False
        Lista_Productos.MultiSelect = False
        'Reiniciamos el numero de productos en la lista.
        NumeroProductos = 0

    End Sub

    Private Sub GuardarPedido()
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
            'Primero obtenemos los datos del cliente.
            Consulta1 = "SELECT CIF_NIF, Plazo_entrega, Portes, Email FROM EMP_GESTION WHERE Nombre = '" + nombre + "'"
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
            'Guardamos los datos necesarios para el documento
            NumRegistros = Registros2.Item(0).Table.Rows(0).Item(0) + 1

            PlazoEntrega = Registros.Item(0).Table.Rows(0).Item(1)

            EmailDestino = Registros.Item(0).Table.Rows(0).Item(3)

            Portes = Registros.Item(0).Table.Rows(0).Item(2)
            PrecioPortes = Portes.Substring(0, Portes.IndexOf("-"))
            TipoPortes = Portes.Substring((Portes.IndexOf("-") + 1), (Portes.Length - 1) - PrecioPortes.Length)

            dias = PlazoEntrega.Substring(0, PlazoEntrega.IndexOf("-"))
            condiciones = PlazoEntrega.Substring((PlazoEntrega.IndexOf("-") + 1), ((PlazoEntrega.Length - 1) - (dias.Length)))

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
            'Modificamos la tabla de Pedidos de la BD.
            Insercion = "INSERT INTO PEDIDO VALUES (" + NumRegistros + ", 'P2233645X', '" + DateString + "', 'La misma', '" + fecha + "', '" + Transporte + "', '" + Registros.Item(0).Table.Rows(0).Item(0) + "', 1000, 0)"

            Con.Open()
            Comando.CommandText = Insercion
            Comando.CommandType = CommandType.Text
            Comando.Connection = Con
            Cuantos = Comando.ExecuteNonQuery

            Comando.Dispose()
            Comando = Nothing
            Con.Close()
            'Modificamos la tabla Art_Contiene de la BD
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
            'Generamos el documento
            Try
                GuardarDoc(NumRegistros, fecha)
            Catch ex As Exception
                MsgBox("Error. No se pudo generar el documento.")
            End Try
            'Enviamos el documento por correo electrónico
            GuardarDatos()
            EnviarCorreoPedido()
            'Reiniciamos la lista
            productoslista = 0
            BorrarLista()
        Catch ex As Exception
            MsgBox("Error. Pedido cancelado.")
        End Try
    End Sub

    Private Sub enviar_correo()
        Try
            Dim archivo_al As New Attachment(archivosalida_al)
            Dim archivo_fa As New Attachment(archivosalida_fa)
            Dim origen As New MailAddress(EmailOrigen_a)
            Dim usuario As String = EmailOrigen_a
            Dim pass As String = "Alumnodam2"

            Dim destino As MailAddress = Nothing
            Dim dsdestino As DataSet = Nothing

            destino = New MailAddress(EmailDestino_a)
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

    Private Sub EnviarCorreoPedido()
        Try
            'Declaramos el archivo de salida, el email de origen, el nombre del usuario y la pass
            Dim archivo As New Attachment(archivosalida)
            Dim origen As New MailAddress(EmailOrigen)
            Dim usuario As String = EmailOrigen
            Dim pass As String = "Alumnodam2"
            'Declaramos el email de destion
            Dim destino As MailAddress = Nothing
            Dim dsdestino As DataSet = Nothing
            'Generamos el mensaje a enviar.
            destino = New MailAddress(EmailDestino)
            Dim mensaje As New MailMessage
            'Añadimos el destinatario, el remitente, el tema, el cuerpo del mensaje y el archivo adjunto.
            mensaje.To.Add(destino)
            mensaje.From = origen
            mensaje.Subject = "Pedido Trabajo Richy y Alban"
            mensaje.Body = "<p><font color=" & "#FF0000" & ">Tienes un pedido  </font><font color=" & "#0000FF" & ">nuevo</font></p>"
            mensaje.Attachments.Add(archivo)
            'Creamos las credenciales de envio y lo enviamos.
            mensaje.IsBodyHtml = True
            Dim cliente As New System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
            cliente.EnableSsl = True
            cliente.Credentials = New System.Net.NetworkCredential(usuario, pass)
            cliente.Send(mensaje)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GuardarDoc(ByVal NumRegistros As String, ByVal fecha As String)

        Dim Consulta1 As String
        'Obtenemos los datos del cliente
        Consulta1 = "SELECT * FROM EMP_GESTION WHERE Nombre = '" + nombre + "'"
        Dim adap As New OleDbDataAdapter(Consulta1, Con)
        Dim ds1 As New DataSet("DatosEmpresa")
        Con.Open()
        adap.Fill(ds1, "DatosEmpresa")
        Con.Close()
        Dim Registros As DataRowCollection = ds1.Tables("DatosEmpresa").Rows
        'Obtenemos la ruta del archivo de origen y del archivo de salida para el pedido
        rutaword = Application.StartupPath.ToString & "\..\..\..\..\Documentos\Pedido_MediaMarkt.docx"
        archivosalida = Application.StartupPath.ToString & "\..\..\..\..\Documentos\Pedido_MediaMarkt_salida_" + NumRegistros + ".docx"
        'Creamos una nueva aplicación Word y Documento Word.
        wd = New Word.Application
        wdoc = New Word.Document
        'Abrimos la aplicación en modo invisible y el documento.
        Try
            wd.Visible = False
            wdoc = wd.Documents.Open(rutaword, System.Reflection.Missing.Value, True)
        Catch ex As Exception
            MsgBox("Error: No se ha podido abrir el documento.")
        End Try

        'Añadimos todos los datos al documento
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
        rng.Text = nombre

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
        End Try

        'Guardamos los cambios
        Try
            wdoc.SaveAs(archivosalida)
        Catch ex As Exception
            MsgBox("Error. No se pudo salvar el documento nuevo.")
        End Try

        If archivosalida <> Nothing Then
            wdoc.Close()
            wdoc = Nothing
        End If

        MatarProcesoWord()

    End Sub

    Private Sub GuardarProducto()
        'Almacenamos los productos en el documento del pedido.
        Dim suma As Double
        Try
            For i = 0 To productoslista - 1

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

    Private Sub Timer_Pedidos_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Pedidos.Tick
        Timer_Pedidos.Enabled = False
        Timer_Ventas.Enabled = False
        SeleccionarEmpresa()
        SeleccionarArticulos()
        GuardarPedido()
        Timer_Pedidos.Interval = 1000 * rnd.Next(1, 30)
        Timer_Pedidos.Enabled = True
        Timer_Ventas.Enabled = True
    End Sub


    Private Sub Timer_Ventas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Ventas.Tick
        Timer_Ventas.Enabled = False
        Timer_Pedidos.Enabled = False
        conectarPedidos()
        seleccionarPedido()
        'Comprobar que el pedido seleccionado aleatoriamente tiene articulos
        If dg_Articulos.RowCount > 0 Then
            confirmaPedido()
        End If
        Timer_Ventas.Interval = 1000 * rnd.Next(1, 30)
        Timer_Ventas.Enabled = True
        Timer_Pedidos.Enabled = True
    End Sub

    Public Sub conectarPedidos()
        Dim Consulta As String
        Try
            Consulta = "SELECT * FROM PEDIDO p WHERE Prov_CIF = 'P2233645X' AND Tramitado = " & False & ""
            Dim adap As New OleDbDataAdapter(Consulta, Con)
            Con.Open()
            adap.Fill(DS, "DS_PEDIDO")
            Con.Close()
            MostrarPedidos()

            Consulta = "SELECT COUNT(Num_ped) FROM PEDIDO p WHERE Prov_CIF = 'P2233645X' AND Tramitado = " & False & ""
            Dim adap1 As New OleDbDataAdapter(Consulta, Con)
            Con.Open()
            adap1.Fill(DS, "DS_PEDIDOCOUNT")
            Con.Close()
            Dim Registros As DataRowCollection = DS.Tables("DS_PEDIDOCOUNT").Rows

            numPedidos = (Registros.Item(0).Table.Rows(0).Item(0))
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Public Sub MostrarPedidos()
        Try
            dg_Pedidos.DataSource = DS
            dg_Pedidos.DataMember = "DS_PEDIDO"
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub seleccionarPedido()
        Dim rnd As New Random
        If numPedidos > 0 Then
            num_pedi = rnd.Next(0, (numPedidos - 1))
            cli_cif = dg_Pedidos.Rows(num_pedi).Cells.Item(1).Value
            num_pedi = dg_Pedidos.Rows(num_pedi).Cells.Item(0).Value
            conectarArticulos(num_pedi)
            MostrarArticulos()
        End If
    End Sub

    Public Sub conectarArticulos(ByVal num_pe As String)
        Dim Consulta As String
        Try
            Consulta = "SELECT a.Cod_art, a.Descripcion, ac.Cantidad " &
                        "FROM PEDIDO p, ART_CONTIENE ac, ARTICULO a " &
                        "WHERE p.Num_ped = " & num_pedi & " AND ac.Tipo = 'Pedido' AND ac.Num_Doc = p.Num_ped AND ac.Cod_art = a.Cod_Art AND p.Tramitado = " & False & ""
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
            dg_Articulos.DataSource = DSA
            dg_Articulos.DataMember = "DS_ARTICULO"
        Catch ex As Exception
            MsgBox(ex.Message)
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
        End Try
    End Sub

    Private Sub confirmaPedido()
        Try
            Dim Consulta As String
            Dim Comando As New OleDbCommand
            Dim max_albaran As Integer
            Dim impor_to As Double = 0
            Dim max_num_factura As Integer

            Consulta = "SELECT Plazo_entrega, Cond_Pago, Descuentos,Email FROM EMP_GESTION WHERE CIF_NIF = 'P2233645X'"
            Dim ds1 As New DataSet("DS_PLAZO")
            Dim adap1 As New OleDbDataAdapter(Consulta, Con)
            adap1.Fill(ds1, "DS_PLAZO")
            Dim Registros As DataRowCollection = ds1.Tables("DS_PLAZO").Rows

            'Ligamos el email del origen del apartado ventas
            EmailOrigen_a = Registros.Item(0).Table.Rows(0).Item(3)

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

            InsertarAlbaran(Consulta, Comando, max_albaran, impor_to, Registros.Item(0).Table.Rows(0).Item(2))

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
            enviar_correo()
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
            EmailDestino_a = ds1.Tables("DatosEmpresa").Rows.Item(0).Table.Rows(0).Item(7)
            Con.Close()
            Dim Registros As DataRowCollection = ds1.Tables("DatosEmpresa").Rows
            Dim rutaword As String = Application.StartupPath.ToString & "\..\..\..\..\Documentos\Albaran_MediaMarkt.docx"
            Dim archivosalida As String = Application.StartupPath.ToString & "\..\..\..\..\Documentos\Albaran_MediaMarkt_salida_" + num_pedi.ToString + ".docx"
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
            Dim rutaword As String = Application.StartupPath.ToString & "\..\..\..\..\Documentos\Factura_MediaMarkt.docx"
            Dim archivosalida As String = Application.StartupPath.ToString & "\..\..\..\..\Documentos\Factura_MediaMarkt_salida_" + num_pedi.ToString + ".docx"
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
            DSS.Clear()

            'Este bucle sirve para meter en el albaran cada articulo con su precio
            'Y sumar el precio total
            'Tambien para quitar los productos del stock y sumarlos
            For i = 0 To dg_Articulos.RowCount - 1
                Consulta = "SELECT Precio_venta FROM ARTICULO WHERE Cod_Art = '" & dg_Articulos.Rows(i).Cells.Item(0).Value & "'"
                Dim adap1 As New OleDbDataAdapter(Consulta, Con)
                adap1.Fill(DSAA, "DS_PRECIO")
                precio_to_uni = dg_Articulos.Rows(i).Cells.Item(2).Value * DSAA.Tables("DS_PRECIO").Rows.Item(0).Table.Rows(i).Item(0)

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

                Consulta = "SELECT stock " &
                            "FROM emp_tiene_art " &
                            "WHERE CIF = '" & cli_cif & "'" &
                            "AND Cod_Art = '" & dg_Articulos.Rows(i).Cells.Item(0).Value & "'"
                Dim adap3 As New OleDbDataAdapter(Consulta, Con)
                Con.Open()
                adap3.Fill(DSS, "DS_STOCKSUMA")

                'Se le suma al stock al cliente
                Consulta = "UPDATE EMP_TIENE_ART SET Stock = " & DSS.Tables("DS_STOCKSUMA").Rows.Item(0).Table.Rows(i).Item(0) + dg_Articulos.Rows(i).Cells.Item(2).Value & " WHERE CIF = '" & cli_cif & "' AND Cod_Art = '" & dg_Articulos.Rows(i).Cells.Item(0).Value & "'"
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
    Private Sub InsertarAlbaran(ByVal Consulta As String, ByVal Comando As OleDbCommand, ByVal max_albaran As Integer, ByRef impor_to As Double, ByVal descuento As Integer)
        Try
            Dim CadenaInsert As String
            'Calculamos con un bucle el importe total de los articulos que tenemos
            For i = 0 To dg_Articulos.RowCount - 1
                Consulta = "SELECT Precio_venta FROM ARTICULO WHERE Cod_Art = '" & dg_Articulos.Rows(i).Cells.Item(0).Value & "'"
                Dim adap As New OleDbDataAdapter(Consulta, Con)
                adap.Fill(DSAA, "DS_PRECIO")
                impor_to = impor_to + DSAA.Tables("DS_PRECIO").Rows.Item(0).Table.Rows(i).Item(0) * dg_Articulos.Rows(i).Cells.Item(2).Value
            Next

            'Aqui se calcula con el iva
            conIVA = impor_to + (impor_to * 0.21)
            conIVA = conIVA - (conIVA * (descuento / 100))

            'Inserccion de los datos a la tabla ALBARAN
            Con.Open()
            CadenaInsert = "INSERT INTO ALBARAN Values (" & max_albaran & "," & num_pedi & ",'" & cli_cif & "','P2233645X'," & conIVA.ToString.Replace(",", ".") & ") "
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
        Try
            Dim CadenaInsert As String
            Dim fecha As String
            Dim dias As String
            Dim PlazoEntrega As String
            Dim condiciones As String
            Dim transporte As String
            Dim dias_tran As Integer

            PlazoEntrega = Registros.Item(0).Table.Rows(0).Item(0)
            dias = PlazoEntrega.Substring(0, PlazoEntrega.IndexOf("-"))
            fecha = DateAdd(DateInterval.Day, CInt(dias), Date.Today)
            condiciones = Registros.Item(0).Table.Rows(0).Item(1)
            transporte = Registros.Item(0).Table.Rows(0).Item(0)
            dias_tran = transporte.Substring(0, PlazoEntrega.IndexOf("-"))

            'Insercion de los datos a la tabla FACTURA
            Con.Open()
            CadenaInsert = "INSERT INTO FACTURA Values (" & max_num_factura & "," & max_albaran & ",'P2233645X','" & cli_cif & "','" & Date.Today & "','" & fecha & "','" & condiciones & "'," & dias_tran & "," & conIVA.ToString.Replace(",", ".") & "," & impor_to.ToString.Replace(",", ".") & ") "
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
        Try
            Dim CadenaInsert As String
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
End Class
