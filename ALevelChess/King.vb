Public Class King
    Public xposition, yposition As Integer 'Coordinates for king
    Public piecevalue As Integer 'negative means black, positive means white
    Public flags(7, 7) As Boolean '2D array - for the movement of the king
    Public checktheking(7, 7) As Boolean '2D array - for the positions it can move to check the king
    Public AllowedToCastle As Boolean = True

    'positive colour means white and negative black
    Public Sub New(ByVal x, ByVal y, ByVal pval)
        xposition = x
        yposition = y
        piecevalue = pval
        reflags()
    End Sub

    Public Function returnx() As Integer
        Return xposition
    End Function
    Public Function returny() As Integer
        Return yposition
    End Function
    Public Function returnvalue()
        Return piecevalue
    End Function
    Public Function possiblemoves() As Boolean(,) 'showing possible moves
        reflags()
        If piecevalue > 0 Then
            whitemove()
        End If
        If piecevalue < 0 Then
            blackmove()
        End If
        Return flags
    End Function
    Public Sub whitemove()

        GameForm1.ga.CastlingW()

        If xposition + 1 <= 7 Then
            'one space vertically downwards
            If GameForm1.ga.board(xposition + 1, yposition) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite()
                If GameForm1.ga.checkforwhite(xposition + 1, yposition) = False Then
                    flags(xposition + 1, yposition) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition + 1, yposition) = temp
                GameForm1.ga.board(xposition, yposition) = 1

            ElseIf GameForm1.ga.board(xposition + 1, yposition) <= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition + 1, yposition) = False Then
                    flags(xposition + 1, yposition) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                GameForm1.ga.board(xposition + 1, yposition) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            End If
        End If


        If yposition + 1 <= 7 And xposition + 1 <= 7 Then
            'one space diagaonlly right top to bottom
            If GameForm1.ga.board(xposition + 1, yposition + 1) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition + 1) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite()
                If GameForm1.ga.checkforwhite(xposition + 1, yposition + 1) = False Then
                    flags(xposition + 1, yposition + 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition + 1, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            ElseIf GameForm1.ga.board(xposition + 1, yposition + 1) <= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition + 1) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition + 1, yposition + 1) = False Then
                    flags(xposition + 1, yposition + 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                GameForm1.ga.board(xposition + 1, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            End If
        End If


        If yposition - 1 >= 0 And xposition + 1 <= 7 Then
            'one space diagonally left top to bottom
            If GameForm1.ga.board(xposition + 1, yposition - 1) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition - 1) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition + 1, yposition - 1) = False Then
                    flags(xposition + 1, yposition - 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition + 1, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            ElseIf GameForm1.ga.board(xposition + 1, yposition - 1) <= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition - 1) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition + 1, yposition - 1) = False Then
                    flags(xposition + 1, yposition - 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                GameForm1.ga.board(xposition + 1, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            End If
        End If


        If xposition - 1 >= 0 Then
            'one sapace vertically upwards
            If GameForm1.ga.board(xposition - 1, yposition) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition - 1, yposition) = False Then
                    flags(xposition - 1, yposition) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition - 1, yposition) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            ElseIf GameForm1.ga.board(xposition - 1, yposition) <= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition - 1, yposition) = False Then
                    flags(xposition - 1, yposition) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                GameForm1.ga.board(xposition - 1, yposition) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            End If
        End If


        If yposition + 1 <= 7 And xposition - 1 >= 0 Then
            'one space diagonally right bottom to top
            If GameForm1.ga.board(xposition - 1, yposition + 1) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition + 1) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition - 1, yposition + 1) = False Then
                    flags(xposition - 1, yposition + 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition - 1, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            ElseIf GameForm1.ga.board(xposition - 1, yposition + 1) <= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition + 1) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition - 1, yposition + 1) = False Then
                    flags(xposition - 1, yposition + 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                GameForm1.ga.board(xposition - 1, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            End If
        End If


        If yposition - 1 >= 0 And xposition - 1 >= 0 Then
            'one space diagonally left bottom to top
            If GameForm1.ga.board(xposition - 1, yposition - 1) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition - 1) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition - 1, yposition - 1) = False Then
                    flags(xposition - 1, yposition - 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition - 1, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            ElseIf GameForm1.ga.board(xposition - 1, yposition - 1) <= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition - 1) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition - 1, yposition - 1) = False Then
                    flags(xposition - 1, yposition - 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                GameForm1.ga.board(xposition - 1, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            End If
        End If


        If yposition + 1 <= 7 Then
            'one space horizontally to the right
            If GameForm1.ga.board(xposition, yposition + 1) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition, yposition + 1) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition, yposition + 1) = False Then
                    flags(xposition, yposition + 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            ElseIf GameForm1.ga.board(xposition, yposition + 1) <= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition, yposition + 1) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition, yposition + 1) = False Then
                    flags(xposition, yposition + 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                GameForm1.ga.board(xposition, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            End If
        End If


        If yposition - 1 >= 0 Then
            'one space horizontally to the left
            If GameForm1.ga.board(xposition, yposition - 1) <= 0 And GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition, yposition - 1) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition, yposition - 1) = False Then
                    flags(xposition, yposition - 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = False
                GameForm1.ga.board(xposition, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            ElseIf GameForm1.ga.board(xposition, yposition - 1) <= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition, yposition - 1) = 1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforwhite() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforwhite(xposition, yposition - 1) = False Then
                    flags(xposition, yposition - 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforwhite(GameForm1.whiteking.xposition, GameForm1.whiteking.yposition) = True
                GameForm1.ga.board(xposition, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = 1
            End If
        End If
    End Sub
    Public Sub blackmove()

        GameForm1.ga.CastlingB()


        If xposition + 1 <= 7 Then
            'one space vertically downwards
            If GameForm1.ga.board(xposition + 1, yposition) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition + 1, yposition) = False Then
                    flags(xposition + 1, yposition) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition + 1, yposition) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            ElseIf GameForm1.ga.board(xposition + 1, yposition) >= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition + 1, yposition) = False Then
                    flags(xposition + 1, yposition) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                GameForm1.ga.board(xposition + 1, yposition) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            End If
        End If


        If yposition + 1 <= 7 And xposition + 1 <= 7 Then
            'one space diagaonlly right top to bottom
            If GameForm1.ga.board(xposition + 1, yposition + 1) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition + 1) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition + 1, yposition + 1) = False Then
                    flags(xposition + 1, yposition + 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition + 1, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            ElseIf GameForm1.ga.board(xposition + 1, yposition + 1) >= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition + 1) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition + 1, yposition + 1) = False Then
                    flags(xposition + 1, yposition + 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                GameForm1.ga.board(xposition + 1, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            End If
        End If


        If yposition - 1 >= 0 And xposition + 1 <= 7 Then
            'one space diagonally left top to bottom
            If GameForm1.ga.board(xposition + 1, yposition - 1) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition - 1) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition + 1, yposition - 1) = False Then
                    flags(xposition + 1, yposition - 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition + 1, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            ElseIf GameForm1.ga.board(xposition + 1, yposition - 1) >= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition + 1, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition + 1, yposition - 1) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition + 1, yposition - 1) = False Then
                    flags(xposition + 1, yposition - 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                GameForm1.ga.board(xposition + 1, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            End If
        End If


        If xposition - 1 >= 0 Then
            'one sapace vertically upwards
            If GameForm1.ga.board(xposition - 1, yposition) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition - 1, yposition) = False Then
                    flags(xposition - 1, yposition) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition - 1, yposition) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            ElseIf GameForm1.ga.board(xposition - 1, yposition) >= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.board(xposition - 1, yposition) = -1 'change desired space to value of the king
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition - 1, yposition) = False Then
                    flags(xposition - 1, yposition) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                GameForm1.ga.board(xposition - 1, yposition) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            End If
        End If


        If yposition + 1 <= 7 And xposition - 1 >= 0 Then
            'one space diagonally right bottom to top
            If GameForm1.ga.board(xposition - 1, yposition + 1) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition + 1) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition - 1, yposition + 1) = False Then
                    flags(xposition - 1, yposition + 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition - 1, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            ElseIf GameForm1.ga.board(xposition - 1, yposition + 1) >= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition + 1) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition - 1, yposition + 1) = False Then
                    flags(xposition - 1, yposition + 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                GameForm1.ga.board(xposition - 1, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            End If
        End If


        If yposition - 1 >= 0 And xposition - 1 >= 0 Then
            'one space diagonally left bottom to top
            If GameForm1.ga.board(xposition - 1, yposition - 1) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition - 1) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition - 1, yposition - 1) = False Then
                    flags(xposition - 1, yposition - 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition - 1, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            ElseIf GameForm1.ga.board(xposition - 1, yposition - 1) >= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition - 1, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition - 1, yposition - 1) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition - 1, yposition - 1) = False Then
                    flags(xposition - 1, yposition - 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                GameForm1.ga.board(xposition - 1, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            End If
        End If


        If yposition + 1 <= 7 Then
            'one space horizontally to the right
            If GameForm1.ga.board(xposition, yposition + 1) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition, yposition + 1) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition, yposition + 1) = False Then
                    flags(xposition, yposition + 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            ElseIf GameForm1.ga.board(xposition, yposition + 1) >= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition, yposition + 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition, yposition + 1) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition, yposition + 1) = False Then
                    flags(xposition, yposition + 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                GameForm1.ga.board(xposition, yposition + 1) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            End If
        End If


        If yposition - 1 >= 0 Then
            'one space horizontally to the left
            If GameForm1.ga.board(xposition, yposition - 1) >= 0 And GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False Then 'If check is false king can move
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition, yposition - 1) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition, yposition - 1) = False Then
                    flags(xposition, yposition - 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = False
                GameForm1.ga.board(xposition, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = -1
            ElseIf GameForm1.ga.board(xposition, yposition - 1) >= 0 Then 'If the king is in check, check to see if it can take the piece inflicting that check
                Dim temp As Integer 'declaring variable to store value from the board
                temp = GameForm1.ga.board(xposition, yposition - 1) 'storing
                GameForm1.ga.board(xposition, yposition) = 0 'setting current king poisition as a blank space
                GameForm1.ga.board(xposition, yposition - 1) = -1 'change desired space to value of the king
                GameForm1.ga.recurrsionstop = False
                GameForm1.ga.fillcheckforblack() 'checking to see that if the king was not there, would it still be in check
                If GameForm1.ga.checkforblack(xposition, yposition - 1) = False Then
                    flags(xposition, yposition - 1) = True 'allow movement
                End If
                'Returning the value of the board back to the origonal values (before the temp changes)
                GameForm1.ga.checkforblack(GameForm1.blackking.xposition, GameForm1.blackking.yposition) = True
                GameForm1.ga.board(xposition, yposition - 1) = temp
                GameForm1.ga.board(xposition, yposition) = -1
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

            GameForm1.BoardTracker.AppendText(whatcolour & (" King ") & (chessnotationletter(0) & chessnotationnumber(0)) & (" → ") & (chessnotationletter(1) & chessnotationnumber(1)) & Environment.NewLine)
        End If

    End Sub
End Class
