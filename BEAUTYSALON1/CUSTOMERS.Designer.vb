<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CUSTOMERS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CUSTOMERS))
        Me.button2 = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.txtage = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtphone = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Location = New System.Drawing.Point(756, 151)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(110, 43)
        Me.btnRefresh.TabIndex = 62
        Me.btnRefresh.Text = "REFRESH"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSearch.Location = New System.Drawing.Point(377, 151)
        Me.txtSearch.Multiline = True
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearch.Size = New System.Drawing.Size(257, 43)
        Me.txtSearch.TabIndex = 61
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dataGridView1
        '
        Me.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Location = New System.Drawing.Point(631, 215)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.RowTemplate.Height = 24
        Me.dataGridView1.Size = New System.Drawing.Size(775, 543)
        Me.dataGridView1.TabIndex = 60
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Crimson
        Me.label1.Location = New System.Drawing.Point(465, 82)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(290, 36)
        Me.label1.TabIndex = 59
        Me.label1.Text = "CUSTOMERS LIST"
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
        'txtage
        '
        Me.txtage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtage.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtage.Location = New System.Drawing.Point(339, 528)
        Me.txtage.Multiline = True
        Me.txtage.Name = "txtage"
        Me.txtage.Size = New System.Drawing.Size(205, 34)
        Me.txtage.TabIndex = 72
        Me.txtage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Moccasin
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label8.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(183, 532)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 26)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "AGE:"
        '
        'txtphone
        '
        Me.txtphone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtphone.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtphone.Location = New System.Drawing.Point(339, 462)
        Me.txtphone.Multiline = True
        Me.txtphone.Name = "txtphone"
        Me.txtphone.Size = New System.Drawing.Size(205, 34)
        Me.txtphone.TabIndex = 70
        Me.txtphone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Moccasin
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label7.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(122, 466)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(182, 26)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "PHONE NUMBER:"
        '
        'txtemail
        '
        Me.txtemail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtemail.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.Location = New System.Drawing.Point(339, 392)
        Me.txtemail.Multiline = True
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(205, 34)
        Me.txtemail.TabIndex = 68
        Me.txtemail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Moccasin
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(149, 400)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 26)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "EMAIL ID:"
        '
        'txtname
        '
        Me.txtname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtname.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(339, 337)
        Me.txtname.Multiline = True
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(205, 34)
        Me.txtname.TabIndex = 66
        Me.txtname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Moccasin
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(149, 345)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 26)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "NAME:"
        '
        'btndelete
        '
        Me.btndelete.BackColor = System.Drawing.Color.Red
        Me.btndelete.FlatAppearance.BorderSize = 0
        Me.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndelete.Location = New System.Drawing.Point(377, 636)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(141, 40)
        Me.btndelete.TabIndex = 74
        Me.btndelete.Text = "DELETE"
        Me.btndelete.UseVisualStyleBackColor = False
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.Green
        Me.btnsave.FlatAppearance.BorderSize = 0
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(184, 636)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(158, 40)
        Me.btnsave.TabIndex = 73
        Me.btnsave.Text = "SAVE"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'CUSTOMERS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1391, 911)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.txtage)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtphone)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtemail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CUSTOMERS"
        Me.Text = "VIEWMEMBER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents btnRefresh As System.Windows.Forms.Button
    Private WithEvents txtSearch As System.Windows.Forms.TextBox
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private WithEvents txtage As System.Windows.Forms.TextBox
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents txtphone As System.Windows.Forms.TextBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents txtemail As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents txtname As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
End Class
