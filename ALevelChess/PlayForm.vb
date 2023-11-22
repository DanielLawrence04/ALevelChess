Public Class PlayForm
    Private currentform As Form

    Private Sub SinglePlayerButton_Click(sender As Object, e As EventArgs) Handles SinglePlayerButton.Click
        OpenSinglePlayerForm(SingleplayerForm)
    End Sub

    Private Sub MultiplayerButton_Click(sender As Object, e As EventArgs) Handles MultiplayerButton.Click
        OpenMultiplayerForm(MultiplayerForm)
    End Sub

    Private Sub OpenSinglePlayerForm(currentform As Form)
        If currentform IsNot Nothing Then
            currentform.Close()
            'Change size back to normal
            Size = New Drawing.Size(1103, 613)
        End If
        currentform = SingleplayerForm
        currentform.Dock = DockStyle.Fill
        currentform.TopLevel = False
        MainMenu.MainPanel.Controls.Add(currentform)
        MainMenu.MainPanel.Tag = currentform
        currentform.BringToFront()
        'Recentre screen
        Me.CenterToScreen()
        currentform.Show()
    End Sub

    Private Sub OpenMultiplayerForm(currentform As Form)
        If currentform IsNot Nothing Then
            currentform.Close()
            'Change size back to normal
            Size = New Drawing.Size(1103, 613)
        End If
        currentform = MultiplayerForm
        currentform.Dock = DockStyle.Fill
        currentform.TopLevel = False
        MainMenu.MainPanel.Controls.Add(currentform)
        MainMenu.MainPanel.Tag = currentform
        currentform.BringToFront()
        'Recentre screen
        Me.CenterToScreen()
        currentform.Show()
    End Sub


End Class