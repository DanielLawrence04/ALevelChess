Imports System.Data.OleDb
Imports System.Data
Imports System.Net.Mail
Public Class LoginForm
    Dim LoginValid As Boolean = True 'Variable for knowing if User Credentials match up
    Public Player1Username As String
    Public Player1ID As Integer
    Private Sub SignUpLink_Changed(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles SignUpLink.LinkClicked
        'Clear Username and Password text box
        Usernametxt.Text = ""
        Passwordtxt.Text = ""
        'Show sign up form
        SignUpForm.Show()
        'Have to hide the form cannot close it as it is the start up form, otherwise program will stop
        Me.Hide()

    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        'Setting database location
        Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
        'Openning connection
        Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
        Dim DBsource As String = "Data Source=" & dbfilename

        Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
        Dim da As OleDbDataAdapter 'adapter
        Dim ds As New DataSet 'set used with adapter
        Dim sql As String
        sql = "SELECT * FROM [Table1]" 'SQL Statement
        Dim cmd As New OleDbCommand(sql, cn)
        da = New OleDbDataAdapter(sql, cn)
        cn.Open() 'Open connection
        da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
        Dim count As Integer


        For count = 0 To ds.Tables(0).Rows.Count - 1 'For loop for amount of users in table, (-1) as starts from 0
            If Usernametxt.Text = ds.Tables(0).Rows(count).Item(1) And Passwordtxt.Text = ds.Tables(0).Rows(count).Item(2) Then
                LoginValid = True
                'Storing username for player 1
                Player1Username = ds.Tables(0).Rows(count).Item(1)
                Player1ID = ds.Tables(0).Rows(count).Item(0)
                'If login valid exit loop
                Exit For
            ElseIf Usernametxt.Text = ds.Tables(0).Rows(count).Item(3) And Passwordtxt.Text = ds.Tables(0).Rows(count).Item(2) Then
                LoginValid = True
                'Storing username for player 1
                Player1Username = ds.Tables(0).Rows(count).Item(1)
                Player1ID = ds.Tables(0).Rows(count).Item(0)
                'If login valid exit loop
                Exit For
            Else
                LoginValid = False
            End If
        Next
        cn.Close() 'Close connection

        'Displaying logged in or not
        If LoginValid = True Then
            MessageBox.Show("Welcome " & Player1Username)
            'Clearing text boxes
            Usernametxt.Text = ""
            Passwordtxt.Text = ""
            MainMenu.Show() 'open main menu form
            Me.Hide() 'hide login form
        Else
            MessageBox.Show("Incorrect details, please try again.")
            Passwordtxt.Text = ""
        End If


    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Setting text box input
        Me.Passwordtxt.PasswordChar = "*"
        Me.AcceptButton = LoginButton
    End Sub

    Private Sub ShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPassword.CheckedChanged

        If Me.ShowPassword.Checked = True Then
            Me.Passwordtxt.PasswordChar = "" 'If user ticks the show password box, show password
        Else
            Me.Passwordtxt.PasswordChar = "*" 'If box is unticked turn password into *
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

    Dim Message, Title, MyValue, MyResetCode
    Dim number(4) As Integer
    Private Sub ForgottenPasswordLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ForgottenPasswordLink.LinkClicked
        Message = "Enter your email address you would like to reset your password for"    ' Set prompt.
        Title = "Forgotton Password"    ' Set title.
        ' Display message, title, and default value.
        MyValue = InputBox(Message, Title)
        'Setting database location
        Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
        'Openning connection
        Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
        Dim DBsource As String = "Data Source=" & dbfilename

        Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
        Dim da As OleDbDataAdapter 'adapter
        Dim ds As New DataSet 'set used with adapter
        Dim sql As String
        sql = "SELECT [Email], [ID] FROM [Table1]" 'SQL Statement
        Dim cmd As New OleDbCommand(sql, cn)
        da = New OleDbDataAdapter(sql, cn)
        cn.Open() 'Open connection
        da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
        Dim count As Integer
        Dim attemptscount As Integer = 3

        For count = 0 To ds.Tables(0).Rows.Count - 1 'For loop for amount of users in table, (-1) as starts from 0
            If MyValue = ds.Tables(0).Rows(count).Item(0) Then 'For player 1 stats
                SendCode()
                Player1ID = ds.Tables(0).Rows(count).Item(1)
                Do
                    Message = "Enter your 4-digit validation code that has been emailed to you. " & attemptscount & " attempts remaining."    ' Set prompt.
                    Title = "Forgotten Password"    ' Set title.
                    ' Display message, title, and default value.
                    MyResetCode = InputBox(Message, Title)
                    If MyResetCode = number(1) & number(2) & number(3) & number(4) Then
                        ForgottenPasswordForm.Show()
                        Exit Sub
                    Else
                        attemptscount -= 1
                    End If
                Loop Until attemptscount = 0
                MessageBox.Show("Ran out of attemps")
                Exit Sub
            End If
        Next
        cn.Close()
        MessageBox.Show("Email not found")

    End Sub

    Private Sub SendCode()
        Dim rnd As New Random
        'Produce 4 random numbers between 0 and 9
        number(1) = rnd.Next(0, 10)
        number(2) = rnd.Next(0, 10)
        number(3) = rnd.Next(0, 10)
        number(4) = rnd.Next(0, 10)
        Dim smtpserver As New SmtpClient
        Dim email As New MailMessage
        smtpserver.UseDefaultCredentials = False
        'Email being sent from
        smtpserver.Credentials = New Net.NetworkCredential("15dlawrence@mgs.kent.sch.uk", "NeaChess123")
        smtpserver.Port = 587
        smtpserver.EnableSsl = True
        smtpserver.Host = "smtp-mail.outlook.com"
        email = New MailMessage
        email.From = New MailAddress("15dlawrence@mgs.kent.sch.uk")
        'Email being sent too...
        email.To.Add(MyValue)
        'Email Subject
        email.Subject = "Reset Password"
        email.IsBodyHtml = False
        'Sending message
        email.Body = "Your 4 digit reset code is : " & number(1) & number(2) & number(3) & number(4)
        smtpserver.Send(email)
    End Sub
End Class
