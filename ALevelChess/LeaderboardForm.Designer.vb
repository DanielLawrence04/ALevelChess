<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LeaderboardForm
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LeaderboardGrid = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FirstPlaceBox = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.SecondPlaceBox = New System.Windows.Forms.PictureBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.ThirdPlaceBox = New System.Windows.Forms.PictureBox()
        Me.FirstLabel = New System.Windows.Forms.Label()
        Me.SecondLabel = New System.Windows.Forms.Label()
        Me.ThirdLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.LeaderboardGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstPlaceBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SecondPlaceBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ThirdPlaceBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LeaderboardGrid
        '
        Me.LeaderboardGrid.AllowUserToAddRows = False
        Me.LeaderboardGrid.AllowUserToDeleteRows = False
        Me.LeaderboardGrid.AllowUserToResizeColumns = False
        Me.LeaderboardGrid.AllowUserToResizeRows = False
        Me.LeaderboardGrid.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LeaderboardGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.LeaderboardGrid.ColumnHeadersHeight = 45
        Me.LeaderboardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.LeaderboardGrid.DefaultCellStyle = DataGridViewCellStyle2
        Me.LeaderboardGrid.GridColor = System.Drawing.Color.Black
        Me.LeaderboardGrid.Location = New System.Drawing.Point(178, 64)
        Me.LeaderboardGrid.MultiSelect = False
        Me.LeaderboardGrid.Name = "LeaderboardGrid"
        Me.LeaderboardGrid.ReadOnly = True
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LeaderboardGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.LeaderboardGrid.RowHeadersWidth = 15
        Me.LeaderboardGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.LeaderboardGrid.Size = New System.Drawing.Size(515, 275)
        Me.LeaderboardGrid.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label6.Location = New System.Drawing.Point(268, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(328, 56)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Leaderboard"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gold
        Me.Panel4.Location = New System.Drawing.Point(292, 370)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(5, 75)
        Me.Panel4.TabIndex = 27
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gold
        Me.Panel3.Location = New System.Drawing.Point(212, 370)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(5, 75)
        Me.Panel3.TabIndex = 28
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Location = New System.Drawing.Point(217, 444)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(75, 5)
        Me.Panel2.TabIndex = 25
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.Location = New System.Drawing.Point(217, 364)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(75, 5)
        Me.Panel1.TabIndex = 26
        '
        'FirstPlaceBox
        '
        Me.FirstPlaceBox.BackColor = System.Drawing.Color.White
        Me.FirstPlaceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FirstPlaceBox.Location = New System.Drawing.Point(217, 369)
        Me.FirstPlaceBox.Name = "FirstPlaceBox"
        Me.FirstPlaceBox.Size = New System.Drawing.Size(75, 75)
        Me.FirstPlaceBox.TabIndex = 24
        Me.FirstPlaceBox.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.Location = New System.Drawing.Point(468, 370)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(5, 75)
        Me.Panel5.TabIndex = 32
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Silver
        Me.Panel6.Location = New System.Drawing.Point(388, 370)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(5, 75)
        Me.Panel6.TabIndex = 33
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Silver
        Me.Panel7.Location = New System.Drawing.Point(393, 444)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(75, 5)
        Me.Panel7.TabIndex = 30
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Silver
        Me.Panel8.Location = New System.Drawing.Point(393, 364)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(75, 5)
        Me.Panel8.TabIndex = 31
        '
        'SecondPlaceBox
        '
        Me.SecondPlaceBox.BackColor = System.Drawing.Color.White
        Me.SecondPlaceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SecondPlaceBox.Location = New System.Drawing.Point(393, 369)
        Me.SecondPlaceBox.Name = "SecondPlaceBox"
        Me.SecondPlaceBox.Size = New System.Drawing.Size(75, 75)
        Me.SecondPlaceBox.TabIndex = 29
        Me.SecondPlaceBox.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.SandyBrown
        Me.Panel9.Location = New System.Drawing.Point(658, 370)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(5, 75)
        Me.Panel9.TabIndex = 37
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.SandyBrown
        Me.Panel10.Location = New System.Drawing.Point(578, 370)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(5, 75)
        Me.Panel10.TabIndex = 38
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.SandyBrown
        Me.Panel11.Location = New System.Drawing.Point(583, 444)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(75, 5)
        Me.Panel11.TabIndex = 35
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SandyBrown
        Me.Panel12.Location = New System.Drawing.Point(583, 364)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(75, 5)
        Me.Panel12.TabIndex = 36
        '
        'ThirdPlaceBox
        '
        Me.ThirdPlaceBox.BackColor = System.Drawing.Color.White
        Me.ThirdPlaceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ThirdPlaceBox.Location = New System.Drawing.Point(583, 369)
        Me.ThirdPlaceBox.Name = "ThirdPlaceBox"
        Me.ThirdPlaceBox.Size = New System.Drawing.Size(75, 75)
        Me.ThirdPlaceBox.TabIndex = 34
        Me.ThirdPlaceBox.TabStop = False
        '
        'FirstLabel
        '
        Me.FirstLabel.AutoSize = True
        Me.FirstLabel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstLabel.ForeColor = System.Drawing.Color.Gainsboro
        Me.FirstLabel.Location = New System.Drawing.Point(163, 342)
        Me.FirstLabel.MinimumSize = New System.Drawing.Size(175, 0)
        Me.FirstLabel.Name = "FirstLabel"
        Me.FirstLabel.Size = New System.Drawing.Size(175, 17)
        Me.FirstLabel.TabIndex = 39
        Me.FirstLabel.Text = "Label1"
        Me.FirstLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SecondLabel
        '
        Me.SecondLabel.AutoSize = True
        Me.SecondLabel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SecondLabel.ForeColor = System.Drawing.Color.Gainsboro
        Me.SecondLabel.Location = New System.Drawing.Point(344, 342)
        Me.SecondLabel.MinimumSize = New System.Drawing.Size(175, 0)
        Me.SecondLabel.Name = "SecondLabel"
        Me.SecondLabel.Size = New System.Drawing.Size(175, 17)
        Me.SecondLabel.TabIndex = 39
        Me.SecondLabel.Text = "Label1"
        Me.SecondLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ThirdLabel
        '
        Me.ThirdLabel.AutoSize = True
        Me.ThirdLabel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ThirdLabel.ForeColor = System.Drawing.Color.Gainsboro
        Me.ThirdLabel.Location = New System.Drawing.Point(535, 342)
        Me.ThirdLabel.MinimumSize = New System.Drawing.Size(175, 0)
        Me.ThirdLabel.Name = "ThirdLabel"
        Me.ThirdLabel.Size = New System.Drawing.Size(175, 17)
        Me.ThirdLabel.TabIndex = 39
        Me.ThirdLabel.Text = "Label1"
        Me.ThirdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gold
        Me.Label1.Location = New System.Drawing.Point(227, 443)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 55)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "❶"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(401, 443)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 55)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "❷"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SandyBrown
        Me.Label3.Location = New System.Drawing.Point(592, 443)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 55)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "❸"
        '
        'LeaderboardForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(912, 526)
        Me.Controls.Add(Me.ThirdLabel)
        Me.Controls.Add(Me.SecondLabel)
        Me.Controls.Add(Me.FirstLabel)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel12)
        Me.Controls.Add(Me.ThirdPlaceBox)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.SecondPlaceBox)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FirstPlaceBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LeaderboardGrid)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LeaderboardForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LeaderboardForm"
        CType(Me.LeaderboardGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstPlaceBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SecondPlaceBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ThirdPlaceBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LeaderboardGrid As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FirstPlaceBox As PictureBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents SecondPlaceBox As PictureBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents ThirdPlaceBox As PictureBox
    Friend WithEvents FirstLabel As Label
    Friend WithEvents SecondLabel As Label
    Friend WithEvents ThirdLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
