<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REGISTER
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(REGISTER))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.txtpass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcpass = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnreg = New System.Windows.Forms.Button()
        Me.btnreset = New System.Windows.Forms.Button()
        Me.txtphone = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtage = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnback = New System.Windows.Forms.Button()
        Me.checkpass = New System.Windows.Forms.CheckBox()
        Me.checkcpass = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(24, 45)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(134, 131)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 17
        Me.PictureBox2.TabStop = False
        '
        'txtname
        '
        Me.txtname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtname.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(533, 227)
        Me.txtname.Multiline = True
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(205, 34)
        Me.txtname.TabIndex = 21
        Me.txtname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Moccasin
        Me.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.label1.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(343, 235)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(128, 26)
        Me.label1.TabIndex = 20
        Me.label1.Text = "USERNAME:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Moccasin
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(343, 290)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 26)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "EMAIL ID:"
        '
        'txtemail
        '
        Me.txtemail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtemail.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.Location = New System.Drawing.Point(533, 282)
        Me.txtemail.Multiline = True
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(205, 34)
        Me.txtemail.TabIndex = 23
        Me.txtemail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtpass
        '
        Me.txtpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpass.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpass.Location = New System.Drawing.Point(533, 489)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.Size = New System.Drawing.Size(205, 34)
        Me.txtpass.TabIndex = 25
        Me.txtpass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtpass.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Moccasin
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(352, 493)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 26)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "PASSWORD:"
        '
        'txtcpass
        '
        Me.txtcpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcpass.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcpass.Location = New System.Drawing.Point(533, 563)
        Me.txtcpass.Name = "txtcpass"
        Me.txtcpass.Size = New System.Drawing.Size(205, 34)
        Me.txtcpass.TabIndex = 27
        Me.txtcpass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtcpass.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Moccasin
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(268, 571)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(230, 26)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "CONFIRM PASSWORD:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.BurlyWood
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(438, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(188, 38)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "REGISTER"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.BurlyWood
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label6.Font = New System.Drawing.Font("Lucida Handwriting", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(396, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(290, 43)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Beauty Salon "
        '
        'btnreg
        '
        Me.btnreg.BackColor = System.Drawing.Color.Green
        Me.btnreg.FlatAppearance.BorderSize = 0
        Me.btnreg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreg.Location = New System.Drawing.Point(427, 677)
        Me.btnreg.Name = "btnreg"
        Me.btnreg.Size = New System.Drawing.Size(158, 40)
        Me.btnreg.TabIndex = 30
        Me.btnreg.Text = "REGISTER"
        Me.btnreg.UseVisualStyleBackColor = False
        '
        'btnreset
        '
        Me.btnreset.BackColor = System.Drawing.Color.Red
        Me.btnreset.FlatAppearance.BorderSize = 0
        Me.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreset.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreset.Location = New System.Drawing.Point(620, 677)
        Me.btnreset.Name = "btnreset"
        Me.btnreset.Size = New System.Drawing.Size(141, 40)
        Me.btnreset.TabIndex = 31
        Me.btnreset.Text = "RESET"
        Me.btnreset.UseVisualStyleBackColor = False
        '
        'txtphone
        '
        Me.txtphone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtphone.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtphone.Location = New System.Drawing.Point(533, 352)
        Me.txtphone.Multiline = True
        Me.txtphone.Name = "txtphone"
        Me.txtphone.Size = New System.Drawing.Size(205, 34)
        Me.txtphone.TabIndex = 33
        Me.txtphone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Moccasin
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label7.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(316, 356)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(182, 26)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "PHONE NUMBER:"
        '
        'txtage
        '
        Me.txtage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtage.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtage.Location = New System.Drawing.Point(533, 418)
        Me.txtage.Multiline = True
        Me.txtage.Name = "txtage"
        Me.txtage.Size = New System.Drawing.Size(205, 34)
        Me.txtage.TabIndex = 35
        Me.txtage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Moccasin
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label8.Font = New System.Drawing.Font("Microsoft YaHei", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(377, 422)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 26)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "AGE:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1231, 851)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnback
        '
        Me.btnback.BackColor = System.Drawing.Color.Chartreuse
        Me.btnback.FlatAppearance.BorderSize = 0
        Me.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnback.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnback.Location = New System.Drawing.Point(545, 762)
        Me.btnback.Name = "btnback"
        Me.btnback.Size = New System.Drawing.Size(141, 40)
        Me.btnback.TabIndex = 36
        Me.btnback.Text = "BACK"
        Me.btnback.UseVisualStyleBackColor = False
        '
        'checkpass
        '
        Me.checkpass.AutoSize = True
        Me.checkpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkpass.Location = New System.Drawing.Point(711, 496)
        Me.checkpass.Name = "checkpass"
        Me.checkpass.Size = New System.Drawing.Size(18, 17)
        Me.checkpass.TabIndex = 37
        Me.checkpass.UseVisualStyleBackColor = True
        '
        'checkcpass
        '
        Me.checkcpass.AutoSize = True
        Me.checkcpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkcpass.Location = New System.Drawing.Point(711, 570)
        Me.checkcpass.Name = "checkcpass"
        Me.checkcpass.Size = New System.Drawing.Size(18, 17)
        Me.checkcpass.TabIndex = 38
        Me.checkcpass.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1154, 790)
        Me.Panel1.TabIndex = 39
        '
        'REGISTER
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1231, 851)
        Me.Controls.Add(Me.checkcpass)
        Me.Controls.Add(Me.checkpass)
        Me.Controls.Add(Me.btnback)
        Me.Controls.Add(Me.txtage)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtphone)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnreset)
        Me.Controls.Add(Me.btnreg)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtcpass)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtpass)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtemail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "REGISTER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Private WithEvents txtname As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents txtemail As System.Windows.Forms.TextBox
    Private WithEvents txtpass As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents txtcpass As System.Windows.Forms.TextBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnreg As System.Windows.Forms.Button
    Friend WithEvents btnreset As System.Windows.Forms.Button
    Private WithEvents txtphone As System.Windows.Forms.TextBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents txtage As System.Windows.Forms.TextBox
    Private WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnback As System.Windows.Forms.Button
    Friend WithEvents checkpass As System.Windows.Forms.CheckBox
    Friend WithEvents checkcpass As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
