
Imports System.Data.Odbc

Module KoneksiDB
    Public Function GetConnection() As OdbcConnection
        Dim connectionString As String = "DSN=connect_dbkasir;" ' Ganti 'db_kasir' dengan nama DSN Anda
        Dim conn As New OdbcConnection(connectionString)
        Return conn
    End Function
End Module
