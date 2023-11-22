<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignUpForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignUpForm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ConfirmPasswordtxt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Passwordtxt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Usernametxt = New System.Windows.Forms.TextBox()
        Me.ShowPassword = New System.Windows.Forms.CheckBox()
        Me.SignUpButton = New System.Windows.Forms.Button()
        Me.Emailtxt = New System.Windows.Forms.TextBox()
        Me.IcloudButton = New System.Windows.Forms.Button()
        Me.MGSButton = New System.Windows.Forms.Button()
        Me.GmailButton = New System.Windows.Forms.Button()
        Me.HotmailButton = New System.Windows.Forms.Button()
        Me.YahooButton = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ReturnButton = New System.Windows.Forms.Button()
        Me.CloseProgramLabel = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(235, 256)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ConfirmPasswordtxt
        '
        Me.ConfirmPasswordtxt.Location = New System.Drawing.Point(322, 155)
        Me.ConfirmPasswordtxt.Name = "ConfirmPasswordtxt"
        Me.ConfirmPasswordtxt.Size = New System.Drawing.Size(143, 20)
        Me.ConfirmPasswordtxt.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(248, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(241, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Username"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(248, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 32)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Confirm" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Password" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Passwordtxt
        '
        Me.Passwordtxt.Location = New System.Drawing.Point(322, 113)
        Me.Passwordtxt.Name = "Passwordtxt"
        Me.Passwordtxt.Size = New System.Drawing.Size(143, 20)
        Me.Passwordtxt.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(254, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Email"
        '
        'Usernametxt
        '
        Me.Usernametxt.Location = New System.Drawing.Point(322, 37)
        Me.Usernametxt.Name = "Usernametxt"
        Me.Usernametxt.Size = New System.Drawing.Size(143, 20)
        Me.Usernametxt.TabIndex = 6
        '
        'ShowPassword
        '
        Me.ShowPassword.AutoSize = True
        Me.ShowPassword.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowPassword.Location = New System.Drawing.Point(251, 200)
        Me.ShowPassword.Name = "ShowPassword"
        Me.ShowPassword.Size = New System.Drawing.Size(113, 19)
        Me.ShowPassword.TabIndex = 8
        Me.ShowPassword.Text = "Show Password"
        Me.ShowPassword.UseVisualStyleBackColor = True
        '
        'SignUpButton
        '
        Me.SignUpButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.SignUpButton.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SignUpButton.Location = New System.Drawing.Point(390, 194)
        Me.SignUpButton.Name = "SignUpButton"
        Me.SignUpButton.Size = New System.Drawing.Size(75, 25)
        Me.SignUpButton.TabIndex = 9
        Me.SignUpButton.Text = "SignUp"
        Me.SignUpButton.UseVisualStyleBackColor = False
        '
        'Emailtxt
        '
        Me.Emailtxt.Location = New System.Drawing.Point(322, 73)
        Me.Emailtxt.Name = "Emailtxt"
        Me.Emailtxt.Size = New System.Drawing.Size(143, 20)
        Me.Emailtxt.TabIndex = 6
        '
        'IcloudButton
        '
        Me.IcloudButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.IcloudButton.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IcloudButton.Location = New System.Drawing.Point(471, 51)
        Me.IcloudButton.Name = "IcloudButton"
        Me.IcloudButton.Size = New System.Drawing.Size(86, 22)
        Me.IcloudButton.TabIndex = 9
        Me.IcloudButton.Text = "@icloud.com"
        Me.IcloudButton.UseVisualStyleBackColor = False
        '
        'MGSButton
        '
        Me.MGSButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.MGSButton.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MGSButton.Location = New System.Drawing.Point(501, 73)
        Me.MGSButton.Name = "MGSButton"
        Me.MGSButton.Size = New System.Drawing.Size(118, 23)
        Me.MGSButton.TabIndex = 9
        Me.MGSButton.Text = "@mgs.kent.sch.uk"
        Me.MGSButton.UseVisualStyleBackColor = False
        '
        'GmailButton
        '
        Me.GmailButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.GmailButton.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GmailButton.Location = New System.Drawing.Point(471, 96)
        Me.GmailButton.Name = "GmailButton"
        Me.GmailButton.Size = New System.Drawing.Size(86, 23)
        Me.GmailButton.TabIndex = 9
        Me.GmailButton.Text = "@gmail.com"
        Me.GmailButton.UseVisualStyleBackColor = False
        '
        'HotmailButton
        '
        Me.HotmailButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.HotmailButton.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HotmailButton.Location = New System.Drawing.Point(555, 51)
        Me.HotmailButton.Name = "HotmailButton"
        Me.HotmailButton.Size = New System.Drawing.Size(94, 22)
        Me.HotmailButton.TabIndex = 9
        Me.HotmailButton.Text = "@hotmail.com"
        Me.HotmailButton.UseVisualStyleBackColor = False
        '
        'YahooButton
        '
        Me.YahooButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.YahooButton.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YahooButton.Location = New System.Drawing.Point(555, 96)
        Me.YahooButton.Name = "YahooButton"
        Me.YahooButton.Size = New System.Drawing.Size(86, 23)
        Me.YahooButton.TabIndex = 9
        Me.YahooButton.Text = "@yahoo.com"
        Me.YahooButton.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Lucida Calligraphy", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(519, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Shortcuts"
        '
        'ReturnButton
        '
        Me.ReturnButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.ReturnButton.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReturnButton.Location = New System.Drawing.Point(566, 194)
        Me.ReturnButton.Name = "ReturnButton"
        Me.ReturnButton.Size = New System.Drawing.Size(75, 25)
        Me.ReturnButton.TabIndex = 9
        Me.ReturnButton.Text = "Return"
        Me.ReturnButton.UseVisualStyleBackColor = False
        '
        'CloseProgramLabel
        '
        Me.CloseProgramLabel.AutoSize = True
        Me.CloseProgramLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseProgramLabel.Font = New System.Drawing.Font("Trebuchet MS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseProgramLabel.ForeColor = System.Drawing.Color.Red
        Me.CloseProgramLabel.Location = New System.Drawing.Point(631, -5)
        Me.CloseProgramLabel.Name = "CloseProgramLabel"
        Me.CloseProgramLabel.Size = New System.Drawing.Size(25, 29)
        Me.CloseProgramLabel.TabIndex = 11
        Me.CloseProgramLabel.Text = "x"
        Me.ToolTip1.SetToolTip(Me.CloseProgramLabel, "Close")
        '
        'SignUpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(653, 256)
        Me.Controls.Add(Me.CloseProgramLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MGSButton)
        Me.Controls.Add(Me.YahooButton)
        Me.Controls.Add(Me.GmailButton)
        Me.Controls.Add(Me.HotmailButton)
        Me.Controls.Add(Me.IcloudButton)
        Me.Controls.Add(Me.ReturnButton)
        Me.Controls.Add(Me.SignUpButton)
        Me.Controls.Add(Me.ShowPassword)
        Me.Controls.Add(Me.Passwordtxt)
        Me.Controls.Add(Me.ConfirmPasswordtxt)
        Me.Controls.Add(Me.Usernametxt)
        Me.Controls.Add(Me.Emailtxt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SignUpForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SignUpForm"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ConfirmPasswordtxt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Passwordtxt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Usernametxt As TextBox
    Friend WithEvents ShowPassword As CheckBox
    Friend WithEvents SignUpButton As Button
    Friend WithEvents Emailtxt As TextBox
    Friend WithEvents IcloudButton As Button
    Friend WithEvents MGSButton As Button
    Friend WithEvents GmailButton As Button
    Friend WithEvents HotmailButton As Button
    Friend WithEvents YahooButton As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents ReturnButton As Button
    Friend WithEvents CloseProgramLabel As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
