Imports System.Data.OleDb
Imports System.Data
Public Class Game
    Public board(7, 7) As Integer '8 by 8 grid like the size of the board
    Public canmove(7, 7) As Boolean '^
    Public checkforwhite(7, 7) As Boolean '^
    Public checkforblack(7, 7) As Boolean '^
    Public gameflag As Boolean = True 'gameflag being true allows game to continue, if not game is ended
    Public player As Integer = 1 'player always start of as 1
    Public blackindanger As Boolean = False
    Public whiteindanger As Boolean = False
    Public movecounter As Integer 'variable to count moves and be displayed on the game form
    Public xpositionCheck As Integer
    Public ypositionCheck As Integer
    Public recurrsionstop As Boolean = False
    Public castleincheck(1) As Boolean
    Public canwritetoboardtracker As Boolean = True
    Public stalemate As Boolean
    Public Sub New()
        'creating an array for chess board, positive pieces are white and negative pieces are black, 0 are also blanks
        board = {{-5, -4, -3, -2, -1, -3, -4, -5},
                 {-6, -6, -6, -6, -6, -6, -6, -6},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {0, 0, 0, 0, 0, 0, 0, 0},
                 {6, 6, 6, 6, 6, 6, 6, 6},
                 {5, 4, 3, 2, 1, 3, 4, 5}}
        recheckblack()
        recheckwhite()
    End Sub
    Private Sub checkwinner()
        Dim checkmate(5) As Boolean
        If AICalculating = False Then
            show() 'show images 
        End If
        If blackindanger = True Then
            gameflag = False
            checkmate(0) = True
            checkmate(1) = True
            checkmate(2) = True
            checkmate(3) = True
            checkmate(4) = True
            checkmate(5) = True
            checkforwhite(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True

            'Possible moves for the black king, if there is a move possible then checkmate = false
            GameForm1.blackking.possiblemoves()
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                    If GameForm1.blackking.flags(i, j) = True Then
                        checkmate(0) = False
                    End If
                Next
            Next

            'Possible moves for the black pawns, if there is a move possible then checkmate = false
            For k As Integer = 0 To 7
                GameForm1.blackpawn(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        If GameForm1.blackpawn(k).flags(i, j) = True Then
                            checkmate(1) = False
                        End If
                    Next
                Next
            Next

            'Possible moves for the black rook, if there is a move possible then checkmate = false
            For k As Integer = 0 To 1 + GameForm1.brookcount
                GameForm1.blackrook(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        If GameForm1.blackrook(k).flags(i, j) = True Then
                            checkmate(2) = False
                        End If
                    Next
                Next
            Next

            'Possible moves for the black bishop, if there is a move possible then checkmate = false
            For k As Integer = 0 To 1 + GameForm1.bbishopcount
                GameForm1.blackbishop(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        If GameForm1.blackbishop(k).flags(i, j) = True Then
                            checkmate(3) = False
                        End If
                    Next
                Next
            Next

            'Possible moves for the black knight, if there is a move possible then checkmate = false
            For k As Integer = 0 To 1 + GameForm1.bknightcount
                GameForm1.blackknight(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        If GameForm1.blackknight(k).flags(i, j) = True Then
                            checkmate(4) = False
                        End If
                    Next
                Next
            Next

            'Possible moves for the black queen, if there is a move possible then checkmate = false
            For k As Integer = 0 To GameForm1.bqueencount
                GameForm1.blackqueen(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        If GameForm1.blackqueen(k).flags(i, j) = True Then
                            checkmate(5) = False
                        End If
                    Next
                Next
            Next

            If checkmate(0) = True And checkmate(1) = True And checkmate(2) = True And checkmate(3) = True And checkmate(4) = True And checkmate(5) = True Then
                If AICalculating = False Then
                    'Stop game
                    gameflag = False
                    GameForm1.gamestarted = False
                    'Stop timers
                    GameForm1.P1Timer.Stop()
                    GameForm1.P2Timer.Stop()
                    'Hide buttons
                    GameForm1.P1ResignButton.Hide()
                    GameForm1.P1SettleButton.Hide()
                    GameForm1.P2ResignButton.Hide()
                    GameForm1.P2SettleButton.Hide()

                    'Display winner
                    MsgBox("Checkmate, " & GameForm1.Player1Label.Text & " is the winner!")
                    'Getting both users stats and storing them temporarily (only win and lose, as settling form has the drawn stats changed)
                    Dim Player1Wins As Integer
                    Dim Player2Loses As Integer

                    'Setting database location
                    Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
                    'Openning connection
                    Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
                    Dim DBsource As String = "Data Source=" & dbfilename

                    Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
                    Dim da As OleDbDataAdapter 'adapter
                    Dim ds As New DataSet 'set used with adapter
                    Dim sql As String
                    sql = "SELECT [Username],[Wins], [Loses] FROM [Table1]" 'SQL Statement
                    da = New OleDbDataAdapter(sql, cn)
                    cn.Open() 'Open connection
                    da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
                    Dim count As Integer


                    For count = 0 To ds.Tables(0).Rows.Count - 1 'For loop for amount of users in table, (-1) as starts from 0
                        If LoginForm.Player1Username = ds.Tables(0).Rows(count).Item(0) Then 'For player 1 stats
                            Player1Wins = ds.Tables(0).Rows(count).Item(1)
                        ElseIf MultiplayerForm.Player2Username = ds.Tables(0).Rows(count).Item(0) Then 'For player 2 stats
                            Player2Loses = ds.Tables(0).Rows(count).Item(2)
                        End If
                    Next

                    cn.Close() 'Close connection

                    'Updating the database with the new P1 user stats
                    Dim cmd As New OleDbCommand(sql, cn)
                    sql = "update [Table1]"
                    sql = sql & "SET [Wins] = '" & Player1Wins + 1 & "' "
                    sql = sql & "WHERE [ID] = " & LoginForm.Player1ID & ";"
                    cmd = New OleDbCommand(sql, cn)
                    cn.Open() 'Open connection
                    cmd.ExecuteNonQuery()
                    cn.Close() 'Close connection


                    'Updating the database with the new P2 user stats
                    sql = "update [Table1]"
                    sql = sql & "SET [Loses] = '" & Player2Loses + 1 & "' "
                    sql = sql & "WHERE [ID] = " & MultiplayerForm.Player2ID & ";"
                    cmd = New OleDbCommand(sql, cn)
                    cn.Open() 'Open connection
                    cmd.ExecuteNonQuery()
                    cn.Close() 'Close connection

                    StoreGameReplay()
                End If
            Else
                'Checkmate is not true, therefore continue game
                gameflag = True
            End If
        End If

        If gameflag = True Then
            stalemate = True
            'Possible moves for the black king, if there is a move possible then stalemate = false
            GameForm1.blackking.possiblemoves()
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    If GameForm1.blackking.flags(i, j) = True Then
                        stalemate = False
                    End If
                Next
            Next

            'Possible moves for the black pawns, if there is a move possible then stalemate = false
            For k As Integer = 0 To 7
                GameForm1.blackpawn(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If GameForm1.blackpawn(k).flags(i, j) = True Then
                            stalemate = False
                        End If
                    Next
                Next
            Next

            'Possible moves for the black rook, if there is a move possible then stalemate = false
            For k As Integer = 0 To 1 + GameForm1.brookcount
                GameForm1.blackrook(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If GameForm1.blackrook(k).flags(i, j) = True Then
                            stalemate = False
                        End If
                    Next
                Next
            Next

            'Possible moves for the black bishop, if there is a move possible then stalemate = false
            For k As Integer = 0 To 1 + GameForm1.bbishopcount
                GameForm1.blackbishop(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If GameForm1.blackbishop(k).flags(i, j) = True Then
                            stalemate = False
                        End If
                    Next
                Next
            Next

            'Possible moves for the black knight, if there is a move possible then stalemate = false
            For k As Integer = 0 To 1 + GameForm1.bknightcount
                GameForm1.blackknight(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If GameForm1.blackknight(k).flags(i, j) = True Then
                            stalemate = False
                        End If
                    Next
                Next
            Next

            'Possible moves for the black queen, if there is a move possible then stalemate = false
            For k As Integer = 0 To GameForm1.bqueencount
                GameForm1.blackqueen(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If GameForm1.blackqueen(k).flags(i, j) = True Then
                            stalemate = False
                        End If
                    Next
                Next
            Next

            If stalemate = True Then
                Settle.SettleAgreed()
            End If
            'Check if it is only kings left on the board
            KingsOnly()
            If stalemate = True Then
                Settle.SettleAgreed()
            End If
        End If


        If whiteindanger = True Then
            show()
            gameflag = False
            checkmate(0) = True
            checkmate(1) = True
            checkmate(2) = True
            checkmate(3) = True
            checkmate(4) = True
            checkmate(5) = True
            checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
            'Possible moves for the white king, if there is a move possible then checkmate = false
            GameForm1.whiteking.possiblemoves()
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                    If GameForm1.whiteking.flags(i, j) = True Then
                        checkmate(0) = False
                    End If
                Next
            Next
            'Possible moves for the white pawn, if there is a move possible then checkmate = false
            For k As Integer = 0 To 7
                GameForm1.whitepawn(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        If GameForm1.whitepawn(k).flags(i, j) = True Then
                            checkmate(1) = False
                        End If
                    Next
                Next
            Next
            'Possible moves for the white rook, if there is a move possible then checkmate = false
            For k As Integer = 0 To 1 + GameForm1.wrookcount
                GameForm1.whiterook(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        If GameForm1.whiterook(k).flags(i, j) = True Then
                            checkmate(2) = False
                        End If
                    Next
                Next
            Next
            'Possible moves for the white bishop, if there is a move possible then checkmate = false
            For k As Integer = 0 To 1 + GameForm1.wbishopcount
                GameForm1.whitebishop(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        If GameForm1.whitebishop(k).flags(i, j) = True Then
                            checkmate(3) = False
                        End If
                    Next
                Next
            Next
            'Possible moves for the white knight, if there is a move possible then checkmate = false
            For k As Integer = 0 To 1 + GameForm1.wknightcount
                GameForm1.whiteknight(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        If GameForm1.whiteknight(k).flags(i, j) = True Then
                            checkmate(4) = False
                        End If
                    Next
                Next
            Next
            'Possible moves for the white queen, if there is a move possible then checkmate = false
            For k As Integer = 0 To GameForm1.wqueencount
                GameForm1.whitequeen(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        If GameForm1.whitequeen(k).flags(i, j) = True Then
                            checkmate(5) = False
                        End If
                    Next
                Next
            Next

            If checkmate(0) = True And checkmate(1) = True And checkmate(2) = True And checkmate(3) = True And checkmate(4) = True And checkmate(5) = True Then
                If AICalculating = False Then
                    'Stop game
                    gameflag = False
                    GameForm1.gamestarted = False
                    'Stop timers
                    GameForm1.P1Timer.Stop()
                    GameForm1.P2Timer.Stop()
                    'Hide buttons
                    GameForm1.P1ResignButton.Hide()
                    GameForm1.P1SettleButton.Hide()
                    GameForm1.P2ResignButton.Hide()
                    GameForm1.P2SettleButton.Hide()

                    'Display winner
                    MsgBox("Checkmate, " & GameForm1.Player2Label.Text & " is the winner!")
                    'Getting both users stats and storing them temporarily (only win and lose, as settling form has the drawn stats changed)
                    Dim Player1Loses As Integer
                    Dim Player2Wins As Integer

                    'Setting database location
                    Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
                    'Openning connection
                    Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
                    Dim DBsource As String = "Data Source=" & dbfilename

                    Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
                    Dim da As OleDbDataAdapter 'adapter
                    Dim ds As New DataSet 'set used with adapter
                    Dim sql As String
                    sql = "SELECT [Username],[Wins], [Loses] FROM [Table1]" 'SQL Statement
                    da = New OleDbDataAdapter(sql, cn)
                    cn.Open() 'Open connection
                    da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
                    Dim count As Integer


                    For count = 0 To ds.Tables(0).Rows.Count - 1 'For loop for amount of users in table, (-1) as starts from 0
                        If LoginForm.Player1Username = ds.Tables(0).Rows(count).Item(0) Then 'For player 1 stats
                            Player1Loses = ds.Tables(0).Rows(count).Item(2)
                        ElseIf MultiplayerForm.Player2Username = ds.Tables(0).Rows(count).Item(0) Then 'For player 2 stats
                            Player2Wins = ds.Tables(0).Rows(count).Item(1)
                        End If
                    Next

                    cn.Close() 'Close connection

                    'Updating the database with the new P1 user stats
                    Dim cmd As New OleDbCommand(sql, cn)
                    sql = "update [Table1]"
                    sql = sql & "SET [Loses] = '" & Player1Loses + 1 & "' "
                    sql = sql & "WHERE [ID] = " & LoginForm.Player1ID & ";"
                    cmd = New OleDbCommand(sql, cn)
                    cn.Open() 'Open connection
                    cmd.ExecuteNonQuery()
                    cn.Close() 'Close connection


                    'Updating the database with the new P2 user stats
                    sql = "update [Table1]"
                    sql = sql & "SET [Wins] = '" & Player2Wins + 1 & "' "
                    sql = sql & "WHERE [ID] = " & MultiplayerForm.Player2ID & ";"
                    cmd = New OleDbCommand(sql, cn)
                    cn.Open() 'Open connection
                    cmd.ExecuteNonQuery()
                    cn.Close() 'Close connection

                    StoreGameReplay()
                End If
            Else
                gameflag = True
            End If
        End If

        If gameflag = True Then
            stalemate = True
            'Possible moves for the white king, if there is a move possible then stalemate = false
            GameForm1.whiteking.possiblemoves()
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    If GameForm1.whiteking.flags(i, j) = True Then
                        stalemate = False
                    End If
                Next
            Next
            'Possible moves for the white pawn, if there is a move possible then stalemate = false
            For k As Integer = 0 To 7
                GameForm1.whitepawn(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If GameForm1.whitepawn(k).flags(i, j) = True Then
                            stalemate = False
                        End If
                    Next
                Next
            Next
            'Possible moves for the white rook, if there is a move possible then stalemate = false
            For k As Integer = 0 To 1 + GameForm1.wrookcount
                GameForm1.whiterook(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If GameForm1.whiterook(k).flags(i, j) = True Then
                            stalemate = False
                        End If
                    Next
                Next
            Next
            'Possible moves for the white bishop, if there is a move possible then stalemate = false
            For k As Integer = 0 To 1 + GameForm1.wbishopcount
                GameForm1.whitebishop(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If GameForm1.whitebishop(k).flags(i, j) = True Then
                            stalemate = False
                        End If
                    Next
                Next
            Next
            'Possible moves for the white knight, if there is a move possible then stalemate = false
            For k As Integer = 0 To 1 + GameForm1.wknightcount
                GameForm1.whiteknight(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If GameForm1.whiteknight(k).flags(i, j) = True Then
                            stalemate = False
                        End If
                    Next
                Next
            Next
            'Possible moves for the white queen, if there is a move possible then stalemate = false
            For k As Integer = 0 To GameForm1.wqueencount
                GameForm1.whitequeen(k).possiblemoves()
                For i As Integer = 0 To 7
                    For j As Integer = 0 To 7
                        If GameForm1.whitequeen(k).flags(i, j) = True Then
                            stalemate = False
                        End If
                    Next
                Next
            Next

            If stalemate = True And AICalculating = False Then
                Settle.SettleAgreed()
            End If
            'Check if it is only kings left on the board
            KingsOnly()
            If stalemate = True And AICalculating = False Then
                Settle.SettleAgreed()
            End If
        End If
    End Sub

    'showing images of pieces
    Public Sub show()
        If GameForm1.Set1 = True Then
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    Select Case board(i, j)
                        Case 1
                            GameForm1.pb(i, j).Image = My.Resources.Set1KingW
                        Case 2
                            GameForm1.pb(i, j).Image = My.Resources.Set1QueenW
                        Case 3
                            GameForm1.pb(i, j).Image = My.Resources.Set1BishopW
                        Case 4
                            GameForm1.pb(i, j).Image = My.Resources.Set1KnightW
                        Case 5
                            GameForm1.pb(i, j).Image = My.Resources.Set1RookW
                        Case 6
                            GameForm1.pb(i, j).Image = My.Resources.Set1PawnW
                        Case -1
                            GameForm1.pb(i, j).Image = My.Resources.Set1KingB
                        Case -2
                            GameForm1.pb(i, j).Image = My.Resources.Set1QueenB
                        Case -3
                            GameForm1.pb(i, j).Image = My.Resources.Set1BishopB
                        Case -4
                            GameForm1.pb(i, j).Image = My.Resources.Set1KnightB
                        Case -5
                            GameForm1.pb(i, j).Image = My.Resources.Set1RookB
                        Case -6
                            GameForm1.pb(i, j).Image = My.Resources.Set1PawnB
                        Case Else
                            GameForm1.pb(i, j).Image = Nothing
                    End Select
                    showcheck()
                Next
            Next
        ElseIf GameForm1.Set2 = True Then
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    Select Case board(i, j)
                        Case 1
                            GameForm1.pb(i, j).Image = My.Resources.Set2KingW
                        Case 2
                            GameForm1.pb(i, j).Image = My.Resources.Set2QueenW
                        Case 3
                            GameForm1.pb(i, j).Image = My.Resources.Set2BishopW
                        Case 4
                            GameForm1.pb(i, j).Image = My.Resources.Set2KnightW
                        Case 5
                            GameForm1.pb(i, j).Image = My.Resources.Set2RookW
                        Case 6
                            GameForm1.pb(i, j).Image = My.Resources.Set2PawnW
                        Case -1
                            GameForm1.pb(i, j).Image = My.Resources.Set2KingB
                        Case -2
                            GameForm1.pb(i, j).Image = My.Resources.Set2QueenB
                        Case -3
                            GameForm1.pb(i, j).Image = My.Resources.Set2BishopB
                        Case -4
                            GameForm1.pb(i, j).Image = My.Resources.Set2KnightB
                        Case -5
                            GameForm1.pb(i, j).Image = My.Resources.Set2RookB
                        Case -6
                            GameForm1.pb(i, j).Image = My.Resources.Set2PawnB
                        Case Else
                            GameForm1.pb(i, j).Image = Nothing
                    End Select
                    showcheck()
                Next
            Next
        ElseIf GameForm1.Set3 = True Then
            For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    Select Case board(i, j)
                        Case 1
                            GameForm1.pb(i, j).Image = My.Resources.Set3KingW
                        Case 2
                            GameForm1.pb(i, j).Image = My.Resources.Set3QueenW
                        Case 3
                            GameForm1.pb(i, j).Image = My.Resources.Set3BishopW
                        Case 4
                            GameForm1.pb(i, j).Image = My.Resources.Set3KnightW
                        Case 5
                            GameForm1.pb(i, j).Image = My.Resources.Set3RookW
                        Case 6
                            GameForm1.pb(i, j).Image = My.Resources.Set3PawnW
                        Case -1
                            GameForm1.pb(i, j).Image = My.Resources.Set3KingB
                        Case -2
                            GameForm1.pb(i, j).Image = My.Resources.Set3QueenB
                        Case -3
                            GameForm1.pb(i, j).Image = My.Resources.Set3BishopB
                        Case -4
                            GameForm1.pb(i, j).Image = My.Resources.Set3KnightB
                        Case -5
                            GameForm1.pb(i, j).Image = My.Resources.Set3RookB
                        Case -6
                            GameForm1.pb(i, j).Image = My.Resources.Set3PawnB
                        Case Else
                            GameForm1.pb(i, j).Image = Nothing
                    End Select
                    showcheck()
                Next
            Next
        End If
    End Sub
    Dim z As Integer 'variable used in the easy mode of AI

    'selecting picture box
    Public Function selection(ByVal x, ByVal y) As String
        If gameflag = True Then 'selection only possible if gameflag true (when game is not over)
            showcheck() 'if the king is in check always display it on the board
            If board(x, y) <> 0 Then 'if value selected on board is not equal to 0 (blank square)
                GameForm1.pb(x, y).BackgroundImage = My.Resources.Selection 'add selection resource to background image to highlight primary image
            End If

            Select Case board(x, y) 'whatever board value selected on board, return the piece and possible moves
                Case 1
                    If player = 1 Then
                        showpossiblemove(GameForm1.whiteking.possiblemoves)
                        Return "whiteking"
                    End If
                Case 2
                    If player = 1 Then
                        For i As Integer = 0 To GameForm1.wqueencount
                            If GameForm1.whitequeen(i).returnx = x And GameForm1.whitequeen(i).returny = y Then
                                showpossiblemove(GameForm1.whitequeen(i).possiblemoves)
                            End If
                        Next
                        Return "whitequeen"
                    End If
                Case 3
                    If player = 1 Then
                        For i As Integer = 0 To 1 + GameForm1.wbishopcount
                            If GameForm1.whitebishop(i).returnx = x And GameForm1.whitebishop(i).returny = y Then
                                showpossiblemove(GameForm1.whitebishop(i).possiblemoves)

                            End If
                        Next
                        Return "whitebishop"
                    End If
                Case 4
                    If player = 1 Then
                        For i As Integer = 0 To 1 + GameForm1.wknightcount
                            If GameForm1.whiteknight(i).returnx = x And GameForm1.whiteknight(i).returny = y Then
                                showpossiblemove(GameForm1.whiteknight(i).possiblemoves)
                            End If
                        Next
                        Return "whiteknight"
                    End If
                Case 5
                    If player = 1 Then
                        For i As Integer = 0 To 1 + GameForm1.wrookcount
                            If GameForm1.whiterook(i).returnx = x And GameForm1.whiterook(i).returny = y Then
                                showpossiblemove(GameForm1.whiterook(i).possiblemoves)
                            End If
                        Next
                        Return "whiterook"
                    End If
                Case 6
                    If player = 1 Then
                        For i As Integer = 0 To 7
                            If GameForm1.whitepawn(i).returnx = x And GameForm1.whitepawn(i).returny = y Then
                                showpossiblemove(GameForm1.whitepawn(i).possiblemoves)
                            End If
                        Next
                    End If
                    Return "whitepawn"
                Case -1
                    If player = 2 Then
                        showpossiblemove(GameForm1.blackking.possiblemoves)
                        Return "blackking"
                    End If
                Case -2
                    If player = 2 Then
                        For i As Integer = 0 To GameForm1.bqueencount
                            If GameForm1.blackqueen(i).returnx = x And GameForm1.blackqueen(i).returny = y Then
                                showpossiblemove(GameForm1.blackqueen(i).possiblemoves)
                                z = i
                            End If
                        Next
                        Return "blackqueen"
                    End If
                Case -3
                    If player = 2 Then
                        For i As Integer = 0 To 1 + GameForm1.bbishopcount
                            If GameForm1.blackbishop(i).returnx = x And GameForm1.blackbishop(i).returny = y Then
                                showpossiblemove(GameForm1.blackbishop(i).possiblemoves)
                                z = i
                            End If
                        Next
                        Return "blackbishop"
                    End If
                Case -4
                    If player = 2 Then
                        For i As Integer = 0 To 1 + GameForm1.bknightcount
                            If GameForm1.blackknight(i).returnx = x And GameForm1.blackknight(i).returny = y Then
                                showpossiblemove(GameForm1.blackknight(i).possiblemoves)
                                'TESTING
                                z = i
                            End If
                        Next
                        Return "blackknight"
                    End If
                Case -5
                    If player = 2 Then
                        For i As Integer = 0 To 1 + GameForm1.brookcount
                            If GameForm1.blackrook(i).returnx = x And GameForm1.blackrook(i).returny = y Then
                                showpossiblemove(GameForm1.blackrook(i).possiblemoves)
                                z = i
                            End If
                        Next
                        Return ("blackrook")
                    End If
                Case -6
                    If player = 2 Then
                        For i As Integer = 0 To 7
                            If GameForm1.blackpawn(i).returnx = x And GameForm1.blackpawn(i).returny = y Then
                                showpossiblemove(GameForm1.blackpawn(i).possiblemoves)
                                z = i
                            End If
                        Next
                        Return ("blackpawn")
                    End If
                Case Else
                    Return Nothing
            End Select
        End If
    End Function

    Public Sub reback()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                GameForm1.pb(i, j).BackgroundImage = Nothing
            Next
        Next
    End Sub

    Public Sub recanmove()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                canmove(i, j) = False
            Next
        Next
    End Sub

    Public Sub recheckwhite() 'Setting Every Square Check = False
        '2 loops needed as (7, 7) array, setting all squares check false
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                checkforwhite(i, j) = False
            Next
        Next
    End Sub

    Public Sub recheckblack()
        '2 loops needed as (7, 7) array, setting all squares check false
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                checkforblack(i, j) = False
            Next
        Next
    End Sub

    Public Sub fillcheckforblack()
        If player = 2 Then
            If recurrsionstop = True Then Exit Sub
            recheckblack()
            '
            'White Pawn
            '
            For i As Integer = 0 To 7
                If GameForm1.whitepawn(i).stillonboard = True And board(GameForm1.whitepawn(i).xposition, GameForm1.whitepawn(i).yposition) = 6 Then
                    GameForm1.whitepawn(i).fillcheckking()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            If GameForm1.whitepawn(i).checktheking(j, k) = True And GameForm1.blackking.xposition = j And GameForm1.blackking.yposition = k Then
                                xpositionCheck = GameForm1.whitepawn(i).xposition
                                ypositionCheck = GameForm1.whitepawn(i).yposition
                                checkforblack(j, k) = True
                            ElseIf GameForm1.whitepawn(i).checktheking(j, k) = True Then
                                checkforblack(j, k) = True

                            End If
                        Next
                    Next
                Else
                    GameForm1.whitepawn(i).reflags()
                End If
            Next
            '
            'White Rook
            '
            For i As Integer = 0 To 1 + GameForm1.wrookcount
                If GameForm1.whiterook(i).stillonboard = True And board(GameForm1.whiterook(i).xposition, GameForm1.whiterook(i).yposition) = 5 Then
                    GameForm1.whiterook(i).fillcheckking()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            If GameForm1.whiterook(i).checktheking(j, k) = True And GameForm1.blackking.xposition = j And GameForm1.blackking.yposition = k Then
                                xpositionCheck = GameForm1.whiterook(i).xposition
                                ypositionCheck = GameForm1.whiterook(i).yposition
                                checkforblack(j, k) = True
                            ElseIf GameForm1.whiterook(i).checktheking(j, k) = True Then
                                checkforblack(j, k) = True
                            End If
                        Next
                    Next
                Else
                    GameForm1.whiterook(i).reflags()
                End If
            Next
            '
            'White Knight
            '
            For i As Integer = 0 To 1 + GameForm1.wknightcount
                If GameForm1.whiteknight(i).stillonboard = True And board(GameForm1.whiteknight(i).xposition, GameForm1.whiteknight(i).yposition) = 4 Then
                    GameForm1.whiteknight(i).fillcheckking()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            If GameForm1.whiteknight(i).checktheking(j, k) = True And GameForm1.blackking.xposition = j And GameForm1.blackking.yposition = k Then
                                xpositionCheck = GameForm1.whiteknight(i).xposition
                                ypositionCheck = GameForm1.whiteknight(i).yposition
                                checkforblack(j, k) = True
                            ElseIf GameForm1.whiteknight(i).checktheking(j, k) = True Then
                                checkforblack(j, k) = True
                            End If
                        Next
                    Next
                Else
                    GameForm1.whiteknight(i).reflags()
                End If
            Next
            '
            'White Bishop
            '
            For i As Integer = 0 To 1 + GameForm1.wbishopcount
                If GameForm1.whitebishop(i).stillonboard = True And board(GameForm1.whitebishop(i).xposition, GameForm1.whitebishop(i).yposition) = 3 Then
                    GameForm1.whitebishop(i).fillcheckking()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            If GameForm1.whitebishop(i).checktheking(j, k) = True And GameForm1.blackking.xposition = j And GameForm1.blackking.yposition = k Then
                                xpositionCheck = GameForm1.whitebishop(i).xposition
                                ypositionCheck = GameForm1.whitebishop(i).yposition
                                checkforblack(j, k) = True
                            ElseIf GameForm1.whitebishop(i).checktheking(j, k) = True Then
                                checkforblack(j, k) = True
                            End If
                        Next
                    Next
                Else
                    GameForm1.whitebishop(i).reflags()
                End If
            Next
            '
            'White Queen
            '
            For i As Integer = 0 To GameForm1.wqueencount
                If GameForm1.whitequeen(i).stillonboard = True And board(GameForm1.whitequeen(i).xposition, GameForm1.whitequeen(i).yposition) = 2 Then
                    GameForm1.whitequeen(i).fillcheckking()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            If GameForm1.whitequeen(i).checktheking(j, k) = True And GameForm1.blackking.xposition = j And GameForm1.blackking.yposition = k Then
                                xpositionCheck = GameForm1.whitequeen(i).xposition
                                ypositionCheck = GameForm1.whitequeen(i).yposition
                                checkforblack(j, k) = True

                            ElseIf GameForm1.whitequeen(i).checktheking(j, k) = True Then
                                checkforblack(j, k) = True
                            End If
                        Next
                    Next
                Else
                    GameForm1.whitequeen(i).reflags()
                End If
            Next
            '
            'White King
            '
            GameForm1.whiteking.fillcheckking()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If GameForm1.whiteking.checktheking(j, k) = True Then
                        checkforblack(j, k) = True
                    End If
                Next
            Next

            recurrsionstop = True
        End If
    End Sub

    Public Sub fillcheckforwhite()
        If player = 1 Then
            If recurrsionstop = True Then Exit Sub
            recheckwhite()
            '
            'Black Pawn
            '
            For i As Integer = 0 To 7
                If GameForm1.blackpawn(i).stillonboard = True And board(GameForm1.blackpawn(i).xposition, GameForm1.blackpawn(i).yposition) = -6 Then
                    GameForm1.blackpawn(i).fillcheckking()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            If GameForm1.blackpawn(i).checktheking(j, k) = True And GameForm1.whiteking.xposition = j And GameForm1.whiteking.yposition = k Then
                                xpositionCheck = GameForm1.blackpawn(i).xposition
                                ypositionCheck = GameForm1.blackpawn(i).yposition
                                checkforwhite(j, k) = True
                            ElseIf GameForm1.blackpawn(i).checktheking(j, k) = True Then
                                checkforwhite(j, k) = True
                            End If
                        Next
                    Next
                Else
                    GameForm1.blackpawn(i).reflags()
                End If
            Next
            '
            'Black Rook
            '
            For i As Integer = 0 To 1 + GameForm1.brookcount
                If GameForm1.blackrook(i).stillonboard = True And board(GameForm1.blackrook(i).xposition, GameForm1.blackrook(i).yposition) = -5 Then
                    GameForm1.blackrook(i).fillcheckking()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            If GameForm1.blackrook(i).checktheking(j, k) = True And GameForm1.whiteking.xposition = j And GameForm1.whiteking.yposition = k Then
                                xpositionCheck = GameForm1.blackrook(i).xposition
                                ypositionCheck = GameForm1.blackrook(i).yposition
                                checkforwhite(j, k) = True
                            ElseIf GameForm1.blackrook(i).checktheking(j, k) = True Then
                                checkforwhite(j, k) = True
                            End If
                        Next
                    Next
                Else
                    GameForm1.blackrook(i).reflags()
                End If
            Next
            '
            'Black Knight
            '
            For i As Integer = 0 To 1 + GameForm1.bknightcount

                If GameForm1.blackknight(i).stillonboard = True And board(GameForm1.blackknight(i).xposition, GameForm1.blackknight(i).yposition) = -4 Then
                    GameForm1.blackknight(i).fillcheckking()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            If GameForm1.blackknight(i).checktheking(j, k) = True And GameForm1.whiteking.xposition = j And GameForm1.whiteking.yposition = k Then
                                xpositionCheck = GameForm1.blackknight(i).xposition
                                ypositionCheck = GameForm1.blackknight(i).yposition
                                checkforwhite(j, k) = True
                            ElseIf GameForm1.blackknight(i).checktheking(j, k) = True Then
                                checkforwhite(j, k) = True
                            End If
                        Next
                    Next
                Else
                    GameForm1.blackknight(i).reflags()
                End If
            Next
            '
            'Black Bishop
            '
            For i As Integer = 0 To 1 + GameForm1.bbishopcount
                If GameForm1.blackbishop(i).stillonboard = True And board(GameForm1.blackbishop(i).xposition, GameForm1.blackbishop(i).yposition) = -3 Then
                    GameForm1.blackbishop(i).fillcheckking()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            If GameForm1.blackbishop(i).checktheking(j, k) = True And GameForm1.whiteking.xposition = j And GameForm1.whiteking.yposition = k Then
                                xpositionCheck = GameForm1.blackbishop(i).xposition
                                ypositionCheck = GameForm1.blackbishop(i).yposition
                                checkforwhite(j, k) = True
                            ElseIf GameForm1.blackbishop(i).checktheking(j, k) = True Then
                                checkforwhite(j, k) = True
                            End If
                        Next
                    Next
                Else
                    GameForm1.blackbishop(i).reflags()
                End If
            Next
            '
            'Black Queen
            '
            For i As Integer = 0 To GameForm1.bqueencount
                If GameForm1.blackqueen(i).stillonboard = True And board(GameForm1.blackqueen(i).xposition, GameForm1.blackqueen(i).yposition) = -2 Then
                    GameForm1.blackqueen(i).fillcheckking()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            If GameForm1.blackqueen(i).checktheking(j, k) = True And GameForm1.whiteking.xposition = j And GameForm1.whiteking.yposition = k Then
                                xpositionCheck = GameForm1.blackqueen(i).xposition
                                ypositionCheck = GameForm1.blackqueen(i).yposition
                                checkforwhite(j, k) = True

                            ElseIf GameForm1.blackqueen(i).checktheking(j, k) = True Then
                                checkforwhite(j, k) = True
                            End If
                        Next
                    Next
                Else
                    GameForm1.blackqueen(i).reflags()
                End If
            Next
            '
            'Black King
            '
            GameForm1.blackking.fillcheckking()
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    If GameForm1.blackking.checktheking(j, k) = True Then
                        checkforwhite(j, k) = True
                    End If
                Next
            Next

            recurrsionstop = True
        End If
    End Sub

    Public Sub showcheck()
        whiteindanger = False
        blackindanger = False
        'black check
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If checkforblack(i, j) = True And GameForm1.blackking.xposition = i And GameForm1.blackking.yposition = j Then 'locating the king using x and y coords and adding check background
                    GameForm1.pb(i, j).BackgroundImage = My.Resources.Check
                    blackindanger = True

                End If
            Next
        Next

        'white check
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If checkforwhite(i, j) = True And GameForm1.whiteking.xposition = i And GameForm1.whiteking.yposition = j Then 'locating the king using x and y coords and adding check background
                    GameForm1.pb(i, j).BackgroundImage = My.Resources.Check
                    whiteindanger = True

                End If
            Next
        Next
    End Sub

    Public Sub showpossiblemove(ByVal b As Boolean(,))
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If b(i, j) = True Then
                    GameForm1.pb(i, j).BackgroundImage = My.Resources.VMove
                    canmove(i, j) = True
                End If
            Next
        Next
    End Sub

    Public Sub mov(ByVal selected, ByVal x, ByVal y, ByVal prex, ByVal prey)
        Select Case selected
            Case "whiteking"
                movecounter += 1
                GameForm1.MoveCounterTextBox.Text = movecounter
                If x = 7 And y = 2 And GameForm1.whiteking.AllowedToCastle = True And GameForm1.whiterook(0).AllowedToCastle = True And castleincheck(0) = False Then
                    Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
                    Dim result As DialogResult
                    'displaying MessageBox
                    result = MessageBox.Show("Are you sure you want castle", "Castle", button)
                    'getting result of the messagebox
                    If result = System.Windows.Forms.DialogResult.Yes Then
                        GameForm1.whiteking.changeposition(x, y, prex, prey)
                        GameForm1.whiterook(0).changeposition(7, 3, 7, 0)
                        GameForm1.whiteking.AllowedToCastle = False
                        GameForm1.whiterook(0).AllowedToCastle = False
                        GameForm1.whiterook(1).AllowedToCastle = False
                        GameForm1.P1Timer.Stop()
                        If GameForm1.MinutesTextBox1.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox1.Text) <= 5 Then
                                GameForm1.SecondsTextBox1.Text += 2
                                GameForm1.SecondsTextBox1.Text = "0" & GameForm1.SecondsTextBox1.Text
                            End If
                        End If
                        GameForm1.P2Timer.Start()
                        player = 2
                        recheckwhite() 'White cannot be in check if king has been moved
                        recheckblack() 'Black cannot be in check by the king, therefore set all squares to not in check 
                        If GameForm1.gameisoneplayer = True And gameflag = True Then
                            If GameForm1.EasyMode = True Then
                                AIMoving()
                            ElseIf GameForm1.HardMode = True Then
                                AIMovingHard()
                            End If
                        End If
                        Exit Sub
                    Else
                        movecounter -= 1
                        Exit Sub
                    End If
                End If
                If x = 7 And y = 6 And GameForm1.whiteking.AllowedToCastle = True And GameForm1.whiterook(1).AllowedToCastle = True And castleincheck(1) = False Then
                    Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
                    Dim result As DialogResult
                    'displaying MessageBox
                    result = MessageBox.Show("Are you sure you want castle", "Castle", button)
                    'getting result of the messagebox
                    If result = System.Windows.Forms.DialogResult.Yes Then
                        GameForm1.whiteking.changeposition(x, y, prex, prey)
                        GameForm1.whiterook(1).changeposition(7, 5, 7, 7)
                        GameForm1.whiteking.AllowedToCastle = False
                        GameForm1.whiterook(1).AllowedToCastle = False
                        GameForm1.whiterook(0).AllowedToCastle = False
                        GameForm1.P1Timer.Stop()
                        If GameForm1.MinutesTextBox1.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox1.Text) <= 5 Then
                                GameForm1.SecondsTextBox1.Text += 2
                                GameForm1.SecondsTextBox1.Text = "0" & GameForm1.SecondsTextBox1.Text
                            End If
                        End If
                        GameForm1.P2Timer.Start()
                        player = 2

                        recheckwhite() 'White cannot be in check if king has been moved
                        recheckblack() 'Black cannot be in check by the king, therefore set all squares to not in check 
                        If GameForm1.gameisoneplayer = True And gameflag = True Then
                            If GameForm1.EasyMode = True Then
                                AIMoving()
                            ElseIf GameForm1.HardMode = True Then
                                AIMovingHard()
                            End If
                        End If
                        Exit Sub
                    Else
                        movecounter -= 1
                        Exit Sub
                    End If
                End If
                GameForm1.whiteking.changeposition(x, y, prex, prey)
                GameForm1.whiteking.AllowedToCastle = False
                'After a white king has moved, if it has taken a black piece set its x and y values to 0

                For L As Integer = 0 To GameForm1.bqueencount
                    If GameForm1.whiteking.xposition = GameForm1.blackqueen(L).xposition And GameForm1.whiteking.yposition = GameForm1.blackqueen(L).yposition Then
                        GameForm1.blackqueen(L).stillonboard = False
                    End If
                Next

                For L As Integer = 0 To 1 + GameForm1.bknightcount
                    If GameForm1.whiteking.xposition = GameForm1.blackknight(L).xposition And GameForm1.whiteking.yposition = GameForm1.blackknight(L).yposition Then
                        GameForm1.blackknight(L).stillonboard = False
                    End If
                Next

                For L As Integer = 0 To 1 + GameForm1.bbishopcount
                    If GameForm1.whiteking.xposition = GameForm1.blackbishop(L).xposition And GameForm1.whiteking.yposition = GameForm1.blackbishop(L).yposition Then
                        GameForm1.blackbishop(L).stillonboard = False
                    End If
                Next

                For L As Integer = 0 To 1 + GameForm1.brookcount
                    If GameForm1.whiteking.xposition = GameForm1.blackrook(L).xposition And GameForm1.whiteking.yposition = GameForm1.blackrook(L).yposition Then
                        GameForm1.blackrook(L).stillonboard = False
                    End If
                Next

                For L As Integer = 0 To 7
                    If GameForm1.whiteking.xposition = GameForm1.blackpawn(L).xposition And GameForm1.whiteking.yposition = GameForm1.blackpawn(L).yposition Then
                        GameForm1.blackpawn(L).stillonboard = False
                    End If
                Next

                GameForm1.P1Timer.Stop()
                If GameForm1.MinutesTextBox1.Text = "00" Then
                    If CInt(GameForm1.SecondsTextBox1.Text) <= 5 Then
                        GameForm1.SecondsTextBox1.Text += 2
                        GameForm1.SecondsTextBox1.Text = "0" & GameForm1.SecondsTextBox1.Text
                    End If
                End If
                GameForm1.P2Timer.Start()

                recheckwhite() 'White cannot be in check if the pawn has moved
                GameForm1.ga.recurrsionstop = False

                player = 2
                fillcheckforblack()
                showcheck() 'Show the check if there is one

                checkwinner()

                If GameForm1.gameisoneplayer = True And gameflag = True Then

                    If GameForm1.EasyMode = True Then
                        AIMoving()
                    ElseIf GameForm1.HardMode = True Then
                        AIMovingHard()
                    End If
                End If


            Case "whitequeen"
                movecounter += 1
                GameForm1.MoveCounterTextBox.Text = movecounter
                For i As Integer = 0 To GameForm1.wqueencount
                    If GameForm1.whitequeen(i).returnx = prex And GameForm1.whitequeen(i).returny = prey Then
                        GameForm1.whitequeen(i).changeposition(x, y, prex, prey)
                        'After a white queen has moved, if it has taken a black piece set its x and y values to 0

                        For L As Integer = 0 To GameForm1.bqueencount
                            If GameForm1.whitequeen(i).xposition = GameForm1.blackqueen(L).xposition And GameForm1.whitequeen(i).yposition = GameForm1.blackqueen(L).yposition Then
                                GameForm1.blackqueen(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.bknightcount
                            If GameForm1.whitequeen(i).xposition = GameForm1.blackknight(L).xposition And GameForm1.whitequeen(i).yposition = GameForm1.blackknight(L).yposition Then
                                GameForm1.blackknight(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.bbishopcount
                            If GameForm1.whitequeen(i).xposition = GameForm1.blackbishop(L).xposition And GameForm1.whitequeen(i).yposition = GameForm1.blackbishop(L).yposition Then
                                GameForm1.blackbishop(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.brookcount
                            If GameForm1.whitequeen(i).xposition = GameForm1.blackrook(L).xposition And GameForm1.whitequeen(i).yposition = GameForm1.blackrook(L).yposition Then
                                GameForm1.blackrook(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 7
                            If GameForm1.whitequeen(i).xposition = GameForm1.blackpawn(L).xposition And GameForm1.whitequeen(i).yposition = GameForm1.blackpawn(L).yposition Then
                                GameForm1.blackpawn(L).stillonboard = False
                            End If
                        Next
                        GameForm1.P1Timer.Stop()
                        If GameForm1.MinutesTextBox1.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox1.Text) <= 5 Then
                                GameForm1.SecondsTextBox1.Text += 2
                                GameForm1.SecondsTextBox1.Text = "0" & GameForm1.SecondsTextBox1.Text
                            End If
                        End If
                        GameForm1.P2Timer.Start()

                        recheckwhite() 'White cannot be in check if the pawn has moved
                        GameForm1.ga.recurrsionstop = False

                        player = 2
                        fillcheckforblack()
                        showcheck() 'Show the check if there is one

                        checkwinner()

                        If GameForm1.gameisoneplayer = True And gameflag = True Then

                            If GameForm1.EasyMode = True Then
                                AIMoving()
                            ElseIf GameForm1.HardMode = True Then
                                AIMovingHard()
                            End If
                        End If
                    End If
                Next

            Case "whitebishop"
                movecounter += 1
                GameForm1.MoveCounterTextBox.Text = movecounter
                For i As Integer = 0 To 1 + GameForm1.wbishopcount
                    If GameForm1.whitebishop(i).returnx = prex And GameForm1.whitebishop(i).returny = prey Then
                        GameForm1.whitebishop(i).changeposition(x, y, prex, prey)
                        'After a white bishop has moved, if it has taken a black piece set its x and y values to 0

                        For L As Integer = 0 To GameForm1.bqueencount
                            If GameForm1.whitebishop(i).xposition = GameForm1.blackqueen(L).xposition And GameForm1.whitebishop(i).yposition = GameForm1.blackqueen(L).yposition Then
                                GameForm1.blackqueen(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.bknightcount
                            If GameForm1.whitebishop(i).xposition = GameForm1.blackknight(L).xposition And GameForm1.whitebishop(i).yposition = GameForm1.blackknight(L).yposition Then
                                GameForm1.blackknight(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.bbishopcount
                            If GameForm1.whitebishop(i).xposition = GameForm1.blackbishop(L).xposition And GameForm1.whitebishop(i).yposition = GameForm1.blackbishop(L).yposition Then
                                GameForm1.blackbishop(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.brookcount
                            If GameForm1.whitebishop(i).xposition = GameForm1.blackrook(L).xposition And GameForm1.whitebishop(i).yposition = GameForm1.blackrook(L).yposition Then
                                GameForm1.blackrook(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 7
                            If GameForm1.whitebishop(i).xposition = GameForm1.blackpawn(L).xposition And GameForm1.whitebishop(i).yposition = GameForm1.blackpawn(L).yposition Then
                                GameForm1.blackpawn(L).stillonboard = False
                            End If
                        Next
                        GameForm1.P1Timer.Stop()
                        If GameForm1.MinutesTextBox1.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox1.Text) <= 5 Then
                                GameForm1.SecondsTextBox1.Text += 2
                                GameForm1.SecondsTextBox1.Text = "0" & GameForm1.SecondsTextBox1.Text
                            End If
                        End If
                        GameForm1.P2Timer.Start()

                        recheckwhite() 'White cannot be in check if the pawn has moved
                        GameForm1.ga.recurrsionstop = False

                        player = 2
                        fillcheckforblack()
                        showcheck() 'Show the check if there is one

                        checkwinner()

                        If GameForm1.gameisoneplayer = True And gameflag = True Then

                            If GameForm1.EasyMode = True Then
                                AIMoving()
                            ElseIf GameForm1.HardMode = True Then
                                AIMovingHard()
                            End If
                        End If
                    End If
                Next

            Case "whiteknight"
                movecounter += 1
                GameForm1.MoveCounterTextBox.Text = movecounter
                For i As Integer = 0 To 1 + GameForm1.wknightcount
                    If GameForm1.whiteknight(i).returnx = prex And GameForm1.whiteknight(i).returny = prey Then
                        GameForm1.whiteknight(i).changeposition(x, y, prex, prey)
                        'After a white knight has moved, if it has taken a black piece set its x and y values to 0

                        For L As Integer = 0 To GameForm1.bqueencount
                            If GameForm1.whiteknight(i).xposition = GameForm1.blackqueen(L).xposition And GameForm1.whiteknight(i).yposition = GameForm1.blackqueen(L).yposition Then
                                GameForm1.blackqueen(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.bknightcount
                            If GameForm1.whiteknight(i).xposition = GameForm1.blackknight(L).xposition And GameForm1.whiteknight(i).yposition = GameForm1.blackknight(L).yposition Then
                                GameForm1.blackknight(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.bbishopcount
                            If GameForm1.whiteknight(i).xposition = GameForm1.blackbishop(L).xposition And GameForm1.whiteknight(i).yposition = GameForm1.blackbishop(L).yposition Then
                                GameForm1.blackbishop(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.brookcount
                            If GameForm1.whiteknight(i).xposition = GameForm1.blackrook(L).xposition And GameForm1.whiteknight(i).yposition = GameForm1.blackrook(L).yposition Then
                                GameForm1.blackrook(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 7
                            If GameForm1.whiteknight(i).xposition = GameForm1.blackpawn(L).xposition And GameForm1.whiteknight(i).yposition = GameForm1.blackpawn(L).yposition Then
                                GameForm1.blackpawn(L).stillonboard = False
                            End If
                        Next
                        GameForm1.P1Timer.Stop()
                        If GameForm1.MinutesTextBox1.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox1.Text) <= 5 Then
                                GameForm1.SecondsTextBox1.Text += 2
                                GameForm1.SecondsTextBox1.Text = "0" & GameForm1.SecondsTextBox1.Text
                            End If
                        End If
                        GameForm1.P2Timer.Start()

                        recheckwhite() 'White cannot be in check if the pawn has moved
                        GameForm1.ga.recurrsionstop = False

                        player = 2
                        fillcheckforblack()
                        showcheck() 'Show the check if there is one

                        checkwinner()

                        If GameForm1.gameisoneplayer = True And gameflag = True Then

                            If GameForm1.EasyMode = True Then
                                AIMoving()
                            ElseIf GameForm1.HardMode = True Then
                                AIMovingHard()
                            End If
                        End If
                    End If
                Next


            Case "whiterook"
                movecounter += 1
                GameForm1.MoveCounterTextBox.Text = movecounter
                'First rook castle code
                If x = 7 And y = 3 And GameForm1.whiteking.AllowedToCastle = True And GameForm1.whiterook(0).AllowedToCastle = True And castleincheck(0) = False Then
                    Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
                    Dim result As DialogResult
                    'displaying MessageBox
                    result = MessageBox.Show("Select 'Yes' to Castle, Select 'No' to move there normally", "Castle", button)
                    'getting result of the messagebox
                    If result = System.Windows.Forms.DialogResult.Yes Then
                        GameForm1.whiterook(0).changeposition(x, y, prex, prey)
                        GameForm1.whiteking.changeposition(7, 2, 7, 4)
                        GameForm1.whiterook(0).AllowedToCastle = False
                        GameForm1.whiterook(1).AllowedToCastle = False
                        GameForm1.whiteking.AllowedToCastle = False

                        GameForm1.P1Timer.Stop()
                        If GameForm1.MinutesTextBox1.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox1.Text) <= 5 Then
                                GameForm1.SecondsTextBox1.Text += 2
                                GameForm1.SecondsTextBox1.Text = "0" & GameForm1.SecondsTextBox1.Text
                            End If
                        End If
                        GameForm1.P2Timer.Start()

                        recheckwhite() 'White cannot be in check if the pawn has moved
                        GameForm1.ga.recurrsionstop = False

                        player = 2
                        fillcheckforblack()
                        showcheck() 'Show the check if there is one

                        checkwinner()

                        If GameForm1.gameisoneplayer = True And gameflag = True Then

                            If GameForm1.EasyMode = True Then
                                AIMoving()
                            ElseIf GameForm1.HardMode = True Then
                                AIMovingHard()
                            End If
                        End If
                        Exit Sub
                    Else
                        If checkforwhite(7, 4) = False Then
                            GameForm1.whiterook(0).changeposition(x, y, prex, prey)
                            GameForm1.whiterook(0).AllowedToCastle = False
                            GameForm1.P1Timer.Stop()
                            If GameForm1.MinutesTextBox1.Text = "00" Then
                                If CInt(GameForm1.SecondsTextBox1.Text) <= 5 Then
                                    GameForm1.SecondsTextBox1.Text += 2
                                    GameForm1.SecondsTextBox1.Text = "0" & GameForm1.SecondsTextBox1.Text
                                End If
                            End If
                            GameForm1.P2Timer.Start()

                            recheckwhite() 'White cannot be in check if the pawn has moved
                            GameForm1.ga.recurrsionstop = False
                            player = 2

                            fillcheckforblack()
                            showcheck() 'Show the check if there is one

                            checkwinner()

                            If GameForm1.gameisoneplayer = True And gameflag = True Then

                                If GameForm1.EasyMode = True Then
                                    AIMoving()
                                ElseIf GameForm1.HardMode = True Then
                                    AIMovingHard()
                                End If
                            End If
                        ElseIf checkforwhite(7, 4) = True Then
                            'Cannot move there normally as king is in check
                            MessageBox.Show("King in check, cannot move Rook to D8")
                        End If
                        Exit Sub
                    End If
                End If
                'Second rook castle code
                If x = 7 And y = 5 And GameForm1.whiteking.AllowedToCastle = True And GameForm1.whiterook(1).AllowedToCastle = True And castleincheck(1) = False Then
                    Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
                    Dim result As DialogResult
                    'displaying MessageBox
                    result = MessageBox.Show("Select 'Yes' to Castle, Select 'No' to move there normally", "Castle", button)
                    'getting result of the messagebox
                    If result = System.Windows.Forms.DialogResult.Yes Then
                        GameForm1.whiterook(1).changeposition(x, y, prex, prey)
                        GameForm1.whiteking.changeposition(7, 6, 7, 4)
                        GameForm1.whiterook(1).AllowedToCastle = False
                        GameForm1.whiterook(0).AllowedToCastle = False
                        GameForm1.P1Timer.Stop()
                        If GameForm1.MinutesTextBox1.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox1.Text) <= 5 Then
                                GameForm1.SecondsTextBox1.Text += 2
                                GameForm1.SecondsTextBox1.Text = "0" & GameForm1.SecondsTextBox1.Text
                            End If
                        End If
                        GameForm1.P2Timer.Start()

                        recheckwhite() 'White cannot be in check if the pawn has moved
                        GameForm1.ga.recurrsionstop = False

                        player = 2
                        fillcheckforblack()
                        showcheck() 'Show the check if there is one
                        checkwinner()

                        If GameForm1.gameisoneplayer = True And gameflag = True Then

                            If GameForm1.EasyMode = True Then
                                AIMoving()
                            ElseIf GameForm1.HardMode = True Then
                                AIMovingHard()
                            End If
                        End If
                        Exit Sub
                    Else
                        If checkforwhite(7, 4) = False Then
                            GameForm1.whiterook(1).changeposition(x, y, prex, prey)
                            GameForm1.whiterook(1).AllowedToCastle = False
                            GameForm1.P1Timer.Stop()
                            If GameForm1.MinutesTextBox1.Text = "00" Then
                                If CInt(GameForm1.SecondsTextBox1.Text) <= 5 Then
                                    GameForm1.SecondsTextBox1.Text += 2
                                    GameForm1.SecondsTextBox1.Text = "0" & GameForm1.SecondsTextBox1.Text
                                End If
                            End If
                            GameForm1.P2Timer.Start()

                            recheckwhite() 'White cannot be in check if the pawn has moved
                            GameForm1.ga.recurrsionstop = False

                            player = 2
                            fillcheckforblack()
                            showcheck() 'Show the check if there is one
                            checkwinner()

                            If GameForm1.gameisoneplayer = True And gameflag = True Then

                                If GameForm1.EasyMode = True Then
                                    AIMoving()
                                ElseIf GameForm1.HardMode = True Then
                                    AIMovingHard()
                                End If
                            End If
                        ElseIf checkforwhite(7, 4) = True Then
                            'Cannot move there normally as king is in check
                            MessageBox.Show("King in check, cannot move Rook to F8")
                        End If
                        Exit Sub
                    End If
                End If

                For i As Integer = 0 To 1 + GameForm1.wrookcount
                    If GameForm1.whiterook(i).returnx = prex And GameForm1.whiterook(i).returny = prey Then
                        GameForm1.whiterook(i).changeposition(x, y, prex, prey)
                        GameForm1.whiterook(i).AllowedToCastle = False
                        'After a white rook has moved, if it has taken a black piece set its x and y values to 0

                        For L As Integer = 0 To GameForm1.bqueencount
                            If GameForm1.whiterook(i).xposition = GameForm1.blackqueen(L).xposition And GameForm1.whiterook(i).yposition = GameForm1.blackqueen(L).yposition Then
                                GameForm1.blackqueen(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.bknightcount
                            If GameForm1.whiterook(i).xposition = GameForm1.blackknight(L).xposition And GameForm1.whiterook(i).yposition = GameForm1.blackknight(L).yposition Then
                                GameForm1.blackknight(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.bbishopcount
                            If GameForm1.whiterook(i).xposition = GameForm1.blackbishop(L).xposition And GameForm1.whiterook(i).yposition = GameForm1.blackbishop(L).yposition Then
                                GameForm1.blackbishop(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.brookcount
                            If GameForm1.whiterook(i).xposition = GameForm1.blackrook(L).xposition And GameForm1.whiterook(i).yposition = GameForm1.blackrook(L).yposition Then
                                GameForm1.blackrook(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 7
                            If GameForm1.whiterook(i).xposition = GameForm1.blackpawn(L).xposition And GameForm1.whiterook(i).yposition = GameForm1.blackpawn(L).yposition Then
                                GameForm1.blackpawn(L).stillonboard = False
                            End If
                        Next
                        GameForm1.P1Timer.Stop()
                        If GameForm1.MinutesTextBox1.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox1.Text) <= 5 Then
                                GameForm1.SecondsTextBox1.Text += 2
                                GameForm1.SecondsTextBox1.Text = "0" & GameForm1.SecondsTextBox1.Text
                            End If
                        End If
                        GameForm1.P2Timer.Start()

                        recheckwhite() 'White cannot be in check if the pawn has moved
                        GameForm1.ga.recurrsionstop = False

                        player = 2
                        fillcheckforblack()
                        showcheck() 'Show the check if there is one

                        checkwinner()

                        If GameForm1.gameisoneplayer = True And gameflag = True Then

                            If GameForm1.EasyMode = True Then
                                AIMoving()
                            ElseIf GameForm1.HardMode = True Then
                                AIMovingHard()
                            End If
                        End If
                    End If
                Next

            Case "whitepawn"
                movecounter += 1
                GameForm1.MoveCounterTextBox.Text = movecounter
                For i As Integer = 0 To 7
                    If GameForm1.whitepawn(i).returnx = prex And GameForm1.whitepawn(i).returny = prey And board(x, y) <= 0 Then

                        GameForm1.whitepawn(i).changeposition(x, y, prex, prey)

                        'After a white pawn has moved, if it has taken a black piece set its x and y values to 0

                        For L As Integer = 0 To GameForm1.bqueencount
                            If GameForm1.whitepawn(i).xposition = GameForm1.blackqueen(L).xposition And GameForm1.whitepawn(i).yposition = GameForm1.blackqueen(L).yposition Then
                                GameForm1.blackqueen(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.bknightcount
                            If GameForm1.whitepawn(i).xposition = GameForm1.blackknight(L).xposition And GameForm1.whitepawn(i).yposition = GameForm1.blackknight(L).yposition Then
                                GameForm1.blackknight(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.bbishopcount
                            If GameForm1.whitepawn(i).xposition = GameForm1.blackbishop(L).xposition And GameForm1.whitepawn(i).yposition = GameForm1.blackbishop(L).yposition Then
                                GameForm1.blackbishop(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.brookcount
                            If GameForm1.whitepawn(i).xposition = GameForm1.blackrook(L).xposition And GameForm1.whitepawn(i).yposition = GameForm1.blackrook(L).yposition Then
                                GameForm1.blackrook(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 7
                            If GameForm1.whitepawn(i).xposition = GameForm1.blackpawn(L).xposition And GameForm1.whitepawn(i).yposition = GameForm1.blackpawn(L).yposition Then
                                GameForm1.blackpawn(L).stillonboard = False
                            End If
                        Next
                        GameForm1.P1Timer.Stop()
                        If GameForm1.MinutesTextBox1.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox1.Text) <= 5 Then
                                GameForm1.SecondsTextBox1.Text += 2
                                GameForm1.SecondsTextBox1.Text = "0" & GameForm1.SecondsTextBox1.Text
                            End If
                        End If
                        GameForm1.P2Timer.Start()

                        PawnPromotion()

                        recheckwhite() 'White cannot be in check if the pawn has moved
                        GameForm1.ga.recurrsionstop = False

                        player = 2
                        fillcheckforblack()
                        showcheck() 'Show the check if there is one

                        checkwinner()

                        If GameForm1.gameisoneplayer = True And gameflag = True Then
                            If GameForm1.EasyMode = True Then
                                AIMoving()
                            ElseIf GameForm1.HardMode = True Then
                                AIMovingHard()
                            End If
                        End If
                    End If

                Next


            Case "blackking"
                movecounter += 1
                GameForm1.MoveCounterTextBox.Text = movecounter
                If x = 0 And y = 2 And GameForm1.blackking.AllowedToCastle = True And GameForm1.blackrook(0).AllowedToCastle = True And castleincheck(0) = False And GameForm1.gameistwoplayer = True Then
                    Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
                    Dim result As DialogResult
                    'displaying MessageBox
                    result = MessageBox.Show("Are you sure you want castle", "Castle", button)
                    'getting result of the messagebox
                    If result = System.Windows.Forms.DialogResult.Yes Then
                        GameForm1.blackking.changeposition(x, y, prex, prey)
                        GameForm1.blackrook(0).changeposition(0, 3, 0, 0)
                        GameForm1.blackking.AllowedToCastle = False
                        GameForm1.blackrook(0).AllowedToCastle = False
                        GameForm1.blackrook(1).AllowedToCastle = False
                        GameForm1.P1Timer.Start()
                        GameForm1.P2Timer.Stop()
                        If GameForm1.MinutesTextBox2.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                                GameForm1.SecondsTextBox2.Text += 2
                                GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                            End If
                        End If

                        recheckwhite()
                        recheckblack() 'Black cannot be in check if the king has moved
                        showcheck() 'Show the check if there is one

                        player = 1
                        checkwinner()
                        Exit Sub
                    Else
                        movecounter -= 1
                        Exit Sub
                    End If
                ElseIf x = 0 And y = 2 And GameForm1.blackking.AllowedToCastle = True And GameForm1.blackrook(0).AllowedToCastle = True And castleincheck(0) = False And GameForm1.gameisoneplayer = True Then
                    'Making it so the AI castles without user promot
                    GameForm1.blackking.changeposition(x, y, prex, prey)
                    GameForm1.blackrook(0).changeposition(0, 3, 0, 0)
                    GameForm1.blackking.AllowedToCastle = False
                    GameForm1.blackrook(0).AllowedToCastle = False

                    GameForm1.P1Timer.Start()
                    GameForm1.P2Timer.Stop()
                    If GameForm1.MinutesTextBox2.Text = "00" Then
                        If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                            GameForm1.SecondsTextBox2.Text += 2
                            GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                        End If
                    End If
                    recheckwhite()
                    recheckblack() 'Black cannot be in check if the king has moved
                    showcheck() 'Show the check if there is one

                    player = 1
                    checkwinner()
                    Exit Sub
                End If
                If x = 0 And y = 6 And GameForm1.blackking.AllowedToCastle = True And GameForm1.blackrook(1).AllowedToCastle = True And castleincheck(1) = False And GameForm1.gameistwoplayer = True Then
                    Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
                    Dim result As DialogResult
                    'displaying MessageBox
                    result = MessageBox.Show("Are you sure you want castle", "Castle", button)
                    'getting result of the messagebox
                    If result = System.Windows.Forms.DialogResult.Yes Then
                        GameForm1.blackking.changeposition(x, y, prex, prey)
                        GameForm1.blackrook(1).changeposition(0, 5, 0, 7)
                        GameForm1.blackking.AllowedToCastle = False
                        GameForm1.blackrook(0).AllowedToCastle = False
                        GameForm1.blackrook(1).AllowedToCastle = False
                        GameForm1.P1Timer.Start()
                        GameForm1.P2Timer.Stop()
                        If GameForm1.MinutesTextBox2.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                                GameForm1.SecondsTextBox2.Text += 2
                                GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                            End If
                        End If
                        recheckwhite()
                        recheckblack() 'Black cannot be in check if the king has moved
                        showcheck() 'Show the check if there is one

                        player = 1
                        checkwinner()
                        Exit Sub
                    Else
                        movecounter -= 1
                        Exit Sub
                    End If
                ElseIf x = 0 And y = 6 And GameForm1.blackking.AllowedToCastle = True And GameForm1.blackrook(1).AllowedToCastle = True And castleincheck(1) = False And GameForm1.gameisoneplayer = True Then
                    'Making it so the AI castles without user prompt
                    GameForm1.blackking.changeposition(x, y, prex, prey)
                    GameForm1.blackrook(1).changeposition(0, 5, 0, 7)
                    GameForm1.blackking.AllowedToCastle = False
                    GameForm1.blackrook(1).AllowedToCastle = False
                    GameForm1.P1Timer.Start()
                    GameForm1.P2Timer.Stop()
                    If GameForm1.MinutesTextBox2.Text = "00" Then
                        If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                            GameForm1.SecondsTextBox2.Text += 2
                            GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                        End If
                    End If
                    recheckwhite()
                    recheckblack() 'Black cannot be in check if the king has moved
                    showcheck() 'Show the check if there is one

                    player = 1
                    checkwinner()
                    Exit Sub
                End If
                GameForm1.blackking.changeposition(x, y, prex, prey)
                GameForm1.blackking.AllowedToCastle = False
                'After a black king has moved, if it has taken a black piece set its x and y values to 0

                For L As Integer = 0 To GameForm1.wqueencount
                    If GameForm1.blackking.xposition = GameForm1.whitequeen(L).xposition And GameForm1.blackking.yposition = GameForm1.whitequeen(L).yposition Then
                        GameForm1.whitequeen(L).stillonboard = False
                    End If
                Next

                For L As Integer = 0 To 1 + GameForm1.wknightcount
                    If GameForm1.blackking.xposition = GameForm1.whiteknight(L).xposition And GameForm1.blackking.yposition = GameForm1.whiteknight(L).yposition Then
                        GameForm1.whiteknight(L).stillonboard = False
                    End If
                Next

                For L As Integer = 0 To 1 + GameForm1.wbishopcount
                    If GameForm1.blackking.xposition = GameForm1.whitebishop(L).xposition And GameForm1.blackking.yposition = GameForm1.whitebishop(L).yposition Then
                        GameForm1.whitebishop(L).stillonboard = False
                    End If
                Next

                For L As Integer = 0 To 1 + GameForm1.wrookcount
                    If GameForm1.blackking.xposition = GameForm1.whiterook(L).xposition And GameForm1.blackking.yposition = GameForm1.whiterook(L).yposition Then
                        GameForm1.whiterook(L).stillonboard = False
                    End If
                Next

                For L As Integer = 0 To 7
                    If GameForm1.blackking.xposition = GameForm1.whitepawn(L).xposition And GameForm1.blackking.yposition = GameForm1.whitepawn(L).yposition Then
                        GameForm1.whitepawn(L).stillonboard = False
                    End If
                Next
                GameForm1.P1Timer.Start()
                GameForm1.P2Timer.Stop()
                If GameForm1.MinutesTextBox2.Text = "00" Then
                    If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                        GameForm1.SecondsTextBox2.Text += 2
                        GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                    End If
                End If
                GameForm1.ga.recurrsionstop = False
                recheckwhite()
                recheckblack() 'Black cannot be in check if the king has moved
                showcheck() 'Show the check if there is one

                player = 1
                checkwinner()




            Case "blackqueen"
                movecounter += 1
                GameForm1.MoveCounterTextBox.Text = movecounter
                For i As Integer = 0 To GameForm1.bqueencount
                    If GameForm1.blackqueen(i).returnx = prex And GameForm1.blackqueen(i).returny = prey Then
                        GameForm1.blackqueen(i).changeposition(x, y, prex, prey)
                        'After a black queen has moved, if it has taken a black piece set its x and y values to 0

                        For L As Integer = 0 To GameForm1.wqueencount
                            If GameForm1.blackqueen(i).xposition = GameForm1.whitequeen(L).xposition And GameForm1.blackqueen(i).yposition = GameForm1.whitequeen(L).yposition Then
                                GameForm1.whitequeen(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wknightcount
                            If GameForm1.blackqueen(i).xposition = GameForm1.whiteknight(L).xposition And GameForm1.blackqueen(i).yposition = GameForm1.whiteknight(L).yposition Then
                                GameForm1.whiteknight(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wbishopcount
                            If GameForm1.blackqueen(i).xposition = GameForm1.whitebishop(L).xposition And GameForm1.blackqueen(i).yposition = GameForm1.whitebishop(L).yposition Then
                                GameForm1.whitebishop(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wrookcount
                            If GameForm1.blackqueen(i).xposition = GameForm1.whiterook(L).xposition And GameForm1.blackqueen(i).yposition = GameForm1.whiterook(L).yposition Then
                                GameForm1.whiterook(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 7
                            If GameForm1.blackqueen(i).xposition = GameForm1.whitepawn(L).xposition And GameForm1.blackqueen(i).yposition = GameForm1.whitepawn(L).yposition Then
                                GameForm1.whitepawn(L).stillonboard = False
                            End If
                        Next
                        GameForm1.P1Timer.Start()
                        GameForm1.P2Timer.Stop()
                        If GameForm1.MinutesTextBox2.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                                GameForm1.SecondsTextBox2.Text += 2
                                GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                            End If
                        End If
                        GameForm1.ga.recurrsionstop = False

                        player = 1
                        fillcheckforwhite()
                        recheckblack() 'Black cannot be in check if the king has moved
                        showcheck() 'Show the check if there is one

                        checkwinner()
                    End If
                Next

            Case "blackbishop"
                movecounter += 1
                GameForm1.MoveCounterTextBox.Text = movecounter
                For i As Integer = 0 To 1 + GameForm1.bbishopcount
                    If GameForm1.blackbishop(i).returnx = prex And GameForm1.blackbishop(i).returny = prey Then
                        GameForm1.blackbishop(i).changeposition(x, y, prex, prey)
                        'After a black bishop has moved, if it has taken a black piece set its x and y values to 0

                        For L As Integer = 0 To GameForm1.wqueencount

                            If GameForm1.blackbishop(i).xposition = GameForm1.whitequeen(L).xposition And GameForm1.blackbishop(i).yposition = GameForm1.whitequeen(L).yposition Then
                                GameForm1.whitequeen(L).stillonboard = False
                            End If

                        Next

                        For L As Integer = 0 To 1 + GameForm1.wknightcount
                            If GameForm1.blackbishop(i).xposition = GameForm1.whiteknight(L).xposition And GameForm1.blackbishop(i).yposition = GameForm1.whiteknight(L).yposition Then
                                GameForm1.whiteknight(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wbishopcount
                            If GameForm1.blackbishop(i).xposition = GameForm1.whitebishop(L).xposition And GameForm1.blackbishop(i).yposition = GameForm1.whitebishop(L).yposition Then
                                GameForm1.whitebishop(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wrookcount
                            If GameForm1.blackbishop(i).xposition = GameForm1.whiterook(L).xposition And GameForm1.blackbishop(i).yposition = GameForm1.whiterook(L).yposition Then
                                GameForm1.whiterook(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 7
                            If GameForm1.blackbishop(i).xposition = GameForm1.whitepawn(L).xposition And GameForm1.blackbishop(i).yposition = GameForm1.whitepawn(L).yposition Then
                                GameForm1.whitepawn(L).stillonboard = False
                            End If
                        Next
                        GameForm1.P1Timer.Start()
                        GameForm1.P2Timer.Stop()
                        If GameForm1.MinutesTextBox2.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                                GameForm1.SecondsTextBox2.Text += 2
                                GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                            End If
                        End If
                        GameForm1.ga.recurrsionstop = False

                        player = 1
                        fillcheckforwhite()
                        recheckblack() 'Black cannot be in check if the king has moved
                        showcheck() 'Show the check if there is one

                        checkwinner()
                    End If
                Next

            Case "blackknight"
                movecounter += 1
                GameForm1.MoveCounterTextBox.Text = movecounter
                For i As Integer = 0 To 1 + GameForm1.bknightcount
                    If GameForm1.blackknight(i).returnx = prex And GameForm1.blackknight(i).returny = prey Then
                        GameForm1.blackknight(i).changeposition(x, y, prex, prey)
                        'After a black knight has moved, if it has taken a black piece set its x and y values to 0

                        For L As Integer = 0 To GameForm1.wqueencount
                            If GameForm1.blackknight(i).xposition = GameForm1.whitequeen(L).xposition And GameForm1.blackknight(i).yposition = GameForm1.whitequeen(L).yposition Then
                                GameForm1.whitequeen(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wknightcount
                            If GameForm1.blackknight(i).xposition = GameForm1.whiteknight(L).xposition And GameForm1.blackknight(i).yposition = GameForm1.whiteknight(L).yposition Then
                                GameForm1.whiteknight(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wbishopcount
                            If GameForm1.blackknight(i).xposition = GameForm1.whitebishop(L).xposition And GameForm1.blackknight(i).yposition = GameForm1.whitebishop(L).yposition Then
                                GameForm1.whitebishop(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wrookcount
                            If GameForm1.blackknight(i).xposition = GameForm1.whiterook(L).xposition And GameForm1.blackknight(i).yposition = GameForm1.whiterook(L).yposition Then
                                GameForm1.whiterook(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 7
                            If GameForm1.blackknight(i).xposition = GameForm1.whitepawn(L).xposition And GameForm1.blackknight(i).yposition = GameForm1.whitepawn(L).yposition Then
                                GameForm1.whitepawn(L).stillonboard = False
                            End If
                        Next
                        GameForm1.P1Timer.Start()
                        GameForm1.P2Timer.Stop()
                        If GameForm1.MinutesTextBox2.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                                GameForm1.SecondsTextBox2.Text += 2
                                GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                            End If
                        End If
                        GameForm1.ga.recurrsionstop = False

                        player = 1
                        fillcheckforwhite()
                        recheckblack() 'Black cannot be in check if the king has moved
                        showcheck() 'Show the check if there is one

                        checkwinner()
                    End If
                Next

            Case "blackrook"
                movecounter += 1
                GameForm1.MoveCounterTextBox.Text = movecounter
                'First rook castle code
                If x = 0 And y = 3 And GameForm1.blackking.AllowedToCastle = True And GameForm1.blackrook(0).AllowedToCastle = True And castleincheck(0) = False And GameForm1.gameistwoplayer = True Then
                    Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
                    Dim result As DialogResult
                    'displaying MessageBox
                    result = MessageBox.Show("Select 'Yes' to Castle, Select 'No' to move there normally", "Castle", button)
                    'getting result of the messagebox
                    If result = System.Windows.Forms.DialogResult.Yes Then
                        GameForm1.blackrook(0).changeposition(x, y, prex, prey)
                        GameForm1.blackking.changeposition(0, 2, 0, 4)
                        GameForm1.blackrook(0).AllowedToCastle = False
                        GameForm1.blackrook(1).AllowedToCastle = False
                        GameForm1.blackking.AllowedToCastle = False
                        GameForm1.P1Timer.Start()
                        GameForm1.P2Timer.Stop()
                        If GameForm1.MinutesTextBox2.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                                GameForm1.SecondsTextBox2.Text += 2
                                GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                            End If
                        End If

                        GameForm1.ga.recurrsionstop = False

                        player = 1
                        fillcheckforwhite()
                        recheckblack() 'Black cannot be in check if the king has moved
                        showcheck() 'Show the check if there is one

                        checkwinner()
                        Exit Sub
                    Else
                        If checkforblack(0, 4) = False Then
                            GameForm1.blackrook(0).changeposition(x, y, prex, prey)
                            GameForm1.blackrook(0).AllowedToCastle = False
                            GameForm1.P1Timer.Start()
                            GameForm1.P2Timer.Stop()
                            If GameForm1.MinutesTextBox2.Text = "00" Then
                                If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                                    GameForm1.SecondsTextBox2.Text += 2
                                    GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                                End If
                            End If

                            GameForm1.ga.recurrsionstop = False

                            player = 1
                            fillcheckforwhite()
                            recheckblack() 'Black cannot be in check if the king has moved
                            showcheck() 'Show the check if there is one

                            checkwinner()
                        ElseIf checkforblack(0, 4) = True Then
                            'Cannot move there normally as king is in check
                            MessageBox.Show("King in check, cannot move Rook to D1")
                        End If
                        Exit Sub
                    End If
                ElseIf x = 0 And y = 3 And GameForm1.blackking.AllowedToCastle = True And GameForm1.blackrook(0).AllowedToCastle = True And castleincheck(0) = False And GameForm1.gameisoneplayer = True Then
                    'Making it so AI can castle without user prompt
                    GameForm1.blackrook(0).changeposition(x, y, prex, prey)
                    GameForm1.blackking.changeposition(0, 2, 0, 4)
                    GameForm1.blackrook(0).AllowedToCastle = False
                    GameForm1.blackking.AllowedToCastle = False
                    GameForm1.P1Timer.Start()
                    GameForm1.P2Timer.Stop()
                    If GameForm1.MinutesTextBox2.Text = "00" Then
                        If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                            GameForm1.SecondsTextBox2.Text += 2
                            GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                        End If
                    End If
                    GameForm1.ga.recurrsionstop = False

                    player = 1
                    fillcheckforwhite()
                    recheckblack() 'Black cannot be in check if the king has moved
                    showcheck() 'Show the check if there is one

                    checkwinner()
                    Exit Sub
                End If
                'Second rook castle code
                If x = 0 And y = 5 And GameForm1.blackking.AllowedToCastle = True And GameForm1.blackrook(1).AllowedToCastle = True And castleincheck(1) = False And GameForm1.gameistwoplayer = True Then
                    Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
                    Dim result As DialogResult
                    'displaying MessageBox
                    result = MessageBox.Show("Select 'Yes' to Castle, Select 'No' to move there normally", "Castle", button)
                    'getting result of the messagebox
                    If result = System.Windows.Forms.DialogResult.Yes Then
                        GameForm1.blackrook(1).changeposition(x, y, prex, prey)
                        GameForm1.blackking.changeposition(0, 6, 0, 4)
                        GameForm1.blackrook(1).AllowedToCastle = False
                        GameForm1.blackrook(0).AllowedToCastle = False
                        GameForm1.blackking.AllowedToCastle = False



                        GameForm1.P1Timer.Start()
                        GameForm1.P2Timer.Stop()
                        If GameForm1.MinutesTextBox2.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                                GameForm1.SecondsTextBox2.Text += 2
                                GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                            End If
                        End If
                        GameForm1.ga.recurrsionstop = False

                        player = 1
                        fillcheckforwhite()
                        recheckblack() 'Black cannot be in check if the king has moved
                        showcheck() 'Show the check if there is one

                        checkwinner()
                        Exit Sub
                    Else
                        If checkforblack(0, 4) = False Then
                            GameForm1.blackrook(1).changeposition(x, y, prex, prey)
                            GameForm1.blackrook(1).AllowedToCastle = False

                            GameForm1.P1Timer.Start()
                            GameForm1.P2Timer.Stop()
                            If GameForm1.MinutesTextBox2.Text = "00" Then
                                If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                                    GameForm1.SecondsTextBox2.Text += 2
                                    GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                                End If
                            End If

                            GameForm1.ga.recurrsionstop = False

                            player = 1
                            fillcheckforwhite()
                            recheckblack() 'Black cannot be in check if the king has moved
                            showcheck() 'Show the check if there is one

                            checkwinner()
                        ElseIf checkforblack(0, 4) = True Then
                            'Cannot move there normally as king is in check
                            MessageBox.Show("King in check, cannot move Rook to F8")
                        End If
                        Exit Sub
                    End If
                ElseIf x = 0 And y = 5 And GameForm1.blackking.AllowedToCastle = True And GameForm1.blackrook(1).AllowedToCastle = True And castleincheck(1) = False And GameForm1.gameisoneplayer = True Then
                    'Making it so AI can castle without user prompt
                    GameForm1.blackrook(1).changeposition(x, y, prex, prey)
                    GameForm1.blackking.changeposition(0, 6, 0, 4)
                    GameForm1.blackrook(1).AllowedToCastle = False
                    GameForm1.blackking.AllowedToCastle = False



                    GameForm1.P1Timer.Start()
                    GameForm1.P2Timer.Stop()
                    If GameForm1.MinutesTextBox2.Text = "00" Then
                        If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                            GameForm1.SecondsTextBox2.Text += 2
                            GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                        End If
                    End If
                    GameForm1.ga.recurrsionstop = False

                    player = 1
                    fillcheckforwhite()
                    recheckblack() 'Black cannot be in check if the king has moved
                    showcheck() 'Show the check if there is one

                    checkwinner()
                    Exit Sub
                End If

                For i As Integer = 0 To 1 + GameForm1.brookcount
                    If GameForm1.blackrook(i).returnx = prex And GameForm1.blackrook(i).returny = prey Then
                        GameForm1.blackrook(i).changeposition(x, y, prex, prey)
                        GameForm1.blackrook(i).AllowedToCastle = False
                        'After a black rook has moved, if it has taken a black piece set its x and y values to 0

                        For L As Integer = 0 To GameForm1.wqueencount
                            If GameForm1.blackrook(i).xposition = GameForm1.whitequeen(L).xposition And GameForm1.blackrook(i).yposition = GameForm1.whitequeen(L).yposition Then
                                GameForm1.whitequeen(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wknightcount
                            If GameForm1.blackrook(i).xposition = GameForm1.whiteknight(L).xposition And GameForm1.blackrook(i).yposition = GameForm1.whiteknight(L).yposition Then
                                GameForm1.whiteknight(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wbishopcount
                            If GameForm1.blackrook(i).xposition = GameForm1.whitebishop(L).xposition And GameForm1.blackrook(i).yposition = GameForm1.whitebishop(L).yposition Then
                                GameForm1.whitebishop(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wrookcount
                            If GameForm1.blackrook(i).xposition = GameForm1.whiterook(L).xposition And GameForm1.blackrook(i).yposition = GameForm1.whiterook(L).yposition Then
                                GameForm1.whiterook(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 7
                            If GameForm1.blackrook(i).xposition = GameForm1.whitepawn(L).xposition And GameForm1.blackrook(i).yposition = GameForm1.whitepawn(L).yposition Then
                                GameForm1.whitepawn(L).stillonboard = False
                            End If
                        Next
                        GameForm1.P1Timer.Start()
                        GameForm1.P2Timer.Stop()
                        If GameForm1.MinutesTextBox2.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                                GameForm1.SecondsTextBox2.Text += 2
                                GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                            End If
                        End If
                        GameForm1.ga.recurrsionstop = False



                        player = 1
                        fillcheckforwhite()
                        recheckblack() 'Black cannot be in check if the king has moved
                        showcheck() 'Show the check if there is one
                        checkwinner()


                    End If
                Next

            Case "blackpawn"
                movecounter += 1
                GameForm1.MoveCounterTextBox.Text = movecounter
                For i As Integer = 0 To 7
                    If GameForm1.blackpawn(i).returnx = prex And GameForm1.blackpawn(i).returny = prey And board(x, y) >= 0 Then
                        GameForm1.blackpawn(i).changeposition(x, y, prex, prey)
                        'After a black pawn has moved, if it has taken a black piece set its x and y values to 0

                        For L As Integer = 0 To GameForm1.wqueencount
                            If GameForm1.blackpawn(i).xposition = GameForm1.whitequeen(L).xposition And GameForm1.blackpawn(i).yposition = GameForm1.whitequeen(L).yposition Then
                                GameForm1.whitequeen(L).stillonboard = False
                            End If
                        Next



                        For L As Integer = 0 To 1 + GameForm1.wknightcount
                            If GameForm1.blackpawn(i).xposition = GameForm1.whiteknight(L).xposition And GameForm1.blackpawn(i).yposition = GameForm1.whiteknight(L).yposition Then
                                GameForm1.whiteknight(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wbishopcount
                            If GameForm1.blackpawn(i).xposition = GameForm1.whitebishop(L).xposition And GameForm1.blackpawn(i).yposition = GameForm1.whitebishop(L).yposition Then
                                GameForm1.whitebishop(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 1 + GameForm1.wrookcount
                            If GameForm1.blackpawn(i).xposition = GameForm1.whiterook(L).xposition And GameForm1.blackpawn(i).yposition = GameForm1.whiterook(L).yposition Then
                                GameForm1.whiterook(L).stillonboard = False
                            End If
                        Next

                        For L As Integer = 0 To 7
                            If GameForm1.blackpawn(i).xposition = GameForm1.whitepawn(L).xposition And GameForm1.blackpawn(i).yposition = GameForm1.whitepawn(L).yposition Then
                                GameForm1.whitepawn(L).stillonboard = False
                            End If
                        Next

                        GameForm1.P1Timer.Start()
                        GameForm1.P2Timer.Stop()
                        If GameForm1.MinutesTextBox2.Text = "00" Then
                            If CInt(GameForm1.SecondsTextBox2.Text) <= 5 Then
                                GameForm1.SecondsTextBox2.Text += 2
                                GameForm1.SecondsTextBox2.Text = "0" & GameForm1.SecondsTextBox2.Text
                            End If
                        End If
                        PawnPromotion()

                        GameForm1.ga.recurrsionstop = False

                        player = 1
                        fillcheckforwhite()
                        recheckblack() 'Black cannot be in check if the pawn has moved
                        showcheck() 'Show the check if there is one

                        checkwinner()
                    End If
                Next
            Case Else

        End Select
    End Sub
    Public Sub PawnPromotion()
        For i As Integer = 0 To 7
            If board(0, i) = 6 Then
                show()
                GameForm1.Enabled = False
                WPawnChangeForm.Show()
                Do
                    Application.DoEvents()
                Loop Until GameForm1.Enabled = True
            ElseIf board(7, i) = -6 Then
                If GameForm1.gameisoneplayer = True Then
                    GameForm1.bqueencount += 1
                    GameForm1.ga.board(7, i) = -2
                    GameForm1.blackqueen(GameForm1.bqueencount) = New Queen(7, i, -2)
                    show()
                    recurrsionstop = False
                    fillcheckforwhite()
                Else
                    show()
                    GameForm1.Enabled = False
                    BPawnChangeForm.Show()
                    Do
                        Application.DoEvents()
                    Loop Until GameForm1.Enabled = True
                End If
            End If
        Next
    End Sub
    Public Sub CastlingW()

        If GameForm1.whiteking.AllowedToCastle = True And GameForm1.whiterook(0).AllowedToCastle = True Then
            If board(7, 1) = 0 And board(7, 2) = 0 And board(7, 3) = 0 Then
                recurrsionstop = False
                fillcheckforwhite()
                If checkforwhite(7, 2) = False And GameForm1.whiterook(0).stillonboard = True Then
                    castleincheck(0) = False
                    GameForm1.whiteking.flags(7, 2) = True
                    GameForm1.whiterook(0).flags(7, 3) = True
                Else
                    castleincheck(0) = True
                End If
            End If
        End If

        If GameForm1.whiteking.AllowedToCastle = True And GameForm1.whiterook(1).AllowedToCastle = True Then
            If board(7, 5) = 0 And board(7, 6) = 0 Then
                recurrsionstop = False
                fillcheckforwhite()
                If checkforwhite(7, 6) = False And GameForm1.whiterook(1).stillonboard = True Then
                    castleincheck(1) = False
                    GameForm1.whiteking.flags(7, 6) = True
                    GameForm1.whiterook(1).flags(7, 5) = True
                Else
                    castleincheck(1) = True
                End If
            End If
        End If
    End Sub
    Public Sub CastlingB()
        If GameForm1.blackking.AllowedToCastle = True And GameForm1.blackrook(0).AllowedToCastle = True Then
            If board(0, 1) = 0 And board(0, 2) = 0 And board(0, 3) = 0 Then
                recurrsionstop = False
                fillcheckforblack()
                If checkforblack(0, 2) = False And GameForm1.blackrook(0).stillonboard = True Then
                    castleincheck(0) = False
                    GameForm1.blackking.flags(0, 2) = True
                    GameForm1.blackrook(0).flags(0, 3) = True
                Else
                    castleincheck(0) = True
                End If
            End If
        End If

        If GameForm1.blackking.AllowedToCastle = True And GameForm1.blackrook(1).AllowedToCastle = True Then
            If board(0, 5) = 0 And board(0, 6) = 0 Then
                recurrsionstop = False
                fillcheckforblack()
                If checkforblack(0, 6) = False And GameForm1.blackrook(1).stillonboard = True Then
                    castleincheck(1) = False
                    GameForm1.blackking.flags(0, 6) = True
                    GameForm1.blackrook(1).flags(0, 5) = True
                Else
                    castleincheck(1) = True
                End If
            End If
        End If
    End Sub

    Private Sub KingsOnly()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If board(i, j) = 0 Or board(i, j) = 1 Or board(i, j) = -1 Then
                    stalemate = True
                Else
                    stalemate = False
                    Exit Sub
                End If
            Next
        Next

    End Sub

    Public Sub StoreGameReplay()
        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult
        'displaying messagebox
        result = MessageBox.Show(LoginForm.Player1Username & ", would you like to store this replay?", "Storing Replay", button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim mystring As String
        Dim premove As String
        Dim premoveintotable As String = ""
        Dim move As String
        Dim moveintotable As String = ""

        'Setting database location
        Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
        'Openning connection
        Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
        Dim DBsource As String = "Data Source=" & dbfilename

        Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
        Dim sql As String
        Dim lines As Integer

        For lines = 0 To GameForm1.BoardTracker.Lines.Length - 1
            mystring = (Right(GameForm1.BoardTracker.Lines(lines).ToString, 7))
            premove = Left(mystring, 2)
            premoveintotable = premoveintotable & premove

            move = Right(mystring, 2)
            moveintotable = moveintotable & move
        Next

        Dim da As OleDbDataAdapter 'adapter
        Dim ds As New DataSet 'set used with adapter
        sql = "SELECT [Username],[PreMove1], [Move1], [PreMove2], [Move2], [PreMove3], [Move3], [PreMove4], [Move4], [PreMove5], [Move5] FROM [Table1]" 'SQL Statement
        da = New OleDbDataAdapter(sql, cn)
        cn.Open() 'Open connection
        da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
        Dim count As Integer

        Dim checkforemptyset As String
        Dim emptysetnumber As Integer
        For count = 0 To ds.Tables(0).Rows.Count - 1 'For loop for amount of users in table, (-1) as starts from 0
            If LoginForm.Player1Username = ds.Tables(0).Rows(count).Item(0) Then 'For player 1 stats

                For i As Integer = 2 To 10 Step 2
                    Try
                        checkforemptyset = ds.Tables(0).Rows(count).Item(i)
                    Catch ex As Exception
                        emptysetnumber = Int(i / 2)
                        Exit For
                    End Try
                Next
            End If
        Next

        cn.Close() 'Close connection

        If emptysetnumber = 0 Then
            Dim Message, Title, MyValue
            Do
                Message = "Enter a value between 1 and 5 (Replace Replay)"    ' Set prompt.
                Title = "Replay Replace"    ' Set title.
                ' Display message, title, and default value.
                MyValue = InputBox(Message, Title, "1")
                Try
                    MyValue = CInt(MyValue)
                Catch ex As Exception
                    MyValue = "10"
                End Try
            Loop Until MyValue >= 1 And MyValue <= 5
            emptysetnumber = MyValue
        End If

        sql = "update [Table1]"
        sql = sql & "SET [PreMove" & emptysetnumber & "] = '" & premoveintotable & "' "
        sql = sql & "WHERE [ID] = " & LoginForm.Player1ID & ";"
        Dim cmd As New OleDbCommand(sql, cn)
        cmd = New OleDbCommand(sql, cn)
        cn.Open() 'Open connection
        cmd.ExecuteNonQuery()
        cn.Close() 'Close connection

        sql = "update [Table1]"
        sql = sql & "SET [Move" & emptysetnumber & "] = '" & moveintotable & "' "
        sql = sql & "WHERE [ID] = " & LoginForm.Player1ID & ";"
        cmd = New OleDbCommand(sql, cn)
        cn.Open() 'Open connection
        cmd.ExecuteNonQuery()
        cn.Close() 'Close connection

    End Sub

    Private Sub AIMoving()
        Dim AIx(1) As Integer
        Dim AIy(1) As Integer
        Dim rnd As New Random
        'Easy mode, getting the computer to select a piece and random and randomly move it
        Do
            Do
                recanmove()
                AIx(0) = rnd.Next(0, 8)
                AIy(0) = rnd.Next(0, 8)
                selection(AIx(0), AIy(0))
            Loop Until board(AIx(0), AIy(0)) < 0

            Select Case board(AIx(0), AIy(0))
                Case -1
                    GameForm1.selectedpiece = ("blackking")
                    For i As Integer = 0 To 7
                        For j As Integer = 0 To 7
                            If GameForm1.blackking.flags(i, j) = True Then
                                Exit Do
                            End If
                        Next
                    Next
                Case -2
                    GameForm1.selectedpiece = ("blackqueen")
                    For i As Integer = 0 To 7
                        For j As Integer = 0 To 7
                            If GameForm1.blackqueen(z).flags(i, j) = True Then
                                Exit Do
                            End If
                        Next
                    Next
                Case -3
                    GameForm1.selectedpiece = ("blackbishop")
                    For i As Integer = 0 To 7
                        For j As Integer = 0 To 7
                            If GameForm1.blackbishop(z).flags(i, j) = True Then
                                Exit Do
                            End If
                        Next
                    Next
                Case -4
                    GameForm1.selectedpiece = "blackknight"
                    For i As Integer = 0 To 7
                        For j As Integer = 0 To 7
                            If GameForm1.blackknight(z).flags(i, j) = True Then
                                Exit Do
                            End If
                        Next
                    Next
                Case -5
                    GameForm1.selectedpiece = ("blackrook")
                    For i As Integer = 0 To 7
                        For j As Integer = 0 To 7
                            If GameForm1.blackrook(z).flags(i, j) = True Then
                                Exit Do

                            End If
                        Next
                    Next
                Case -6
                    GameForm1.selectedpiece = ("blackpawn")
                    For i As Integer = 0 To 7
                        For j As Integer = 0 To 7
                            If GameForm1.blackpawn(z).flags(i, j) = True Then
                                Exit Do
                            End If
                        Next
                    Next
            End Select
            recanmove()
            reback()
            GameForm1.selected = False
        Loop
        reback()
        Do
            AIx(1) = rnd.Next(0, 8)
            AIy(1) = rnd.Next(0, 8)
            If canmove(AIx(1), AIy(1)) = True Then
                mov(GameForm1.selectedpiece, AIx(1), AIy(1), AIx(0), AIy(0))
            End If
        Loop Until player = 1
        GameForm1.selected = False
        show()
    End Sub


    Dim six(5) As Integer
    Dim x(5) As Integer
    Dim y(5) As Integer
    Dim prex(5) As Integer
    Dim prey(5) As Integer
    Dim selected(5) As String
    Dim AICalculating As Boolean = False
    Private Sub AIMovingHard()
        AICalculating = True

        Dim DontRepeat As Boolean
        Dim PieceCanMove As Boolean

        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                GameForm1.pb(i, j).Enabled = False
            Next
        Next
        show()
        'Storing current board
        LoadTempBoard()
        'Changing it so when pieces move the board tracker does not add text
        canwritetoboardtracker = False

        'Black Pawn
        DontRepeat = True
        PieceCanMove = False
        '
        For i As Integer = 0 To 7
            '
            '
            Dim xpos As Integer = GameForm1.blackpawn(i).xposition
            Dim ypos As Integer = GameForm1.blackpawn(i).yposition
            '
            '
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    recurrsionstop = False
                    fillcheckforblack()
                    GameForm1.blackpawn(i).possiblemoves()
                    'If the pawn can move 
                    If GameForm1.blackpawn(i).flags(j, k) = True Then
                        PieceCanMove = True
                        'Changing posistion of the pawn
                        GameForm1.blackpawn(i).changeposition(j, k, GameForm1.blackpawn(i).xposition, GameForm1.blackpawn(i).yposition)
                        'Change the x and y position of the pawn (as write to board = false)
                        GameForm1.blackpawn(i).xposition = j
                        GameForm1.blackpawn(i).yposition = k

                        'Change player to 1
                        player = 1
                        'Second Depth
                        SecondDepth()

                        'See if white king is in check
                        fillcheckforwhite()

                        ' Code will always check the king
                        For a As Integer = 0 To 7
                            For b As Integer = 0 To 7
                                If checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True Then
                                    If canmove(GameForm1.blackpawn(i).xposition, GameForm1.blackpawn(i).yposition) = False Then
                                        ' If black Then can check the white king, -5 off Of q, (most post effective way, will check king unless the pawn can take a piece)
                                        q = q - 5
                                        AICheckmate()
                                    End If
                                End If
                            Next
                        Next

                        'Change player to 2
                        player = 2

                        'Change the x and y position of the pawn back to original
                        GameForm1.blackpawn(i).xposition = xpos
                        GameForm1.blackpawn(i).yposition = ypos

                        'Store point value if pawn moves there
                        If DontRepeat = True Then
                            six(0) = q
                            x(0) = j
                            y(0) = k
                            prex(0) = GameForm1.blackpawn(i).xposition
                            prey(0) = GameForm1.blackpawn(i).yposition
                            selected(0) = "blackpawn"
                            DontRepeat = False
                        Else
                            'Calculate random number (either a 0 or a 1)
                            Dim samemove As Integer
                            Dim rnd As New Random
                            samemove = rnd.Next(0, 2)
                            If q < six(0) Then
                                six(0) = q
                                x(0) = j
                                y(0) = k
                                prex(0) = GameForm1.blackpawn(i).xposition
                                prey(0) = GameForm1.blackpawn(i).yposition
                                selected(0) = "blackpawn"
                            End If
                            'If the maximum move is the same value as the one already stored, randomly choose a move
                            If q = six(0) And samemove = 1 Then
                                six(0) = q
                                x(0) = j
                                y(0) = k
                                prex(0) = GameForm1.blackpawn(i).xposition
                                prey(0) = GameForm1.blackpawn(i).yposition
                                selected(0) = "blackpawn"
                                DontRepeat = False
                            End If
                        End If

                        'Reset board back to original
                        Resetboard()
                    End If
                Next
            Next
        Next

        If PieceCanMove = False Then
            six(0) = 1000
        End If

        'Black Knight
        DontRepeat = True
        PieceCanMove = False
        '
        For i As Integer = 0 To 1 + GameForm1.bknightcount
            '
            '
            Dim xpos As Integer = GameForm1.blackknight(i).xposition
            Dim ypos As Integer = GameForm1.blackknight(i).yposition
            '
            '
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    recurrsionstop = False
                    fillcheckforblack()
                    GameForm1.blackknight(i).possiblemoves()
                    'If the knight can move 
                    If GameForm1.blackknight(i).flags(j, k) = True Then
                        PieceCanMove = True
                        'Changing posistion of the knight
                        GameForm1.blackknight(i).changeposition(j, k, GameForm1.blackknight(i).xposition, GameForm1.blackknight(i).yposition)
                        'Change the x and y position of the knight (as write to board = false)
                        GameForm1.blackknight(i).xposition = j
                        GameForm1.blackknight(i).yposition = k

                        'Change player to 1
                        player = 1
                        'Second Depth
                        SecondDepth()

                        'See if white king is in check
                        fillcheckforwhite()

                        ' Code will always check the king
                        For a As Integer = 0 To 7
                            For b As Integer = 0 To 7
                                If checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True Then
                                    If canmove(GameForm1.blackknight(i).xposition, GameForm1.blackknight(i).yposition) = False Then
                                        'If black can check the white king, - 5 off of q, (most post effective way, will check king unless the knight can take a piece)
                                        q = q - 5
                                        AICheckmate()
                                    End If
                                End If
                            Next
                        Next

                        'Change player to 2
                        player = 2

                        'Change the x and y position of the knight back to original
                        GameForm1.blackknight(i).xposition = xpos
                        GameForm1.blackknight(i).yposition = ypos

                        'Store point value if knight moves there
                        If DontRepeat = True Then
                            six(1) = q
                            x(1) = j
                            y(1) = k
                            prex(1) = GameForm1.blackknight(i).xposition
                            prey(1) = GameForm1.blackknight(i).yposition
                            selected(1) = "blackknight"
                            DontRepeat = False
                        Else
                            'Calculate random number (either a 0 or a 1)
                            Dim samemove As Integer
                            Dim rnd As New Random
                            samemove = rnd.Next(0, 2)
                            If q < six(1) Then
                                six(1) = q
                                x(1) = j
                                y(1) = k
                                prex(1) = GameForm1.blackknight(i).xposition
                                prey(1) = GameForm1.blackknight(i).yposition
                                selected(1) = "blackknight"
                            End If
                            'If the maximum move is the same value as the one already stored, randomly choose a move
                            If q = six(1) And samemove = 1 Then
                                six(1) = q
                                x(1) = j
                                y(1) = k
                                prex(1) = GameForm1.blackknight(i).xposition
                                prey(1) = GameForm1.blackknight(i).yposition
                                selected(1) = "blackknight"
                                DontRepeat = False
                            End If
                        End If

                        'Reset board back to original
                        Resetboard()
                    End If
                Next
            Next
        Next

        If PieceCanMove = False Then
            six(1) = 1000
        End If


        'Blak Queen
        DontRepeat = True
        PieceCanMove = False
        '
        For i As Integer = 0 To GameForm1.bqueencount
            '
            '
            Dim xpos As Integer = GameForm1.blackqueen(i).xposition
            Dim ypos As Integer = GameForm1.blackqueen(i).yposition
            '
            '
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    recurrsionstop = False
                    fillcheckforblack()
                    GameForm1.blackqueen(i).possiblemoves()
                    'If the queen can move 
                    If GameForm1.blackqueen(i).flags(j, k) = True Then
                        PieceCanMove = True
                        'Changing posistion of the queen
                        GameForm1.blackqueen(i).changeposition(j, k, GameForm1.blackqueen(i).xposition, GameForm1.blackqueen(i).yposition)
                        'Change the x and y position of the queen (as write to board = false)
                        GameForm1.blackqueen(i).xposition = j
                        GameForm1.blackqueen(i).yposition = k

                        'Change player to 1
                        player = 1
                        'Second Depth
                        SecondDepth()

                        'See if white king is in check
                        fillcheckforwhite()

                        'Code will always check the king
                        For a As Integer = 0 To 7
                            For b As Integer = 0 To 7
                                If checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True Then
                                    If canmove(GameForm1.blackqueen(i).xposition, GameForm1.blackqueen(i).yposition) = False Then
                                        '              'If black can check the white king, - 5 off of q, (most post effective way, will check king unless the queen can take a piece)
                                        q = q - 5
                                        AICheckmate()
                                    End If
                                End If
                            Next
                        Next

                        'Change player to 2
                        player = 2

                        'Change the x and y position of the queen back to original
                        GameForm1.blackqueen(i).xposition = xpos
                        GameForm1.blackqueen(i).yposition = ypos

                        'Store point value if queen moves there
                        If DontRepeat = True Then
                            six(2) = q
                            x(2) = j
                            y(2) = k
                            prex(2) = GameForm1.blackqueen(i).xposition
                            prey(2) = GameForm1.blackqueen(i).yposition
                            selected(2) = "blackqueen"
                            DontRepeat = False
                        Else
                            'Calculate random number (either a 0 or a 1)
                            Dim samemove As Integer
                            Dim rnd As New Random
                            samemove = rnd.Next(0, 2)
                            If q < six(2) Then
                                six(2) = q
                                x(2) = j
                                y(2) = k
                                prex(2) = GameForm1.blackqueen(i).xposition
                                prey(2) = GameForm1.blackqueen(i).yposition
                                selected(2) = "blackqueen"
                            End If
                            'If the maximum move is the same value as the one already stored, randomly choose a move
                            If q = six(2) And samemove = 1 Then
                                six(2) = q
                                x(2) = j
                                y(2) = k
                                prex(2) = GameForm1.blackqueen(i).xposition
                                prey(2) = GameForm1.blackqueen(i).yposition
                                selected(2) = "blackqueen"
                                DontRepeat = False
                            End If
                        End If

                        'Reset board back to original
                        Resetboard()
                    End If
                Next
            Next
        Next

        If PieceCanMove = False Then
            six(2) = 1000
        End If

        'Black Bishop
        DontRepeat = True
        PieceCanMove = False
        '
        For i As Integer = 0 To 1 + GameForm1.bbishopcount
            '
            '
            Dim xpos As Integer = GameForm1.blackbishop(i).xposition
            Dim ypos As Integer = GameForm1.blackbishop(i).yposition
            '
            '
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    recurrsionstop = False
                    fillcheckforblack()
                    GameForm1.blackbishop(i).possiblemoves()
                    'If the bishop can move 
                    If GameForm1.blackbishop(i).flags(j, k) = True Then
                        PieceCanMove = True
                        'Changing posistion of the bishop
                        GameForm1.blackbishop(i).changeposition(j, k, GameForm1.blackbishop(i).xposition, GameForm1.blackbishop(i).yposition)
                        'Change the x and y position of the bishop (as write to board = false)
                        GameForm1.blackbishop(i).xposition = j
                        GameForm1.blackbishop(i).yposition = k

                        'Change player to 1
                        player = 1
                        'Second Depth
                        SecondDepth()

                        'See if white king is in check
                        fillcheckforwhite()

                        'Code will always check the king
                        For a As Integer = 0 To 7
                            For b As Integer = 0 To 7
                                If checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True Then
                                    If canmove(GameForm1.blackbishop(i).xposition, GameForm1.blackbishop(i).yposition) = False Then
                                        'If black can check the white king, - 5 off of q, (most post effective way, will check king unless the bishop can take a piece)
                                        q = q - 5
                                        AICheckmate()
                                    End If
                                End If
                            Next
                        Next

                        'Change player to 2
                        player = 2

                        'Change the x and y position of the bishop back to original
                        GameForm1.blackbishop(i).xposition = xpos
                        GameForm1.blackbishop(i).yposition = ypos

                        'Store point value if bishop moves there
                        If DontRepeat = True Then
                            six(3) = q
                            x(3) = j
                            y(3) = k
                            prex(3) = GameForm1.blackbishop(i).xposition
                            prey(3) = GameForm1.blackbishop(i).yposition
                            selected(3) = "blackbishop"
                            DontRepeat = False
                        Else
                            'Calculate random number (either a 0 or a 1)
                            Dim samemove As Integer
                            Dim rnd As New Random
                            samemove = rnd.Next(0, 2)
                            If q < six(3) Then
                                six(3) = q
                                x(3) = j
                                y(3) = k
                                prex(3) = GameForm1.blackbishop(i).xposition
                                prey(3) = GameForm1.blackbishop(i).yposition
                                selected(3) = "blackbishop"
                            End If
                            'If the maximum move is the same value as the one already stored, randomly choose a move
                            If q = six(3) And samemove = 1 Then
                                six(3) = q
                                x(3) = j
                                y(3) = k
                                prex(3) = GameForm1.blackbishop(i).xposition
                                prey(3) = GameForm1.blackbishop(i).yposition
                                selected(3) = "blackbishop"
                                DontRepeat = False
                            End If
                        End If

                        'Reset board back to original
                        Resetboard()
                    End If
                Next
            Next

        Next

        If PieceCanMove = False Then
            six(3) = 1000
        End If


        'Black Rook
        DontRepeat = True
        PieceCanMove = False
        '
        For i As Integer = 0 To 1 + GameForm1.brookcount
            '
            '
            Dim xpos As Integer = GameForm1.blackrook(i).xposition
            Dim ypos As Integer = GameForm1.blackrook(i).yposition
            '
            '
            For j As Integer = 0 To 7
                For k As Integer = 0 To 7
                    recurrsionstop = False
                    fillcheckforblack()
                    GameForm1.blackrook(i).possiblemoves()
                    'If the rook can move 
                    If GameForm1.blackrook(i).flags(j, k) = True Then
                        PieceCanMove = True
                        'Changing posistion of the rook
                        GameForm1.blackrook(i).changeposition(j, k, GameForm1.blackrook(i).xposition, GameForm1.blackrook(i).yposition)
                        'Change the x and y position of the rook (as write to board = false)
                        GameForm1.blackrook(i).xposition = j
                        GameForm1.blackrook(i).yposition = k

                        'Change player to 1
                        player = 1
                        'Second Depth
                        SecondDepth()

                        'See if white king is in check
                        fillcheckforwhite()

                        'Code will always check the king
                        For a As Integer = 0 To 7
                            For b As Integer = 0 To 7
                                If checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True Then
                                    If canmove(GameForm1.blackrook(i).xposition, GameForm1.blackrook(i).yposition) = False Then
                                        'If black can check the white king, - 5 off of q, (most post effective way, will check king unless the rook can take a piece)
                                        q = q - 5
                                        AICheckmate()
                                    End If
                                End If
                            Next
                        Next

                        'Change player to 2
                        player = 2

                        'Change the x and y position of the rook back to original
                        GameForm1.blackrook(i).xposition = xpos
                        GameForm1.blackrook(i).yposition = ypos
                        'Store point value if rook moves there
                        If DontRepeat = True Then
                            six(4) = q
                            x(4) = j
                            y(4) = k
                            prex(4) = GameForm1.blackrook(i).xposition
                            prey(4) = GameForm1.blackrook(i).yposition
                            selected(4) = "blackrook"
                            DontRepeat = False
                        Else
                            'Calculate random number (either a 0 or a 1)
                            Dim samemove As Integer
                            Dim rnd As New Random
                            samemove = rnd.Next(0, 2)
                            If q < six(4) Then
                                six(4) = q
                                x(4) = j
                                y(4) = k
                                prex(4) = GameForm1.blackrook(i).xposition
                                prey(4) = GameForm1.blackrook(i).yposition
                                selected(4) = "blackrook"
                            End If
                            'If the maximum move is the same value as the one already stored, randomly choose a move
                            If q = six(4) And samemove = 1 Then
                                six(4) = q
                                x(4) = j
                                y(4) = k
                                prex(4) = GameForm1.blackrook(i).xposition
                                prey(4) = GameForm1.blackrook(i).yposition
                                selected(4) = "blackrook"
                                DontRepeat = False
                            End If
                        End If

                        'Reset board back to original
                        Resetboard()
                    End If
                Next
            Next
        Next

        If PieceCanMove = False Then
            six(4) = 1000
        End If

        'Black King
        DontRepeat = True
        PieceCanMove = False
        '
        '
        Dim xposking As Integer = GameForm1.blackking.xposition
        Dim yposking As Integer = GameForm1.blackking.yposition
        '
        '
        For j As Integer = 0 To 7
            For k As Integer = 0 To 7
                recurrsionstop = False
                fillcheckforblack()
                GameForm1.blackking.possiblemoves()
                'If the king can move 
                If GameForm1.blackking.flags(j, k) = True Then
                    PieceCanMove = True
                    'Changing posistion of the king
                    GameForm1.blackking.changeposition(j, k, GameForm1.blackking.xposition, GameForm1.blackking.yposition)
                    'Change the x and y position of the king (as write to board = false)
                    GameForm1.blackking.xposition = j
                    GameForm1.blackking.yposition = k

                    'Change player to 1
                    player = 1
                    'Second Depth
                    SecondDepth()

                    'Change player to 2
                    player = 2

                    'Change the x and y position of the king back to original
                    GameForm1.blackking.xposition = xposking
                    GameForm1.blackking.yposition = yposking

                    'Store point value if king moves there
                    If DontRepeat = True Then
                        six(5) = q
                        x(5) = j
                        y(5) = k
                        prex(5) = GameForm1.blackking.xposition
                        prey(5) = GameForm1.blackking.yposition
                        selected(5) = "blackking"
                        DontRepeat = False
                    Else
                        'Calculate random number (either a 0 or a 1)
                        Dim samemove As Integer
                        Dim rnd As New Random
                        samemove = rnd.Next(0, 2)
                        If q < six(5) Then
                            six(5) = q
                            x(5) = j
                            y(5) = k
                            prex(5) = GameForm1.blackking.xposition
                            prey(5) = GameForm1.blackking.yposition
                            selected(5) = "blackking"
                        End If
                        'If the maximum move is the same value as the one already stored, randomly choose a move
                        If q = six(5) And samemove = 1 Then
                            six(5) = q
                            x(5) = j
                            y(5) = k
                            prex(5) = GameForm1.blackking.xposition
                            prey(5) = GameForm1.blackking.yposition
                            selected(5) = "blackking"
                            DontRepeat = False
                        End If
                    End If

                    'Reset board back to original
                    Resetboard()
                End If
            Next
        Next

        If PieceCanMove = False Then
            six(5) = 1000
        End If

        canwritetoboardtracker = True
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                GameForm1.pb(i, j).Enabled = True
            Next
        Next
        Resetboard()
        show()
        reback()
        'Bubble sort algorithm for deciding best move
        Dim iTemp As Integer
        Dim iTemp1 As String
        For iPass = 1 To 4
            For i As Integer = 0 To 4
                If six(i) < six(i + 1) Then
                    iTemp = six(i)
                    six(i) = six(i + 1)
                    six(i + 1) = iTemp
                    iTemp = x(i)
                    x(i) = x(i + 1)
                    x(i + 1) = iTemp
                    iTemp = y(i)
                    y(i) = y(i + 1)
                    y(i + 1) = iTemp
                    iTemp = prex(i)
                    prex(i) = prex(i + 1)
                    prex(i + 1) = iTemp
                    iTemp = prey(i)
                    prey(i) = prey(i + 1)
                    prey(i + 1) = iTemp
                    iTemp1 = selected(i)
                    selected(i) = selected(i + 1)
                    selected(i + 1) = iTemp1
                End If
            Next
        Next

        Dim random As Integer = -1
        Dim rndd As New Random
        'if multiple moves have the same minimum losing value, randomly select one 
        'ignore king due to chess logic
        If six(5) = six(4) Then
            random = 4
            If six(4) = six(3) Then
                random = rndd.Next(3, 5)
                If six(3) = six(2) Then
                    random = rndd.Next(2, 5)
                    If six(2) = six(1) Then
                        random = rndd.Next(1, 5)
                        If six(1) = six(0) Then
                            random = rndd.Next(0, 5)
                        End If
                    End If
                End If
            End If
        End If
        AICalculating = False

        If random = -1 Then
            mov(selected(5), x(5), y(5), prex(5), prey(5))
        Else
            mov(selected(random), x(random), y(random), prex(random), prey(random))
        End If
    End Sub

    Dim tempboard(7, 7) As Integer
    Dim points As Integer
    Dim count As Integer = 0

    Private Sub SecondDepth()
        LoadSecondDepthBoard()

        recurrsionstop = False
        fillcheckforwhite()
        recanmove()
        Application.DoEvents()
        'Reset count
        count = 0

        'Move all the white pawns into all possible positions
        For i As Integer = 0 To 7
            If GameForm1.whitepawn(i).stillonboard = False Then
                GameForm1.whitepawn(i).reflags()
            Else

                If board(GameForm1.whitepawn(i).xposition, GameForm1.whitepawn(i).yposition) = 6 Then
                    GameForm1.whitepawn(i).possiblemoves()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            'If the pawn can move 
                            If GameForm1.whitepawn(i).flags(j, k) = True Then
                                'Move to that square

                                GameForm1.whitepawn(i).changeposition(j, k, GameForm1.whitepawn(i).xposition, GameForm1.whitepawn(i).yposition)
                                'Reset board back to before 2nd depth move was made
                                CalculateBoardPoints()

                                ResetSecondDepthBoard()
                            End If
                        Next
                    Next

                    GameForm1.whitepawn(i).fillcheckking()

                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            'If the pawn can move 
                            If GameForm1.whitepawn(i).flags(j, k) = True Then
                                canmove(j, k) = True
                            End If
                        Next
                    Next
                End If
            End If
        Next

        'Move all the white knights into all possible positions
        For i As Integer = 0 To 1 + GameForm1.wknightcount
            If GameForm1.whiteknight(i).stillonboard = False Then
                GameForm1.whiteknight(i).reflags()
            Else

                If board(GameForm1.whiteknight(i).xposition, GameForm1.whiteknight(i).yposition) = 4 Then
                    GameForm1.whiteknight(i).possiblemoves()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            'If the knight can move 
                            If GameForm1.whiteknight(i).flags(j, k) = True Then
                                'Move to that square
                                GameForm1.whiteknight(i).changeposition(j, k, GameForm1.whiteknight(i).xposition, GameForm1.whiteknight(i).yposition)
                                'Reset board back to before 2nd depth move was made
                                CalculateBoardPoints()

                                If GameForm1.whiteknight(i).flags(j, k) = True Then
                                    canmove(j, k) = True
                                End If
                                ResetSecondDepthBoard()
                                recurrsionstop = False
                                fillcheckforwhite()
                            End If
                        Next
                    Next
                End If
            End If
        Next


        'Move all the white queens into all possible positions
        For i As Integer = 0 To GameForm1.wqueencount
            If GameForm1.whitequeen(i).stillonboard = False Then
                GameForm1.whitequeen(i).reflags()
            Else
                If board(GameForm1.whitequeen(i).xposition, GameForm1.whitequeen(i).yposition) = 2 Then
                    GameForm1.whitequeen(i).possiblemoves()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            'If the queen can move 
                            If GameForm1.whitequeen(i).flags(j, k) = True Then
                                'Move to that square
                                GameForm1.whitequeen(i).changeposition(j, k, GameForm1.whitequeen(i).xposition, GameForm1.whitequeen(i).yposition)
                                'Reset board back to before 2nd depth move was made
                                CalculateBoardPoints()
                                'TESTING
                                If GameForm1.whitequeen(i).flags(j, k) = True Then
                                    canmove(j, k) = True
                                End If
                                ResetSecondDepthBoard()
                                recurrsionstop = False
                                fillcheckforwhite()
                            End If
                        Next
                    Next
                End If
            End If
        Next

        'Move all the white bishops into all possible positions

        For i As Integer = 0 To 1 + GameForm1.wbishopcount
            If GameForm1.whitebishop(i).stillonboard = False Then
                GameForm1.whitebishop(i).reflags()
            Else
                If board(GameForm1.whitebishop(i).xposition, GameForm1.whitebishop(i).yposition) = 3 Then
                    GameForm1.whitebishop(i).possiblemoves()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            'If the bishop can move 
                            If GameForm1.whitebishop(i).flags(j, k) = True Then
                                'Move to that square
                                GameForm1.whitebishop(i).changeposition(j, k, GameForm1.whitebishop(i).xposition, GameForm1.whitebishop(i).yposition)
                                'Reset board back to before 2nd depth move was made
                                CalculateBoardPoints()

                                If GameForm1.whitebishop(i).flags(j, k) = True Then
                                    canmove(j, k) = True
                                End If

                                ResetSecondDepthBoard()
                                recurrsionstop = False
                                fillcheckforwhite()
                            End If
                        Next
                    Next
                End If
            End If
        Next


        'Move all the white rook into all possible positions

        For i As Integer = 0 To 1 + GameForm1.wrookcount
            If GameForm1.whiterook(i).stillonboard = False Then
                GameForm1.whiterook(i).reflags()
            Else
                If board(GameForm1.whiterook(i).xposition, GameForm1.whiterook(i).yposition) = 5 Then
                    GameForm1.whiterook(i).possiblemoves()
                    For j As Integer = 0 To 7
                        For k As Integer = 0 To 7
                            'If the rook can move 
                            If GameForm1.whiterook(i).flags(j, k) = True Then
                                'Move to that square
                                GameForm1.whiterook(i).changeposition(j, k, GameForm1.whiterook(i).xposition, GameForm1.whiterook(i).yposition)
                                'Reset board back to before 2nd depth move was made
                                CalculateBoardPoints()
                                'TESTIng
                                If GameForm1.whiterook(i).flags(j, k) = True Then
                                    canmove(j, k) = True
                                End If
                                ResetSecondDepthBoard()
                                recurrsionstop = False
                                fillcheckforwhite()
                            End If
                        Next
                    Next

                End If
            End If
        Next

        'Move all the white king into all possible positions

        GameForm1.whiteking.possiblemoves()
        For j As Integer = 0 To 7
            For k As Integer = 0 To 7
                'If the king can move 
                If GameForm1.whiteking.flags(j, k) = True Then

                    'Move to that square
                    GameForm1.whiteking.changeposition(j, k, GameForm1.whiteking.xposition, GameForm1.whiteking.yposition)
                    'Reset board back to before 2nd depth move was made
                    CalculateBoardPoints()
                    ResetSecondDepthBoard()
                    recurrsionstop = False
                    fillcheckforwhite()
                End If
            Next
        Next

        GameForm1.whiteking.fillcheckking()

        For j As Integer = 0 To 7
            For k As Integer = 0 To 7
                'If the pawn can move 
                If GameForm1.whiteking.flags(j, k) = True Then
                    canmove(j, k) = True
                End If
            Next
        Next
    End Sub
    Private Sub LoadTempBoard()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                tempboard(i, j) = board(i, j)
            Next
        Next
    End Sub

    Private Sub Resetboard()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                board(i, j) = tempboard(i, j)
            Next
        Next
    End Sub
    Dim tempboard2(7, 7) As Integer
    Private Sub LoadSecondDepthBoard()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                tempboard2(i, j) = board(i, j)
            Next
        Next
    End Sub
    Private Sub ResetSecondDepthBoard()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                board(i, j) = tempboard2(i, j)
            Next
        Next
    End Sub

    Dim q As Integer 'Used in minmax algorithm, minimum loss move

    Private Sub CalculateBoardPoints()
        count = count + 1
        points = 0
        'Calculation 
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                Select Case board(i, j)
                    Case 1
                        'King = 900 points
                        points += 900
                    Case 2
                        'Queen = 90 points
                        points += 90
                    Case 3
                        'Bishop = 30 points
                        points += 30
                    Case 4
                        'Knight = 30 points
                        points += 30
                    Case 5
                        'Rook = 50 points
                        points += 50
                    Case 6
                        'Pawn = 10 point
                        points += 10
                    Case -1
                        'King = -900 points
                        points += -900
                    Case -2
                        'Queen = -90 points
                        points += -90
                    Case -3
                        'Bishop = -30 points
                        points += -30
                    Case -4
                        'Knight = -30 points
                        points += -30
                    Case -5
                        'Rook = -50 points
                        points += -50
                    Case -6
                        'Pawn = -10 point
                        points += -10
                End Select
            Next
        Next

        If count = 1 Then
            q = points
        End If

        If points > q Then
            q = points
        End If

    End Sub
    Private Sub AICheckmate()
        Dim AIcancheckmate As Boolean = False
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If canmove(i, j) = False Then
                    AIcancheckmate = True
                Else
                    AIcancheckmate = False
                End If
            Next
        Next

        If AIcancheckmate = True Then
            q = q - 100
        End If
    End Sub
End Class