Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class ComAccessWingest
    Public conAccessWingest As OleDbConnection

    Public Function Conectar() As OleDbConnection
        Try
            Dim fichero As String = FrmInicio.FicheroAccess
            Dim connectionString As String
            'connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\" & FrmInicio.FicheroAccess & ";Jet OLEDB:Database Password='';"
            ''connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\" & FrmInicio.FicheroAccess & ";Jet OLEDB:Database Password='';"
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & FrmInicio.config.AppSettings.Settings.Item("FicheroAccessEtiquetas").Value & ";Jet OLEDB:Database Password='';"
            conAccessWingest = New OleDbConnection(connectionString)
            conAccessWingest.Open()
        Catch ex As Exception
            MsgBox("Error al conectar la BBDD ACCESS en (" & Application.StartupPath & "\" & FrmInicio.FicheroAccess & ") " & ex.Message.ToString(), MsgBoxStyle.Critical, "Conectar a BBDD ACCESS Wingest")
        End Try

        Return conAccessWingest
    End Function

    Public Sub Desconectar()
        Try
            'Cerrar la conexion si esta abierta
            If conAccessWingest.State = ConnectionState.Open Then
                conAccessWingest.Close() 'Cerrar la conexion
                conAccessWingest.Dispose() 'Liberar recursos
            End If
        Catch ex As Exception
            MsgBox("Error al cerrar la BBDD de ACCESS Wingest. " & ex.Message, MsgBoxStyle.Critical, "Desconectar de ACCESS Wingest")
        End Try
    End Sub


    Public Function Consulta(ByVal sql As String, Optional con_AccessWingest As OleDbConnection = Nothing) As DataTable
        Dim da As OleDbDataAdapter = Nothing 'Guardara las filas de la consulta
        Dim ds As New DataSet
        Dim dt As DataTable = New DataTable

        If con_AccessWingest Is Nothing Then
            Conectar() 'Conectar al servidor
        End If

        Try
            da = New OleDbDataAdapter(sql, conAccessWingest) 'Especificamos la sentencia SQLServer
            da.Fill(ds)
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

        Catch ex As Exception
            MsgBox("Error en la consulta de ACCESS Wingest. " & ex.Message, MsgBoxStyle.Critical, "Consulta de ACCESS Wingest") 'Muestra un mensaje de Error si lo hay
        End Try

        If con_AccessWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return dt
    End Function

    Public Function Consulta_Pager(ByVal sql As String, Optional pagina As Integer = 1, Optional regs_porpagina As Integer = 100, Optional con_AccessWingest As OleDbConnection = Nothing) As DataTable
        Dim da As OleDbDataAdapter = Nothing 'Guardara las filas de la consulta
        Dim ds As New DataSet
        Dim dt As DataTable = New DataTable

        If con_AccessWingest Is Nothing Then
            Conectar() 'Conectar al servidor
        End If

        Try
            da = New OleDbDataAdapter(sql, conAccessWingest) 'Especificamos la sentencia SQLServer
            da.Fill(ds)
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

        Catch ex As Exception
            MsgBox("Error en la consulta de ACCESS Wingest. " & ex.Message, MsgBoxStyle.Critical, "Consulta de ACCESS Wingest") 'Muestra un mensaje de Error si lo hay
        End Try

        If con_AccessWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return dt
    End Function

    Public Function Cuantos_Consulta(ByVal sql As String, Optional con_AccessWingest As OleDbConnection = Nothing) As Long
        Dim da As OleDbDataAdapter = Nothing 'Guardara las filas de la consulta
        Dim ds As New DataSet
        Dim dt As DataTable = New DataTable
        Dim cuantos As Long = 0

        If con_AccessWingest Is Nothing Then
            Conectar() 'Conectar al servidor
        End If

        Try
            da = New OleDbDataAdapter(sql, conAccessWingest) 'Especificamos la sentencia SQLServer
            da.Fill(ds)
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

        Catch ex As Exception
            MsgBox("Error en la consulta de ACCESS Wingest. " & ex.Message, MsgBoxStyle.Critical, "Consulta de ACCESS Wingest") 'Muestra un mensaje de Error si lo hay
        End Try

        If con_AccessWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return cuantos
    End Function

    Public Function Alta(ByVal sql As String, ByVal Proceso As String, Optional con_AccessWingest As OleDbConnection = Nothing, Optional tran As OleDbTransaction = Nothing) As String
        Dim msg As String = String.Empty

        Dim filas As Integer = 0 'Guardara las filas afectadas

        Try
            If con_AccessWingest Is Nothing Then
                Conectar() 'Conectar a la BD
                Dim query As New OleDbCommand(sql, conAccessWingest) 'Especifica la Sentencia SQLServer
                filas = query.ExecuteNonQuery() 'Ejecuta la Sentencia SQLServer
            Else
                'conAccessWingest = con_AccessWingest
                Dim query As New OleDbCommand(sql, con_AccessWingest, tran) 'Especifica la Sentencia SQLServer
                filas = query.ExecuteNonQuery() 'Ejecuta la Sentencia SQLServer
            End If

            'msg = filas.ToString
        Catch ex As Exception
            msg = "Error: " & ex.Message
            FrmInicio.CargaError(Proceso, 1, ex.Message.ToString(), msg)
        End Try

        If con_AccessWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return msg
    End Function

    Public Function Alta_ReturnNewID(ByVal sql As String, ByVal Proceso As String, Optional con_AccessWingest As OleDbConnection = Nothing) As String
        Dim msg As String = String.Empty
        If con_AccessWingest Is Nothing Then
            Conectar() 'Conectar a la BD
        Else
            conAccessWingest = con_AccessWingest
        End If

        Dim filas As Int32 = 0 'Guardara las filas afectadas

        Try
            Dim query As New OleDbCommand(sql, conAccessWingest) 'Especifica la Sentencia SQLServer
            filas = Convert.ToInt32(query.ExecuteScalar())

            msg = filas.ToString
        Catch ex As Exception
            msg = "Error: " & ex.Message
            FrmInicio.CargaError(Proceso, 2, ex.Message.ToString(), msg)
        End Try

        If con_AccessWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return msg
    End Function

    Public Function UpdateRegistroTabla(ByVal tabla As String, ByVal ids As Long, id As Long, Optional sql As String = "", Optional con_AccessWingest As OleDbConnection = Nothing) As String
        Dim msg As String = String.Empty
        If con_AccessWingest Is Nothing Then
            Conectar() 'Conectar a la BD
        Else
            conAccessWingest = con_AccessWingest
        End If

        Dim filas As Integer = 0 'Guardara las filas afectadas

        Try
            If sql = "" Then sql = "UPDATE " & tabla
            Dim query As New OleDbCommand(sql, conAccessWingest) 'Especifica la Sentencia SQLServer
            filas = query.ExecuteNonQuery() 'Ejecuta la Sentencia SQLServer

            msg = filas.ToString
        Catch ex As Exception
            msg = "Error: " & ex.Message
            FrmInicio.CargaError("UpdateRegistroTabla", 2, ex.Message.ToString(), "Error al actualizar el registro de la tabla (" & tabla & "). " & msg)
        End Try

        If con_AccessWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return msg
    End Function

    Public Function BorrarRegistrosTabla(ByVal tabla As String, Optional sql As String = "", Optional con_AccessWingest As OleDbConnection = Nothing) As String
        Dim msg As String = String.Empty

        If con_AccessWingest Is Nothing Then
            Conectar() 'Conectar a la BD
        Else
            conAccessWingest = con_AccessWingest
        End If
        Dim filas As Integer = 0 'Guardara las filas afectadas

        Try
            If sql = "" Then sql = "DELETE From " & tabla
            Dim query As New OleDbCommand(sql, conAccessWingest) 'Especifica la Sentencia SQLServer
            filas = query.ExecuteNonQuery() 'Ejecuta la Sentencia SQLServer

            'Dim adapter As OleDbDataAdapter = New OleDbDataAdapter()
            'Dim Command As OleDbCommand
            'Dim parameter As SqlParameter
            'Command = New OleDbCommand("DELETE FROM Customers WHERE CustomerID = @CustomerID", conAccessWingest)
            'Command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID")
            'parameter.SourceVersion = DataRowVersion.Original
            'adapter.DeleteCommand = Command

            msg = filas.ToString
        Catch ex As Exception
            msg = "Error: " & ex.Message
            FrmInicio.CargaError("BorrarRegistrosTabla", 2, ex.Message.ToString(), "Error al borrar los registros de la tabla (" & tabla & "). " & msg)
        End Try

        If con_AccessWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return msg
    End Function

    Public Function EjecutaQuery(ByVal sql As String, Optional con_AccessWingest As OleDbConnection = Nothing) As String
        Dim msg As String = String.Empty

        If con_AccessWingest Is Nothing Then
            Conectar() 'Conectar a la BD
        Else
            conAccessWingest = con_AccessWingest
        End If
        Dim filas As Integer = 0 'Guardara las filas afectadas

        Try
            Dim query As New OleDbCommand(sql, conAccessWingest) 'Especifica la Sentencia SQLServer
            filas = query.ExecuteNonQuery() 'Ejecuta la Sentencia SQLServer

            msg = filas.ToString
        Catch ex As Exception
            msg = "Error: " & ex.Message
            FrmInicio.CargaError("EjecutaQuery", 2, ex.Message.ToString(), "Error al ejecutar la consulta (" & sql & "). " & msg)
        End Try

        If con_AccessWingest Is Nothing Then
            Desconectar() 'Cerrar la Conexion a la BD
        End If

        Return msg
    End Function

End Class
