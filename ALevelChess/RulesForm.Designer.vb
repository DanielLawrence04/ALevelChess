<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RulesForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RulesForm))
        Me.RulesButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RulesButton
        '
        Me.RulesButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RulesButton.FlatAppearance.BorderSize = 0
        Me.RulesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RulesButton.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RulesButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.RulesButton.Image = CType(resources.GetObject("RulesButton.Image"), System.Drawing.Image)
        Me.RulesButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.RulesButton.Location = New System.Drawing.Point(0, 0)
        Me.RulesButton.Name = "RulesButton"
        Me.RulesButton.Size = New System.Drawing.Size(912, 526)
        Me.RulesButton.TabIndex = 23
        Me.RulesButton.Text = "Open document"
        Me.RulesButton.UseVisualStyleBackColor = True
        '
        'RulesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(912, 526)
        Me.Controls.Add(Me.RulesButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RulesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RulesForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RulesButton As Button
End Class
