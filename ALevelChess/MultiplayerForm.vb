Imports System.Data.OleDb
Imports System.Data
Public Class MultiplayerForm
    Private currentform As Form
    Dim LoginValid As Boolean = True 'Variable for knowing if User Credentials match up
    Public Player2Username As String
    Public Player2ID As Integer
    Public Player1AlreadySignedIn As Boolean = False 'Variable for if a user signs up on this page, after they will return to this form
    Private Sub MultiplayerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Loading in logged in players name
        User1Label.Text = LoginForm.Player1Username
        'Setting text box input
        Me.Passwordtxt.PasswordChar = "*"
    End Sub

    Private Sub GuestButton_Click(sender As Object, e As EventArgs) Handles GuestButton.Click
        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult
        'displaying messagebox
        result = MessageBox.Show("Are you sure you want to continue as a Guest?", "Guest conformation", button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.Yes Then
            'User 2 is guest
            Player2Username = "Guest"
            User2Label.Text = Player2Username
            'Allow them to play by adding play button
            PlayButton.Visible = True
            'Hiding all the login components
            LoginButton.Visible = False
            GuestButton.Visible = False
            Label5.Visible = False
            Label4.Visible = False
            Label3.Visible = False
            SignUpLink.Visible = False
            Usernametxt.Visible = False
            Passwordtxt.Visible = False
            ShowPassword.Visible = False
        End If
    End Sub

    Private Sub ShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPassword.CheckedChanged
        If Me.ShowPassword.Checked = True Then
            Me.Passwordtxt.PasswordChar = "" 'If user ticks the show password box, show password
        Else
            Me.Passwordtxt.PasswordChar = "*" 'If box is unticked turn password into *
        End If
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
        sql = "SELECT [Username],[Password], [Email], [ID] FROM [Table1]" 'SQL Statement
        Dim cmd As New OleDbCommand(sql, cn)
        da = New OleDbDataAdapter(sql, cn)
        cn.Open() 'Open connection
        da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
        Dim count As Integer


        For count = 0 To ds.Tables(0).Rows.Count - 1 'For loop for amount of users in table, (-1) as starts from 0
            If Usernametxt.Text = ds.Tables(0).Rows(count).Item(0) And Passwordtxt.Text = ds.Tables(0).Rows(count).Item(1) Then
                'Storing username for player 2
                Player2Username = ds.Tables(0).Rows(count).Item(0)
                Player2ID = ds.Tables(0).Rows(count).Item(3)

                If Player2Username = LoginForm.Player1Username Then 'If user already signed in log in is not valid
                    LoginValid = False
                    MessageBox.Show("Error - User already signed in")
                Else
                    LoginValid = True
                End If
                'If login valid exit loop
                Exit For
            ElseIf Usernametxt.Text = ds.Tables(0).Rows(count).Item(2) And Passwordtxt.Text = ds.Tables(0).Rows(count).Item(1) Then
                'Storing username for player 2
                Player2Username = ds.Tables(0).Rows(count).Item(0)
                If Player2Username = LoginForm.Player1Username Then 'If user already signed in log in is not valid
                    LoginValid = False
                    MessageBox.Show("Error - User already signed in")
                Else
                    LoginValid = True
                End If
                'If login vaid exit loop
                Exit For
            Else
                LoginValid = False
            End If
        Next
        cn.Close() 'Close connection

        'Displaying logged in or not
        If LoginValid = True Then
            MessageBox.Show("Welcome " & Player2Username)
            User2Label.Text = Player2Username
            'Allow them to play by adding play button
            PlayButton.Visible = True
            'Clearing text boxes
            Usernametxt.Text = ""
            Passwordtxt.Text = ""
            'Hiding all the login components
            LoginButton.Visible = False
            GuestButton.Visible = False
            Label5.Visible = False
            Label4.Visible = False
            Label3.Visible = False
            SignUpLink.Visible = False
            Usernametxt.Visible = False
            Passwordtxt.Visible = False
            ShowPassword.Visible = False
        Else
            MessageBox.Show("Incorrect details, please try again.")
            Passwordtxt.Text = ""
        End If
    End Sub

    Private Sub SignUpLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles SignUpLink.LinkClicked
        'Set variable as true so after user signs up they return to this form
        Player1AlreadySignedIn = True
        'Show sign up form
        SignUpForm.Show()
        'Disable Main Menu
        MainMenu.Enabled = False
        'Hide current form
        Me.Hide()
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        GameForm1.gameistwoplayer = True
        'Open game form
        OpenGameForm(GameForm1)

    End Sub

    Private Sub OpenGameForm(currentform As Form)
        If currentform IsNot Nothing Then
            'Hide not close form, to allow form to give the difficulty level to the gameform
            currentform.Hide()
        End If
        currentform = GameForm1
        currentform.Dock = DockStyle.Fill
        currentform.TopLevel = False
        MainMenu.MainPanel.Controls.Add(currentform)
        MainMenu.MainPanel.Tag = currentform
        currentform.BringToFront()
        'Change size to be able to fit form in
        MainMenu.Size = New Drawing.Size(1320, 870)
        'Recentre screen
        MainMenu.CentresScreen()
        currentform.Show()
    End Sub
End Class