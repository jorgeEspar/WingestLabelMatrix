Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Net
Imports System.IO.FileStream
Imports System.Text
Imports System.Drawing.Printing
Imports System.Globalization

Public Class FrmInicio
    Public dtErrores As DataTable
    Public FrmConfiguracion As FrmConfiguracion = New FrmConfiguracion()
    Public obcomun As ObjComunes = New ObjComunes()
    Public objSQLServerWingest As ComSQLServerWingest = New ComSQLServerWingest()
    Public objAccess As ComAccessWingest = New ComAccessWingest()
    Public swhora As Boolean = False
    Public SWEditConfiguración As Boolean = False ' para indicar si la ventana de Configuración está abierta para no realizar la transferencia hasta que el usuario guarde la configuración
    Public a_actualizar As Date
    Public Shared config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
    'Public Shared config As Configuration '= ConfigurationManager.OpenMappedExeConfiguration(New ExeConfigurationFileMap("App.config"), ConfigurationUserLevel.None)
    Public Shared FirstInit As Boolean = True
    Public Shared swConexWingest As Boolean = False ' para saber si la BBDD Wingest local está conectada
    Public Shared swConexAccess As Boolean = False ' para saber si la BBDD Access está conectada
    Public versionesSQL_Server() As String = {"7"}

    Public ModoTest As Boolean = False
    Public fs As FileStream
    Public FormatoFechaSQLServer As String = ""
    Public args As String()

    '*** NOMBRE DEL FICHERO DE ACCESS CON LOS DATOS DE WINGEST DE LOS AÑOS 2014 Y 2015 ***
    Public FicheroAccess As String = "etiquetas_pedidos.mdb" '"etiquetas_pedidos.accdb"

    Private Dirraiz As String = Application.StartupPath
    Private PrimeraCarga As Boolean = True

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridPedido.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridPedido.EditMode = DataGridViewEditMode.EditProgrammatically

        DataGridPedido.AllowUserToAddRows = False
        DataGridPedido.AllowUserToDeleteRows = False
        DataGridPedido.AllowUserToOrderColumns = False
        DataGridPedido.ReadOnly = False
        DataGridPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridPedido.MultiSelect = False
        DataGridPedido.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        DataGridPedido.AllowUserToResizeColumns = True
        DataGridPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridPedido.AllowUserToResizeRows = False

        'txtNumPed.Text = "3856" '"3860"

        txtNumPed.Focus()

    End Sub

    Private Sub FrmInicio_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        args = Environment.GetCommandLineArgs()

        Dim i As Integer = 1

        Dim ComsOK As Boolean = False
        Try
            Me.Text = "DIPLAN - Impresión de Etiquetas Label Matrix"

            Dim fileMap As ExeConfigurationFileMap = New ExeConfigurationFileMap()
            Dim mipathAppconfig As String = Application.StartupPath & "\App.config"
            fileMap.ExeConfigFilename = mipathAppconfig  ' relative path names possible
            ' Open another config file
            config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None)

            ' Comprobar si es Instalación Inicial y si es así, abrir ventana configuración
            Dim xInstInicial As String = config.AppSettings.Settings.Item("FirstInit").Value
            If xInstInicial = "0" Then
                FirstInit = True ' es la primera ejecución
                Configuracion_Inicial_Appconfig()
            Else
                FirstInit = False
            End If

            FrmConfiguracion.cargaform()

            dtErrores = CargaTablaErrores()

            'lblEmpresa.Text = config.AppSettings.Settings.Item("NombreEmpresa").Value
            'Me.Text = Me.Text & " - " & config.AppSettings.Settings.Item("NombreEmpresa").Value

            If config.AppSettings.Settings.Item("Ejercicio").Value.ToString.Trim() = "" Then
                config.AppSettings.Settings.Item("Ejercicio").Value = Now.Year.ToString()
                config.Save(ConfigurationSaveMode.Modified)
                ''My.Settings.Save()
            End If
            tbxEjercicio.Text = config.AppSettings.Settings.Item("Ejercicio").Value.ToString
            ConfigurationManager.RefreshSection("appSettings")

            obcomun.ActivarDesactivar_Controles_FrmInicio(True)

            If FirstInit = False Then
                '//-> Comprobar conexiones MySQL y FoxPRo <-\\
                ComsOK = CompruebaComunicaciones()
            End If

            '-------------------------
            '--- Leer configuracion ---
            '-------------------------
            CargaConfiguracion()

            'Me.CargaError("Proceso", "1", "2548788", "Cuando se agrega un objeto a la colección, de ListBox comprueba primero para ver si la propiedad de DisplayMember de la clase de ListControl tiene el nombre de un miembro del objeto")

            If ComsOK = False Or FirstInit = True Then
                FrmConfiguracion.ShowDialog()
            Else
                Carga_Canales()
            End If

            txtNumPed.Focus()

        Catch ex As Exception
            Dim msg As String = ex.Message
            MessageBox.Show("Error: " & msg)
        End Try

        PrimeraCarga = False
    End Sub

    ' Si es instalacion nueva, configurar inicial de App.config
    Private Sub Configuracion_Inicial_Appconfig()
        config.AppSettings.Settings.Item("NombreEmpresa").Value = "Albatros-Informática"
        config.AppSettings.Settings.Item("Versionwingest").Value = "7"
        Dim anno As String = Now.Year.ToString
        If anno.Length > 2 Then anno = Now.Year.ToString().Substring(2, 2)
        config.AppSettings.Settings.Item("ServidorSQLServerWingest").Value = ""
        config.AppSettings.Settings.Item("UserSQLServerWingest").Value = ""
        config.AppSettings.Settings.Item("PwdSQLServerWingest").Value = ""
        config.AppSettings.Settings.Item("PortSQLServerWingest").Value = "1433"
        config.AppSettings.Settings.Item("DataBaseSQLServerWingest").Value = "wgdemo"
        config.AppSettings.Settings.Item("FirstInit").Value = "0"
        config.AppSettings.Settings.Item("FormatFecha_SqlServer").Value = "yyyy-dd-MM"
        config.AppSettings.Settings.Item("FormatNumer_Importes_Excel").Value = "#.##0,00"
        config.AppSettings.Settings.Item("FormatNumer_Cantidades_Excel").Value = "#.##0"

        config.AppSettings.Settings.Item("CodArticulosLabelMatrix").Value = "48."
        config.AppSettings.Settings.Item("PathEtiquetasLabelMatrix").Value = ""
        config.AppSettings.Settings.Item("FicheroAccessEtiquetas").Value = ""
        config.AppSettings.Settings.Item("Canal").Value = ""
        config.AppSettings.Settings.Item("Ejercicio").Value = Year(Now).ToString()
        config.AppSettings.Settings.Item("PathEtiquetasLabelMatrixOriginal").Value = ""
        config.AppSettings.Settings.Item("PathProgramaLabelMatrix").Value = ""
        config.AppSettings.Settings.Item("MostrarVentanaMSDos").Value = "N"
        config.AppSettings.Settings.Item("ModoImpresionEtiquetas").Value = "1"
        FrmInicio.config.AppSettings.Settings.Item("TiempoEsperaEntreEtiquetas").Value = "3"

        config.Save(ConfigurationSaveMode.Full)
        ConfigurationManager.RefreshSection("appSettings")
    End Sub

    '//-> Comprobar conexiones MySQL y FoxPRo o SQL-Server<-\\
    Public Function CompruebaComunicaciones() As Boolean
        Dim msgwingest As String = String.Empty
        Dim msgaccess As String = String.Empty

        chkConectadoWingest.Checked = False
        chkConectadoAccess.Checked = False

        Dim ComsOK As Boolean = True
        swConexWingest = False
        swConexAccess = False

        Semaforowingest.Image = My.Resources.bola_roja 'Image.FromFile(Path.Combine(dir, "\images\luzroja.gif"))
        SemaforoAccess.Image = My.Resources.bola_roja
        Application.DoEvents()

        Try
            Dim conSQLServerWingest As SqlConnection
            conSQLServerWingest = objSQLServerWingest.Conectar()
            If conSQLServerWingest.State = ConnectionState.Open Then
                swConexWingest = True
                Semaforowingest.Image = My.Resources.bola_verde
                chkConectadoWingest.Checked = True
                objSQLServerWingest.Desconectar()
                chkConectadoWingest.Checked = True
            Else
                ComsOK = False
            End If
        Catch ex As Exception
            ComsOK = False
            msgwingest = "Error conexión a Wingest: " & ex.Message & vbCrLf
        End Try

        Dim conAccess As OleDbConnection

        Try
            conAccess = objAccess.Conectar()
            chkConectadoAccess.Checked = True
            swConexAccess = True
            SemaforoAccess.Image = My.Resources.bola_verde

        Catch ex As Exception
            ComsOK = False
            msgaccess = "Error conexión a Base datos Access: " & ex.Message & vbCrLf
        End Try
        Try
            objAccess.Desconectar()
        Catch ex As Exception

        End Try
        Dim msg As String
        msg = msgwingest & msgaccess
        If msg <> String.Empty Then
            MessageBox.Show(msg, "Error comunicaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Return ComsOK
    End Function

    Private Sub CargaConfiguracion()
        FormatoFechaSQLServer = config.AppSettings.Settings.Item("FormatFecha_SqlServer").Value.ToString
    End Sub

    Private Sub FrmInicio_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ' Display a MsgBox asking the user to save changes or abort.
        If MessageBox.Show("¿ Desea SALIR del programa ?", "Salir del programa", MessageBoxButtons.YesNo) = DialogResult.No Then
            ' Cancel the Closing event from closing the form.
            e.Cancel = True
        End If ' Call method to save file...
    End Sub 'Form1_Closing
#Region "Tratamiento de errores"
    Private Function CargaTablaErrores() As DataTable
        Dim dt As New DataTable("TablaErrores")

        Dim column As DataColumn = New DataColumn
        column.DataType = System.Type.GetType("System.Int16")
        column.AllowDBNull = True
        column.Caption = ""
        column.ColumnName = "Gravedad"
        column.DefaultValue = 0 '0 = Aviso, 1 = error leve, 2 = error grave
        dt.Columns.Add(column)

        Dim column0 As DataColumn = New DataColumn
        column0.DataType = System.Type.GetType("System.String")
        column0.AllowDBNull = True
        column0.Caption = "Proceso"
        column0.ColumnName = "Proceso"
        column0.DefaultValue = 100
        dt.Columns.Add(column0)

        Dim column1 As DataColumn = New DataColumn
        column1.DataType = System.Type.GetType("System.String")
        column1.AllowDBNull = True
        column1.Caption = "Error_Num"
        column1.ColumnName = "Error_Num"
        column1.DefaultValue = 40
        dt.Columns.Add(column1)

        Dim column2 As DataColumn = New DataColumn
        column2.DataType = System.Type.GetType("System.String")
        column2.AllowDBNull = True
        column2.Caption = "Des_Error"
        column2.ColumnName = "Des_Error"
        column2.DefaultValue = 40
        dt.Columns.Add(column2)

        Return dt
    End Function
    Public Sub CargaError(ByVal Proceso As String, ByVal gravedad As Integer, ByVal Error_num As String, ByVal meserror As String)
        Dim row As DataRow

        row = dtErrores.NewRow()
        row("Gravedad") = gravedad
        row("Proceso") = Proceso
        row("Error_Num") = Error_num
        row("Des_Error") = meserror

        dtErrores.Rows.Add(row)
    End Sub
    Public Sub LimpiaTablaErrores()
        dtErrores.Clear()
    End Sub
#End Region

    '----------------------
    '-- OPCIONES DE MENU --
    '----------------------
#Region "OPCIONES DE MENÚ"
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        If (MsgBox("¿ Desea salir del programa ?", MsgBoxStyle.YesNo, "Salir del programa")) = MsgBoxResult.Yes Then
            Application.Exit()
        End If
    End Sub
    Private Sub ConfiguraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraciónToolStripMenuItem.Click
        FrmConfiguracion.ShowDialog()
    End Sub
#End Region '"OPCIONES DE MENU"

#Region "funciones Varias"
    Private Sub centrar_ventana()
        Dim ancho_ventana As Long = 0
        Dim alto_ventana As Long = 0
        Dim warea As System.Drawing.Rectangle = Screen.PrimaryScreen.WorkingArea
        ancho_ventana = warea.Width
        alto_ventana = warea.Height
        Me.Left = ancho_ventana / 2 - Me.Width / 2
        Me.Top = alto_ventana / 2 - Me.Height / 2

        'ReportViewer1.Width = Me.Width '- 10
        'ReportViewer1.Height = Me.Height '- ReportViewer1.Top - 20
    End Sub
    Private Sub actualiza_ventana()
        Dim ancho_ventana As Long = 0
        Dim alto_ventana As Long = 0
        Dim warea As System.Drawing.Rectangle = Screen.PrimaryScreen.WorkingArea
        ancho_ventana = warea.Width
        alto_ventana = warea.Height
        Me.Width = ancho_ventana
        Me.Height = alto_ventana

        'ReportViewer1.Width = Me.Width '- 10
        'ReportViewer1.Height = Me.Height '- ReportViewer1.Top - 20
    End Sub

    Private Sub Borrar_Fichero(ByVal fichero As String)
        If File.Exists(fichero) Then
            File.Delete(fichero)
        End If
    End Sub
    Private Sub CreaDirectorio_exportaciones()
        Dim directorio As String = My.Application.Info.DirectoryPath ' IO.Path.GetFullPath(Application.ExecutablePath)
        If Not Directory.Exists(directorio & "\exportaciones") Then
            Directory.CreateDirectory(directorio & "\exportaciones")
        End If
    End Sub

#End Region

    Private Sub FrmInicio_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState <> FormWindowState.Minimized Then
            'ReportViewer1.Width = Me.Width '- 10
            'ReportViewer1.Height = Me.Height - 90 '- ReportViewer1.Top - 20
        End If

    End Sub

    Public Sub BuscarPedido()
        Dim msg As String = ""
        txtFechaPedido.Text = ""
        txtCodcli.Text = ""
        txtNomcli.Text = ""

        BindingSource1.DataSource = ""
        DataGridPedido.DataSource = BindingSource1

        If txtNumPed.Text.Trim() = "" Then
            msg = "No ha indicado el Nº de Pedido"
        End If
        If ddlCanal.Items.Count = 0 Then
            msg = "No ha seleccionado el Canal"
        Else
            If ddlCanal.Items(ddlCanal.SelectedIndex).value = "" Then
                msg = "No ha seleccionado el Canal"
            End If
        End If
        If tbxEjercicio.Text = "" Then
            msg = "No ha indicado el Ejercicio"
        End If
        If msg <> "" Then
            MsgBox(msg, MsgBoxStyle.Critical, "Nº de Pedido")
        Else
            Try
                ToolStripStatuslbl.Text = "Seleccionando artículos pedido..."
                Dim can As String = ddlCanal.Items(ddlCanal.SelectedIndex).value  'config.AppSettings.Settings.Item("Canal").Value.ToString
                Dim eje As String = tbxEjercicio.Text 'config.AppSettings.Settings.Item("Ejercicio").Value.ToString
                Dim dt As New DataTable
                Application.DoEvents()

                obcomun.GetPedido(dt, txtNumPed.Text.Trim(), can, eje)
                ''dt = DT_Pedidos()

                If dt.Rows.Count = 0 Then
                    MsgBox("Nº de Pedido (" & txtNumPed.Text.Trim() & ") no encontrado en el Canal=" & can & " y Ejercicio=" & eje, MsgBoxStyle.Critical, "Pedido no encontrado")
                Else
                    Dim column As DataColumn = New DataColumn
                    column.DataType = System.Type.GetType("System.Int16")
                    column.AllowDBNull = True
                    column.Caption = ""
                    column.ColumnName = "CODESTADO"
                    column.DefaultValue = 0 '0 = PENDIENTE, 1 = PRINTING, 2 = IMPRESO, 3 = error
                    dt.Columns.Add(column)

                    Dim column0 As DataColumn = New DataColumn
                    column0.DataType = System.Type.GetType("System.String")
                    column0.AllowDBNull = True
                    column0.Caption = ""
                    column0.ColumnName = "ESTADO"
                    column0.DefaultValue = "PENDIENTE"
                    dt.Columns.Add(column0)

                    ''BindingSource1.DataSource = dt
                    ''DataGridPedido.DataSource = BindingSource1
                    'BindingSource1.RaiseListChangedEvents = True

                    Dim numfilas As Long = dt.Rows.Count
                    Dim numcolumnas As Integer = DataGridPedido.ColumnCount

                    If DataGridPedido.RowCount > 0 Then
                        Dim valor As String
                        Dim cfecha As Date
                        For i = 0 To dt.Rows.Count - 1
                            valor = "" & dt.Rows(i).Item("CODLOT").ToString().Trim()
                            dt.Rows(i).Item("CODLOT") = valor

                            valor = "" & dt.Rows(i).Item("FECCAD").ToString()
                            If valor <> "" Then
                                cfecha = CDate(valor)
                                dt.Rows(i).Item("FECCAD") = Format(cfecha, "dd/MM/yyyy")
                            End If
                        Next
                        txtFechaPedido.Text = Format(dt.Rows(0).Item("FECPED"), "dd/MM/yyyy")
                        txtNomcli.Text = dt.Rows(0).Item("DESCLI")
                        txtCodcli.Text = dt.Rows(0).Item("CODCLI")

                        BindingSource1.DataSource = dt
                        DataGridPedido.DataSource = dt 'BindingSource1

                        DataGridPedido.Rows(0).Selected = True
                        DataGridPedido.Focus()
                    Else
                        DataGridPedido.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                        DataGridPedido.AutoGenerateColumns = True

                        DataGridPedido.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
                        DataGridPedido.BorderStyle = BorderStyle.Fixed3D
                        DataGridPedido.EditMode = DataGridViewEditMode.EditProgrammatically
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error al cargar los datos del Pedido: " & ex.Message.ToString(), "Error datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            ToolStripStatuslbl.Text = "Seleccionados " & DataGridPedido.Rows.Count & " artículos."
        End If
    End Sub
    Private Sub btnBuscadorPedido_Click(sender As Object, e As EventArgs) Handles btnBuscadorPedido.Click
        BuscarPedido()

    End Sub

#Region "Eventos DataGridPedido"
    Private Sub DataGridPedido_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridPedido.DataBindingComplete
        Dim cuantos As Integer = DataGridPedido.RowCount
        Dim codcli As String = txtCodcli.Text
        Dim fichero_qdf As String
        Dim pos As String
        cuantos = DataGridPedido.Rows.Count

        If cuantos > 0 Then
            Dim PathEtiquetasNew As String = config.AppSettings.Settings.Item("PathEtiquetasLabelMatrix").Value
            Dim PathEtiquetasOld As String = config.AppSettings.Settings.Item("PathEtiquetasLabelMatrixOriginal").Value

            'modifica_ancho_grid()
            For Each row As DataGridViewRow In DataGridPedido.Rows
                'Dim btn As DataGridViewButtonCell = row.Cells()
                Dim codart As String = row.Cells(3).Value
                If codart <> "" Then
                    codart = codart.Trim()
                    pos = codart.IndexOf(".")
                    If pos > 0 Then codart = codart.Substring(pos + 1, codart.Length - (pos + 1))

                    fichero_qdf = PathEtiquetasNew & "\B" & codcli.PadLeft(4, "0") & codart.PadLeft(3, "0") & ".qdf"
                    row.Cells(10).ToolTipText = fichero_qdf
                    If File.Exists(fichero_qdf) Then
                        row.Cells(10).Value = My.Resources.bola_verde
                    Else
                        row.Cells(10).Value = My.Resources.bola_roja
                    End If

                    fichero_qdf = PathEtiquetasOld & "\B" & codcli.PadLeft(4, "0") & codart.PadLeft(3, "0") & ".qdf"
                    row.Cells(11).ToolTipText = fichero_qdf
                    If File.Exists(fichero_qdf) Then
                        row.Cells(11).Value = My.Resources.bola_verde
                    Else
                        row.Cells(11).Value = My.Resources.bola_roja
                    End If
                End If
            Next


        End If
    End Sub

    Private Sub DataGridPedido_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridPedido.CellValidating

    End Sub
    Private Sub DataGridPedido_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridPedido.EditingControlShowing
        Dim col As Integer = DataGridPedido.CurrentCell.ColumnIndex

        If col = 6 Or col = 7 Or col = 8 Or col = 11 Then
            Dim txtEdit As TextBox = e.Control

            Select Case col
                Case 6 ' cantidad
                    'remove any existing handler
                    RemoveHandler txtEdit.KeyPress, AddressOf TextboxNumeric_KeyPress
                    AddHandler txtEdit.KeyPress, AddressOf TextboxNumeric_KeyPress
                Case 7 ' Lote

                Case 8 ' fecha caducidad

                    'remove any existing handler
                    RemoveHandler txtEdit.KeyPress, AddressOf TextboxDate_KeyPress
                    AddHandler txtEdit.KeyPress, AddressOf TextboxDate_KeyPress
                Case 12 ' Botón Imprimir
                    'If e.Control Is Button Then

                    'Dim btn As Button = e.Control As Button
                    '    btn.Click -= New EventHandler(btn_Click)
                    '    btn.Click += New EventHandler(btn_Click)
                    'End If
            End Select

        End If
    End Sub
    Private Sub TextboxDate_KeyPress(sender As Object, e As KeyPressEventArgs)
        Console.WriteLine("KeyPress " & e.KeyChar.ToString())
        'Test for numeric value or backspace in first column
        'If DataGridPedido.CurrentCell.ColumnIndex = 8 Then
        If IsNumeric(e.KeyChar.ToString()) _
                Or e.KeyChar = ChrW(Keys.Back) _
                Or e.KeyChar = ChrW(Keys.Delete) _
                Or e.KeyChar = ChrW(Keys.End) _
                Or e.KeyChar = ChrW(Keys.Home) _
                Or e.KeyChar = ChrW(Keys.Left) _
                Or e.KeyChar = ChrW(Keys.Right) _
                Or e.KeyChar = "/" Then
                Console.WriteLine("KeyPress number")
                e.Handled = False 'if numeric display
            Else
                Console.WriteLine("Enter Numbers Only")
                e.Handled = True  'if non numeric don't display
            End If
        'End If
    End Sub

    Private Sub TextboxNumeric_KeyPress(sender As Object, e As KeyPressEventArgs)
        Console.WriteLine("KeyPress " & e.KeyChar.ToString())
        'Test for numeric value or backspace in first column
        'If DataGridPedido.CurrentCell.ColumnIndex = 6 Then
        If IsNumeric(e.KeyChar.ToString()) _
                Or e.KeyChar = ChrW(Keys.Back) _
                Or e.KeyChar = ChrW(Keys.Delete) _
                Or e.KeyChar = ChrW(Keys.End) _
                Or e.KeyChar = ChrW(Keys.Home) _
                Or e.KeyChar = ChrW(Keys.Left) _
                Or e.KeyChar = ChrW(Keys.Right) _
                Or e.KeyChar = "." Then
                Console.WriteLine("KeyPress number")
                e.Handled = False 'if numeric display
            Else
                Console.WriteLine("Enter Numbers Only")
                e.Handled = True  'if non numeric don't display
            End If
        'End If
    End Sub
    Private Sub DataGridPedido_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridPedido.CellContentClick
        'Dim senderGrid As DataGridView = DirectCast(sender, DataGridView)
        'If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
        If e.ColumnIndex = DataGridPedido.ColumnCount - 1 Then
                'TODO - Button Clicked - Execute Code Here
                Dim codcli As String = DataGridPedido.Rows(e.RowIndex).Cells(1).Value.ToString()
                Dim codart As String = DataGridPedido.Rows(e.RowIndex).Cells(3).Value.ToString()
                Dim cantidad As String = DataGridPedido.Rows(e.RowIndex).Cells(6).Value.ToString()
                Dim lote As String = DataGridPedido.Rows(e.RowIndex).Cells(7).Value.ToString()
                Dim FechaCaducidad As String = DataGridPedido.Rows(e.RowIndex).Cells(8).Value.ToString()

                '' AQUI formar el nombre del fichero etiqueta qdf y ejecutar el comando msdos para imprimir la etiqueta
                Dim fileqdf As String = codcli & codart & ".qdf"
            End If
    End Sub
    Private Sub DataGridPedido_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridPedido.CellClick
        If e.RowIndex >= 0 Then
            Dim col As Integer = DataGridPedido.CurrentCell.ColumnIndex

            If col = 6 Or col = 7 Or col = 8 Then
                Dim x As Long = DataGridPedido.Rows(e.RowIndex).Index
                'DataGridPedido.Rows(x).Selected = True

                Dim cell As DataGridViewCell = DataGridPedido(col, e.RowIndex)
                Select Case col
                    Case 6 'cantidad
                        'Dim c As DataGridTextBox = New DataGridTextBox
                        'c.Text = DataGridPedido.Rows(e.RowIndex).Cells(col).Value
                        'DataGridPedido("Choice", e.RowIndex) = c
                    Case 8 ' fecha caducidad
                        Dim oDateTimePicker = New DateTimePicker()

                        'Adding DateTimePicker control into DataGridView   
                        DataGridPedido.Controls.Add(oDateTimePicker)
                        ' Setting the format (i.e. 2014-10-10)  
                        oDateTimePicker.Format = DateTimePickerFormat.Short

                        oDateTimePicker.Text = cell.Value

                        ' It returns the retangular area that represents the Display area for a cell  
                        Dim oRectangle As Rectangle = DataGridPedido.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                        'Setting area for DateTimePicker Control  
                        oDateTimePicker.Size = New Size(oRectangle.Width, oRectangle.Height)
                        ' Setting Location  
                        oDateTimePicker.Location = New Point(oRectangle.X, oRectangle.Y)

                        'RemoveHandler oDateTimePicker.CloseUp, AddressOf oDateTimePicker_CloseUp
                        'AddHandler oDateTimePicker.TextChanged, AddressOf dateTimePicker_OnTextChange

                        ' An event attached to dateTimePicker Control which Is fired when DateTimeControl Is closed  
                        'oDateTimePicker.CloseUp += New EventHandler(oDateTimePicker_CloseUp)
                        ' An event attached to dateTimePicker Control which Is fired when any date Is selected  
                        'oDateTimePicker.TextChanged += New EventHandler(dateTimePicker_OnTextChange)
                        ' Now make it visible  
                        oDateTimePicker.Visible = True

                End Select

                DataGridPedido.CurrentCell = cell
                DataGridPedido.BeginEdit(True)
            Else
                'Colum_OrderBy = e.ColumnIndex
                'Buscar(1, Colum_OrderBy)

                ' boton Imprimir
                If col = DataGridPedido.ColumnCount - 1 Then
                    DataGridPedido.Enabled = False
                    Dim msg As String
                    Dim pos As Integer
                    Dim lote As String
                    Dim codart As String
                    Dim cantidad As Integer
                    Dim fecha_caducidad As String
                    Dim fichero_etiqueta As String
                    Dim cadena As String

                    codart = DataGridPedido.Rows(e.RowIndex).Cells(3).Value.Trim()
                    If codart.IndexOf(".") > 0 Then
                        pos = codart.IndexOf(".")
                        codart = codart.Substring(pos + 1, codart.Length - (pos + 1))
                    End If
                    codart = codart.PadLeft(3, "0")

                    cantidad = DataGridPedido.Rows(e.RowIndex).Cells(6).Value
                    lote = DataGridPedido.Rows(e.RowIndex).Cells(7).Value
                    fecha_caducidad = DataGridPedido.Rows(e.RowIndex).Cells(8).Value

                    DataGridPedido.Rows(e.RowIndex).Cells(4).Value = "Generando impresión"
                    fichero_etiqueta = "B" & txtCodcli.Text.PadLeft(4, "0") & codart

                    obcomun.Borra_Registros_Etiquetas()
                    msg = obcomun.Add_Registro_Etiqueta(fichero_etiqueta, lote, fecha_caducidad, cantidad)
                    fichero_etiqueta = fichero_etiqueta & ".qdf"

                    cadena = config.AppSettings.Settings.Item("PathEtiquetasLabelMatrix").Value
                    If cadena.Substring(cadena.Length - 1) <> "\" Then cadena = cadena & "\"
                    cadena = cadena & fichero_etiqueta
                    If Not File.Exists(cadena) Then
                        MessageBox.Show("El fichero " & cadena & " no se ha encontrado.")
                        Exit Sub
                    Else
                        msg = ImprimeEtiqueta(fichero_etiqueta, cantidad)

                        If msg = "" Then
                            DataGridPedido.Rows(e.RowIndex).Cells(9).Value = "Impresas"
                        Else
                            DataGridPedido.Rows(e.RowIndex).Cells(9).Value = "ERROR"
                            DataGridPedido.Rows(e.RowIndex).Cells(9).ToolTipText = msg
                        End If
                    End If

                    DataGridPedido.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub DataGridPedido_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridPedido.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim col As Integer = DataGridPedido.CurrentCell.ColumnIndex

            If col = 6 Or col = 7 Or col = 8 Then
                Dim x As Long = DataGridPedido.Rows(e.RowIndex).Index
                DataGridPedido.Rows(x).Selected = True
                DataGridPedido.BeginEdit(True)

                Dim codigoSel As String = ""
                Dim descripcionSel As String = ""

                codigoSel = DataGridPedido.Rows(x).Cells(0).Value
                descripcionSel = DataGridPedido.Rows(x).Cells(1).Value
            Else
                'Colum_OrderBy = e.ColumnIndex
                'Buscar(1, Colum_OrderBy)
            End If
        End If

        'Me.Hide()
    End Sub

    Private Sub DataGridPedido_SizeChanged(sender As Object, e As EventArgs) Handles DataGridPedido.SizeChanged

        'modifica_ancho_grid()
    End Sub

    Private Sub DataGridPedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridPedido.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            e.Handled = True

            DataGridPedido.CurrentRow.Selected = True

            Dim x As Long = DataGridPedido.SelectedRows(0).Index - 1
            DataGridPedido.Rows(x).Selected = True

            Dim codigoSel As String = ""
            Dim descripcionSel As String = ""

            codigoSel = DataGridPedido.Rows(x).Cells(0).Value
            descripcionSel = DataGridPedido.Rows(x).Cells(1).Value

            'Me.Hide()
        End If
    End Sub
#End Region

    Private Sub btnBuscadorArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscadorArticulo.Click
        Busca_Articulo()

    End Sub
    Private Sub txtCodArt_TextChanged(sender As Object, e As EventArgs) Handles txtCodArt.TextChanged
        'Busca_Articulo()
    End Sub

    Private Sub Busca_Articulo()
        Dim dt As DataTable
        Dim txtCodArt As String

        txtDesArt.Text = ""
        txtLote.Text = ""
        txtFechaCaducidad.Text = ""
        txtCantidad.Text = "1"

        txtCodArt = Me.txtCodArt.Text.Trim()
        If txtCodArt = "" Then
            MsgBox("No ha indicado el Código de artículo", MsgBoxStyle.Critical, "Código de artículo")
            txtDesArt.Text = ""
        Else
            dt = obcomun.Get_Articulos_SQL_Server(txtCodArt)
            If dt.Rows.Count = 0 Then
                MsgBox("Artículo no encontrado", MsgBoxStyle.Critical, "Artículo no encontrado")
            Else
                txtDesArt.Text = dt.Rows(0)("desart").ToString().Trim()

                txtLote.Focus()
            End If
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Not (Char.IsNumber(e.KeyChar)) Then e.Handled = True
        If [Char].IsDigit(e.KeyChar) Or e.KeyChar = vbBack Or Asc(e.KeyChar) = 8 Then
            Return
        End If
        e.Handled = True
    End Sub

    '***********************
    '*** IMPRIMIR PEDIDO ***
    '***********************
    Private Sub btnImprimirPed_Click(sender As Object, e As EventArgs) Handles btnImprimirPed.Click
        Dim i As Long, msg As String
        Dim pos As Integer
        Dim lote As String
        Dim codart As String
        Dim cantidad As Integer
        Dim fecha_caducidad As String
        Dim fichero_etiqueta As String
        Dim TiempoEsperaEntreEtiquetas As Integer = 0
        Dim cadena As String = String.Empty
        Dim numfilas As Long = DataGridPedido.RowCount
        Dim numetiquetasimpresas As Integer = 0
        msg = ""
        If numfilas = 0 Then

        Else
            DataGridPedido.Enabled = False
            ToolStripStatuslbl.Text = "Generando etiquetas..."

            For i = 0 To numfilas - 1
                codart = DataGridPedido.Rows(i).Cells(3).Value
                If codart.IndexOf(".") > 0 Then
                    pos = codart.IndexOf(".")
                    codart = codart.Substring(pos + 1, codart.Length - (pos + 1))
                End If

                cantidad = DataGridPedido.Rows(i).Cells(6).Value
                lote = DataGridPedido.Rows(i).Cells(7).Value
                fecha_caducidad = DataGridPedido.Rows(i).Cells(8).Value

                fichero_etiqueta = "B" & txtCodcli.Text.PadLeft(4, "0") & codart.PadLeft(3, "0")

                cadena = config.AppSettings.Settings.Item("PathEtiquetasLabelMatrix").Value
                If cadena.Substring(cadena.Length - 1) <> "\" Then cadena = cadena & "\"
                If File.Exists(cadena & fichero_etiqueta & ".qdf") Then
                    DataGridPedido.Rows(i).Cells(4).Value = "Generando impresión"
                    obcomun.Borra_Registros_Etiquetas()
                    msg = obcomun.Add_Registro_Etiqueta(fichero_etiqueta, lote, fecha_caducidad, cantidad)
                    fichero_etiqueta = fichero_etiqueta & ".qdf"

                    ToolStripStatuslbl.Text = "Imprimiendo etiqueta " & fichero_etiqueta
                    Application.DoEvents()
                    msg = ImprimeEtiqueta(fichero_etiqueta, cantidad)

                    If msg = "" Then
                        numetiquetasimpresas += 1
                        DataGridPedido.Rows(i).Cells(9).Value = "Impresas"
                    Else
                        DataGridPedido.Rows(i).Cells(9).Value = "ERROR"
                        DataGridPedido.Rows(i).Cells(9).ToolTipText = msg
                    End If
                    If FrmInicio.config.AppSettings.Settings.Item("TiempoEsperaEntreEtiquetas").Value <> "" And FrmInicio.config.AppSettings.Settings.Item("TiempoEsperaEntreEtiquetas").Value <> "0" Then
                        TiempoEsperaEntreEtiquetas = CInt(FrmInicio.config.AppSettings.Settings.Item("TiempoEsperaEntreEtiquetas").Value)
                        System.Threading.Thread.Sleep(TiempoEsperaEntreEtiquetas * 1000)
                    End If
                End If
            Next

            DataGridPedido.Enabled = True
            ToolStripStatuslbl.Text = "Listo"
            Application.DoEvents()
            MsgBox("Se han enviado a Imprimir " & numetiquetasimpresas.ToString() & " de " & numfilas.ToString(), MsgBoxStyle.Information, "Impresión de etiquetas")
        End If
    End Sub

    Private Function DT_Pedidos() As DataTable
        Dim dt As DataTable = New DataTable
        Dim column As DataColumn
        Dim Row As DataRow
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "NUMPED"
        dt.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "CODCLI"
        dt.Columns.Add(column)

        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "DESCLI"
        dt.Columns.Add(column)

        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "CODART"
        dt.Columns.Add(column)

        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "DESMOD"
        dt.Columns.Add(column)

        column = New DataColumn()
        column.DataType = Type.GetType("System.DateTime")
        column.ColumnName = "FECPED"
        dt.Columns.Add(column)

        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "CANPED"
        dt.Columns.Add(column)

        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "CODLOT"
        dt.Columns.Add(column)

        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "FEDCAD"
        dt.Columns.Add(column)

        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "ESTADO"
        dt.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int32")
        column.ColumnName = "CODESTADO"
        dt.Columns.Add(column)

        Row = dt.NewRow() : Row("NUMPED") = 1 : Row("CODCLI") = 11 : Row("DESCLI") = "Cliente 1" : Row("CODART") = "A1" : Row("DESMOD") = "ARTICULO 1" : Row("FECPED") = "24/01/2018"
        Row("CANPED") = 1 : Row("CODLOT") = "LOT 1" : Row("FEDCAD") = "01/05/2018" : Row("ESTADO") = "PENDIENTE" : Row("CODESTADO") = 1 : dt.Rows.Add(Row)

        Row = dt.NewRow() : Row("NUMPED") = 2 : Row("CODCLI") = 11 : Row("DESCLI") = "Cliente 1" : Row("CODART") = "A2" : Row("DESMOD") = "ARTICULO 2" : Row("FECPED") = "24/01/2018"
        Row("CANPED") = 1 : Row("CODLOT") = "LOT 2" : Row("FEDCAD") = "02/05/2018" : Row("ESTADO") = "PENDIENTE" : Row("CODESTADO") = 1 : dt.Rows.Add(Row)

        Row = dt.NewRow() : Row("NUMPED") = 3 : Row("CODCLI") = 11 : Row("DESCLI") = "Cliente 1" : Row("CODART") = "A3" : Row("DESMOD") = "ARTICULO 3" : Row("FECPED") = "24/01/2018"
        Row("CANPED") = 1 : Row("CODLOT") = "LOT 3" : Row("FEDCAD") = "03/05/2018" : Row("ESTADO") = "PENDIENTE" : Row("CODESTADO") = 1 : dt.Rows.Add(Row)

        Return dt
    End Function

    Private Sub CargaCombo(ByVal objeto As ComboBox, ByVal tabla As String, ByVal añadir_blanco As Boolean, ByVal anadir_todos As String)
        Dim dt As DataTable = New DataTable
        Dim dt2 As DataTable = New DataTable
        Dim comboSource As New Dictionary(Of String, String)()
        'If Desde_Hasta.ToUpper = "DESDE" Then ddlSerie_Desde.DataSource = "" Else ddlSerie_Hasta.DataSource = ""


        If añadir_blanco = True Then
            comboSource.Add("", " ")
        Else
            If anadir_todos <> "" Then
                comboSource.Add("", "<-- TODOS -->")
            End If
        End If

        Select Case tabla
            Case "CANALES"
                dt = obcomun.Selecciona_Canales()

            Case "SERIES"
                Dim valor As String
                If ddlCanal.SelectedIndex > -1 Then
                    valor = DirectCast(ddlCanal.Items(ddlCanal.SelectedIndex), System.Collections.Generic.KeyValuePair(Of String, String)).Key
                    dt = obcomun.Selecciona_Series_Desde(valor, tbxEjercicio.Text)
                End If
        End Select
        If dt.Rows.Count > 0 Then
            With objeto
                If añadir_blanco = True Or anadir_todos <> "" Then
                    For i = 0 To dt.Rows.Count - 1
                        comboSource.Add(dt.Rows(i).Item("Codigo"), dt.Rows(i).Item("Descripcion"))
                    Next
                    .DataSource = New BindingSource(comboSource, Nothing)
                    .DisplayMember = "Value"
                    .ValueMember = "Key"
                Else
                    .DataSource = dt
                    .DisplayMember = "Descripcion"
                    .ValueMember = "Codigo"
                End If
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With
        Else
            objeto.DataSource = Nothing
        End If
    End Sub
    Private Sub tbxEjercicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbxEjercicio.KeyPress
        Dim numberFormatInfo As NumberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat
        Dim decimalSeparator As String = numberFormatInfo.NumberDecimalSeparator
        Dim groupSeparator As String = numberFormatInfo.NumberGroupSeparator
        Dim negativeSign As String = numberFormatInfo.NegativeSign

        Dim keyInput As String = e.KeyChar.ToString()

        If [Char].IsDigit(e.KeyChar) Then
            ' Digits are OK
        ElseIf e.KeyChar = vbBack Then
            ' Backspace key is OK
            '    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
            '    {
            '     // Let the edit control handle control and alt key combinations
            '    }
        Else
            ' Swallow this invalid key and beep
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodCliArt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodCliArt.KeyPress
        Dim numberFormatInfo As NumberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat
        Dim decimalSeparator As String = numberFormatInfo.NumberDecimalSeparator
        Dim groupSeparator As String = numberFormatInfo.NumberGroupSeparator
        Dim negativeSign As String = numberFormatInfo.NegativeSign

        Dim keyInput As String = e.KeyChar.ToString()

        If [Char].IsDigit(e.KeyChar) Then
            ' Digits are OK
        ElseIf e.KeyChar = vbBack Then
            ' Backspace key is OK
            '    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
            '    {
            '     // Let the edit control handle control and alt key combinations
            '    }
        Else
            ' Swallow this invalid key and beep
            e.Handled = True
        End If
    End Sub

    Public Sub Carga_Canales()
        If chkConectadoWingest.Checked = True Then
            CargaCombo(ddlCanal, "CANALES", True, "")
        End If
        If ddlCanal.Items.Count > 0 Then
            ddlCanal.SelectedIndex = 0
            Dim canalconfig As String = FrmInicio.config.AppSettings.Settings.Item("Canal").Value
            For i = 0 To ddlCanal.Items.Count - 1
                If ddlCanal.Items(i).Value = canalconfig Then
                    ddlCanal.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
    End Sub

    Public Function ImprimeEtiqueta(ByVal fichero_qdf As String, ByVal cantidad As Integer) As String
        Dim msg As String = String.Empty
        Dim cadena As String
        Try
            '***************************
            '** crear fichero .bat
            Dim ficherobat As String = Application.StartupPath & "\etiqueta.bat"
            ' Borrar el fichero .bat
            If File.Exists(ficherobat) Then File.Delete(ficherobat)

            Dim sb As New System.Text.StringBuilder
            'sb.AppendLine("@echo off")
            cadena = "cd /D """ & config.AppSettings.Settings.Item("PathProgramaLabelMatrix").Value & """"
            'sb.AppendLine("cd ""C:\Program Files\LABEL MATRIX PowerPro Demo""")
            sb.AppendLine(cadena)

            cadena = config.AppSettings.Settings.Item("PathEtiquetasLabelMatrix").Value
            If cadena.Substring(cadena.Length - 1) <> "\" Then cadena = cadena & "\"

            If File.Exists(cadena & fichero_qdf) Then
                cadena = "start Lmwprint.exe /L=" & cadena & fichero_qdf & " /C=" & cantidad.ToString() & " /N /Q"
                sb.AppendLine(cadena)
                'sb.AppendLine("start LMWPRINT.exe / L = C: \Users\informatica\Documents\jorge\_albatros-informatica\QPDF\je\b0524048.qdf /C=3 /N /Q")

                IO.File.WriteAllText(ficherobat, sb.ToString())

                'Process.Start("etiqueta.bat")
                '******************************************************
                Dim waitprocess As Long = 2000 '5 segundos en milisegundos
                Dim proc As Process = New Process()
                proc.StartInfo.FileName = ficherobat
                'proc.StartInfo.Arguments = prg;
                If config.AppSettings.Settings.Item("MostrarVentanaMSDos").Value = "S" Then
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                Else
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                End If
                proc.StartInfo.ErrorDialog = True
                proc.StartInfo.WorkingDirectory = Application.StartupPath 'Path.GetDirectoryName(prg)
                proc.Start()
                proc.WaitForExit(waitprocess)
                '******************************************************
            Else
                msg = "El fichero " & cadena & fichero_qdf & " no se ha encontrado."
            End If

        Catch ex As Exception
            msg = ex.Message.ToString
        End Try
        Return msg
    End Function

    Private Sub btnImprimirArticulo_Click(sender As Object, e As EventArgs) Handles btnImprimirArticulo.Click
        Dim msg As String
        Dim pos As Integer
        Dim lote As String
        Dim codart As String
        Dim cantidad As Integer
        Dim fecha_caducidad As String
        Dim fichero_etiqueta As String
        Dim cadena As String
        Try
            codart = txtCodArt.Text.Trim()
            cantidad = txtCantidad.Text
            lote = txtLote.Text
            fecha_caducidad = txtFechaCaducidad.Text
            If txtCodCliArt.Text = "" Then
                txtCodCliArt.Focus()
                MessageBox.Show("No ha indicado el Código del Cliente")
                Exit Sub
            End If
            If codart.Trim() = "" Then
                txtCodArt.Focus()
                MessageBox.Show("No ha indicado el Código del artículo")
                Exit Sub
            End If
            If codart.IndexOf(".") > 0 Then
                pos = codart.IndexOf(".")
                codart = codart.Substring(pos + 1, codart.Length - (pos + 1))
            End If
            codart = codart.PadLeft(3, "0")
            If lote = "" Then
                txtLote.Focus()
                MessageBox.Show("No ha indicado el Lote")
                Exit Sub
            End If
            If fecha_caducidad = "" Then
                txtFechaCaducidad.Focus()
                MessageBox.Show("No ha indicado la Fecha de Caducidad")
                Exit Sub
            End If
            If cantidad = "" Or cantidad = "0" Then
                txtCantidad.Focus()
                MessageBox.Show("No ha indicado la Cantidad")
                Exit Sub
            End If

            fichero_etiqueta = "B" & txtCodCliArt.Text.PadLeft(4, "0") & codart

            cadena = config.AppSettings.Settings.Item("PathEtiquetasLabelMatrix").Value
            If cadena.Substring(cadena.Length - 1) <> "\" Then cadena = cadena & "\"
            cadena = cadena & fichero_etiqueta
            If Not File.Exists(cadena & ".qdf") Then
                MessageBox.Show("El fichero " & cadena & " no se ha encontrado.")
                Exit Sub
            End If

            obcomun.Borra_Registros_Etiquetas()
            msg = obcomun.Add_Registro_Etiqueta(fichero_etiqueta, lote, fecha_caducidad, cantidad)
            fichero_etiqueta = fichero_etiqueta & ".qdf"
            msg = ImprimeEtiqueta(fichero_etiqueta, cantidad)

            If msg <> "" Then
                MessageBox.Show("Error: " & msg)
            Else
                MessageBox.Show("Etiqueta Impresa")
            End If
        Catch ex As Exception
            Dim msg2 As String = ex.Message
            MessageBox.Show("Error: " & msg2)
        End Try

    End Sub

    Private Sub txtNumPed_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNumPed.KeyUp
        If txtNumPed.Text <> "" Then
            If e.KeyCode = Keys.Enter Then
                BuscarPedido()
            End If
        End If
    End Sub

    Private Sub txtCodArt_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodArt.KeyUp
        If txtCodArt.Text <> "" Then
            If e.KeyCode = Keys.Enter Then
                Busca_Articulo()
                Existe_Etiqueta()
            End If
        Else
            txtDesArt.Text = ""
            Existe_Etiqueta()
        End If
    End Sub
#Region "Opciones de menú"

#End Region 'Opciones de menú

    Private Sub GuardaCambiosConfiguracion()
        FrmInicio.config.AppSettings.Settings.Item("Canal").Value = ddlCanal.Items(ddlCanal.SelectedIndex).Value
        FrmInicio.config.AppSettings.Settings.Item("Ejercicio").Value = tbxEjercicio.Text

        FrmInicio.config.Save(ConfigurationSaveMode.Modified)
        ConfigurationManager.RefreshSection("appSettings")
    End Sub

    Private Sub ddlCanal_TextChanged(sender As Object, e As EventArgs) Handles ddlCanal.TextChanged
        If PrimeraCarga = False Then
            GuardaCambiosConfiguracion()
        End If

    End Sub

    Private Sub tbxEjercicio_TextChanged(sender As Object, e As EventArgs) Handles tbxEjercicio.TextChanged
        If PrimeraCarga = False Then
            GuardaCambiosConfiguracion()
        End If

    End Sub

    Private Sub btnBuscadorCliente_Click(sender As Object, e As EventArgs) Handles btnBuscadorCliente.Click
        Busca_Cliente()
    End Sub
    Private Sub txtCodCliArt_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodCliArt.KeyUp
        If txtCodCliArt.Text <> "" Then
            If e.KeyCode = Keys.Enter Then
                Busca_Cliente()
            End If
        Else
            txtNomcliArt.Text = ""
            Existe_Etiqueta()
        End If
    End Sub
    Private Sub Busca_Cliente()
        Dim dt As DataTable
        Dim txtCodCli1 As String

        txtCodCli1 = Me.txtCodCliArt.Text.Trim()
        If txtCodCli1 = "" Then
            MsgBox("No ha indicado el Código del Cliente", MsgBoxStyle.Critical, "Código de Cliente")
            txtNomcliArt.Text = ""
        Else
            dt = obcomun.Get_Cliente_SQL_Server(txtCodCli1)
            If dt.Rows.Count = 0 Then
                MsgBox("Cliente no encontrado", MsgBoxStyle.Critical, "Cliente no encontrado")
            Else
                txtNomcliArt.Text = dt.Rows(0)("DESCLI").ToString().Trim()

                txtCodArt.Focus()
            End If
        End If

        Existe_Etiqueta()
    End Sub

    Private Sub Existe_Etiqueta()
        Dim existe_access As Boolean = False
        Dim existe_vieja As Boolean = False
        Dim codart As String = txtCodArt.Text.Trim()
        Dim pos As Integer = 0
        Dim fichero_etiqueta As String
        Dim cadena As String

        img_etiqueta_access.Image = My.Resources.bola_roja
        img_etiqueta_vieja.Image = My.Resources.bola_roja

        If txtCodCliArt.Text.Trim() <> "" And txtNomcliArt.Text.Trim() <> "" And txtCodArt.Text.Trim() <> "" And txtDesArt.Text.Trim() <> "" Then
            If codart.IndexOf(".") > 0 Then
                pos = codart.IndexOf(".")
                codart = codart.Substring(pos + 1, codart.Length - (pos + 1))
            End If
            codart = codart.PadLeft(3, "0")
            fichero_etiqueta = "B" & txtCodCliArt.Text.PadLeft(4, "0") & codart & ".qdf"

            cadena = config.AppSettings.Settings.Item("PathEtiquetasLabelMatrix").Value
            If cadena.Substring(cadena.Length - 1) <> "\" Then cadena = cadena & "\"
            cadena = cadena & fichero_etiqueta
            If File.Exists(cadena) Then existe_access = True
            If existe_access = True Then
                img_etiqueta_access.Image = My.Resources.bola_verde
            End If

            cadena = config.AppSettings.Settings.Item("PathEtiquetasLabelMatrixOriginal").Value
            If cadena.Substring(cadena.Length - 1) <> "\" Then cadena = cadena & "\"
            cadena = cadena & fichero_etiqueta
            If File.Exists(cadena) Then existe_vieja = True
            If existe_vieja = True Then
                img_etiqueta_vieja.Image = My.Resources.bola_verde
            End If

            img_etiqueta_access.Visible = True
            img_etiqueta_vieja.Visible = True
        Else
            img_etiqueta_access.Visible = False
            img_etiqueta_vieja.Visible = False
        End If

    End Sub
End Class
