Public Class SingleplayerForm
    Private currentform As Form

    Private Sub EasyButton_Click(sender As Object, e As EventArgs) Handles EasyButton.Click
        GameForm1.EasyMode = True
        GameForm1.gameisoneplayer = True
        'Setting player 2 name as AI
        MultiplayerForm.Player2Username = "AI"
        'Show game form
        OpenGameForm(GameForm1)
    End Sub

    Private Sub HardButton_Click(sender As Object, e As EventArgs) Handles HardButton.Click
        GameForm1.HardMode = True

        GameForm1.gameisoneplayer = True
        'Setting player 2 name as AI
        MultiplayerForm.Player2Username = "AI"
        'Show game form
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