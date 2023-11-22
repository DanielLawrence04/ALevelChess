<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Usernametxt = New System.Windows.Forms.TextBox()
        Me.Passwordtxt = New System.Windows.Forms.TextBox()
        Me.ShowPassword = New System.Windows.Forms.CheckBox()
        Me.LoginButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SignUpLink = New System.Windows.Forms.LinkLabel()
        Me.CloseProgramLabel = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ForgottenPasswordLink = New System.Windows.Forms.LinkLabel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(254, 256)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(260, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Username" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Or email)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(260, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password"
        '
        'Usernametxt
        '
        Me.Usernametxt.Location = New System.Drawing.Point(341, 62)
        Me.Usernametxt.Name = "Usernametxt"
        Me.Usernametxt.Size = New System.Drawing.Size(143, 20)
        Me.Usernametxt.TabIndex = 3
        '
        'Passwordtxt
        '
        Me.Passwordtxt.Location = New System.Drawing.Point(341, 103)
        Me.Passwordtxt.Name = "Passwordtxt"
        Me.Passwordtxt.Size = New System.Drawing.Size(143, 20)
        Me.Passwordtxt.TabIndex = 4
        '
        'ShowPassword
        '
        Me.ShowPassword.AutoSize = True
        Me.ShowPassword.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowPassword.Location = New System.Drawing.Point(260, 134)
        Me.ShowPassword.Name = "ShowPassword"
        Me.ShowPassword.Size = New System.Drawing.Size(113, 19)
        Me.ShowPassword.TabIndex = 5
        Me.ShowPassword.Text = "Show Password"
        Me.ShowPassword.UseVisualStyleBackColor = True
        '
        'LoginButton
        '
        Me.LoginButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.LoginButton.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoginButton.Location = New System.Drawing.Point(379, 130)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(75, 25)
        Me.LoginButton.TabIndex = 6
        Me.LoginButton.Text = "Login"
        Me.LoginButton.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(260, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(195, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Don't have an account? Sign up"
        '
        'SignUpLink
        '
        Me.SignUpLink.AutoSize = True
        Me.SignUpLink.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SignUpLink.Location = New System.Drawing.Point(455, 182)
        Me.SignUpLink.Name = "SignUpLink"
        Me.SignUpLink.Size = New System.Drawing.Size(32, 15)
        Me.SignUpLink.TabIndex = 8
        Me.SignUpLink.TabStop = True
        Me.SignUpLink.Text = "here"
        Me.SignUpLink.VisitedLinkColor = System.Drawing.Color.Transparent
        '
        'CloseProgramLabel
        '
        Me.CloseProgramLabel.AutoSize = True
        Me.CloseProgramLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseProgramLabel.Font = New System.Drawing.Font("Trebuchet MS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseProgramLabel.ForeColor = System.Drawing.Color.Red
        Me.CloseProgramLabel.Location = New System.Drawing.Point(476, -3)
        Me.CloseProgramLabel.Name = "CloseProgramLabel"
        Me.CloseProgramLabel.Size = New System.Drawing.Size(25, 29)
        Me.CloseProgramLabel.TabIndex = 10
        Me.CloseProgramLabel.Text = "x"
        Me.ToolTip1.SetToolTip(Me.CloseProgramLabel, "Close")
        '
        'ForgottenPasswordLink
        '
        Me.ForgottenPasswordLink.AutoSize = True
        Me.ForgottenPasswordLink.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForgottenPasswordLink.Location = New System.Drawing.Point(327, 209)
        Me.ForgottenPasswordLink.Name = "ForgottenPasswordLink"
        Me.ForgottenPasswordLink.Size = New System.Drawing.Size(102, 15)
        Me.ForgottenPasswordLink.TabIndex = 8
        Me.ForgottenPasswordLink.TabStop = True
        Me.ForgottenPasswordLink.Text = "Forgot password"
        Me.ForgottenPasswordLink.VisitedLinkColor = System.Drawing.Color.Transparent
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(496, 254)
        Me.Controls.Add(Me.CloseProgramLabel)
        Me.Controls.Add(Me.ForgottenPasswordLink)
        Me.Controls.Add(Me.SignUpLink)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LoginButton)
        Me.Controls.Add(Me.ShowPassword)
        Me.Controls.Add(Me.Passwordtxt)
        Me.Controls.Add(Me.Usernametxt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Usernametxt As TextBox
    Friend WithEvents Passwordtxt As TextBox
    Friend WithEvents ShowPassword As CheckBox
    Friend WithEvents LoginButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents SignUpLink As LinkLabel
    Friend WithEvents CloseProgramLabel As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ForgottenPasswordLink As LinkLabel
End Class
