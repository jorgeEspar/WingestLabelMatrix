Imports System.Configuration
Imports System.Data
Imports System.Data.OleDb
Imports System.Xml
Imports System.IO
Imports System.Linq
Imports System.Data.DataSetExtensions

Public Class ObjComunes
    Private objSQLServerWingest As ComSQLServerWingest
    Private objAccessWingest As ComAccessWingest
    Private config As Configuration = FrmInicio.config 'ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

    Public Sub New()
        objSQLServerWingest = New ComSQLServerWingest()
        objAccessWingest = New ComAccessWingest()
    End Sub

    Public Sub ActivarDesactivar_Controles_FrmInicio(ByVal como As Boolean)
        If como = True Then ' Activar controles
            FrmInicio.MenuStrip1.Enabled = True
        Else
            FrmInicio.MenuStrip1.Enabled = False
        End If
    End Sub

#Region "Guardar Key en app.config"
    Public Sub editConfig(key As String, value As String)

        'Dim configx As Configuration = ConfigurationManager..OpenExeConfiguration(ConfigurationUserLevel.None)
        'For Each setting As KeyValueConfigurationElement In configx.AppSettings.Settings
        '    If setting.Key.Equals(key) Then
        '        setting.Value = value
        '    End If
        'Next
        'configx.Save(ConfigurationSaveMode.Modified)
        'ConfigurationManager.RefreshSection("appSettings")



        Dim config1 As Configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath) ' ConfigurationUserLevel.None)
        config1.AppSettings.Settings(key).Value = value
        config1.Save(ConfigurationSaveMode.Minimal)

        'Dim Config As New XmlDocument()
        'Dim path As String = Application.ExecutablePath & ".config"
        'FrmInicio.config.Load(path)
        'Dim apps As XmlNodeList = FrmInicio.config.GetElementsByTagName("applicationSettings")
        ''Dim list As XmlNodeList = (CType(apps(0), XmlElement)).GetElementsByTagName("settings")
        'Dim list As XmlNodeList = FrmInicio.config.GetElementsByTagName("setting")
        'For Each nodo As XmlElement In list
        '    If nodo.GetAttribute("name") = key Then
        '        nodo.SetAttribute("value", value)
        '        Exit For
        '    End If
        'Next
        'FrmInicio.config.Save(path)
    End Sub
#End Region

#Region "funciones Access"

    Public Sub Borra_Registros_Etiquetas()
        objAccessWingest.BorrarRegistrosTabla("etiquetas", "")

    End Sub
    Public Function Add_Registro_Etiqueta(ByVal fichero_etiqueta As String, ByVal lote As String, ByVal fecha_caducidad As String, ByVal num_etiquetas_print As Integer) As String
        Dim msg As String = ""
        Dim sql As String = ""
        sql = "INSERT INTO etiquetas (fichero_etiqueta,lote,fecha_caducidad,num_etiquetas_print,impresion_ok) VALUES("
        sql += "'" & fichero_etiqueta & "',"
        sql += "'" & Trim(lote) & "',"
        sql += "'" & fecha_caducidad & "',"
        sql += num_etiquetas_print & ",0)"
        Try
            msg = objAccessWingest.Alta_ReturnNewID(sql, "")
        Catch ex As Exception
            msg = "Error: " & ex.Message
        End Try

        Return msg
    End Function
#End Region
#Region "Funciones Obtener registros de Wingest"

    '***********************************************
    '*** Selección registros del pedido indicado ***
    '***********************************************
    Public Sub GetPedido(ByRef dt As DataTable, ByVal numped As Long, ByVal can As String, ByVal eje As Integer)
        Dim sql As String = ""
        Dim sqlhaving As String = ""
        Dim sqlwhere As String = ""
        Dim sqlgroup As String = ""
        Dim sqlorderby As String = ""
        Try
            'ejemplo de select de albfacca para cuando no hay  registros en pedclica
            'can=2; eje=16; NUNFAC=585 NUNFAC=464 -> can=1; eje=16; NUNFAC=3853 -> can=1; eje=16; NUNFAC=3855 -> can=2; eje=16; NUNFAC=461

            'sql = "Select afa.CAN, afa.ejefac, convert(date,afa.FECFAC) As FECPED, afa.NUMFAC As NUMPED, afa.CODCLI, clientes.NOM as DESCLI, articulo.CODART as CODART, articulo.DES AS DESMOD, "
            'sql += "albfacli.CODLOT, cast(convert(date,albfacli.FECCAD) as varchar(10)) as FECCAD, convert(int,albfacli.CANPED) as CANPED "
            'sql += "FROM(albfacca afa INNER JOIN clientes On afa.CODCLI = clientes.CODCLI) "
            'sql += "INNER Join(articulo INNER JOIN albfacli On articulo.CODART = albfacli.CODART) ON (afa.NUMFAC = albfacli.NUMFAC) And (afa.EJEFAC = albfacli.EJEFAC) And (afa.CAN = albfacli.CAN) "
            'sqlgroup = "GROUP BY afa.CAN, afa.EJEFAC, afa.FECFAC, afa.NUMFAC, afa.CODCLI, clientes.NOM, articulo.CODART, articulo.DES, albfacli.CODLOT, albfacli.FECCAD, albfacli.CANPED "
            'sqlhaving = "HAVING afa.CAN ='" & can & "' AND afa.ejefac=" & eje.ToString() & " AND afa.NUMFAC=" & numped.ToString() & " "
            'sqlwhere = "WHERE Left(articulo.CODARTREF, 3) ='" & FrmInicio.config.AppSettings.Settings.Item("CodArticulosLabelMatrix").Value & "' " ' 48.
            'sqlorderby = "ORDER BY CODART"

            sql = "Select ped.CAN, ped.eje as ejefac, convert(date,ped.FECPED) As FECPED, ped.NUMPED, ped.CODCLI, clientes.NOM as DESCLI, articulo.CODART as CODART, articulo.DES AS DESMOD, "
            sql += "pedclili.CODLOT, cast(convert(date,pedclili.FECCAD) as varchar(10)) as FECCAD, convert(int,pedclili.CANPED) as CANPED "
            sql += "FROM(pedclica ped INNER JOIN clientes On ped.CODCLI = clientes.CODCLI) "
            sql += "INNER Join(articulo INNER JOIN pedclili On articulo.CODART = pedclili.CODART) ON (ped.NUMPED = pedclili.NUMPED) And (ped.EJE = pedclili.EJE) And (ped.CAN = pedclili.CAN) "
            sqlgroup = "GROUP BY ped.CAN, ped.EJE, ped.FECPED, ped.NUMPED, ped.CODCLI, clientes.NOM, articulo.CODART, articulo.DES, pedclili.CODLOT, pedclili.FECCAD, pedclili.CANPED "
            sqlhaving = "HAVING ped.CAN ='" & can & "' AND ped.eje=" & eje.ToString() & " AND ped.NUMPED=" & numped.ToString() & " "
            sqlwhere = "WHERE Left(articulo.CODARTREF, 3) ='" & FrmInicio.config.AppSettings.Settings.Item("CodArticulosLabelMatrix").Value & "' " ' 48.
            sqlorderby = "ORDER BY CODART"

            'sql = "SELECT pedclica.CAN, pedclica.eje, pedclica.FECPED, pedclica.CODCLI, clientes.NOM, articulo.CODARTREF, articulo.DES as ARTICULO "
            'sql += "FROM (pedclica INNER JOIN clientes ON pedclica.CODCLI = clientes.CODCLI) " & vbCrLf
            'sql += "INNER JOIN (articulo INNER JOIN pedclili ON articulo.CODART = pedclili.CODART) ON (pedclica.NUMFAC = peclili.NUMFAC) AND (pedclica.EJEFAC = pedclili.EJEFAC) AND (pedclica.CAN = peclili.CAN) " & vbCrLf
            'sqlgroup = "GROUP BY pedclica.CAN, pedclica.eje, albfacca.serfac, pedclica.CODCLI, clientes.NOM, articulo.CODARTREF, DES " & vbCrLf
            'sqlwhere = "WHERE pedclica.can ='" & can & "' AND pedclica.EJE=" & eje.ToString() & " AND pedclica.NUMPED=" & numped.ToString()
            'sqlwhere += " AND Left(articulo.CODARTREF, 3) ='" & FrmInicio.config.AppSettings.Settings.Item("CodArticulosLabelMatrix").Value & "' " ' 48.
            'sqlorderby = "ORDER BY CODARTREF"

            'sqlorderby = " ORDER BY articulo.CODARTREF"
            Dim sqlquery As String = sql & sqlwhere & sqlgroup & sqlhaving & sqlorderby
            'MsgBox(sqlquery)
            dt = objSQLServerWingest.Consulta(sqlquery).Copy()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' Esta función 
    Public Function Get_NumClientes_tipcli(ByVal tipcli As Integer) As Long
        Dim cuantos As Long = 0
        Dim dt As DataTable
        Dim sql As String
        sql = "select COUNT(*) as cuantos from clientes where tipcli=" & tipcli.ToString()
        Try
            dt = objSQLServerWingest.Consulta(sql)
            If dt.Rows.Count > 0 Then
                cuantos = dt.Rows(0).Item("cuantos")
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return cuantos
    End Function

    Public Function BuscadorClientes(ByVal codcli As String, ByVal nom As String, ByVal nomcom As String, ByVal pagina As Integer, ByVal PageSize As Integer, ByVal Colum_OrderBy As Integer, Optional ByVal soloClientesBiolema As Boolean = False) As DataTable
        Dim dt As DataTable
        Dim sql As String = "", sqlwhere As String = ""
        'sql = "select codcli, nom, cif, codpos,cal1,email,tel1,tel2,pagweb,fax,nomcom,percon,obs,forpag,pripag,numpag,entpag,"
        sql = "select codcli, nom, nomcom FROM clientes "
        sqlwhere += "WHERE codcli>0 "
        If codcli <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "codcli=" & codcli
        End If
        If nom <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "nom like '%" & nom & "%'"
        End If
        If nomcom <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "nomcom like '%" & nomcom & "%'"
        End If
        If soloClientesBiolema = True Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "tipcli = 2"
        End If
        'sqlwhere += " RowNumber BETWEEN(2 -1) 100 + 1 AND(((2 -1) 100 + 1) + 100) - 1"

        sql += sqlwhere
        Select Case Colum_OrderBy
            Case 0
                sql += " ORDER BY codcli "
            Case 1
                sql += " ORDER BY nom "
            Case 2
                sql += " ORDER BY nomcom "
            Case Else
                sql += " ORDER BY nom "
        End Select

        FrmInicio.ToolStripStatuslbl.Text = "Seleccionando Clientes" : Application.DoEvents()
        dt = objSQLServerWingest.Consulta_Pager(sql, pagina, PageSize)

        Return dt
    End Function
    Public Function Cuantos_BuscadorClientes(ByVal codcli As String, ByVal nom As String, ByVal nomcom As String, Optional ByVal soloClientesBiolema As Boolean = False) As Long
        Dim cuantos As Long = 0
        Dim sql As String = "", sqlwhere As String = ""
        'sql = "select codcli, nom, cif, codpos,cal1,email,tel1,tel2,pagweb,fax,nomcom,percon,obs,forpag,pripag,numpag,entpag,"
        sql = "select codcli, nom, nomcom FROM clientes "
        sqlwhere += "WHERE codcli>0 "
        If codcli <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "codcli=" & codcli
        End If
        If nom <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "nom like '%" & nom & "%'"
        End If
        If nomcom <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "nomcom like '%" & nomcom & "%'"
        End If
        If soloClientesBiolema = True Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "tipcli = 2"
        End If

        'sqlwhere += " RowNumber BETWEEN(2 -1) 100 + 1 AND(((2 -1) 100 + 1) + 100) - 1"

        sql += sqlwhere
        sql += " ORDER BY nom "

        FrmInicio.ToolStripStatuslbl.Text = "Seleccionando Clientes" : Application.DoEvents()
        cuantos = objSQLServerWingest.Cuantos_Consulta(sql)

        Return cuantos
    End Function

    Public Function BuscadorArticulos(ByVal codArt As String, ByVal nom As String, ByVal pagina As Integer, ByVal PageSize As Integer, ByVal Colum_OrderBy As Integer, Optional ByVal soloArticulosBiolema As Boolean = False) As DataTable
        Dim dt As DataTable
        Dim sql As String = "", sqlwhere As String = ""
        'sql = "select codcli, nom, cif, codpos,cal1,email,tel1,tel2,pagweb,fax,nomcom,percon,obs,forpag,pripag,numpag,entpag,"
        sql = "select codart, des FROM articulo "
        sqlwhere += "WHERE codart<>'' "
        If codArt <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "codart=" & codArt
        End If
        If nom <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "des like '%" & nom & "%'"
        End If

        'If soloArticulosBiolema = True Then
        '    If sqlwhere <> "" Then sqlwhere += " AND "
        '    sqlwhere += "tipcli = 2"
        'End If
        'sqlwhere += " RowNumber BETWEEN(2 -1) 100 + 1 AND(((2 -1) 100 + 1) + 100) - 1"

        sql += sqlwhere
        Select Case Colum_OrderBy
            Case 0
                sql += " ORDER BY codart "
            Case 1
                sql += " ORDER BY des "
            Case Else
                sql += " ORDER BY des "
        End Select

        FrmInicio.ToolStripStatuslbl.Text = "Seleccionando Artículos" : Application.DoEvents()
        dt = objSQLServerWingest.Consulta_Pager(sql, pagina, PageSize)

        Return dt
    End Function
    Public Function Cuantos_BuscadorArticulos(ByVal codart As String, ByVal des As String, Optional ByVal soloArticulosBiolema As Boolean = False) As Long
        Dim cuantos As Long = 0
        Dim sql As String = "", sqlwhere As String = ""
        'sql = "select codcli, nom, cif, codpos,cal1,email,tel1,tel2,pagweb,fax,nomcom,percon,obs,forpag,pripag,numpag,entpag,"
        sql = "select codart, des FROM articulo "
        sqlwhere += "WHERE codart<>'' "
        If codart <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "codart like '%" & codart & "%'"
        End If
        If des <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "des like '%" & des & "%'"
        End If
        'If soloArticulosBiolema = True Then
        '    If sqlwhere <> "" Then sqlwhere += " AND "
        '    sqlwhere += "tipcli = 2"
        'End If

        'sqlwhere += " RowNumber BETWEEN(2 -1) 100 + 1 AND(((2 -1) 100 + 1) + 100) - 1"

        sql += sqlwhere
        sql += " ORDER BY des "

        FrmInicio.ToolStripStatuslbl.Text = "Seleccionando Artículos" : Application.DoEvents()
        cuantos = objSQLServerWingest.Cuantos_Consulta(sql)

        Return cuantos
    End Function

    Public Function BuscadorPedidos(ByVal NumPedido As String, ByVal DesdeFechaPedido As String, ByVal HastaFechaPedido As String, ByVal codcli As String, ByVal nom As String, ByVal nomcom As String, ByVal CANAL As String, ByVal EJE As String, ByVal pagina As Integer, ByVal PageSize As Integer) As DataTable
        Dim cuantos As Long = 0
        Dim dt As DataTable
        Dim sql As String = "", sqlwhere As String = ""
        'sql = "select codcli, nom, cif, codpos,cal1,email,tel1,tel2,pagweb,fax,nomcom,percon,obs,forpag,pripag,numpag,entpag,"
        sql = "select p.can, p.EJE, p.NUMPED, CAST(p.FECPED AS DATE) as fecped, p.codcli, RTRIM(clientes.NOM) AS NOM, RTRIM(clientes.NOMCOM) AS NOMCOM FROM pedclica p INNER JOIN clientes ON p.codcli=clientes.codcli "
        sqlwhere += "WHERE p.codcli>0 "
        If CANAL <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "p.can='" & CANAL & "'"
        End If
        If EJE <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "p.EJE = " & EJE
        End If
        If NumPedido <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "p.NUMPED = " & NumPedido
        End If

        If DesdeFechaPedido <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            Dim fechaPedidoDesde As String = Format(CDate(DesdeFechaPedido), FrmInicio.FormatoFechaSQLServer)
            sqlwhere += " p.fecped >= '" & fechaPedidoDesde & "'" ' '01/01/2016' - Convert(datetime, '" & fechaFacturaDesde & " 00:00:00')" ' ojo la fecha en formato dd-MM-yyyy
        End If
        If HastaFechaPedido <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            Dim fechaPedidoHasta As String = Format(CDate(HastaFechaPedido), FrmInicio.FormatoFechaSQLServer)
            sqlwhere += " p.fecped <= '" & fechaPedidoHasta & "'" ' '01/01/2016' - Convert(datetime, '" & fechaFacturaDesde & " 00:00:00')" ' ojo la fecha en formato dd-MM-yyyy
        End If

        If codcli <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "p.codcli=" & codcli
        End If
        If nom <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "nom like '%" & nom & "%'"
        End If
        If nomcom <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "nomcom like '%" & nomcom & "%'"
        End If

        'sqlwhere += " RowNumber BETWEEN(2 -1) 100 + 1 AND(((2 -1) 100 + 1) + 100) - 1"

        sql += sqlwhere
        sql += " ORDER BY FECPED DESC, NOM, NUMPED "

        FrmInicio.ToolStripStatuslbl.Text = "Seleccionando Pedidos" : Application.DoEvents()
        dt = objSQLServerWingest.Consulta_Pager(sql, pagina, PageSize)

        Return dt
    End Function

    Public Function Cuantos_BuscadorPedidos(ByVal NumPedido As String, ByVal DesdeFechaPedido As String, ByVal HastaFechaPedido As String, ByVal codcli As String, ByVal nom As String, ByVal nomcom As String, ByVal CANAL As String, ByVal EJE As String) As Long
        Dim cuantos As Long = 0
        Dim sql As String = "", sqlwhere As String = ""
        'sql = "select codcli, nom, cif, codpos,cal1,email,tel1,tel2,pagweb,fax,nomcom,percon,obs,forpag,pripag,numpag,entpag,"
        sql = "select p.can, p.EJE, p.NUMPED, CAST(p.FECPED AS DATE) as fecped, p.codcli, clientes.NOM, clientes.NOMCOM from pedclica p INNER JOIN clientes ON p.codcli=clientes.codcli "
        sqlwhere += "WHERE p.codcli>0 "
        If CANAL <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "p.can='" & CANAL & "'"
        End If
        If EJE <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "p.EJE = " & EJE
        End If
        If NumPedido <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "p.NUMPED = " & NumPedido
        End If

        If DesdeFechaPedido <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            Dim fechaPedidoDesde As String = Format(CDate(DesdeFechaPedido), FrmInicio.FormatoFechaSQLServer)
            sqlwhere += " p.fecped >= '" & fechaPedidoDesde & "'" ' '01/01/2016' - Convert(datetime, '" & fechaFacturaDesde & " 00:00:00')" ' ojo la fecha en formato dd-MM-yyyy
        End If
        If HastaFechaPedido <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            Dim fechaPedidoHasta As String = Format(CDate(HastaFechaPedido), FrmInicio.FormatoFechaSQLServer)
            sqlwhere += " p.fecped <= '" & fechaPedidoHasta & "'" ' '01/01/2016' - Convert(datetime, '" & fechaFacturaDesde & " 00:00:00')" ' ojo la fecha en formato dd-MM-yyyy
        End If

        If codcli <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "p.codcli=" & codcli
        End If
        If nom <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "nom like '%" & nom & "%'"
        End If
        If nomcom <> "" Then
            If sqlwhere <> "" Then sqlwhere += " AND "
            sqlwhere += "nomcom like '%" & nomcom & "%'"
        End If

        'sqlwhere += " RowNumber BETWEEN(2 -1) 100 + 1 AND(((2 -1) 100 + 1) + 100) - 1"

        sql += sqlwhere
        sql += " ORDER BY FECPED DESC, NOM, NUMPED "

        FrmInicio.ToolStripStatuslbl.Text = "Seleccionando Pedidos" : Application.DoEvents()
        cuantos = objSQLServerWingest.Cuantos_Consulta(sql)

        Return cuantos
    End Function

    Public Function Selecciona_Canales() As DataTable
        Dim dt As DataTable = New DataTable
        Dim sql As String
        sql = "SELECT DISTINCT CANAL as Codigo, DES as Descripcion FROM canal ORDER BY DES"
        dt = objSQLServerWingest.Consulta(sql)

        Return dt
    End Function
#End Region

    ' Esta función devuelve los articulos de la familia indicada
    Public Function Get_Articulos_SQL_Server(ByVal familia As String, ByVal articulos_biolema As Boolean) As DataTable
        Dim sql As String = ""
        Dim dt As DataTable
        Dim desarticulo As String = ""
        desarticulo = "CASE WHEN articulo.CODARTREF='78.1' THEN 'BOLSAS' " & vbCrLf
        desarticulo += "WHEN articulo.CODARTREF='79.1' THEN 'CARAMELOS' " & vbCrLf
        desarticulo += "WHEN articulo.CODARTREF='76.1' THEN 'COSMÉTICA' " & vbCrLf
        desarticulo += "WHEN articulo.CODARTREF='77.1' THEN 'ALIMENTACIÓN' ELSE articulo.DES " & vbCrLf
        desarticulo += "END as DES "

        If articulos_biolema = True Then
            sql = "SELECT articulo.CODART,articulo.CODARTREF, " & desarticulo & ", familia.CODFAM, familia.DES as DESFAMILIA "
        Else
            sql = "SELECT articulo.CODART,articulo.CODARTREF, articulo.DES, familia.CODFAM, familia.DES "
        End If

        sql += "FROM articulo INNER JOIN familia ON articulo.CODFAM = familia.CODFAM "
        If articulos_biolema = True Or familia <> "" Then sql += " WHERE "
        If familia <> "" Then
            sql += "articulo.CODFAM='" & familia & "' "
        Else
            If articulos_biolema = True Then
                sql += "LEFT(articulo.CODARTREF,1)='7'"
            End If
        End If
        sql += "ORDER BY articulo.DES"
        Try
            dt = objSQLServerWingest.Consulta(sql)

        Catch ex As Exception
            Throw ex
        End Try

        Return dt
    End Function

    ' Esta función devuelve los clientes del tipo indicado
    Public Function Get_Clientes_SQL_Server(ByVal tipo_cliente As String) As DataTable
        Dim sql As String
        Dim dt As DataTable
        sql = "SELECT clientes.CODCLI, clientes.NOM, clientes.TIPCLI, tipcli.DES as DESTIPOCLI "
        sql += "FROM clientes INNER JOIN tipcli ON clientes.TIPCLI = tipcli.tipcli "
        If tipo_cliente <> "" Then
            sql += "WHERE clientes.tipcli='" & tipo_cliente & "' "
        End If
        sql += "ORDER BY clientes.NOM"
        Try
            dt = objSQLServerWingest.Consulta(sql)

        Catch ex As Exception
            Throw ex
        End Try

        Return dt
    End Function

    Public Function Get_Articulos_SQL_Server(ByVal codart As String) As DataTable
        Dim sql As String = ""
        Dim dt As DataTable

        sql = "SELECT articulo.DES as desart, familia.CODFAM, familia.DES as desfam "
        sql += "FROM articulo LEFT JOIN familia ON articulo.CODFAM = familia.CODFAM "
        sql += " WHERE articulo.codart='" & codart & "'"
        Try
            dt = objSQLServerWingest.Consulta(sql)

        Catch ex As Exception
            Throw ex
        End Try

        Return dt
    End Function
    Public Function Get_Cliente_SQL_Server(ByVal codcli As String) As DataTable
        Dim sql As String = ""
        Dim dt As DataTable

        sql = "SELECT clientes.NOM as DESCLI "
        sql += "FROM clientes WHERE clientes.codcli=" & codcli
        Try
            dt = objSQLServerWingest.Consulta(sql)

        Catch ex As Exception
            Throw ex
        End Try

        Return dt
    End Function
End Class
