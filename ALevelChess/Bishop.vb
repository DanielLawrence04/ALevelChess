Public Class Bishop
    Public xposition, yposition As Integer 'Coordinates for bishop
    Public piecevalue As Integer 'negative means black, positive means white
    Public flags(7, 7) As Boolean '2D array - for the movement of the bishop
    Public checktheking(7, 7) As Boolean '2D array - for the positions it can move to check the king
    Public stillonboard As Boolean = True
    Public allcheckmoves As Boolean 'used in calculations for movement of bishop, when the opposite colour is playing (used for making sure the king cannot move to a square which isn't directly in check)
    Public Sub New(ByVal x, ByVal y, ByVal pvalue) 'giving the new piece its coordinates, and piece value
        xposition = x
        yposition = y
        piecevalue = pvalue
        reflags() 'setting every possible move to false
    End Sub
    Public Function returnx() As Integer
        Return xposition
    End Function
    Public Function returny() As Integer
        Return yposition
    End Function
    Public Function possiblemoves() As Boolean(,) 'returning all possible moves
        reflags() 'setting every possible move to false
        'only calculate moves of the piece if it is still on the board
        If piecevalue > 0 And stillonboard = True Then
            whitemove()
        End If
        If piecevalue < 0 And stillonboard = True Then
            blackmove()
        End If
        Return flags
    End Function
    Public Sub whitemove() 'all moves for white
        'Storing posistion of bishop
        Dim x As Integer = xposition
        Dim y As Integer = yposition
        allcheckmoves = True 'Setting boolean value to true, allowing one calculation to happen

        'diagonal left top to bottom
        While (x < 7 And y > 0)
            x = x + 1
            y = y - 1

            'Code to make sure black king cannot move into a check posistion
            If GameForm1.ga.board(x, y) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(x, y) = True
                allcheckmoves = False
            End If

            If GameForm1.ga.board(x, y) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                GameForm1.ga.board(x, y) = 10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the bishop was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = 3
                If GameForm1.ga.board(x, y) < 0 Then 'If desired space is a white piece, exit loop (cannot travel through a piece)
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) <= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                    GameForm1.ga.board(x, y) = -10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                    GameForm1.ga.board(x, y) = 0
                    GameForm1.ga.board(xposition, yposition) = 3
                End If
                If GameForm1.ga.board(x, y) < 0 Then 'If the bishop can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If bishop can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                        GameForm1.ga.board(x, y) = 10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the bishop was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = 3
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        'Storing posistion of the bishop
        x = xposition
        y = yposition
        allcheckmoves = True 'Setting boolean value to true, allowing one calculation to happen

        'diagonal right bottom to top
        While (x > 0 And y < 7)
            x = x - 1
            y = y + 1

            'Code to make sure black king cannot move into a check posistion
            If GameForm1.ga.board(x, y) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(x, y) = True
                allcheckmoves = False
            End If

            If GameForm1.ga.board(x, y) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                GameForm1.ga.board(x, y) = 10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the bishop was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 

                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = 3
                If GameForm1.ga.board(x, y) < 0 Then 'If desired space is a white piece, exit loop (cannot travel through a piece)
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) <= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                    GameForm1.ga.board(x, y) = -10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                    GameForm1.ga.board(x, y) = 0
                    GameForm1.ga.board(xposition, yposition) = 3
                End If
                If GameForm1.ga.board(x, y) < 0 Then 'If the bishop can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If bishop can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                        GameForm1.ga.board(x, y) = 10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the bishop was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = 3
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        'Storing posistion of bishop
        x = xposition
        y = yposition
        allcheckmoves = True 'Setting boolean value to true, allowing one calculation to happen

        'diagonal right top to bottom
        While (x < 7 And y < 7)
            x = x + 1
            y = y + 1

            'Code to make sure black king cannot move into a check posistion
            If GameForm1.ga.board(x, y) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(x, y) = True
                allcheckmoves = False
            End If

            If GameForm1.ga.board(x, y) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                GameForm1.ga.board(x, y) = 10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the bishop was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = 3
                If GameForm1.ga.board(x, y) < 0 Then 'If desired space is a white piece, exit loop (cannot travel through a piece)
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) <= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                    GameForm1.ga.board(x, y) = -10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                    GameForm1.ga.board(x, y) = 0
                    GameForm1.ga.board(xposition, yposition) = 3
                End If
                If GameForm1.ga.board(x, y) < 0 Then 'If the bishop can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If bishop can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                        GameForm1.ga.board(x, y) = 10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the bishop was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = 3
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        'Storing posistions of bishop
        x = xposition
        y = yposition
        allcheckmoves = True 'Setting boolean value to true, allowing one calculation to happen

        'diagonal left bottom to top
        While (x > 0 And y > 0)
            x = x - 1
            y = y - 1

            'Code to make sure black king cannot move into a check posistion
            If GameForm1.ga.board(x, y) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(x, y) = True
                allcheckmoves = False
            End If

            If GameForm1.ga.board(x, y) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                GameForm1.ga.board(x, y) = 10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the bishop was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = 3
                If GameForm1.ga.board(x, y) < 0 Then 'If desired space is a white piece, exit loop (cannot travel through a piece)
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) <= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                    GameForm1.ga.board(x, y) = -10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                    GameForm1.ga.board(x, y) = 0
                    GameForm1.ga.board(xposition, yposition) = 3
                End If
                If GameForm1.ga.board(x, y) < 0 Then 'If the bishop can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If bishop can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                        GameForm1.ga.board(x, y) = 10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the bishop was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = 3
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While
    End Sub
    Public Sub blackmove()
        'Storing posistion of bishop
        Dim x As Integer = xposition
        Dim y As Integer = yposition
        allcheckmoves = True 'Setting boolean value to true, allowing one calculation to happen

        'diagonal left top to buttom
        While (x < 7 And y > 0)
            x = x + 1
            y = y - 1

            'Code to make sure white king cannot move into a check posistion
            If GameForm1.ga.board(x, y) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(x, y) = True
                allcheckmoves = False
            End If

            If GameForm1.ga.board(x, y) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the bishop was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = -3
                If GameForm1.ga.board(x, y) > 0 Then 'If desired space is a black piece, cannot move past it (cannot travel through a piece)
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) >= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                    GameForm1.ga.board(x, y) = 10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                    GameForm1.ga.board(x, y) = 0
                    GameForm1.ga.board(xposition, yposition) = -3
                End If
                If GameForm1.ga.board(x, y) > 0 Then 'If the bishop can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If bishop can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                        GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the bishop was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = -3
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        'Storing posistion of bishop
        x = xposition
        y = yposition
        allcheckmoves = True 'Setting boolean value to true, allowing one calculation to happen

        'diagonal right bottom to top
        While (x > 0 And y < 7)
            x = x - 1
            y = y + 1

            'Code to make sure white king cannot move into a check posistion
            If GameForm1.ga.board(x, y) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(x, y) = True
                allcheckmoves = False
            End If

            If GameForm1.ga.board(x, y) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false bishop can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(x, y) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the bishop was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = -3
                If GameForm1.ga.board(x, y) > 0 Then 'If desired space is a black piece, cannot move past it (cannot travel through a piece)
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) >= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                    GameForm1.ga.board(x, y) = 10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                    GameForm1.ga.board(x, y) = 0
                    GameForm1.ga.board(xposition, yposition) = -3
                End If
                If GameForm1.ga.board(x, y) > 0 Then 'If the bishop can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If bishop can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                        GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the bishop was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = -3
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        'Storing posistion of bishop
        x = xposition
        y = yposition
        allcheckmoves = True 'Setting boolean value to true, allowing one calculation to happen

        'diagonal right top to bottom
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
                GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the bishop was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = -3
                If GameForm1.ga.board(x, y) > 0 Then 'If desired space is a black piece, cannot move past it (cannot travel through a piece)
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) >= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                    GameForm1.ga.board(x, y) = 10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                    GameForm1.ga.board(x, y) = 0
                    GameForm1.ga.board(xposition, yposition) = -3
                End If
                If GameForm1.ga.board(x, y) > 0 Then 'If the bishop can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If bishop can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                        GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the bishop was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = -3
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While

        'Storing posistion of bishop
        x = xposition
        y = yposition
        allcheckmoves = True 'Setting boolean value to true, allowing one calculation to happen

        'diagonal left bottom to top
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
                GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the bishop was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(x, y) = True 'allow movement
                ElseIf x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then
                    flags(x, y) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(x, y) = temp
                GameForm1.ga.board(xposition, yposition) = -3
                If GameForm1.ga.board(x, y) > 0 Then 'If desired space is a black piece, cannot move past it (cannot travel through a piece)
                    Exit While
                End If
            ElseIf GameForm1.ga.board(x, y) >= 0 Then 'If king is in check check for available spaces
                If GameForm1.ga.board(x, y) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                    GameForm1.ga.board(x, y) = 10 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(x, y) = True
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                    GameForm1.ga.board(x, y) = 0
                    GameForm1.ga.board(xposition, yposition) = -3
                End If
                If GameForm1.ga.board(x, y) > 0 Then 'If the bishop can take a black piece it can move there to get rid of check
                    If x = GameForm1.ga.xpositionCheck And y = GameForm1.ga.ypositionCheck Then 'If bishop can move to the black piece that is checking the king then allow it to move there
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(x, y) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current bishop poisition as a blank space
                        GameForm1.ga.board(x, y) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the bishop was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(x, y) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(x, y) = temp
                        GameForm1.ga.board(xposition, yposition) = -3
                    End If
                    Exit While
                End If
            Else
                Exit While
            End If
        End While
    End Sub
    Public Sub reflags()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                flags(i, j) = False
            Next
        Next
    End Sub
    Public Sub fillcheckking()
        possiblemoves()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If flags(i, j) = True Then
                    checktheking(i, j) = True
                Else
                    checktheking(i, j) = False
                End If
            Next
        Next
        allcheckmoves = False 'Reset variable
    End Sub
    Public Sub changeposition(ByVal x, ByVal y, ByVal prex, ByVal prey)
        'Changing the posistion of piece, old and new coordinates are passed in as parameters
        GameForm1.ga.board(x, y) = GameForm1.ga.board(prex, prey)
        GameForm1.ga.board(prex, prey) = 0 'Setting old space as 0 

        If GameForm1.ga.canwritetoboardtracker = True Then 'Variable always set to true, unless the computer is doing a calculation
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
                'Setting new bishop coordinates
                xposition = x
                yposition = y
            Next
            'Writing to board tracker text box
            GameForm1.BoardTracker.AppendText(whatcolour & (" Bishop ") & (chessnotationletter(0) & chessnotationnumber(0)) & (" → ") & (chessnotationletter(1) & chessnotationnumber(1)) & Environment.NewLine)
        End If
    End Sub
End Class
