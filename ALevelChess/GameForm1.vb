Imports System.Data.OleDb
Imports System.Data

Public Class GameForm1
    'Chess pieces:
    '1) Pawn
    '2) Bishop
    '3) Rook
    '4) Knight
    '5) Queen
    '6) King

    Public pb(7, 7) As PictureBox
    Public whiteking As King
    Public whitequeen(8) As Queen '1 Queen to start, 8 other possible queens due to pawn promotions
    Public whitebishop(9) As Bishop '2 Bishops to start, 8 other possible bishops due to pawn promotions
    Public whiteknight(9) As Knight '2 Knights to start, 8 other possible knights due to pawn promotions
    Public whitepawn(7) As Pawn
    Public whiterook(9) As Rook '2 Rooks to start, 8 other possible rooks due to pawn promotions
    Public blackking As King
    Public blackqueen(8) As Queen '1 Queen to start, 8 other possible queens due to pawn promotions
    Public blackbishop(9) As Bishop '2 Bishops to start, 8 other possible bishops due to pawn promotions
    Public blackknight(9) As Knight  '2 Knights to start, 8 other possible knights due to pawn promotions
    Public blackpawn(7) As Pawn
    Public blackrook(9) As Rook '2 Rooks to start, 8 other possible rooks due to pawn promotions
    'Count in case of pawn promotion
    Public wqueencount As Integer = 0
    Public wbishopcount As Integer = 0
    Public wknightcount As Integer = 0
    Public wrookcount As Integer = 0
    Public bqueencount As Integer = 0
    Public bbishopcount As Integer = 0
    Public bknightcount As Integer = 0
    Public brookcount As Integer = 0

    Public playerssettle As Boolean

    Public ga As Game
    Public x, y, selectionx, selectiony As Integer
    Public selected As Boolean = False
    Public allowgametostart As Boolean = False
    Public gamestarted As Boolean = False
    Public selectedpiece As String = Nothing
    'Code for piece sets
    Public Set1 As Boolean = False
    Public Set2 As Boolean = False
    Public Set3 As Boolean = False
    'Code for AI
    Public gameistwoplayer As Boolean = False
    Public gameisoneplayer As Boolean = False
    Public EasyMode As Boolean = False
    Public HardMode As Boolean = False

    Private Sub GameForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Loading player 1 name
        Player1Label.Text = LoginForm.Player1Username
        'Loading player 2 username
        Player2Label.Text = MultiplayerForm.Player2Username
        'Making sure buttons not needed arent visible
        RestartButton.Visible = False
        'Give board tracker properties
        BoardTracker.Multiline = True
        BoardTracker.ScrollBars = ScrollBars.Vertical
        'Setting times to 00
        MinutesTextBox1.AppendText("00")
        SecondsTextBox1.AppendText("00")
        MinutesTextBox2.AppendText("00")
        SecondsTextBox2.AppendText("00")
        'Loading User 1 And User 2 profile pictures
        'Setting database location
        Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
        'Openning connection
        Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
        Dim DBsource As String = "Data Source=" & dbfilename

        Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
        Dim da As OleDbDataAdapter 'adapter
        Dim ds As New DataSet 'set used with adapter
        Dim sql As String
        sql = "SELECT [Username],[ProfilePicture],[BoardColour],[PieceType] FROM [Table1]" 'SQL Statement
        Dim cmd As New OleDbCommand(sql, cn)
        da = New OleDbDataAdapter(sql, cn)
        cn.Open() 'Open connection
        da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
        Dim count As Integer


        For count = 0 To ds.Tables(0).Rows.Count - 1 'For loop for amount of users in table, (-1) as starts from 0
            If Player1Label.Text = ds.Tables(0).Rows(count).Item(0) Then 'For player 1 profile picture (for a user that has signed in)
                Select Case (ds.Tables(0).Rows(count).Item(1))
                    Case "Default"
                        P1ProfilePicture.Image = My.Resources.DefaultSkin
                    Case "Skin1"
                        P1ProfilePicture.Image = My.Resources.Skin1
                    Case "Skin2"
                        P1ProfilePicture.Image = My.Resources.Skin2
                    Case "Skin3"
                        P1ProfilePicture.Image = My.Resources.Skin3
                    Case "Skin4"
                        P1ProfilePicture.Image = My.Resources.Skin4
                    Case "Skin5"
                        P1ProfilePicture.Image = My.Resources.Skin5
                    Case "Skin6"
                        P1ProfilePicture.Image = My.Resources.Skin6
                    Case "Skin7"
                        P1ProfilePicture.Image = My.Resources.Skin7
                    Case "Locked1"
                        P1ProfilePicture.Image = My.Resources.Locked1
                    Case "Locked2"
                        P1ProfilePicture.Image = My.Resources.Locked2
                    Case "Locked3"
                        P1ProfilePicture.Image = My.Resources.Locked3
                    Case "Locked4"
                        P1ProfilePicture.Image = My.Resources.Locked4
                    Case "Locked5"
                        P1ProfilePicture.Image = My.Resources.Locked5
                    Case "Locked6"
                        P1ProfilePicture.Image = My.Resources.Locked6
                    Case "Locked7"
                        P1ProfilePicture.Image = My.Resources.Locked7
                    Case "Locked8"
                        P1ProfilePicture.Image = My.Resources.Locked8
                End Select
                Select Case (ds.Tables(0).Rows(count).Item(2))
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
                Select Case (ds.Tables(0).Rows(count).Item(3))
                    Case "Set1"
                        Set1 = True
                    Case "Set2"
                        Set2 = True
                    Case "Set3"
                        Set3 = True
                End Select
            ElseIf Player2Label.Text = ds.Tables(0).Rows(count).Item(0) Then 'For player 2 profile picture (for a user that has signed in)
                Select Case (ds.Tables(0).Rows(count).Item(1))
                    Case "Default"
                        P2ProfilePicture.Image = My.Resources.DefaultSkin
                    Case "Skin1"
                        P2ProfilePicture.Image = My.Resources.Skin1
                    Case "Skin2"
                        P2ProfilePicture.Image = My.Resources.Skin2
                    Case "Skin3"
                        P2ProfilePicture.Image = My.Resources.Skin3
                    Case "Skin4"
                        P2ProfilePicture.Image = My.Resources.Skin4
                    Case "Skin5"
                        P2ProfilePicture.Image = My.Resources.Skin5
                    Case "Skin6"
                        P2ProfilePicture.Image = My.Resources.Skin6
                    Case "Skin7"
                        P2ProfilePicture.Image = My.Resources.Skin7
                    Case "Locked1"
                        P2ProfilePicture.Image = My.Resources.Locked1
                    Case "Locked2"
                        P2ProfilePicture.Image = My.Resources.Locked2
                    Case "Locked3"
                        P2ProfilePicture.Image = My.Resources.Locked3
                    Case "Locked4"
                        P2ProfilePicture.Image = My.Resources.Locked4
                    Case "Locked5"
                        P2ProfilePicture.Image = My.Resources.Locked5
                    Case "Locked6"
                        P2ProfilePicture.Image = My.Resources.Locked6
                    Case "Locked7"
                        P2ProfilePicture.Image = My.Resources.Locked7
                    Case "Locked8"
                        P2ProfilePicture.Image = My.Resources.Locked8
                End Select
            Else
                P2ProfilePicture.Image = My.Resources.DefaultSkin 'Default profile picture for a guest (Or AI)
            End If
        Next
        cn.Close() 'Close connection

        'Creating picture boxes as an array
        pb = New PictureBox(7, 7) {{Me.p00, Me.p01, Me.p02, Me.p03, Me.p04, Me.p05, Me.p06, Me.p07},
            {Me.p10, Me.p11, Me.p12, Me.p13, Me.p14, Me.p15, Me.p16, Me.p17},
            {Me.p20, Me.p21, Me.p22, Me.p23, Me.p24, Me.p25, Me.p26, Me.p27},
            {Me.p30, Me.p31, Me.p32, Me.p33, Me.p34, Me.p35, Me.p36, Me.p37},
            {Me.p40, Me.p41, Me.p42, Me.p43, Me.p44, Me.p45, Me.p46, Me.p47},
            {Me.p50, Me.p51, Me.p52, Me.p53, Me.p54, Me.p55, Me.p56, Me.p57},
            {Me.p60, Me.p61, Me.p62, Me.p63, Me.p64, Me.p65, Me.p66, Me.p67},
            {Me.p70, Me.p71, Me.p72, Me.p73, Me.p74, Me.p75, Me.p76, Me.p77}}
        'Creating all objects
        allobjects()
        ga.show()
    End Sub


    Private Sub TimeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TimeComboBox.SelectedIndexChanged
        'If a time has been selected, copy it to both players time textboxes, and allow the game to start
        If TimeComboBox.Text = "Unlimited" Then
            MinutesTextBox1.Text = "∞"
            MinutesTextBox2.Text = "∞"
            SecondsTextBox1.Text = "∞"
            SecondsTextBox2.Text = "∞"
            allowgametostart = True
        ElseIf TimeComboBox.Text = "2 Minutes" Then
            MinutesTextBox1.Text = "02"
            MinutesTextBox2.Text = "02"
            SecondsTextBox1.Text = "00"
            SecondsTextBox2.Text = "00"
            allowgametostart = True
        ElseIf TimeComboBox.Text = "5 Minutes" Then
            MinutesTextBox1.Text = "05"
            MinutesTextBox2.Text = "05"
            SecondsTextBox1.Text = "00"
            SecondsTextBox2.Text = "00"
            allowgametostart = True
        ElseIf TimeComboBox.Text = "10 Minutes" Then
            MinutesTextBox1.Text = "10"
            MinutesTextBox2.Text = "10"
            SecondsTextBox1.Text = "00"
            SecondsTextBox2.Text = "00"
            allowgametostart = True
        ElseIf TimeComboBox.Text = "20 Minutes" Then
            MinutesTextBox1.Text = "20"
            MinutesTextBox2.Text = "20"
            SecondsTextBox1.Text = "00"
            SecondsTextBox2.Text = "00"
            allowgametostart = True
        ElseIf TimeComboBox.Text = "30 Minutes" Then
            MinutesTextBox1.Text = "30"
            MinutesTextBox2.Text = "30"
            SecondsTextBox1.Text = "00"
            SecondsTextBox2.Text = "00"
            allowgametostart = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles P1Timer.Tick
        If SecondsTextBox1.Text = 0 And MinutesTextBox1.Text = 0 Then
            'If timer reaches 0 disable timers
            P1Timer.Enabled = False
            P2Timer.Enabled = False
            ga.gameflag = False
            gamestarted = False
            'Hide buttons
            P1ResignButton.Hide()
            P1SettleButton.Hide()
            P2ResignButton.Hide()
            P2SettleButton.Hide()

            'Display winner
            MsgBox("Ran out of time, " & Player2Label.Text & " is the winner!")
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

            ga.StoreGameReplay()

        ElseIf SecondsTextBox1.Text = 0 Then
            MinutesTextBox1.Text -= 1
            For i = 0 To 9
                If MinutesTextBox1.Text = i Then
                    MinutesTextBox1.Text = "0" & i
                End If
            Next
        End If
        If P1Timer.Enabled = True Then
            If SecondsTextBox1.Text > 0 Then
                SecondsTextBox1.Text -= 1
                For i = 0 To 9
                    If SecondsTextBox1.Text = i Then
                        SecondsTextBox1.Text = "0" & i
                    End If
                Next
            ElseIf SecondsTextBox1.Text = 0 Then
                SecondsTextBox1.Text = 59
            End If
        End If
    End Sub

    Private Sub P2Timer_Tick(sender As Object, e As EventArgs) Handles P2Timer.Tick
        If SecondsTextBox2.Text = 0 And MinutesTextBox2.Text = 0 Then
            'If timer reaches 0 disable timers
            P1Timer.Enabled = False
            P2Timer.Enabled = False
            ga.gameflag = False
            gamestarted = False
            'Hide buttons
            P1ResignButton.Hide()
            P1SettleButton.Hide()
            P2ResignButton.Hide()
            P2SettleButton.Hide()

            'Display winner
            MsgBox("Ran out of time, " & Player1Label.Text & " is the winner!")
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

            ga.StoreGameReplay()

        ElseIf SecondsTextBox2.Text = 0 Then
            MinutesTextBox2.Text -= 1
            For i = 0 To 9
                If MinutesTextBox2.Text = i Then
                    MinutesTextBox2.Text = "0" & i
                End If
            Next
        Else

        End If
        If P2Timer.Enabled = True Then
            If SecondsTextBox2.Text > 0 Then
                SecondsTextBox2.Text -= 1
                For i = 0 To 9
                    If SecondsTextBox2.Text = i Then
                        SecondsTextBox2.Text = "0" & i
                    End If
                Next
            ElseIf SecondsTextBox2.Text = 0 Then
                SecondsTextBox2.Text = 59
            End If
        End If
    End Sub
    Private Sub StartGameButton_Click(sender As Object, e As EventArgs) Handles StartGameButton.Click
        gamestarted = True 'trigger starting of game

        If allowgametostart = False Then 'If no time limit has been selected then you cannot start the game
            MsgBox("Please select a time limit")
        Else 'If time limit has been selected then run the program
            TimeLimitLabel.Visible = False
            TimeComboBox.Visible = False 'User cannot change the time during the game running
            P1Timer.Start() 'Starting the P1 timer as white is always first
            RestartButton.Visible = True 'If the game is started user has an option to restart the game whenever they want
            StartGameButton.Visible = False 'If the game is started hide the button, after restart button is pressed it shall show up again

            allobjects() 'loading in all of the pieces into the array to be used
            ga.recanmove()
            ga.show()
            ga.reback()
            ga.recheckblack()
            ga.recheckwhite()
        End If
    End Sub
    Private Sub RestartButton_Click(sender As Object, e As EventArgs) Handles RestartButton.Click
        P1Timer.Stop()
        P2Timer.Stop()
        BoardTracker.Text = ("")
        StartGameButton.Visible = True
        P1ResignButton.Visible = False
        P2ResignButton.Visible = False
        P1SettleButton.Visible = False
        P2SettleButton.Visible = False

        TimeComboBox.SelectedIndex = -1
        TimeComboBox.Visible = True
        TimeLimitLabel.Visible = True
        SecondsTextBox1.Text = "00"
        SecondsTextBox2.Text = "00"
        MinutesTextBox1.Text = "00"
        MinutesTextBox2.Text = "00"
        MoveCounterTextBox.Text = ""
        'Game has stoppped
        gamestarted = False
        'Get rid of back
        ga.reback()
        'Create new pieces and game
        allobjects()
        'Display pieces 
        ga.show()
        'Game is not allowed to start until time has been selected again
        allowgametostart = False
        gamestarted = False
        'Reset count of pieces
        wqueencount = 0
        wbishopcount = 0
        wknightcount = 0
        wrookcount = 0
        bqueencount = 0
        bbishopcount = 0
        bknightcount = 0
        brookcount = 0

    End Sub

    Private Sub MoveCounterTextBox_TextChanged(sender As Object, e As EventArgs) Handles MoveCounterTextBox.TextChanged
        If MoveCounterTextBox.Text = "1" Then
            P1ResignButton.Visible = True 'If the game is started the player has the option to resign the win
            If gameistwoplayer = True Then
                P2ResignButton.Visible = True 'If the game is started the player has the option to resign the win
                P2SettleButton.Visible = True 'Settle for player 2
                P1SettleButton.Visible = True 'If game started allow option for players to sette
            End If
        End If
    End Sub

    Private Sub P1ResignButton_Click(sender As Object, e As EventArgs) Handles P1ResignButton.Click
        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult

        'stopping timers
        P1Timer.Stop()
        P2Timer.Stop()
        'displaying messagebox
        result = MessageBox.Show("Are you sure you want to resign", "Player 1 Resigning", button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.Yes Then
            'Game has ended, player 2 has one
            'Stop game
            ga.gameflag = False
            gamestarted = False
            'Hide buttons
            P1ResignButton.Hide()
            P1SettleButton.Hide()
            P2ResignButton.Hide()
            P2SettleButton.Hide()

            'Display winner
            MessageBox.Show("Resigned, " & Player2Label.Text & " is the winner!")
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

            ga.StoreGameReplay()
        ElseIf result = System.Windows.Forms.DialogResult.No Then
            If ga.movecounter Mod 2 = 0 Then
                P1Timer.Start()
            Else
                P2Timer.Start()
            End If
        End If
    End Sub

    Private Sub P2ResignButton_Click(sender As Object, e As EventArgs) Handles P2ResignButton.Click
        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult

        'stop timers
        P1Timer.Stop()
        P2Timer.Stop()
        'displaying messagebox
        result = MessageBox.Show("Are you sure you want to resign", "Player 2 Resigning", button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.Yes Then
            'Game has ended, player 1 has one
            ga.gameflag = False
            gamestarted = False
            'Hide buttons
            P1ResignButton.Hide()
            P1SettleButton.Hide()
            P2ResignButton.Hide()
            P2SettleButton.Hide()

            'Display winner
            MessageBox.Show("Resigned, " & Player1Label.Text & " is the winner!")
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


            ga.StoreGameReplay()

        ElseIf result = System.Windows.Forms.DialogResult.No Then
            If ga.movecounter Mod 2 = 0 Then
                P1Timer.Start()
            Else
                P2Timer.Start()
            End If
        End If
    End Sub

    Private Sub P1SettleButton_Click(sender As Object, e As EventArgs) Handles P1SettleButton.Click, P2SettleButton.Click
        Settle.Show()
    End Sub

    Private Sub ReturnLabel_Click(sender As Object, e As EventArgs)
        Application.DoEvents()
        'Pause timers
        P1Timer.Stop()
        P2Timer.Stop()

        Dim button As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult
        'displaying messagebox
        result = MessageBox.Show("Are you sure you want return to the main menu?", "Main Menu", button)
        'getting result of the messagebox
        If result = System.Windows.Forms.DialogResult.Yes Then
            'Show main menu form
            MainMenu.Show()
            'Close current form
            Me.Close()
            'Close Multiplayer Menu Form (as we don't need the data from it anymore)
            MultiplayerForm.Close()
        Else
            'Resume timers if game is started
            If gamestarted = True Then
                If ga.movecounter Mod 2 = 0 Then
                    P1Timer.Start()
                Else
                    P2Timer.Start()
                End If
            End If
        End If
    End Sub

    Public Sub allobjects()
        blackpawn(0) = New Pawn(1, 0, -6)
        blackpawn(1) = New Pawn(1, 1, -6)
        blackpawn(2) = New Pawn(1, 2, -6)
        blackpawn(3) = New Pawn(1, 3, -6)
        blackpawn(4) = New Pawn(1, 4, -6)
        blackpawn(5) = New Pawn(1, 5, -6)
        blackpawn(6) = New Pawn(1, 6, -6)
        blackpawn(7) = New Pawn(1, 7, -6)
        blackrook(0) = New Rook(0, 0, -5)
        blackrook(1) = New Rook(0, 7, -5)
        blackknight(0) = New Knight(0, 1, -4)
        blackknight(1) = New Knight(0, 6, -4)
        blackbishop(0) = New Bishop(0, 2, -3)
        blackbishop(1) = New Bishop(0, 5, -3)
        blackking = New King(0, 4, -1)
        blackqueen(0) = New Queen(0, 3, -2)

        whitepawn(0) = New Pawn(6, 0, 6)
        whitepawn(1) = New Pawn(6, 1, 6)
        whitepawn(2) = New Pawn(6, 2, 6)
        whitepawn(3) = New Pawn(6, 3, 6)
        whitepawn(4) = New Pawn(6, 4, 6)
        whitepawn(5) = New Pawn(6, 5, 6)
        whitepawn(6) = New Pawn(6, 6, 6)
        whitepawn(7) = New Pawn(6, 7, 6)
        whiterook(0) = New Rook(7, 0, 5)
        whiterook(1) = New Rook(7, 7, 5)
        whiteknight(0) = New Knight(7, 1, 4)
        whiteknight(1) = New Knight(7, 6, 4)
        whitebishop(0) = New Bishop(7, 2, 3)
        whitebishop(1) = New Bishop(7, 5, 3)
        whiteking = New King(7, 4, 1)
        whitequeen(0) = New Queen(7, 3, 2)
        ga = New Game
    End Sub

    Private Sub p00_Click(sender As Object, e As EventArgs) Handles p00.Click, P2ProfilePicture.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 0
            y = 0
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then 'if selected is true and piece can move there then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony) 'move selected piece, from x y to selection x, y
                End If
                selected = False

                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If

    End Sub

    Private Sub p01_Click(sender As Object, e As EventArgs) Handles p01.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 0
            y = 1
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p02_Click(sender As Object, e As EventArgs) Handles p02.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 0
            y = 2
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else

                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p03_Click(sender As Object, e As EventArgs) Handles p03.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 0
            y = 3
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p04_Click(sender As Object, e As EventArgs) Handles p04.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 0
            y = 4
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p05_Click(sender As Object, e As EventArgs) Handles p05.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 0
            y = 5
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p06_Click(sender As Object, e As EventArgs) Handles p06.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 0
            y = 6
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p07_Click(sender As Object, e As EventArgs) Handles p07.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 0
            y = 7
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p10_Click(sender As Object, e As EventArgs) Handles p10.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 1
            y = 0

            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If

                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If

    End Sub

    Private Sub p11_Click(sender As Object, e As EventArgs) Handles p11.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 1
            y = 1
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p12_Click(sender As Object, e As EventArgs) Handles p12.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 1
            y = 2
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p13_Click(sender As Object, e As EventArgs) Handles p13.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 1
            y = 3
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p14_Click(sender As Object, e As EventArgs) Handles p14.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 1
            y = 4
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p15_Click(sender As Object, e As EventArgs) Handles p15.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 1
            y = 5
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p16_Click(sender As Object, e As EventArgs) Handles p16.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 1
            y = 6
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p17_Click(sender As Object, e As EventArgs) Handles p17.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 1
            y = 7
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True

            Else

                If ga.canmove(x, y) = True Then

                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If


                selected = False
                ga.show()
            End If

        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p20_Click(sender As Object, e As EventArgs) Handles p20.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 2
            y = 0
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p21_Click(sender As Object, e As EventArgs) Handles p21.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 2
            y = 1
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p22_Click(sender As Object, e As EventArgs) Handles p22.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 2
            y = 2
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True

            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p23_Click(sender As Object, e As EventArgs) Handles p23.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 2
            y = 3
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p24_Click(sender As Object, e As EventArgs) Handles p24.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 2
            y = 4
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If

        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p25_Click(sender As Object, e As EventArgs) Handles p25.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 2
            y = 5
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p26_Click(sender As Object, e As EventArgs) Handles p26.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 2
            y = 6
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p27_Click(sender As Object, e As EventArgs) Handles p27.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 2
            y = 7
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p30_Click(sender As Object, e As EventArgs) Handles p30.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 3
            y = 0
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p31_Click(sender As Object, e As EventArgs) Handles p31.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 3
            y = 1
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p32_Click(sender As Object, e As EventArgs) Handles p32.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 3
            y = 2
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p33_Click(sender As Object, e As EventArgs) Handles p33.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 3
            y = 3
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p34_Click(sender As Object, e As EventArgs) Handles p34.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 3
            y = 4
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p35_Click(sender As Object, e As EventArgs) Handles p35.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 3
            y = 5
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p36_Click(sender As Object, e As EventArgs) Handles p36.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 3
            y = 6
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p37_Click(sender As Object, e As EventArgs) Handles p37.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 3
            y = 7
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p40_Click(sender As Object, e As EventArgs) Handles p40.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 4
            y = 0
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p41_Click(sender As Object, e As EventArgs) Handles p41.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 4
            y = 1
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p42_Click(sender As Object, e As EventArgs) Handles p42.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 4
            y = 2
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p43_Click(sender As Object, e As EventArgs) Handles p43.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 4
            y = 3
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p44_Click(sender As Object, e As EventArgs) Handles p44.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 4
            y = 4
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p45_Click(sender As Object, e As EventArgs) Handles p45.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 4
            y = 5
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p46_Click(sender As Object, e As EventArgs) Handles p46.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 4
            y = 6
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p47_Click(sender As Object, e As EventArgs) Handles p47.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 4
            y = 7
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p50_Click(sender As Object, e As EventArgs) Handles p50.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 5
            y = 0
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p51_Click(sender As Object, e As EventArgs) Handles p51.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 5
            y = 1
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p52_Click(sender As Object, e As EventArgs) Handles p52.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 5
            y = 2
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p53_Click(sender As Object, e As EventArgs) Handles p53.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 5
            y = 3
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p54_Click(sender As Object, e As EventArgs) Handles p54.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 5
            y = 4
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p55_Click(sender As Object, e As EventArgs) Handles p55.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 5
            y = 5
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p56_Click(sender As Object, e As EventArgs) Handles p56.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 5
            y = 6
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p57_Click(sender As Object, e As EventArgs) Handles p57.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 5
            y = 7
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p60_Click(sender As Object, e As EventArgs) Handles p60.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 6
            y = 0
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p61_Click(sender As Object, e As EventArgs) Handles p61.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 6
            y = 1
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p62_Click(sender As Object, e As EventArgs) Handles p62.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 6
            y = 2
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p63_Click(sender As Object, e As EventArgs) Handles p63.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 6
            y = 3
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p64_Click(sender As Object, e As EventArgs) Handles p64.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 6
            y = 4
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p65_Click(sender As Object, e As EventArgs) Handles p65.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 6
            y = 5
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p66_Click(sender As Object, e As EventArgs) Handles p66.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 6
            y = 6
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p67_Click(sender As Object, e As EventArgs) Handles p67.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 6
            y = 7
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p70_Click(sender As Object, e As EventArgs) Handles p70.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 7
            y = 0
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p71_Click(sender As Object, e As EventArgs) Handles p71.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 7
            y = 1
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p72_Click(sender As Object, e As EventArgs) Handles p72.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 7
            y = 2
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p73_Click(sender As Object, e As EventArgs) Handles p73.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 7
            y = 3
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p74_Click(sender As Object, e As EventArgs) Handles p74.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 7
            y = 4
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p75_Click(sender As Object, e As EventArgs) Handles p75.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 7
            y = 5
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p76_Click(sender As Object, e As EventArgs) Handles p76.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 7
            y = 6
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub

    Private Sub p77_Click(sender As Object, e As EventArgs) Handles p77.Click
        If (gamestarted = True And gameistwoplayer = True) Or (gamestarted = True And ga.player = 1) Then
            ga.reback()
            x = 7
            y = 7
            If selected <> True Then
                ga.recanmove()
                selectedpiece = ga.selection(x, y)
                selectionx = x
                selectiony = y
                selected = True
            Else
                If ga.canmove(x, y) = True Then
                    ga.mov(selectedpiece, x, y, selectionx, selectiony)
                End If
                selected = False
                ga.show()
            End If
        ElseIf gamestarted = False Then
            MessageBox.Show("Game needs to be started before using the board")
        End If
    End Sub
End Class