<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiguracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfiguracion))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupConexWingestSQLSERVER = New System.Windows.Forms.GroupBox()
        Me.btn_TestingConexSQLServerWingest = New System.Windows.Forms.Button()
        Me.tbxBBDDpwdSQL_Server = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.tbxBBDDuserSQL_Server = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.tbxBBDDSQL_DataSource = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.tbxBBDDPuertoSQL_Server = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.tbxServidorSQL_Server = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.ddlFormatoFechaSQLServer = New System.Windows.Forms.ComboBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtFormatoImportes_Excel = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFormatoCantidades_Excel = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnPathProgramaLabelMatrix = New System.Windows.Forms.Button()
        Me.txtPathProgramaLabelMatrix = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnPathetiquetasQDFOriginales = New System.Windows.Forms.Button()
        Me.txtPathetiquetasQDFOriginales = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnPathBBDDAccess = New System.Windows.Forms.Button()
        Me.btnPathetiquetasQDF = New System.Windows.Forms.Button()
        Me.txtPathetiquetasQDF = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFicheroAccess = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtCodArtLabelMatrix = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbxEjercicio = New System.Windows.Forms.TextBox()
        Me.ddlCanal = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ddlMostrarVentanaMSDos = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTiempoEsperaEntreEtiquetas = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblFormatoImpr = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ddlTipoConexImpresora = New System.Windows.Forms.ComboBox()
        Me.txtIPImpresora = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupConexWingestSQLSERVER.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(400, 478)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(72, 25)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(478, 478)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(72, 25)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupConexWingestSQLSERVER
        '
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.btn_TestingConexSQLServerWingest)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.tbxBBDDpwdSQL_Server)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.Label34)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.tbxBBDDuserSQL_Server)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.Label35)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.tbxBBDDSQL_DataSource)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.Label36)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.tbxBBDDPuertoSQL_Server)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.Label37)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.tbxServidorSQL_Server)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.Label38)
        Me.GroupConexWingestSQLSERVER.Location = New System.Drawing.Point(12, 12)
        Me.GroupConexWingestSQLSERVER.Name = "GroupConexWingestSQLSERVER"
        Me.GroupConexWingestSQLSERVER.Size = New System.Drawing.Size(544, 120)
        Me.GroupConexWingestSQLSERVER.TabIndex = 34
        Me.GroupConexWingestSQLSERVER.TabStop = False
        Me.GroupConexWingestSQLSERVER.Text = "Conexión Wingest SQL-Server"
        '
        'btn_TestingConexSQLServerWingest
        '
        Me.btn_TestingConexSQLServerWingest.Location = New System.Drawing.Point(459, 91)
        Me.btn_TestingConexSQLServerWingest.Name = "btn_TestingConexSQLServerWingest"
        Me.btn_TestingConexSQLServerWingest.Size = New System.Drawing.Size(74, 21)
        Me.btn_TestingConexSQLServerWingest.TabIndex = 10
        Me.btn_TestingConexSQLServerWingest.Text = "Probar"
        Me.btn_TestingConexSQLServerWingest.UseVisualStyleBackColor = True
        '
        'tbxBBDDpwdSQL_Server
        '
        Me.tbxBBDDpwdSQL_Server.Location = New System.Drawing.Point(89, 93)
        Me.tbxBBDDpwdSQL_Server.Name = "tbxBBDDpwdSQL_Server"
        Me.tbxBBDDpwdSQL_Server.Size = New System.Drawing.Size(133, 20)
        Me.tbxBBDDpwdSQL_Server.TabIndex = 9
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(8, 100)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(61, 13)
        Me.Label34.TabIndex = 8
        Me.Label34.Text = "Contraseña"
        '
        'tbxBBDDuserSQL_Server
        '
        Me.tbxBBDDuserSQL_Server.Location = New System.Drawing.Point(89, 69)
        Me.tbxBBDDuserSQL_Server.Name = "tbxBBDDuserSQL_Server"
        Me.tbxBBDDuserSQL_Server.Size = New System.Drawing.Size(133, 20)
        Me.tbxBBDDuserSQL_Server.TabIndex = 7
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(8, 76)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(43, 13)
        Me.Label35.TabIndex = 6
        Me.Label35.Text = "Usuario"
        '
        'tbxBBDDSQL_DataSource
        '
        Me.tbxBBDDSQL_DataSource.Location = New System.Drawing.Point(89, 45)
        Me.tbxBBDDSQL_DataSource.Name = "tbxBBDDSQL_DataSource"
        Me.tbxBBDDSQL_DataSource.Size = New System.Drawing.Size(324, 20)
        Me.tbxBBDDSQL_DataSource.TabIndex = 5
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(8, 52)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(77, 13)
        Me.Label36.TabIndex = 4
        Me.Label36.Text = "Base de Datos"
        '
        'tbxBBDDPuertoSQL_Server
        '
        Me.tbxBBDDPuertoSQL_Server.Location = New System.Drawing.Point(483, 21)
        Me.tbxBBDDPuertoSQL_Server.Name = "tbxBBDDPuertoSQL_Server"
        Me.tbxBBDDPuertoSQL_Server.Size = New System.Drawing.Size(51, 20)
        Me.tbxBBDDPuertoSQL_Server.TabIndex = 3
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(439, 24)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(38, 13)
        Me.Label37.TabIndex = 2
        Me.Label37.Text = "Puerto"
        '
        'tbxServidorSQL_Server
        '
        Me.tbxServidorSQL_Server.Location = New System.Drawing.Point(89, 21)
        Me.tbxServidorSQL_Server.Name = "tbxServidorSQL_Server"
        Me.tbxServidorSQL_Server.Size = New System.Drawing.Size(324, 20)
        Me.tbxServidorSQL_Server.TabIndex = 1
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(6, 28)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(46, 13)
        Me.Label38.TabIndex = 0
        Me.Label38.Text = "Servidor"
        '
        'ddlFormatoFechaSQLServer
        '
        Me.ddlFormatoFechaSQLServer.FormattingEnabled = True
        Me.ddlFormatoFechaSQLServer.Location = New System.Drawing.Point(26, 419)
        Me.ddlFormatoFechaSQLServer.Name = "ddlFormatoFechaSQLServer"
        Me.ddlFormatoFechaSQLServer.Size = New System.Drawing.Size(119, 21)
        Me.ddlFormatoFechaSQLServer.TabIndex = 52
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(23, 403)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(136, 13)
        Me.Label47.TabIndex = 51
        Me.Label47.Text = "Formato Fecha SQL-Server"
        '
        'txtFormatoImportes_Excel
        '
        Me.txtFormatoImportes_Excel.Location = New System.Drawing.Point(197, 419)
        Me.txtFormatoImportes_Excel.Name = "txtFormatoImportes_Excel"
        Me.txtFormatoImportes_Excel.Size = New System.Drawing.Size(119, 20)
        Me.txtFormatoImportes_Excel.TabIndex = 54
        Me.txtFormatoImportes_Excel.Text = "#.##0,00"
        Me.txtFormatoImportes_Excel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(194, 403)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Formato Importes Excel"
        '
        'txtFormatoCantidades_Excel
        '
        Me.txtFormatoCantidades_Excel.Location = New System.Drawing.Point(363, 419)
        Me.txtFormatoCantidades_Excel.Name = "txtFormatoCantidades_Excel"
        Me.txtFormatoCantidades_Excel.Size = New System.Drawing.Size(119, 20)
        Me.txtFormatoCantidades_Excel.TabIndex = 56
        Me.txtFormatoCantidades_Excel.Text = "#.##0"
        Me.txtFormatoCantidades_Excel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(359, 403)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 13)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Formato Cantidades Excel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnPathProgramaLabelMatrix)
        Me.GroupBox1.Controls.Add(Me.txtPathProgramaLabelMatrix)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btnPathetiquetasQDFOriginales)
        Me.GroupBox1.Controls.Add(Me.txtPathetiquetasQDFOriginales)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnPathBBDDAccess)
        Me.GroupBox1.Controls.Add(Me.btnPathetiquetasQDF)
        Me.GroupBox1.Controls.Add(Me.txtPathetiquetasQDF)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFicheroAccess)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 138)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 192)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        '
        'btnPathProgramaLabelMatrix
        '
        Me.btnPathProgramaLabelMatrix.Image = Global.WingestLabelMatrix.My.Resources.Resources.btnsearch
        Me.btnPathProgramaLabelMatrix.Location = New System.Drawing.Point(515, 160)
        Me.btnPathProgramaLabelMatrix.Name = "btnPathProgramaLabelMatrix"
        Me.btnPathProgramaLabelMatrix.Size = New System.Drawing.Size(23, 22)
        Me.btnPathProgramaLabelMatrix.TabIndex = 56
        Me.btnPathProgramaLabelMatrix.UseVisualStyleBackColor = True
        '
        'txtPathProgramaLabelMatrix
        '
        Me.txtPathProgramaLabelMatrix.Location = New System.Drawing.Point(11, 162)
        Me.txtPathProgramaLabelMatrix.Name = "txtPathProgramaLabelMatrix"
        Me.txtPathProgramaLabelMatrix.Size = New System.Drawing.Size(500, 20)
        Me.txtPathProgramaLabelMatrix.TabIndex = 55
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(365, 13)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "Carpeta donde se encuentra el programa LABELMATRIX (LMWPRINT.exe)"
        '
        'btnPathetiquetasQDFOriginales
        '
        Me.btnPathetiquetasQDFOriginales.Image = Global.WingestLabelMatrix.My.Resources.Resources.btnsearch
        Me.btnPathetiquetasQDFOriginales.Location = New System.Drawing.Point(515, 114)
        Me.btnPathetiquetasQDFOriginales.Name = "btnPathetiquetasQDFOriginales"
        Me.btnPathetiquetasQDFOriginales.Size = New System.Drawing.Size(23, 22)
        Me.btnPathetiquetasQDFOriginales.TabIndex = 53
        Me.btnPathetiquetasQDFOriginales.UseVisualStyleBackColor = True
        '
        'txtPathetiquetasQDFOriginales
        '
        Me.txtPathetiquetasQDFOriginales.Location = New System.Drawing.Point(11, 116)
        Me.txtPathetiquetasQDFOriginales.Name = "txtPathetiquetasQDFOriginales"
        Me.txtPathetiquetasQDFOriginales.Size = New System.Drawing.Size(500, 20)
        Me.txtPathetiquetasQDFOriginales.TabIndex = 52
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(309, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Carpeta ficheros qdf de etiquetas SIN conexión a base de datos"
        '
        'btnPathBBDDAccess
        '
        Me.btnPathBBDDAccess.Image = Global.WingestLabelMatrix.My.Resources.Resources.btnsearch
        Me.btnPathBBDDAccess.Location = New System.Drawing.Point(515, 29)
        Me.btnPathBBDDAccess.Name = "btnPathBBDDAccess"
        Me.btnPathBBDDAccess.Size = New System.Drawing.Size(23, 22)
        Me.btnPathBBDDAccess.TabIndex = 50
        Me.btnPathBBDDAccess.UseVisualStyleBackColor = True
        '
        'btnPathetiquetasQDF
        '
        Me.btnPathetiquetasQDF.Image = Global.WingestLabelMatrix.My.Resources.Resources.btnsearch
        Me.btnPathetiquetasQDF.Location = New System.Drawing.Point(515, 71)
        Me.btnPathetiquetasQDF.Name = "btnPathetiquetasQDF"
        Me.btnPathetiquetasQDF.Size = New System.Drawing.Size(23, 22)
        Me.btnPathetiquetasQDF.TabIndex = 49
        Me.btnPathetiquetasQDF.UseVisualStyleBackColor = True
        '
        'txtPathetiquetasQDF
        '
        Me.txtPathetiquetasQDF.Location = New System.Drawing.Point(11, 73)
        Me.txtPathetiquetasQDF.Name = "txtPathetiquetasQDF"
        Me.txtPathetiquetasQDF.Size = New System.Drawing.Size(500, 20)
        Me.txtPathetiquetasQDF.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(309, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Carpeta ficheros qdf de etiquetas con conexión a base de datos"
        '
        'txtFicheroAccess
        '
        Me.txtFicheroAccess.Location = New System.Drawing.Point(11, 31)
        Me.txtFicheroAccess.Name = "txtFicheroAccess"
        Me.txtFicheroAccess.Size = New System.Drawing.Size(500, 20)
        Me.txtFicheroAccess.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Fichero Access etiquetas/pedidos"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtCodArtLabelMatrix
        '
        Me.txtCodArtLabelMatrix.Location = New System.Drawing.Point(247, 372)
        Me.txtCodArtLabelMatrix.MaxLength = 10
        Me.txtCodArtLabelMatrix.Name = "txtCodArtLabelMatrix"
        Me.txtCodArtLabelMatrix.Size = New System.Drawing.Size(119, 20)
        Me.txtCodArtLabelMatrix.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 375)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(217, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Código artículos tienen etiqueta Label Matrix"
        '
        'tbxEjercicio
        '
        Me.tbxEjercicio.Location = New System.Drawing.Point(402, 342)
        Me.tbxEjercicio.MaxLength = 2
        Me.tbxEjercicio.Name = "tbxEjercicio"
        Me.tbxEjercicio.Size = New System.Drawing.Size(61, 20)
        Me.tbxEjercicio.TabIndex = 61
        Me.tbxEjercicio.Text = "0"
        Me.tbxEjercicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tbxEjercicio.WordWrap = False
        '
        'ddlCanal
        '
        Me.ddlCanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlCanal.FormattingEnabled = True
        Me.ddlCanal.Location = New System.Drawing.Point(121, 341)
        Me.ddlCanal.Name = "ddlCanal"
        Me.ddlCanal.Size = New System.Drawing.Size(131, 21)
        Me.ddlCanal.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 349)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Canal por defecto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(295, 349)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 13)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Ejercicio por defecto"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(24, 490)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(215, 13)
        Me.Label10.TabIndex = 67
        Me.Label10.Text = "Mostrar ventana MSDos impresión etiquetas"
        '
        'ddlMostrarVentanaMSDos
        '
        Me.ddlMostrarVentanaMSDos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlMostrarVentanaMSDos.FormattingEnabled = True
        Me.ddlMostrarVentanaMSDos.Location = New System.Drawing.Point(245, 482)
        Me.ddlMostrarVentanaMSDos.Name = "ddlMostrarVentanaMSDos"
        Me.ddlMostrarVentanaMSDos.Size = New System.Drawing.Size(66, 21)
        Me.ddlMostrarVentanaMSDos.TabIndex = 66
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(26, 464)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(252, 13)
        Me.Label12.TabIndex = 71
        Me.Label12.Text = "Tiempo espera entre impresión etiquetas (segundos)"
        '
        'txtTiempoEsperaEntreEtiquetas
        '
        Me.txtTiempoEsperaEntreEtiquetas.Location = New System.Drawing.Point(285, 457)
        Me.txtTiempoEsperaEntreEtiquetas.MaxLength = 10
        Me.txtTiempoEsperaEntreEtiquetas.Name = "txtTiempoEsperaEntreEtiquetas"
        Me.txtTiempoEsperaEntreEtiquetas.Size = New System.Drawing.Size(61, 20)
        Me.txtTiempoEsperaEntreEtiquetas.TabIndex = 70
        Me.txtTiempoEsperaEntreEtiquetas.Text = "0"
        Me.txtTiempoEsperaEntreEtiquetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTiempoEsperaEntreEtiquetas.WordWrap = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblFormatoImpr)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.ddlTipoConexImpresora)
        Me.GroupBox2.Controls.Add(Me.txtIPImpresora)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 512)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(535, 91)
        Me.GroupBox2.TabIndex = 74
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Conexión Impresora"
        '
        'lblFormatoImpr
        '
        Me.lblFormatoImpr.AutoSize = True
        Me.lblFormatoImpr.Location = New System.Drawing.Point(10, 68)
        Me.lblFormatoImpr.Name = "lblFormatoImpr"
        Me.lblFormatoImpr.Size = New System.Drawing.Size(48, 13)
        Me.lblFormatoImpr.TabIndex = 78
        Me.lblFormatoImpr.Text = "Formato:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(7, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(145, 13)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "Tipo conexión impresora"
        '
        'ddlTipoConexImpresora
        '
        Me.ddlTipoConexImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlTipoConexImpresora.FormattingEnabled = True
        Me.ddlTipoConexImpresora.Location = New System.Drawing.Point(10, 39)
        Me.ddlTipoConexImpresora.Name = "ddlTipoConexImpresora"
        Me.ddlTipoConexImpresora.Size = New System.Drawing.Size(162, 21)
        Me.ddlTipoConexImpresora.TabIndex = 76
        '
        'txtIPImpresora
        '
        Me.txtIPImpresora.Location = New System.Drawing.Point(178, 39)
        Me.txtIPImpresora.Name = "txtIPImpresora"
        Me.txtIPImpresora.Size = New System.Drawing.Size(346, 20)
        Me.txtIPImpresora.TabIndex = 75
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(175, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 13)
        Me.Label11.TabIndex = 74
        Me.Label11.Text = "Impresora etiquetas"
        '
        'FrmConfiguracion
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(568, 617)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTiempoEsperaEntreEtiquetas)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ddlMostrarVentanaMSDos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbxEjercicio)
        Me.Controls.Add(Me.ddlCanal)
        Me.Controls.Add(Me.txtCodArtLabelMatrix)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtFormatoCantidades_Excel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFormatoImportes_Excel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ddlFormatoFechaSQLServer)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.GroupConexWingestSQLSERVER)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConfiguracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración"
        Me.GroupConexWingestSQLSERVER.ResumeLayout(False)
        Me.GroupConexWingestSQLSERVER.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupConexWingestSQLSERVER As System.Windows.Forms.GroupBox
    Friend WithEvents btn_TestingConexSQLServerWingest As System.Windows.Forms.Button
    Friend WithEvents tbxBBDDpwdSQL_Server As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents tbxBBDDuserSQL_Server As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents tbxBBDDSQL_DataSource As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents tbxBBDDPuertoSQL_Server As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents tbxServidorSQL_Server As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents ddlFormatoFechaSQLServer As System.Windows.Forms.ComboBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtFormatoImportes_Excel As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFormatoCantidades_Excel As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtPathetiquetasQDF As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFicheroAccess As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnPathBBDDAccess As Button
    Friend WithEvents btnPathetiquetasQDF As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents txtCodArtLabelMatrix As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbxEjercicio As TextBox
    Friend WithEvents ddlCanal As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnPathetiquetasQDFOriginales As Button
    Friend WithEvents txtPathetiquetasQDFOriginales As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnPathProgramaLabelMatrix As Button
    Friend WithEvents txtPathProgramaLabelMatrix As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents ddlMostrarVentanaMSDos As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTiempoEsperaEntreEtiquetas As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents ddlTipoConexImpresora As ComboBox
    Friend WithEvents txtIPImpresora As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents lblFormatoImpr As Label
End Class
