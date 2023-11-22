Public Class WPawnChangeForm
    Private Sub WPawnChangeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Pausing timers
        GameForm1.P1Timer.Stop()
        GameForm1.P2Timer.Stop()

        If GameForm1.Set1 = True Then
            Me.QueenBox.Image = My.Resources.Set1QueenW
            Me.RookBox.Image = My.Resources.Set1RookW
            Me.KnightBox.Image = My.Resources.Set1KnightW
            Me.BishopBox.Image = My.Resources.Set1BishopW
        ElseIf GameForm1.Set2 = True Then
            Me.QueenBox.Image = My.Resources.Set2QueenW
            Me.RookBox.Image = My.Resources.Set2RookW
            Me.KnightBox.Image = My.Resources.Set2KnightW
            Me.BishopBox.Image = My.Resources.Set2BishopW
        ElseIf GameForm1.Set3 = True Then
            Me.QueenBox.Image = My.Resources.Set3QueenW
            Me.RookBox.Image = My.Resources.Set3RookW
            Me.KnightBox.Image = My.Resources.Set3KnightW
            Me.BishopBox.Image = My.Resources.Set3BishopW
        End If
    End Sub

    Private Sub QueenButton_Click(sender As Object, e As EventArgs) Handles QueenButton.Click
        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult
        result = MessageBox.Show("Are you sure you want to choose Queen", "Queen", button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.Yes Then
            GameForm1.wqueencount += 1
            For i As Integer = 0 To 7
                If GameForm1.ga.board(0, i) = 6 Then
                    GameForm1.ga.board(0, i) = 2
                    GameForm1.whitequeen(GameForm1.wqueencount) = New Queen(0, i, 2)
                    GameForm1.ga.show()

                End If
            Next
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
        result = MessageBox.Show("Are you sure you want to choose Rook", "Rook", button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.Yes Then
            GameForm1.wrookcount += 1
            For i As Integer = 0 To 7
                If GameForm1.ga.board(0, i) = 6 Then
                    GameForm1.ga.board(0, i) = 5
                    GameForm1.whiterook(1 + GameForm1.wrookcount) = New Rook(0, i, 5)
                    GameForm1.ga.show()
                End If
            Next
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
            GameForm1.wknightcount += 1
            For i As Integer = 0 To 7
                If GameForm1.ga.board(0, i) = 6 Then
                    GameForm1.ga.board(0, i) = 4
                    GameForm1.whiteknight(1 + GameForm1.wknightcount) = New Knight(0, i, 4)
                    GameForm1.ga.show()
                End If
            Next
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
        result = MessageBox.Show("Are you sure you want to choose Bishop", "Bishop", Button)
        'getting result of the messagebox

        If result = System.Windows.Forms.DialogResult.Yes Then
            GameForm1.wbishopcount += 1
            For i As Integer = 0 To 7
                If GameForm1.ga.board(0, i) = 6 Then
                    GameForm1.ga.board(0, i) = 3
                    GameForm1.whitebishop(1 + GameForm1.wbishopcount) = New Bishop(0, i, 3)
                    GameForm1.ga.show()
                End If
            Next
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