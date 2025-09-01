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

    ' Method to set user details (called from login form)
    Public Sub SetUserDetails(name As String, email As String, phone As String, age As String, role As String)
        CurrentUserName = name
        CurrentUserEmail = email
        CurrentUserPhone = phone
        CurrentUserAge = age
        CurrentUserRole = role
        DisplayUserInfo()
    End Sub

    ' Method to clear user details on logout
    Private Sub ClearUserDetails()
        CurrentUserName = ""
        CurrentUserEmail = ""
        CurrentUserPhone = ""
        CurrentUserAge = ""
        CurrentUserRole = ""
        Label1.Text = "Welcome, Guest" ' Reset label on logout
    End Sub

    Private Sub lbappointment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbappointment.Click
        Dim form As New APPOINTMENT1()
        form.Show()
        Me.Hide()
    End Sub

    Private Sub lbcustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbcustomer.Click
        ' Check if user has permission (example role-based access)
        If CurrentUserRole.ToLower() = "admin" Or CurrentUserRole.ToLower() = "user" Then
            Dim form As New CUSTOMERS()
            form.Show()
            Me.Hide()
        Else
            MsgBox("Access denied. Insufficient permissions.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub lbpayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbpayment.Click
        Dim form As New PAYMENT()
        form.Show()
        Me.Hide()
    End Sub

    Private Sub lbfeedback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbfeedback.Click
        Dim form As New FEEDBACK()
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
End Class