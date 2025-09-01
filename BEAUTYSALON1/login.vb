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
        Dim email As String = txtname.Text.Trim()  ' Now using email instead of username
        Dim pwd As String = txtpass.Text.Trim()

        ' Basic validation
        If email = "" OrElse pwd = "" Then
            MsgBox("Please enter email and password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Email format validation
        If Not email.ToLower().EndsWith("@gmail.com") And email.ToLower() <> "admin" Then
            MsgBox("Email should end with @gmail.com", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Admin login check
        If email.ToLower() = "admin" AndAlso pwd = "vs2512" Then
            MsgBox("Admin Login successful!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Set admin details
            Dim mainForm As New MAINFORM()
            mainForm.SetUserDetails("Admin", "admin@beautysalon.com", "0000000000", "N/A", "admin")
            Me.Hide()
            mainForm.Show()
            Exit Sub
        End If

        ' Database login verification using email
        Try
            cn.Open()
            ' Updated query to use email for login
            cmd = New OleDbCommand("SELECT * FROM register WHERE email=@email AND [password]=@pwd", cn)
            cmd.Parameters.AddWithValue("@email", email)
            cmd.Parameters.AddWithValue("@pwd", pwd)
            dr = cmd.ExecuteReader()

            If dr.Read Then
                ' Get user information from database
                Dim userName As String = dr("username").ToString()  ' Get name from database
                Dim userPhone As String = dr("phoneno").ToString()
                Dim userAge As String = dr("age").ToString()
                Dim userRole As String = dr("role").ToString()

                MsgBox("Welcome to Beauty Salon, " & userName & "! (Role: " & userRole & ")", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dr.Close()
                cn.Close()

                ' Create new instance of MAINFORM and pass user details
                Dim mainForm As New MAINFORM()
                mainForm.SetUserDetails(userName, email, userPhone, userAge, userRole)

                Me.Hide()
                mainForm.Show()
            Else
                MsgBox("Invalid email or password", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                cn.Close()
            End If

        Catch ex As Exception
            MsgBox("Error!! " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                dr.Close()
            End If
        End Try
    End Sub

    Private Sub label1_Click(sender As System.Object, e As System.EventArgs) Handles label1.Click

    End Sub
End Class