Public Class HomeForm
    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim random As Integer
        Dim rnd As New Random

        random = rnd.Next(0, 2)

        Select Case random
            Case 0
                Me.BackgroundImage = My.Resources.Background1
            Case 1
                Me.BackgroundImage = My.Resources.Background2
        End Select
    End Sub
End Class