Imports System.Data.OleDb
Imports System.Data
Public Class CustomisationForm
    Dim Skinname As String
    Dim BoardColour As String
    Dim PieceType As String
    Private Sub CustomisationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StatsCalculator()
        'As stats have been calculated, check if any unlockable profile pictures can be chosen
        If Winstxt.Text >= 1 Then
            'Making image available
            Locked1Box.Enabled = True
            Locked1Box.Image = Nothing
            'Editing the text
            U1WinLabel.ForeColor = Color.Green
            U1WinLabel.Text = "Unlocked"
        End If

        If Winstxt.Text >= 2 Then
            'Making images available
            Locked2Box.Enabled = True
            Locked2Box.Image = Nothing
            'Editing the text
            U2WinLabel.ForeColor = Color.Green
            U2WinLabel.Text = "Unlocked"
        End If

        If Winstxt.Text >= 3 Then
            'Making images available
            Locked3Box.Enabled = True
            Locked3Box.Image = Nothing
            'Editing the text
            U3WinLabel.ForeColor = Color.Green
            U3WinLabel.Text = "Unlocked"
        End If

        If Winstxt.Text >= 4 Then
            'Making images available
            Locked4Box.Enabled = True
            Locked4Box.Image = Nothing
            'Editing the text
            U4WinLabel.ForeColor = Color.Green
            U4WinLabel.Text = "Unlocked"
        End If

        If Winstxt.Text >= 5 Then
            'Making images available
            Locked5Box.Enabled = True
            Locked5Box.Image = Nothing
            'Editing the text
            U5WinLabel.ForeColor = Color.Green
            U5WinLabel.Text = "Unlocked"
        End If

        If Winstxt.Text >= 6 Then
            'Making images available
            Locked6Box.Enabled = True
            Locked6Box.Image = Nothing
            'Editing the text
            U6WinLabel.ForeColor = Color.Green
            U6WinLabel.Text = "Unlocked"
        End If

        If Winstxt.Text >= 7 Then
            'Making images available
            Locked7Box.Enabled = True
            Locked7Box.Image = Nothing
            'Editing the text
            U7WinLabel.ForeColor = Color.Green
            U7WinLabel.Text = "Unlocked"
        End If

        If Winstxt.Text >= 8 Then
            'Making images available
            Locked8Box.Enabled = True
            Locked8Box.Image = Nothing
            'Editing the text
            U8WinLabel.ForeColor = Color.Green
            U8WinLabel.Text = "Unlocked"
        End If

        'Load current board and piece selection 
        'Setting database location
        Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
        'Openning connection
        Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
        Dim DBsource As String = "Data Source=" & dbfilename

        Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
        Dim da As OleDbDataAdapter 'adapter
        Dim ds As New DataSet 'set used with adapter
        Dim sql As String
        sql = "SELECT [Username],[BoardColour], [PieceType], [ProfilePicture] FROM [Table1]" 'SQL Statement
        Dim cmd As New OleDbCommand(sql, cn)
        da = New OleDbDataAdapter(sql, cn)
        cn.Open() 'Open connection
        da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
        Dim count As Integer


        For count = 0 To ds.Tables(0).Rows.Count - 1 'For loop for amount of users in table, (-1) as starts from 0
            If LoginForm.Player1Username = ds.Tables(0).Rows(count).Item(0) Then 'For player 1 profile picture (for a user that has signed in)
                BoardColour = ds.Tables(0).Rows(count).Item(1)
                PieceType = ds.Tables(0).Rows(count).Item(2)
                Select Case (ds.Tables(0).Rows(count).Item(1))
                    Case "YellowBoard"
                        SelectedBoardBox.Image = My.Resources.YellowBoardPreview
                    Case "GreenBoard"
                        SelectedBoardBox.Image = My.Resources.GreenBoardPreview
                    Case "PinkBoard"
                        SelectedBoardBox.Image = My.Resources.PinkBoardPreview
                    Case "RedBoard"
                        SelectedBoardBox.Image = My.Resources.RedBoardPreview
                    Case "BlueBoard"
                        SelectedBoardBox.Image = My.Resources.BlueBoardPreview
                End Select
                Select Case (ds.Tables(0).Rows(count).Item(2))
                    Case "Set1"
                        SelectedPieceBox.Image = My.Resources.Set1KnightW
                    Case "Set2"
                        SelectedPieceBox.Image = My.Resources.Set2KnightW
                    Case "Set3"
                        SelectedPieceBox.Image = My.Resources.Set3KnightW
                End Select
                Select Case (ds.Tables(0).Rows(count).Item(3))
                    Case "Default"
                        MainMenu.ProfilePicture.Image = My.Resources.DefaultSkin
                    Case "Skin1"
                        MainMenu.ProfilePicture.Image = My.Resources.Skin1
                    Case "Skin2"
                        MainMenu.ProfilePicture.Image = My.Resources.Skin2
                    Case "Skin3"
                        MainMenu.ProfilePicture.Image = My.Resources.Skin3
                    Case "Skin4"
                        MainMenu.ProfilePicture.Image = My.Resources.Skin4
                    Case "Skin5"
                        MainMenu.ProfilePicture.Image = My.Resources.Skin5
                    Case "Skin6"
                        MainMenu.ProfilePicture.Image = My.Resources.Skin6
                    Case "Skin7"
                        MainMenu.ProfilePicture.Image = My.Resources.Skin7
                    Case "Locked1"
                        MainMenu.ProfilePicture.Image = My.Resources.Locked1
                    Case "Locked2"
                        MainMenu.ProfilePicture.Image = My.Resources.Locked2
                    Case "Locked3"
                        MainMenu.ProfilePicture.Image = My.Resources.Locked3
                    Case "Locked4"
                        MainMenu.ProfilePicture.Image = My.Resources.Locked4
                    Case "Locked5"
                        MainMenu.ProfilePicture.Image = My.Resources.Locked5
                    Case "Locked6"
                        MainMenu.ProfilePicture.Image = My.Resources.Locked6
                    Case "Locked7"
                        MainMenu.ProfilePicture.Image = My.Resources.Locked7
                    Case "Locked8"
                        MainMenu.ProfilePicture.Image = My.Resources.Locked8
                End Select
            End If
        Next
        cn.Close() 'Close connection
        'As stats have been calculated, check if any unlockable boards or piece sets are available
        If Winstxt.Text >= 1 Then
            RedBoardBox.Enabled = True
            RedBoardBox.Image = Nothing
            'Editing the text
            U1WinLabel2.ForeColor = Color.Green
            U1WinLabel2.Text = "Unlocked"
            Set2Box.Enabled = True
            Set2Box.Image = Nothing
            'Editing the text
            U1WinLabel3.ForeColor = Color.Green
            U1WinLabel3.Text = "Unlocked"
        End If

        If Winstxt.Text >= 2 Then
            BlueBoardBox.Enabled = True
            BlueBoardBox.Image = Nothing
            'Editing the text
            U2WinLabel2.ForeColor = Color.Green
            U2WinLabel2.Text = "Unlocked"
            Set3Box.Enabled = True
            Set3Box.Image = Nothing
            'Editing the text
            U2WinLabel3.ForeColor = Color.Green
            U2WinLabel3.Text = "Unlocked"
        End If

        If Winstxt.Text >= 3 Then
            PinkBoardBox.Enabled = True
            PinkBoardBox.Image = Nothing
            'Editing the text
            U3WinLabel2.ForeColor = Color.Green
            U3WinLabel2.Text = "Unlocked"
        End If
    End Sub
    Private Sub LoadIntoDB()

        'Updating profile picture in database
        'Setting database location
        Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
        'Openning connection
        Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
        Dim DBsource As String = "Data Source=" & dbfilename

        Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
        cn.Open() 'Open connection
        Dim sql As String
        sql = "update [Table1]"
        sql = sql & "SET [ProfilePicture] = '" & Skinname & "', "
        sql = sql & "[BoardColour] = '" & BoardColour & "', "
        sql = sql & "[PieceType] = '" & PieceType & "' "
        sql = sql & "WHERE [ID] = " & LoginForm.Player1ID & ";"

        Dim cmd As New OleDbCommand(sql, cn)

        cmd.ExecuteNonQuery()
        cn.Close() 'Close connection
    End Sub
    Private Sub StatsCalculator()
        'Setting database location
        Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
        'Openning connection
        Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
        Dim DBsource As String = "Data Source=" & dbfilename

        Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
        Dim da As OleDbDataAdapter 'adapter
        Dim ds As New DataSet 'set used with adapter
        Dim sql As String
        sql = "SELECT [Username],[Wins],[Draws], [Loses] FROM [Table1]" 'SQL Statement
        Dim cmd As New OleDbCommand(sql, cn)
        da = New OleDbDataAdapter(sql, cn)
        cn.Open() 'Open connection
        da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
        Dim count As Integer


        For count = 0 To ds.Tables(0).Rows.Count - 1 'For loop for amount of users in table, (-1) as starts from 0
            If LoginForm.Player1Username = ds.Tables(0).Rows(count).Item(0) Then 'For player 1 stats
                Winstxt.Text = ds.Tables(0).Rows(count).Item(1)
                Drawstxt.Text = ds.Tables(0).Rows(count).Item(2)
                Losestxt.Text = ds.Tables(0).Rows(count).Item(3)
            End If
        Next
        cn.Close()
        'Creating the Win %
        WinPercentagetxt.Text = (Int((CInt(Winstxt.Text) / (CInt(Winstxt.Text) + CInt(Drawstxt.Text) + CInt(Losestxt.Text)) * 100))) 'Used append text to make form more user friendly and not highlight text from the get go
    End Sub
    Private Sub BoxClicked(sender As Object, e As EventArgs) Handles DefaultSkinBox.Click
        MainMenu.ProfilePicture.Image = DefaultSkinBox.Image
        Skinname = "Default"
        LoadIntoDB()
    End Sub

    Private Sub Skin1Box_Click(sender As Object, e As EventArgs) Handles Skin1Box.Click
        MainMenu.ProfilePicture.Image = Skin1Box.Image
        Skinname = "Skin1"
        LoadIntoDB()
    End Sub

    Private Sub Skin2Box_Click(sender As Object, e As EventArgs) Handles Skin2Box.Click
        MainMenu.ProfilePicture.Image = Skin2Box.Image
        Skinname = "Skin2"
        LoadIntoDB()
    End Sub

    Private Sub Skin3Box_Click(sender As Object, e As EventArgs) Handles Skin3Box.Click
        MainMenu.ProfilePicture.Image = Skin3Box.Image
        Skinname = "Skin3"
        LoadIntoDB()
    End Sub

    Private Sub Skin4Box_Click(sender As Object, e As EventArgs) Handles Skin4Box.Click
        MainMenu.ProfilePicture.Image = Skin4Box.Image

        Skinname = "Skin4"
        LoadIntoDB()
    End Sub

    Private Sub Skin5Box_Click(sender As Object, e As EventArgs) Handles Skin5Box.Click
        MainMenu.ProfilePicture.Image = Skin5Box.Image
        Skinname = "Skin5"
        LoadIntoDB()
    End Sub

    Private Sub Skin6Box_Click(sender As Object, e As EventArgs) Handles Skin6Box.Click
        MainMenu.ProfilePicture.Image = Skin6Box.Image
        Skinname = "Skin6"
        LoadIntoDB()
    End Sub

    Private Sub Skin7Box_Click(sender As Object, e As EventArgs) Handles Skin7Box.Click
        MainMenu.ProfilePicture.Image = Skin7Box.Image
        Skinname = "Skin7"
        LoadIntoDB()
    End Sub
    Private Sub Locked1Box_Click(sender As Object, e As EventArgs) Handles Locked1Box.Click
        MainMenu.ProfilePicture.Image = Locked1Box.BackgroundImage
        Skinname = "Locked1"
        LoadIntoDB()
    End Sub

    Private Sub Locked2Box_Click(sender As Object, e As EventArgs) Handles Locked2Box.Click
        MainMenu.ProfilePicture.Image = Locked2Box.BackgroundImage
        Skinname = "Locked2"
        LoadIntoDB()
    End Sub

    Private Sub Locked3Box_Click(sender As Object, e As EventArgs) Handles Locked3Box.Click
        MainMenu.ProfilePicture.Image = Locked3Box.BackgroundImage
        Skinname = "Locked3"
        LoadIntoDB()
    End Sub

    Private Sub Locked4Box_Click(sender As Object, e As EventArgs) Handles Locked4Box.Click
        MainMenu.ProfilePicture.Image = Locked4Box.BackgroundImage
        Skinname = "Locked4"
        LoadIntoDB()
    End Sub

    Private Sub Locked5Box_Click(sender As Object, e As EventArgs) Handles Locked5Box.Click
        MainMenu.ProfilePicture.Image = Locked5Box.BackgroundImage
        Skinname = "Locked5"
        LoadIntoDB()
    End Sub

    Private Sub Locked6Box_Click(sender As Object, e As EventArgs) Handles Locked6Box.Click
        MainMenu.ProfilePicture.Image = Locked6Box.BackgroundImage
        Skinname = "Locked6"
        LoadIntoDB()
    End Sub

    Private Sub Locked7Box_Click(sender As Object, e As EventArgs) Handles Locked7Box.Click
        MainMenu.ProfilePicture.Image = Locked7Box.BackgroundImage
        Skinname = "Locked7"
        LoadIntoDB()
    End Sub

    Private Sub Locked8Box_Click(sender As Object, e As EventArgs) Handles Locked8Box.Click
        MainMenu.ProfilePicture.Image = Locked8Box.BackgroundImage
        Skinname = "Locked8"
        LoadIntoDB()
    End Sub

    Private Sub YellowBoardBox_Click(sender As Object, e As EventArgs) Handles YellowBoardBox.Click
        SelectedBoardBox.Image = My.Resources.YellowBoardPreview
        BoardColour = "YellowBoard"
        LoadIntoDB()
    End Sub
    Private Sub GreenBoardBox_Click(sender As Object, e As EventArgs) Handles GreenBoardBox.Click
        SelectedBoardBox.Image = My.Resources.GreenBoardPreview
        BoardColour = "GreenBoard"
        LoadIntoDB()
    End Sub
    Private Sub PinkBoardBox_Click(sender As Object, e As EventArgs) Handles PinkBoardBox.Click
        SelectedBoardBox.Image = My.Resources.PinkBoardPreview
        BoardColour = "PinkBoard"
        LoadIntoDB()
    End Sub

    Private Sub RedBoardBox_Click(sender As Object, e As EventArgs) Handles RedBoardBox.Click
        SelectedBoardBox.Image = My.Resources.RedBoardPreview
        BoardColour = "RedBoard"
        LoadIntoDB()
    End Sub

    Private Sub BlueBoardBox_Click(sender As Object, e As EventArgs) Handles BlueBoardBox.Click
        SelectedBoardBox.Image = My.Resources.BlueBoardPreview
        BoardColour = "BlueBoard"
        LoadIntoDB()
    End Sub
    Private Sub Set1Box_Click(sender As Object, e As EventArgs) Handles Set1Box.Click
        SelectedPieceBox.Image = My.Resources.Set1KnightW
        PieceType = "Set1"
        LoadIntoDB()
    End Sub

    Private Sub Set2Box_Click(sender As Object, e As EventArgs) Handles Set2Box.Click
        SelectedPieceBox.Image = My.Resources.Set2KnightW
        PieceType = "Set2"
        LoadIntoDB()
    End Sub
    Private Sub Set3Box_Click(sender As Object, e As EventArgs) Handles Set3Box.Click
        SelectedPieceBox.Image = My.Resources.Set3KnightW
        PieceType = "Set3"
        LoadIntoDB()
    End Sub
End Class