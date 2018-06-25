Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.IO.FileStream
Imports System.Text

Public Class Buscador_Clientes
    Private obcomun As ObjComunes = New ObjComunes()
    Private PageSize As Integer = 200
    Private Colum_OrderBy As Integer = -1

    Private Sub Buscador_Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub Buscar(ByVal pageIndex As Integer, ByVal OrderBY_Colum As Integer)
        Me.Cursor = Cursors.WaitCursor

        Dim cuantos As Long = obcomun.Cuantos_BuscadorClientes(tbxCodCli.Text, tbxNomCli.Text, tbxNomcomCli.Text, chkSoloClientesBiolema.Checked)

        Dim dt As DataTable = obcomun.BuscadorClientes(tbxCodCli.Text, tbxNomCli.Text, tbxNomcomCli.Text, pageIndex, PageSize, Colum_OrderBy, chkSoloClientesBiolema.Checked)
        'BindingSource1.RaiseListChangedEvents = False
        BindingSource1.DataSource = dt
        DataGridBuscador.DataSource = BindingSource1
        'BindingSource1.RaiseListChangedEvents = True

        Dim numfilas As Long = dt.Rows.Count

        If DataGridBuscador.RowCount > 0 Then
            DataGridBuscador.Rows(0).Selected = True
            DataGridBuscador.Focus()
        End If

        Dim MaxPages As Integer = Math.Ceiling(cuantos \ PageSize) + 1
        If pageIndex = 1 Then
            With NumericUpDown1
                .Maximum = MaxPages
                .Minimum = 1
                .Increment = 1
                .Value = 1
            End With
        End If
        lblDeNumPags.Text = "de " & MaxPages.ToString

        Me.PopulatePager(cuantos, pageIndex)
        Dim primer_reg As Long = (pageIndex - 1) * PageSize + 1
        Dim ultimo_reg As Long = (pageIndex) * PageSize
        If ultimo_reg > cuantos Then ultimo_reg = cuantos

        If cuantos = 0 Then
            lblRegistros.Text = "Ningún registro seleccionado con el criterio indicado"
        Else
            lblRegistros.Text = "Mostrando del " & Format(primer_reg, "#,##0") & " al " & Format(ultimo_reg, "#,##0") & " de " & Format(cuantos, "#,##0")
        End If

        Me.Cursor = Cursors.Default
    End Sub
    ' Este evento se produce cuando se va a Mostrar la ventana
    Private Sub FrmBuscador_Clientes_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If DataGridBuscador.RowCount = 0 Then
            DataGridBuscador.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGridBuscador.AutoGenerateColumns = True

            Buscar(1, Colum_OrderBy)

            DataGridBuscador.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            DataGridBuscador.BorderStyle = BorderStyle.Fixed3D
            DataGridBuscador.EditMode = DataGridViewEditMode.EditProgrammatically
        End If
    End Sub

    ' Este evento se produce cuando se cierra la ventana
    Private Sub FrmBuscador_Clientes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub FrmMostrarErrores_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        DataGridBuscador.Width = Me.Width - 45
        DataGridBuscador.Height = Me.Height - (DataGridBuscador.Top + 60 + 17)

        pnlPager.Top = DataGridBuscador.Top + DataGridBuscador.Height + 3
        PanelPaginas.Top = pnlPager.Top

        lblRegistros.Left = (DataGridBuscador.Location.X + DataGridBuscador.Width) - lblRegistros.Width
        lblRegistros.Top = pnlPager.Top

        PanelBotones.Left = (DataGridBuscador.Location.X + DataGridBuscador.Width) - PanelBotones.Width

    End Sub
    Private Sub modifica_ancho_grid()
        If DataGridBuscador.RowCount > 0 Then
            Dim ancho As Integer = DataGridBuscador.Width
            DataGridBuscador.Columns(0).Width = ancho * 17 / 100
            DataGridBuscador.Columns(1).Width = ancho * 40 / 100
            DataGridBuscador.Columns(2).Width = ancho * 40 / 100

        End If
    End Sub

#Region "Botones"
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim numfilas As Long = 0
        Dim i As Long = 0
        Dim codigoSel As String = ""
        Dim descripcionSel As String = ""
        Dim x As Long = 0
        numfilas = DataGridBuscador.RowCount
        If DataGridBuscador.SelectedRows.Count > 0 Then
            x = DataGridBuscador.SelectedRows(0).Index
            codigoSel = DataGridBuscador.Rows(x).Cells(0).Value
            descripcionSel = DataGridBuscador.Rows(x).Cells(1).Value

            'For i = 0 To numfilas - 1

            'Next
        End If
        If codigoSel = "" Then
            MsgBox("No ha indicado el registro que desea seleccionar.", MsgBoxStyle.Exclamation, "Error - Buscador Clientes")
        Else
            FrmInicio.txtCodCliArt.Text = codigoSel
            FrmInicio.txtNomcliArt.Text = descripcionSel

            FrmInicio.Existe_Etiqueta()

            Me.Hide()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Hide()
    End Sub

    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Buscar(1, Colum_OrderBy)
    End Sub
#End Region

#Region "Eventos DataGridBuscador"
    Private Sub DataGridBuscador_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridBuscador.DataBindingComplete
        If DataGridBuscador.RowCount > 0 Then
            DataGridBuscador.Columns(0).HeaderText = "Código"
            DataGridBuscador.Columns(1).HeaderText = "Nombre"
            DataGridBuscador.Columns(2).HeaderText = "Nombre Comercial"

            modifica_ancho_grid()
        End If
    End Sub

    Private Sub DataGridBuscador_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridBuscador.CellClick
        If e.RowIndex > -1 Then
            Dim x As Long = DataGridBuscador.Rows(e.RowIndex).Index
            DataGridBuscador.Rows(x).Selected = True
        Else
            Colum_OrderBy = e.ColumnIndex
            Buscar(1, Colum_OrderBy)
        End If
    End Sub

    Private Sub DataGridBuscador_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridBuscador.CellDoubleClick
        Dim codigoSel As String = ""
        Dim descripcionSel As String = ""
        Dim x As Long = DataGridBuscador.Rows(e.RowIndex).Index
        codigoSel = DataGridBuscador.Rows(x).Cells(0).Value
        descripcionSel = DataGridBuscador.Rows(x).Cells(1).Value

        FrmInicio.txtCodCliArt.Text = codigoSel
        FrmInicio.txtNomcliArt.Text = descripcionSel

        FrmInicio.Existe_Etiqueta()

        Me.Hide()
    End Sub

    Private Sub DataGridBuscador_SizeChanged(sender As Object, e As EventArgs) Handles DataGridBuscador.SizeChanged

        modifica_ancho_grid()
    End Sub

    Private Sub DataGridBuscador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridBuscador.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            e.Handled = True

            DataGridBuscador.CurrentRow.Selected = True

            Dim x As Long = DataGridBuscador.SelectedRows(0).Index - 1
            DataGridBuscador.Rows(x).Selected = True

            Dim codigoSel As String = ""
            Dim descripcionSel As String = ""

            codigoSel = DataGridBuscador.Rows(x).Cells(0).Value
            descripcionSel = DataGridBuscador.Rows(x).Cells(1).Value

            FrmInicio.txtCodCliArt.Text = codigoSel
            FrmInicio.txtNomcliArt.Text = descripcionSel

            FrmInicio.Existe_Etiqueta()
            Me.Hide()
        End If
    End Sub
#End Region

    Private Sub PopulatePager(recordCount As Integer, currentPage As Integer)
        Dim pages As New List(Of Page)()
        Dim startIndex As Integer, endIndex As Integer
        Dim pagerSpan As Integer = 5

        'Calculate the Start and End Index of pages to be displayed.
        Dim dblPageCount As Double = CDbl(CDec(recordCount) / Convert.ToDecimal(PageSize))
        Dim pageCount As Integer = CInt(Math.Ceiling(dblPageCount))
        startIndex = If(currentPage > 1 AndAlso currentPage + pagerSpan - 1 < pagerSpan, currentPage, 1)
        endIndex = If(pageCount > pagerSpan, pagerSpan, pageCount)
        If currentPage > pagerSpan Mod 2 Then
            If currentPage = 2 Then
                endIndex = 5
            Else
                endIndex = currentPage + 2
            End If
        Else
            endIndex = (pagerSpan - currentPage) + 1
        End If

        If endIndex - (pagerSpan - 1) > startIndex Then
            startIndex = endIndex - (pagerSpan - 1)
        End If

        If endIndex > pageCount Then
            endIndex = pageCount
            startIndex = If(((endIndex - pagerSpan) + 1) > 0, (endIndex - pagerSpan) + 1, 1)
        End If

        'Add the First Page Button.
        If currentPage > 1 Then
            pages.Add(New Page() With { _
              .Text = "<<", _
              .Value = "1" _
            })
        End If

        'Add the Previous Button.
        If currentPage > 1 Then
            pages.Add(New Page() With { _
              .Text = "<", _
              .Value = (currentPage - 1).ToString() _
           })
        End If

        For i As Integer = startIndex To endIndex
            pages.Add(New Page() With { _
              .Text = i.ToString(), _
              .Value = i.ToString(), _
              .Selected = i = currentPage _
            })
        Next

        'Add the Next Button.
        If currentPage < pageCount Then
            pages.Add(New Page() With { _
              .Text = ">", _
              .Value = (currentPage + 1).ToString() _
            })
        End If

        'Add the Last Button.
        If currentPage <> pageCount Then
            pages.Add(New Page() With { _
              .Text = ">>", _
              .Value = pageCount.ToString() _
            })
        End If

        'Clear existing Pager Buttons.
        pnlPager.Controls.Clear()

        'Loop and add Buttons for Pager.
        Dim count As Integer = 0
        For Each page As Page In pages
            Dim btnPage As New Button()
            btnPage.Location = New System.Drawing.Point(38 * count, 5)
            btnPage.Size = New System.Drawing.Size(35, 20)
            btnPage.Name = page.Value
            btnPage.Text = page.Text
            btnPage.Enabled = Not page.Selected
            AddHandler btnPage.Click, AddressOf Page_Click
            pnlPager.Controls.Add(btnPage)
            count += 1
        Next
    End Sub

    Private Sub Page_Click(sender As Object, e As EventArgs)
        Dim btnPager As Button = TryCast(sender, Button)
        NumericUpDown1.Value = Integer.Parse(btnPager.Name)
    End Sub

    Public Class Page
        Public Property Text() As String
        Public Property Value() As String
        Public Property Selected() As Boolean
    End Class

    Private Sub NumericUpDown1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumericUpDown1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            e.Handled = True
            Buscar(Integer.Parse(NumericUpDown1.Value), Colum_OrderBy)
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged1(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        Buscar(Integer.Parse(NumericUpDown1.Value), Colum_OrderBy)
    End Sub
End Class