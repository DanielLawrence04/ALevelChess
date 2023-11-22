Imports System.Data.OleDb
Imports System.Data

Public Class ForgottenPasswordForm
    Dim PasswordIsValid As Boolean = True 'Variable which determines whether or not the user can sign up
    Private Sub ChangePasswordButton_Click(sender As Object, e As EventArgs) Handles ChangePasswordButton.Click
        If Passwordtxt.Text = "" Then
            MessageBox.Show("Please enter a new password")
            PasswordIsValid = False
        ElseIf ConfirmPasswordtxt.Text = "" Then
            MessageBox.Show("Please confirm your new password")
            PasswordIsValid = False
        ElseIf Len(Passwordtxt.Text) < 5 Then
            MessageBox.Show("Password is too short. Please make it between 5 and 30 characters")
            PasswordIsValid = False
        ElseIf Len(Passwordtxt.Text) > 30 Then
            MessageBox.Show("Password is too long. Please make it between 5 and 30 characters")
            PasswordIsValid = False
        ElseIf Passwordtxt.Text <> ConfirmPasswordtxt.Text Then
            MessageBox.Show("Passwords do not match up")
            PasswordIsValid = False
        ElseIf Len(Passwordtxt.Text) >= 5 And Len(Passwordtxt.Text) <= 30 And Passwordtxt.Text = ConfirmPasswordtxt.Text Then 'Password is valid
            PasswordIsValid = True
        End If

        If PasswordIsValid = True Then
            Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
            Dim result As DialogResult
            'displaying messagebox
            result = MessageBox.Show("Are you sure you want to change your password?", "Change Password Confirmation", button)
            'getting result of the messagebox
            If result = System.Windows.Forms.DialogResult.Yes Then
                'Update password
                'Setting database location
                Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
                'Openning connection
                Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
                Dim DBsource As String = "Data Source=" & dbfilename

                Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
                cn.Open() 'Open connection
                Dim sql As String
                sql = "update [Table1]"
                sql = sql & "SET [Password] = '" & Passwordtxt.Text & "' "
                sql = sql & "WHERE [ID] = " & LoginForm.Player1ID & ";"
                Dim cmd As New OleDbCommand(sql, cn)
                cmd.ExecuteNonQuery()
                cn.Close() 'Close connection
                MessageBox.Show("Password Changed")
                'Close form
                Me.Close()

            Else
                PasswordIsValid = False
            End If
        End If
    End Sub

    Private Sub ForgottenPasswordForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Setting text box input
        Me.Passwordtxt.PasswordChar = "*"
        Me.ConfirmPasswordtxt.PasswordChar = "*"
    End Sub

    Private Sub ShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPassword.CheckedChanged
        If Me.ShowPassword.Checked = True Then
            Me.Passwordtxt.PasswordChar = "" 'If user ticks the show password box, show password
            Me.ConfirmPasswordtxt.PasswordChar = ""
        Else
            Me.Passwordtxt.PasswordChar = "*" 'If box is unticked turn password into *
            Me.ConfirmPasswordtxt.PasswordChar = "*"
        End If
    End Sub

    Private Sub CloseProgramLabel_Click(sender As Object, e As EventArgs) Handles CloseProgramLabel.Click
        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult
        'displaying messagebox
        result = MessageBox.Show("Are you sure you want close the program?", "Exit Program", button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.Yes Then
            'end program
            End
        End If
    End Sub

    Private Sub ReturnLabel_Click(sender As Object, e As EventArgs) Handles ReturnLabel.Click
        'Show login form
        LoginForm.Show()
        'Close current form
        Me.Close()
    End Sub
End Class