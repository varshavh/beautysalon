Public Class MAINFORM
    Public CurrentUserRole As String

    Private Sub MAINFORM_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lbappointment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbappointment.Click
        Dim form As New APPOINTMENT1()
        form.Show()
        Me.Hide()
    End Sub
    Private Sub lbcustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbcustomer.Click
        Dim form As New CUSTOMERS()
        form.Show()
        Me.Hide()
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
        login.Show()
    End Sub
End Class