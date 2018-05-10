Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class ComSQLServerWingest
    Public conSQLServerWingest As SqlConnection
    Private config As Configuration = FrmInicio.config 'ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

    Public Function Conectar() As SqlConnection
        Try
            Dim connectionString As String = "Data Source=" & FrmInicio.config.AppSettings.Settings.Item("ServidorSQLServerWingest").Value & ";Initial Catalog=" & FrmInicio.config.AppSettings.Settings.Item("DataBaseSQLServerWingest").Value & ";User ID=" & FrmInicio.config.AppSettings.Settings.Item("UserSQLServerWingest").Value & ";Password=" & FrmInicio.config.AppSettings.Settings.Item("PwdSQLServerWingest").Value & ";" 'Integrated Security=SSPI;"
            conSQLServerWingest = New SqlConnection(connectionString)
            conSQLServerWingest.Open()
        Catch ex As Exception
            MsgBox("Error al conectar al Servidor de SQL-Server Wingest. " & ex.Message.ToString(), MsgBoxStyle.Critical, "Conectar a BBDD SQL-Server Wingest")
        End Try

        Return conSQLServerWingest
    End Function

    Public Sub Desconectar()
        Try
            'Cerrar la conexion si esta abierta
            If conSQLServerWingest.State = ConnectionState.Open Then
                conSQLServerWingest.Close() 'Cerrar la conexion
                conSQLServerWingest.Dispose() 'Liberar recursos
            End If
        Catch ex As Exception
            MsgBox("Error al cerrar la BBDD de SQL-Server Wingest. " & ex.Message, MsgBoxStyle.Critical, "Desconectar de SQL-Server Wingest")
        End Try
    End Sub


    Public Function Consulta(ByVal sql As String, Optional con_SQLServerWingest As SqlConnection = Nothing, Optional ByVal timeout As Integer = 120) As DataTable
        Dim da As SqlDataAdapter = Nothing 'Guardara las filas de la consulta
        Dim ds As New DataSet
        Dim dt As DataTable = New DataTable

        If con_SQLServerWingest Is Nothing Then
            Conectar() 'Conectar al servidor
        Else
            conSQLServerWingest = con_SQLServerWingest
        End If

        Try
            da = New SqlDataAdapter(sql, conSQLServerWingest) 'Especificamos la sentencia SQLServer
            da.SelectCommand.CommandTimeout = timeout
            da.Fill(ds)
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

            'Dim adapter As SqlDataAdapter = New SqlDataAdapter()
            'Dim command As SqlCommand = New SqlCommand("SELECT * FROM Customers WHERE Country = @Country AND City = @City", conSQLServerWingest)
            'command.Parameters.Add("@Country", SqlDbType.NVarChar, 15)
            'command.Parameters.Add("@City", SqlDbType.NVarChar, 15)
            'adapter.SelectCommand = command
            'MsgBox("Consulta:" & " seleccionados " & dt.Rows.Count)
        Catch ex As Exception
            MsgBox("Error en la consulta de SQL-Server Wingest. " & ex.Message, MsgBoxStyle.Critical, "Consulta de SQL-Server Wingest") 'Muestra un mensaje de Error si lo hay
        End Try

        If con_SQLServerWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return dt
    End Function

    Public Function Consulta_Pager(ByVal sql As String, Optional pagina As Integer = 1, Optional regs_porpagina As Integer = 100, Optional con_SQLServerWingest As SqlConnection = Nothing) As DataTable
        Dim da As SqlDataAdapter = Nothing 'Guardara las filas de la consulta
        Dim ds As New DataSet
        Dim dt As DataTable = New DataTable

        If con_SQLServerWingest Is Nothing Then
            Conectar() 'Conectar al servidor
        Else
            conSQLServerWingest = con_SQLServerWingest
        End If

        Try
            da = New SqlDataAdapter(sql, conSQLServerWingest) 'Especificamos la sentencia SQLServer
            'da.Fill(ds)
            Dim intStart As Integer = CInt((pagina - 1) * regs_porpagina)
            ds.Clear()
            da.Fill(ds, intStart, regs_porpagina, "RegsBuscador")
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

            'Dim adapter As SqlDataAdapter = New SqlDataAdapter()
            'Dim command As SqlCommand = New SqlCommand("SELECT * FROM Customers WHERE Country = @Country AND City = @City", conSQLServerWingest)
            'command.Parameters.Add("@Country", SqlDbType.NVarChar, 15)
            'command.Parameters.Add("@City", SqlDbType.NVarChar, 15)
            'adapter.SelectCommand = command

        Catch ex As Exception
            MsgBox("Error en la consulta de SQL-Server Wingest. " & ex.Message, MsgBoxStyle.Critical, "Consulta de SQL-Server Wingest") 'Muestra un mensaje de Error si lo hay
        End Try

        If con_SQLServerWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return dt
    End Function

    Public Function Cuantos_Consulta(ByVal sql As String, Optional con_SQLServerWingest As SqlConnection = Nothing) As Long
        Dim da As SqlDataAdapter = Nothing 'Guardara las filas de la consulta
        Dim ds As New DataSet
        Dim dt As DataTable = New DataTable
        Dim cuantos As Long = 0

        If con_SQLServerWingest Is Nothing Then
            Conectar() 'Conectar al servidor
        Else
            conSQLServerWingest = con_SQLServerWingest
        End If

        Try
            da = New SqlDataAdapter(sql, conSQLServerWingest) 'Especificamos la sentencia SQLServer
            da.Fill(ds)
            If ds.Tables.Count > 0 Then
                cuantos = ds.Tables(0).Rows.Count
            End If

            'Dim adapter As SqlDataAdapter = New SqlDataAdapter()
            'Dim command As SqlCommand = New SqlCommand("SELECT * FROM Customers WHERE Country = @Country AND City = @City", conSQLServerWingest)
            'command.Parameters.Add("@Country", SqlDbType.NVarChar, 15)
            'command.Parameters.Add("@City", SqlDbType.NVarChar, 15)
            'adapter.SelectCommand = command

        Catch ex As Exception
            MsgBox("Error en la consulta de SQL-Server Wingest. " & ex.Message, MsgBoxStyle.Critical, "Consulta de SQL-Server Wingest") 'Muestra un mensaje de Error si lo hay
        End Try

        If con_SQLServerWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return cuantos
    End Function

    Public Function Alta(ByVal sql As String, ByVal Proceso As String, Optional con_SQLServerWingest As SqlConnection = Nothing, Optional tran As SqlTransaction = Nothing) As String
        Dim msg As String = String.Empty

        Dim filas As Integer = 0 'Guardara las filas afectadas

        Try
            If con_SQLServerWingest Is Nothing Then
                Conectar() 'Conectar a la BD
                Dim query As New SqlCommand(sql, conSQLServerWingest) 'Especifica la Sentencia SQLServer
                filas = query.ExecuteNonQuery() 'Ejecuta la Sentencia SQLServer
            Else
                'conSQLServerWingest = con_SQLServerWingest
                Dim query As New SqlCommand(sql, con_SQLServerWingest, tran) 'Especifica la Sentencia SQLServer
                filas = query.ExecuteNonQuery() 'Ejecuta la Sentencia SQLServer
            End If


            'Dim adapter As SqlDataAdapter = New SqlDataAdapter()
            'Dim Command As SqlCommand
            'Command = New SqlCommand("INSERT INTO Customers (CustomerID, CompanyName) VALUES (@CustomerID, @CompanyName)", conSQLServerWingest)
            'Command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID")
            'Command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName")
            'adapter.InsertCommand = Command

            'msg = filas.ToString
        Catch ex As Exception
            msg = "Error: " & ex.Message
            FrmInicio.CargaError(Proceso, 1, ex.Message.ToString(), msg)
        End Try

        If con_SQLServerWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return msg
    End Function

    Public Function Alta_ReturnNewID(ByVal sql As String, ByVal Proceso As String, Optional con_SQLServerWingest As SqlConnection = Nothing) As String
        Dim msg As String = String.Empty
        If con_SQLServerWingest Is Nothing Then
            Conectar() 'Conectar a la BD
        Else
            conSQLServerWingest = con_SQLServerWingest
        End If

        Dim filas As Int32 = 0 'Guardara las filas afectadas

        Try
            Dim query As New SqlCommand(sql, conSQLServerWingest) 'Especifica la Sentencia SQLServer
            filas = Convert.ToInt32(query.ExecuteScalar())

            msg = filas.ToString
        Catch ex As Exception
            msg = "Error: " & ex.Message
            FrmInicio.CargaError(Proceso, 2, ex.Message.ToString(), msg)
        End Try

        If con_SQLServerWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return msg
    End Function

    Public Function UpdateRegistroTabla(ByVal tabla As String, ByVal ids As Long, id As Long, Optional sql As String = "", Optional con_SQLServerWingest As SqlConnection = Nothing) As String
        Dim msg As String = String.Empty
        If con_SQLServerWingest Is Nothing Then
            Conectar() 'Conectar a la BD
        Else
            conSQLServerWingest = con_SQLServerWingest
        End If

        Dim filas As Integer = 0 'Guardara las filas afectadas

        Try
            If sql = "" Then sql = "UPDATE " & tabla
            Dim query As New SqlCommand(sql, conSQLServerWingest) 'Especifica la Sentencia SQLServer
            filas = query.ExecuteNonQuery() 'Ejecuta la Sentencia SQLServer

            'Dim adapter As SqlDataAdapter = New SqlDataAdapter()
            'Dim Command As SqlCommand
            'Command = New SqlCommand("UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName WHERE CustomerID = @oldCustomerID", conSQLServerWingest)
            'Command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID")
            'Command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName")
            'Dim parameter As SqlParameter = Command.Parameters.Add("@oldCustomerID", SqlDbType.NChar, 5, "CustomerID")
            'parameter.SourceVersion = DataRowVersion.Original
            'adapter.UpdateCommand = Command

            msg = filas.ToString
        Catch ex As Exception
            msg = "Error: " & ex.Message
            FrmInicio.CargaError("UpdateRegistroTabla", 2, ex.Message.ToString(), "Error al actualizar el registro de la tabla (" & tabla & "). " & msg)
        End Try

        If con_SQLServerWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return msg
    End Function

    Public Function BorrarRegistrosTabla(ByVal tabla As String, Optional sql As String = "", Optional con_SQLServerWingest As SqlConnection = Nothing) As String
        Dim msg As String = String.Empty

        If con_SQLServerWingest Is Nothing Then
            Conectar() 'Conectar a la BD
        Else
            conSQLServerWingest = con_SQLServerWingest
        End If
        Dim filas As Integer = 0 'Guardara las filas afectadas

        Try
            If sql = "" Then sql = "DELETE From " & tabla
            Dim query As New SqlCommand(sql, conSQLServerWingest) 'Especifica la Sentencia SQLServer
            filas = query.ExecuteNonQuery() 'Ejecuta la Sentencia SQLServer

            Dim adapter As SqlDataAdapter = New SqlDataAdapter()
            Dim Command As SqlCommand
            'Dim parameter As SqlParameter
            Command = New SqlCommand("DELETE FROM Customers WHERE CustomerID = @CustomerID", conSQLServerWingest)
            Command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID")
            'parameter.SourceVersion = DataRowVersion.Original
            adapter.DeleteCommand = Command

            msg = filas.ToString
        Catch ex As Exception
            msg = "Error: " & ex.Message
            FrmInicio.CargaError("BorrarRegistrosTabla", 2, ex.Message.ToString(), "Error al borrar los registros de la tabla (" & tabla & "). " & msg)
        End Try

        If con_SQLServerWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return msg
    End Function

    Public Function EjecutaQuery(ByVal sql As String, Optional con_SQLServerWingest As SqlConnection = Nothing) As String
        Dim msg As String = String.Empty

        If con_SQLServerWingest Is Nothing Then
            Conectar() 'Conectar a la BD
        Else
            conSQLServerWingest = con_SQLServerWingest
        End If
        Dim filas As Integer = 0 'Guardara las filas afectadas

        Try
            Dim query As New SqlCommand(sql, conSQLServerWingest) 'Especifica la Sentencia SQLServer
            filas = query.ExecuteNonQuery() 'Ejecuta la Sentencia SQLServer

            msg = filas.ToString
        Catch ex As Exception
            msg = "Error: " & ex.Message
            FrmInicio.CargaError("EjecutaQuery", 2, ex.Message.ToString(), "Error al ejecutar la consulta (" & sql & "). " & msg)
        End Try

        If con_SQLServerWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return msg
    End Function

End Class
