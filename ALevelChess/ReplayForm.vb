Imports System.Data.OleDb
Imports System.Data
Imports System.Threading
Public Class ReplayForm
    Dim pb(7, 7) As PictureBox
    Dim board(7, 7) As Integer
    Dim Set1 As Boolean = False
    Dim Set2 As Boolean = False
    Dim Set3 As Boolean = False
    Dim PreMove As String
    Dim PostMove As String
    Dim gamelength As Integer
    Dim ReplayNumber As Integer = 0
    Private Sub ReplayForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Creating picture boxes as an array
        pb = New PictureBox(7, 7) {{Me.p00, Me.p01, Me.p02, Me.p03, Me.p04, Me.p05, Me.p06, Me.p07},
            {Me.p10, Me.p11, Me.p12, Me.p13, Me.p14, Me.p15, Me.p16, Me.p17},
            {Me.p20, Me.p21, Me.p22, Me.p23, Me.p24, Me.p25, Me.p26, Me.p27},
            {Me.p30, Me.p31, Me.p32, Me.p33, Me.p34, Me.p35, Me.p36, Me.p37},
            {Me.p40, Me.p41, Me.p42, Me.p43, Me.p44, Me.p45, Me.p46, Me.p47},
            {Me.p50, Me.p51, Me.p52, Me.p53, Me.p54, Me.p55, Me.p56, Me.p57},
            {Me.p60, Me.p61, Me.p62, Me.p63, Me.p64, Me.p65, Me.p66, Me.p67},
            {Me.p70, Me.p71, Me.p72, Me.p73, Me.p74, Me.p75, Me.p76, Me.p77}}

        board = {{-5, -4, -3, -2, -1, -3, -4, -5},
                 {-6, -6, -6, -6, -6, -6, -6, -6},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {6, 6, 6, 6, 6, 6, 6, 6},
                 {5, 4, 3, 2, 1, 3, 4, 5}}

        LoadReplay()
        showpiece()
    End Sub

    Private Sub showpiece()
        'Loading pieces onto board for user
        For i As Integer = 0 To 7
            If board(7, i) = -6 Then
                board(7, i) = -2
            End If
        Next

        If Set1 = True Then
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    Select Case board(i, j)
                        Case 1
                            pb(i, j).Image = My.Resources.Set1KingW
                        Case 2
                            pb(i, j).Image = My.Resources.Set1QueenW
                        Case 3
                            pb(i, j).Image = My.Resources.Set1BishopW
                        Case 4
                            pb(i, j).Image = My.Resources.Set1KnightW
                        Case 5
                            pb(i, j).Image = My.Resources.Set1RookW
                        Case 6
                            pb(i, j).Image = My.Resources.Set1PawnW
                        Case -1
                            pb(i, j).Image = My.Resources.Set1KingB
                        Case -2
                            pb(i, j).Image = My.Resources.Set1QueenB
                        Case -3
                            pb(i, j).Image = My.Resources.Set1BishopB
                        Case -4
                            pb(i, j).Image = My.Resources.Set1KnightB
                        Case -5
                            pb(i, j).Image = My.Resources.Set1RookB
                        Case -6
                            pb(i, j).Image = My.Resources.Set1PawnB
                        Case Else
                            pb(i, j).Image = Nothing
                    End Select
                Next
            Next
        ElseIf Set2 = True Then
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    Select Case board(i, j)
                        Case 1
                            pb(i, j).Image = My.Resources.Set2KingW
                        Case 2
                            pb(i, j).Image = My.Resources.Set2QueenW
                        Case 3
                            pb(i, j).Image = My.Resources.Set2BishopW
                        Case 4
                            pb(i, j).Image = My.Resources.Set2KnightW
                        Case 5
                            pb(i, j).Image = My.Resources.Set2RookW
                        Case 6
                            pb(i, j).Image = My.Resources.Set2PawnW
                        Case -1
                            pb(i, j).Image = My.Resources.Set2KingB
                        Case -2
                            pb(i, j).Image = My.Resources.Set2QueenB
                        Case -3
                            pb(i, j).Image = My.Resources.Set2BishopB
                        Case -4
                            pb(i, j).Image = My.Resources.Set2KnightB
                        Case -5
                            pb(i, j).Image = My.Resources.Set2RookB
                        Case -6
                            pb(i, j).Image = My.Resources.Set2PawnB
                        Case Else
                            pb(i, j).Image = Nothing
                    End Select
                Next
            Next
        ElseIf Set3 = True Then
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    Select Case board(i, j)
                        Case 1
                            pb(i, j).Image = My.Resources.Set3KingW
                        Case 2
                            pb(i, j).Image = My.Resources.Set3QueenW
                        Case 3
                            pb(i, j).Image = My.Resources.Set3BishopW
                        Case 4
                            pb(i, j).Image = My.Resources.Set3KnightW
                        Case 5
                            pb(i, j).Image = My.Resources.Set3RookW
                        Case 6
                            pb(i, j).Image = My.Resources.Set3PawnW
                        Case -1
                            pb(i, j).Image = My.Resources.Set3KingB
                        Case -2
                            pb(i, j).Image = My.Resources.Set3QueenB
                        Case -3
                            pb(i, j).Image = My.Resources.Set3BishopB
                        Case -4
                            pb(i, j).Image = My.Resources.Set3KnightB
                        Case -5
                            pb(i, j).Image = My.Resources.Set3RookB
                        Case -6
                            pb(i, j).Image = My.Resources.Set3PawnB
                        Case Else
                            pb(i, j).Image = Nothing
                    End Select
                Next
            Next
        End If
    End Sub

    Private Sub redoback()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                pb(i, j).BackgroundImage = Nothing
            Next
        Next
    End Sub

    Private Sub LoadReplay()
        'Loading User 1 profile details
        'Setting database location
        Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
        'Openning connection
        Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
        Dim DBsource As String = "Data Source=" & dbfilename

        Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
        Dim da As OleDbDataAdapter 'adapter
        Dim ds As New DataSet 'set used with adapter
        Dim sql As String
        sql = "SELECT [Username],[BoardColour],[PieceType], [PreMove1], [Move1], [PreMove2], [Move2], [PreMove3], [Move3], [PreMove4], [Move4], [PreMove5], [Move5] FROM [Table1]" 'SQL Statement
        Dim cmd As New OleDbCommand(sql, cn)
        da = New OleDbDataAdapter(sql, cn)
        cn.Open() 'Open connection
        da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
        Dim count As Integer


        For count = 0 To ds.Tables(0).Rows.Count - 1 'For loop for amount of users in table, (-1) as starts from 0
            If LoginForm.Player1Username = ds.Tables(0).Rows(count).Item(0) Then 'For player 1 profile picture (for a user that has signed in)
                Select Case (ds.Tables(0).Rows(count).Item(1))
                    Case "YellowBoard"
                        Me.BackgroundImage = My.Resources.YellowBoard
                    Case "GreenBoard"
                        Me.BackgroundImage = My.Resources.GreenBoard
                    Case "PinkBoard"
                        Me.BackgroundImage = My.Resources.PinkBoard
                    Case "RedBoard"
                        Me.BackgroundImage = My.Resources.RedBoard
                    Case "BlueBoard"
                        Me.BackgroundImage = My.Resources.BlueBoard
                End Select
                Select Case (ds.Tables(0).Rows(count).Item(2))
                    Case "Set1"
                        Set1 = True
                    Case "Set2"
                        Set2 = True
                    Case "Set3"
                        Set3 = True
                End Select
                Try
                    If ReplayNumber = 1 Then
                        PreMove = ds.Tables(0).Rows(count).Item(3)
                        PostMove = ds.Tables(0).Rows(count).Item(4)
                    ElseIf ReplayNumber = 2 Then
                        PreMove = ds.Tables(0).Rows(count).Item(5)
                        PostMove = ds.Tables(0).Rows(count).Item(6)
                    ElseIf ReplayNumber = 3 Then
                        PreMove = ds.Tables(0).Rows(count).Item(7)
                        PostMove = ds.Tables(0).Rows(count).Item(8)
                    ElseIf ReplayNumber = 4 Then
                        PreMove = ds.Tables(0).Rows(count).Item(9)
                        PostMove = ds.Tables(0).Rows(count).Item(10)
                    ElseIf ReplayNumber = 5 Then
                        PreMove = ds.Tables(0).Rows(count).Item(11)
                        PostMove = ds.Tables(0).Rows(count).Item(12)
                    End If
                    gamelength = Len(PreMove)
                Catch ex As Exception
                    PreMove = ""
                    PostMove = ""
                End Try
            End If
        Next
        cn.Close() 'Close connection
    End Sub

    Dim CurrentPos As String = "Nothing"
    Dim NextPos As String
    Dim x As Integer = 0
    Dim count As Integer = 1
    Dim xposition(1) As Integer
    Dim yposition(1) As Integer
    Dim Premovepiecevalue(1000) As Integer
    Dim Postmovepiecevalue As Integer
    Private Sub MovePiece()
        RewindButton.Show()

        x = x + 1
        If x <= 0 Then
            x = 1
        End If
        CurrentPos = Mid(PreMove, x, 1)
        NextPos = Mid(PostMove, x, 1)
        Select Case CurrentPos
            Case "A"
                yposition(0) = 0
            Case "B"
                yposition(0) = 1
            Case "C"
                yposition(0) = 2
            Case "D"
                yposition(0) = 3
            Case "E"
                yposition(0) = 4
            Case "F"
                yposition(0) = 5
            Case "G"
                yposition(0) = 6
            Case "H"
                yposition(0) = 7
        End Select
        Select Case NextPos
            Case "A"
                yposition(1) = 0
            Case "B"
                yposition(1) = 1
            Case "C"
                yposition(1) = 2
            Case "D"
                yposition(1) = 3
            Case "E"
                yposition(1) = 4
            Case "F"
                yposition(1) = 5
            Case "G"
                yposition(1) = 6
            Case "H"
                yposition(1) = 7
        End Select

        x = x + 1

        CurrentPos = Mid(PreMove, x, 1)
        NextPos = Mid(PostMove, x, 1)

        Select Case CurrentPos
            Case "1"
                xposition(0) = 7
            Case "2"
                xposition(0) = 6
            Case "3"
                xposition(0) = 5
            Case "4"
                xposition(0) = 4
            Case "5"
                xposition(0) = 3
            Case "6"
                xposition(0) = 2
            Case "7"
                xposition(0) = 1
            Case "8"
                xposition(0) = 0
        End Select
        Select Case NextPos
            Case "1"
                xposition(1) = 7
            Case "2"
                xposition(1) = 6
            Case "3"
                xposition(1) = 5
            Case "4"
                xposition(1) = 4
            Case "5"
                xposition(1) = 3
            Case "6"
                xposition(1) = 2
            Case "7"
                xposition(1) = 1
            Case "8"
                xposition(1) = 0
        End Select

        y = x


        If board(xposition(0), yposition(0)) <> Nothing Then
            Premovepiecevalue(count) = board(xposition(1), yposition(1))
            board(xposition(1), yposition(1)) = board(xposition(0), yposition(0))
            board(xposition(0), yposition(0)) = 0
            count += 1

            RewindButton.Show()
            showpiece()
        ElseIf board(xposition(0), yposition(0)) = Nothing Then
            MovePiece()
        End If
        If x >= gamelength Then 'End of Game

            FastFowardTimer.Stop()
            AutoPlayTimer.Stop()

            PauseButton.Hide()
            PlayButton.Hide()
            FastFowardButton.Hide()

            x = gamelength - 2
            Exit Sub
        End If
    End Sub
    Private Sub MovePieceBack()

        If y <= 0 Then
            RewindButton.Hide()
            Exit Sub
        End If
        y = y - 1
        CurrentPos = Mid(PreMove, y, 1)
        NextPos = Mid(PostMove, y, 1)
        Select Case CurrentPos
            Case "A"
                yposition(0) = 0
            Case "B"
                yposition(0) = 1
            Case "C"
                yposition(0) = 2
            Case "D"
                yposition(0) = 3
            Case "E"
                yposition(0) = 4
            Case "F"
                yposition(0) = 5
            Case "G"
                yposition(0) = 6
            Case "H"
                yposition(0) = 7
        End Select
        Select Case NextPos
            Case "A"
                yposition(1) = 0
            Case "B"
                yposition(1) = 1
            Case "C"
                yposition(1) = 2
            Case "D"
                yposition(1) = 3
            Case "E"
                yposition(1) = 4
            Case "F"
                yposition(1) = 5
            Case "G"
                yposition(1) = 6
            Case "H"
                yposition(1) = 7
        End Select

        y = y + 1
        CurrentPos = Mid(PreMove, y, 1)
        NextPos = Mid(PostMove, y, 1)

        Select Case CurrentPos
            Case "1"
                xposition(0) = 7
            Case "2"
                xposition(0) = 6
            Case "3"
                xposition(0) = 5
            Case "4"
                xposition(0) = 4
            Case "5"
                xposition(0) = 3
            Case "6"
                xposition(0) = 2
            Case "7"
                xposition(0) = 1
            Case "8"
                xposition(0) = 0
        End Select
        Select Case NextPos
            Case "1"
                xposition(1) = 7
            Case "2"
                xposition(1) = 6
            Case "3"
                xposition(1) = 5
            Case "4"
                xposition(1) = 4
            Case "5"
                xposition(1) = 3
            Case "6"
                xposition(1) = 2
            Case "7"
                xposition(1) = 1
            Case "8"
                xposition(1) = 0
        End Select
        board(xposition(0), yposition(0)) = board(xposition(1), yposition(1))
        count = count - 1
        board(xposition(1), yposition(1)) = Premovepiecevalue(count)

        showpiece()
        y = y - 2
        x = y - 2
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MovePiece()
    End Sub

    Dim y As Integer
    Private Sub BackMoveButton_Click(sender As Object, e As EventArgs)
        MovePieceBack()
    End Sub

    Private Sub ReplaySelectBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReplaySelectBox.SelectedIndexChanged
        Select Case ReplaySelectBox.SelectedItem
            Case "Replay 1"
                ReplayNumber = 1
                LoadReplay()
            Case "Replay 2"
                ReplayNumber = 2
                LoadReplay()
            Case "Replay 3"
                ReplayNumber = 3
                LoadReplay()
            Case "Replay 4"
                ReplayNumber = 4
                LoadReplay()
            Case "Replay 5"
                ReplayNumber = 5
                LoadReplay()
        End Select

        If PreMove <> "" And PostMove <> "" Then
            ReplaySelectBox.Hide()
            ChangeReplayButton.Show()
            PlayButton.Show()
            FastFowardButton.Show()
            PauseButton.Show()
        Else
            MessageBox.Show("Replay not found, please try a different one")
        End If
    End Sub

    Private Sub ChangeReplayButton_Click(sender As Object, e As EventArgs) Handles ChangeReplayButton.Click
        'Hiding buttons
        ChangeReplayButton.Hide()
        PlayButton.Hide()
        FastFowardButton.Hide()
        PauseButton.Hide()
        RewindButton.Hide()
        AutoPlayTimer.Stop()
        FastFowardTimer.Stop()
        ReverseTimer.Stop()
        ReplaySelectBox.Show()
        'Make sure board is back to start
        board = {{-5, -4, -3, -2, -1, -3, -4, -5},
                 {-6, -6, -6, -6, -6, -6, -6, -6},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {6, 6, 6, 6, 6, 6, 6, 6},
                 {5, 4, 3, 2, 1, 3, 4, 5}}
        'Displaying pieces on board 
        showpiece()
        'Reset x and y
        x = 0
        y = 0
    End Sub

    Private Sub ReturnLabel_Click(sender As Object, e As EventArgs)
        'Show main menu form
        MainMenu.Show()
        'Close current form
        Me.Close()
    End Sub

    Private Sub CloseProgramLabel_Click(sender As Object, e As EventArgs)
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

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        AutoPlayTimer.Start()
        ReverseTimer.Stop()
        FastFowardTimer.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles AutoPlayTimer.Tick
        If x < gamelength Then
            MovePiece()
        ElseIf x >= gamelength Then
            AutoPlayTimer.Stop()
        End If
    End Sub

    Private Sub PauseButton_Click(sender As Object, e As EventArgs) Handles PauseButton.Click
        AutoPlayTimer.Stop()
        ReverseTimer.Stop()
        FastFowardTimer.Stop()
    End Sub

    Private Sub RewindButton_Click(sender As Object, e As EventArgs) Handles RewindButton.Click
        AutoPlayTimer.Stop()
        FastFowardTimer.Stop()
        ReverseTimer.Start()

        PauseButton.Show()
        PlayButton.Show()
        FastFowardButton.Show()
    End Sub

    Private Sub Reverse_Tick(sender As Object, e As EventArgs) Handles ReverseTimer.Tick
        If y > 0 Then
            MovePieceBack()
        ElseIf y <= 0 Then
            ReverseTimer.Stop()
            RewindButton.Hide()

        End If
    End Sub

    Private Sub FastFowardButton_Click(sender As Object, e As EventArgs) Handles FastFowardButton.Click
        AutoPlayTimer.Stop()
        ReverseTimer.Stop()
        FastFowardTimer.Start()
    End Sub

    Private Sub FastFowardTimer_Tick(sender As Object, e As EventArgs) Handles FastFowardTimer.Tick
        If x < gamelength Then
            MovePiece()
        ElseIf x >= gamelength Then
            FastFowardTimer.Stop()
        End If
    End Sub
End Class