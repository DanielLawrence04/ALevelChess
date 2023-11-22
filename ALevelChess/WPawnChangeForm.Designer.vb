<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WPawnChangeForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.QueenBox = New System.Windows.Forms.PictureBox()
        Me.RookBox = New System.Windows.Forms.PictureBox()
        Me.KnightBox = New System.Windows.Forms.PictureBox()
        Me.BishopBox = New System.Windows.Forms.PictureBox()
        Me.RookButton = New System.Windows.Forms.Button()
        Me.KnightButton = New System.Windows.Forms.Button()
        Me.BishopButton = New System.Windows.Forms.Button()
        Me.QueenButton = New System.Windows.Forms.Button()
        CType(Me.QueenBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RookBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KnightBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BishopBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Calligraphy", 21.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(11, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(406, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Choose Promotion Piece"
        '
        'QueenBox
        '
        Me.QueenBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.QueenBox.Location = New System.Drawing.Point(35, 67)
        Me.QueenBox.Name = "QueenBox"
        Me.QueenBox.Size = New System.Drawing.Size(75, 75)
        Me.QueenBox.TabIndex = 1
        Me.QueenBox.TabStop = False
        '
        'RookBox
        '
        Me.RookBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RookBox.Location = New System.Drawing.Point(131, 67)
        Me.RookBox.Name = "RookBox"
        Me.RookBox.Size = New System.Drawing.Size(75, 75)
        Me.RookBox.TabIndex = 1
        Me.RookBox.TabStop = False
        '
        'KnightBox
        '
        Me.KnightBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.KnightBox.Location = New System.Drawing.Point(224, 67)
        Me.KnightBox.Name = "KnightBox"
        Me.KnightBox.Size = New System.Drawing.Size(75, 75)
        Me.KnightBox.TabIndex = 1
        Me.KnightBox.TabStop = False
        '
        'BishopBox
        '
        Me.BishopBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BishopBox.Location = New System.Drawing.Point(317, 67)
        Me.BishopBox.Name = "BishopBox"
        Me.BishopBox.Size = New System.Drawing.Size(75, 75)
        Me.BishopBox.TabIndex = 1
        Me.BishopBox.TabStop = False
        '
        'RookButton
        '
        Me.RookButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.RookButton.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!)
        Me.RookButton.Location = New System.Drawing.Point(131, 160)
        Me.RookButton.Name = "RookButton"
        Me.RookButton.Size = New System.Drawing.Size(75, 25)
        Me.RookButton.TabIndex = 2
        Me.RookButton.Text = "Rook"
        Me.RookButton.UseVisualStyleBackColor = False
        '
        'KnightButton
        '
        Me.KnightButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.KnightButton.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!)
        Me.KnightButton.Location = New System.Drawing.Point(224, 160)
        Me.KnightButton.Name = "KnightButton"
        Me.KnightButton.Size = New System.Drawing.Size(75, 25)
        Me.KnightButton.TabIndex = 2
        Me.KnightButton.Text = "Knight"
        Me.KnightButton.UseVisualStyleBackColor = False
        '
        'BishopButton
        '
        Me.BishopButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.BishopButton.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!)
        Me.BishopButton.Location = New System.Drawing.Point(317, 160)
        Me.BishopButton.Name = "BishopButton"
        Me.BishopButton.Size = New System.Drawing.Size(75, 25)
        Me.BishopButton.TabIndex = 2
        Me.BishopButton.Text = "Bishop"
        Me.BishopButton.UseVisualStyleBackColor = False
        '
        'QueenButton
        '
        Me.QueenButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.QueenButton.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!)
        Me.QueenButton.Location = New System.Drawing.Point(35, 160)
        Me.QueenButton.Name = "QueenButton"
        Me.QueenButton.Size = New System.Drawing.Size(75, 25)
        Me.QueenButton.TabIndex = 2
        Me.QueenButton.Text = "Queen"
        Me.QueenButton.UseVisualStyleBackColor = False
        '
        'WPawnChangeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(428, 214)
        Me.Controls.Add(Me.BishopButton)
        Me.Controls.Add(Me.KnightButton)
        Me.Controls.Add(Me.QueenButton)
        Me.Controls.Add(Me.RookButton)
        Me.Controls.Add(Me.BishopBox)
        Me.Controls.Add(Me.KnightBox)
        Me.Controls.Add(Me.RookBox)
        Me.Controls.Add(Me.QueenBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WPawnChangeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WPawnChangeForm"
        CType(Me.QueenBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RookBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KnightBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BishopBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents QueenBox As PictureBox
    Friend WithEvents RookBox As PictureBox
    Friend WithEvents KnightBox As PictureBox
    Friend WithEvents BishopBox As PictureBox
    Friend WithEvents RookButton As Button
    Friend WithEvents KnightButton As Button
    Friend WithEvents BishopButton As Button
    Friend WithEvents QueenButton As Button
End Class
