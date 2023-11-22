<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ShowPassword = New System.Windows.Forms.CheckBox()
        Me.Passwordtxt = New System.Windows.Forms.TextBox()
        Me.ConfirmPasswordtxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChangePasswordButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DeleteAccountButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(265, 36)
        Me.Label1.MinimumSize = New System.Drawing.Size(400, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(400, 32)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Change Password"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ShowPassword
        '
        Me.ShowPassword.AutoSize = True
        Me.ShowPassword.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowPassword.ForeColor = System.Drawing.Color.Gainsboro
        Me.ShowPassword.Image = CType(resources.GetObject("ShowPassword.Image"), System.Drawing.Image)
        Me.ShowPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ShowPassword.Location = New System.Drawing.Point(186, 196)
        Me.ShowPassword.MinimumSize = New System.Drawing.Size(165, 30)
        Me.ShowPassword.Name = "ShowPassword"
        Me.ShowPassword.Size = New System.Drawing.Size(165, 32)
        Me.ShowPassword.TabIndex = 39
        Me.ShowPassword.Text = "Show Password"
        Me.ShowPassword.UseVisualStyleBackColor = True
        '
        'Passwordtxt
        '
        Me.Passwordtxt.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Passwordtxt.Location = New System.Drawing.Point(381, 98)
        Me.Passwordtxt.Name = "Passwordtxt"
        Me.Passwordtxt.Size = New System.Drawing.Size(175, 23)
        Me.Passwordtxt.TabIndex = 37
        '
        'ConfirmPasswordtxt
        '
        Me.ConfirmPasswordtxt.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConfirmPasswordtxt.Location = New System.Drawing.Point(381, 148)
        Me.ConfirmPasswordtxt.Name = "ConfirmPasswordtxt"
        Me.ConfirmPasswordtxt.Size = New System.Drawing.Size(175, 23)
        Me.ConfirmPasswordtxt.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label3.Location = New System.Drawing.Point(206, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 34)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Confirm" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " New Password" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label4.Location = New System.Drawing.Point(230, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 34)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = " New" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Password"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChangePasswordButton
        '
        Me.ChangePasswordButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.ChangePasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChangePasswordButton.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangePasswordButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.ChangePasswordButton.Image = CType(resources.GetObject("ChangePasswordButton.Image"), System.Drawing.Image)
        Me.ChangePasswordButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ChangePasswordButton.Location = New System.Drawing.Point(381, 189)
        Me.ChangePasswordButton.Name = "ChangePasswordButton"
        Me.ChangePasswordButton.Size = New System.Drawing.Size(175, 45)
        Me.ChangePasswordButton.TabIndex = 40
        Me.ChangePasswordButton.Text = "Change Password"
        Me.ChangePasswordButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChangePasswordButton.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(265, 287)
        Me.Label2.MinimumSize = New System.Drawing.Size(400, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(400, 32)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Delete Account"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DeleteAccountButton
        '
        Me.DeleteAccountButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DeleteAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeleteAccountButton.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteAccountButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.DeleteAccountButton.Image = CType(resources.GetObject("DeleteAccountButton.Image"), System.Drawing.Image)
        Me.DeleteAccountButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DeleteAccountButton.Location = New System.Drawing.Point(387, 341)
        Me.DeleteAccountButton.Name = "DeleteAccountButton"
        Me.DeleteAccountButton.Size = New System.Drawing.Size(158, 45)
        Me.DeleteAccountButton.TabIndex = 40
        Me.DeleteAccountButton.Text = "Delete Account"
        Me.DeleteAccountButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DeleteAccountButton.UseVisualStyleBackColor = False
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(912, 526)
        Me.Controls.Add(Me.DeleteAccountButton)
        Me.Controls.Add(Me.ChangePasswordButton)
        Me.Controls.Add(Me.ShowPassword)
        Me.Controls.Add(Me.Passwordtxt)
        Me.Controls.Add(Me.ConfirmPasswordtxt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SettingsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SettingsForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents ShowPassword As CheckBox
    Friend WithEvents Passwordtxt As TextBox
    Friend WithEvents ConfirmPasswordtxt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ChangePasswordButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents DeleteAccountButton As Button
End Class
