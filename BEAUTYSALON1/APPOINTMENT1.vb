Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class APPOINTMENT1
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\varsha v hegde\OneDrive\ドキュメント\vspsln.accdb")

    ' Public variables to pass appointment data to payment form
    Public Shared AppointmentData As New Dictionary(Of String, String)

    Private Sub APPOINTMENT1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Prefill user details from MAINFORM
        PrefillUserDetails()

        ' Initialize payment type dropdown
        InitializePaymentTypes()
    End Sub

    Private Sub InitializePaymentTypes()
        ' Add payment options to the combo box
        payment_type.Items.Clear()
        payment_type.Items.Add("Cash Payment")
        payment_type.Items.Add("Online Payment")
        payment_type.SelectedIndex = -1
    End Sub

    Private Sub PrefillUserDetails()
        ' Get current user details from MAINFORM and prefill the form
        Try
            If MAINFORM.CurrentUserName <> "" And MAINFORM.CurrentUserRole.ToLower() <> "admin" Then
                ' Prefill with logged-in user details
                txtname.Text = MAINFORM.CurrentUserName
                txtage.Text = MAINFORM.CurrentUserAge
                txtphone.Text = MAINFORM.CurrentUserPhone
                txtemail.Text = MAINFORM.CurrentUserEmail

                ' Make these fields readonly so user can't change their own details
                txtname.ReadOnly = True
                txtage.ReadOnly = True
                txtphone.ReadOnly = True
                txtemail.ReadOnly = True

                ' Set focus to appointment type since personal details are prefilled
                If cmbtype.Items.Count > 0 Then
                    cmbtype.Focus()
                End If

            ElseIf MAINFORM.CurrentUserRole.ToLower() = "admin" Then
                ' For admin, leave fields empty so they can book for any customer
                txtname.ReadOnly = False
                txtage.ReadOnly = False
                txtphone.ReadOnly = False
                txtemail.ReadOnly = False
            End If

        Catch ex As Exception
            ' If there's any error, just leave fields empty
            MsgBox("Could not load user details: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            ' Validation checks
            If txtname.Text = "" Or txtage.Text = "" Or txtphone.Text = "" Or txtemail.Text = "" Or cmbtype.Text = "" Or cmbtime.Text = "" Or payment_type.Text = "" Then
                MsgBox("Please fill all the fields including payment type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not Regex.IsMatch(txtname.Text, "^[A-Za-z\s]+$") Then
                MsgBox("Name can contain only alphabets", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not IsNumeric(txtage.Text) OrElse CInt(txtage.Text) <= 0 OrElse CInt(txtage.Text) > 120 Then
                MsgBox("Enter valid Age (1-120)!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If txtphone.Text.Length <> 10 OrElse Not IsNumeric(txtphone.Text) Then
                MsgBox("Phone number must be 10 digits only", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not txtemail.Text.ToLower.EndsWith("@gmail.com") Then
                MsgBox("Email must end with @gmail.com", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Check for duplicate appointments (same email, type, and timing)
            cn.Open()
            Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM Appointments WHERE email=@email AND type=@type AND timing=@timing", cn)
            checkCmd.Parameters.AddWithValue("@email", txtemail.Text)
            checkCmd.Parameters.AddWithValue("@type", cmbtype.Text)
            checkCmd.Parameters.AddWithValue("@timing", cmbtime.Text)

            Dim existingCount As Integer = CInt(checkCmd.ExecuteScalar())
            cn.Close()

            If existingCount > 0 Then
                MsgBox("Appointment already exists for this email, service type, and timing!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Handle payment based on selected payment type
            If payment_type.Text = "Cash Payment" Then
                ' Direct booking for cash payment
                SaveAppointment("Cash", "")
            ElseIf payment_type.Text = "Online Payment" Then
                ' Store appointment data and go to payment page
                StoreAppointmentData()
                ' Show payment form
                Dim paymentForm As New PAYMENT()
                paymentForm.Show()
                Me.Hide()
            End If

        Catch ex As Exception
            MsgBox("Error!! " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub StoreAppointmentData()
        ' Store appointment data in shared dictionary for payment form
        AppointmentData.Clear()
        AppointmentData.Add("name", txtname.Text)
        AppointmentData.Add("age", txtage.Text)
        AppointmentData.Add("phone", txtphone.Text)
        AppointmentData.Add("email", txtemail.Text)
        AppointmentData.Add("type", cmbtype.Text)
        AppointmentData.Add("timing", cmbtime.Text)
    End Sub

    Public Sub SaveAppointment(paymentType As String, paymentId As String)
        Try
            cn.Open()
            Dim cmd As New OleDbCommand("INSERT INTO Appointments(cname,age,phone,email,type,timing,booking_date,payment_type,payment_id)VALUES(@name,@age,@phone,@email,@type,@timing,@booking_date,@payment_type,@payment_id)", cn)

            ' Use stored data if available (for online payment), otherwise use form data
            If AppointmentData.Count > 0 Then
                cmd.Parameters.AddWithValue("@name", AppointmentData("name"))
                cmd.Parameters.AddWithValue("@age", AppointmentData("age"))
                cmd.Parameters.AddWithValue("@phone", AppointmentData("phone"))
                cmd.Parameters.AddWithValue("@email", AppointmentData("email"))
                cmd.Parameters.AddWithValue("@type", AppointmentData("type"))
                cmd.Parameters.AddWithValue("@timing", AppointmentData("timing"))
            Else
                cmd.Parameters.AddWithValue("@name", txtname.Text)
                cmd.Parameters.AddWithValue("@age", txtage.Text)
                cmd.Parameters.AddWithValue("@phone", txtphone.Text)
                cmd.Parameters.AddWithValue("@email", txtemail.Text)
                cmd.Parameters.AddWithValue("@type", cmbtype.Text)
                cmd.Parameters.AddWithValue("@timing", cmbtime.Text)
            End If

            cmd.Parameters.AddWithValue("@booking_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            cmd.Parameters.AddWithValue("@payment_type", paymentType)

            ' Set payment_id to null/empty for cash, actual ID for online
            If paymentId = "" Then
                cmd.Parameters.AddWithValue("@payment_id", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@payment_id", paymentId)
            End If

            cmd.ExecuteNonQuery()
            cn.Close()

            Dim customerName As String = If(AppointmentData.Count > 0, AppointmentData("name"), txtname.Text)
            MsgBox("Appointment Successful for " & customerName & "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Ask if user wants to book another appointment
            Dim result As DialogResult = MsgBox("Do you want to book another appointment?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                ' Clear only appointment-specific fields, keep user details
                ClearAppointmentFields()
                AppointmentData.Clear()
            Else
                ' Go back to main form
                MAINFORM.Show()
                Me.Hide()
                AppointmentData.Clear()
            End If

        Catch ex As Exception
            MsgBox("Error saving appointment: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub ClearAppointmentFields()
        ' Clear only appointment-specific fields, keep user details prefilled
        cmbtype.SelectedIndex = -1
        cmbtime.SelectedIndex = -1
        payment_type.SelectedIndex = -1

        ' Set focus back to appointment type
        If cmbtype.Items.Count > 0 Then
            cmbtype.Focus()
        End If
    End Sub

    Private Sub btnreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreset.Click
        If MAINFORM.CurrentUserRole.ToLower() = "admin" Then
            ' Admin can reset all fields
            txtname.Clear()
            txtage.Clear()
            txtphone.Clear()
            txtemail.Clear()
        Else
            ' Regular users can only reset appointment fields, personal details remain prefilled
            Dim result As DialogResult = MsgBox("This will reset appointment details only. Your personal information will remain. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                ' Keep personal details, only clear appointment fields
                ClearAppointmentFields()
                Exit Sub
            Else
                Exit Sub
            End If
        End If

        ' Clear appointment fields
        cmbtype.SelectedIndex = -1
        cmbtime.SelectedIndex = -1
        payment_type.SelectedIndex = -1
    End Sub

    Private Sub btnback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        MAINFORM.Show()
        Me.Hide()
    End Sub

    Private Sub txtamt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtemail.TextChanged
    End Sub

    ' Optional: Add button to allow users to edit their details if needed
    Private Sub btnEditDetails_Click(sender As System.Object, e As System.EventArgs)
        If MAINFORM.CurrentUserRole.ToLower() <> "admin" Then
            Dim result As DialogResult = MsgBox("Do you want to edit your personal details for this appointment?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                txtname.ReadOnly = False
                txtage.ReadOnly = False
                txtphone.ReadOnly = False
                txtemail.ReadOnly = False
                txtname.Focus()
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles payment_type.SelectedIndexChanged
        ' Optional: You can add logic here to show/hide amount field based on payment type
    End Sub

    Private Sub Label11_Click(sender As System.Object, e As System.EventArgs) Handles Label11.Click
    End Sub
End Class