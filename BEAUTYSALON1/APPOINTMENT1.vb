Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Public Class APPOINTMENT1
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\varsha v hegde\OneDrive\ドキュメント\vspsln.accdb")
    Private Sub APPOINTMENT1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            If txtname.Text = "" Or txtage.Text = "" Or txtphone.Text = "" Or txtemail.Text = "" Or cmbtype.Text = "" Or cmbtime.Text = "" Then
                MsgBox("Please fill all the fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Not Regex.IsMatch(txtname.Text, "^[A-Za-z\s]+$") Then
                MsgBox("Name can contain only  alphabets", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Not IsNumeric(txtage.Text) OrElse CInt(txtage.Text) <= 0 Then
                MsgBox("Enter valid Age!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtphone.Text.Length <> 10 Then
                MsgBox("Phone number must be 10 digits only", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Not txtemail.Text.ToLower.EndsWith("@gmail.com") Then
                MsgBox("Email must end with@gmail.com", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            cn.Open()
            Dim cmd As New OleDbCommand("INSERT INTO Appointments(cname,age,phone,email,type,timing)VALUES(@name,@age,@phone,@email,@type,@timing)", cn)
            cmd.Parameters.AddWithValue("@name", txtname.Text)
            cmd.Parameters.AddWithValue("@age", txtage.Text)
            cmd.Parameters.AddWithValue("@phone", txtphone.Text)
            cmd.Parameters.AddWithValue("@email", txtemail.Text)
            cmd.Parameters.AddWithValue("@type", cmbtype.Text)
            cmd.Parameters.AddWithValue("@timing", cmbtime.Text)
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Appointment Successsful!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox("Error!!" & ex.Message)
            cn.Close()
        End Try
    End Sub

    Private Sub btnreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreset.Click
        txtname.Clear()
        txtage.Clear()
        txtphone.Clear()
        txtemail.Clear()
        cmbtype.SelectedIndex = -1
        cmbtime.SelectedIndex = -1
    End Sub

    Private Sub btnback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        login.Show()
        Me.Hide()
    End Sub

    Private Sub txtamt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtemail.TextChanged

    End Sub
End Class