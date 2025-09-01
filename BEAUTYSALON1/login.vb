Imports System.Data.OleDb
Public Class login
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\varsha v hegde\OneDrive\ドキュメント\vspsln.accdb")
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpass.UseSystemPasswordChar = True
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub chkpass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpass.CheckedChanged
        If chkpass.Checked Then
            txtpass.UseSystemPasswordChar = False
        Else
            txtpass.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub txtpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.TextChanged

    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub acclink_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles acclink.LinkClicked
        Me.Hide()
        REGISTER.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub btnlogin_Click(sender As System.Object, e As System.EventArgs) Handles btnlogin.Click
        Dim uname As String = txtname.Text.Trim()
        Dim pwd As String = txtpass.Text.Trim()
        If uname = "" OrElse pwd = "" Then
            MsgBox("Please enter username and password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If uname.ToLower() = "admin" AndAlso pwd = "vs2512" Then
            MsgBox("Admin Login successfull!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            MAINFORM.Show()
            Exit Sub
        End If
        Try
            cn.Open()
            cmd = New OleDbCommand("select * from register where username=@uname and [password]=@pwd", cn)
            cmd.Parameters.AddWithValue("@uname", uname)
            cmd.Parameters.AddWithValue("@pwd", pwd)
            dr = cmd.ExecuteReader()
            If dr.Read Then
                Dim role As String = dr("role").ToString()
                MAINFORM.CurrentUserRole = role
                MAINFORM.Show()
                MsgBox("Welcome to Beauty Salon", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
            Else
                MsgBox("Invalid username or password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            cn.Close()
        Catch ex As Exception
            MsgBox("Error!!" & ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
End Class