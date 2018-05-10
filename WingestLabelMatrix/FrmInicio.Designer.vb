<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInicio
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInicio))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatuslbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Semaforowingest = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SemaforoAccess = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatuslblVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.chkConectadoWingest = New System.Windows.Forms.CheckBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnImprimirPed = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumPed = New System.Windows.Forms.TextBox()
        Me.txtFechaPedido = New System.Windows.Forms.TextBox()
        Me.txtNomcli = New System.Windows.Forms.TextBox()
        Me.DataGridPedido = New System.Windows.Forms.DataGridView()
        Me.NUMPEDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCLIDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCLIDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODARTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECPEDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANPEDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODLOTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECCAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EtiqNew = New System.Windows.Forms.DataGridViewImageColumn()
        Me.EtiqOld = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Imprimir = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Articulos_pedido = New WingestLabelMatrix.articulos_pedido()
        Me.btnBuscadorPedido = New System.Windows.Forms.Button()
        Me.GroupConexWingestSQLSERVER = New System.Windows.Forms.GroupBox()
        Me.txtCodCliArt = New System.Windows.Forms.TextBox()
        Me.btnBuscadorCliente = New System.Windows.Forms.Button()
        Me.txtNomcliArt = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFechaCaducidad = New System.Windows.Forms.DateTimePicker()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnImprimirArticulo = New System.Windows.Forms.Button()
        Me.txtDesArt = New System.Windows.Forms.TextBox()
        Me.btnBuscadorArticulo = New System.Windows.Forms.Button()
        Me.txtCodArt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbxEjercicio = New System.Windows.Forms.TextBox()
        Me.ddlCanal = New System.Windows.Forms.ComboBox()
        Me.txtCodcli = New System.Windows.Forms.TextBox()
        Me.chkConectadoAccess = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.img_etiqueta_access = New System.Windows.Forms.PictureBox()
        Me.img_etiqueta_vieja = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Articulos_pedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupConexWingestSQLSERVER.SuspendLayout()
        CType(Me.img_etiqueta_access, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_etiqueta_vieja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1153, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfiguraciónToolStripMenuItem
        '
        Me.ConfiguraciónToolStripMenuItem.Name = "ConfiguraciónToolStripMenuItem"
        Me.ConfiguraciónToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.ConfiguraciónToolStripMenuItem.Text = "&Configuración"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatus, Me.ToolStripStatuslbl, Me.ToolStripStatusLabel1, Me.Semaforowingest, Me.ToolStripStatusLabel4, Me.SemaforoAccess, Me.ToolStripStatusLabel2, Me.ToolStripStatuslblVersion})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 705)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1153, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatus
        '
        Me.ToolStripStatus.Name = "ToolStripStatus"
        Me.ToolStripStatus.Size = New System.Drawing.Size(48, 17)
        Me.ToolStripStatus.Text = "Estado: "
        '
        'ToolStripStatuslbl
        '
        Me.ToolStripStatuslbl.AutoSize = False
        Me.ToolStripStatuslbl.Name = "ToolStripStatuslbl"
        Me.ToolStripStatuslbl.Size = New System.Drawing.Size(500, 17)
        Me.ToolStripStatuslbl.Text = "Listo"
        Me.ToolStripStatuslbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(109, 17)
        Me.ToolStripStatusLabel1.Text = "Conexión Wingest: "
        '
        'Semaforowingest
        '
        Me.Semaforowingest.Image = Global.WingestLabelMatrix.My.Resources.Resources.bola_roja
        Me.Semaforowingest.Name = "Semaforowingest"
        Me.Semaforowingest.Size = New System.Drawing.Size(16, 17)
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(96, 17)
        Me.ToolStripStatusLabel4.Text = "Conexión Access"
        '
        'SemaforoAccess
        '
        Me.SemaforoAccess.Image = Global.WingestLabelMatrix.My.Resources.Resources.bola_roja
        Me.SemaforoAccess.Name = "SemaforoAccess"
        Me.SemaforoAccess.Size = New System.Drawing.Size(16, 17)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(52, 17)
        Me.ToolStripStatusLabel2.Text = "Versión: "
        '
        'ToolStripStatuslblVersion
        '
        Me.ToolStripStatuslblVersion.Name = "ToolStripStatuslblVersion"
        Me.ToolStripStatuslblVersion.Size = New System.Drawing.Size(31, 17)
        Me.ToolStripStatuslblVersion.Text = "1.0.0"
        '
        'chkConectadoWingest
        '
        Me.chkConectadoWingest.AutoSize = True
        Me.chkConectadoWingest.Location = New System.Drawing.Point(401, 27)
        Me.chkConectadoWingest.Name = "chkConectadoWingest"
        Me.chkConectadoWingest.Size = New System.Drawing.Size(129, 17)
        Me.chkConectadoWingest.TabIndex = 13
        Me.chkConectadoWingest.Text = "Conectado a Wingest"
        Me.chkConectadoWingest.UseVisualStyleBackColor = True
        Me.chkConectadoWingest.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(929, 704)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(206, 23)
        Me.ProgressBar1.TabIndex = 14
        Me.ProgressBar1.Visible = False
        '
        'btnImprimirPed
        '
        Me.btnImprimirPed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirPed.Location = New System.Drawing.Point(990, 46)
        Me.btnImprimirPed.Name = "btnImprimirPed"
        Me.btnImprimirPed.Size = New System.Drawing.Size(151, 30)
        Me.btnImprimirPed.TabIndex = 5
        Me.btnImprimirPed.Text = "Imprimir etiquetas pedido"
        Me.btnImprimirPed.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Nº Pedido"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(252, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(149, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Fecha Pedido"
        '
        'txtNumPed
        '
        Me.txtNumPed.Location = New System.Drawing.Point(17, 52)
        Me.txtNumPed.Name = "txtNumPed"
        Me.txtNumPed.Size = New System.Drawing.Size(98, 20)
        Me.txtNumPed.TabIndex = 1
        Me.txtNumPed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFechaPedido
        '
        Me.txtFechaPedido.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFechaPedido.Location = New System.Drawing.Point(152, 52)
        Me.txtFechaPedido.Name = "txtFechaPedido"
        Me.txtFechaPedido.ReadOnly = True
        Me.txtFechaPedido.Size = New System.Drawing.Size(94, 20)
        Me.txtFechaPedido.TabIndex = 21
        Me.txtFechaPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNomcli
        '
        Me.txtNomcli.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNomcli.Location = New System.Drawing.Point(316, 52)
        Me.txtNomcli.Name = "txtNomcli"
        Me.txtNomcli.ReadOnly = True
        Me.txtNomcli.Size = New System.Drawing.Size(455, 20)
        Me.txtNomcli.TabIndex = 22
        '
        'DataGridPedido
        '
        Me.DataGridPedido.AllowUserToAddRows = False
        Me.DataGridPedido.AllowUserToDeleteRows = False
        Me.DataGridPedido.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridPedido.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridPedido.AutoGenerateColumns = False
        Me.DataGridPedido.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridPedido.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridPedido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMPEDDataGridViewTextBoxColumn, Me.CODCLIDataGridViewTextBoxColumn, Me.DESCLIDataGridViewTextBoxColumn, Me.CODARTDataGridViewTextBoxColumn, Me.DESMODDataGridViewTextBoxColumn, Me.FECPEDDataGridViewTextBoxColumn, Me.CANPEDDataGridViewTextBoxColumn, Me.CODLOTDataGridViewTextBoxColumn, Me.FECCAD, Me.ESTADODataGridViewTextBoxColumn, Me.EtiqNew, Me.EtiqOld, Me.Imprimir})
        Me.DataGridPedido.DataSource = Me.BindingSource1
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridPedido.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridPedido.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridPedido.Location = New System.Drawing.Point(16, 209)
        Me.DataGridPedido.MultiSelect = False
        Me.DataGridPedido.Name = "DataGridPedido"
        Me.DataGridPedido.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridPedido.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridPedido.RowHeadersVisible = False
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridPedido.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridPedido.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridPedido.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridPedido.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridPedido.ShowEditingIcon = False
        Me.DataGridPedido.Size = New System.Drawing.Size(1125, 488)
        Me.DataGridPedido.TabIndex = 14
        '
        'NUMPEDDataGridViewTextBoxColumn
        '
        Me.NUMPEDDataGridViewTextBoxColumn.DataPropertyName = "NUMPED"
        Me.NUMPEDDataGridViewTextBoxColumn.HeaderText = "NUMPED"
        Me.NUMPEDDataGridViewTextBoxColumn.Name = "NUMPEDDataGridViewTextBoxColumn"
        Me.NUMPEDDataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMPEDDataGridViewTextBoxColumn.Visible = False
        '
        'CODCLIDataGridViewTextBoxColumn
        '
        Me.CODCLIDataGridViewTextBoxColumn.DataPropertyName = "CODCLI"
        Me.CODCLIDataGridViewTextBoxColumn.HeaderText = "CODCLI"
        Me.CODCLIDataGridViewTextBoxColumn.Name = "CODCLIDataGridViewTextBoxColumn"
        Me.CODCLIDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCLIDataGridViewTextBoxColumn.Visible = False
        Me.CODCLIDataGridViewTextBoxColumn.Width = 90
        '
        'DESCLIDataGridViewTextBoxColumn
        '
        Me.DESCLIDataGridViewTextBoxColumn.DataPropertyName = "DESCLI"
        Me.DESCLIDataGridViewTextBoxColumn.HeaderText = "DESCLI"
        Me.DESCLIDataGridViewTextBoxColumn.Name = "DESCLIDataGridViewTextBoxColumn"
        Me.DESCLIDataGridViewTextBoxColumn.ReadOnly = True
        Me.DESCLIDataGridViewTextBoxColumn.Visible = False
        '
        'CODARTDataGridViewTextBoxColumn
        '
        Me.CODARTDataGridViewTextBoxColumn.DataPropertyName = "CODART"
        Me.CODARTDataGridViewTextBoxColumn.HeaderText = "CÓD. ARTÍCULO"
        Me.CODARTDataGridViewTextBoxColumn.Name = "CODARTDataGridViewTextBoxColumn"
        Me.CODARTDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESMODDataGridViewTextBoxColumn
        '
        Me.DESMODDataGridViewTextBoxColumn.DataPropertyName = "DESMOD"
        Me.DESMODDataGridViewTextBoxColumn.HeaderText = "DESCRIPCIÓN ARTÍCULO"
        Me.DESMODDataGridViewTextBoxColumn.MinimumWidth = 450
        Me.DESMODDataGridViewTextBoxColumn.Name = "DESMODDataGridViewTextBoxColumn"
        Me.DESMODDataGridViewTextBoxColumn.ReadOnly = True
        Me.DESMODDataGridViewTextBoxColumn.Width = 450
        '
        'FECPEDDataGridViewTextBoxColumn
        '
        Me.FECPEDDataGridViewTextBoxColumn.DataPropertyName = "FECPED"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.FECPEDDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.FECPEDDataGridViewTextBoxColumn.HeaderText = "FECPED"
        Me.FECPEDDataGridViewTextBoxColumn.Name = "FECPEDDataGridViewTextBoxColumn"
        Me.FECPEDDataGridViewTextBoxColumn.ReadOnly = True
        Me.FECPEDDataGridViewTextBoxColumn.Visible = False
        '
        'CANPEDDataGridViewTextBoxColumn
        '
        Me.CANPEDDataGridViewTextBoxColumn.DataPropertyName = "CANPED"
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.CANPEDDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.CANPEDDataGridViewTextBoxColumn.HeaderText = "CANTIDAD"
        Me.CANPEDDataGridViewTextBoxColumn.MaxInputLength = 4
        Me.CANPEDDataGridViewTextBoxColumn.Name = "CANPEDDataGridViewTextBoxColumn"
        Me.CANPEDDataGridViewTextBoxColumn.ReadOnly = True
        Me.CANPEDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CANPEDDataGridViewTextBoxColumn.Width = 70
        '
        'CODLOTDataGridViewTextBoxColumn
        '
        Me.CODLOTDataGridViewTextBoxColumn.DataPropertyName = "CODLOT"
        Me.CODLOTDataGridViewTextBoxColumn.HeaderText = "LOTE"
        Me.CODLOTDataGridViewTextBoxColumn.MaxInputLength = 20
        Me.CODLOTDataGridViewTextBoxColumn.MinimumWidth = 80
        Me.CODLOTDataGridViewTextBoxColumn.Name = "CODLOTDataGridViewTextBoxColumn"
        Me.CODLOTDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODLOTDataGridViewTextBoxColumn.Width = 80
        '
        'FECCAD
        '
        Me.FECCAD.DataPropertyName = "FECCAD"
        Me.FECCAD.HeaderText = "F. CADUCIDAD"
        Me.FECCAD.Name = "FECCAD"
        Me.FECCAD.ReadOnly = True
        '
        'ESTADODataGridViewTextBoxColumn
        '
        Me.ESTADODataGridViewTextBoxColumn.DataPropertyName = "ESTADO"
        Me.ESTADODataGridViewTextBoxColumn.HeaderText = "ESTADO"
        Me.ESTADODataGridViewTextBoxColumn.MinimumWidth = 100
        Me.ESTADODataGridViewTextBoxColumn.Name = "ESTADODataGridViewTextBoxColumn"
        Me.ESTADODataGridViewTextBoxColumn.ReadOnly = True
        '
        'EtiqNew
        '
        Me.EtiqNew.Description = "Existe etiqueta nueva"
        Me.EtiqNew.HeaderText = "Etiq Nueva"
        Me.EtiqNew.Name = "EtiqNew"
        Me.EtiqNew.ReadOnly = True
        Me.EtiqNew.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EtiqNew.ToolTipText = "Existe etiqueta nueva"
        Me.EtiqNew.Width = 70
        '
        'EtiqOld
        '
        Me.EtiqOld.Description = "Existe etiqueta antigua"
        Me.EtiqOld.HeaderText = "Etiq vieja"
        Me.EtiqOld.Name = "EtiqOld"
        Me.EtiqOld.ReadOnly = True
        Me.EtiqOld.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EtiqOld.ToolTipText = "Existe etiqueta antigua"
        Me.EtiqOld.Width = 60
        '
        'Imprimir
        '
        Me.Imprimir.HeaderText = ""
        Me.Imprimir.Name = "Imprimir"
        Me.Imprimir.ReadOnly = True
        Me.Imprimir.Text = "Imprimir"
        Me.Imprimir.UseColumnTextForButtonValue = True
        Me.Imprimir.Width = 70
        '
        'BindingSource1
        '
        Me.BindingSource1.AllowNew = False
        Me.BindingSource1.DataMember = "Articulos_Pedido"
        Me.BindingSource1.DataSource = Me.Articulos_pedido
        '
        'Articulos_pedido
        '
        Me.Articulos_pedido.DataSetName = "articulos_pedido"
        Me.Articulos_pedido.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnBuscadorPedido
        '
        Me.btnBuscadorPedido.FlatAppearance.BorderSize = 0
        Me.btnBuscadorPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscadorPedido.Image = Global.WingestLabelMatrix.My.Resources.Resources.btnsearch
        Me.btnBuscadorPedido.Location = New System.Drawing.Point(120, 48)
        Me.btnBuscadorPedido.Name = "btnBuscadorPedido"
        Me.btnBuscadorPedido.Size = New System.Drawing.Size(26, 29)
        Me.btnBuscadorPedido.TabIndex = 2
        Me.btnBuscadorPedido.UseVisualStyleBackColor = True
        '
        'GroupConexWingestSQLSERVER
        '
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.img_etiqueta_vieja)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.img_etiqueta_access)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.Label12)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.Label11)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.txtCodCliArt)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.btnBuscadorCliente)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.txtNomcliArt)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.Label10)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.txtFechaCaducidad)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.txtCantidad)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.Label7)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.Label6)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.txtLote)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.Label5)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.btnImprimirArticulo)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.txtDesArt)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.btnBuscadorArticulo)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.txtCodArt)
        Me.GroupConexWingestSQLSERVER.Controls.Add(Me.Label4)
        Me.GroupConexWingestSQLSERVER.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupConexWingestSQLSERVER.Location = New System.Drawing.Point(17, 90)
        Me.GroupConexWingestSQLSERVER.Name = "GroupConexWingestSQLSERVER"
        Me.GroupConexWingestSQLSERVER.Size = New System.Drawing.Size(1124, 113)
        Me.GroupConexWingestSQLSERVER.TabIndex = 35
        Me.GroupConexWingestSQLSERVER.TabStop = False
        Me.GroupConexWingestSQLSERVER.Text = "Impresión etiqueta de artículo"
        '
        'txtCodCliArt
        '
        Me.txtCodCliArt.Location = New System.Drawing.Point(6, 36)
        Me.txtCodCliArt.MaxLength = 20
        Me.txtCodCliArt.Name = "txtCodCliArt"
        Me.txtCodCliArt.Size = New System.Drawing.Size(74, 20)
        Me.txtCodCliArt.TabIndex = 6
        Me.txtCodCliArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscadorCliente
        '
        Me.btnBuscadorCliente.FlatAppearance.BorderSize = 0
        Me.btnBuscadorCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscadorCliente.Image = Global.WingestLabelMatrix.My.Resources.Resources.btnsearch
        Me.btnBuscadorCliente.Location = New System.Drawing.Point(86, 31)
        Me.btnBuscadorCliente.Name = "btnBuscadorCliente"
        Me.btnBuscadorCliente.Size = New System.Drawing.Size(26, 29)
        Me.btnBuscadorCliente.TabIndex = 7
        Me.btnBuscadorCliente.UseVisualStyleBackColor = True
        '
        'txtNomcliArt
        '
        Me.txtNomcliArt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNomcliArt.Location = New System.Drawing.Point(118, 37)
        Me.txtNomcliArt.Name = "txtNomcliArt"
        Me.txtNomcliArt.ReadOnly = True
        Me.txtNomcliArt.Size = New System.Drawing.Size(554, 20)
        Me.txtNomcliArt.TabIndex = 71
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "Cliente"
        '
        'txtFechaCaducidad
        '
        Me.txtFechaCaducidad.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaCaducidad.Location = New System.Drawing.Point(822, 76)
        Me.txtFechaCaducidad.Name = "txtFechaCaducidad"
        Me.txtFechaCaducidad.Size = New System.Drawing.Size(102, 20)
        Me.txtFechaCaducidad.TabIndex = 11
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(930, 76)
        Me.txtCantidad.MaxLength = 3
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(54, 20)
        Me.txtCantidad.TabIndex = 12
        Me.txtCantidad.Text = "1"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(927, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Cantidad"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(819, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Fecha caducidad"
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(687, 76)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(126, 20)
        Me.txtLote.TabIndex = 10
        Me.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(684, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Lote"
        '
        'btnImprimirArticulo
        '
        Me.btnImprimirArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirArticulo.Location = New System.Drawing.Point(995, 48)
        Me.btnImprimirArticulo.Name = "btnImprimirArticulo"
        Me.btnImprimirArticulo.Size = New System.Drawing.Size(123, 48)
        Me.btnImprimirArticulo.TabIndex = 13
        Me.btnImprimirArticulo.Text = "Imprimir etiqueta artículo"
        Me.btnImprimirArticulo.UseVisualStyleBackColor = True
        '
        'txtDesArt
        '
        Me.txtDesArt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDesArt.Location = New System.Drawing.Point(168, 76)
        Me.txtDesArt.Name = "txtDesArt"
        Me.txtDesArt.ReadOnly = True
        Me.txtDesArt.Size = New System.Drawing.Size(504, 20)
        Me.txtDesArt.TabIndex = 33
        '
        'btnBuscadorArticulo
        '
        Me.btnBuscadorArticulo.FlatAppearance.BorderSize = 0
        Me.btnBuscadorArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscadorArticulo.Image = Global.WingestLabelMatrix.My.Resources.Resources.btnsearch
        Me.btnBuscadorArticulo.Location = New System.Drawing.Point(136, 72)
        Me.btnBuscadorArticulo.Name = "btnBuscadorArticulo"
        Me.btnBuscadorArticulo.Size = New System.Drawing.Size(26, 26)
        Me.btnBuscadorArticulo.TabIndex = 9
        Me.btnBuscadorArticulo.UseVisualStyleBackColor = True
        '
        'txtCodArt
        '
        Me.txtCodArt.Location = New System.Drawing.Point(6, 76)
        Me.txtCodArt.MaxLength = 20
        Me.txtCodArt.Name = "txtCodArt"
        Me.txtCodArt.Size = New System.Drawing.Size(126, 20)
        Me.txtCodArt.TabIndex = 8
        Me.txtCodArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Código de artículo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(911, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "Ejercicio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(774, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Canal"
        '
        'tbxEjercicio
        '
        Me.tbxEjercicio.Location = New System.Drawing.Point(914, 52)
        Me.tbxEjercicio.MaxLength = 2
        Me.tbxEjercicio.Name = "tbxEjercicio"
        Me.tbxEjercicio.Size = New System.Drawing.Size(61, 20)
        Me.tbxEjercicio.TabIndex = 4
        Me.tbxEjercicio.Text = "0"
        Me.tbxEjercicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbxEjercicio.WordWrap = False
        '
        'ddlCanal
        '
        Me.ddlCanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlCanal.FormattingEnabled = True
        Me.ddlCanal.Location = New System.Drawing.Point(777, 50)
        Me.ddlCanal.Name = "ddlCanal"
        Me.ddlCanal.Size = New System.Drawing.Size(131, 21)
        Me.ddlCanal.TabIndex = 3
        '
        'txtCodcli
        '
        Me.txtCodcli.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCodcli.Location = New System.Drawing.Point(255, 51)
        Me.txtCodcli.Name = "txtCodcli"
        Me.txtCodcli.ReadOnly = True
        Me.txtCodcli.Size = New System.Drawing.Size(55, 20)
        Me.txtCodcli.TabIndex = 69
        '
        'chkConectadoAccess
        '
        Me.chkConectadoAccess.AutoSize = True
        Me.chkConectadoAccess.Location = New System.Drawing.Point(545, 27)
        Me.chkConectadoAccess.Name = "chkConectadoAccess"
        Me.chkConectadoAccess.Size = New System.Drawing.Size(125, 17)
        Me.chkConectadoAccess.TabIndex = 70
        Me.chkConectadoAccess.Text = "Conectado a Access"
        Me.chkConectadoAccess.UseVisualStyleBackColor = True
        Me.chkConectadoAccess.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(703, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 13)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "Etiqueta Access:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(838, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 76
        Me.Label12.Text = "Etiqueta vieja:"
        '
        'img_etiqueta_access
        '
        Me.img_etiqueta_access.Image = Global.WingestLabelMatrix.My.Resources.Resources.bola_roja
        Me.img_etiqueta_access.Location = New System.Drawing.Point(804, 14)
        Me.img_etiqueta_access.Name = "img_etiqueta_access"
        Me.img_etiqueta_access.Size = New System.Drawing.Size(16, 16)
        Me.img_etiqueta_access.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.img_etiqueta_access.TabIndex = 77
        Me.img_etiqueta_access.TabStop = False
        Me.img_etiqueta_access.Visible = False
        '
        'img_etiqueta_vieja
        '
        Me.img_etiqueta_vieja.Image = Global.WingestLabelMatrix.My.Resources.Resources.bola_roja
        Me.img_etiqueta_vieja.Location = New System.Drawing.Point(927, 14)
        Me.img_etiqueta_vieja.Name = "img_etiqueta_vieja"
        Me.img_etiqueta_vieja.Size = New System.Drawing.Size(16, 16)
        Me.img_etiqueta_vieja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.img_etiqueta_vieja.TabIndex = 78
        Me.img_etiqueta_vieja.TabStop = False
        Me.img_etiqueta_vieja.Visible = False
        '
        'FrmInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 727)
        Me.Controls.Add(Me.chkConectadoAccess)
        Me.Controls.Add(Me.txtCodcli)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tbxEjercicio)
        Me.Controls.Add(Me.ddlCanal)
        Me.Controls.Add(Me.GroupConexWingestSQLSERVER)
        Me.Controls.Add(Me.DataGridPedido)
        Me.Controls.Add(Me.btnBuscadorPedido)
        Me.Controls.Add(Me.txtNomcli)
        Me.Controls.Add(Me.txtFechaPedido)
        Me.Controls.Add(Me.txtNumPed)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnImprimirPed)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.chkConectadoWingest)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmInicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión etiquetas Label Matrix"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Articulos_pedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupConexWingestSQLSERVER.ResumeLayout(False)
        Me.GroupConexWingestSQLSERVER.PerformLayout()
        CType(Me.img_etiqueta_access, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_etiqueta_vieja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ConfiguraciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatuslbl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Semaforowingest As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatuslblVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chkConectadoWingest As System.Windows.Forms.CheckBox
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnImprimirPed As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNumPed As TextBox
    Friend WithEvents txtFechaPedido As TextBox
    Friend WithEvents txtNomcli As TextBox
    Friend WithEvents btnBuscadorPedido As Button
    Friend WithEvents DataGridPedido As DataGridView
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents GroupConexWingestSQLSERVER As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtLote As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnImprimirArticulo As Button
    Friend WithEvents txtDesArt As TextBox
    Friend WithEvents btnBuscadorArticulo As Button
    Friend WithEvents txtCodArt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Articulos_pedido As articulos_pedido
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFechaCaducidad As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents tbxEjercicio As TextBox
    Friend WithEvents ddlCanal As ComboBox
    Friend WithEvents FEDCADDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NUMPEDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODCLIDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESCLIDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODARTDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESMODDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FECPEDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CANPEDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODLOTDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FECCAD As DataGridViewTextBoxColumn
    Friend WithEvents ESTADODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EtiqNew As DataGridViewImageColumn
    Friend WithEvents EtiqOld As DataGridViewImageColumn
    Friend WithEvents Imprimir As DataGridViewButtonColumn
    Friend WithEvents txtCodcli As TextBox
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents SemaforoAccess As ToolStripStatusLabel
    Friend WithEvents chkConectadoAccess As CheckBox
    Friend WithEvents txtCodCliArt As TextBox
    Friend WithEvents btnBuscadorCliente As Button
    Friend WithEvents txtNomcliArt As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents img_etiqueta_vieja As PictureBox
    Friend WithEvents img_etiqueta_access As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
End Class
