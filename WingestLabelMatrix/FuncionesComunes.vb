Public Class FuncionesComunes
    ' Clase para poder añadir items a los ComboBox
    Public Class Item
        Public Name As String
        Public Value As Integer
        Public Sub New(N As String, V As Integer)
            Name = N
            Value = V
        End Sub
        Public Overrides Function ToString() As String
            Return Value
        End Function
    End Class

    Shared Function Fecha_SQlServer(ByVal fecha As String, ByVal tipo_origen As String) As String
        Dim f As String = ""
        If fecha <> "" Then
            Select Case tipo_origen.ToUpper
                Case "MYSQL"
                    f = fecha
                Case "FOXPRO"
                    f = fecha
            End Select
        End If

        Return f
    End Function

    Shared Function Fecha_MySQL_to_Date(ByVal fecha_mysql As String) As Date
        Dim f As String
        Dim fecha As Date
        Dim x As String()
        If fecha_mysql <> "" Then
            x = fecha_mysql.Split("-")
            If x.Length > 0 Then
                f = x(2) & "/" & x(1) & "/" & x(0)
                fecha = CDate(f)
            End If
        End If
        Return fecha
    End Function
    ' esta función se le pasa el nº columna de Excel y devuelve la columna en LETRAS. Ejemplo: 4 -> D
    Shared Function CL(ByVal colIndex As Long) As String
        Dim div As Integer = colIndex
        Dim colLetter As String = String.Empty
        Dim modnum As Integer = 0

        While div > 0
            modnum = (div - 1) Mod 26
            colLetter = Chr(65 + modnum) & colLetter
            div = CInt((div - modnum) \ 26)
        End While

        Return colLetter
    End Function

End Class
