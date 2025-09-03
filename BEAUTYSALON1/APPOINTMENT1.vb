Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class APPOINTMENT1
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\varsha v hegde\OneDrive\ドキュメント\vspsln.accdb")
    Public Property CallingForm As Form
    ' Public variables to pass appointment data to payment form
    Public Shared AppointmentData As New Dictionary(Of String, String)

    ' Dictionary to store service names and their corresponding amounts
    Private ServiceAmounts As New Dictionary(Of String, Decimal)

    Private Sub APPOINTMENT1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Load services from database first
        LoadServicesFromDatabase()

        ' Prefill user details from MAINFORM
        PrefillUserDetails()

        ' Initialize payment type dropdown
        InitializePaymentTypes()

        ' Initialize DateTimePicker for booking date
        InitializeDateTimePicker()

        ' Disable amount field so user cannot change it
        txtamt.ReadOnly = True
        txtamt.Enabled = False
    End Sub

    Private Sub InitializeDateTimePicker()
        Try
            ' Set DateTimePicker properties
            DateTimePicker1.Format = DateTimePickerFormat.Short ' Shows only date (MM/dd/yyyy)
            DateTimePicker1.Value = DateTime.Now.Date ' Set to current date without time
            DateTimePicker1.MinDate = DateTime.Now.Date ' Prevent booking past dates
            DateTimePicker1.MaxDate = DateTime.Now.AddMonths(6) ' Allow booking up to 6 months ahead
        Catch ex As Exception
            MsgBox("Error initializing date picker: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub LoadServicesFromDatabase()
        Try
            cn.Open()

            ' Clear existing items and dictionary
            cmbtype.Items.Clear()
            ServiceAmounts.Clear()

            ' Query to get service names and amounts from services table
            Dim cmd As New OleDbCommand("SELECT service_name, amount FROM services ORDER BY service_name", cn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim serviceName As String = reader("service_name").ToString()
                Dim amount As Decimal = Convert.ToDecimal(reader("amount"))

                ' Add to combo box
                cmbtype.Items.Add(serviceName)

                ' Store in dictionary for amount lookup
                ServiceAmounts.Add(serviceName, amount)
            End While

            reader.Close()
            cn.Close()

            ' Set default selection
            If cmbtype.Items.Count > 0 Then
                cmbtype.SelectedIndex = -1 ' No default selection
            End If

        Catch ex As Exception
            MsgBox("Error loading services: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbtype.SelectedIndexChanged
        ' Auto-fill amount when service type is selected
        If cmbtype.SelectedItem IsNot Nothing Then
            Dim selectedService As String = cmbtype.SelectedItem.ToString()

            If ServiceAmounts.ContainsKey(selectedService) Then
                ' Set the amount in the text field
                txtamt.Text = ServiceAmounts(selectedService).ToString("F2") ' Format to 2 decimal places
            End If
        Else
            ' Clear amount if no service selected
            txtamt.Clear()
        End If
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

            ' Validate booking date is not in the past
            If DateTimePicker1.Value.Date < DateTime.Now.Date Then
                MsgBox("Booking date cannot be in the past!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            ' Check for duplicate appointments (same email, type, timing, and booking date)
            cn.Open()
            Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM Appointments WHERE email=@email AND type=@type AND timing=@timing AND booking_date=@booking_date", cn)
            checkCmd.Parameters.AddWithValue("@email", txtemail.Text)
            checkCmd.Parameters.AddWithValue("@type", cmbtype.Text)
            checkCmd.Parameters.AddWithValue("@timing", cmbtime.Text)
            checkCmd.Parameters.AddWithValue("@booking_date", DateTimePicker1.Value.Date.ToString("yyyy-MM-dd"))

            Dim existingCount As Integer = CInt(checkCmd.ExecuteScalar())
            cn.Close()

            If existingCount > 0 Then
                MsgBox("Appointment already exists for this email, service type, timing, and date!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                paymentForm.CallingForm = Me
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
        AppointmentData.Add("amount", txtamt.Text) ' Also store the amount
        AppointmentData.Add("booking_date", DateTimePicker1.Value.Date.ToString("yyyy-MM-dd")) ' Store selected booking date
    End Sub

    Public Sub SaveAppointment(paymentType As String, paymentId As String)
        Try
            cn.Open()

            ' FIXED: Insert appointment with correct parameter order matching the column order
            Dim cmd As New OleDbCommand("INSERT INTO Appointments(cname,age,phone,email,type,timing,booking_date,booked_date,payment_type,payment_id,amount)VALUES(@name,@age,@phone,@email,@type,@timing,@booking_date,@booked_date,@payment_type,@payment_id,@amount)", cn)

            ' Use stored data if available (for online payment), otherwise use form data
            If AppointmentData.Count > 0 Then
                cmd.Parameters.AddWithValue("@name", AppointmentData("name"))
                cmd.Parameters.AddWithValue("@age", AppointmentData("age"))
                cmd.Parameters.AddWithValue("@phone", AppointmentData("phone"))
                cmd.Parameters.AddWithValue("@email", AppointmentData("email"))
                cmd.Parameters.AddWithValue("@type", AppointmentData("type"))
                cmd.Parameters.AddWithValue("@timing", AppointmentData("timing"))
                cmd.Parameters.AddWithValue("@booking_date", AppointmentData("booking_date")) ' User selected date
                cmd.Parameters.AddWithValue("@booked_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) ' Current timestamp
                cmd.Parameters.AddWithValue("@payment_type", paymentType)

                ' Set payment_id to null/empty for cash, actual ID for online
                If paymentId = "" Then
                    cmd.Parameters.AddWithValue("@payment_id", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@payment_id", paymentId)
                End If

                cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(AppointmentData("amount")))
            Else
                cmd.Parameters.AddWithValue("@name", txtname.Text)
                cmd.Parameters.AddWithValue("@age", txtage.Text)
                cmd.Parameters.AddWithValue("@phone", txtphone.Text)
                cmd.Parameters.AddWithValue("@email", txtemail.Text)
                cmd.Parameters.AddWithValue("@type", cmbtype.Text)
                cmd.Parameters.AddWithValue("@timing", cmbtime.Text)
                cmd.Parameters.AddWithValue("@booking_date", DateTimePicker1.Value.Date.ToString("yyyy-MM-dd")) ' User selected date
                cmd.Parameters.AddWithValue("@booked_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) ' Current timestamp
                cmd.Parameters.AddWithValue("@payment_type", paymentType)

                ' Set payment_id to null/empty for cash, actual ID for online
                If paymentId = "" Then
                    cmd.Parameters.AddWithValue("@payment_id", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@payment_id", paymentId)
                End If

                cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(txtamt.Text))
            End If

            cmd.ExecuteNonQuery()

            ' Get the created appointment ID to update payment record
            If paymentType = "Online" And paymentId <> "" Then
                Dim getAppointmentIdCmd As New OleDbCommand("SELECT @@IDENTITY", cn)
                Dim appointmentId As String = getAppointmentIdCmd.ExecuteScalar().ToString()

                ' Update the payment record with the appointment ID
                Dim updatePaymentCmd As New OleDbCommand("UPDATE Payments SET appointment_id = @appointment_id WHERE ID = @payment_id", cn)
                updatePaymentCmd.Parameters.AddWithValue("@appointment_id", appointmentId)
                updatePaymentCmd.Parameters.AddWithValue("@payment_id", paymentId)
                updatePaymentCmd.ExecuteNonQuery()
            End If

            cn.Close()

            Dim customerName As String = If(AppointmentData.Count > 0, AppointmentData("name"), txtname.Text)
            Dim bookingDate As String = If(AppointmentData.Count > 0, AppointmentData("booking_date"), DateTimePicker1.Value.Date.ToString("yyyy-MM-dd"))
            MsgBox("Appointment Successful for " & customerName & " on " & DateTime.Parse(bookingDate).ToString("dd/MM/yyyy") & "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Ask if user wants to book another appointment
            Dim result As DialogResult = MsgBox("Do you want to book another appointment?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                ' Clear only appointment-specific fields, keep user details
                ClearAppointmentFields()
                AppointmentData.Clear()
            Else
                ' Go back to main form
                If CallingForm IsNot Nothing Then
                    CallingForm.Show()
                Else
                    ' Fallback - create new MAINFORM if no calling form reference
                    Dim mainForm As New MAINFORM()
                    mainForm.Show()
                End If
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
        txtamt.Clear() ' Also clear the amount
        DateTimePicker1.Value = DateTime.Now.Date ' Reset to current date

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
        txtamt.Clear()
        DateTimePicker1.Value = DateTime.Now.Date ' Reset to current date
    End Sub

    Private Sub btnback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        Me.Hide()
        CallingForm.Show()
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

    Public Sub back_main_form()
        If CallingForm IsNot Nothing Then
            CallingForm.Show()
        Else
            ' Fallback - create new MAINFORM if no calling form reference
            Dim mainForm As New MAINFORM()
            mainForm.Show()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles payment_type.SelectedIndexChanged
        ' Optional: You can add logic here to show/hide amount field based on payment type
    End Sub

    Private Sub Label11_Click(sender As System.Object, e As System.EventArgs) Handles Label11.Click
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtamt.TextChanged
        ' This event handler is now disabled since txtamt is read-only
    End Sub

    Private Sub Label12_Click(sender As System.Object, e As System.EventArgs) Handles amt.Click
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        ' Optional: Add validation or logic when date changes
        Try
            ' Ensure selected date is not in the past
            If DateTimePicker1.Value.Date < DateTime.Now.Date Then
                MsgBox("Please select a current or future date for the appointment.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                DateTimePicker1.Value = DateTime.Now.Date
            End If
        Catch ex As Exception
            ' Handle any date validation errors
        End Try
    End Sub
End Class