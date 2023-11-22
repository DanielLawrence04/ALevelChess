Public Class BPawnChangeForm
    Private Sub BPawnChangeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Pausing timers
        GameForm1.P1Timer.Stop()
        GameForm1.P2Timer.Stop()
        'Displaying piece types 
        If GameForm1.Set1 = True Then
            Me.QueenBox.Image = My.Resources.Set1QueenB
            Me.RookBox.Image = My.Resources.Set1RookB
            Me.KnightBox.Image = My.Resources.Set1KnightB
            Me.BishopBox.Image = My.Resources.Set1BishopB
        ElseIf GameForm1.Set2 = True Then
            Me.QueenBox.Image = My.Resources.Set2QueenB
            Me.RookBox.Image = My.Resources.Set2RookB
            Me.KnightBox.Image = My.Resources.Set2KnightB
            Me.BishopBox.Image = My.Resources.Set2BishopB
        ElseIf GameForm1.Set3 = True Then
            Me.QueenBox.Image = My.Resources.Set3QueenB
            Me.RookBox.Image = My.Resources.Set3RookB
            Me.KnightBox.Image = My.Resources.Set3KnightB
            Me.BishopBox.Image = My.Resources.Set3BishopB
        End If
    End Sub
    Private Sub QueenButton_Click(sender As Object, e As EventArgs) Handles QueenButton.Click
        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult
        result = MessageBox.Show("Are you sure you want to choose Queen", "Queen", Button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.Yes Then
            GameForm1.bqueencount += 1
            For i As Integer = 0 To 7
                If GameForm1.ga.board(7, i) = -6 Then
                    GameForm1.ga.board(7, i) = -2
                    GameForm1.blackqueen(GameForm1.bqueencount) = New Queen(7, i, -2)
                    GameForm1.ga.show()
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite()
                End If
            Next
            'Enabling gameform and timers
            GameForm1.Enabled = True
            If GameForm1.ga.movecounter Mod 2 = 0 Then
                GameForm1.P1Timer.Start()
            Else
                GameForm1.P2Timer.Start()
            End If
            Me.Close()
        End If
    End Sub

    Private Sub RookButton_Click(sender As Object, e As EventArgs) Handles RookButton.Click
        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult
        result = MessageBox.Show("Are you sure you want to choose Rook", "Rook", Button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.Yes Then
            GameForm1.brookcount += 1
            For i As Integer = 0 To 7
                If GameForm1.ga.board(7, i) = -6 Then
                    GameForm1.ga.board(7, i) = -5
                    GameForm1.blackrook(1 + GameForm1.brookcount) = New Rook(7, i, -5)
                    GameForm1.ga.show()
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite()
                End If
            Next
            'Enabling gameform and timers
            GameForm1.Enabled = True
            If GameForm1.ga.movecounter Mod 2 = 0 Then
                GameForm1.P1Timer.Start()
            Else
                GameForm1.P2Timer.Start()
            End If
            Me.Close()
        End If
    End Sub

    Private Sub KnightButton_Click(sender As Object, e As EventArgs) Handles KnightButton.Click
        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult
        result = MessageBox.Show("Are you sure you want to choose Knight", "Knight", Button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.Yes Then
            GameForm1.bknightcount += 1
            For i As Integer = 0 To 7
                If GameForm1.ga.board(7, i) = -6 Then
                    GameForm1.ga.board(7, i) = -4
                    GameForm1.blackknight(1 + GameForm1.bknightcount) = New Knight(7, i, -4)
                    GameForm1.ga.show()
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite()
                End If
            Next
            'Enabling gameform and timers
            GameForm1.Enabled = True
            If GameForm1.ga.movecounter Mod 2 = 0 Then
                GameForm1.P1Timer.Start()
            Else
                GameForm1.P2Timer.Start()
            End If
            Me.Close()
        End If
    End Sub
    Private Sub BishopButton_Click(sender As Object, e As EventArgs) Handles BishopButton.Click
        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult
        result = MessageBox.Show("Are you sure you want to choose Bishop", "Bishop", button)
        'getting result of the messagebox

        If result = System.Windows.Forms.DialogResult.Yes Then
            GameForm1.bbishopcount += 1
            For i As Integer = 0 To 7
                If GameForm1.ga.board(7, i) = -6 Then
                    GameForm1.ga.board(7, i) = -3
                    GameForm1.blackbishop(1 + GameForm1.bbishopcount) = New Bishop(7, i, -3)
                    GameForm1.ga.show()
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite()
                End If
            Next
            'Enabling gameform and timers
            GameForm1.Enabled = True
            If GameForm1.ga.movecounter Mod 2 = 0 Then
                GameForm1.P1Timer.Start()
            Else
                GameForm1.P2Timer.Start()
            End If
            Me.Close()
        End If
    End Sub
End Class