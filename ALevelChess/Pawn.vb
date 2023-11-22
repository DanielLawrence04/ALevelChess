Public Class Pawn
    Public xposition, yposition As Integer 'Coordinates for pawn
    Public piecevalue As Integer 'negative means black, positive means white
    Public flags(7, 7) As Boolean '2D array - for the movement of the pawn
    Public checktheking(7, 7) As Boolean '2D array - for the positions it can move to check the king
    Public stillonboard As Boolean = True
    Public allcheckmoves As Boolean 'used in calculations for movement of pawn, when the opposite colour is playing (used for making sure the king cannot move to a square which isn't directly in check)

    Public Sub New(ByVal x, ByVal y, ByVal pvalue)
        xposition = x
        yposition = y
        piecevalue = pvalue 'Positive P value is White, Negative P value is Black
        reflags()
        recheckking()
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
    Public Function possiblemoves() As Boolean(,) 'Calculation of the possible moves
        reflags()
        If piecevalue > 0 And stillonboard = True Then
            whitemove()
        End If
        If piecevalue < 0 And stillonboard = True Then
            blackmove()
        End If
        Return flags 'Returning all possible positions the pawn can move to
    End Function
    Public Sub whitemove()

        If xposition = 6 Then 'If pawn is at starting position
            '
            'one square vertically down
            '
            '
            If xposition - 1 >= 0 Then
                If GameForm1.ga.board(xposition - 1, yposition) = 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false pawn can move
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition - 1, yposition) = 6 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn was not there, would the king be in check
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(xposition - 1, yposition) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                    GameForm1.ga.board(xposition - 1, yposition) = 0
                    GameForm1.ga.board(xposition, yposition) = 6
                ElseIf GameForm1.ga.board(xposition - 1, yposition) = 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True Then 'If king is in check, check to see if pawn can block the check from taking place
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition - 1, yposition) = 6 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn moved to the desired space, would the king still be in check
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(xposition - 1, yposition) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                    GameForm1.ga.board(xposition - 1, yposition) = 0
                    GameForm1.ga.board(xposition, yposition) = 6
                End If
            End If
            '
            '
            'two squares vertically down
            '
            '
            'Pawn can move two spaces upwards on first go (if the two spaces in front of it are free)
            If GameForm1.ga.board(xposition - 2, yposition) = 0 And GameForm1.ga.board(xposition - 1, yposition) = 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false pawn can move
                GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                GameForm1.ga.board(xposition - 2, yposition) = 6 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn was not there, would the king be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(xposition - 2, yposition) = True 'allow movement
                End If
                'Return value of the board back to original
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition - 2, yposition) = 0
                GameForm1.ga.board(xposition, yposition) = 6
            ElseIf GameForm1.ga.board(xposition - 2, yposition) = 0 And GameForm1.ga.board(xposition - 1, yposition) = 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True Then 'If king is in check, check to see if pawn can block the check from taking place
                GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                GameForm1.ga.board(xposition - 2, yposition) = 6 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn moved to the desired space, would the king still be in check
                If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                    flags(xposition - 2, yposition) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                GameForm1.ga.board(xposition - 2, yposition) = 0
                GameForm1.ga.board(xposition, yposition) = 6
            End If
            '
            '
            'diagonlly right top downwards
            '
            '
            If yposition + 1 <= 7 And xposition - 1 >= 0 Then
                '
                'Code to make sure black king cannot move into a check posistion
                If GameForm1.ga.board(xposition - 1, yposition + 1) > 0 And GameForm1.ga.player = 2 Then
                    flags(xposition - 1, yposition + 1) = True
                End If
                '
                '
                If GameForm1.ga.board(xposition - 1, yposition + 1) < 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false pawn can move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(xposition - 1, yposition + 1) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition - 1, yposition + 1) = 10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn was not there, would the king be in check
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(xposition - 1, yposition + 1) = True 'allow movement
                    ElseIf xposition - 1 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        flags(xposition - 1, yposition + 1) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                    GameForm1.ga.board(xposition - 1, yposition + 1) = temp
                    GameForm1.ga.board(xposition, yposition) = 6
                ElseIf GameForm1.ga.board(xposition - 1, yposition + 1) < 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True Then 'If king is in check, check to see if pawn can take the piece which is putting king in check

                    If xposition - 1 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition - 1, yposition + 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                        GameForm1.ga.board(xposition - 1, yposition + 1) = 10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(xposition - 1, yposition + 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(xposition - 1, yposition + 1) = temp
                        GameForm1.ga.board(xposition, yposition) = 6
                    End If
                End If
            End If
            '
            '
            'diagonally left top downwards
            '
            '
            If yposition - 1 >= 0 And xposition - 1 >= 0 Then
                '
                'Code to make sure black king cannot move into a check posistion
                If GameForm1.ga.board(xposition - 1, yposition - 1) > 0 And GameForm1.ga.player = 2 Then
                    flags(xposition - 1, yposition - 1) = True
                End If
                '
                '
                If GameForm1.ga.board(xposition - 1, yposition - 1) < 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false pawn can move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(xposition - 1, yposition - 1) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition - 1, yposition - 1) = 10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn was not there, would the king be in check
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(xposition - 1, yposition - 1) = True 'allow movement
                    ElseIf xposition - 1 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        flags(xposition - 1, yposition - 1) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                    GameForm1.ga.board(xposition - 1, yposition - 1) = temp
                    GameForm1.ga.board(xposition, yposition) = 6
                ElseIf GameForm1.ga.board(xposition - 1, yposition - 1) < 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True Then 'If king is in check, check to see if pawn can take the piece which is putting king in check
                    If xposition - 1 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition - 1, yposition - 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                        GameForm1.ga.board(xposition - 1, yposition - 1) = 10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(xposition - 1, yposition - 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(xposition - 1, yposition - 1) = temp
                        GameForm1.ga.board(xposition, yposition) = 6
                    End If
                End If
            End If

        Else
            '
            '
            'one square vertically down
            '
            '
            If xposition - 1 >= 0 Then
                If GameForm1.ga.board(xposition - 1, yposition) = 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false pawn can move
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition - 1, yposition) = 10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn was not there, would the king be in check
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(xposition - 1, yposition) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                    GameForm1.ga.board(xposition - 1, yposition) = 0
                    GameForm1.ga.board(xposition, yposition) = 6
                ElseIf GameForm1.ga.board(xposition - 1, yposition) = 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True Then 'If king is in check, check to see if pawn can block the check from taking place
                    GameForm1.ga.board(xposition, yposition) = 0
                    GameForm1.ga.board(xposition - 1, yposition) = -10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn moved to the desired space, would the king still be in check
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(xposition - 1, yposition) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                    GameForm1.ga.board(xposition - 1, yposition) = 0
                    GameForm1.ga.board(xposition, yposition) = 6
                End If
            End If

            '
            '
            'diagonlly right top downwards
            '
            '
            If yposition + 1 <= 7 And xposition - 1 >= 0 Then
                '
                'Code to make sure black king cannot move into a check posistion
                If GameForm1.ga.board(xposition - 1, yposition + 1) > 0 And GameForm1.ga.player = 2 Then
                    flags(xposition - 1, yposition + 1) = True
                End If
                '
                '
                If GameForm1.ga.board(xposition - 1, yposition + 1) < 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false pawn can move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(xposition - 1, yposition + 1) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition - 1, yposition + 1) = 10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn was not there, would the king be in check
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(xposition - 1, yposition + 1) = True 'allow movement
                    ElseIf xposition - 1 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        flags(xposition - 1, yposition + 1) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                    GameForm1.ga.board(xposition - 1, yposition + 1) = temp '
                    GameForm1.ga.board(xposition, yposition) = 6
                ElseIf GameForm1.ga.board(xposition - 1, yposition + 1) < 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True Then 'If king is in check, check to see if pawn can take the piece which is putting king in check
                    If xposition - 1 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition - 1, yposition + 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                        GameForm1.ga.board(xposition - 1, yposition + 1) = 10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(xposition - 1, yposition + 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(xposition - 1, yposition + 1) = temp '
                        GameForm1.ga.board(xposition, yposition) = 6
                    End If
                End If
            End If
            '
            '
            'diagonally left top downwards
            '
            '
            If yposition - 1 >= 0 And xposition - 1 >= 0 Then
                '
                'Code to make sure black king cannot move into a check posistion
                If GameForm1.ga.board(xposition - 1, yposition - 1) > 0 And GameForm1.ga.player = 2 Then
                    flags(xposition - 1, yposition - 1) = True
                End If
                '
                '
                If GameForm1.ga.board(xposition - 1, yposition - 1) < 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false pawn can move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(xposition - 1, yposition - 1) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition - 1, yposition - 1) = 10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn was not there, would the king be in check
                    If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                        flags(xposition - 1, yposition - 1) = True 'allow movement
                    ElseIf xposition - 1 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        flags(xposition - 1, yposition - 1) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                    GameForm1.ga.board(xposition - 1, yposition - 1) = temp
                    GameForm1.ga.board(xposition, yposition) = 6
                ElseIf GameForm1.ga.board(xposition - 1, yposition - 1) < 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True Then 'If king is in check, check to see if pawn can take the piece which is putting king in check
                    If xposition - 1 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition - 1, yposition - 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                        GameForm1.ga.board(xposition - 1, yposition - 1) = 10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforwhite() 'checking to see that if the pawn was not there, would the king be in check
                        If GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then
                            flags(xposition - 1, yposition - 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                        GameForm1.ga.board(xposition - 1, yposition - 1) = temp
                        GameForm1.ga.board(xposition, yposition) = 6
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub blackmove()
        If xposition = 1 Then 'If pawn is at starting position
            '
            'One square vertically upwards
            '
            If xposition + 1 <= 7 Then
                If GameForm1.ga.board(xposition + 1, yposition) = 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false pawn can move
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition + 1, yposition) = -6 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn was not there, would the king be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(xposition + 1, yposition) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                    GameForm1.ga.board(xposition + 1, yposition) = 0
                    GameForm1.ga.board(xposition, yposition) = -6
                ElseIf GameForm1.ga.board(xposition + 1, yposition) = 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True Then 'If king is in check, check to see if pawn can block the check from taking place
                    GameForm1.ga.board(xposition, yposition) = 0
                    GameForm1.ga.board(xposition + 1, yposition) = -6 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn moved to the desired space, would the king still be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(xposition + 1, yposition) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                    GameForm1.ga.board(xposition + 1, yposition) = 0
                    GameForm1.ga.board(xposition, yposition) = -6
                End If
            End If
            '
            'Two squares vertically upwards
            '
            '
            If GameForm1.ga.board(xposition + 2, yposition) = 0 And GameForm1.ga.board(xposition + 1, yposition) = 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false pawn can move
                GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                GameForm1.ga.board(xposition + 2, yposition) = -6 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn was not there, would the king be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(xposition + 2, yposition) = True 'allow movement
                End If
                'Return value of the board back to original
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition + 2, yposition) = 0
                GameForm1.ga.board(xposition, yposition) = -6
            ElseIf GameForm1.ga.board(xposition + 2, yposition) = 0 And GameForm1.ga.board(xposition + 1, yposition) = 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True Then 'If king is in check, check to see if pawn can block the check from taking place
                GameForm1.ga.board(xposition, yposition) = 0
                GameForm1.ga.board(xposition + 2, yposition) = -6 'change desired space to a random number
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn moved to the desired space, would the king still be in check
                If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                    flags(xposition + 2, yposition) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                GameForm1.ga.board(xposition + 2, yposition) = 0
                GameForm1.ga.board(xposition, yposition) = -6
            End If
            '
            'diagonally right bottom upwards
            '
            If yposition + 1 <= 7 And xposition + 1 <= 7 Then
                'Code to make sure black king cannot move into a check posistion
                If GameForm1.ga.board(xposition + 1, yposition + 1) < 0 And GameForm1.ga.player = 1 Then
                    flags(xposition + 1, yposition + 1) = True
                End If
                '
                '
                If GameForm1.ga.board(xposition + 1, yposition + 1) > 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false pawn can move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(xposition + 1, yposition + 1) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition + 1, yposition + 1) = -10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn was not there, would the king be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(xposition + 1, yposition + 1) = True 'allow movement
                    ElseIf xposition + 1 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        flags(xposition + 1, yposition + 1) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                    GameForm1.ga.board(xposition + 1, yposition + 1) = temp '
                    GameForm1.ga.board(xposition, yposition) = -6
                ElseIf GameForm1.ga.board(xposition + 1, yposition + 1) > 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True Then 'If king is in check, check to see if pawn can take the piece which is putting king in check
                    If xposition + 1 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition + 1, yposition + 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                        GameForm1.ga.board(xposition + 1, yposition + 1) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(xposition + 1, yposition + 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(xposition + 1, yposition + 1) = temp '
                        GameForm1.ga.board(xposition, yposition) = -6
                    End If
                End If
            End If
            '
            'diagoanlly left bottom upwards
            '
            If yposition - 1 >= 0 And xposition + 1 <= 7 Then
                'Code to make sure black king cannot move into a check posistion
                If GameForm1.ga.board(xposition + 1, yposition - 1) < 0 And GameForm1.ga.player = 1 Then
                    flags(xposition + 1, yposition - 1) = True
                End If
                'one square diagonally left (bottom upwards)
                If GameForm1.ga.board(xposition + 1, yposition - 1) > 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false pawn can move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(xposition + 1, yposition - 1) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition + 1, yposition - 1) = -10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn was not there, would the king be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(xposition + 1, yposition - 1) = True 'allow movement
                    ElseIf xposition + 1 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        flags(xposition + 1, yposition - 1) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                    GameForm1.ga.board(xposition + 1, yposition - 1) = temp
                    GameForm1.ga.board(xposition, yposition) = -6
                ElseIf GameForm1.ga.board(xposition + 1, yposition - 1) > 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True Then 'If king is in check, check to see if pawn can take the piece which is putting king in check
                    If xposition + 1 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition + 1, yposition - 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                        GameForm1.ga.board(xposition + 1, yposition - 1) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(xposition + 1, yposition - 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(xposition + 1, yposition - 1) = temp
                        GameForm1.ga.board(xposition, yposition) = -6
                    End If
                End If
            End If

        Else
            '
            'One square vertically upwards
            '
            If xposition + 1 <= 7 Then
                If GameForm1.ga.board(xposition + 1, yposition) = 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false pawn can move
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition + 1, yposition) = -6 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn was not there, would the king be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(xposition + 1, yposition) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                    GameForm1.ga.board(xposition + 1, yposition) = 0
                    GameForm1.ga.board(xposition, yposition) = -6
                ElseIf GameForm1.ga.board(xposition + 1, yposition) = 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True Then 'If king is in check, check to see if pawn can block the check from taking place
                    GameForm1.ga.board(xposition, yposition) = 0
                    GameForm1.ga.board(xposition + 1, yposition) = -10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn moved to the desired space, would the king still be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(xposition + 1, yposition) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                    GameForm1.ga.board(xposition + 1, yposition) = 0
                    GameForm1.ga.board(xposition, yposition) = -6
                End If
            End If
            '
            'diagonally right bottom upwards
            '

            '
            If yposition + 1 <= 7 And xposition + 1 <= 7 Then
                'Code to make sure black king cannot move into a check posistion
                If GameForm1.ga.board(xposition + 1, yposition + 1) < 0 And GameForm1.ga.player = 1 Then
                    flags(xposition + 1, yposition + 1) = True
                End If
                If GameForm1.ga.board(xposition + 1, yposition + 1) > 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false pawn can move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(xposition + 1, yposition + 1) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition + 1, yposition + 1) = -10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn was not there, would the king be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(xposition + 1, yposition + 1) = True 'allow movement
                    ElseIf xposition + 1 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        flags(xposition + 1, yposition + 1) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                    GameForm1.ga.board(xposition + 1, yposition + 1) = temp '
                    GameForm1.ga.board(xposition, yposition) = -6

                ElseIf GameForm1.ga.board(xposition + 1, yposition + 1) > 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True Then 'If king is in check, check to see if pawn can take the piece which is putting king in check
                    If xposition + 1 = GameForm1.ga.xpositionCheck And yposition + 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition + 1, yposition + 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                        GameForm1.ga.board(xposition + 1, yposition + 1) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(xposition + 1, yposition + 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(xposition + 1, yposition + 1) = temp '
                        GameForm1.ga.board(xposition, yposition) = -6
                    End If
                End If
            End If
            '
            'diagonally left bottom upwards
            '
            If yposition - 1 >= 0 And xposition + 1 <= 7 Then
                'Code to make sure black king cannot move into a check posistion
                If GameForm1.ga.board(xposition + 1, yposition - 1) < 0 And GameForm1.ga.player = 1 Then
                    flags(xposition + 1, yposition - 1) = True
                End If
                If GameForm1.ga.board(xposition + 1, yposition - 1) > 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false pawn can move
                    Dim temp As Integer 'declaring variable to store value from the board
                    temp = GameForm1.ga.board(xposition + 1, yposition - 1) 'storing
                    GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                    GameForm1.ga.board(xposition + 1, yposition - 1) = -10 'change desired space to a random number
                    GameForm1.ga.recurrsionstop = False
                    GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn was not there, would the king be in check
                    If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                        flags(xposition + 1, yposition - 1) = True 'allow movement
                    ElseIf xposition + 1 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        flags(xposition + 1, yposition - 1) = True 'allow movement
                    End If
                    'Returning the value of the board back to the origonal values (before the temp changes)
                    GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                    GameForm1.ga.board(xposition + 1, yposition - 1) = temp
                    GameForm1.ga.board(xposition, yposition) = -6
                ElseIf GameForm1.ga.board(xposition + 1, yposition - 1) > 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True Then 'If king is in check, check to see if pawn can take the piece which is putting king in check
                    If xposition + 1 = GameForm1.ga.xpositionCheck And yposition - 1 = GameForm1.ga.ypositionCheck Then 'if the position the pawn was going to move is the position the king is getting checked from, allow the movement
                        Dim temp As Integer 'declaring variable to store value from the board
                        temp = GameForm1.ga.board(xposition + 1, yposition - 1) 'storing
                        GameForm1.ga.board(xposition, yposition) = 0 'setting current pawn poisition as a blank space
                        GameForm1.ga.board(xposition + 1, yposition - 1) = -10 'change desired space to a random number
                        GameForm1.ga.recurrsionstop = False
                        GameForm1.ga.fillcheckforblack() 'checking to see that if the pawn was not there, would the king be in check
                        If GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then
                            flags(xposition + 1, yposition - 1) = True 'allow movement
                        End If
                        'Returning the value of the board back to the origonal values (before the temp changes)
                        GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                        GameForm1.ga.board(xposition + 1, yposition - 1) = temp
                        GameForm1.ga.board(xposition, yposition) = -6
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub diagonalchecktest()
        reflags()

        'White Pawn
        If piecevalue > 0 Then
            If yposition + 1 <= 7 And xposition - 1 >= 0 Then
                flags(xposition - 1, yposition + 1) = True
            End If
            If yposition - 1 >= 0 And xposition - 1 >= 0 Then
                flags(xposition - 1, yposition - 1) = True
            End If
        End If
        'Black Pawn
        If piecevalue < 0 Then
            If allcheckmoves = True Then
                If yposition + 1 <= 7 And xposition + 1 <= 7 Then 'pawn moving up 1 and right 1 (diagonally right)
                    flags(xposition + 1, yposition + 1) = True 'therefore move can happen
                End If
                If yposition - 1 >= 0 And xposition + 1 <= 7 Then 'pawn moving up 1 and and left 1 (diagonally left)
                    flags(xposition + 1, yposition - 1) = True 'therefore move can happen
                End If
            End If
        End If
    End Sub
    Public Sub reflags() 'Setting all elements false flag
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                flags(i, j) = False
            Next
        Next
    End Sub
    Public Sub recheckking()
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                checktheking(i, j) = False
            Next
        Next
    End Sub
    Public Sub fillcheckking()
        allcheckmoves = True
        If stillonboard = True Then
            diagonalchecktest()
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

            GameForm1.BoardTracker.AppendText(whatcolour & (" Pawn ") & (chessnotationletter(0) & chessnotationnumber(0)) & (" → ") & (chessnotationletter(1) & chessnotationnumber(1)) & Environment.NewLine)

            fillcheckking()
        End If
    End Sub

End Class
