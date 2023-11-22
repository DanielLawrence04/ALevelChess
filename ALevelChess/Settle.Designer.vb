<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settle))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Player1Box = New System.Windows.Forms.PictureBox()
        Me.Player2Box = New System.Windows.Forms.PictureBox()
        Me.P1Yes = New System.Windows.Forms.Button()
        Me.P1No = New System.Windows.Forms.Button()
        Me.P2Yes = New System.Windows.Forms.Button()
        Me.P2No = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        CType(Me.Player1Box, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player2Box, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(44, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Player 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Calligraphy", 9.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(190, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Player2"
        '
        'Player1Box
        '
        Me.Player1Box.BackgroundImage = CType(resources.GetObject("Player1Box.BackgroundImage"), System.Drawing.Image)
        Me.Player1Box.Image = CType(resources.GetObject("Player1Box.Image"), System.Drawing.Image)
        Me.Player1Box.Location = New System.Drawing.Point(39, 51)
        Me.Player1Box.Name = "Player1Box"
        Me.Player1Box.Size = New System.Drawing.Size(75, 75)
        Me.Player1Box.TabIndex = 1
        Me.Player1Box.TabStop = False
        Me.Player1Box.Visible = False
        '
        'Player2Box
        '
        Me.Player2Box.BackgroundImage = CType(resources.GetObject("Player2Box.BackgroundImage"), System.Drawing.Image)
        Me.Player2Box.Image = CType(resources.GetObject("Player2Box.Image"), System.Drawing.Image)
        Me.Player2Box.Location = New System.Drawing.Point(181, 51)
        Me.Player2Box.Name = "Player2Box"
        Me.Player2Box.Size = New System.Drawing.Size(75, 75)
        Me.Player2Box.TabIndex = 1
        Me.Player2Box.TabStop = False
        Me.Player2Box.Visible = False
        '
        'P1Yes
        '
        Me.P1Yes.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.P1Yes.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!)
        Me.P1Yes.Location = New System.Drawing.Point(27, 78)
        Me.P1Yes.Name = "P1Yes"
        Me.P1Yes.Size = New System.Drawing.Size(35, 35)
        Me.P1Yes.TabIndex = 2
        Me.P1Yes.Text = "Yes"
        Me.P1Yes.UseVisualStyleBackColor = False
        '
        'P1No
        '
        Me.P1No.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.P1No.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!)
        Me.P1No.Location = New System.Drawing.Point(94, 78)
        Me.P1No.Name = "P1No"
        Me.P1No.Size = New System.Drawing.Size(35, 35)
        Me.P1No.TabIndex = 2
        Me.P1No.Text = "No"
        Me.P1No.UseVisualStyleBackColor = False
        '
        'P2Yes
        '
        Me.P2Yes.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.P2Yes.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!)
        Me.P2Yes.Location = New System.Drawing.Point(172, 78)
        Me.P2Yes.Name = "P2Yes"
        Me.P2Yes.Size = New System.Drawing.Size(35, 35)
        Me.P2Yes.TabIndex = 2
        Me.P2Yes.Text = "Yes"
        Me.P2Yes.UseVisualStyleBackColor = False
        '
        'P2No
        '
        Me.P2No.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.P2No.Font = New System.Drawing.Font("Lucida Calligraphy", 8.25!)
        Me.P2No.Location = New System.Drawing.Point(239, 78)
        Me.P2No.Name = "P2No"
        Me.P2No.Size = New System.Drawing.Size(35, 35)
        Me.P2No.TabIndex = 2
        Me.P2No.Text = "No"
        Me.P2No.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(146, -4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(5, 144)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(295, 5)
        Me.Panel2.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Location = New System.Drawing.Point(0, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(5, 144)
        Me.Panel3.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Location = New System.Drawing.Point(295, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(5, 144)
        Me.Panel4.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Location = New System.Drawing.Point(5, 137)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(295, 5)
        Me.Panel5.TabIndex = 4
        '
        'Settle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(300, 142)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.P2No)
        Me.Controls.Add(Me.P2Yes)
        Me.Controls.Add(Me.P1No)
        Me.Controls.Add(Me.P1Yes)
        Me.Controls.Add(Me.Player2Box)
        Me.Controls.Add(Me.Player1Box)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Settle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settle"
        CType(Me.Player1Box, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player2Box, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Player1Box As PictureBox
    Friend WithEvents Player2Box As PictureBox
    Friend WithEvents P1Yes As Button
    Friend WithEvents P1No As Button
    Friend WithEvents P2Yes As Button
    Friend WithEvents P2No As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
End Class
