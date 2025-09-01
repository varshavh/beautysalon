Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Public Class REGISTER
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\varsha v hegde\OneDrive\ドキュメント\vspsln.accdb")
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader

    Private Sub REGISTER_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub btnreg_Click(sender As System.Object, e As System.EventArgs) Handles btnreg.Click
        Dim nam As String = txtname.Text.Trim()  ' This is the user's name
        Dim email As String = txtemail.Text.Trim()
        Dim phone As String = txtphone.Text.Trim()
        Dim age As String = txtage.Text.Trim()
        Dim pwd As String = txtpass.Text.Trim()
        Dim cpwd As String = txtcpass.Text.Trim()
        Dim role As String = "user" ' Default role as user

        ' Validation checks
        If nam = "" Or email = "" Or phone = "" Or age = "" Or pwd = "" Or cpwd = "" Then
            MsgBox("All fields should be filled", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not Regex.IsMatch(nam, "^[A-Za-z\s]+$") Then
            MsgBox("Username should contain letters and spaces only", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not email.ToLower().EndsWith("@gmail.com") Then
            MsgBox("Email should end with @gmail.com", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not Regex.IsMatch(phone, "^[0-9]{10}$") Then
            MsgBox("Phone number should contain only 10 digits", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Age validation
        If Not IsNumeric(age) OrElse CInt(age) <= 0 OrElse CInt(age) > 120 Then
            MsgBox("Please enter a valid age (1-120)", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Password validation
        If pwd.Length < 6 Then
            MsgBox("Password should be at least 6 characters long", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If pwd <> cpwd Then
            MsgBox("Password and Confirm password should be same", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            con.Open()

            ' Check if email already exists
            cmd = New OleDbCommand("SELECT * FROM register WHERE email=@email", con)
            cmd.Parameters.AddWithValue("@email", email)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                MsgBox("Email already exists!!! Please choose another", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                con.Close()
                Exit Sub
            End If
            dr.Close()

            ' Check if name already exists (optional - you might want to allow same names)
            cmd = New OleDbCommand("SELECT * FROM register WHERE username=@username", con)
            cmd.Parameters.AddWithValue("@username", nam)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                MsgBox("This name is already registered!!! Please use a different name", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                con.Close()
                Exit Sub
            End If
            dr.Close()

            ' Insert new user with default role
            cmd = New OleDbCommand("INSERT INTO register(username,email,phoneno,age,[password],role)VALUES(@nam,@email,@phone,@age,@pwd,@role)", con)
            cmd.Parameters.AddWithValue("@nam", nam)
            cmd.Parameters.AddWithValue("@email", email)
            cmd.Parameters.AddWithValue("@phone", phone)
            cmd.Parameters.AddWithValue("@age", age)
            cmd.Parameters.AddWithValue("@pwd", pwd)
            cmd.Parameters.AddWithValue("@role", role)
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Registration successful!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            login.Show()

        Catch ex As Exception
            MsgBox("Error!! " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                dr.Close()
            End If
        End Try
    End Sub

    Private Sub btnreset_Click(sender As System.Object, e As System.EventArgs) Handles btnreset.Click
        txtname.Clear()
        txtemail.Clear()
        txtphone.Clear()
        txtage.Clear()
        txtpass.Clear()
        txtcpass.Clear()
    End Sub

    Private Sub btnback_Click(sender As System.Object, e As System.EventArgs) Handles btnback.Click
        login.Show()
        Me.Hide()
    End Sub

    Private Sub checkpass_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkpass.CheckedChanged
        If checkpass.Checked Then
            txtpass.UseSystemPasswordChar = False
        Else
            txtpass.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub checkcpass_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkcpass.CheckedChanged
        If checkcpass.Checked Then
            txtcpass.UseSystemPasswordChar = False
        Else
            txtcpass.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
    End Sub
End Class