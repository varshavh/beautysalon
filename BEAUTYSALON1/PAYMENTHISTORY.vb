Imports System.Data.OleDb

Public Class PAYMENTHISTORY
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\varsha v hegde\OneDrive\ドキュメント\vspsln.accdb")
    Public Property CallingForm As Form

    Private Sub PAYMENTHISTORY_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Payment History"

        ' Initialize form
        InitializeForm()

        ' Load payment data based on user role
        LoadPaymentData()
    End Sub

    Private Sub InitializeForm()
        Try
            ' Configure DataGridView properties
            With dataGridView1
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ReadOnly = True
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToResizeRows = False
                .RowHeadersVisible = False
                .BackgroundColor = Color.White
                .BorderStyle = BorderStyle.Fixed3D
            End With

            ' Set search textbox placeholder-like behavior
            If txtsearch.Text = "" Then
                txtsearch.ForeColor = Color.Gray
                txtsearch.Text = "Search by customer name, email, or amount..."
            End If

            ' Configure form title based on user role
            If MAINFORM.CurrentUserRole.ToLower() = "admin" Then
                Me.Text = "Payment History - All Payments (Admin View)"
                Label1.Text = "All Payment Records"
            Else
                Me.Text = "Payment History - My Payments"
                Label1.Text = "My Payment History"
            End If

        Catch ex As Exception
            MsgBox("Error initializing form: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

Private Sub LoadPaymentData(Optional searchTerm As String = "")
        Try
            cn.Open()
            Dim query As String = ""
            Dim cmd As OleDbCommand

            ' Different queries based on user role
            If MAINFORM.CurrentUserRole.ToLower() = "admin" Then
                ' Admin sees all payments
                query = "SELECT p.ID as [Payment ID], " &
                       "a.cname as [Customer Name], " &
                       "a.email as [Email], " &
                       "a.type as [Service Type], " &
                       "a.timing as [Appointment Time], " &
                       "a.booking_date as [Booking Date], " &
                       "p.amount as [Amount (₹)], " &
                       "a.payment_type as [Payment Method], " &
                       "p.card_holder_name as [Card Holder], " &
                       "('****' & RIGHT(p.card_number, 4)) as [Card Number] " &
                       "FROM Payments p " &
                       "INNER JOIN Appointments a ON p.appointment_id = a.ID "

                If searchTerm <> "" AndAlso searchTerm <> "Search by customer name, email, or amount..." Then
                    query &= "WHERE (a.cname LIKE ? OR a.email LIKE ? OR p.amount LIKE ?) "
                End If

                query &= "ORDER BY p.ID DESC"

            Else
                ' Regular user sees only their payments
                query = "SELECT p.ID as [Payment ID], " &
                       "a.type as [Service Type], " &
                       "a.timing as [Appointment Time], " &
                       "a.booking_date as [Booking Date], " &
                       "p.amount as [Amount (₹)], " &
                       "a.payment_type as [Payment Method], " &
                       "p.card_holder_name as [Card Holder], " &
                       "('****' & RIGHT(p.card_number, 4)) as [Card Number] " &
                       "FROM Payments p " &
                       "INNER JOIN Appointments a ON p.appointment_id = a.ID " &
                       "WHERE a.email = ? "

                If searchTerm <> "" AndAlso searchTerm <> "Search by customer name, email, or amount..." Then
                    query &= "AND (a.type LIKE ? OR p.amount LIKE ? OR p.card_holder_name LIKE ?) "
                End If

                query &= "ORDER BY p.ID DESC"
            End If

            cmd = New OleDbCommand(query, cn)

            ' Add parameters in order
            If MAINFORM.CurrentUserRole.ToLower() = "admin" Then
                If searchTerm <> "" AndAlso searchTerm <> "Search by customer name, email, or amount..." Then
                    cmd.Parameters.AddWithValue("?", "%" & searchTerm & "%")
                    cmd.Parameters.AddWithValue("?", "%" & searchTerm & "%")
                    cmd.Parameters.AddWithValue("?", "%" & searchTerm & "%")
                End If
            Else
                cmd.Parameters.AddWithValue("?", MAINFORM.CurrentUserEmail)
                If searchTerm <> "" AndAlso searchTerm <> "Search by customer name, email, or amount..." Then
                    cmd.Parameters.AddWithValue("?", "%" & searchTerm & "%")
                    cmd.Parameters.AddWithValue("?", "%" & searchTerm & "%")
                    cmd.Parameters.AddWithValue("?", "%" & searchTerm & "%")
                End If
            End If

            ' Execute query and bind to DataGridView
            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dataTable As New DataTable()
            adapter.Fill(dataTable)

            dataGridView1.DataSource = dataTable
            FormatDataGridView()

            cn.Close()

        Catch ex As Exception
            MsgBox("Error loading payment data: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Sub ShowNoDataMessage(searchTerm As String)
        ' Create empty DataTable with proper columns
        Dim emptyTable As New DataTable()

        If MAINFORM.CurrentUserRole.ToLower() = "admin" Then
            emptyTable.Columns.Add("Payment ID")
            emptyTable.Columns.Add("Customer Name")
            emptyTable.Columns.Add("Email")
            emptyTable.Columns.Add("Service Type")
            emptyTable.Columns.Add("Appointment Time")
            emptyTable.Columns.Add("Booking Date")
            emptyTable.Columns.Add("Amount (₹)")
            emptyTable.Columns.Add("Payment Method")
            emptyTable.Columns.Add("Card Holder")
            emptyTable.Columns.Add("Card Number")
            emptyTable.Columns.Add("Payment Date")
        Else
            emptyTable.Columns.Add("Payment ID")
            emptyTable.Columns.Add("Service Type")
            emptyTable.Columns.Add("Appointment Time")
            emptyTable.Columns.Add("Booking Date")
            emptyTable.Columns.Add("Amount (₹)")
            emptyTable.Columns.Add("Payment Method")
            emptyTable.Columns.Add("Card Holder")
            emptyTable.Columns.Add("Card Number")
            emptyTable.Columns.Add("Payment Date")
        End If

        dataGridView1.DataSource = emptyTable

        ' Show appropriate message
        Dim message As String = ""
        If searchTerm <> "" AndAlso searchTerm <> "Search by customer name, email, or amount..." Then
            message = "No payment records found matching '" & searchTerm & "'"
        Else
            If MAINFORM.CurrentUserRole.ToLower() = "admin" Then
                message = "No payment records found in the system."
            Else
                message = "You don't have any payment records yet."
            End If
        End If

        MsgBox(message, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub FormatDataGridView()
        Try
            ' Format currency columns
            If dataGridView1.Columns.Contains("Amount (₹)") Then
                dataGridView1.Columns("Amount (₹)").DefaultCellStyle.Format = "C2"
                dataGridView1.Columns("Amount (₹)").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

            ' Format date columns
            For Each column As DataGridViewColumn In dataGridView1.Columns
                If column.Name.ToLower().Contains("date") Then
                    column.DefaultCellStyle.Format = "dd/MM/yyyy"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
            Next

            ' Set column widths for better display
            If dataGridView1.Columns.Count > 0 Then
                For Each column As DataGridViewColumn In dataGridView1.Columns
                    Select Case column.Name.ToLower()
                        Case "payment id"
                            column.Width = 80
                        Case "customer name", "email"
                            column.Width = 150
                        Case "service type"
                            column.Width = 120
                        Case "appointment time"
                            column.Width = 100
                        Case "booking date", "payment date"
                            column.Width = 100
                        Case "amount (₹)"
                            column.Width = 80
                        Case "payment method"
                            column.Width = 100
                        Case "card holder"
                            column.Width = 120
                        Case "card number"
                            column.Width = 80
                    End Select
                Next
            End If

            ' Alternate row colors for better readability
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        Catch ex As Exception
            ' Continue without formatting if there's an error
        End Try
    End Sub

    Private Sub txtsearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtsearch.TextChanged
        ' Handle placeholder text behavior
        If txtsearch.Focused AndAlso txtsearch.Text = "Search by customer name, email, or amount..." Then
            txtsearch.Text = ""
            txtsearch.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtsearch_Enter(sender As Object, e As EventArgs) Handles txtsearch.Enter
        ' Clear placeholder text when focused
        If txtsearch.Text = "Search by customer name, email, or amount..." Then
            txtsearch.Text = ""
            txtsearch.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtsearch_Leave(sender As Object, e As EventArgs) Handles txtsearch.Leave
        ' Restore placeholder text if empty
        If txtsearch.Text.Trim() = "" Then
            txtsearch.ForeColor = Color.Gray
            txtsearch.Text = "Search by customer name, email, or amount..."
        End If
    End Sub

    Private Sub btnsearch_Click(sender As System.Object, e As System.EventArgs) Handles btnsearch.Click
        Try
            Dim searchTerm As String = txtsearch.Text.Trim()

            ' Don't search with placeholder text
            If searchTerm = "Search by customer name, email, or amount..." Then
                searchTerm = ""
            End If

            ' Reload data with search filter
            LoadPaymentData(searchTerm)

        Catch ex As Exception
            MsgBox("Error during search: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnrefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnrefresh.Click
        Try
            ' Clear search and reload all data
            txtsearch.ForeColor = Color.Gray
            txtsearch.Text = "Search by customer name, email, or amount..."

            ' Reload payment data
            LoadPaymentData()

            MsgBox("Payment data refreshed successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox("Error refreshing data: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick
        ' Optional: Handle cell clicks for additional functionality
        Try
            If e.RowIndex >= 0 AndAlso dataGridView1.Rows.Count > 0 Then
                ' You can add functionality here like showing payment details in a message box
                Dim selectedRow As DataGridViewRow = dataGridView1.Rows(e.RowIndex)

                ' Example: Show payment details (optional)
                If e.ColumnIndex >= 0 Then
                    Dim paymentId As String = selectedRow.Cells("Payment ID").Value.ToString()
                    Dim amount As String = selectedRow.Cells("Amount (₹)").Value.ToString()
                    Dim paymentDate As String = selectedRow.Cells("Payment Date").Value.ToString()

                    ' You can uncomment this if you want to show details on click
                    ' MsgBox("Payment Details:" & vbCrLf & "Payment ID: " & paymentId & vbCrLf & "Amount: " & amount & vbCrLf & "Date: " & paymentDate, 
                    '        MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            ' Handle any errors silently for cell clicks
        End Try
    End Sub

    ' Add a back button event handler
    Private Sub btnback_Click(sender As System.Object, e As System.EventArgs)
        Try
            ' Return to main form
            If CallingForm IsNot Nothing Then
                CallingForm.Show()
            Else
                MAINFORM.Show()
            End If
            Me.Hide()
        Catch ex As Exception
            MsgBox("Error returning to main form: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Handle form closing
    Private Sub PAYMENTHISTORY_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            ' Return to calling form when this form is closed
            If CallingForm IsNot Nothing Then
                CallingForm.Show()
            Else
                MAINFORM.Show()
            End If
        Catch ex As Exception
            ' Handle any errors during form closing
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        CallingForm.Show()
    End Sub
End Class