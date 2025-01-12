
Imports System.Data.Odbc

Public Class FormLogin
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim conn As OdbcConnection = KoneksiDB.GetConnection()
        Dim cmd As New OdbcCommand("SELECT * FROM users WHERE username = ? AND password = ?", conn)

        cmd.Parameters.AddWithValue("@username", txtUsername.Text)
        cmd.Parameters.AddWithValue("@password", txtPassword.Text)

        Try
            conn.Open()
            Dim reader As OdbcDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                MessageBox.Show("Login berhasil!")
                Dim formMenu As New FormMenu()
                formMenu.Show()
                Me.Hide()
            Else
                MessageBox.Show("Username atau password salah.")
            End If
        Catch ex As Exception
            MessageBox.Show("Kesalahan koneksi: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class
