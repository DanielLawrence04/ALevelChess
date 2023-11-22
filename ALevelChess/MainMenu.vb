Imports System.Data.OleDb
Imports System.Data

Public Class MainMenu
    Private currentform As Form

    Private Sub MainMenuTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Attatching Tool Tips
        HoverTool.SetToolTip(ExitButton, "Close")
        'Word document for rules
        'Set Default selection
        SelectedHomeTab.Show()
        'Load in user's username
        UserLabel.Text = LoginForm.Player1Username
        'Load in user's profile picture
        'Setting database location
        Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
        'Openning connection
        Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
        Dim DBsource As String = "Data Source=" & dbfilename

        Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
        Dim da As OleDbDataAdapter 'adapter
        Dim ds As New DataSet 'set used with adapter
        Dim sql As String
        sql = "SELECT [Username],[ProfilePicture] FROM [Table1]" 'SQL Statement
        Dim cmd As New OleDbCommand(sql, cn)
        da = New OleDbDataAdapter(sql, cn)
        cn.Open() 'Open connection
        da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
        Dim count As Integer
        For count = 0 To ds.Tables(0).Rows.Count - 1 'For loop for amount of users in table, (-1) as starts from 0
            If LoginForm.Player1Username = ds.Tables(0).Rows(count).Item(0) Then 'For player 1 profile picture (for a user that has signed in)
                Select Case (ds.Tables(0).Rows(count).Item(1))
                    Case "Default"
                        ProfilePicture.Image = My.Resources.DefaultSkin
                    Case "Skin1"
                        ProfilePicture.Image = My.Resources.Skin1
                    Case "Skin2"
                        ProfilePicture.Image = My.Resources.Skin2
                    Case "Skin3"
                        ProfilePicture.Image = My.Resources.Skin3
                    Case "Skin4"
                        ProfilePicture.Image = My.Resources.Skin4
                    Case "Skin5"
                        ProfilePicture.Image = My.Resources.Skin5
                    Case "Skin6"
                        ProfilePicture.Image = My.Resources.Skin6
                    Case "Skin7"
                        ProfilePicture.Image = My.Resources.Skin7
                    Case "Locked1"
                        ProfilePicture.Image = My.Resources.Locked1
                    Case "Locked2"
                        ProfilePicture.Image = My.Resources.Locked2
                    Case "Locked3"
                        ProfilePicture.Image = My.Resources.Locked3
                    Case "Locked4"
                        ProfilePicture.Image = My.Resources.Locked4
                    Case "Locked5"
                        ProfilePicture.Image = My.Resources.Locked5
                    Case "Locked6"
                        ProfilePicture.Image = My.Resources.Locked6
                    Case "Locked7"
                        ProfilePicture.Image = My.Resources.Locked7
                    Case "Locked8"
                        ProfilePicture.Image = My.Resources.Locked8
                End Select
            End If
        Next
        cn.Close() 'Close connection
        'opening home form
        OpenHomeForm(HomeForm)
        'enable timer
        Timer1.Enabled = True
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult
        'displaying messagebox
        result = MessageBox.Show("Are you sure you want close the program?", "Exit Program", button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.Yes Then
            'attempting to quit word document
            Try
                If RulesForm.wordapp IsNot Nothing Then
                    RulesForm.wordapp.Quit()
                End If
            Catch ex As Exception
            End Try
            'end program
            End
        End If
    End Sub

    Private Sub HomeButton_Click(sender As Object, e As EventArgs) Handles HomeButton.Click
        'Show selection
        SelectedHomeTab.Show()
        'Hide selections
        SelectedPlayTab.Hide()
        SelectedCustomiseTab.Hide()
        SelectedLeaderBoardTab.Hide()
        SelectedReplaysTab.Hide()
        SelectedRulesTab.Hide()
        SelectedSettingsTab.Hide()
        SelectedSignOutTab.Hide()
        'Open form
        OpenHomeForm(HomeForm)
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        'Show selection
        SelectedPlayTab.Show()
        'Hide selections
        SelectedHomeTab.Hide()
        SelectedCustomiseTab.Hide()
        SelectedLeaderBoardTab.Hide()
        SelectedReplaysTab.Hide()
        SelectedRulesTab.Hide()
        SelectedSettingsTab.Hide()
        SelectedSignOutTab.Hide()
        'Open form
        OpenPlayForm(PlayForm)
        'Close gameform 
        GameForm1.Close()
    End Sub

    Private Sub CustomiseButton_Click(sender As Object, e As EventArgs) Handles CustomiseButton.Click
        'Show selection
        SelectedCustomiseTab.Show()
        'Hide selections
        SelectedHomeTab.Hide()
        SelectedPlayTab.Hide()
        SelectedLeaderBoardTab.Hide()
        SelectedReplaysTab.Hide()
        SelectedRulesTab.Hide()
        SelectedSettingsTab.Hide()
        SelectedSignOutTab.Hide()
        'Open form
        OpenCustomisationForm(CustomisationForm)
    End Sub

    Private Sub LeaderboardButton_Click(sender As Object, e As EventArgs) Handles LeaderboardButton.Click
        'Show selection
        SelectedLeaderBoardTab.Show()
        'Hide selections
        SelectedHomeTab.Hide()
        SelectedCustomiseTab.Hide()
        SelectedPlayTab.Hide()
        SelectedReplaysTab.Hide()
        SelectedRulesTab.Hide()
        SelectedSettingsTab.Hide()
        SelectedSignOutTab.Hide()
        'Open form
        OpenLeaderboardForm(LeaderboardForm)
    End Sub

    Private Sub ReplaysButton_Click(sender As Object, e As EventArgs) Handles ReplaysButton.Click
        'Show selection
        SelectedReplaysTab.Show()
        'Hide selections
        SelectedHomeTab.Hide()
        SelectedCustomiseTab.Hide()
        SelectedLeaderBoardTab.Hide()
        SelectedPlayTab.Hide()
        SelectedRulesTab.Hide()
        SelectedSettingsTab.Hide()
        SelectedSignOutTab.Hide()
        'Open form
        OpenReplayForm(ReplayForm)
    End Sub

    Private Sub RulesButton_Click(sender As Object, e As EventArgs) Handles RulesButton.Click
        'Show selection
        SelectedRulesTab.Show()
        'Hide selections
        SelectedHomeTab.Hide()
        SelectedCustomiseTab.Hide()
        SelectedLeaderBoardTab.Hide()
        SelectedReplaysTab.Hide()
        SelectedPlayTab.Hide()
        SelectedSettingsTab.Hide()
        SelectedSignOutTab.Hide()
        'Open form
        OpenRulesForm(RulesForm)
    End Sub

    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        'Show selection
        SelectedSettingsTab.Show()
        'Hide selections
        SelectedHomeTab.Hide()
        SelectedCustomiseTab.Hide()
        SelectedLeaderBoardTab.Hide()
        SelectedReplaysTab.Hide()
        SelectedRulesTab.Hide()
        SelectedPlayTab.Hide()
        SelectedSignOutTab.Hide()
        'open form
        OpenSettingsForm(SettingsForm)
    End Sub

    Private Sub SignOutButton_Click(sender As Object, e As EventArgs) Handles SignOutButton.Click
        'Show selection
        SelectedSignOutTab.Show()
        'Hide selections
        SelectedHomeTab.Hide()
        SelectedCustomiseTab.Hide()
        SelectedLeaderBoardTab.Hide()
        SelectedReplaysTab.Hide()
        SelectedRulesTab.Hide()
        SelectedPlayTab.Hide()
        SelectedSettingsTab.Hide()

        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult
        'displaying messagebox
        result = MessageBox.Show("Are you sure you want to sign out?", "Sign out", button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.Yes Then
            'Show Login form
            LoginForm.Show()
            'Close current form
            Me.Close()
        End If

    End Sub
    Private Sub OpenHomeForm(currentform As Form)
        If currentform IsNot Nothing Then
            currentform.Close()
            'Change size back to normal
            Size = New Drawing.Size(1103, 613)
        End If
        currentform = HomeForm
        currentform.Dock = DockStyle.Fill
        currentform.TopLevel = False
        MainPanel.Controls.Add(currentform)
        MainPanel.Tag = currentform
        currentform.BringToFront()
        'Recentre screen
        Me.CenterToScreen()
        currentform.Show()
    End Sub

    Private Sub OpenPlayForm(currentform As Form)
        If currentform IsNot Nothing Then
            currentform.Close()
            'Change size back to normal
            Size = New Drawing.Size(1103, 613)
        End If
        currentform = PlayForm
        currentform.Dock = DockStyle.Fill
        currentform.TopLevel = False
        MainPanel.Controls.Add(currentform)
        MainPanel.Tag = currentform
        currentform.BringToFront()
        'Recentre screen
        Me.CenterToScreen()
        currentform.Show()
    End Sub

    Private Sub OpenCustomisationForm(currentform As Form)
        If currentform IsNot Nothing Then
            currentform.Close()
            'Change size back to normal
            Size = New Drawing.Size(1103, 613)
        End If
        currentform = CustomisationForm
        currentform.Dock = DockStyle.Fill
        currentform.TopLevel = False
        MainPanel.Controls.Add(currentform)
        MainPanel.Tag = currentform
        currentform.BringToFront()
        'Recentre screen
        Me.CenterToScreen()
        currentform.Show()
    End Sub

    Private Sub OpenReplayForm(currentform As Form)
        If currentform IsNot Nothing Then
            currentform.Close()
        End If
        currentform = ReplayForm
        currentform.Dock = DockStyle.Fill
        currentform.TopLevel = False
        MainPanel.Controls.Add(currentform)
        MainPanel.Tag = currentform
        currentform.BringToFront()
        'Change size to be able to fit form in
        Size = New Drawing.Size(1103, 830)
        'Recentre screen
        Me.CenterToScreen()
        currentform.Show()
    End Sub

    Private Sub OpenLeaderboardForm(currentform As Form)

        If currentform IsNot Nothing Then
            currentform.Close()
            'Change size back to normal
            Size = New Drawing.Size(1103, 613)
        End If
        currentform = LeaderboardForm
        currentform.Dock = DockStyle.Fill
        currentform.TopLevel = False
        MainPanel.Controls.Add(currentform)
        MainPanel.Tag = currentform
        currentform.BringToFront()
        'Change size to be able to fit form in
        'Recentre screen
        Me.CenterToScreen()
        currentform.Show()
    End Sub

    Private Sub OpenRulesForm(currentform As Form)
        If currentform IsNot Nothing Then
            currentform.Close()
            'Change size back to normal
            Size = New Drawing.Size(1103, 613)
        End If
        currentform = RulesForm
        currentform.Dock = DockStyle.Fill
        currentform.TopLevel = False
        MainPanel.Controls.Add(currentform)
        MainPanel.Tag = currentform
        currentform.BringToFront()
        'Change size to be able to fit form in
        'Recentre screen
        Me.CenterToScreen()
        currentform.Show()
    End Sub

    Private Sub OpenSettingsForm(currentform As Form)
        If currentform IsNot Nothing Then
            currentform.Close()
            'Change size back to normal
            Size = New Drawing.Size(1103, 613)
        End If
        currentform = SettingsForm
        currentform.Dock = DockStyle.Fill
        currentform.TopLevel = False
        MainPanel.Controls.Add(currentform)
        MainPanel.Tag = currentform
        currentform.BringToFront()
        'Change size to be able to fit form in
        'Recentre screen
        Me.CenterToScreen()
        currentform.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Datelabel.Text = Date.Now.ToString("dd MMM yyyy  hh:mm:ss")
    End Sub

    Public Sub CentresScreen()
        Me.CenterToScreen()
    End Sub
End Class