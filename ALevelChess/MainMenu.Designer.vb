<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SelectedSignOutTab = New System.Windows.Forms.Panel()
        Me.SignOutButton = New System.Windows.Forms.Button()
        Me.SelectedCustomiseTab = New System.Windows.Forms.Panel()
        Me.SelectedSettingsTab = New System.Windows.Forms.Panel()
        Me.SelectedRulesTab = New System.Windows.Forms.Panel()
        Me.SelectedReplaysTab = New System.Windows.Forms.Panel()
        Me.SelectedLeaderBoardTab = New System.Windows.Forms.Panel()
        Me.SelectedPlayTab = New System.Windows.Forms.Panel()
        Me.SelectedHomeTab = New System.Windows.Forms.Panel()
        Me.SettingsButton = New System.Windows.Forms.Button()
        Me.RulesButton = New System.Windows.Forms.Button()
        Me.ReplaysButton = New System.Windows.Forms.Button()
        Me.LeaderboardButton = New System.Windows.Forms.Button()
        Me.CustomiseButton = New System.Windows.Forms.Button()
        Me.PlayButton = New System.Windows.Forms.Button()
        Me.HomeButton = New System.Windows.Forms.Button()
        Me.PanelLogo = New System.Windows.Forms.Panel()
        Me.imgHome = New System.Windows.Forms.PictureBox()
        Me.PanelTitleBar = New System.Windows.Forms.Panel()
        Me.Datelabel = New System.Windows.Forms.Label()
        Me.UserLabel = New System.Windows.Forms.Label()
        Me.ProfilePicture = New System.Windows.Forms.PictureBox()
        Me.ExitButton = New System.Windows.Forms.Label()
        Me.HoverTool = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.PanelLogo.SuspendLayout()
        CType(Me.imgHome, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTitleBar.SuspendLayout()
        CType(Me.ProfilePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Panel1.Controls.Add(Me.SelectedSignOutTab)
        Me.Panel1.Controls.Add(Me.SignOutButton)
        Me.Panel1.Controls.Add(Me.SelectedCustomiseTab)
        Me.Panel1.Controls.Add(Me.SelectedSettingsTab)
        Me.Panel1.Controls.Add(Me.SelectedRulesTab)
        Me.Panel1.Controls.Add(Me.SelectedReplaysTab)
        Me.Panel1.Controls.Add(Me.SelectedLeaderBoardTab)
        Me.Panel1.Controls.Add(Me.SelectedPlayTab)
        Me.Panel1.Controls.Add(Me.SelectedHomeTab)
        Me.Panel1.Controls.Add(Me.SettingsButton)
        Me.Panel1.Controls.Add(Me.RulesButton)
        Me.Panel1.Controls.Add(Me.ReplaysButton)
        Me.Panel1.Controls.Add(Me.LeaderboardButton)
        Me.Panel1.Controls.Add(Me.CustomiseButton)
        Me.Panel1.Controls.Add(Me.PlayButton)
        Me.Panel1.Controls.Add(Me.HomeButton)
        Me.Panel1.Controls.Add(Me.PanelLogo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(191, 613)
        Me.Panel1.TabIndex = 0
        '
        'SelectedSignOutTab
        '
        Me.SelectedSignOutTab.BackColor = System.Drawing.Color.Salmon
        Me.SelectedSignOutTab.Location = New System.Drawing.Point(186, 551)
        Me.SelectedSignOutTab.Name = "SelectedSignOutTab"
        Me.SelectedSignOutTab.Size = New System.Drawing.Size(5, 60)
        Me.SelectedSignOutTab.TabIndex = 11
        Me.SelectedSignOutTab.Visible = False
        '
        'SignOutButton
        '
        Me.SignOutButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.SignOutButton.FlatAppearance.BorderSize = 0
        Me.SignOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SignOutButton.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.SignOutButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.SignOutButton.Image = CType(resources.GetObject("SignOutButton.Image"), System.Drawing.Image)
        Me.SignOutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SignOutButton.Location = New System.Drawing.Point(0, 550)
        Me.SignOutButton.Name = "SignOutButton"
        Me.SignOutButton.Size = New System.Drawing.Size(191, 60)
        Me.SignOutButton.TabIndex = 10
        Me.SignOutButton.Text = "Sign Out"
        Me.SignOutButton.UseVisualStyleBackColor = True
        '
        'SelectedCustomiseTab
        '
        Me.SelectedCustomiseTab.BackColor = System.Drawing.Color.Salmon
        Me.SelectedCustomiseTab.Location = New System.Drawing.Point(186, 250)
        Me.SelectedCustomiseTab.Name = "SelectedCustomiseTab"
        Me.SelectedCustomiseTab.Size = New System.Drawing.Size(5, 60)
        Me.SelectedCustomiseTab.TabIndex = 9
        Me.SelectedCustomiseTab.Visible = False
        '
        'SelectedSettingsTab
        '
        Me.SelectedSettingsTab.BackColor = System.Drawing.Color.Salmon
        Me.SelectedSettingsTab.Location = New System.Drawing.Point(186, 491)
        Me.SelectedSettingsTab.Name = "SelectedSettingsTab"
        Me.SelectedSettingsTab.Size = New System.Drawing.Size(5, 60)
        Me.SelectedSettingsTab.TabIndex = 9
        Me.SelectedSettingsTab.Visible = False
        '
        'SelectedRulesTab
        '
        Me.SelectedRulesTab.BackColor = System.Drawing.Color.Salmon
        Me.SelectedRulesTab.Location = New System.Drawing.Point(186, 430)
        Me.SelectedRulesTab.Name = "SelectedRulesTab"
        Me.SelectedRulesTab.Size = New System.Drawing.Size(5, 60)
        Me.SelectedRulesTab.TabIndex = 9
        Me.SelectedRulesTab.Visible = False
        '
        'SelectedReplaysTab
        '
        Me.SelectedReplaysTab.BackColor = System.Drawing.Color.Salmon
        Me.SelectedReplaysTab.Location = New System.Drawing.Point(186, 370)
        Me.SelectedReplaysTab.Name = "SelectedReplaysTab"
        Me.SelectedReplaysTab.Size = New System.Drawing.Size(5, 60)
        Me.SelectedReplaysTab.TabIndex = 9
        Me.SelectedReplaysTab.Visible = False
        '
        'SelectedLeaderBoardTab
        '
        Me.SelectedLeaderBoardTab.BackColor = System.Drawing.Color.Salmon
        Me.SelectedLeaderBoardTab.Location = New System.Drawing.Point(186, 310)
        Me.SelectedLeaderBoardTab.Name = "SelectedLeaderBoardTab"
        Me.SelectedLeaderBoardTab.Size = New System.Drawing.Size(5, 60)
        Me.SelectedLeaderBoardTab.TabIndex = 9
        Me.SelectedLeaderBoardTab.Visible = False
        '
        'SelectedPlayTab
        '
        Me.SelectedPlayTab.BackColor = System.Drawing.Color.Salmon
        Me.SelectedPlayTab.Location = New System.Drawing.Point(186, 190)
        Me.SelectedPlayTab.Name = "SelectedPlayTab"
        Me.SelectedPlayTab.Size = New System.Drawing.Size(5, 60)
        Me.SelectedPlayTab.TabIndex = 9
        Me.SelectedPlayTab.Visible = False
        '
        'SelectedHomeTab
        '
        Me.SelectedHomeTab.BackColor = System.Drawing.Color.Salmon
        Me.SelectedHomeTab.Location = New System.Drawing.Point(186, 130)
        Me.SelectedHomeTab.Name = "SelectedHomeTab"
        Me.SelectedHomeTab.Size = New System.Drawing.Size(5, 60)
        Me.SelectedHomeTab.TabIndex = 9
        '
        'SettingsButton
        '
        Me.SettingsButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.SettingsButton.FlatAppearance.BorderSize = 0
        Me.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SettingsButton.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.SettingsButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.SettingsButton.Image = CType(resources.GetObject("SettingsButton.Image"), System.Drawing.Image)
        Me.SettingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SettingsButton.Location = New System.Drawing.Point(0, 490)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(191, 60)
        Me.SettingsButton.TabIndex = 8
        Me.SettingsButton.Text = "Settings"
        Me.SettingsButton.UseVisualStyleBackColor = True
        '
        'RulesButton
        '
        Me.RulesButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.RulesButton.FlatAppearance.BorderSize = 0
        Me.RulesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RulesButton.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.RulesButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.RulesButton.Image = CType(resources.GetObject("RulesButton.Image"), System.Drawing.Image)
        Me.RulesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RulesButton.Location = New System.Drawing.Point(0, 430)
        Me.RulesButton.Name = "RulesButton"
        Me.RulesButton.Size = New System.Drawing.Size(191, 60)
        Me.RulesButton.TabIndex = 7
        Me.RulesButton.Text = "Rules"
        Me.RulesButton.UseVisualStyleBackColor = True
        '
        'ReplaysButton
        '
        Me.ReplaysButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.ReplaysButton.FlatAppearance.BorderSize = 0
        Me.ReplaysButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ReplaysButton.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.ReplaysButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.ReplaysButton.Image = CType(resources.GetObject("ReplaysButton.Image"), System.Drawing.Image)
        Me.ReplaysButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ReplaysButton.Location = New System.Drawing.Point(0, 370)
        Me.ReplaysButton.Name = "ReplaysButton"
        Me.ReplaysButton.Size = New System.Drawing.Size(191, 60)
        Me.ReplaysButton.TabIndex = 6
        Me.ReplaysButton.Text = "Replays"
        Me.ReplaysButton.UseVisualStyleBackColor = True
        '
        'LeaderboardButton
        '
        Me.LeaderboardButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.LeaderboardButton.FlatAppearance.BorderSize = 0
        Me.LeaderboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LeaderboardButton.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.LeaderboardButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.LeaderboardButton.Image = CType(resources.GetObject("LeaderboardButton.Image"), System.Drawing.Image)
        Me.LeaderboardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LeaderboardButton.Location = New System.Drawing.Point(0, 310)
        Me.LeaderboardButton.Name = "LeaderboardButton"
        Me.LeaderboardButton.Size = New System.Drawing.Size(191, 60)
        Me.LeaderboardButton.TabIndex = 5
        Me.LeaderboardButton.Text = "Leaderboard "
        Me.LeaderboardButton.UseVisualStyleBackColor = True
        '
        'CustomiseButton
        '
        Me.CustomiseButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.CustomiseButton.FlatAppearance.BorderSize = 0
        Me.CustomiseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CustomiseButton.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.CustomiseButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.CustomiseButton.Image = CType(resources.GetObject("CustomiseButton.Image"), System.Drawing.Image)
        Me.CustomiseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CustomiseButton.Location = New System.Drawing.Point(0, 250)
        Me.CustomiseButton.Name = "CustomiseButton"
        Me.CustomiseButton.Size = New System.Drawing.Size(191, 60)
        Me.CustomiseButton.TabIndex = 4
        Me.CustomiseButton.Text = "Customise"
        Me.CustomiseButton.UseVisualStyleBackColor = True
        '
        'PlayButton
        '
        Me.PlayButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.PlayButton.FlatAppearance.BorderSize = 0
        Me.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PlayButton.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.PlayButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.PlayButton.Image = CType(resources.GetObject("PlayButton.Image"), System.Drawing.Image)
        Me.PlayButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PlayButton.Location = New System.Drawing.Point(0, 190)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(191, 60)
        Me.PlayButton.TabIndex = 3
        Me.PlayButton.Text = "Play"
        Me.PlayButton.UseVisualStyleBackColor = True
        '
        'HomeButton
        '
        Me.HomeButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.HomeButton.FlatAppearance.BorderSize = 0
        Me.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.HomeButton.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomeButton.ForeColor = System.Drawing.Color.Gainsboro
        Me.HomeButton.Image = CType(resources.GetObject("HomeButton.Image"), System.Drawing.Image)
        Me.HomeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.HomeButton.Location = New System.Drawing.Point(0, 130)
        Me.HomeButton.Name = "HomeButton"
        Me.HomeButton.Size = New System.Drawing.Size(191, 60)
        Me.HomeButton.TabIndex = 2
        Me.HomeButton.Text = "Home"
        Me.HomeButton.UseVisualStyleBackColor = True
        '
        'PanelLogo
        '
        Me.PanelLogo.Controls.Add(Me.imgHome)
        Me.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelLogo.Location = New System.Drawing.Point(0, 0)
        Me.PanelLogo.Name = "PanelLogo"
        Me.PanelLogo.Size = New System.Drawing.Size(191, 130)
        Me.PanelLogo.TabIndex = 1
        '
        'imgHome
        '
        Me.imgHome.Image = CType(resources.GetObject("imgHome.Image"), System.Drawing.Image)
        Me.imgHome.Location = New System.Drawing.Point(0, 0)
        Me.imgHome.Name = "imgHome"
        Me.imgHome.Size = New System.Drawing.Size(191, 130)
        Me.imgHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgHome.TabIndex = 0
        Me.imgHome.TabStop = False
        '
        'PanelTitleBar
        '
        Me.PanelTitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.PanelTitleBar.Controls.Add(Me.Datelabel)
        Me.PanelTitleBar.Controls.Add(Me.UserLabel)
        Me.PanelTitleBar.Controls.Add(Me.ProfilePicture)
        Me.PanelTitleBar.Controls.Add(Me.ExitButton)
        Me.PanelTitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTitleBar.Location = New System.Drawing.Point(191, 0)
        Me.PanelTitleBar.Name = "PanelTitleBar"
        Me.PanelTitleBar.Size = New System.Drawing.Size(912, 87)
        Me.PanelTitleBar.TabIndex = 1
        '
        'Datelabel
        '
        Me.Datelabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Datelabel.AutoSize = True
        Me.Datelabel.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Datelabel.ForeColor = System.Drawing.Color.Gainsboro
        Me.Datelabel.Location = New System.Drawing.Point(678, 50)
        Me.Datelabel.Name = "Datelabel"
        Me.Datelabel.Size = New System.Drawing.Size(0, 22)
        Me.Datelabel.TabIndex = 2
        '
        'UserLabel
        '
        Me.UserLabel.AutoSize = True
        Me.UserLabel.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel.ForeColor = System.Drawing.Color.Gainsboro
        Me.UserLabel.Location = New System.Drawing.Point(87, 29)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(68, 33)
        Me.UserLabel.TabIndex = 2
        Me.UserLabel.Text = "User"
        '
        'ProfilePicture
        '
        Me.ProfilePicture.Location = New System.Drawing.Point(6, 6)
        Me.ProfilePicture.Name = "ProfilePicture"
        Me.ProfilePicture.Size = New System.Drawing.Size(75, 75)
        Me.ProfilePicture.TabIndex = 1
        Me.ProfilePicture.TabStop = False
        '
        'ExitButton
        '
        Me.ExitButton.AutoSize = True
        Me.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExitButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.ExitButton.Font = New System.Drawing.Font("Century Gothic", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.ForeColor = System.Drawing.Color.Red
        Me.ExitButton.Image = CType(resources.GetObject("ExitButton.Image"), System.Drawing.Image)
        Me.ExitButton.Location = New System.Drawing.Point(877, 0)
        Me.ExitButton.MinimumSize = New System.Drawing.Size(35, 35)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(35, 42)
        Me.ExitButton.TabIndex = 0
        '
        'MainPanel
        '
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(191, 87)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(912, 526)
        Me.MainPanel.TabIndex = 2
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1103, 613)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.PanelTitleBar)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainMenuTest"
        Me.Panel1.ResumeLayout(False)
        Me.PanelLogo.ResumeLayout(False)
        CType(Me.imgHome, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTitleBar.ResumeLayout(False)
        Me.PanelTitleBar.PerformLayout()
        CType(Me.ProfilePicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelLogo As Panel
    Friend WithEvents imgHome As PictureBox
    Friend WithEvents HomeButton As Button
    Friend WithEvents RulesButton As Button
    Friend WithEvents ReplaysButton As Button
    Friend WithEvents LeaderboardButton As Button
    Friend WithEvents CustomiseButton As Button
    Friend WithEvents PlayButton As Button
    Friend WithEvents PanelTitleBar As Panel
    Friend WithEvents SettingsButton As Button
    Friend WithEvents ExitButton As Label
    Friend WithEvents HoverTool As ToolTip
    Friend WithEvents SelectedHomeTab As Panel
    Friend WithEvents SelectedCustomiseTab As Panel
    Friend WithEvents SelectedSettingsTab As Panel
    Friend WithEvents SelectedRulesTab As Panel
    Friend WithEvents SelectedReplaysTab As Panel
    Friend WithEvents SelectedLeaderBoardTab As Panel
    Friend WithEvents SelectedPlayTab As Panel
    Friend WithEvents UserLabel As Label
    Friend WithEvents ProfilePicture As PictureBox
    Friend WithEvents SelectedSignOutTab As Panel
    Friend WithEvents SignOutButton As Button
    Friend WithEvents MainPanel As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Datelabel As Label
End Class
