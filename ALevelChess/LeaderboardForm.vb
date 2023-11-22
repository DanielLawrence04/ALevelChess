Imports System.Data
Imports System.Data.OleDb
Public Class LeaderboardForm
    Private Sub LeaderboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Setting database location
        Dim dbfilename As String = System.Windows.Forms.Application.StartupPath & "\UserInfo.mdb"
        'Openning connection
        Dim DBconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" 'OLE provider for MS Access
        Dim DBsource As String = "Data Source=" & dbfilename

        Dim cn As OleDbConnection = New OleDbConnection(DBconn & DBsource) 'connection
        Dim da As OleDbDataAdapter 'adapter
        Dim ds As New DataSet 'set used with adapter
        Dim sql As String
        sql = "SELECT [Username],[Wins],[Draws],[Loses], [ProfilePicture] FROM [Table1] ORDER BY [Wins] DESC" 'SQL Statement, instead of using bubble sort, use order by function within the database
        Dim cmd As New OleDbCommand(sql, cn)
        da = New OleDbDataAdapter(sql, cn)
        cn.Open() 'Open connection

        da.Fill(ds, "Table1") 'Fill data set with data gathered by adapter
        'Population of datagrid 
        LeaderboardGrid.DataSource = ds.Tables("Table1")
        'Identifying top 3 places
        FirstLabel.Text = ds.Tables(0).Rows(0).Item(0)
        SecondLabel.Text = ds.Tables(0).Rows(1).Item(0)
        ThirdLabel.Text = ds.Tables(0).Rows(2).Item(0)
        'Profile pictures for top 3
        Dim SkinType(2) As String
        SkinType(0) = ds.Tables(0).Rows(0).Item(4)
        SkinType(1) = ds.Tables(0).Rows(1).Item(4)
        SkinType(2) = ds.Tables(0).Rows(2).Item(4)

        Select Case SkinType(0)
            Case "Default"
                FirstPlaceBox.Image = My.Resources.DefaultSkin
            Case "Skin1"
                FirstPlaceBox.Image = My.Resources.Skin1
            Case "Skin2"
                FirstPlaceBox.Image = My.Resources.Skin2
            Case "Skin3"
                FirstPlaceBox.Image = My.Resources.Skin3
            Case "Skin4"
                FirstPlaceBox.Image = My.Resources.Skin4
            Case "Skin5"
                FirstPlaceBox.Image = My.Resources.Skin5
            Case "Skin6"
                FirstPlaceBox.Image = My.Resources.Skin6
            Case "Skin7"
                FirstPlaceBox.Image = My.Resources.Skin7
            Case "Locked1"
                FirstPlaceBox.Image = My.Resources.Locked1
            Case "Locked2"
                FirstPlaceBox.Image = My.Resources.Locked2
            Case "Locked3"
                FirstPlaceBox.Image = My.Resources.Locked3
            Case "Locked4"
                FirstPlaceBox.Image = My.Resources.Locked4
            Case "Locked5"
                FirstPlaceBox.Image = My.Resources.Locked5
            Case "Locked6"
                FirstPlaceBox.Image = My.Resources.Locked6
            Case "Locked7"
                FirstPlaceBox.Image = My.Resources.Locked7
            Case "Locked8"
                FirstPlaceBox.Image = My.Resources.Locked8
        End Select
        Select Case SkinType(1)
            Case "Default"
                SecondPlaceBox.Image = My.Resources.DefaultSkin
            Case "Skin1"
                SecondPlaceBox.Image = My.Resources.Skin1
            Case "Skin2"
                SecondPlaceBox.Image = My.Resources.Skin2
            Case "Skin3"
                SecondPlaceBox.Image = My.Resources.Skin3
            Case "Skin4"
                SecondPlaceBox.Image = My.Resources.Skin4
            Case "Skin5"
                SecondPlaceBox.Image = My.Resources.Skin5
            Case "Skin6"
                SecondPlaceBox.Image = My.Resources.Skin6
            Case "Skin7"
                SecondPlaceBox.Image = My.Resources.Skin7
            Case "Locked1"
                SecondPlaceBox.Image = My.Resources.Locked1
            Case "Locked2"
                SecondPlaceBox.Image = My.Resources.Locked2
            Case "Locked3"
                SecondPlaceBox.Image = My.Resources.Locked3
            Case "Locked4"
                SecondPlaceBox.Image = My.Resources.Locked4
            Case "Locked5"
                SecondPlaceBox.Image = My.Resources.Locked5
            Case "Locked6"
                SecondPlaceBox.Image = My.Resources.Locked6
            Case "Locked7"
                SecondPlaceBox.Image = My.Resources.Locked7
            Case "Locked8"
                SecondPlaceBox.Image = My.Resources.Locked8
        End Select
        Select Case SkinType(2)
            Case "Default"
                ThirdPlaceBox.Image = My.Resources.DefaultSkin
            Case "Skin1"
                ThirdPlaceBox.Image = My.Resources.Skin1
            Case "Skin2"
                ThirdPlaceBox.Image = My.Resources.Skin2
            Case "Skin3"
                ThirdPlaceBox.Image = My.Resources.Skin3
            Case "Skin4"
                ThirdPlaceBox.Image = My.Resources.Skin4
            Case "Skin5"
                ThirdPlaceBox.Image = My.Resources.Skin5
            Case "Skin6"
                ThirdPlaceBox.Image = My.Resources.Skin6
            Case "Skin7"
                ThirdPlaceBox.Image = My.Resources.Skin7
            Case "Locked1"
                ThirdPlaceBox.Image = My.Resources.Locked1
            Case "Locked2"
                ThirdPlaceBox.Image = My.Resources.Locked2
            Case "Locked3"
                ThirdPlaceBox.Image = My.Resources.Locked3
            Case "Locked4"
                ThirdPlaceBox.Image = My.Resources.Locked4
            Case "Locked5"
                ThirdPlaceBox.Image = My.Resources.Locked5
            Case "Locked6"
                ThirdPlaceBox.Image = My.Resources.Locked6
            Case "Locked7"
                ThirdPlaceBox.Image = My.Resources.Locked7
            Case "Locked8"
                ThirdPlaceBox.Image = My.Resources.Locked8
        End Select
        cn.Close()
    End Sub
End Class