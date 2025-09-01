<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PAYMENT
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PAYMENT))
        Me.label10 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnPay = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.HolderName = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CardNum = New System.Windows.Forms.TextBox()
        Me.ExpMonth = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pictureBox3 = New System.Windows.Forms.PictureBox()
        Me.CustName = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Amount = New System.Windows.Forms.TextBox()
        Me.ExpYear = New System.Windows.Forms.ComboBox()
        CType(Me.pictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.ForeColor = System.Drawing.Color.MediumSlateBlue
        Me.label10.Location = New System.Drawing.Point(569, 828)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(285, 24)
        Me.label10.TabIndex = 74
        Me.label10.Text = "Contact:beautysalon@gmail.com"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label9.ForeColor = System.Drawing.Color.Crimson
        Me.label9.Location = New System.Drawing.Point(598, 804)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(216, 24)
        Me.label9.TabIndex = 73
        Me.label9.Text = "DevelopedByTechTeam"
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Lime
        Me.btnBack.FlatAppearance.BorderSize = 0
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnBack.Location = New System.Drawing.Point(632, 711)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(116, 40)
        Me.btnBack.TabIndex = 72
        Me.btnBack.Text = "BACK"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnPay
        '
        Me.btnPay.BackColor = System.Drawing.Color.Aqua
        Me.btnPay.FlatAppearance.BorderSize = 0
        Me.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPay.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPay.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPay.Location = New System.Drawing.Point(545, 653)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(105, 32)
        Me.btnPay.TabIndex = 71
        Me.btnPay.Text = "PAY"
        Me.btnPay.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Red
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCancel.Location = New System.Drawing.Point(740, 653)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(114, 32)
        Me.btnCancel.TabIndex = 70
        Me.btnCancel.Text = "RESET"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label7.Location = New System.Drawing.Point(484, 365)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(209, 31)
        Me.label7.TabIndex = 66
        Me.label7.Text = "EXPIRY MONTH"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label2.Location = New System.Drawing.Point(426, 247)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(278, 31)
        Me.label2.TabIndex = 58
        Me.label2.Text = "CARD HOLDER NAME"
        '
        'HolderName
        '
        Me.HolderName.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HolderName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HolderName.Location = New System.Drawing.Point(717, 240)
        Me.HolderName.Multiline = True
        Me.HolderName.Name = "HolderName"
        Me.HolderName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HolderName.Size = New System.Drawing.Size(257, 38)
        Me.HolderName.TabIndex = 57
        Me.HolderName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Crimson
        Me.label1.Location = New System.Drawing.Point(658, 81)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(168, 36)
        Me.label1.TabIndex = 56
        Me.label1.Text = "PAYMENT"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.BackColor = System.Drawing.SystemColors.Control
        Me.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label4.Font = New System.Drawing.Font("Lucida Handwriting", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.MediumBlue
        Me.label4.Image = CType(resources.GetObject("label4.Image"), System.Drawing.Image)
        Me.label4.Location = New System.Drawing.Point(580, 9)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(333, 49)
        Me.label4.TabIndex = 55
        Me.label4.Text = "Beauty Salon "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.Label3.Location = New System.Drawing.Point(488, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(211, 31)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "PAYMENT DATE"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(717, 182)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(249, 22)
        Me.DateTimePicker1.TabIndex = 77
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.Label6.Location = New System.Drawing.Point(835, 435)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 31)
        Me.Label6.TabIndex = 82
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.Label8.Location = New System.Drawing.Point(497, 301)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(202, 31)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "CARD NUMBER"
        '
        'CardNum
        '
        Me.CardNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CardNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CardNum.Location = New System.Drawing.Point(717, 300)
        Me.CardNum.Multiline = True
        Me.CardNum.Name = "CardNum"
        Me.CardNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CardNum.Size = New System.Drawing.Size(257, 38)
        Me.CardNum.TabIndex = 80
        Me.CardNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ExpMonth
        '
        Me.ExpMonth.FormattingEnabled = True
        Me.ExpMonth.Items.AddRange(New Object() {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"})
        Me.ExpMonth.Location = New System.Drawing.Point(717, 369)
        Me.ExpMonth.Name = "ExpMonth"
        Me.ExpMonth.Size = New System.Drawing.Size(257, 24)
        Me.ExpMonth.TabIndex = 84
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.Label11.Location = New System.Drawing.Point(497, 426)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(174, 31)
        Me.Label11.TabIndex = 85
        Me.Label11.Text = "EXPIRY YEAR"
        '
        'pictureBox3
        '
        Me.pictureBox3.BackColor = System.Drawing.Color.White
        Me.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBox3.Image = CType(resources.GetObject("pictureBox3.Image"), System.Drawing.Image)
        Me.pictureBox3.Location = New System.Drawing.Point(1073, 12)
        Me.pictureBox3.Name = "pictureBox3"
        Me.pictureBox3.Size = New System.Drawing.Size(62, 57)
        Me.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox3.TabIndex = 86
        Me.pictureBox3.TabStop = False
        '
        'CustName
        '
        Me.CustName.AutoSize = True
        Me.CustName.Location = New System.Drawing.Point(1171, 32)
        Me.CustName.Name = "CustName"
        Me.CustName.Size = New System.Drawing.Size(51, 17)
        Me.CustName.TabIndex = 87
        Me.CustName.Text = "Label5"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.Label5.Location = New System.Drawing.Point(539, 494)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 31)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "Amount"
        '
        'Amount
        '
        Me.Amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Amount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Amount.Location = New System.Drawing.Point(717, 485)
        Me.Amount.Multiline = True
        Me.Amount.Name = "Amount"
        Me.Amount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Amount.Size = New System.Drawing.Size(257, 40)
        Me.Amount.TabIndex = 88
        Me.Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ExpYear
        '
        Me.ExpYear.FormattingEnabled = True
        Me.ExpYear.Items.AddRange(New Object() {"2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035"})
        Me.ExpYear.Location = New System.Drawing.Point(717, 433)
        Me.ExpYear.Name = "ExpYear"
        Me.ExpYear.Size = New System.Drawing.Size(257, 24)
        Me.ExpYear.TabIndex = 90
        '
        'PAYMENT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1347, 869)
        Me.Controls.Add(Me.ExpYear)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Amount)
        Me.Controls.Add(Me.CustName)
        Me.Controls.Add(Me.pictureBox3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ExpMonth)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CardNum)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnPay)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.HolderName)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label4)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PAYMENT"
        Me.Text = "UPDATEDELETE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents btnBack As System.Windows.Forms.Button
    Private WithEvents btnPay As System.Windows.Forms.Button
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents HolderName As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents CardNum As System.Windows.Forms.TextBox
    Friend WithEvents ExpMonth As System.Windows.Forms.ComboBox
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents pictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CustName As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Amount As System.Windows.Forms.TextBox
    Friend WithEvents ExpYear As System.Windows.Forms.ComboBox
End Class
