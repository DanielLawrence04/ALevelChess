Imports System.Net.Mail
Imports System.Data
Imports System.Data.OleDb
Public Class SignUpForm
    Dim UserIsValid As Boolean = True 'Variable which determines whether or not the user can sign up
    Public Sub CheckAvailability()
        'Setting database location
        Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
        'Openning connection
        Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
        Dim DBsource As String = "Data Source=" & dbfilename
        Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
        Dim da As OleDbDataAdapter 'adapter
        Dim ds As New DataSet 'set used with adapter
        Dim sql As String
        sql = "SELECT [Username],[Email] FROM [Table1]" 'SQL Statement
        Dim cmd As New OleDbCommand(sql, cn)
        da = New OleDbDataAdapter(sql, cn)
        cn.Open() 'Open connection
        da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter

        Dim count As Integer

        For count = 0 To ds.Tables(0).Rows.Count - 1
            If Usernametxt.Text = ds.Tables(0).Rows(count).Item(0) Then
                UserIsValid = False
                MessageBox.Show("Username already in use")
            ElseIf Emailtxt.Text = ds.Tables(0).Rows(count).Item(1) Then
                UserIsValid = False
                MessageBox.Show("Email already in use")
            End If
        Next
    End Sub

    Private Sub SignUpButton_Click(sender As Object, e As EventArgs) Handles SignUpButton.Click
        'Making the conditions for the username
        If Usernametxt.Text = "" Then 'Username being empty
            MessageBox.Show("Please enter a username")
            UserIsValid = False
        ElseIf Usernametxt.Text = "Guest" Or Usernametxt.Text = "AI" Then
            MessageBox.Show("Username is not available to use")
            UserIsValid = False
        ElseIf Len(Usernametxt.Text) <= 25 And Len(Usernametxt.Text) >= 2 Then 'Username to be checked against DB
            UserIsValid = True
        Else
            MessageBox.Show("Username is invalid. Please make it between 2 and 25 characters")
            UserIsValid = False
        End If

        'Making the conditions for the password
        If UserIsValid = True Then
            If Passwordtxt.Text = "" Then
                MessageBox.Show("Please enter a password")
                UserIsValid = False
            ElseIf ConfirmPasswordtxt.Text = "" Then
                MessageBox.Show("Please confirm your password")
                UserIsValid = False
            ElseIf Len(Passwordtxt.Text) < 5 Then
                MessageBox.Show("Password is too short. Please make it between 5 and 30 characters")
                UserIsValid = False
            ElseIf Len(Passwordtxt.Text) > 30 Then
                MessageBox.Show("Password is too long. Please make it between 5 and 30 characters")
                UserIsValid = False
            ElseIf Passwordtxt.Text <> ConfirmPasswordtxt.Text Then
                MessageBox.Show("Passwords do not match up")
                UserIsValid = False
            ElseIf Len(Passwordtxt.Text) >= 5 And Len(Passwordtxt.Text) <= 30 And Passwordtxt.Text = ConfirmPasswordtxt.Text Then 'Password is valid
                UserIsValid = True
            End If
        End If


        'Checking availability against db
        If UserIsValid = True Then
            CheckAvailability()
        End If
        'Attempting to send email, if doesn't work the email the user entered was not vaild
        If UserIsValid = True Then
            Try

                Dim smtpserver As New SmtpClient
                Dim email As New MailMessage

                smtpserver.UseDefaultCredentials = False
                smtpserver.Credentials = New Net.NetworkCredential("15dlawrence@mgs.kent.sch.uk", "NeaChess123")

                smtpserver.Port = 587
                smtpserver.EnableSsl = True

                smtpserver.Host = "smtp-mail.outlook.com"

                email = New MailMessage
                email.From = New MailAddress("15dlawrence@mgs.kent.sch.uk")
                email.To.Add(Emailtxt.Text)
                email.Subject = "Sign up confirmation"
                email.IsBodyHtml = False
                email.Body = "Thank you for signing up to my Chess Game " & Usernametxt.Text & "!"
                smtpserver.Send(email)
                UserIsValid = True
            Catch ex As Exception
                UserIsValid = False
                MessageBox.Show("Please enter a valid email")
            End Try
        End If
        'If everything is valid then add users credentials to the database
        If UserIsValid = True Then
            'Setting database location
            Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
            'Openning connection
            Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
            Dim DBsource As String = "Data Source=" & dbfilename
            Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
            cn.Open() 'open connection

            Dim sql As String
            sql = "INSERT INTO [Table1] ([Username], [Password], [Email], [ProfilePicture], [BoardColour], [PieceType]) VALUES ('"
            sql = sql & Usernametxt.Text & "','"
            sql = sql & Passwordtxt.Text & "','"
            sql = sql & Emailtxt.Text & "','"
            sql = sql & "Default" & "','"
            sql = sql & "YellowBoard" & "','"
            sql = sql & "Set1" & "');"
            'sends SQL command to OLEBD
            Dim cmd As New OleDbCommand(sql, cn)
            'Execute SQL command that doesnt return a query
            cmd.ExecuteNonQuery()
            'close connection
            cn.Close()
            MessageBox.Show("Sign up complete!")
            'clearing text boxes
            Usernametxt.Text = ""
            Emailtxt.Text = ""
            Passwordtxt.Text = ""
            ConfirmPasswordtxt.Text = ""


            If MultiplayerForm.Player1AlreadySignedIn = True Then
                MultiplayerForm.Show()
                MainMenu.Enabled = True
                Me.Close()
            Else
                LoginForm.Show()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub IcloudButton_Click(sender As Object, e As EventArgs) Handles IcloudButton.Click
        Emailtxt.AppendText("@icloud.com")
    End Sub

    Private Sub HotmailButton_Click(sender As Object, e As EventArgs) Handles HotmailButton.Click
        Emailtxt.AppendText("@hotmail.com")
    End Sub

    Private Sub MGSButton_Click(sender As Object, e As EventArgs) Handles MGSButton.Click
        Emailtxt.AppendText("@mgs.kent.sch.uk")
    End Sub

    Private Sub GmailButton_Click(sender As Object, e As EventArgs) Handles GmailButton.Click
        Emailtxt.AppendText("@gmail.com")
    End Sub

    Private Sub YahooButton_Click(sender As Object, e As EventArgs) Handles YahooButton.Click
        Emailtxt.AppendText("@yahoo.com")
    End Sub

    Private Sub SignUpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Setting text box input
        Me.Passwordtxt.PasswordChar = "*"
        Me.ConfirmPasswordtxt.PasswordChar = "*"
        Me.AcceptButton = SignUpButton
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

    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        If MultiplayerForm.Player1AlreadySignedIn = True Then
            MultiplayerForm.Show()
            MainMenu.Enabled = True
            Me.Close()
        Else
            LoginForm.Show()
            Me.Close()
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


End Class