
Imports System.Data.Odbc

Public Class FormBarang
    Private Sub LoadDataBarang()
        Dim conn As OdbcConnection = KoneksiDB.GetConnection()
        Dim cmd As New OdbcCommand("SELECT * FROM barang", conn)
        Dim adapter As New OdbcDataAdapter(cmd)
        Dim table As New DataTable()

        Try
            conn.Open()
            adapter.Fill(table)
            dgvBarang.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Kesalahan koneksi: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Dim conn As OdbcConnection = KoneksiDB.GetConnection()
        Dim cmd As New OdbcCommand("INSERT INTO barang (jenis_barang, nama_barang, harga_satuan) VALUES (?, ?, ?)", conn)

        cmd.Parameters.AddWithValue("@jenis", txtJenisBarang.Text)
        cmd.Parameters.AddWithValue("@nama", txtNamaBarang.Text)
        cmd.Parameters.AddWithValue("@harga", txtHargaSatuan.Text)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data barang berhasil ditambahkan!")
            LoadDataBarang()
        Catch ex As Exception
            MessageBox.Show("Kesalahan koneksi: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class
