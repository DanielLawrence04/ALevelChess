<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForgottenPasswordForm
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
        Me.ChangePasswordButton = New System.Windows.Forms.Button()
        Me.ShowPassword = New System.Windows.Forms.CheckBox()
        Me.Passwordtxt = New System.Windows.Forms.TextBox()
        Me.ConfirmPasswordtxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CloseProgramLabel = New System.Windows.Forms.Label()
        Me.ReturnLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ChangePasswordButton
        '
        Me.ChangePasswordButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.ChangePasswordButton.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangePasswordButton.Location = New System.Drawing.Point(233, 145)
        Me.ChangePasswordButton.Name = "ChangePasswordButton"
        Me.ChangePasswordButton.Size = New System.Drawing.Size(113, 41)
        Me.ChangePasswordButton.TabIndex = 47
        Me.ChangePasswordButton.Text = "Change Password"
        Me.ChangePasswordButton.UseVisualStyleBackColor = False
        '
        'ShowPassword
        '
        Me.ShowPassword.AutoSize = True
        Me.ShowPassword.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowPassword.Location = New System.Drawing.Point(114, 159)
        Me.ShowPassword.Name = "ShowPassword"
        Me.ShowPassword.Size = New System.Drawing.Size(113, 19)
        Me.ShowPassword.TabIndex = 46
        Me.ShowPassword.Text = "Show Password"
        Me.ShowPassword.UseVisualStyleBackColor = True
        '
        'Passwordtxt
        '
        Me.Passwordtxt.Location = New System.Drawing.Point(203, 73)
        Me.Passwordtxt.Name = "Passwordtxt"
        Me.Passwordtxt.Size = New System.Drawing.Size(143, 20)
        Me.Passwordtxt.TabIndex = 44
        '
        'ConfirmPasswordtxt
        '
        Me.ConfirmPasswordtxt.Location = New System.Drawing.Point(203, 115)
        Me.ConfirmPasswordtxt.Name = "ConfirmPasswordtxt"
        Me.ConfirmPasswordtxt.Size = New System.Drawing.Size(143, 20)
        Me.ConfirmPasswordtxt.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(91, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 32)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Confirm" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " New Password" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(111, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 32)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = " New" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Password"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Calligraphy", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(74, 48)
        Me.Label1.MinimumSize = New System.Drawing.Size(400, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(400, 17)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Change Password"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CloseProgramLabel
        '
        Me.CloseProgramLabel.AutoSize = True
        Me.CloseProgramLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloseProgramLabel.Font = New System.Drawing.Font("Trebuchet MS", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseProgramLabel.ForeColor = System.Drawing.Color.Red
        Me.CloseProgramLabel.Location = New System.Drawing.Point(470, -1)
        Me.CloseProgramLabel.Name = "CloseProgramLabel"
        Me.CloseProgramLabel.Size = New System.Drawing.Size(25, 29)
        Me.CloseProgramLabel.TabIndex = 48
        Me.CloseProgramLabel.Text = "x"
        '
        'ReturnLabel
        '
        Me.ReturnLabel.AutoSize = True
        Me.ReturnLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ReturnLabel.Font = New System.Drawing.Font("Trebuchet MS", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReturnLabel.ForeColor = System.Drawing.Color.Red
        Me.ReturnLabel.Location = New System.Drawing.Point(-1, -14)
        Me.ReturnLabel.Name = "ReturnLabel"
        Me.ReturnLabel.Size = New System.Drawing.Size(48, 46)
        Me.ReturnLabel.TabIndex = 48
        Me.ReturnLabel.Text = "←"
        '
        'ForgottenPasswordForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(496, 254)
        Me.Controls.Add(Me.ReturnLabel)
        Me.Controls.Add(Me.CloseProgramLabel)
        Me.Controls.Add(Me.ChangePasswordButton)
        Me.Controls.Add(Me.ShowPassword)
        Me.Controls.Add(Me.Passwordtxt)
        Me.Controls.Add(Me.ConfirmPasswordtxt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ForgottenPasswordForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ForgottenPasswordForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ChangePasswordButton As Button
    Friend WithEvents ShowPassword As CheckBox
    Friend WithEvents Passwordtxt As TextBox
    Friend WithEvents ConfirmPasswordtxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CloseProgramLabel As Label
    Friend WithEvents ReturnLabel As Label
End Class
