Imports System.Data.OleDb

Public Class CUSTOMERS
    ' Database connection string - same as in REGISTER form
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\varsha v hegde\OneDrive\ドキュメント\vspsln.accdb")
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim da As OleDbDataAdapter
    Dim dt As DataTable

    ' Variable to store the selected customer's original email for updates
    Dim selectedCustomerEmail As String = ""
    Dim isEditMode As Boolean = False

    Private Sub CUSTOMERS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Maximized

        ' Set form title
        Me.Text = "Customer Management - Beauty Salon"

        ' Load customer data into DataGridView
        LoadCustomerData()

        ' Configure DataGridView appearance
        ConfigureDataGridView()

        ' Initialize form controls
        ClearFormFields()
        SetFormMode(False)
    End Sub

    Private Sub LoadCustomerData()
        Try
            ' Clear any existing data
            dataGridView1.DataSource = Nothing

            ' Create new DataTable
            dt = New DataTable()

            ' Open connection
            con.Open()

            ' SQL query to get all registered users
            Dim query As String = "SELECT username AS [Customer Name], email AS [Email Address], phoneno AS [Phone Number], age AS [Age], role AS [Role] FROM register ORDER BY username"

            ' Create command and data adapter
            cmd = New OleDbCommand(query, con)
            da = New OleDbDataAdapter(cmd)

            ' Fill DataTable with data
            da.Fill(dt)

            ' Bind DataTable to DataGridView
            dataGridView1.DataSource = dt

            ' Display total count
            If dt.Rows.Count > 0 Then
                Me.Text = "Customer Management - Beauty Salon (" & dt.Rows.Count & " customers)"
            Else
                Me.Text = "Customer Management - Beauty Salon (No customers found)"
                MsgBox("No customer data found in the database.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox("Error loading customer data: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Always close connection
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub ConfigureDataGridView()
        Try
            With dataGridView1
                ' Basic appearance settings
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .ReadOnly = True
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = True

                ' Header styling
                .EnableHeadersVisualStyles = False
                .ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                .ColumnHeadersHeight = 35

                ' Row styling
                .DefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.ForeColor = Color.Black
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .DefaultCellStyle.Font = New Font("Arial", 9)
                .RowTemplate.Height = 30

                ' Alternating row colors for better readability
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

                ' Grid lines
                .GridColor = Color.DarkGray
                .CellBorderStyle = DataGridViewCellBorderStyle.Single

                ' Remove row headers (the leftmost column with arrows)
                .RowHeadersVisible = False
            End With

            ' Set specific column widths if data is loaded
            If dataGridView1.Columns.Count > 0 Then
                ' Adjust column widths proportionally
                dataGridView1.Columns("Customer Name").FillWeight = 25  ' 25%
                dataGridView1.Columns("Email Address").FillWeight = 35   ' 35%
                dataGridView1.Columns("Phone Number").FillWeight = 20    ' 20%
                dataGridView1.Columns("Age").FillWeight = 10             ' 10%
                dataGridView1.Columns("Role").FillWeight = 10            ' 10%

                ' Center align Age and Role columns
                dataGridView1.Columns("Age").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dataGridView1.Columns("Role").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

        Catch ex As Exception
            MsgBox("Error configuring DataGridView: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' NEW: Handle row click to populate form fields
    Private Sub dataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellClick
        Try
            If e.RowIndex >= 0 Then
                Dim selectedRow As DataGridViewRow = dataGridView1.Rows(e.RowIndex)

                ' Populate form fields with selected customer data
                txtname.Text = selectedRow.Cells("Customer Name").Value.ToString()
                txtemail.Text = selectedRow.Cells("Email Address").Value.ToString()
                txtphone.Text = selectedRow.Cells("Phone Number").Value.ToString()
                txtage.Text = selectedRow.Cells("Age").Value.ToString()

                ' Store the selected customer's email for reference
                selectedCustomerEmail = selectedRow.Cells("Email Address").Value.ToString()

                ' Enable edit/delete buttons
                SetFormMode(True)
                isEditMode = True
            End If
        Catch ex As Exception
            MsgBox("Error selecting customer: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' NEW: Set form mode (enable/disable buttons and fields)
    Private Sub SetFormMode(hasSelection As Boolean)
        If hasSelection Then
            ' Enable text fields for editing
            txtname.ReadOnly = False
            txtemail.ReadOnly = False
            txtphone.ReadOnly = False
            txtage.ReadOnly = False

            ' Enable action buttons
            btnsave.Enabled = True
            btndelete.Enabled = True
            btnsave.Text = "Update"
        Else
            ' Make text fields read-only
            txtname.ReadOnly = True
            txtemail.ReadOnly = True
            txtphone.ReadOnly = True
            txtage.ReadOnly = True

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
        selectedCustomerEmail = ""
        isEditMode = False
    End Sub

    ' NEW: Save/Update customer data
    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        Try
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

            If isEditMode Then
                ' Update existing customer
                UpdateCustomer()
            Else
                ' This would be for adding new customer (if needed)
                MsgBox("Please select a customer from the list to edit.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox("Error saving customer data: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' NEW: Update customer in database
    Private Sub UpdateCustomer()
        Try
            con.Open()

            ' Check if email is being changed and if new email already exists
            If txtemail.Text.ToLower() <> selectedCustomerEmail.ToLower() Then
                Dim checkQuery As String = "SELECT COUNT(*) FROM register WHERE email = ?"
                cmd = New OleDbCommand(checkQuery, con)
                cmd.Parameters.AddWithValue("@email", txtemail.Text)

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    MsgBox("Email address already exists. Please use a different email.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    con.Close()
                    Return
                End If
            End If

            ' Update customer data
            Dim updateQuery As String = "UPDATE register SET username = ?, email = ?, phoneno = ?, age = ? WHERE email = ?"
            cmd = New OleDbCommand(updateQuery, con)
            cmd.Parameters.AddWithValue("@username", txtname.Text.Trim())
            cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim())
            cmd.Parameters.AddWithValue("@phoneno", txtphone.Text.Trim())
            cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtage.Text))
            cmd.Parameters.AddWithValue("@original_email", selectedCustomerEmail)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MsgBox("Customer updated successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Update the selected email reference
                selectedCustomerEmail = txtemail.Text.Trim()

                ' Refresh the data grid
                con.Close()
                LoadCustomerData()

                ' Clear form and disable editing
                ClearFormFields()
                SetFormMode(False)
            Else
                MsgBox("No customer was updated. Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MsgBox("Error updating customer: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    ' NEW: Delete customer
    Private Sub btndelete_Click(sender As System.Object, e As System.EventArgs) Handles btndelete.Click
        Try
            If String.IsNullOrEmpty(selectedCustomerEmail) Then
                MsgBox("Please select a customer to delete.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Confirm deletion
            Dim result As DialogResult = MsgBox("Are you sure you want to delete customer '" & txtname.Text & "'?" & vbCrLf & "This action cannot be undone.",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                con.Open()

                ' Delete customer from database
                Dim deleteQuery As String = "DELETE FROM register WHERE email = ?"
                cmd = New OleDbCommand(deleteQuery, con)
                cmd.Parameters.AddWithValue("@email", selectedCustomerEmail)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MsgBox("Customer deleted successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh the data grid
                    con.Close()
                    LoadCustomerData()

                    ' Clear form and disable editing
                    ClearFormFields()
                    SetFormMode(False)
                Else
                    MsgBox("No customer was deleted. Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
            MsgBox("Error deleting customer: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    ' NEW: Cancel/Clear button functionality
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs)
        ClearFormFields()
        SetFormMode(False)
        dataGridView1.ClearSelection()
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

    ' Refresh button to reload data
    Private Sub RefreshData()
        LoadCustomerData()
        ClearFormFields()
        SetFormMode(False)
        MsgBox("Customer data refreshed successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Add a refresh button handler if you have one
    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        RefreshData()
    End Sub

    ' Search functionality - if you add a search textbox
    Private Sub txtSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearch.TextChanged
        If dt IsNot Nothing Then
            Try
                Dim searchValue As String = txtSearch.Text.Trim()
                If searchValue = "" Then
                    ' Show all data if search box is empty
                    dataGridView1.DataSource = dt
                Else
                    ' Filter data based on search term
                    Dim dv As DataView = dt.DefaultView
                    dv.RowFilter = String.Format("[Customer Name] LIKE '%{0}%' OR [Email Address] LIKE '%{0}%' OR [Phone Number] LIKE '%{0}%'", searchValue)
                    dataGridView1.DataSource = dv
                End If

                ' Clear selection when searching
                ClearFormFields()
                SetFormMode(False)
            Catch ex As Exception
                MsgBox("Error during search: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Export to CSV functionality (optional)
    Private Sub ExportToCSV()
        Try
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim saveDialog As New SaveFileDialog()
                saveDialog.Filter = "CSV files (*.csv)|*.csv"
                saveDialog.FileName = "Customers_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    Dim csv As New System.Text.StringBuilder()

                    ' Add headers
                    For i As Integer = 0 To dt.Columns.Count - 1
                        csv.Append(dt.Columns(i).ColumnName)
                        If i < dt.Columns.Count - 1 Then
                            csv.Append(",")
                        End If
                    Next
                    csv.AppendLine()

                    ' Add rows
                    For Each row As DataRow In dt.Rows
                        For i As Integer = 0 To dt.Columns.Count - 1
                            csv.Append("""" & row(i).ToString().Replace("""", """""") & """")
                            If i < dt.Columns.Count - 1 Then
                                csv.Append(",")
                            End If
                        Next
                        csv.AppendLine()
                    Next

                    System.IO.File.WriteAllText(saveDialog.FileName, csv.ToString())
                    MsgBox("Customer data exported successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MsgBox("No data to export!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox("Error exporting data: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Export button handler (if you add one)
    'Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
    '   ExportToCSV()
    'End Sub

    ' Back button to return to main form
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        MAINFORM.Show()
    End Sub

    ' DataGridView cell content click handler
    Private Sub dataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick
        ' This can be used for specific cell content clicks if needed
    End Sub

    ' Double click on row to show customer details (optional)
    Private Sub dataGridView1_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                Dim selectedRow As DataGridViewRow = dataGridView1.Rows(e.RowIndex)
                Dim customerName As String = selectedRow.Cells("Customer Name").Value.ToString()
                Dim email As String = selectedRow.Cells("Email Address").Value.ToString()
                Dim phone As String = selectedRow.Cells("Phone Number").Value.ToString()
                Dim age As String = selectedRow.Cells("Age").Value.ToString()
                Dim role As String = selectedRow.Cells("Role").Value.ToString()

                Dim details As String = "Customer Details:" & vbCrLf & vbCrLf &
                                      "Name: " & customerName & vbCrLf &
                                      "Email: " & email & vbCrLf &
                                      "Phone: " & phone & vbCrLf &
                                      "Age: " & age & vbCrLf &
                                      "Role: " & role

                MsgBox(details, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Error displaying customer details: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Form closing event
    Private Sub CUSTOMERS_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Clean up resources
        If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
            con.Close()
        End If
        If dr IsNot Nothing AndAlso Not dr.IsClosed Then
            dr.Close()
        End If
    End Sub

    ' Text changed event handlers (you can add validation here if needed)
    Private Sub txtname_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtname.TextChanged
        ' Optional: Add real-time validation
    End Sub

    Private Sub txtemail_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtemail.TextChanged
        ' Optional: Add real-time email validation
    End Sub

    Private Sub txtphone_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtphone.TextChanged
        ' Optional: Add phone number validation
    End Sub

    Private Sub txtage_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtage.TextChanged
        ' Optional: Add age validation
    End Sub
End Class