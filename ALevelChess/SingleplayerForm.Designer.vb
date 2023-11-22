<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SingleplayerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SingleplayerForm))
        Me.EasyButton = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.HardButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'EasyButton
        '
        Me.EasyButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.EasyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EasyButton.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EasyButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.EasyButton.Image = CType(resources.GetObject("EasyButton.Image"), System.Drawing.Image)
        Me.EasyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EasyButton.Location = New System.Drawing.Point(342, 162)
        Me.EasyButton.Name = "EasyButton"
        Me.EasyButton.Size = New System.Drawing.Size(164, 78)
        Me.EasyButton.TabIndex = 43
        Me.EasyButton.Text = "Easy"
        Me.EasyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EasyButton.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label6.Location = New System.Drawing.Point(318, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(222, 56)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Difficulty"
        '
        'HardButton
        '
        Me.HardButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.HardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.HardButton.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HardButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.HardButton.Image = CType(resources.GetObject("HardButton.Image"), System.Drawing.Image)
        Me.HardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.HardButton.Location = New System.Drawing.Point(342, 276)
        Me.HardButton.Name = "HardButton"
        Me.HardButton.Size = New System.Drawing.Size(164, 78)
        Me.HardButton.TabIndex = 43
        Me.HardButton.Text = "Hard"
        Me.HardButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.HardButton.UseVisualStyleBackColor = False
        '
        'SingleplayerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(912, 526)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.HardButton)
        Me.Controls.Add(Me.EasyButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SingleplayerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SingleplayerForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EasyButton As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents HardButton As Button
End Class
