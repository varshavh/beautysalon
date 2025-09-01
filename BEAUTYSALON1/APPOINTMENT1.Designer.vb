<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class APPOINTMENT1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(APPOINTMENT1))
        Me.label10 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.btnreset = New System.Windows.Forms.Button()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.cmbtime = New System.Windows.Forms.ComboBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtage = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.txtphone = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.btnback = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.ForeColor = System.Drawing.Color.MediumSlateBlue
        Me.label10.Location = New System.Drawing.Point(642, 858)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(285, 24)
        Me.label10.TabIndex = 52
        Me.label10.Text = "Contact:beautysalon@gmail.com"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label9.ForeColor = System.Drawing.Color.Crimson
        Me.label9.Location = New System.Drawing.Point(671, 834)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(216, 24)
        Me.label9.TabIndex = 51
        Me.label9.Text = "DevelopedByTechTeam"
        '
        'btnreset
        '
        Me.btnreset.BackColor = System.Drawing.Color.Red
        Me.btnreset.FlatAppearance.BorderSize = 0
        Me.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreset.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreset.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnreset.Location = New System.Drawing.Point(850, 646)
        Me.btnreset.Name = "btnreset"
        Me.btnreset.Size = New System.Drawing.Size(155, 54)
        Me.btnreset.TabIndex = 48
        Me.btnreset.Text = "RESET"
        Me.btnreset.UseVisualStyleBackColor = False
        '
        'btnadd
        '
        Me.btnadd.BackColor = System.Drawing.Color.Lime
        Me.btnadd.FlatAppearance.BorderSize = 0
        Me.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnadd.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadd.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnadd.Location = New System.Drawing.Point(521, 646)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(155, 54)
        Me.btnadd.TabIndex = 47
        Me.btnadd.Text = "ADD"
        Me.btnadd.UseVisualStyleBackColor = False
        '
        'cmbtime
        '
        Me.cmbtime.Font = New System.Drawing.Font("Microsoft YaHei", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtime.FormattingEnabled = True
        Me.cmbtime.Items.AddRange(New Object() {"8:00AM-10:00AM", "10:00AM-12:00AM", "12:00AM-2:00PM", "2:00PM-4:00PM", "4:00PM-6:00PM", "6:00PM-8:00PM"})
        Me.cmbtime.Location = New System.Drawing.Point(981, 460)
        Me.cmbtime.Name = "cmbtime"
        Me.cmbtime.Size = New System.Drawing.Size(220, 32)
        Me.cmbtime.TabIndex = 46
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label8.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label8.Location = New System.Drawing.Point(997, 413)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(108, 31)
        Me.label8.TabIndex = 45
        Me.label8.Text = "TIMING"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label7.Location = New System.Drawing.Point(638, 413)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(75, 31)
        Me.label7.TabIndex = 44
        Me.label7.Text = "TYPE"
        '
        'txtemail
        '
        Me.txtemail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtemail.Location = New System.Drawing.Point(182, 460)
        Me.txtemail.Multiline = True
        Me.txtemail.Name = "txtemail"
        Me.txtemail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtemail.Size = New System.Drawing.Size(257, 36)
        Me.txtemail.TabIndex = 43
        Me.txtemail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbtype
        '
        Me.cmbtype.Font = New System.Drawing.Font("Microsoft YaHei", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"Hair Wash", "Hair Cutting", "Facial", "Manicure", "Bridal Makeup", "Waxing", "Hair Coloring"})
        Me.cmbtype.Location = New System.Drawing.Point(604, 460)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(220, 32)
        Me.cmbtype.TabIndex = 42
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label6.Location = New System.Drawing.Point(233, 413)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(126, 31)
        Me.label6.TabIndex = 41
        Me.label6.Text = "EMAIL ID"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label5.Location = New System.Drawing.Point(1067, 287)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(64, 31)
        Me.label5.TabIndex = 40
        Me.label5.Text = "AGE"
        '
        'txtage
        '
        Me.txtage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtage.Location = New System.Drawing.Point(980, 334)
        Me.txtage.Multiline = True
        Me.txtage.Name = "txtage"
        Me.txtage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtage.Size = New System.Drawing.Size(257, 36)
        Me.txtage.TabIndex = 39
        Me.txtage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label3.Location = New System.Drawing.Point(602, 287)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(222, 31)
        Me.label3.TabIndex = 38
        Me.label3.Text = "PHONE NUMBER"
        '
        'txtphone
        '
        Me.txtphone.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtphone.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtphone.Location = New System.Drawing.Point(579, 334)
        Me.txtphone.Multiline = True
        Me.txtphone.Name = "txtphone"
        Me.txtphone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtphone.Size = New System.Drawing.Size(257, 36)
        Me.txtphone.TabIndex = 37
        Me.txtphone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label2.Location = New System.Drawing.Point(198, 287)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(216, 31)
        Me.label2.TabIndex = 36
        Me.label2.Text = " MEMBER NAME"
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtname.Location = New System.Drawing.Point(182, 334)
        Me.txtname.Multiline = True
        Me.txtname.Name = "txtname"
        Me.txtname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtname.Size = New System.Drawing.Size(257, 36)
        Me.txtname.TabIndex = 35
        Me.txtname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Crimson
        Me.label1.Location = New System.Drawing.Point(613, 117)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(242, 36)
        Me.label1.TabIndex = 34
        Me.label1.Text = "APPOINTMENT"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label4.Font = New System.Drawing.Font("Lucida Handwriting", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.MediumBlue
        Me.label4.Image = CType(resources.GetObject("label4.Image"), System.Drawing.Image)
        Me.label4.Location = New System.Drawing.Point(577, 36)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(333, 49)
        Me.label4.TabIndex = 33
        Me.label4.Text = "Beauty Salon "
        '
        'btnback
        '
        Me.btnback.BackColor = System.Drawing.Color.Aqua
        Me.btnback.FlatAppearance.BorderSize = 0
        Me.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnback.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnback.Location = New System.Drawing.Point(707, 735)
        Me.btnback.Name = "btnback"
        Me.btnback.Size = New System.Drawing.Size(119, 42)
        Me.btnback.TabIndex = 53
        Me.btnback.Text = "BACK"
        Me.btnback.UseVisualStyleBackColor = False
        '
        'APPOINTMENT1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MistyRose
        Me.ClientSize = New System.Drawing.Size(1351, 898)
        Me.Controls.Add(Me.btnback)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.btnreset)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.cmbtime)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.txtemail)
        Me.Controls.Add(Me.cmbtype)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.txtage)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.txtphone)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "APPOINTMENT1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APPOINTMENT"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents btnreset As System.Windows.Forms.Button
    Private WithEvents btnadd As System.Windows.Forms.Button
    Private WithEvents cmbtime As System.Windows.Forms.ComboBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents txtemail As System.Windows.Forms.TextBox
    Private WithEvents cmbtype As System.Windows.Forms.ComboBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtage As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents txtphone As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txtname As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents btnback As System.Windows.Forms.Button
End Class
