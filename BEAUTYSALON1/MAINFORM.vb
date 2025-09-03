Public Class MAINFORM
    ' Public properties to store current user details
    Public Shared CurrentUserName As String = ""  ' This stores the actual name
    Public Shared CurrentUserEmail As String = ""
    Public Shared CurrentUserPhone As String = ""
    Public Shared CurrentUserAge As String = ""
    Public Shared CurrentUserRole As String = ""

    Private Sub MAINFORM_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Display current user information on the form
        DisplayUserInfo()
        ' Configure menu based on user rolea
        ConfigureMenuForRole()
        ' Set form properties
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DisplayUserInfo()
        ' Display name in Label1
        If CurrentUserName <> "" Then
            Label1.Text = "Welcome, " & CurrentUserName
            Me.Text = "Beauty Salon Management - Welcome " & CurrentUserName & " (" & CurrentUserRole & ")"
        Else
            Label1.Text = "Welcome, Guest"
            Me.Text = "Beauty Salon Management System"
        End If
    End Sub

    ' Updated method to configure menu visibility based on user role
    Private Sub ConfigureMenuForRole()
        If CurrentUserRole.ToLower() = "admin" Then
            ' Admin can see everything
            lbappointment.Visible = False   ' Admin can also book appointments for customers
            lbappointment.Text = "Book Appointment"
            booklayout.Visible = False
            ' Bookings - Admin sees all bookings
            If Me.Controls.ContainsKey("Bookings") Then
                lbbookings.Visible = True
                lbbookings.Text = "All Bookings"
            End If
            If Me.Controls.ContainsKey("lbbookings") Then
                lbbookings.Visible = True
                lbbookings.Text = "All Bookings"
            End If

            ' Customers - Only visible to Admin
            lbcustomer.Visible = True
            lbcustomer.Text = "Customers Management"

            lbpayment.Visible = True
            lbfeedback.Visible = True
            lblogout.Visible = True

        ElseIf CurrentUserRole.ToLower() = "user" Then
            ' Regular users can book appointments and see their bookings
            lbappointment.Visible = True
            lbappointment.Text = "Book Appointment"

            ' Bookings - User sees only their bookings
            If Me.Controls.ContainsKey("Bookings") Then
                lbbookings.Visible = True
                lbbookings.Text = "My Bookings"
            End If
            If Me.Controls.ContainsKey("lbbookings") Then
                lbbookings.Visible = True
                lbbookings.Text = "My Bookings"
            End If

            ' Customers - Hidden for regular users
            'lbcustomer.Visible = False
            'PictureBox4.Visible = False
            customerlayout.Visible = False
            lbpayment.Visible = True
            lbfeedback.Visible = True
            lblogout.Visible = True

        Else
            ' Guest or unknown role - limited access
            lbappointment.Visible = False

            ' Hide bookings for guests
            If Me.Controls.ContainsKey("Bookings") Then
                lbbookings.Visible = False
            End If
            If Me.Controls.ContainsKey("lbbookings") Then
                lbbookings.Visible = False
            End If

            lbcustomer.Visible = False
            PictureBox4.Visible = False
            customerlayout.Visible = False
            lbpayment.Visible = False
            paymentlayout.Visible = False
            lbfeedback.Visible = True  ' Allow feedback for guests
            lblogout.Visible = True
        End If
    End Sub

    ' Method to set user details (called from login form)
    Public Sub SetUserDetails(name As String, email As String, phone As String, age As String, role As String)
        CurrentUserName = name
        CurrentUserEmail = email
        CurrentUserPhone = phone
        CurrentUserAge = age
        CurrentUserRole = role
        DisplayUserInfo()
        ' Reconfigure menu after setting user details
        ConfigureMenuForRole()
    End Sub

    ' Method to clear user details on logout
    Private Sub ClearUserDetails()
        CurrentUserName = ""
        CurrentUserEmail = ""
        CurrentUserPhone = ""
        CurrentUserAge = ""
        CurrentUserRole = ""
        Label1.Text = "Welcome, Guest" ' Reset label on logout
        ' Reset menu to guest configuration
        ConfigureMenuForRole()
    End Sub

    ' UPDATED: Pass reference to calling form
    Private Sub lbappointment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbappointment.Click
        ' Both admin and users can book appointments
        If CurrentUserRole.ToLower() = "admin" Or CurrentUserRole.ToLower() = "user" Then
            Dim form As New APPOINTMENT1()
            form.CallingForm = Me  ' Pass reference to this form
            form.Show()
            Me.Hide()
        Else
            MsgBox("Please login to book appointments.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' UPDATED: Handle the Bookings button click (this goes to MYBOOKINGS form)
    Private Sub Bookings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbbookings.Click
        ' Check user role and redirect accordingly
        If CurrentUserRole.ToLower() = "admin" Then
            ' Admin sees all bookings
            Dim form As New ADMINBOOKINGS()
            form.CallingForm = Me  ' Pass reference to this form
            form.Show()
            Me.Hide()
        ElseIf CurrentUserRole.ToLower() = "user" Then
            ' User sees their own bookings
            Dim form As New MYBOOKINGS()
            form.CallingForm = Me  ' Pass reference to this form
            form.Show()
            Me.Hide()
        Else
            MsgBox("Access denied. Please login to view bookings.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Alternative handler if you have a different bookings button name
    Private Sub lbbookings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Same functionality as Bookings_Click
        Bookings_Click(sender, e)
    End Sub

    ' UPDATED: Handle the Customers button click (this goes to CUSTOMERS form - Admin only)
    Private Sub lbcustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbcustomer.Click
        ' Only admin can access customer management
        If CurrentUserRole.ToLower() = "admin" Then
            ' Admin sees customer management
            Dim form As New CUSTOMERS()
            form.CallingForm = Me  ' Pass reference to this form
            form.Show()
            Me.Hide()
        Else
            MsgBox("Access denied. Customer management is only available for administrators.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' UPDATED: Payment form
    Private Sub lbpayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbpayment.Click
        ' Check if user has permission
        If CurrentUserRole.ToLower() = "admin" Or CurrentUserRole.ToLower() = "user" Then
            Dim form As New PAYMENTHISTORY()
            form.CallingForm = Me  ' Pass reference to this form
            form.Show()
            Me.Hide()
        Else
            MsgBox("Access denied. Please login to access payment section.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' UPDATED: Feedback form
    Private Sub lbfeedback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbfeedback.Click
        Dim form As New FEEDBACK()
        form.CallingForm = Me  ' Pass reference to this form
        form.Show()
        Me.Hide()
    End Sub

    Private Sub lblogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblogout.Click
        ' Clear user details and show confirmation
        Dim result As DialogResult = MsgBox("Are you sure you want to logout?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            ClearUserDetails()
            Me.Hide()
            login.Show()
        End If
    End Sub

    ' Optional: Method to get current user details for other forms
    Public Shared Function GetCurrentUserInfo() As String()
        Return {CurrentUserName, CurrentUserEmail, CurrentUserPhone, CurrentUserAge, CurrentUserRole}
    End Function

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles lbbookings.Click
        ' This handles the click on the Bookings label
        Bookings_Click(sender, e)
    End Sub

    Private Sub PictureBox4_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox5_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox5.Click

    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub PictureBox7_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox7.Click

    End Sub
End Class