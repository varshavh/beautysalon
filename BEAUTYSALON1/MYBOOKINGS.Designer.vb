<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MYBOOKINGS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MYBOOKINGS))
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.bookinglist = New System.Windows.Forms.DataGridView()
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
        Me.dataGridView1.Location = New System.Drawing.Point(81, 213)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.RowTemplate.Height = 24
        Me.dataGridView1.Size = New System.Drawing.Size(1156, 543)
        Me.dataGridView1.TabIndex = 60
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Crimson
        Me.label1.Location = New System.Drawing.Point(465, 82)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(236, 36)
        Me.label1.TabIndex = 59
        Me.label1.Text = "MY BOOKINGS"
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
        'MYBOOKINGS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1391, 911)
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
End Class
