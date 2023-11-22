Public Class Knight
    Public xposition, yposition As Integer 'Coordinates for knight
    Public piecevalue As Integer 'negative means black, positive means white
    Public flags(7, 7) As Boolean '2D array - for the movement of the knight
    Public checktheking(7, 7) As Boolean '2D array - for the positions it can move to check the king
    Public stillonboard As Boolean = True
    Public allcheckmoves As Boolean 'used in calculations for movement of knight, when the opposite colour is playing (used for making sure the king cannot move to a square which isn't directly in check)
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
        '
        'down 2 and left 1
        '
        If xposition + 2 <= 7 And yposition - 1 >= 0 Then
            '
            'Code to make sure black king cannot move into a check posistion
            allcheckmoves = True
            If GameForm1.ga.board(xposition + 2, yposition - 1) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(xposition + 2, yposition - 1) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(xposition + 2, yposition - 1) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 2, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition + 2, yposition - 1) = 4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(xposition + 2, yposition - 1) = True 'allow movement
                ElseIf xposition + 2 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then
                    flags(xposition + 2, yposition - 1) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition + 2, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = 4
            ElseIf GameForm1.ga.board(xposition + 2, yposition - 1) <= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition + 2, yposition - 1) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition + 2, yposition - 1) = 4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition + 2, yposition - 1) = True
                    End If
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition + 2, yposition - 1) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition + 2, yposition - 1) < 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition + 2 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition + 2, yposition - 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition + 2, yposition - 1) = 4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(xposition + 2, yposition - 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(xposition + 2, yposition - 1) = temp
                        GameForm1.ga.board(xposition, yposition) = 4
                    End If
                End If
            End If
        End If
        '
        'down 2 and right 1
        '
        If xposition + 2 <= 7 And yposition + 1 <= 7 Then
            '
            'Code to make sure black king cannot move into a check posistion
            allcheckmoves = True
            If GameForm1.ga.board(xposition + 2, yposition + 1) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(xposition + 2, yposition + 1) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(xposition + 2, yposition + 1) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 2, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition + 2, yposition + 1) = 4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(xposition + 2, yposition + 1) = True 'allow movement
                ElseIf xposition + 2 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then
                    flags(xposition + 2, yposition + 1) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition + 2, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = 4
            ElseIf GameForm1.ga.board(xposition + 2, yposition + 1) <= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition + 2, yposition + 1) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition + 2, yposition + 1) = 4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition + 2, yposition + 1) = True
                    End If
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition + 2, yposition + 1) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition + 2, yposition + 1) < 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition + 2 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition + 2, yposition + 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition + 2, yposition + 1) = 4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(xposition + 2, yposition + 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(xposition + 2, yposition + 1) = temp
                        GameForm1.ga.board(xposition, yposition) = 4
                    End If
                End If
            End If
        End If
        '
        'up 2 and left 1
        '
        If xposition - 2 >= 0 And yposition - 1 >= 0 Then
            '
            'Code to make sure black king cannot move into a check posistion
            allcheckmoves = True
            If GameForm1.ga.board(xposition - 2, yposition - 1) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(xposition - 2, yposition - 1) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(xposition - 2, yposition - 1) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 2, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition - 2, yposition - 1) = 4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(xposition - 2, yposition - 1) = True 'allow movement
                ElseIf xposition - 2 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then
                    flags(xposition - 2, yposition - 1) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition - 2, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = 4
            ElseIf GameForm1.ga.board(xposition - 2, yposition - 1) <= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition - 2, yposition - 1) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition - 2, yposition - 1) = 4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition - 2, yposition - 1) = True
                    End If
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition - 2, yposition - 1) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition - 2, yposition - 1) < 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition - 2 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition - 2, yposition - 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition - 2, yposition - 1) = 4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(xposition - 2, yposition - 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(xposition - 2, yposition - 1) = temp
                        GameForm1.ga.board(xposition, yposition) = 4
                    End If
                End If
            End If
        End If
        '
        'up 2 and right 1
        '
        If xposition - 2 >= 0 And yposition + 1 <= 7 Then
            '
            'Code to make sure black king cannot move into a check posistion
            allcheckmoves = True
            If GameForm1.ga.board(xposition - 2, yposition + 1) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(xposition - 2, yposition + 1) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(xposition - 2, yposition + 1) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 2, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition - 2, yposition + 1) = 4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(xposition - 2, yposition + 1) = True 'allow movement
                ElseIf xposition - 2 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then
                    flags(xposition - 2, yposition + 1) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition - 2, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = 4
            ElseIf GameForm1.ga.board(xposition - 2, yposition + 1) <= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition - 2, yposition + 1) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition - 2, yposition + 1) = 4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition - 2, yposition + 1) = True
                    End If
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition - 2, yposition + 1) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition - 2, yposition + 1) < 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition - 2 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition - 2, yposition + 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition - 2, yposition + 1) = 4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(xposition - 2, yposition + 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(xposition - 2, yposition + 1) = temp
                        GameForm1.ga.board(xposition, yposition) = 4
                    End If
                End If
            End If
        End If
        '
        'up 1 and right 2
        '
        If xposition - 1 >= 0 And yposition + 2 <= 7 Then
            '
            'Code to make sure black king cannot move into a check posistion
            allcheckmoves = True
            If GameForm1.ga.board(xposition - 1, yposition + 2) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(xposition - 1, yposition + 2) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(xposition - 1, yposition + 2) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition + 2) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition + 2) = 4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(xposition - 1, yposition + 2) = True 'allow movement
                ElseIf xposition - 1 = GameForm1.ga.xpositionCheck And yposition + 2 = GameForm1.ga.ypositionCheck Then
                    flags(xposition - 1, yposition + 2) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition - 1, yposition + 2) = temp
                GameForm1.ga.board(xposition, yposition) = 4
            ElseIf GameForm1.ga.board(xposition - 1, yposition + 2) <= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition - 1, yposition + 2) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition - 1, yposition + 2) = 4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition - 1, yposition + 2) = True
                    End If
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition - 1, yposition + 2) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition - 1, yposition + 2) < 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition - 1 = GameForm1.ga.xpositionCheck And yposition + 2 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition - 1, yposition + 2) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition - 1, yposition + 2) = 4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(xposition - 1, yposition + 2) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(xposition - 1, yposition + 2) = temp
                        GameForm1.ga.board(xposition, yposition) = 4
                    End If
                End If
            End If
        End If
        '
        'down 1 and right 2
        '
        If xposition + 1 <= 7 And yposition + 2 <= 7 Then
            '
            'Code to make sure black king cannot move into a check posistion
            allcheckmoves = True
            If GameForm1.ga.board(xposition + 1, yposition + 2) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(xposition + 1, yposition + 2) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(xposition + 1, yposition + 2) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the king is not in check, can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition + 2) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition + 2) = 4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(xposition + 1, yposition + 2) = True 'allow movement
                ElseIf xposition + 1 = GameForm1.ga.xpositionCheck And yposition + 2 = GameForm1.ga.ypositionCheck Then
                    flags(xposition + 1, yposition + 2) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition + 1, yposition + 2) = temp
                GameForm1.ga.board(xposition, yposition) = 4
            ElseIf GameForm1.ga.board(xposition + 1, yposition + 2) <= 0 Then 'If the king is in check, see if you can either block or take the piece to resulting in a non check
                If GameForm1.ga.board(xposition + 1, yposition + 2) = 0 Then
                    GameForm1.ga.board(xposition + 1, yposition + 2) = 4
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the knight moved to the desired space, would the king still be in check
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(xposition + 1, yposition + 2) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                    GameForm1.ga.board(xposition + 1, yposition + 2) = 0
                End If
                If GameForm1.ga.board(xposition + 1, yposition + 2) < 0 Then
                    If xposition + 1 = GameForm1.ga.xpositionCheck And yposition + 2 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition + 1, yposition + 2) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition + 1, yposition + 2) = 4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(xposition + 1, yposition + 2) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(xposition + 1, yposition + 2) = temp
                        GameForm1.ga.board(xposition, yposition) = 4
                    End If
                End If
            End If
        End If
        '
        'up 1 and left 2
        '
        If xposition - 1 >= 0 And yposition - 2 >= 0 Then
            '
            'Code to make sure black king cannot move into a check posistion
            allcheckmoves = True
            If GameForm1.ga.board(xposition - 1, yposition - 2) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(xposition - 1, yposition - 2) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(xposition - 1, yposition - 2) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition - 2) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition - 2) = 4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(xposition - 1, yposition - 2) = True 'allow movement
                ElseIf xposition - 1 = GameForm1.ga.xpositionCheck And yposition - 2 = GameForm1.ga.ypositionCheck Then
                    flags(xposition - 1, yposition - 2) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition - 1, yposition - 2) = temp
                GameForm1.ga.board(xposition, yposition) = 4
            ElseIf GameForm1.ga.board(xposition - 1, yposition - 2) <= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition - 1, yposition - 2) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition - 1, yposition - 2) = 4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition - 1, yposition - 2) = True
                    End If
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition - 1, yposition - 2) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition - 1, yposition - 2) < 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition - 1 = GameForm1.ga.xpositionCheck And yposition - 2 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition - 1, yposition - 2) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition - 1, yposition - 2) = 4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(xposition - 1, yposition - 2) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(xposition - 1, yposition - 2) = temp
                        GameForm1.ga.board(xposition, yposition) = 4
                    End If
                End If
            End If
        End If
        '
        'down 1 and left 2
        '
        If xposition + 1 <= 7 And yposition - 2 >= 0 Then
            '
            'Code to make sure black king cannot move into a check posistion
            allcheckmoves = True
            If GameForm1.ga.board(xposition + 1, yposition - 2) > 0 And allcheckmoves = True And GameForm1.ga.player = 2 Then
                flags(xposition + 1, yposition - 2) = True
                allcheckmoves = False
            End If
            '
            '
            If GameForm1.ga.board(xposition + 1, yposition - 2) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition - 2) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition - 2) = 4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(xposition + 1, yposition - 2) = True 'allow movement
                ElseIf xposition + 1 = GameForm1.ga.xpositionCheck And yposition - 2 = GameForm1.ga.ypositionCheck Then
                    flags(xposition + 1, yposition - 2) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition + 1, yposition - 2) = temp
                GameForm1.ga.board(xposition, yposition) = 4
            ElseIf GameForm1.ga.board(xposition + 1, yposition - 2) <= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition + 1, yposition - 2) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition + 1, yposition - 2) = 4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition + 1, yposition - 2) = True
                    End If
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition + 1, yposition - 2) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition + 1, yposition - 2) < 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition + 1 = GameForm1.ga.xpositionCheck And yposition - 2 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition + 1, yposition - 2) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition + 1, yposition - 2) = 4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(xposition + 1, yposition - 2) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(xposition + 1, yposition - 2) = temp
                        GameForm1.ga.board(xposition, yposition) = 4
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub blackmove()
        '
        'down 2 and left 1
        '

        If xposition + 2 <= 7 And yposition - 1 >= 0 Then
            allcheckmoves = True
            If GameForm1.ga.board(xposition + 2, yposition - 1) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(xposition + 2, yposition - 1) = True
                allcheckmoves = False
            End If
            If GameForm1.ga.board(xposition + 2, yposition - 1) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 2, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition + 2, yposition - 1) = -4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(xposition + 2, yposition - 1) = True 'allow movement
                ElseIf xposition + 2 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then
                    flags(xposition + 2, yposition - 1) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition + 2, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = -4
            ElseIf GameForm1.ga.board(xposition + 2, yposition - 1) >= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition + 2, yposition - 1) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition + 2, yposition - 1) = -4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition + 2, yposition - 1) = True
                    End If
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition + 2, yposition - 1) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition + 2, yposition - 1) > 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition + 2 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition + 2, yposition - 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition + 2, yposition - 1) = -4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(xposition + 2, yposition - 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(xposition + 2, yposition - 1) = temp
                        GameForm1.ga.board(xposition, yposition) = -4
                    End If
                End If
            End If
        End If

        'down 2 and right 1

        If xposition + 2 <= 7 And yposition + 1 <= 7 Then
            allcheckmoves = True
            If GameForm1.ga.board(xposition + 2, yposition + 1) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(xposition + 2, yposition + 1) = True
                allcheckmoves = False
            End If
            If GameForm1.ga.board(xposition + 2, yposition + 1) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 2, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition + 2, yposition + 1) = -4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(xposition + 2, yposition + 1) = True 'allow movement
                ElseIf xposition + 2 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then
                    flags(xposition + 2, yposition + 1) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition + 2, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = -4
            ElseIf GameForm1.ga.board(xposition + 2, yposition + 1) >= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition + 2, yposition + 1) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition + 2, yposition + 1) = -4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition + 2, yposition + 1) = True
                    End If
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition + 2, yposition + 1) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition + 2, yposition + 1) > 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition + 2 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition + 2, yposition + 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition + 2, yposition + 1) = -4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(xposition + 2, yposition + 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(xposition + 2, yposition + 1) = temp
                        GameForm1.ga.board(xposition, yposition) = -4
                    End If
                End If
            End If
        End If

        'up 2 and left 1
        If xposition - 2 >= 0 And yposition - 1 >= 0 Then
            allcheckmoves = True
            If GameForm1.ga.board(xposition - 2, yposition - 1) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(xposition - 2, yposition - 1) = True
                allcheckmoves = False
            End If
            If GameForm1.ga.board(xposition - 2, yposition - 1) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 2, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition - 2, yposition - 1) = -4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(xposition - 2, yposition - 1) = True 'allow movement
                ElseIf xposition - 2 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then
                    flags(xposition - 2, yposition - 1) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition - 2, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = -4
            ElseIf GameForm1.ga.board(xposition - 2, yposition - 1) >= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition - 2, yposition - 1) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition - 2, yposition - 1) = -4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition - 2, yposition - 1) = True
                    End If
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition - 2, yposition - 1) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition - 2, yposition - 1) > 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition - 2 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition - 2, yposition - 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition - 2, yposition - 1) = -4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(xposition - 2, yposition - 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(xposition - 2, yposition - 1) = temp
                        GameForm1.ga.board(xposition, yposition) = -4
                    End If
                End If
            End If
        End If

        'up 2 and right 1
        If xposition - 2 >= 0 And yposition + 1 <= 7 Then
            allcheckmoves = True
            If GameForm1.ga.board(xposition - 2, yposition + 1) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(xposition - 2, yposition + 1) = True
                allcheckmoves = False
            End If
            If GameForm1.ga.board(xposition - 2, yposition + 1) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 2, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition - 2, yposition + 1) = -4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(xposition - 2, yposition + 1) = True 'allow movement
                ElseIf xposition - 2 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then
                    flags(xposition - 2, yposition + 1) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition - 2, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = -4
            ElseIf GameForm1.ga.board(xposition - 2, yposition + 1) >= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition - 2, yposition + 1) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition - 2, yposition + 1) = -4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition - 2, yposition + 1) = True
                    End If
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition - 2, yposition + 1) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition - 2, yposition + 1) > 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition - 2 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition - 2, yposition + 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition - 2, yposition + 1) = -4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(xposition - 2, yposition + 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(xposition - 2, yposition + 1) = temp
                        GameForm1.ga.board(xposition, yposition) = -4
                    End If
                End If
            End If
        End If

        'up 1 and right 2
        If xposition - 1 >= 0 And yposition + 2 <= 7 Then
            allcheckmoves = True
            If GameForm1.ga.board(xposition - 1, yposition + 2) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(xposition - 1, yposition + 2) = True
                allcheckmoves = False
            End If
            If GameForm1.ga.board(xposition - 1, yposition + 2) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition + 2) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition + 2) = -4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(xposition - 1, yposition + 2) = True 'allow movement
                ElseIf xposition - 1 = GameForm1.ga.xpositionCheck And yposition + 2 = GameForm1.ga.ypositionCheck Then
                    flags(xposition - 1, yposition + 2) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition - 1, yposition + 2) = temp
                GameForm1.ga.board(xposition, yposition) = -4
            ElseIf GameForm1.ga.board(xposition - 1, yposition + 2) >= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition - 1, yposition + 2) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition - 1, yposition + 2) = -4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition - 1, yposition + 2) = True
                    End If
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition - 1, yposition + 2) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition - 1, yposition + 2) > 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition - 1 = GameForm1.ga.xpositionCheck And yposition + 2 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition - 1, yposition + 2) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition - 1, yposition + 2) = -4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(xposition - 1, yposition + 2) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(xposition - 1, yposition + 2) = temp
                        GameForm1.ga.board(xposition, yposition) = -4
                    End If
                End If
            End If
        End If

        'down 1 and right 2
        If xposition + 1 <= 7 And yposition + 2 <= 7 Then
            allcheckmoves = True
            If GameForm1.ga.board(xposition + 1, yposition + 2) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(xposition + 1, yposition + 2) = True
                allcheckmoves = False
            End If
            If GameForm1.ga.board(xposition + 1, yposition + 2) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the king is not in check, can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition + 2) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition + 2) = -4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(xposition + 1, yposition + 2) = True 'allow movement
                ElseIf xposition + 1 = GameForm1.ga.xpositionCheck And yposition + 2 = GameForm1.ga.ypositionCheck Then
                    flags(xposition + 1, yposition + 2) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition + 1, yposition + 2) = temp
                GameForm1.ga.board(xposition, yposition) = -4
            ElseIf GameForm1.ga.board(xposition + 1, yposition + 2) >= 0 Then 'If the king is in check, see if you can either block or take the piece to resulting in a non check
                If GameForm1.ga.board(xposition + 1, yposition + 2) = 0 Then
                    GameForm1.ga.board(xposition + 1, yposition + 2) = 4
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the knight moved to the desired space, would the king still be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(xposition + 1, yposition + 2) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                    GameForm1.ga.board(xposition + 1, yposition + 2) = 0
                End If
                If GameForm1.ga.board(xposition + 1, yposition + 2) > 0 Then
                    If xposition + 1 = GameForm1.ga.xpositionCheck And yposition + 2 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition + 1, yposition + 2) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition + 1, yposition + 2) = -4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(xposition + 1, yposition + 2) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(xposition + 1, yposition + 2) = temp
                        GameForm1.ga.board(xposition, yposition) = -4
                    End If
                End If
            End If
        End If

        'up 1 and left 2
        If xposition - 1 >= 0 And yposition - 2 >= 0 Then
            allcheckmoves = True
            If GameForm1.ga.board(xposition - 1, yposition - 2) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(xposition - 1, yposition - 2) = True
                allcheckmoves = False
            End If
            If GameForm1.ga.board(xposition - 1, yposition - 2) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition - 2) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition - 2) = -4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(xposition - 1, yposition - 2) = True 'allow movement
                ElseIf xposition - 1 = GameForm1.ga.xpositionCheck And yposition - 2 = GameForm1.ga.ypositionCheck Then
                    flags(xposition - 1, yposition - 2) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition - 1, yposition - 2) = temp
                GameForm1.ga.board(xposition, yposition) = -4
            ElseIf GameForm1.ga.board(xposition - 1, yposition - 2) >= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition - 1, yposition - 2) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition - 1, yposition - 2) = -4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition - 1, yposition - 2) = True
                    End If
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition - 1, yposition - 2) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition - 1, yposition - 2) > 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition - 1 = GameForm1.ga.xpositionCheck And yposition - 2 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition - 1, yposition - 2) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition - 1, yposition - 2) = -4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(xposition - 1, yposition - 2) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(xposition - 1, yposition - 2) = temp
                        GameForm1.ga.board(xposition, yposition) = -4
                    End If
                End If
            End If
        End If

        'down 1 and left 2
        If xposition + 1 <= 7 And yposition - 2 >= 0 Then
            allcheckmoves = True
            If GameForm1.ga.board(xposition + 1, yposition - 2) < 0 And allcheckmoves = True And GameForm1.ga.player = 1 Then
                flags(xposition + 1, yposition - 2) = True
                allcheckmoves = False
            End If
            If GameForm1.ga.board(xposition + 1, yposition - 2) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false knight can do any move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition - 2) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition - 2) = -4 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(xposition + 1, yposition - 2) = True 'allow movement
                ElseIf xposition + 1 = GameForm1.ga.xpositionCheck And yposition - 2 = GameForm1.ga.ypositionCheck Then
                    flags(xposition + 1, yposition - 2) = True 'allow movement 
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition + 1, yposition - 2) = temp
                GameForm1.ga.board(xposition, yposition) = -4
            ElseIf GameForm1.ga.board(xposition + 1, yposition - 2) >= 0 Then 'If king is in check, check for available spaces
                If GameForm1.ga.board(xposition + 1, yposition - 2) = 0 Then 'If the space is empty
                    GameForm1.ga.board(xposition + 1, yposition - 2) = -4 'Change space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'See if the king would still be in check if that piece was moved there
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If the piece prevents the king from being in check then the piece can move there
                        flags(xposition + 1, yposition - 2) = True
                    End If
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True 'Return the king being in check
                    GameForm1.ga.board(xposition + 1, yposition - 2) = 0 'Return the random number back to a blank space
                End If
                If GameForm1.ga.board(xposition + 1, yposition - 2) > 0 Then 'If the knight can take a black piece and check is no longer true then flag space
                    If xposition + 1 = GameForm1.ga.xpositionCheck And yposition - 2 = GameForm1.ga.ypositionCheck Then
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition + 1, yposition - 2) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current queen poisition as a blank space
                        GameForm1.ga.board(xposition + 1, yposition - 2) = -4 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the queen was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(xposition + 1, yposition - 2) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(xposition + 1, yposition - 2) = temp
                        GameForm1.ga.board(xposition, yposition) = -4
                    End If
                End If
            End If
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

            GameForm1.BoardTracker.AppendText(whatcolour & (" Knight ") & (chessnotationletter(0) & chessnotationnumber(0)) & (" → ") & (chessnotationletter(1) & chessnotationnumber(1)) & Environment.NewLine)
        End If


    End Sub
End Class
