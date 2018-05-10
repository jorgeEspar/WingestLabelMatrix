<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Buscador_Clientes
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Buscador_Clientes))
        Me.GroupFiltros = New System.Windows.Forms.GroupBox()
        Me.btn_Buscar = New System.Windows.Forms.Button()
        Me.tbxNomcomCli = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.tbxNomCli = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.tbxCodCli = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.DataGridBuscador = New System.Windows.Forms.DataGridView()
        Me.tbxNombreCampoCodigo_Destino = New System.Windows.Forms.TextBox()
        Me.tbxNombreCampoDescripcion_Destino = New System.Windows.Forms.TextBox()
        Me.PanelBotones = New System.Windows.Forms.Panel()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlPager = New System.Windows.Forms.Panel()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PanelPaginas = New System.Windows.Forms.Panel()
        Me.lblDeNumPags = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxFormularioDestino = New System.Windows.Forms.TextBox()
        Me.chkSoloClientesBiolema = New System.Windows.Forms.CheckBox()
        Me.GroupFiltros.SuspendLayout()
        CType(Me.DataGridBuscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotones.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPaginas.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupFiltros
        '
        Me.GroupFiltros.Controls.Add(Me.btn_Buscar)
        Me.GroupFiltros.Controls.Add(Me.tbxNomcomCli)
        Me.GroupFiltros.Controls.Add(Me.Label35)
        Me.GroupFiltros.Controls.Add(Me.tbxNomCli)
        Me.GroupFiltros.Controls.Add(Me.Label36)
        Me.GroupFiltros.Controls.Add(Me.tbxCodCli)
        Me.GroupFiltros.Controls.Add(Me.Label38)
        Me.GroupFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupFiltros.Location = New System.Drawing.Point(12, 12)
        Me.GroupFiltros.Name = "GroupFiltros"
        Me.GroupFiltros.Size = New System.Drawing.Size(461, 91)
        Me.GroupFiltros.TabIndex = 35
        Me.GroupFiltros.TabStop = False
        Me.GroupFiltros.Text = "Filtros"
        '
        'btn_Buscar
        '
        Me.btn_Buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Buscar.Location = New System.Drawing.Point(377, 14)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(74, 21)
        Me.btn_Buscar.TabIndex = 4
        Me.btn_Buscar.Text = "Buscar"
        Me.btn_Buscar.UseVisualStyleBackColor = True
        '
        'tbxNomcomCli
        '
        Me.tbxNomcomCli.Location = New System.Drawing.Point(105, 63)
        Me.tbxNomcomCli.Name = "tbxNomcomCli"
        Me.tbxNomcomCli.Size = New System.Drawing.Size(264, 20)
        Me.tbxNomcomCli.TabIndex = 3
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(8, 70)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(93, 13)
        Me.Label35.TabIndex = 6
        Me.Label35.Text = "Nombre Comercial"
        '
        'tbxNomCli
        '
        Me.tbxNomCli.Location = New System.Drawing.Point(105, 39)
        Me.tbxNomCli.Name = "tbxNomCli"
        Me.tbxNomCli.Size = New System.Drawing.Size(264, 20)
        Me.tbxNomCli.TabIndex = 2
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(8, 46)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(44, 13)
        Me.Label36.TabIndex = 4
        Me.Label36.Text = "Nombre"
        '
        'tbxCodCli
        '
        Me.tbxCodCli.Location = New System.Drawing.Point(105, 15)
        Me.tbxCodCli.Name = "tbxCodCli"
        Me.tbxCodCli.Size = New System.Drawing.Size(101, 20)
        Me.tbxCodCli.TabIndex = 1
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(8, 22)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(40, 13)
        Me.Label38.TabIndex = 0
        Me.Label38.Text = "Código"
        '
        'DataGridBuscador
        '
        Me.DataGridBuscador.AllowUserToAddRows = False
        Me.DataGridBuscador.AllowUserToDeleteRows = False
        Me.DataGridBuscador.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridBuscador.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridBuscador.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridBuscador.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridBuscador.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridBuscador.Location = New System.Drawing.Point(12, 109)
        Me.DataGridBuscador.MultiSelect = False
        Me.DataGridBuscador.Name = "DataGridBuscador"
        Me.DataGridBuscador.ReadOnly = True
        Me.DataGridBuscador.RowHeadersVisible = False
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridBuscador.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridBuscador.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridBuscador.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridBuscador.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridBuscador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridBuscador.ShowEditingIcon = False
        Me.DataGridBuscador.Size = New System.Drawing.Size(724, 434)
        Me.DataGridBuscador.TabIndex = 5
        '
        'tbxNombreCampoCodigo_Destino
        '
        Me.tbxNombreCampoCodigo_Destino.Location = New System.Drawing.Point(477, 16)
        Me.tbxNombreCampoCodigo_Destino.Name = "tbxNombreCampoCodigo_Destino"
        Me.tbxNombreCampoCodigo_Destino.Size = New System.Drawing.Size(101, 20)
        Me.tbxNombreCampoCodigo_Destino.TabIndex = 37
        Me.tbxNombreCampoCodigo_Destino.Visible = False
        '
        'tbxNombreCampoDescripcion_Destino
        '
        Me.tbxNombreCampoDescripcion_Destino.Location = New System.Drawing.Point(477, 42)
        Me.tbxNombreCampoDescripcion_Destino.Name = "tbxNombreCampoDescripcion_Destino"
        Me.tbxNombreCampoDescripcion_Destino.Size = New System.Drawing.Size(101, 20)
        Me.tbxNombreCampoDescripcion_Destino.TabIndex = 38
        Me.tbxNombreCampoDescripcion_Destino.Visible = False
        '
        'PanelBotones
        '
        Me.PanelBotones.Controls.Add(Me.btnAceptar)
        Me.PanelBotones.Controls.Add(Me.btnCancelar)
        Me.PanelBotones.Location = New System.Drawing.Point(577, 10)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(165, 36)
        Me.PanelBotones.TabIndex = 39
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(7, 6)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(72, 25)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(85, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(72, 25)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'pnlPager
        '
        Me.pnlPager.Location = New System.Drawing.Point(12, 549)
        Me.pnlPager.Name = "pnlPager"
        Me.pnlPager.Size = New System.Drawing.Size(340, 26)
        Me.pnlPager.TabIndex = 40
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.Location = New System.Drawing.Point(502, 553)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(232, 19)
        Me.lblRegistros.TabIndex = 43
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PanelPaginas
        '
        Me.PanelPaginas.Controls.Add(Me.lblDeNumPags)
        Me.PanelPaginas.Controls.Add(Me.NumericUpDown1)
        Me.PanelPaginas.Controls.Add(Me.Label1)
        Me.PanelPaginas.Location = New System.Drawing.Point(358, 549)
        Me.PanelPaginas.Name = "PanelPaginas"
        Me.PanelPaginas.Size = New System.Drawing.Size(147, 26)
        Me.PanelPaginas.TabIndex = 46
        '
        'lblDeNumPags
        '
        Me.lblDeNumPags.AutoSize = True
        Me.lblDeNumPags.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeNumPags.Location = New System.Drawing.Point(98, 8)
        Me.lblDeNumPags.Name = "lblDeNumPags"
        Me.lblDeNumPags.Size = New System.Drawing.Size(0, 13)
        Me.lblDeNumPags.TabIndex = 48
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(48, 3)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(44, 21)
        Me.NumericUpDown1.TabIndex = 47
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Página"
        '
        'tbxFormularioDestino
        '
        Me.tbxFormularioDestino.Location = New System.Drawing.Point(609, 52)
        Me.tbxFormularioDestino.Name = "tbxFormularioDestino"
        Me.tbxFormularioDestino.Size = New System.Drawing.Size(101, 20)
        Me.tbxFormularioDestino.TabIndex = 47
        Me.tbxFormularioDestino.Visible = False
        '
        'chkSoloClientesBiolema
        '
        Me.chkSoloClientesBiolema.AutoSize = True
        Me.chkSoloClientesBiolema.Location = New System.Drawing.Point(505, 82)
        Me.chkSoloClientesBiolema.Name = "chkSoloClientesBiolema"
        Me.chkSoloClientesBiolema.Size = New System.Drawing.Size(152, 17)
        Me.chkSoloClientesBiolema.TabIndex = 48
        Me.chkSoloClientesBiolema.Text = "Solo Clientes de BIOLEMA"
        Me.chkSoloClientesBiolema.UseVisualStyleBackColor = True
        Me.chkSoloClientesBiolema.Visible = False
        '
        'Buscador_Clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 583)
        Me.Controls.Add(Me.chkSoloClientesBiolema)
        Me.Controls.Add(Me.tbxFormularioDestino)
        Me.Controls.Add(Me.PanelPaginas)
        Me.Controls.Add(Me.lblRegistros)
        Me.Controls.Add(Me.pnlPager)
        Me.Controls.Add(Me.tbxNombreCampoDescripcion_Destino)
        Me.Controls.Add(Me.tbxNombreCampoCodigo_Destino)
        Me.Controls.Add(Me.DataGridBuscador)
        Me.Controls.Add(Me.GroupFiltros)
        Me.Controls.Add(Me.PanelBotones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Buscador_Clientes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscador de Clientes"
        Me.GroupFiltros.ResumeLayout(False)
        Me.GroupFiltros.PerformLayout()
        CType(Me.DataGridBuscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotones.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPaginas.ResumeLayout(False)
        Me.PanelPaginas.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Buscar As System.Windows.Forms.Button
    Friend WithEvents tbxNomcomCli As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents tbxNomCli As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents tbxCodCli As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents DataGridBuscador As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents tbxNombreCampoCodigo_Destino As System.Windows.Forms.TextBox
    Friend WithEvents tbxNombreCampoDescripcion_Destino As System.Windows.Forms.TextBox
    Friend WithEvents PanelBotones As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents pnlPager As System.Windows.Forms.Panel
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents PanelPaginas As System.Windows.Forms.Panel
    Friend WithEvents lblDeNumPags As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbxFormularioDestino As System.Windows.Forms.TextBox
    Friend WithEvents chkSoloClientesBiolema As System.Windows.Forms.CheckBox
End Class
