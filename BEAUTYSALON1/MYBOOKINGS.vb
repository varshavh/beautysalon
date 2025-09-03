Imports System.Data.OleDb

Public Class MYBOOKINGS
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\varsha v hegde\OneDrive\ドキュメント\vspsln.accdb")
    Public Property CallingForm As Form
    Private Sub MYBOOKINGS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Load user's bookings when form loads
        LoadMyBookings()

        ' Configure DataGridView
        ConfigureDataGridView()

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
                ' Admin sees all appointments with all details including amount and booked_date
                query = "SELECT ID as [Booking ID], cname as [Customer Name], age as Age, phone as Phone, " &
                       "email as Email, type as [Service Type], timing as [Appointment Time], " &
                       "booking_date as [Appointment Date], booked_date as [Booked On], " &
                       "payment_type as [Payment Type], payment_id as [Payment ID], " &
                       "amount as Amount FROM Appointments ORDER BY booked_date DESC"
                cmd = New OleDbCommand(query, cn)
            Else
                ' Regular user sees their appointments with relevant details
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

            ' Format the date columns for better display
            FormatDateColumns(dt)

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

    Private Sub FormatDateColumns(dt As DataTable)
        Try
            ' Format date columns for better display
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

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        MAINFORM.Show()
    End Sub

    Private Sub label1_Click(sender As System.Object, e As System.EventArgs) Handles label1.Click
        ' Optional: Refresh bookings when label is clicked
        LoadMyBookings()
    End Sub

    Private Sub dataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick
        ' Handle row selection for future features like viewing appointment details
        Try
            If e.RowIndex >= 0 And dataGridView1.Rows.Count > 0 Then
                ' Get selected booking details
                Dim selectedRow As DataGridViewRow = dataGridView1.Rows(e.RowIndex)
                Dim bookingId As String = selectedRow.Cells("Booking ID").Value.ToString()
                Dim serviceName As String = selectedRow.Cells("Service Type").Value.ToString()
                Dim appointmentTime As String = selectedRow.Cells("Appointment Time").Value.ToString()
                Dim appointmentDate As String = selectedRow.Cells("Appointment Date").Value.ToString()
                Dim amount As String = selectedRow.Cells("Amount").Value.ToString()
                Dim paymentType As String = selectedRow.Cells("Payment Type").Value.ToString()

                ' Show detailed booking information
                Dim message As String = "Booking Details:" & vbCrLf & vbCrLf &
                                      "Booking ID: " & bookingId & vbCrLf &
                                      "Service: " & serviceName & vbCrLf &
                                      "Appointment Date: " & appointmentDate & vbCrLf &
                                      "Time: " & appointmentTime & vbCrLf &
                                      "Amount: " & amount & vbCrLf &
                                      "Payment: " & paymentType

                MsgBox(message, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ' Ignore selection errors
        End Try
    End Sub

    ' Add refresh button functionality
    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs)
        LoadMyBookings()
        MsgBox("Bookings refreshed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Enhanced search functionality
    Private Sub txtSearch_TextChanged(sender As System.Object, e As System.EventArgs)
        Try
            If dataGridView1.DataSource IsNot Nothing Then
                Dim dt As DataTable = CType(dataGridView1.DataSource, DataTable)
                Dim searchText As String = CType(sender, TextBox).Text.Trim()

                If searchText = "" Then
                    dt.DefaultView.RowFilter = ""
                Else
                    ' Search in multiple columns
                    Dim filterExpression As String = String.Format(
                        "[Customer Name] LIKE '%{0}%' OR [Service Type] LIKE '%{0}%' OR " &
                        "[Appointment Time] LIKE '%{0}%' OR [Payment Type] LIKE '%{0}%' OR " &
                        "[Appointment Date] LIKE '%{0}%'", searchText)

                    dt.DefaultView.RowFilter = filterExpression
                End If

                ' Update label to show filtered count
                Dim filteredCount As Integer = dt.DefaultView.Count
                If MAINFORM.CurrentUserRole.ToLower() = "admin" Then
                    If searchText = "" Then
                        label1.Text = "All Appointments (" & dt.Rows.Count & " total)"
                    Else
                        label1.Text = "Filtered Appointments (" & filteredCount & " of " & dt.Rows.Count & " total)"
                    End If
                Else
                    If searchText = "" Then
                        label1.Text = "My Bookings (" & dt.Rows.Count & " appointments)"
                    Else
                        label1.Text = "Filtered Bookings (" & filteredCount & " of " & dt.Rows.Count & " appointments)"
                    End If
                End If
            End If
        Catch ex As Exception
            ' Ignore search errors
        End Try
    End Sub

    ' Method to cancel an appointment (enhanced with amount check)
    Private Sub CancelSelectedAppointment()
        Try
            If dataGridView1.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dataGridView1.SelectedRows(0)
                Dim bookingId As String = selectedRow.Cells("Booking ID").Value.ToString()
                Dim serviceName As String = selectedRow.Cells("Service Type").Value.ToString()
                Dim appointmentDate As String = selectedRow.Cells("Appointment Date").Value.ToString()
                Dim amount As String = selectedRow.Cells("Amount").Value.ToString()

                ' Check if appointment date has passed
                Dim aptDate As DateTime
                If DateTime.TryParse(appointmentDate, aptDate) AndAlso aptDate < DateTime.Now.Date Then
                    MsgBox("Cannot cancel past appointments.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim message As String = "Are you sure you want to cancel this appointment?" & vbCrLf & vbCrLf &
                                      "Service: " & serviceName & vbCrLf &
                                      "Date: " & appointmentDate & vbCrLf &
                                      "Amount: " & amount & vbCrLf & vbCrLf &
                                      "Note: Refund processing may take 3-5 business days for online payments."

                Dim result As DialogResult = MsgBox(message, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    ' Delete the appointment from database
                    cn.Open()
                    Dim deleteCmd As New OleDbCommand("DELETE FROM Appointments WHERE ID = @id", cn)

                    ' If not admin, also check email for security
                    If MAINFORM.CurrentUserRole.ToLower() <> "admin" Then
                        deleteCmd.CommandText = "DELETE FROM Appointments WHERE ID = @id AND email = @email"
                        deleteCmd.Parameters.AddWithValue("@email", MAINFORM.CurrentUserEmail)
                    End If

                    deleteCmd.Parameters.AddWithValue("@id", bookingId)

                    Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()
                    cn.Close()

                    If rowsAffected > 0 Then
                        MsgBox("Appointment cancelled successfully!" & vbCrLf & "Refund will be processed if applicable.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadMyBookings() ' Refresh the list
                    Else
                        MsgBox("Could not cancel appointment. Please try again or contact support.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    ' Method to export bookings to CSV (optional feature)
    Private Sub ExportToCSV()
        Try
            If dataGridView1.DataSource IsNot Nothing Then
                Dim saveFileDialog As New SaveFileDialog()
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv"
                saveFileDialog.FileName = "Bookings_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    Dim csv As New System.Text.StringBuilder()

                    ' Add headers
                    Dim headerRow As String = ""
                    For Each column As DataGridViewColumn In dataGridView1.Columns
                        headerRow += column.HeaderText & ","
                    Next
                    csv.AppendLine(headerRow.TrimEnd(","c))

                    ' Add data rows
                    For Each row As DataGridViewRow In dataGridView1.Rows
                        If Not row.IsNewRow Then
                            Dim dataRow As String = ""
                            For Each cell As DataGridViewCell In row.Cells
                                dataRow += cell.Value.ToString() & ","
                            Next
                            csv.AppendLine(dataRow.TrimEnd(","c))
                        End If
                    Next

                    System.IO.File.WriteAllText(saveFileDialog.FileName, csv.ToString())
                    MsgBox("Bookings exported successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error exporting bookings: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class