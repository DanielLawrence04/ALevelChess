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
    Public whitequeen As Queen
    Public whitebishop(1) As Bishop
    Public whiteknight(1) As Knight
    Public whitepawn(7) As Pawn
    Public whiterook(1) As Rook
    Public blackking As King
    Public blackqueen As Queen
    Public blackbishop(1) As Bishop
    Public blackknight(1) As Knight
    Public blackpawn(7) As Pawn
    Public blackrook(1) As Rook


    Public ga As Game
    Public x, y, selectionx, selectiony As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click




    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub


    Public selected As Boolean = False
    Dim Pos As Point

    Private Sub p00_Click(sender As Object, e As EventArgs) Handles p00.Click
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
            If ga.canmove(x, y) = True Then
                ga.mov(selectedpiece, x, y, selectiony, selectiony)
            End If
            selected = False
            ga.show()
        End If
    End Sub

    Private Sub p01_Click(sender As Object, e As EventArgs) Handles p01.Click
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
    End Sub

    Private Sub p02_Click(sender As Object, e As EventArgs) Handles p02.Click
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
    End Sub

    Private Sub p03_Click(sender As Object, e As EventArgs) Handles p03.Click
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
    End Sub

    Private Sub p04_Click(sender As Object, e As EventArgs) Handles p04.Click
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
    End Sub

    Private Sub p05_Click(sender As Object, e As EventArgs) Handles p05.Click
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
    End Sub

    Private Sub p06_Click(sender As Object, e As EventArgs) Handles p06.Click
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
    End Sub

    Private Sub p07_Click(sender As Object, e As EventArgs) Handles p07.Click
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
    End Sub

    Private Sub p08_Click(sender As Object, e As EventArgs) Handles p08.Click
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
    End Sub

    Private Sub p09_Click(sender As Object, e As EventArgs) Handles p09.Click
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
    End Sub

    Private Sub p10_Click(sender As Object, e As EventArgs) Handles p10.Click
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
    End Sub

    Private Sub p11_Click(sender As Object, e As EventArgs) Handles p11.Click
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
    End Sub

    Private Sub p12_Click(sender As Object, e As EventArgs) Handles p12.Click
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
    End Sub

    Private Sub p13_Click(sender As Object, e As EventArgs) Handles p13.Click
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
    End Sub

    Private Sub p14_Click(sender As Object, e As EventArgs) Handles p14.Click
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
    End Sub

    Private Sub p15_Click(sender As Object, e As EventArgs) Handles p15.Click
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
    End Sub

    Private Sub p16_Click(sender As Object, e As EventArgs) Handles p16.Click
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
    End Sub

    Private Sub p17_Click(sender As Object, e As EventArgs) Handles p17.Click
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
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location += Control.MousePosition - Pos
        End If
        Pos = Control.MousePosition
    End Sub

    Public selectedpiece As String = Nothing


    Private Sub GameForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = MainForm1.TextBox1.Text
        Label4.Text = MainForm1.TextBox2.Text
    End Sub

End Class
