Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class ADMINBOOKINGS
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\varsha v hegde\OneDrive\ドキュメント\vspsln.accdb")
    Public Property CallingForm As Form
    ' Variables to track selected appointment for editing
    Dim selectedAppointmentId As String = ""
    Dim selectedCustomerEmail As String = ""
    Dim isEditMode As Boolean = False

    ' Dictionary to store service names and their corresponding amounts
    Private ServiceAmounts As New Dictionary(Of String, Decimal)

    Private Sub ADMINBOOKINGS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Load services from database for combo box and amounts
        LoadServicesFromDatabase()

        ' Load user's bookings when form loads
        LoadMyBookings()

        ' Configure DataGridView
        ConfigureDataGridView()

        ' Initialize form controls
        ClearFormFields()
        SetFormMode(False)

        ' Initialize DateTimePicker
        InitializeDateTimePicker()

        ' Update form title
        Me.Text = "Admin Bookings Management - " & MAINFORM.CurrentUserName
    End Sub

    Private Sub InitializeDateTimePicker()
        Try
            ' Set DateTimePicker properties
            booking_Date.Format = DateTimePickerFormat.Short ' Shows only date (MM/dd/yyyy)
            booking_Date.Value = DateTime.Now.Date ' Set to current date without time
            booking_Date.MinDate = DateTime.Now.Date ' Prevent booking past dates
            booking_Date.MaxDate = DateTime.Now.AddMonths(6) ' Allow booking up to 6 months ahead
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

    Private Sub LoadMyBookings()
        Try
            ' Check if user is logged in
            If MAINFORM.CurrentUserEmail = "" Then
                MsgBox("Please login to view bookings.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Hide()
                MAINFORM.Show()
                Return
            End If

            cn.Open()

            Dim query As String = ""
            Dim cmd As OleDbCommand

            If MAINFORM.CurrentUserRole.ToLower() = "admin" Then
                ' Admin sees all appointments with all columns including new ones
                query = "SELECT ID as [Booking ID], cname as [Customer Name], age as Age, phone as Phone, " &
                       "email as Email, type as [Service Type], timing as [Appointment Time], " &
                       "booking_date as [Appointment Date], booked_date as [Booked On], " &
                       "payment_type as [Payment Type], payment_id as [Payment ID], " &
                       "amount as Amount FROM Appointments ORDER BY booked_date DESC"
                cmd = New OleDbCommand(query, cn)
            Else
                ' Regular user sees only their appointments
                query = "SELECT ID as [Booking ID], cname as [Customer Name], type as [Service Type], " &
                       "timing as [Appointment Time], booking_date as [Appointment Date], " &
                       "booked_date as [Booked On], payment_type as [Payment Type], " &
                       "amount as Amount FROM Appointments WHERE email = @email ORDER BY booked_date DESC"
                cmd = New OleDbCommand(query, cn)
                cmd.Parameters.AddWithValue("@email", MAINFORM.CurrentUserEmail)
            End If

            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ' Format the date and amount columns for better display
            FormatDataColumns(dt)

            ' Bind data to DataGridView
            If dt.Rows.Count > 0 Then
                dataGridView1.DataSource = dt

                ' Update label to show count
                If MAINFORM.CurrentUserRole.ToLower() = "admin" Then
                    label1.Text = "All Appointments (" & dt.Rows.Count & " total)"
                Else
                    label1.Text = "My Bookings (" & dt.Rows.Count & " appointments)"
                End If
            Else
                ' No bookings found
                dataGridView1.DataSource = Nothing
                If MAINFORM.CurrentUserRole.ToLower() = "admin" Then
                    label1.Text = "No Appointments Found"
                Else
                    label1.Text = "No Bookings Found"
                    MsgBox("You don't have any bookings yet. Would you like to book an appointment?", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Catch ex As Exception
            MsgBox("Error loading bookings: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub FormatDataColumns(dt As DataTable)
        Try
            ' Format date and amount columns for better display
            For Each row As DataRow In dt.Rows
                ' Format Appointment Date (booking_date) - show only date
                If Not IsDBNull(row("Appointment Date")) Then
                    Dim appointmentDate As DateTime
                    If DateTime.TryParse(row("Appointment Date").ToString(), appointmentDate) Then
                        row("Appointment Date") = appointmentDate.ToString("dd/MM/yyyy")
                    End If
                End If

                ' Format Booked On (booked_date) - show date and time
                If Not IsDBNull(row("Booked On")) Then
                    Dim bookedDateTime As DateTime
                    If DateTime.TryParse(row("Booked On").ToString(), bookedDateTime) Then
                        row("Booked On") = bookedDateTime.ToString("dd/MM/yyyy hh:mm tt")
                    End If
                End If

                ' Format Amount with currency symbol
                If Not IsDBNull(row("Amount")) Then
                    Dim amount As Decimal
                    If Decimal.TryParse(row("Amount").ToString(), amount) Then
                        row("Amount") = "₹" & amount.ToString("F2")
                    End If
                End If
            Next
        Catch ex As Exception
            ' If formatting fails, continue with original data
        End Try
    End Sub

    Private Sub ConfigureDataGridView()
        Try
            ' Configure DataGridView appearance
            With dataGridView1
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ReadOnly = True
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .BackgroundColor = Color.White
                .BorderStyle = BorderStyle.Fixed3D

                ' Set alternating row colors for better readability
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
                .RowsDefaultCellStyle.BackColor = Color.White

                ' Header styling
                .EnableHeadersVisualStyles = False
                .ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)

                ' Set specific column widths for better display
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            End With

            ' Set column widths after data is loaded
            AddHandler dataGridView1.DataBindingComplete, AddressOf SetColumnWidths

        Catch ex As Exception
            ' If DataGridView configuration fails, just continue
        End Try
    End Sub

    Private Sub SetColumnWidths(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        Try
            With dataGridView1
                If .Columns.Count > 0 Then
                    ' Set specific widths for different columns
                    For Each column As DataGridViewColumn In .Columns
                        Select Case column.Name
                            Case "Booking ID"
                                column.Width = 80
                            Case "Customer Name"
                                column.Width = 150
                            Case "Age"
                                column.Width = 50
                            Case "Phone"
                                column.Width = 100
                            Case "Email"
                                column.Width = 180
                            Case "Service Type"
                                column.Width = 120
                            Case "Appointment Time"
                                column.Width = 120
                            Case "Appointment Date"
                                column.Width = 110
                            Case "Booked On"
                                column.Width = 140
                            Case "Payment Type"
                                column.Width = 100
                            Case "Payment ID"
                                column.Width = 100
                            Case "Amount"
                                column.Width = 80
                                ' Right-align amount column
                                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        End Select
                    Next

                    ' Enable horizontal scrolling if needed
                    .ScrollBars = ScrollBars.Both
                End If
            End With
        Catch ex As Exception
            ' If column width setting fails, continue with auto-sizing
        End Try
    End Sub

    ' Handle row click to populate form fields for editing
    Private Sub dataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellClick
        Try
            If e.RowIndex >= 0 And MAINFORM.CurrentUserRole.ToLower() = "admin" Then
                Dim selectedRow As DataGridViewRow = dataGridView1.Rows(e.RowIndex)

                ' Get original data from database to populate form properly
                selectedAppointmentId = selectedRow.Cells("Booking ID").Value.ToString()
                PopulateFormFromDatabase(selectedAppointmentId)

                ' Enable edit/delete mode
                SetFormMode(True)
                isEditMode = True
            End If
        Catch ex As Exception
            MsgBox("Error selecting appointment: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateFormFromDatabase(appointmentId As String)
        Try
            cn.Open()

            ' Get full appointment data from database
            Dim query As String = "SELECT * FROM Appointments WHERE ID = @id"
            Dim cmd As New OleDbCommand(query, cn)
            cmd.Parameters.AddWithValue("@id", appointmentId)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                ' Populate form fields with original database values
                txtname.Text = reader("cname").ToString()
                txtage.Text = reader("age").ToString()
                txtphone.Text = reader("phone").ToString()
                txtemail.Text = reader("email").ToString()
                cmbtype.Text = reader("type").ToString()
                cmbtime.Text = reader("timing").ToString()

                ' Set booking date in DateTimePicker
                If Not IsDBNull(reader("booking_date")) Then
                    Dim bookingDate As DateTime
                    If DateTime.TryParse(reader("booking_date").ToString(), bookingDate) Then
                        booking_Date.Value = bookingDate.Date
                    End If
                End If

                ' Store the selected customer's email for reference
                selectedCustomerEmail = reader("email").ToString()
            End If

            reader.Close()
            cn.Close()

        Catch ex As Exception
            MsgBox("Error loading appointment details: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    ' Set form mode (enable/disable buttons and fields)
    Private Sub SetFormMode(hasSelection As Boolean)
        If hasSelection And MAINFORM.CurrentUserRole.ToLower() = "admin" Then
            ' Enable text fields for editing
            txtname.ReadOnly = False
            txtemail.ReadOnly = False
            txtphone.ReadOnly = False
            txtage.ReadOnly = False
            cmbtype.Enabled = True
            cmbtime.Enabled = True
            booking_Date.Enabled = True

            ' Enable action buttons
            btnsave.Enabled = True
            btndelete.Enabled = True
            btnsave.Text = "Update Appointment"
        Else
            ' Make text fields read-only
            txtname.ReadOnly = True
            txtemail.ReadOnly = True
            txtphone.ReadOnly = True
            txtage.ReadOnly = True
            cmbtype.Enabled = False
            cmbtime.Enabled = False
            booking_Date.Enabled = False

            ' Disable action buttons
            btnsave.Enabled = False
            btndelete.Enabled = False
            btnsave.Text = "Save"
        End If
    End Sub

    ' Clear all form fields
    Private Sub ClearFormFields()
        txtname.Text = ""
        txtemail.Text = ""
        txtphone.Text = ""
        txtage.Text = ""
        If cmbtype.Items.Count > 0 Then cmbtype.SelectedIndex = -1
        If cmbtime.Items.Count > 0 Then cmbtime.SelectedIndex = -1
        booking_Date.Value = DateTime.Now.Date
        selectedAppointmentId = ""
        selectedCustomerEmail = ""
        isEditMode = False
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbtype.SelectedIndexChanged
        ' This can be used to show amount if needed in admin interface
        If cmbtype.SelectedItem IsNot Nothing And ServiceAmounts.ContainsKey(cmbtype.SelectedItem.ToString()) Then
            ' You can add a label to show the service amount if needed
            ' lblAmount.Text = "Amount: ₹" & ServiceAmounts(cmbtype.SelectedItem.ToString()).ToString("F2")
        End If
    End Sub

    ' Save/Update appointment data
    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        Try
            ' Check if admin is logged in
            If MAINFORM.CurrentUserRole.ToLower() <> "admin" Then
                MsgBox("Only administrators can edit appointments.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate input fields
            If String.IsNullOrWhiteSpace(txtname.Text) Then
                MsgBox("Please enter customer name.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtname.Focus()
                Return
            End If

            If Not Regex.IsMatch(txtname.Text, "^[A-Za-z\s]+$") Then
                MsgBox("Name can contain only alphabets", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtname.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtage.Text) Then
                MsgBox("Please enter age.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtage.Focus()
                Return
            End If

            ' Validate age is numeric and in range
            Dim ageValue As Integer
            If Not Integer.TryParse(txtage.Text, ageValue) OrElse ageValue < 1 OrElse ageValue > 120 Then
                MsgBox("Please enter a valid age (1-120).", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtage.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtphone.Text) Then
                MsgBox("Please enter phone number.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtphone.Focus()
                Return
            End If

            If txtphone.Text.Length <> 10 OrElse Not IsNumeric(txtphone.Text) Then
                MsgBox("Phone number must be 10 digits only", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtphone.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtemail.Text) Then
                MsgBox("Please enter email address.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtemail.Focus()
                Return
            End If

            If Not txtemail.Text.ToLower.EndsWith("@gmail.com") Then
                MsgBox("Email must end with @gmail.com", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtemail.Focus()
                Return
            End If

            If cmbtype.Text = "" Then
                MsgBox("Please select a service type.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbtype.Focus()
                Return
            End If

            If cmbtime.Text = "" Then
                MsgBox("Please select an appointment time.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbtime.Focus()
                Return
            End If

            ' Validate booking date is not in the past
            If booking_Date.Value.Date < DateTime.Now.Date Then
                MsgBox("Appointment date cannot be in the past!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                booking_Date.Focus()
                Return
            End If

            If isEditMode And selectedAppointmentId <> "" Then
                ' Show confirmation popup before updating
                Dim result As DialogResult = MsgBox("Are you sure you want to update this appointment?" & vbCrLf & vbCrLf &
                                                  "Customer: " & txtname.Text & vbCrLf &
                                                  "Service: " & cmbtype.Text & vbCrLf &
                                                  "Date: " & booking_Date.Value.ToString("dd/MM/yyyy") & vbCrLf &
                                                  "Time: " & cmbtime.Text & vbCrLf & vbCrLf &
                                                  "Note: This will also update the customer's profile information.",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    UpdateAppointmentAndUser()
                End If
            Else
                MsgBox("Please select an appointment from the list to edit.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox("Error processing appointment update: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Update appointment and corresponding user data
    Private Sub UpdateAppointmentAndUser()
        Dim transaction As OleDbTransaction = Nothing
        Try
            cn.Open()
            transaction = cn.BeginTransaction()

            ' Get the amount for the selected service
            Dim serviceAmount As Decimal = 0
            If ServiceAmounts.ContainsKey(cmbtype.Text) Then
                serviceAmount = ServiceAmounts(cmbtype.Text)
            End If

            ' Update the appointment record with new columns
            Dim updateAppointmentQuery As String = "UPDATE Appointments SET cname = ?, age = ?, phone = ?, " &
                                                  "email = ?, type = ?, timing = ?, booking_date = ?, amount = ? WHERE ID = ?"
            Dim cmdAppointment As New OleDbCommand(updateAppointmentQuery, cn, transaction)
            cmdAppointment.Parameters.AddWithValue("@cname", txtname.Text.Trim())
            cmdAppointment.Parameters.AddWithValue("@age", Convert.ToInt32(txtage.Text))
            cmdAppointment.Parameters.AddWithValue("@phone", txtphone.Text.Trim())
            cmdAppointment.Parameters.AddWithValue("@email", txtemail.Text.Trim())
            cmdAppointment.Parameters.AddWithValue("@type", cmbtype.Text)
            cmdAppointment.Parameters.AddWithValue("@timing", cmbtime.Text)
            cmdAppointment.Parameters.AddWithValue("@booking_date", booking_Date.Value.Date.ToString("yyyy-MM-dd"))
            cmdAppointment.Parameters.AddWithValue("@amount", serviceAmount)
            cmdAppointment.Parameters.AddWithValue("@id", Convert.ToInt32(selectedAppointmentId))

            Dim appointmentRowsAffected As Integer = cmdAppointment.ExecuteNonQuery()

            ' Check if user exists in register table and update their information
            Dim checkUserQuery As String = "SELECT COUNT(*) FROM register WHERE email = ?"
            Dim cmdCheckUser As New OleDbCommand(checkUserQuery, cn, transaction)
            cmdCheckUser.Parameters.AddWithValue("@email", selectedCustomerEmail)
            Dim userExists As Integer = Convert.ToInt32(cmdCheckUser.ExecuteScalar())

            Dim userRowsAffected As Integer = 0
            If userExists > 0 Then
                ' Update user information in register table
                Dim updateUserQuery As String = "UPDATE register SET username = ?, email = ?, phoneno = ?, age = ? WHERE email = ?"
                Dim cmdUser As New OleDbCommand(updateUserQuery, cn, transaction)
                cmdUser.Parameters.AddWithValue("@username", txtname.Text.Trim())
                cmdUser.Parameters.AddWithValue("@email", txtemail.Text.Trim())
                cmdUser.Parameters.AddWithValue("@phoneno", txtphone.Text.Trim())
                cmdUser.Parameters.AddWithValue("@age", Convert.ToInt32(txtage.Text))
                cmdUser.Parameters.AddWithValue("@original_email", selectedCustomerEmail)

                userRowsAffected = cmdUser.ExecuteNonQuery()
            End If

            ' Commit the transaction if both updates were successful
            If appointmentRowsAffected > 0 Then
                transaction.Commit()

                If userExists > 0 And userRowsAffected > 0 Then
                    MsgBox("Appointment and customer data updated successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf userExists > 0 And userRowsAffected = 0 Then
                    MsgBox("Appointment updated, but customer data update failed. Please check customer information.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MsgBox("Appointment updated successfully! (Customer not found in register table)", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ' Refresh the bookings list
                cn.Close()
                LoadMyBookings()

                ' Clear form and disable editing
                ClearFormFields()
                SetFormMode(False)
            Else
                transaction.Rollback()
                MsgBox("No appointment was updated. Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            If transaction IsNot Nothing Then
                transaction.Rollback()
            End If
            MsgBox("Error updating appointment: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    ' Delete appointment
    Private Sub btndelete_Click(sender As System.Object, e As System.EventArgs) Handles btndelete.Click
        Try
            ' Check if admin is logged in
            If MAINFORM.CurrentUserRole.ToLower() <> "admin" Then
                MsgBox("Only administrators can delete appointments.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrEmpty(selectedAppointmentId) Then
                MsgBox("Please select an appointment to delete.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Confirmation popup
            Dim result As DialogResult = MsgBox("Are you sure you want to delete this appointment?" & vbCrLf & vbCrLf &
                                              "Customer: " & txtname.Text & vbCrLf &
                                              "Email: " & txtemail.Text & vbCrLf &
                                              "Service: " & cmbtype.Text & vbCrLf &
                                              "Date: " & booking_Date.Value.ToString("dd/MM/yyyy") & vbCrLf &
                                              "Time: " & cmbtime.Text & vbCrLf & vbCrLf &
                                              "This action cannot be undone.",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                cn.Open()

                ' Delete appointment from database
                Dim deleteQuery As String = "DELETE FROM Appointments WHERE ID = ?"
                Dim cmd As New OleDbCommand(deleteQuery, cn)
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(selectedAppointmentId))

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MsgBox("Appointment deleted successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh the bookings list
                    cn.Close()
                    LoadMyBookings()

                    ' Clear form and disable editing
                    ClearFormFields()
                    SetFormMode(False)
                Else
                    MsgBox("No appointment was deleted. Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
            MsgBox("Error deleting appointment: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    ' Cancel/Clear button functionality
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs)
        ClearFormFields()
        SetFormMode(False)
        dataGridView1.ClearSelection()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        MAINFORM.Show()
    End Sub

    Private Sub label1_Click(sender As System.Object, e As System.EventArgs) Handles label1.Click
        ' Refresh bookings when label is clicked
        LoadMyBookings()
    End Sub

    Private Sub dataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick
        ' This is now handled by CellClick event for row selection
    End Sub

    ' Add refresh button functionality
    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs)
        LoadMyBookings()
        ClearFormFields()
        SetFormMode(False)
        MsgBox("Bookings refreshed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Search functionality
    Private Sub txtSearch_TextChanged(sender As System.Object, e As System.EventArgs)
        Try
            If dataGridView1.DataSource IsNot Nothing Then
                Dim dt As DataTable = CType(dataGridView1.DataSource, DataTable)
                Dim searchText As String = CType(sender, TextBox).Text.Trim()

                If searchText = "" Then
                    dt.DefaultView.RowFilter = ""
                Else
                    ' Search in multiple columns including new ones
                    Dim filterExpression As String = String.Format(
                        "[Customer Name] LIKE '%{0}%' OR [Service Type] LIKE '%{0}%' OR " &
                        "[Appointment Time] LIKE '%{0}%' OR [Email] LIKE '%{0}%' OR " &
                        "[Phone] LIKE '%{0}%' OR [Appointment Date] LIKE '%{0}%'", searchText)

                    dt.DefaultView.RowFilter = filterExpression
                End If

                ' Clear selection when searching
                ClearFormFields()
                SetFormMode(False)
            End If
        Catch ex As Exception
            ' Ignore search errors
        End Try
    End Sub

    Private Sub booking_Date_ValueChanged(sender As System.Object, e As System.EventArgs) Handles booking_Date.ValueChanged
        ' Validate booking date when changed
        Try
            If booking_Date.Value.Date < DateTime.Now.Date Then
                MsgBox("Please select a current or future date for the appointment.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                booking_Date.Value = DateTime.Now.Date
            End If
        Catch ex As Exception
            ' Handle any date validation errors
        End Try
    End Sub

    ' Keep existing event handlers
    Private Sub txtname_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtname.TextChanged
        ' Real-time name validation
        If Not String.IsNullOrEmpty(txtname.Text) AndAlso Not Regex.IsMatch(txtname.Text, "^[A-Za-z\s]+$") Then
            ' Could add visual feedback here
        End If
    End Sub

    Private Sub txtphone_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtphone.TextChanged
        ' Real-time phone validation
        If Not String.IsNullOrEmpty(txtphone.Text) AndAlso (txtphone.Text.Length > 10 OrElse Not IsNumeric(txtphone.Text)) Then
            ' Could add visual feedback here
        End If
    End Sub

    Private Sub txtage_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtage.TextChanged
        ' Real-time age validation
        Dim age As Integer
        If Not String.IsNullOrEmpty(txtage.Text) AndAlso (Not Integer.TryParse(txtage.Text, age) OrElse age < 1 OrElse age > 120) Then
            ' Could add visual feedback here
        End If
    End Sub

    Private Sub txtemail_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtemail.TextChanged
        ' Real-time email validation
        If Not String.IsNullOrEmpty(txtemail.Text) AndAlso Not txtemail.Text.ToLower.EndsWith("@gmail.com") Then
            ' Could add visual feedback here
        End If
    End Sub

    Private Sub cmbtime_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbtime.SelectedIndexChanged
        ' Time selection validation if needed
    End Sub

    ' Form closing event
    Private Sub ADMINBOOKINGS_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Clean up resources
        If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

End Class