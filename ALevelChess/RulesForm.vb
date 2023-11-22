Imports Microsoft.Office.Interop
Public Class RulesForm
    Public wordapp As Word.Application

    Private Sub RulesButton_Click(sender As Object, e As EventArgs) Handles RulesButton.Click
        'Don't want more than 1 form open at a time
        If wordapp IsNot Nothing Then
            wordapp.Quit()
        End If
        'Open rules document
        'creating rules document again as error would otherwise occur when opening the rules document, if once closed.
        wordapp = CreateObject("word.application")
        'making word document visible
        wordapp.Visible = True
        'opening already exisiting document, as then can make it read only so user cannot edit it

        wordapp.Documents.Open(System.Windows.Forms.Application.StartupPath & "\RulesDocument.docx")
    End Sub
End Class