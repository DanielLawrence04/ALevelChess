<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiplayerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultiplayerForm))
        Me.User1Label = New System.Windows.Forms.Label()
        Me.User2Label = New System.Windows.Forms.Label()
        Me.SignUpLink = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Passwordtxt = New System.Windows.Forms.TextBox()
        Me.Usernametxt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ShowPassword = New System.Windows.Forms.CheckBox()
        Me.LoginButton = New System.Windows.Forms.Button()
        Me.GuestButton = New System.Windows.Forms.Button()
        Me.PlayButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'User1Label
        '
        Me.User1Label.AutoSize = True
        Me.User1Label.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.User1Label.ForeColor = System.Drawing.Color.Gainsboro
        Me.User1Label.Location = New System.Drawing.Point(277, 83)
        Me.User1Label.MinimumSize = New System.Drawing.Size(300, 0)
        Me.User1Label.Name = "User1Label"
        Me.User1Label.Size = New System.Drawing.Size(300, 22)
        Me.User1Label.TabIndex = 1
        Me.User1Label.Text = "User1"
        Me.User1Label.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'User2Label
        '
        Me.User2Label.AutoSize = True
        Me.User2Label.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.User2Label.ForeColor = System.Drawing.Color.Gainsboro
        Me.User2Label.Location = New System.Drawing.Point(277, 187)
        Me.User2Label.MinimumSize = New System.Drawing.Size(300, 0)
        Me.User2Label.Name = "User2Label"
        Me.User2Label.Size = New System.Drawing.Size(300, 22)
        Me.User2Label.TabIndex = 1
        Me.User2Label.Text = "N/A"
        Me.User2Label.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'SignUpLink
        '
        Me.SignUpLink.AutoSize = True
        Me.SignUpLink.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SignUpLink.ForeColor = System.Drawing.Color.Gainsboro
        Me.SignUpLink.LinkColor = System.Drawing.Color.Aqua
        Me.SignUpLink.Location = New System.Drawing.Point(521, 428)
        Me.SignUpLink.Name = "SignUpLink"
        Me.SignUpLink.Size = New System.Drawing.Size(43, 20)
        Me.SignUpLink.TabIndex = 16
        Me.SignUpLink.TabStop = True
        Me.SignUpLink.Text = "here"
        Me.SignUpLink.VisitedLinkColor = System.Drawing.Color.Transparent
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label3.Location = New System.Drawing.Point(277, 428)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(245, 20)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Don't have an account? Sign up"
        '
        'Passwordtxt
        '
        Me.Passwordtxt.Location = New System.Drawing.Point(350, 290)
        Me.Passwordtxt.Name = "Passwordtxt"
        Me.Passwordtxt.Size = New System.Drawing.Size(156, 20)
        Me.Passwordtxt.TabIndex = 12
        '
        'Usernametxt
        '
        Me.Usernametxt.Location = New System.Drawing.Point(350, 242)
        Me.Usernametxt.Name = "Usernametxt"
        Me.Usernametxt.Size = New System.Drawing.Size(156, 20)
        Me.Usernametxt.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label4.Location = New System.Drawing.Point(254, 292)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label5.Location = New System.Drawing.Point(253, 236)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 34)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Username" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Or email)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(379, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 30)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Player 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(379, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 30)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Player 2"
        '
        'ShowPassword
        '
        Me.ShowPassword.AutoSize = True
        Me.ShowPassword.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowPassword.ForeColor = System.Drawing.Color.Gainsboro
        Me.ShowPassword.Image = CType(resources.GetObject("ShowPassword.Image"), System.Drawing.Image)
        Me.ShowPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ShowPassword.Location = New System.Drawing.Point(527, 284)
        Me.ShowPassword.MinimumSize = New System.Drawing.Size(165, 30)
        Me.ShowPassword.Name = "ShowPassword"
        Me.ShowPassword.Size = New System.Drawing.Size(165, 32)
        Me.ShowPassword.TabIndex = 40
        Me.ShowPassword.Text = "Show Password"
        Me.ShowPassword.UseVisualStyleBackColor = True
        '
        'LoginButton
        '
        Me.LoginButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LoginButton.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoginButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.LoginButton.Image = CType(resources.GetObject("LoginButton.Image"), System.Drawing.Image)
        Me.LoginButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoginButton.Location = New System.Drawing.Point(350, 327)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(156, 81)
        Me.LoginButton.TabIndex = 43
        Me.LoginButton.Text = "Login"
        Me.LoginButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LoginButton.UseVisualStyleBackColor = False
        '
        'GuestButton
        '
        Me.GuestButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.GuestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GuestButton.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GuestButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.GuestButton.Image = CType(resources.GetObject("GuestButton.Image"), System.Drawing.Image)
        Me.GuestButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.GuestButton.Location = New System.Drawing.Point(525, 346)
        Me.GuestButton.Name = "GuestButton"
        Me.GuestButton.Size = New System.Drawing.Size(185, 43)
        Me.GuestButton.TabIndex = 43
        Me.GuestButton.Text = "Play as guest"
        Me.GuestButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.GuestButton.UseVisualStyleBackColor = False
        '
        'PlayButton
        '
        Me.PlayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PlayButton.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.PlayButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PlayButton.Location = New System.Drawing.Point(350, 221)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(156, 41)
        Me.PlayButton.TabIndex = 43
        Me.PlayButton.Text = "Play"
        Me.PlayButton.UseVisualStyleBackColor = False
        Me.PlayButton.Visible = False
        '
        'MultiplayerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(912, 526)
        Me.Controls.Add(Me.GuestButton)
        Me.Controls.Add(Me.LoginButton)
        Me.Controls.Add(Me.ShowPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SignUpLink)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Passwordtxt)
        Me.Controls.Add(Me.Usernametxt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.User2Label)
        Me.Controls.Add(Me.User1Label)
        Me.Controls.Add(Me.PlayButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MultiplayerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MultiplayerForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents User1Label As Label
    Friend WithEvents User2Label As Label
    Friend WithEvents SignUpLink As LinkLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents Passwordtxt As TextBox
    Friend WithEvents Usernametxt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ShowPassword As CheckBox
    Friend WithEvents LoginButton As Button
    Friend WithEvents GuestButton As Button
    Friend WithEvents PlayButton As Button
End Class
