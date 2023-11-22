Public Class Queen
    Public xposition, yposition As Integer
    Public piecevalue As Integer
    Public flags(7, 7) As Boolean
    Public checktheking(7, 7) As Boolean
    Public stillonboard As Boolean = True
    Public allcheckmoves As Boolean

    'positive colour is white and negative is black
    Public Sub New(ByVal x, ByVal y, ByVal pvalue)
        xposition = x
        yposition = y
        piecevalue = pvalue
        reflags()
    End Sub

    Public Function returnx() As Integer
        Return xposition
    End Function
    Public Function returny() As Integer
        Return yposition
    End Function
    Public Function returnvalue() As Integer
        Return piecevalue
    End Function
    Public Function possiblemoves() As Boolean(,) 'showing possible moves
        reflags()
        If piecevalue > 0 And stillonboard = True Then
            whitemove()
        End If
        If piecevalue < 0 And stillonboard = True Then
            blackmove()
        End If
        Return flags
    End Function
    Public Sub whitemove()
        Dim x As Integer = xposition
        Dim y As Integer = yposition
        allcheckmoves = True
        'diagonal left top to bottom
        While (x < 7 And y > 0)
            x = x + 1
            y = y - 1
            '
            'Code to make sure black king cannot move into a check posistion
            If GameForm1.ga.board(x, y) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(x, y) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(x, y) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(x, y) = -2 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = 2
                If GameForm1.ga.board(x, y) < 0 Then 'If desired space is a black piece, cannot move past it (cannot travel through a piece)
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) <= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(x, y) = -10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                    GameForm1.ga.board(x, y) = 0
                    GameForm1.ga.board(xposition, yposition) = 2
                End If
                If GameForm1.ga.board(x, y) < 0 Then 'If the queen can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = 2
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        'diagonal right bottom to top
        x = xposition
        y = yposition
        allcheckmoves = True
        While (x > 0 And y < 7)
            x = x - 1
            y = y + 1
            '
            'Code to make sure black king cannot move into a check posistion
            If GameForm1.ga.board(x, y) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(x, y) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(x, y) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(x, y) = 10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 

                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = 2
                If GameForm1.ga.board(x, y) < 0 Then
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) <= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(x, y) = -10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                    GameForm1.ga.board(x, y) = 0
                    GameForm1.ga.board(xposition, yposition) = 2
                End If
                If GameForm1.ga.board(x, y) < 0 Then 'If the queen can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = 2
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While
        'diagonal right top to bottom
        x = xposition
        y = yposition
        allcheckmoves = True
        While (x < 7 And y < 7)
            x = x + 1
            y = y + 1
            '
            'Code to make sure black king cannot move into a check posistion
            If GameForm1.ga.board(x, y) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(x, y) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(x, y) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(x, y) = 10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = 2
                If GameForm1.ga.board(x, y) < 0 Then
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) <= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(x, y) = -10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                    GameForm1.ga.board(x, y) = 0
                    GameForm1.ga.board(xposition, yposition) = 2
                End If
                If GameForm1.ga.board(x, y) < 0 Then 'If the queen can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = 2
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While
        'diagonal left bottom to top
        x = xposition
        y = yposition
        allcheckmoves = True
        While (x > 0 And y > 0)
            x = x - 1
            y = y - 1
            '
            'Code to make sure black king cannot move into a check posistion
            If GameForm1.ga.board(x, y) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(x, y) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(x, y) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(x, y) = 10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = 2
                If GameForm1.ga.board(x, y) < 0 Then
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) <= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(x, y) = -10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                    GameForm1.ga.board(x, y) = 0
                    GameForm1.ga.board(xposition, yposition) = 2
                End If
                If GameForm1.ga.board(x, y) < 0 Then 'If the queen can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = 2
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While


        'horizontal and vertical movement

        If xposition > 0 Then
            'vertically downwards
            allcheckmoves = True
            For i As Integer = xposition - 1 To 0 Step -1
                '
                'Code to make sure black king cannot move into a check posistion
                If GameForm1.ga.board(i, yposition) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                    flags(i, yposition) = True
                    allcheckmoves = False
                End If
                '
                '
                If GameForm1.ga.board(i, yposition) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false bishop can do any move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(i, yposition) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(i, yposition) = 10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(i, yposition) = True 'allow movement
                    ElseIf i = GameForm1.ga.xpositionCheck And yposition = GameForm1.ga.ypositionCheck Then
                        flags(i, yposition) = True 'allow movement 
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                    GameForm1.ga.board(i, yposition) = temp
                    GameForm1.ga.board(xposition, yposition) = 2
                    If GameForm1.ga.board(i, yposition) < 0 Then
                        Exit For
                    End If
                ElseIf GameForm1.ga.board(i, yposition) <= 0 Then 'If king is in check, check for available spaces
                    If GameForm1.ga.board(i, yposition) = 0 Then 'If the space is empty
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(i, yposition) = -10 'Change space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                            flags(i, yposition) = True
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True 'Return the king being in check
                        GameForm1.ga.board(i, yposition) = 0 'Return the random number back to a blank space
                        GameForm1.ga.board(xposition, yposition) = 2
                    End If
                    If GameForm1.ga.board(i, yposition) < 0 Then 'If the queen can take a black piece it can move there to get rid of check
                        If i = GameForm1.ga.xpositionCheck And yposition = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                            Dim temp As Integer 'declaring variable to store value from the board
                            temp = GameForm1.ga.board(i, yposition) 'storing
                            GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                            GameForm1.ga.board(i, yposition) = 10 'change desired space to a random number
                            GameForm1.ga.recurrsionstop = False
                            GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                            If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                                flags(i, yposition) = True 'allow movement
                            End If
                            'Returning the value of the board back to the origonal values (before the temp changes)
                            GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                            GameForm1.ga.board(i, yposition) = temp
                            GameForm1.ga.board(xposition, yposition) = 2
                        End If
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        If xposition <= 7 Then
            allcheckmoves = True
            'vertically upwards
            For i As Integer = xposition + 1 To 7
                '
                'Code to make sure black king cannot move into a check posistion
                If GameForm1.ga.board(i, yposition) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                    flags(i, yposition) = True
                    allcheckmoves = False
                End If
                '
                '
                If GameForm1.ga.board(i, yposition) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false bishop can do any move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(i, yposition) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(i, yposition) = 10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check

                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(i, yposition) = True 'allow movement
                    ElseIf i = GameForm1.ga.xpositionCheck And yposition = GameForm1.ga.ypositionCheck Then
                        flags(i, yposition) = True 'allow movement 
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                    GameForm1.ga.board(i, yposition) = temp
                    GameForm1.ga.board(xposition, yposition) = 2
                    If GameForm1.ga.board(i, yposition) < 0 Then
                        Exit For
                    End If
                ElseIf GameForm1.ga.board(i, yposition) <= 0 Then 'If king is in check, check for available spaces
                    If GameForm1.ga.board(i, yposition) = 0 Then 'If the space is empty
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(i, yposition) = -10 'Change space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                            flags(i, yposition) = True
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(i, yposition) = 0
                        GameForm1.ga.board(xposition, yposition) = 2
                    End If
                    If GameForm1.ga.board(i, yposition) < 0 Then 'If the queen can take a black piece it can move there to get rid of check
                        If i = GameForm1.ga.xpositionCheck And yposition = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                            Dim temp As Integer 'declaring variable to store value from the board
                            temp = GameForm1.ga.board(i, yposition) 'storing
                            GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                            GameForm1.ga.board(i, yposition) = 10 'change desired space to a random number
                            GameForm1.ga.recurrsionstop = False
                            GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                            If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                                flags(i, yposition) = True 'allow movement
                            End If
                            'Returning the value of the board back to the origonal values (before the temp changes)
                            GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                            GameForm1.ga.board(i, yposition) = temp
                            GameForm1.ga.board(xposition, yposition) = 2
                        End If
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If


        If yposition > 0 Then
            allcheckmoves = True
            'horizontally left
            For i As Integer = yposition - 1 To 0 Step -1
                '
                'Code to make sure black king cannot move into a check posistion
                If GameForm1.ga.board(xposition, i) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                    flags(xposition, i) = True
                    allcheckmoves = False
                End If
                '
                '
                If GameForm1.ga.board(xposition, i) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false bishop can do any move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(xposition, i) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(xposition, i) = 10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(xposition, i) = True 'allow movement
                    ElseIf xposition = GameForm1.ga.xpositionCheck And i = GameForm1.ga.ypositionCheck Then
                        flags(xposition, i) = True 'allow movement 
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                    GameForm1.ga.board(xposition, i) = temp
                    GameForm1.ga.board(xposition, yposition) = 2
                    If GameForm1.ga.board(xposition, i) < 0 Then
                        Exit For
                    End If
                ElseIf GameForm1.ga.board(xposition, i) <= 0 Then 'If king is in check, check for available spaces
                    If GameForm1.ga.board(xposition, i) = 0 Then 'If the space is empty
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition, i) = -10 'Change space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                            flags(xposition, i) = True
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True 'Return the king being in check
                        GameForm1.ga.board(xposition, i) = 0 'Return the random number back to a blank space
                        GameForm1.ga.board(xposition, yposition) = 2
                    End If
                    If GameForm1.ga.board(xposition, i) < 0 Then 'If the queen can take a black piece it can move there to get rid of check
                        If xposition = GameForm1.ga.xpositionCheck And i = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                            Dim temp As Integer 'declaring variable to store value from the board
                            temp = GameForm1.ga.board(xposition, i) 'storing
                            GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                            GameForm1.ga.board(xposition, i) = 10 'change desired space to a random number
                            GameForm1.ga.recurrsionstop = False
                            GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                            If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                                flags(xposition, i) = True 'allow movement
                            End If
                            'Returning the value of the board back to the origonal values (before the temp changes)
                            GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                            GameForm1.ga.board(xposition, i) = temp
                            GameForm1.ga.board(xposition, yposition) = 2
                        End If
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        If yposition <= 7 Then
            allcheckmoves = True
            'horizontally right
            For i As Integer = yposition + 1 To 7
                '
                'Code to make sure black king cannot move into a check posistion
                If GameForm1.ga.board(xposition, i) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                    flags(xposition, i) = True
                    allcheckmoves = False
                End If
                '
                '
                If GameForm1.ga.board(xposition, i) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false bishop can do any move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(xposition, i) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(xposition, i) = 10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(xposition, i) = True 'allow movement
                    ElseIf xposition = GameForm1.ga.xpositionCheck And i = GameForm1.ga.ypositionCheck Then
                        flags(xposition, i) = True 'allow movement 
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                    GameForm1.ga.board(xposition, i) = temp
                    GameForm1.ga.board(xposition, yposition) = 2
                    If GameForm1.ga.board(xposition, i) < 0 Then
                        Exit For
                    End If
                ElseIf GameForm1.ga.board(xposition, i) <= 0 Then 'If king is in check, check for available spaces
                    If GameForm1.ga.board(xposition, i) = 0 Then 'If the space is empty
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition, i) = -10 'Change space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                            flags(xposition, i) = True
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True 'Return the king being in check
                        GameForm1.ga.board(xposition, i) = 0 'Return the random number back to a blank space
                        GameForm1.ga.board(xposition, yposition) = 2
                    End If
                    If GameForm1.ga.board(xposition, i) < 0 Then 'If the queen can take a black piece it can move there to get rid of check
                        If xposition = GameForm1.ga.xpositionCheck And i = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                            Dim temp As Integer 'declaring variable to store value from the board
                            temp = GameForm1.ga.board(xposition, i) 'storing
                            GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                            GameForm1.ga.board(xposition, i) = 10 'change desired space to a random number
                            GameForm1.ga.recurrsionstop = False
                            GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                            If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                                flags(xposition, i) = True 'allow movement
                            End If
                            'Returning the value of the board back to the origonal values (before the temp changes)
                            GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                            GameForm1.ga.board(xposition, i) = temp
                            GameForm1.ga.board(xposition, yposition) = 2
                        End If
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If
    End Sub
    Public Sub blackmove()
        Dim x As Integer = xposition
        Dim y As Integer = yposition

        allcheckmoves = True
        'diagonal left top to bottom

        While (x < 7 And y > 0)
            x = x + 1
            y = y - 1
            '
            'Code to make sure white king cannot move into a check posistion
            If GameForm1.ga.board(x, y) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(x, y) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(x, y) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = -2
                If GameForm1.ga.board(x, y) > 0 Then 'If desired space is a black piece, cannot move past it (cannot travel through a piece)
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) >= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(x, y) = -10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(x, y) = 0 'Return the random number back to a blank space
                    GameForm1.ga.board(xposition, yposition) = -2
                End If
                If GameForm1.ga.board(x, y) > 0 Then 'If the queen can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = -2
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        'diagonal right bottom to top
        x = xposition
        y = yposition
        allcheckmoves = True
        While (x > 0 And y < 7)
            x = x - 1
            y = y + 1
            If GameForm1.ga.board(x, y) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(x, y) = True
                allcheckmoves = False
            End If
            If GameForm1.ga.board(x, y) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 

                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = -2
                If GameForm1.ga.board(x, y) > 0 Then
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) >= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(x, y) = -10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(x, y) = 0 'Return the random number back to a blank space
                    GameForm1.ga.board(xposition, yposition) = -2
                End If
                If GameForm1.ga.board(x, y) > 0 Then 'If the queen can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = -2
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While
        'diagonal right top to bottom
        x = xposition
        y = yposition
        allcheckmoves = True
        While (x < 7 And y < 7)
            x = x + 1
            y = y + 1
            If GameForm1.ga.board(x, y) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(x, y) = True
                allcheckmoves = False
            End If
            If GameForm1.ga.board(x, y) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = -2
                If GameForm1.ga.board(x, y) > 0 Then
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) >= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(x, y) = -10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(x, y) = 0 'Return the random number back to a blank space
                    GameForm1.ga.board(xposition, yposition) = -2
                End If
                If GameForm1.ga.board(x, y) > 0 Then 'If the queen can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = -2
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While
        'diagonal left bottom to top
        x = xposition
        y = yposition
        allcheckmoves = True
        While (x > 0 And y > 0)
            x = x - 1
            y = y - 1
            If GameForm1.ga.board(x, y) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(x, y) = True
                allcheckmoves = False
            End If
            If GameForm1.ga.board(x, y) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = -2
                If GameForm1.ga.board(x, y) > 0 Then
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) >= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(x, y) = -10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(x, y) = 0 'Return the random number back to a blank space
                    GameForm1.ga.board(xposition, yposition) = -2
                End If
                If GameForm1.ga.board(x, y) > 0 Then 'If the queen can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = -2
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        'horizontal and vertical movement
        allcheckmoves = True
        If xposition > 0 Then
            'vertically downwards
            For i As Integer = xposition - 1 To 0 Step -1
                If GameForm1.ga.board(i, yposition) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                    flags(i, yposition) = True
                    allcheckmoves = False
                End If
                If GameForm1.ga.board(i, yposition) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false bishop can do any move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(i, yposition) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(i, yposition) = -10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(i, yposition) = True 'allow movement
                    ElseIf i = GameForm1.ga.xpositionCheck And yposition = GameForm1.ga.ypositionCheck Then
                        flags(i, yposition) = True 'allow movement 
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                    GameForm1.ga.board(i, yposition) = temp
                    GameForm1.ga.board(xposition, yposition) = -2
                    If GameForm1.ga.board(i, yposition) > 0 Then
                        Exit For
                    End If
                ElseIf GameForm1.ga.board(i, yposition) >= 0 Then 'If king is in check, check for available spaces
                    If GameForm1.ga.board(i, yposition) = 0 Then 'If the space is empty
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(i, yposition) = -10 'Change space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                            flags(i, yposition) = True
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                        GameForm1.ga.board(i, yposition) = 0 'Return the random number back to a blank space
                        GameForm1.ga.board(xposition, yposition) = -2
                    End If
                    If GameForm1.ga.board(i, yposition) > 0 Then 'If the queen can take a black piece it can move there to get rid of check
                        If i = GameForm1.ga.xpositionCheck And yposition = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                            Dim temp As Integer 'declaring variable to store value from the board
                            temp = GameForm1.ga.board(i, yposition) 'storing
                            GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                            GameForm1.ga.board(i, yposition) = -10 'change desired space to a random number
                            GameForm1.ga.recurrsionstop = False
                            GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                            If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                                flags(i, yposition) = True 'allow movement
                            End If
                            'Returning the value of the board back to the origonal values (before the temp changes)
                            GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                            GameForm1.ga.board(i, yposition) = temp
                            GameForm1.ga.board(xposition, yposition) = -2
                        End If
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If
        allcheckmoves = True
        If xposition <= 7 Then
            'vertically upwards
            For i As Integer = xposition + 1 To 7
                If GameForm1.ga.board(i, yposition) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                    flags(i, yposition) = True
                    allcheckmoves = False
                End If
                If GameForm1.ga.board(i, yposition) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false bishop can do any move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(i, yposition) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(i, yposition) = -2 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(i, yposition) = True 'allow movement
                    ElseIf i = GameForm1.ga.xpositionCheck And yposition = GameForm1.ga.ypositionCheck Then
                        flags(i, yposition) = True 'allow movement 
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                    GameForm1.ga.board(i, yposition) = temp
                    GameForm1.ga.board(xposition, yposition) = -2
                    If GameForm1.ga.board(i, yposition) > 0 Then
                        Exit For
                    End If
                ElseIf GameForm1.ga.board(i, yposition) >= 0 Then 'If king is in check, check for available spaces
                    If GameForm1.ga.board(i, yposition) = 0 Then 'If the space is empty
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(i, yposition) = -2 'Change space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                            flags(i, yposition) = True
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                        GameForm1.ga.board(i, yposition) = 0 'Return the random number back to a blank space
                        GameForm1.ga.board(xposition, yposition) = -2
                    End If
                    If GameForm1.ga.board(i, yposition) > 0 Then 'If the queen can take a black piece it can move there to get rid of check
                        If i = GameForm1.ga.xpositionCheck And yposition = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                            Dim temp As Integer 'declaring variable to store value from the board
                            temp = GameForm1.ga.board(i, yposition) 'storing
                            GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                            GameForm1.ga.board(i, yposition) = -10 'change desired space to a random number
                            GameForm1.ga.recurrsionstop = False
                            GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                            If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                                flags(i, yposition) = True 'allow movement
                            End If
                            'Returning the value of the board back to the origonal values (before the temp changes)
                            GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                            GameForm1.ga.board(i, yposition) = temp
                            GameForm1.ga.board(xposition, yposition) = -2
                        End If
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        allcheckmoves = True
        If yposition > 0 Then
            'horizontally left
            For i As Integer = yposition - 1 To 0 Step -1
                If GameForm1.ga.board(xposition, i) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                    flags(xposition, i) = True
                    allcheckmoves = False
                End If
                If GameForm1.ga.board(xposition, i) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false bishop can do any move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(xposition, i) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(xposition, i) = -10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(xposition, i) = True 'allow movement
                    ElseIf xposition = GameForm1.ga.xpositionCheck And i = GameForm1.ga.ypositionCheck Then
                        flags(xposition, i) = True 'allow movement 
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                    GameForm1.ga.board(xposition, i) = temp
                    GameForm1.ga.board(xposition, yposition) = -2
                    If GameForm1.ga.board(xposition, i) > 0 Then
                        Exit For
                    End If
                ElseIf GameForm1.ga.board(xposition, i) >= 0 Then 'If king is in check, check for available spaces
                    If GameForm1.ga.board(xposition, i) = 0 Then 'If the space is empty
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition, i) = -10 'Change space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                            flags(xposition, i) = True
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                        GameForm1.ga.board(xposition, i) = 0 'Return the random number back to a blank space
                        GameForm1.ga.board(xposition, yposition) = -2
                    End If
                    If GameForm1.ga.board(xposition, i) > 0 Then 'If the queen can take a black piece it can move there to get rid of check
                        If xposition = GameForm1.ga.xpositionCheck And i = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                            Dim temp As Integer 'declaring variable to store value from the board
                            temp = GameForm1.ga.board(xposition, i) 'storing
                            GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                            GameForm1.ga.board(xposition, i) = -10 'change desired space to a random number
                            GameForm1.ga.recurrsionstop = False
                            GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                            If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                                flags(xposition, i) = True 'allow movement
                            End If
                            'Returning the value of the board back to the origonal values (before the temp changes)
                            GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                            GameForm1.ga.board(xposition, i) = temp
                            GameForm1.ga.board(xposition, yposition) = -2
                        End If
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If
        allcheckmoves = True
        If yposition <= 7 Then
            'horizontally right
            For i As Integer = yposition + 1 To 7
                If GameForm1.ga.board(xposition, i) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                    flags(xposition, i) = True
                    allcheckmoves = False
                End If
                If GameForm1.ga.board(xposition, i) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false bishop can do any move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(xposition, i) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                    GameForm1.ga.board(xposition, i) = -10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(xposition, i) = True 'allow movement
                    ElseIf xposition = GameForm1.ga.xpositionCheck And i = GameForm1.ga.ypositionCheck Then
                        flags(xposition, i) = True 'allow movement 
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                    GameForm1.ga.board(xposition, i) = temp
                    GameForm1.ga.board(xposition, yposition) = -2
                    If GameForm1.ga.board(xposition, i) > 0 Then
                        Exit For
                    End If
                ElseIf GameForm1.ga.board(xposition, i) >= 0 Then 'If king is in check, check for available spaces
                    If GameForm1.ga.board(xposition, i) = 0 Then 'If the space is empty
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition, i) = -10 'Change space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                            flags(xposition, i) = True
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                        GameForm1.ga.board(xposition, i) = 0 'Return the random number back to a blank space
                        GameForm1.ga.board(xposition, yposition) = -2
                    End If
                    If GameForm1.ga.board(xposition, i) > 0 Then 'If the queen can take a black piece it can move there to get rid of check
                        If xposition = GameForm1.ga.xpositionCheck And i = GameForm1.ga.ypositionCheck Then 'If queen can move to the black piece that is checking the king then allow it to move there
                            Dim temp As Integer 'declaring variable to store value from the board
                            temp = GameForm1.ga.board(xposition, i) 'storing
                            GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                            GameForm1.ga.board(xposition, i) = -10 'change desired space to a random number
                            GameForm1.ga.recurrsionstop = False
                            GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                            If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                                flags(xposition, i) = True 'allow movement
                            End If
                            'Returning the value of the board back to the origonal values (before the temp changes)
                            GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                            GameForm1.ga.board(xposition, i) = temp
                            GameForm1.ga.board(xposition, yposition) = -2
                        End If
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

    End Sub
    Public Sub reflags()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                flags(i, j) = False
            Next
        Next
    End Sub
    Public Sub fillcheckking()
        If stillonboard = True Then
            possiblemoves()
        Else
            reflags()
        End If
        For i As Integer = 0 To 7
                For j As Integer = 0 To 7
                    If flags(i, j) = True Then
                        checktheking(i, j) = True
                    Else
                        checktheking(i, j) = False
                    End If
                Next
            Next
        allcheckmoves = False
    End Sub
    Public Sub changeposition(ByVal x, ByVal y, ByVal prex, ByVal prey)
        GameForm1.ga.board(x, y) = GameForm1.ga.board(prex, prey)
        GameForm1.ga.board(prex, prey) = 0

        If GameForm1.ga.canwritetoboardtracker = True Then
            Dim whatcolour As String

            If GameForm1.ga.movecounter Mod 2 = 1 Then
                whatcolour = "White"
            Else
                whatcolour = "Black"
            End If

            Dim chessnotationletter(1) As String
            Dim chessnotationnumber(1) As Integer
            For i = 0 To 1
                Select Case yposition
                    Case 0
                        chessnotationletter(i) = "A"
                    Case 1
                        chessnotationletter(i) = "B"
                    Case 2
                        chessnotationletter(i) = "C"
                    Case 3
                        chessnotationletter(i) = "D"
                    Case 4
                        chessnotationletter(i) = "E"
                    Case 5
                        chessnotationletter(i) = "F"
                    Case 6
                        chessnotationletter(i) = "G"
                    Case 7
                        chessnotationletter(i) = "H"
                End Select


                Select Case xposition
                    Case 0
                        chessnotationnumber(i) = "8"
                    Case 1
                        chessnotationnumber(i) = "7"
                    Case 2
                        chessnotationnumber(i) = "6"
                    Case 3
                        chessnotationnumber(i) = "5"
                    Case 4
                        chessnotationnumber(i) = "4"
                    Case 5
                        chessnotationnumber(i) = "3"
                    Case 6
                        chessnotationnumber(i) = "2"
                    Case 7
                        chessnotationnumber(i) = "1"
                End Select
                xposition = x
                yposition = y
            Next

            GameForm1.BoardTracker.AppendText(whatcolour & (" Queen ") & (chessnotationletter(0) & chessnotationnumber(0)) & (" → ") & (chessnotationletter(1) & chessnotationnumber(1)) & Environment.NewLine)
        End If

    End Sub
End Class
