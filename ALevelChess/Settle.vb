Imports System.Threading
Imports System.Data.OleDb
Imports System.Data
Public Class Settle
    Dim P1Choice As Boolean = False
    Dim P2Choice As Boolean = False
    Dim WantToSettle(1) As Boolean
    Dim WantToNotSettle(1) As Boolean
    Private Sub Settle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Disable form
        GameForm1.Enabled = False
        'Make timers stop
        GameForm1.P1Timer.Stop()
        GameForm1.P2Timer.Stop()
    End Sub

    Private Sub P1Yes_Click(sender As Object, e As EventArgs) Handles P1Yes.Click
        'Make picture visible and display Tick
        Player1Box.BackgroundImage = Nothing
        Player1Box.Visible = True
        P1Choice = True
        WantToSettle(0) = True
        P1Yes.Hide()
        P1No.Hide()
        DecideSettle()
    End Sub

    Private Sub P1No_Click(sender As Object, e As EventArgs) Handles P1No.Click
        'Make picture visible and display Cross
        Player1Box.Image = Nothing
        Player1Box.Visible = True
        P1Choice = True
        WantToNotSettle(0) = True
        P1Yes.Hide()
        P1No.Hide()
        DecideSettle()
    End Sub

    Private Sub P2Yes_Click(sender As Object, e As EventArgs) Handles P2Yes.Click
        'Make picture visible and display Tick
        Player2Box.BackgroundImage = Nothing
        Player2Box.Visible = True
        P2Choice = True
        WantToSettle(1) = True
        P2Yes.Hide()
        P2No.Hide()
        DecideSettle()
    End Sub

    Private Sub P2No_Click(sender As Object, e As EventArgs) Handles P2No.Click
        'Make picture visible and display Cross
        Player2Box.Image = Nothing
        Player2Box.Visible = True
        P2Choice = True
        WantToNotSettle(1) = True
        P2Yes.Hide()
        P2No.Hide()
        DecideSettle()
    End Sub

    Private Sub DecideSettle()
        If P1Choice = True And P2Choice = True Then
            'Sleeping system so the users can see result of settle
            My.Application.DoEvents()
            Thread.Sleep(1000)
            If WantToSettle(0) = True And WantToSettle(1) = True Then
                SettleAgreed()
            Else
                MessageBox.Show("Settle Denied")
                If GameForm1.ga.movecounter Mod 2 = 0 Then
                    GameForm1.P1Timer.Start()
                Else
                    GameForm1.P2Timer.Start()
                End If
            End If
            'Show form
            GameForm1.Enabled = True
            GameForm1.Show()

            Me.Close()
        End If
    End Sub

    Public Sub SettleAgreed()
        GameForm1.ga.gameflag = False
        If GameForm1.ga.stalemate = True Then
            MessageBox.Show("Stalemate - Draw")
        Else
            MessageBox.Show("Settle Agreed - Draw")
        End If
        'Hiding Buttons
        GameForm1.P1SettleButton.Visible = False
        GameForm1.P2SettleButton.Visible = False
        GameForm1.P1ResignButton.Visible = False
        GameForm1.P2ResignButton.Visible = False

        'Getting both users stats for draws and storing them temporarily
        Dim Player1Draws As Integer
        Dim Player2Draws As Integer

        'Setting database location
        Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
        'Openning connection
        Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
        Dim DBsource As String = "Data Source=" & dbfilename

        Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
        Dim da As OleDbDataAdapter 'adapter
        Dim ds As New DataSet 'set used with adapter
        Dim sql As String
        sql = "SELECT [Username],[Draws] FROM [Table1]" 'SQL Statement
        da = New OleDbDataAdapter(sql, cn)
        cn.Open() 'Open connection
        da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
        Dim count As Integer


        For count = 0 To ds.Tables(0).Rows.Count - 1 'For loop for amount of users in table, (-1) as starts from 0
            If LoginForm.Player1Username = ds.Tables(0).Rows(count).Item(0) Then 'For player 1 stats
                Player1Draws = ds.Tables(0).Rows(count).Item(1)
            ElseIf MultiplayerForm.Player2Username = ds.Tables(0).Rows(count).Item(0) Then 'For player 2 stats
                Player2Draws = ds.Tables(0).Rows(count).Item(1)
            End If
        Next

        cn.Close() 'Close connection

        'Updating the database with the new P1 user stats
        Dim cmd As New OleDbCommand(sql, cn)
        sql = "update [Table1]"
        sql = sql & "SET [Draws] = '" & Player1Draws + 1 & "' "
        sql = sql & "WHERE [ID] = " & LoginForm.Player1ID & ";"
        cmd = New OleDbCommand(sql, cn)
        cn.Open() 'Open connection
        cmd.ExecuteNonQuery()
        cn.Close() 'Close connection


        'Updating the database with the new P2 user stats
        sql = "update [Table1]"
        sql = sql & "SET [Draws] = '" & Player2Draws + 1 & "' "
        sql = sql & "WHERE [ID] = " & MultiplayerForm.Player2ID & ";"
        cmd = New OleDbCommand(sql, cn)
        cn.Open() 'Open connection
        cmd.ExecuteNonQuery()
        cn.Close() 'Close connection
        'Disable game
        GameForm1.ga.gameflag = False
        GameForm1.gamestarted = False
        'Hide buttons
        GameForm1.P1ResignButton.Hide()
        GameForm1.P1SettleButton.Hide()
        GameForm1.P2ResignButton.Hide()
        GameForm1.P2SettleButton.Hide()

        GameForm1.ga.StoreGameReplay()
        GameForm1.P1Timer.Stop()
        GameForm1.P2Timer.Stop()
    End Sub
End Class