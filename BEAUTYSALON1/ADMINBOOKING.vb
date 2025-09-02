Imports System.Data.OleDb

Public Class ADMINBOOKINGS
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\varsha v hegde\OneDrive\ドキュメント\vspsln.accdb")

    ' Variables to track selected appointment for editing
    Dim selectedAppointmentId As String = ""
    Dim selectedCustomerEmail As String = ""
    Dim isEditMode As Boolean = False

    Private Sub ADMINBOOKINGS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Load user's bookings when form loads
        LoadMyBookings()

        ' Configure DataGridView
        ConfigureDataGridView()

        ' Initialize form controls
        ClearFormFields()
        SetFormMode(False)

        ' Update form title
        Me.Text = "My Bookings - " & MAINFORM.CurrentUserName
    End Sub

    Private Sub LoadMyBookings()
        Try
            ' Check if user is logged in
            If MAINFORM.CurrentUserEmail = "" Then
                MsgBox("Please login to view your bookings.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Hide()
                MAINFORM.Show()
                Return
            End If

            cn.Open()

            Dim query As String = ""
            Dim cmd As OleDbCommand

            If MAINFORM.CurrentUserRole.ToLower() = "admin" Then
                ' Admin sees all appointments
                query = "SELECT ID as [Booking ID], cname as [Customer Name], age as Age, phone as Phone, " &
                       "email as Email, type as [Service Type], timing as [Appointment Time], " &
                       "booking_date as [Booking Date], payment_type as [Payment Type], " &
                       "payment_id as [Payment ID] FROM Appointments ORDER BY booking_date DESC"
                cmd = New OleDbCommand(query, cn)
            Else
                ' Regular user sees only their appointments
                query = "SELECT ID as [Booking ID], cname as [Customer Name], age as Age, phone as Phone, " &
                       "email as Email, type as [Service Type], timing as [Appointment Time], " &
                       "booking_date as [Booking Date], payment_type as [Payment Type], " &
                       "payment_id as [Payment ID] FROM Appointments WHERE email = @email ORDER BY booking_date DESC"
                cmd = New OleDbCommand(query, cn)
                cmd.Parameters.AddWithValue("@email", MAINFORM.CurrentUserEmail)
            End If

            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

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
            End With
        Catch ex As Exception
            ' If DataGridView configuration fails, just continue
        End Try
    End Sub

    ' NEW: Handle row click to populate form fields for editing
    Private Sub dataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellClick
        Try
            If e.RowIndex >= 0 And MAINFORM.CurrentUserRole.ToLower() = "admin" Then
                Dim selectedRow As DataGridViewRow = dataGridView1.Rows(e.RowIndex)

                ' Populate form fields with selected appointment data
                selectedAppointmentId = selectedRow.Cells("Booking ID").Value.ToString()
                txtname.Text = selectedRow.Cells("Customer Name").Value.ToString()
                txtage.Text = selectedRow.Cells("Age").Value.ToString()
                txtphone.Text = selectedRow.Cells("Phone").Value.ToString()
                txtemail.Text = selectedRow.Cells("Email").Value.ToString()
                cmbtype.Text = selectedRow.Cells("Service Type").Value.ToString()
                cmbtime.Text = selectedRow.Cells("Appointment Time").Value.ToString()

                ' Store the selected customer's email for reference
                selectedCustomerEmail = selectedRow.Cells("Email").Value.ToString()

                ' Enable edit/delete mode
                SetFormMode(True)
                isEditMode = True
            End If
        Catch ex As Exception
            MsgBox("Error selecting appointment: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' NEW: Set form mode (enable/disable buttons and fields)
    Private Sub SetFormMode(hasSelection As Boolean)
        If hasSelection And MAINFORM.CurrentUserRole.ToLower() = "admin" Then
            ' Enable text fields for editing
            txtname.ReadOnly = False
            txtemail.ReadOnly = False
            txtphone.ReadOnly = False
            txtage.ReadOnly = False
            cmbtype.Enabled = True
            cmbtime.Enabled = True

            ' Enable action buttons
            btnsave.Enabled = True
            btndelete.Enabled = True
            btnsave.Text = "Update Customer"
        Else
            ' Make text fields read-only
            txtname.ReadOnly = True
            txtemail.ReadOnly = True
            txtphone.ReadOnly = True
            txtage.ReadOnly = True
            cmbtype.Enabled = False
            cmbtime.Enabled = False

            ' Disable action buttons
            btnsave.Enabled = False
            btndelete.Enabled = False
            btnsave.Text = "Save"
        End If
    End Sub

    ' NEW: Clear all form fields
    Private Sub ClearFormFields()
        txtname.Text = ""
        txtemail.Text = ""
        txtphone.Text = ""
        txtage.Text = ""
        If cmbtype.Items.Count > 0 Then cmbtype.SelectedIndex = -1
        If cmbtime.Items.Count > 0 Then cmbtime.SelectedIndex = -1
        selectedAppointmentId = ""
        selectedCustomerEmail = ""
        isEditMode = False
    End Sub

    ' NEW: Save/Update appointment data - with proper event handler
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

            If String.IsNullOrWhiteSpace(txtemail.Text) Then
                MsgBox("Please enter email address.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtemail.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtphone.Text) Then
                MsgBox("Please enter phone number.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtphone.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtage.Text) Then
                MsgBox("Please enter age.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtage.Focus()
                Return
            End If

            ' Validate age is numeric
            Dim ageValue As Integer
            If Not Integer.TryParse(txtage.Text, ageValue) OrElse ageValue < 1 OrElse ageValue > 150 Then
                MsgBox("Please enter a valid age (1-150).", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtage.Focus()
                Return
            End If

            ' Validate email format
            If Not IsValidEmail(txtemail.Text) Then
                MsgBox("Please enter a valid email address.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            If isEditMode And selectedAppointmentId <> "" Then
                ' Show confirmation popup before updating
                Dim result As DialogResult = MsgBox("Are you sure you want to update this appointment?" & vbCrLf & vbCrLf &
                                                  "Customer: " & txtname.Text & vbCrLf &
                                                  "Service: " & cmbtype.Text & vbCrLf &
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

    ' NEW: Update appointment and corresponding user data
    Private Sub UpdateAppointmentAndUser()
        Dim transaction As OleDbTransaction = Nothing
        Try
            cn.Open()
            transaction = cn.BeginTransaction()

            ' First, update the appointment record
            Dim updateAppointmentQuery As String = "UPDATE Appointments SET cname = ?, age = ?, phone = ?, " &
                                                  "email = ?, type = ?, timing = ? WHERE ID = ?"
            Dim cmdAppointment As New OleDbCommand(updateAppointmentQuery, cn, transaction)
            cmdAppointment.Parameters.AddWithValue("@cname", txtname.Text.Trim())
            cmdAppointment.Parameters.AddWithValue("@age", Convert.ToInt32(txtage.Text))
            cmdAppointment.Parameters.AddWithValue("@phone", txtphone.Text.Trim())
            cmdAppointment.Parameters.AddWithValue("@email", txtemail.Text.Trim())
            cmdAppointment.Parameters.AddWithValue("@type", cmbtype.Text)
            cmdAppointment.Parameters.AddWithValue("@timing", cmbtime.Text)
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

    ' NEW: Delete appointment - with proper event handler and confirmation popup
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

            ' Confirmation popup similar to CUSTOMERS form
            Dim result As DialogResult = MsgBox("Are you sure you want to delete this appointment?" & vbCrLf & vbCrLf &
                                              "Customer: " & txtname.Text & vbCrLf &
                                              "Email: " & txtemail.Text & vbCrLf &
                                              "Service: " & cmbtype.Text & vbCrLf &
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

    ' NEW: Email validation function
    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr As New System.Net.Mail.MailAddress(email)
            Return addr.Address = email AndAlso email.Contains("@") AndAlso email.Contains(".")
        Catch
            Return False
        End Try
    End Function

    ' NEW: Cancel/Clear button functionality
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
        ' Optional: Refresh bookings when label is clicked
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

    ' Optional: Add search functionality
    Private Sub txtSearch_TextChanged(sender As System.Object, e As System.EventArgs)
        Try
            If dataGridView1.DataSource IsNot Nothing Then
                Dim dt As DataTable = CType(dataGridView1.DataSource, DataTable)
                Dim searchText As String = CType(sender, TextBox).Text.Trim()

                If searchText = "" Then
                    dt.DefaultView.RowFilter = ""
                Else
                    ' Search in customer name, service type, or appointment time
                    dt.DefaultView.RowFilter = String.Format("[Customer Name] LIKE '%{0}%' OR [Service Type] LIKE '%{0}%' OR [Appointment Time] LIKE '%{0}%'", searchText)
                End If

                ' Clear selection when searching
                ClearFormFields()
                SetFormMode(False)
            End If
        Catch ex As Exception
            ' Ignore search errors
        End Try
    End Sub

    ' Method to cancel an appointment (keep existing functionality but enhanced)
    Private Sub CancelSelectedAppointment()
        Try
            If dataGridView1.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dataGridView1.SelectedRows(0)
                Dim bookingId As String = selectedRow.Cells("Booking ID").Value.ToString()
                Dim serviceName As String = selectedRow.Cells("Service Type").Value.ToString()

                Dim result As DialogResult = MsgBox("Are you sure you want to cancel the appointment for " & serviceName & "?",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    ' Delete the appointment from database
                    cn.Open()
                    Dim deleteCmd As New OleDbCommand("DELETE FROM Appointments WHERE ID = @id", cn)
                    deleteCmd.Parameters.AddWithValue("@id", bookingId)

                    ' For admin, allow canceling any appointment
                    If MAINFORM.CurrentUserRole.ToLower() <> "admin" Then
                        deleteCmd.CommandText = "DELETE FROM Appointments WHERE ID = @id AND email = @email"
                        deleteCmd.Parameters.AddWithValue("@email", MAINFORM.CurrentUserEmail)
                    End If

                    Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()
                    cn.Close()

                    If rowsAffected > 0 Then
                        MsgBox("Appointment cancelled successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadMyBookings() ' Refresh the list
                        ClearFormFields()
                        SetFormMode(False)
                    Else
                        MsgBox("Could not cancel appointment. Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MsgBox("Please select an appointment to cancel.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox("Error cancelling appointment: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    ' Keep existing event handlers but make them functional
    Private Sub cmbtime_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbtime.SelectedIndexChanged
        ' You can add time validation logic here if needed
    End Sub

    Private Sub txtname_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtname.TextChanged
        ' You can add real-time validation here if needed
    End Sub

    Private Sub txtphone_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtphone.TextChanged
        ' You can add phone number validation here if needed
    End Sub

    Private Sub txtage_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtage.TextChanged
        ' You can add age validation here if needed
    End Sub

    Private Sub txtemail_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtemail.TextChanged
        ' You can add email validation here if needed
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbtype.SelectedIndexChanged
        ' You can add service type validation here if needed
    End Sub

    ' Form closing event
    Private Sub ADMINBOOKINGS_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Clean up resources
        If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
End Class