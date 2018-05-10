Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization

Public Class FrmConfiguracion
    Private objFuncionesComunes As FuncionesComunes = New FuncionesComunes()
    Private objSQLServerWingest As ComSQLServerWingest = New ComSQLServerWingest()
    Private CargaInicial As Boolean = True

    Private Sub FrmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaform()
    End Sub

    Public Sub cargaform()
        If CargaInicial = False Then
            EstadoComunicaciones()
            Exit Sub
        End If

        'GroupConexWingestSQLSERVER.Visible = False

        '' TabControl1.Height = 520
        ''Me.Height = 620

        Dim jorge As String = FrmInicio.config.AppSettings.Settings.Item("FirstInit").Value

        Dim i As Integer = 0
        Try
            If FrmInicio.FirstInit = False Then
                If FrmInicio.chkConectadoWingest.Checked = True Then

                End If
            End If

            tbxEjercicio.Text = Year(Now).ToString
            If FrmInicio.config.AppSettings.Settings.Item("Ejercicio").Value <> "" Then
                tbxEjercicio.Text = FrmInicio.config.AppSettings.Settings.Item("Ejercicio").Value
            End If

            Dim xitem5 As New List(Of rmItem)
            xitem5.Add(New rmItem("yyyy-dd-MM", "yyyy-dd-MM")) ' rmItem(Descripción, valor)
            xitem5.Add(New rmItem("yyyy-MM-dd", "yyyy-MM-dd"))
            ddlFormatoFechaSQLServer.DisplayMember = "ItemName"
            ddlFormatoFechaSQLServer.ValueMember = "ItemValue"
            ddlFormatoFechaSQLServer.DataSource = xitem5
            If FrmInicio.config.AppSettings.Settings.Item("FormatFecha_SqlServer").Value <> "" Then
                ddlFormatoFechaSQLServer.SelectedValue = FrmInicio.config.AppSettings.Settings.Item("FormatFecha_SqlServer").Value
            Else
                ddlFormatoFechaSQLServer.SelectedIndex = 0
            End If

            'BBDD SQL-Server Wingest
            tbxServidorSQL_Server.Text = FrmInicio.config.AppSettings.Settings.Item("ServidorSQLServerWingest").Value
            tbxBBDDPuertoSQL_Server.Text = FrmInicio.config.AppSettings.Settings.Item("PortSQLServerWingest").Value
            tbxBBDDSQL_DataSource.Text = FrmInicio.config.AppSettings.Settings.Item("DataBaseSQLServerWingest").Value
            tbxBBDDuserSQL_Server.Text = FrmInicio.config.AppSettings.Settings.Item("UserSQLServerWingest").Value
            tbxBBDDpwdSQL_Server.Text = FrmInicio.config.AppSettings.Settings.Item("PwdSQLServerWingest").Value

            txtFormatoImportes_Excel.Text = FrmInicio.config.AppSettings.Settings.Item("FormatNumer_Importes_Excel").Value
            txtFormatoCantidades_Excel.Text = FrmInicio.config.AppSettings.Settings.Item("FormatNumer_Cantidades_Excel").Value

            txtFicheroAccess.Text = FrmInicio.config.AppSettings.Settings.Item("FicheroAccessEtiquetas").Value
            txtPathetiquetasQDF.Text = FrmInicio.config.AppSettings.Settings.Item("PathEtiquetasLabelMatrix").Value
            txtPathetiquetasQDFOriginales.Text = FrmInicio.config.AppSettings.Settings.Item("PathEtiquetasLabelMatrixOriginal").Value
            txtPathProgramaLabelMatrix.Text = FrmInicio.config.AppSettings.Settings.Item("PathProgramaLabelMatrix").Value

            txtCodArtLabelMatrix.Text = FrmInicio.config.AppSettings.Settings.Item("CodArticulosLabelMatrix").Value

            Dim xitem6 As New List(Of rmItem)
            xitem6.Add(New rmItem("NO", "N")) ' rmItem(Descripción, valor)
            xitem6.Add(New rmItem("SI", "S"))
            ddlMostrarVentanaMSDos.DisplayMember = "ItemName"
            ddlMostrarVentanaMSDos.ValueMember = "ItemValue"
            ddlMostrarVentanaMSDos.DataSource = xitem6
            If FrmInicio.config.AppSettings.Settings.Item("MostrarVentanaMSDos").Value <> "" Then
                ddlMostrarVentanaMSDos.SelectedValue = FrmInicio.config.AppSettings.Settings.Item("MostrarVentanaMSDos").Value
            Else
                ddlMostrarVentanaMSDos.SelectedIndex = 0
            End If

            txtTiempoEsperaEntreEtiquetas.Text = FrmInicio.config.AppSettings.Settings.Item("TiempoEsperaEntreEtiquetas").Value

            EstadoComunicaciones()

        Catch ex As Exception
            MsgBox("Error al cargar la configuración. Error: " & ex.Message, MsgBoxStyle.Critical, "Cargar Configuración")
        End Try
        CargaInicial = False
    End Sub

    Private Sub EstadoComunicaciones()
        If FrmInicio.swConexWingest = True Then
            FrmInicio.chkConectadoWingest.Checked = True
            FrmInicio.Semaforowingest.Image = My.Resources.bola_verde
        Else
            FrmInicio.chkConectadoWingest.Checked = False
            FrmInicio.Semaforowingest.Image = My.Resources.bola_roja
        End If

        If FrmInicio.swConexAccess = True Then
            FrmInicio.chkConectadoAccess.Checked = True
            FrmInicio.SemaforoAccess.Image = My.Resources.bola_verde
        Else
            FrmInicio.chkConectadoAccess.Checked = False
            FrmInicio.SemaforoAccess.Image = My.Resources.bola_roja
        End If
    End Sub

#Region "Guardar la Configuración"
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim ComsOK As Boolean = False
        Dim msg As String = String.Empty
        Dim canal As String = ""

        ProbarConexionSQLServer()

        If ddlCanal.SelectedIndex = -1 Then
            MsgBox("No ha indicado el Canal por defecto", MsgBoxStyle.Critical, "Error")
            ddlCanal.Focus()
            'Exit Sub
        Else
            canal = ddlCanal.Items(ddlCanal.SelectedIndex).Value
        End If
        If canal = "" Then
            MsgBox("No ha indicado el Canal por defecto", MsgBoxStyle.Critical, "Error")
            ddlCanal.Focus()
            'Exit Sub
        End If
        If tbxEjercicio.Text = "" Then
            MsgBox("No ha indicado el Ejercicio por defecto", MsgBoxStyle.Critical, "Error")
            tbxEjercicio.Text = Year(Now).ToString()
            tbxEjercicio.Focus()
            Exit Sub
        End If

        If txtCodArtLabelMatrix.Text.Trim() = "" Then
            MsgBox("No ha indicado Código artículos tienen etiqueta Label Matrix", MsgBoxStyle.Critical, "Error")
            txtCodArtLabelMatrix.Focus()
            Exit Sub
        End If
        If txtPathetiquetasQDF.Text.Trim() = "" Then
            MsgBox("No ha indicado el Path donde se encuentran los ficheros QDF de Label Matrix con conexión a base de datos", MsgBoxStyle.Critical, "Error")
            txtPathetiquetasQDF.Focus()
            Exit Sub
        End If
        If txtPathetiquetasQDFOriginales.Text.Trim() = "" Then
            MsgBox("No ha indicado el Path donde se encuentran los ficheros QDF de Label Matrix SIN conexión a base de datos", MsgBoxStyle.Critical, "Error")
            txtPathetiquetasQDFOriginales.Focus()
            Exit Sub
        End If
        If txtPathProgramaLabelMatrix.Text.Trim() = "" Then
            MsgBox("No ha indicado el Path donde se encuentra el programa LABELMATRIX (LMWPRINT.exe)", MsgBoxStyle.Critical, "Error")
            txtPathProgramaLabelMatrix.Focus()
            Exit Sub
        End If
        If txtFicheroAccess.Text.Trim() = "" Then
            MsgBox("No ha indicado donde se encuentra el fichero de Access de las etiquetas (etiquetas_pedidos.mdb)", MsgBoxStyle.Critical, "Error")
            txtFicheroAccess.Focus()
            Exit Sub
        End If
        If txtTiempoEsperaEntreEtiquetas.Text = "" Then txtTiempoEsperaEntreEtiquetas.Text = "0"

        If MessageBox.Show("¿Seguro desea guardar la Configuración?", "Guardar Configuración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
                'BBDD SQL-Server Wingest
                FrmInicio.config.AppSettings.Settings.Item("ServidorSQLServerWingest").Value = tbxServidorSQL_Server.Text
                FrmInicio.config.AppSettings.Settings.Item("PortSQLServerWingest").Value = tbxBBDDPuertoSQL_Server.Text
                FrmInicio.config.AppSettings.Settings.Item("DataBaseSQLServerWingest").Value = tbxBBDDSQL_DataSource.Text
                FrmInicio.config.AppSettings.Settings.Item("UserSQLServerWingest").Value = tbxBBDDuserSQL_Server.Text
                FrmInicio.config.AppSettings.Settings.Item("PwdSQLServerWingest").Value = tbxBBDDpwdSQL_Server.Text

                FrmInicio.config.AppSettings.Settings.Item("FormatFecha_SqlServer").Value = ddlFormatoFechaSQLServer.SelectedValue

                FrmInicio.config.AppSettings.Settings.Item("FormatNumer_Importes_Excel").Value = txtFormatoImportes_Excel.Text
                FrmInicio.config.AppSettings.Settings.Item("FormatNumer_Cantidades_Excel").Value = txtFormatoCantidades_Excel.Text

                FrmInicio.config.AppSettings.Settings.Item("FicheroAccessEtiquetas").Value = txtFicheroAccess.Text
                FrmInicio.config.AppSettings.Settings.Item("PathEtiquetasLabelMatrix").Value = txtPathetiquetasQDF.Text
                FrmInicio.config.AppSettings.Settings.Item("PathEtiquetasLabelMatrixOriginal").Value = txtPathetiquetasQDFOriginales.Text
                FrmInicio.config.AppSettings.Settings.Item("PathProgramaLabelMatrix").Value = txtPathProgramaLabelMatrix.Text

                FrmInicio.config.AppSettings.Settings.Item("CodArticulosLabelMatrix").Value = txtCodArtLabelMatrix.Text

                FrmInicio.config.AppSettings.Settings.Item("Canal").Value = ddlCanal.Items(ddlCanal.SelectedIndex).Value
                FrmInicio.config.AppSettings.Settings.Item("Ejercicio").Value = tbxEjercicio.Text

                FrmInicio.config.AppSettings.Settings.Item("MostrarVentanaMSDos").Value = ddlMostrarVentanaMSDos.SelectedValue
                FrmInicio.config.AppSettings.Settings.Item("TiempoEsperaEntreEtiquetas").Value = txtTiempoEsperaEntreEtiquetas.Text

                FrmInicio.FormatoFechaSQLServer = ddlFormatoFechaSQLServer.SelectedValue
                ''FrmInicio.config.AppSettings.Settings.Item("Save()
                FrmInicio.config.Save(ConfigurationSaveMode.Modified)
                ConfigurationManager.RefreshSection("appSettings")

                ComsOK = FrmInicio.CompruebaComunicaciones()
                If ComsOK = False Then
                    Exit Sub
                Else
                    FrmInicio.config.AppSettings.Settings.Item("FirstInit").Value = "1"
                End If

                ''FrmInicio.config.AppSettings.Settings.Item("Save()
                FrmInicio.config.Save(ConfigurationSaveMode.Modified)
                ConfigurationManager.RefreshSection("appSettings")

                '---------------------------------------------------------------------------
                '--- Leer y Guardar la configuración en registro tabla "config" de MySQL ---
                '---------------------------------------------------------------------------
                If msg = "" Then
                    MsgBox("Configuración guardada correctamente", MsgBoxStyle.Information, "Guardar Configuración")

                    FrmInicio.Carga_Canales()
                    FrmInicio.ddlCanal.SelectedValue = ddlCanal.SelectedValue
                    FrmInicio.tbxEjercicio.Text = tbxEjercicio.Text

                    Me.Close()
                End If
            Catch ex As Exception
                MsgBox("Error al guardar la configuración. Error: " & ex.Message, MsgBoxStyle.Critical, "Guardar Configuración")
            End Try
        End If
    End Sub
#End Region

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub CargaTablasWingest()
        'CargaCanalesWingest()

        'CargaAlmacenesWingest()
    End Sub

    Private Sub btn_TestingConexSQLServerWingest_Click(sender As Object, e As EventArgs) Handles btn_TestingConexSQLServerWingest.Click
        ProbarConexionSQLServer()
    End Sub

    Private Sub ProbarConexionSQLServer()
        Dim conSQL As SqlConnection
        Dim connectionString As String = "Data Source=" & tbxServidorSQL_Server.Text & ";Initial Catalog=" & tbxBBDDSQL_DataSource.Text.Trim() & ";User ID=" & tbxBBDDuserSQL_Server.Text.Trim() & ";Password=" & tbxBBDDpwdSQL_Server.Text.Trim() & ";" 'Integrated Security=SSPI;"
        FrmInicio.swConexWingest = False
        conSQL = New SqlConnection(connectionString)

        Try
            conSQL.Open()
            MsgBox("Conexión a la Base de datos SQL Server Wingest OK", MsgBoxStyle.Information, "Conectar Base de datos SQL Server")

            FrmInicio.swConexWingest = True

            'BBDD SQL-Server Wingest
            FrmInicio.config.AppSettings.Settings.Item("ServidorSQLServerWingest").Value = tbxServidorSQL_Server.Text
            FrmInicio.config.AppSettings.Settings.Item("PortSQLServerWingest").Value = tbxBBDDPuertoSQL_Server.Text
            FrmInicio.config.AppSettings.Settings.Item("DataBaseSQLServerWingest").Value = tbxBBDDSQL_DataSource.Text
            FrmInicio.config.AppSettings.Settings.Item("UserSQLServerWingest").Value = tbxBBDDuserSQL_Server.Text
            FrmInicio.config.AppSettings.Settings.Item("PwdSQLServerWingest").Value = tbxBBDDpwdSQL_Server.Text
            FrmInicio.config.Save(ConfigurationSaveMode.Full) ' Save changes
            ConfigurationManager.RefreshSection("appSettings")

            CargaTablasWingest()

            If ddlCanal.Items.Count = 0 Then
                CargaCanales()
            End If

        Catch ex As Exception
            MsgBox("Error al conectar al Servidor de SQL Server de Wingest. " & ex.Message.ToString(), MsgBoxStyle.Critical, "Conectar a BBDD SQL Server Wingest")
        End Try
        If conSQL.State = ConnectionState.Open Then conSQL.Close()

        EstadoComunicaciones()
    End Sub
    Private Sub CargaCanales()
        CargaCombo(ddlCanal, "CANALES", True, "")

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
    ' Este evento se produce cuando se va a Mostrar la ventana
    Private Sub FrmConfiguracion_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If FrmInicio.chkConectadoWingest.Checked = True Then
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

    ' Este evento se produce cuando se cierra la ventana
    Private Sub FrmConfiguracion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub btnPathetiquetasQDF_Click(sender As Object, e As EventArgs) Handles btnPathetiquetasQDF.Click
        FolderBrowserDialog1.ShowNewFolderButton = False
        'FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Recent
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtPathetiquetasQDF.Text = FolderBrowserDialog1.SelectedPath & "\"
        End If
    End Sub
    Private Sub btnPathetiquetasQDFOriginales_Click(sender As Object, e As EventArgs) Handles btnPathetiquetasQDFOriginales.Click
        FolderBrowserDialog1.ShowNewFolderButton = False
        'FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Recent
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtPathetiquetasQDFOriginales.Text = FolderBrowserDialog1.SelectedPath & "\"
        End If
    End Sub

    Private Sub btnPathProgramaLabelMatrix_Click(sender As Object, e As EventArgs) Handles btnPathProgramaLabelMatrix.Click
        FolderBrowserDialog1.ShowNewFolderButton = False
        'FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Recent
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtPathProgramaLabelMatrix.Text = FolderBrowserDialog1.SelectedPath & "\"
        End If
    End Sub

    Private Sub btnPathBBDDAccess_Click(sender As Object, e As EventArgs) Handles btnPathBBDDAccess.Click
        OpenFileDialog1.Filter = "Base de datos Access (etiquetas_pedidos.accdb)|*.accdb|Base de datos Access (etiquetas_pedidos.mdb)|*.mdb|Todos los archivos (*.*)|*.*"
        OpenFileDialog1.FileName = "etiquetas_pedidos.mdb"
        'OpenFileDialog1.InitialDirectory = Environment.SpecialFolder.Recent
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            txtFicheroAccess.Text = OpenFileDialog1.FileName
        End If
    End Sub

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
                dt = FrmInicio.obcomun.Selecciona_Canales()

            Case "SERIES"
                Dim valor As String
                If ddlCanal.SelectedIndex > -1 Then
                    valor = DirectCast(ddlCanal.Items(ddlCanal.SelectedIndex), System.Collections.Generic.KeyValuePair(Of String, String)).Key
                    dt = FrmInicio.obcomun.Selecciona_Series_Desde(valor, tbxEjercicio.Text)
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

    Private Sub txtTiempoEsperaEntreEtiquetas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTiempoEsperaEntreEtiquetas.KeyPress
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
End Class

#Region "Clase para tratamiento Combobox"
Public Class rmItem
    Private myName As String
    Private myID As Int64
    Private mySValue As String

    Public Sub New(ByVal strName As String, ByVal strValue As String, Optional intID As Int64 = -1)
        Me.myName = strName
        Me.myID = intID
        Me.mySValue = strValue
    End Sub 'New

    Public Overrides Function ToString() As String
        Return myName
    End Function

    Public ReadOnly Property ItemName() As String
        Get
            Return myName
        End Get
    End Property

    Public ReadOnly Property ItemID() As Int64
        Get
            Return myID
        End Get
    End Property

    Public ReadOnly Property ItemValue() As String
        Get
            Return mySValue
        End Get
    End Property
End Class
#End Region
