Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class PAYMENT
    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\varsha v hegde\OneDrive\ドキュメント\vspsln.accdb")
    Public Property CallingForm
    Private Sub PAYMENT_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Initialize form
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        ' Populate expiry month dropdown
        ExpMonth.Items.Clear()
        For i As Integer = 1 To 12
            ExpMonth.Items.Add(i.ToString("00"))
        Next

        ' Populate expiry year dropdown (current year + 10 years)
        ExpYear.Items.Clear()
        Dim currentYear As Integer = DateTime.Now.Year
        For i As Integer = currentYear To currentYear + 10
            ExpYear.Items.Add(i.ToString())
        Next
        Dim userName As String = APPOINTMENT1.AppointmentData("name")
        CustName.Text = userName
        Amount.Enabled = False
        Dim amt As Integer = APPOINTMENT1.AppointmentData("amount")
        Amount.Text = amt.ToString
        ' Set focus to cardholder name
        HolderName.Focus()
    End Sub

    Private Sub btnPay_Click(sender As System.Object, e As System.EventArgs) Handles btnPay.Click
        Try
            ' Validate payment form
            If Not ValidatePaymentForm() Then
                Exit Sub
            End If

            ' Simulate payment processing
            Dim paymentId As String = ProcessPayment()

            If paymentId <> "" Then
                ' Payment successful, save appointment with payment details
                Dim appointmentForm As New APPOINTMENT1()
                appointmentForm.SaveAppointment("Online", paymentId)

                ' Clear the stored appointment data
                APPOINTMENT1.AppointmentData.Clear()

                ' Go back to main form
                CallingForm.back_main_form()
                Me.Close()
            Else
                MsgBox("Payment failed. Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox("Payment error: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidatePaymentForm() As Boolean
        ' Validate cardholder name
        If HolderName.Text.Trim() = "" Then
            MsgBox("Please enter cardholder name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            HolderName.Focus()
            Return False
        End If

        If Not Regex.IsMatch(HolderName.Text.Trim(), "^[A-Za-z\s]+$") Then
            MsgBox("Cardholder name can contain only alphabets", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            HolderName.Focus()
            Return False
        End If

        ' Validate card number
        If CardNum.Text.Trim() = "" Then
            MsgBox("Please enter card number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CardNum.Focus()
            Return False
        End If

        ' Remove spaces and validate card number (should be 16 digits)
        Dim cardNumber As String = CardNum.Text.Replace(" ", "")
        If Not Regex.IsMatch(cardNumber, "^\d{16}$") Then
            MsgBox("Card number must be 16 digits", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CardNum.Focus()
            Return False
        End If

        ' Validate expiry month
        If ExpMonth.SelectedIndex = -1 Then
            MsgBox("Please select expiry month", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ExpMonth.Focus()
            Return False
        End If

        ' Validate expiry year
        If ExpYear.Text.Trim() = "" Then
            MsgBox("Please select expiry year", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ExpYear.Focus()
            Return False
        End If

        ' Check if card is not expired
        Dim selectedMonth As Integer
        Dim selectedYear As Integer

        ' Parse month safely
        If Not Integer.TryParse(ExpMonth.Text, selectedMonth) Then
            MsgBox("Invalid expiry month selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ExpMonth.Focus()
            Return False
        End If

        ' Parse year safely  
        If Not Integer.TryParse(ExpYear.Text, selectedYear) Then
            MsgBox("Invalid expiry year selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ExpYear.Focus()
            Return False
        End If
        Dim currentDate As DateTime = DateTime.Now
        Dim expiryDate As New DateTime(selectedYear, selectedMonth, DateTime.DaysInMonth(selectedYear, selectedMonth))

        If expiryDate < currentDate Then
            MsgBox("Card has expired. Please use a valid card.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ExpMonth.Focus()
            Return False
        End If

        ' Validate amount
        If Amount.Text.Trim() = "" Then
            MsgBox("Please enter amount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Amount.Focus()
            Return False
        End If

        If Not IsNumeric(Amount.Text) OrElse CDbl(Amount.Text) <= 0 Then
            MsgBox("Please enter valid amount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Amount.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function ProcessPayment() As String
        ' Process payment and insert into Payments table

        Try
            ' Show processing message
            Dim processingMsg As String = "Processing payment of ₹" & Amount.Text & "..." & vbCrLf & "Please wait..."
            ' You could show a progress bar here

            ' Simulate processing delay
            System.Threading.Thread.Sleep(2000)

            ' Insert payment record into Payments table
            cn.Open()

            ' Get the user email from stored appointment data
            Dim userEmail As String = APPOINTMENT1.AppointmentData("email")

            ' Insert payment details
            Dim paymentCmd As New OleDbCommand("INSERT INTO Payments(user_email, appointment_id, card_number, card_holder_name, exp_month, exp_year, amount) VALUES(@user_email, @appointment_id, @card_number, @card_holder, @exp_month, @exp_year, @amount)", cn)

            paymentCmd.Parameters.AddWithValue("@user_email", userEmail)
            paymentCmd.Parameters.AddWithValue("@appointment_id", 0) ' Will be updated after appointment is created
            paymentCmd.Parameters.AddWithValue("@card_number", CardNum.Text.Replace(" ", "").Substring(CardNum.Text.Replace(" ", "").Length - 4)) ' Store only last 4 digits for security
            paymentCmd.Parameters.AddWithValue("@card_holder", HolderName.Text.Trim())
            paymentCmd.Parameters.AddWithValue("@exp_month", ExpMonth.Text)
            paymentCmd.Parameters.AddWithValue("@exp_year", ExpYear.Text)
            paymentCmd.Parameters.AddWithValue("@amount", CDbl(Amount.Text))

            paymentCmd.ExecuteNonQuery()

            ' Get the generated payment ID
            Dim getIdCmd As New OleDbCommand("SELECT @@IDENTITY", cn)
            Dim paymentId As String = getIdCmd.ExecuteScalar().ToString()

            cn.Close()

            ' Payment successful
            MsgBox("Payment successful!" & vbCrLf & "Payment ID: " & paymentId, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return paymentId

        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            MsgBox("Payment processing error: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        ' Cancel payment and go back to appointment form
        Dim result As DialogResult = MsgBox("Are you sure you want to cancel the payment?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Clear stored appointment data
            APPOINTMENT1.AppointmentData.Clear()

            ' Go back to appointment form
            Dim appointmentForm As New APPOINTMENT1()
            appointmentForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        ' Go back to appointment form without clearing data
        Dim appointmentForm As New APPOINTMENT1()
        appointmentForm.Show()
        Me.Hide()
    End Sub

    ' Format card number input (add spaces every 4 digits)
    Private Sub CardNum_TextChanged(sender As System.Object, e As System.EventArgs) Handles CardNum.TextChanged
        ' Format card number with spaces
        Dim textBox As TextBox = DirectCast(sender, TextBox)
        Dim text As String = textBox.Text.Replace(" ", "")

        If text.Length > 0 Then
            Dim formatted As String = ""
            For i As Integer = 0 To text.Length - 1
                If i > 0 AndAlso i Mod 4 = 0 Then
                    formatted += " "
                End If
                formatted += text(i)
            Next

            If formatted <> textBox.Text Then
                Dim cursorPos As Integer = textBox.SelectionStart
                textBox.Text = formatted
                textBox.SelectionStart = Math.Min(cursorPos + 1, textBox.Text.Length)
            End If
        End If
    End Sub

    ' Existing event handlers (keeping them for compatibility)
    Private Sub Label5_Click(sender As System.Object, e As System.EventArgs)
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs)
    End Sub

    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs) Handles Label3.Click
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
    End Sub

    Private Sub label2_Click(sender As System.Object, e As System.EventArgs) Handles label2.Click
    End Sub

    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs) Handles Label8.Click
    End Sub

    Private Sub label7_Click(sender As System.Object, e As System.EventArgs) Handles label7.Click
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As System.Object, e As System.EventArgs)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ExpMonth.SelectedIndexChanged
    End Sub

    Private Sub Label11_Click(sender As System.Object, e As System.EventArgs) Handles Label11.Click
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles Amount.TextChanged
    End Sub

    Private Sub Label5_Click_1(sender As System.Object, e As System.EventArgs) Handles Label5.Click
    End Sub

    Private Sub HolderName_TextChanged(sender As System.Object, e As System.EventArgs) Handles HolderName.TextChanged
    End Sub

    Private Sub ExpYear_TextChanged(sender As System.Object, e As System.EventArgs) Handles ExpYear.TextChanged
    End Sub

    Private Sub CustName_Click(sender As System.Object, e As System.EventArgs) Handles CustName.Click

    End Sub
End Class