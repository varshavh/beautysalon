Imports System.Data.OleDb

Public Class MYBOOKINGS
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\varsha v hegde\OneDrive\ドキュメント\vspsln.accdb")

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

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        MAINFORM.Show()
    End Sub

    Private Sub label1_Click(sender As System.Object, e As System.EventArgs) Handles label1.Click
        ' Optional: Refresh bookings when label is clicked
        LoadMyBookings()
    End Sub

    Private Sub dataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick
        ' Optional: Handle row selection for future features like canceling appointments
        Try
            If e.RowIndex >= 0 And dataGridView1.Rows.Count > 0 Then
                ' Get selected booking details
                Dim selectedRow As DataGridViewRow = dataGridView1.Rows(e.RowIndex)
                Dim bookingId As String = selectedRow.Cells("Booking ID").Value.ToString()
                Dim serviceName As String = selectedRow.Cells("Service Type").Value.ToString()
                Dim appointmentTime As String = selectedRow.Cells("Appointment Time").Value.ToString()

                ' Show booking details (you can expand this)
                Dim message As String = "Booking Details:" & vbCrLf &
                                      "Booking ID: " & bookingId & vbCrLf &
                                      "Service: " & serviceName & vbCrLf &
                                      "Time: " & appointmentTime

                ' MsgBox(message, MessageBoxButtons.OK, MessageBoxIcon.Information, "Booking Details")
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
            End If
        Catch ex As Exception
            ' Ignore search errors
        End Try
    End Sub

    ' Method to cancel an appointment (optional feature)
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
                    Dim deleteCmd As New OleDbCommand("DELETE FROM Appointments WHERE ID = @id AND email = @email", cn)
                    deleteCmd.Parameters.AddWithValue("@id", bookingId)
                    deleteCmd.Parameters.AddWithValue("@email", MAINFORM.CurrentUserEmail)

                    Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()
                    cn.Close()

                    If rowsAffected > 0 Then
                        MsgBox("Appointment cancelled successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadMyBookings() ' Refresh the list
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

End Class