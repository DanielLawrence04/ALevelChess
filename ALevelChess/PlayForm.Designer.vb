<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlayForm))
        Me.MultiplayerButton = New System.Windows.Forms.Button()
        Me.SinglePlayerButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'MultiplayerButton
        '
        Me.MultiplayerButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.MultiplayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MultiplayerButton.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MultiplayerButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.MultiplayerButton.Image = CType(resources.GetObject("MultiplayerButton.Image"), System.Drawing.Image)
        Me.MultiplayerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MultiplayerButton.Location = New System.Drawing.Point(312, 251)
        Me.MultiplayerButton.Name = "MultiplayerButton"
        Me.MultiplayerButton.Size = New System.Drawing.Size(239, 84)
        Me.MultiplayerButton.TabIndex = 41
        Me.MultiplayerButton.Text = "Multiplayer"
        Me.MultiplayerButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MultiplayerButton.UseVisualStyleBackColor = False
        '
        'SinglePlayerButton
        '
        Me.SinglePlayerButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.SinglePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SinglePlayerButton.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SinglePlayerButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.SinglePlayerButton.Image = CType(resources.GetObject("SinglePlayerButton.Image"), System.Drawing.Image)
        Me.SinglePlayerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SinglePlayerButton.Location = New System.Drawing.Point(312, 115)
        Me.SinglePlayerButton.Name = "SinglePlayerButton"
        Me.SinglePlayerButton.Size = New System.Drawing.Size(239, 81)
        Me.SinglePlayerButton.TabIndex = 42
        Me.SinglePlayerButton.Text = "Singleplayer"
        Me.SinglePlayerButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SinglePlayerButton.UseVisualStyleBackColor = False
        '
        'PlayForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(912, 526)
        Me.Controls.Add(Me.MultiplayerButton)
        Me.Controls.Add(Me.SinglePlayerButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PlayForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PlayForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MultiplayerButton As Button
    Friend WithEvents SinglePlayerButton As Button
End Class
