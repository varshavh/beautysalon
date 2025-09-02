<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADMINBOOKINGS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADMINBOOKINGS))
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.bookinglist = New System.Windows.Forms.DataGridView()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.txtphone = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtage = New System.Windows.Forms.TextBox()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.cmbtime = New System.Windows.Forms.ComboBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bookinglist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'button2
        '
        Me.button2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.button2.FlatAppearance.BorderSize = 0
        Me.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button2.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.button2.Location = New System.Drawing.Point(631, 151)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(110, 43)
        Me.button2.TabIndex = 63
        Me.button2.Text = "SEARCH"
        Me.button2.UseVisualStyleBackColor = False
        '
        'button1
        '
        Me.button1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.button1.FlatAppearance.BorderSize = 0
        Me.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button1.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.button1.Location = New System.Drawing.Point(756, 151)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(110, 43)
        Me.button1.TabIndex = 62
        Me.button1.Text = "REFRESH"
        Me.button1.UseVisualStyleBackColor = False
        '
        'textBox1
        '
        Me.textBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.textBox1.Location = New System.Drawing.Point(377, 151)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.textBox1.Size = New System.Drawing.Size(257, 43)
        Me.textBox1.TabIndex = 61
        Me.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dataGridView1
        '
        Me.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Location = New System.Drawing.Point(688, 211)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.RowTemplate.Height = 24
        Me.dataGridView1.Size = New System.Drawing.Size(712, 543)
        Me.dataGridView1.TabIndex = 60
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Crimson
        Me.label1.Location = New System.Drawing.Point(465, 82)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(247, 36)
        Me.label1.TabIndex = 59
        Me.label1.Text = "ALL BOOKINGS"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label4.Font = New System.Drawing.Font("Lucida Handwriting", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.MediumBlue
        Me.label4.Image = CType(resources.GetObject("label4.Image"), System.Drawing.Image)
        Me.label4.Location = New System.Drawing.Point(441, 21)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(333, 49)
        Me.label4.TabIndex = 58
        Me.label4.Text = "Beauty Salon "
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(614, 849)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(117, 39)
        Me.Button3.TabIndex = 64
        Me.Button3.Text = "Back"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'bookinglist
        '
        Me.bookinglist.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.bookinglist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.bookinglist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.bookinglist.Location = New System.Drawing.Point(81, 213)
        Me.bookinglist.Name = "bookinglist"
        Me.bookinglist.RowTemplate.Height = 24
        Me.bookinglist.Size = New System.Drawing.Size(1156, 543)
        Me.bookinglist.TabIndex = 60
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label2.Location = New System.Drawing.Point(74, 265)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(216, 31)
        Me.label2.TabIndex = 66
        Me.label2.Text = " MEMBER NAME"
        '
        'txtname
        '
        Me.txtname.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtname.Location = New System.Drawing.Point(296, 264)
        Me.txtname.Multiline = True
        Me.txtname.Name = "txtname"
        Me.txtname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtname.Size = New System.Drawing.Size(257, 36)
        Me.txtname.TabIndex = 65
        Me.txtname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label3.Location = New System.Drawing.Point(67, 332)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(222, 31)
        Me.label3.TabIndex = 68
        Me.label3.Text = "PHONE NUMBER"
        '
        'txtphone
        '
        Me.txtphone.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtphone.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtphone.Location = New System.Drawing.Point(296, 332)
        Me.txtphone.Multiline = True
        Me.txtphone.Name = "txtphone"
        Me.txtphone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtphone.Size = New System.Drawing.Size(257, 36)
        Me.txtphone.TabIndex = 67
        Me.txtphone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label5.Location = New System.Drawing.Point(128, 398)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(64, 31)
        Me.label5.TabIndex = 70
        Me.label5.Text = "AGE"
        '
        'txtage
        '
        Me.txtage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtage.Location = New System.Drawing.Point(296, 393)
        Me.txtage.Multiline = True
        Me.txtage.Name = "txtage"
        Me.txtage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtage.Size = New System.Drawing.Size(257, 36)
        Me.txtage.TabIndex = 69
        Me.txtage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtemail
        '
        Me.txtemail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtemail.Location = New System.Drawing.Point(296, 458)
        Me.txtemail.Multiline = True
        Me.txtemail.Name = "txtemail"
        Me.txtemail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtemail.Size = New System.Drawing.Size(257, 36)
        Me.txtemail.TabIndex = 72
        Me.txtemail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label6.Location = New System.Drawing.Point(98, 463)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(126, 31)
        Me.label6.TabIndex = 71
        Me.label6.Text = "EMAIL ID"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label7.Location = New System.Drawing.Point(126, 526)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(75, 31)
        Me.label7.TabIndex = 74
        Me.label7.Text = "TYPE"
        '
        'cmbtype
        '
        Me.cmbtype.Font = New System.Drawing.Font("Microsoft YaHei", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"Hair Wash", "Hair Cutting", "Facial", "Manicure", "Bridal Makeup", "Waxing", "Hair Coloring"})
        Me.cmbtype.Location = New System.Drawing.Point(296, 530)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(220, 32)
        Me.cmbtype.TabIndex = 73
        '
        'cmbtime
        '
        Me.cmbtime.Font = New System.Drawing.Font("Microsoft YaHei", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtime.FormattingEnabled = True
        Me.cmbtime.Items.AddRange(New Object() {"8:00AM-10:00AM", "10:00AM-12:00AM", "12:00AM-2:00PM", "2:00PM-4:00PM", "4:00PM-6:00PM", "6:00PM-8:00PM"})
        Me.cmbtime.Location = New System.Drawing.Point(296, 601)
        Me.cmbtime.Name = "cmbtime"
        Me.cmbtime.Size = New System.Drawing.Size(220, 32)
        Me.cmbtime.TabIndex = 76
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label8.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.label8.Location = New System.Drawing.Point(96, 601)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(108, 31)
        Me.label8.TabIndex = 75
        Me.label8.Text = "TIMING"
        '
        'btndelete
        '
        Me.btndelete.BackColor = System.Drawing.Color.Red
        Me.btndelete.FlatAppearance.BorderSize = 0
        Me.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndelete.Location = New System.Drawing.Point(324, 694)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(141, 40)
        Me.btndelete.TabIndex = 78
        Me.btndelete.Text = "DELETE"
        Me.btndelete.UseVisualStyleBackColor = False
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.Green
        Me.btnsave.FlatAppearance.BorderSize = 0
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(131, 694)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(158, 40)
        Me.btnsave.TabIndex = 77
        Me.btnsave.Text = "SAVE"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'MYBOOKINGS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1391, 911)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.cmbtime)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.cmbtype)
        Me.Controls.Add(Me.txtemail)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.txtage)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.txtphone)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MYBOOKINGS"
        Me.Text = "VIEWMEMBER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bookinglist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Private WithEvents bookinglist As System.Windows.Forms.DataGridView
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txtname As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents txtphone As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtage As System.Windows.Forms.TextBox
    Private WithEvents txtemail As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents cmbtype As System.Windows.Forms.ComboBox
    Private WithEvents cmbtime As System.Windows.Forms.ComboBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
End Class
