<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Client
    Inherits MetroFramework.Forms.MetroForm

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
        Me.clientLb = New System.Windows.Forms.ListBox()
        Me.MetroContextMenu1 = New MetroFramework.Controls.MetroContextMenu(Me.components)
        Me.Label3 = New MetroFramework.Controls.MetroLabel()
        Me.msgHistoryTxt = New MetroFramework.Controls.MetroTextBox()
        Me.msgTxt = New MetroFramework.Controls.MetroTextBox()
        Me.sendBtn = New MetroFramework.Controls.MetroButton()
        Me.Label5 = New MetroFramework.Controls.MetroLabel()
        Me.showNameTxt = New MetroFramework.Controls.MetroTextBox()
        Me.nameChangeBtn = New MetroFramework.Controls.MetroButton()
        Me.WhoisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KickToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsernameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PokeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MetroContextMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'clientLb
        '
        Me.clientLb.ContextMenuStrip = Me.MetroContextMenu1
        Me.clientLb.FormattingEnabled = True
        Me.clientLb.Location = New System.Drawing.Point(640, 53)
        Me.clientLb.Name = "clientLb"
        Me.clientLb.Size = New System.Drawing.Size(127, 472)
        Me.clientLb.Sorted = True
        Me.clientLb.TabIndex = 11
        '
        'MetroContextMenu1
        '
        Me.MetroContextMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WhoisToolStripMenuItem, Me.KickToolStripMenuItem, Me.BanToolStripMenuItem, Me.MuteToolStripMenuItem, Me.PokeToolStripMenuItem})
        Me.MetroContextMenu1.Name = "MetroContextMenu1"
        Me.MetroContextMenu1.Size = New System.Drawing.Size(153, 136)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(654, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Select receiver"
        '
        'msgHistoryTxt
        '
        '
        '
        '
        Me.msgHistoryTxt.CustomButton.Image = Nothing
        Me.msgHistoryTxt.CustomButton.Location = New System.Drawing.Point(199, 1)
        Me.msgHistoryTxt.CustomButton.Name = ""
        Me.msgHistoryTxt.CustomButton.Size = New System.Drawing.Size(429, 429)
        Me.msgHistoryTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.msgHistoryTxt.CustomButton.TabIndex = 1
        Me.msgHistoryTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.msgHistoryTxt.CustomButton.UseSelectable = True
        Me.msgHistoryTxt.CustomButton.Visible = False
        Me.msgHistoryTxt.Lines = New String(-1) {}
        Me.msgHistoryTxt.Location = New System.Drawing.Point(5, 57)
        Me.msgHistoryTxt.MaxLength = 2139999999
        Me.msgHistoryTxt.Multiline = True
        Me.msgHistoryTxt.Name = "msgHistoryTxt"
        Me.msgHistoryTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.msgHistoryTxt.ReadOnly = True
        Me.msgHistoryTxt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.msgHistoryTxt.SelectedText = ""
        Me.msgHistoryTxt.SelectionLength = 0
        Me.msgHistoryTxt.SelectionStart = 0
        Me.msgHistoryTxt.Size = New System.Drawing.Size(629, 431)
        Me.msgHistoryTxt.TabIndex = 13
        Me.msgHistoryTxt.UseSelectable = True
        Me.msgHistoryTxt.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.msgHistoryTxt.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'msgTxt
        '
        '
        '
        '
        Me.msgTxt.CustomButton.Image = Nothing
        Me.msgTxt.CustomButton.Location = New System.Drawing.Point(518, 1)
        Me.msgTxt.CustomButton.Name = ""
        Me.msgTxt.CustomButton.Size = New System.Drawing.Size(29, 29)
        Me.msgTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.msgTxt.CustomButton.TabIndex = 1
        Me.msgTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.msgTxt.CustomButton.UseSelectable = True
        Me.msgTxt.CustomButton.Visible = False
        Me.msgTxt.Lines = New String(-1) {}
        Me.msgTxt.Location = New System.Drawing.Point(5, 496)
        Me.msgTxt.MaxLength = 32767
        Me.msgTxt.Multiline = True
        Me.msgTxt.Name = "msgTxt"
        Me.msgTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.msgTxt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.msgTxt.SelectedText = ""
        Me.msgTxt.SelectionLength = 0
        Me.msgTxt.SelectionStart = 0
        Me.msgTxt.Size = New System.Drawing.Size(548, 31)
        Me.msgTxt.TabIndex = 14
        Me.msgTxt.UseSelectable = True
        Me.msgTxt.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.msgTxt.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'sendBtn
        '
        Me.sendBtn.Location = New System.Drawing.Point(559, 494)
        Me.sendBtn.Name = "sendBtn"
        Me.sendBtn.Size = New System.Drawing.Size(75, 33)
        Me.sendBtn.TabIndex = 15
        Me.sendBtn.Text = "Send"
        Me.sendBtn.UseSelectable = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(110, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 19)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Shown name:"
        '
        'showNameTxt
        '
        '
        '
        '
        Me.showNameTxt.CustomButton.Image = Nothing
        Me.showNameTxt.CustomButton.Location = New System.Drawing.Point(82, 2)
        Me.showNameTxt.CustomButton.Name = ""
        Me.showNameTxt.CustomButton.Size = New System.Drawing.Size(15, 15)
        Me.showNameTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.showNameTxt.CustomButton.TabIndex = 1
        Me.showNameTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.showNameTxt.CustomButton.UseSelectable = True
        Me.showNameTxt.CustomButton.Visible = False
        Me.showNameTxt.Lines = New String(-1) {}
        Me.showNameTxt.Location = New System.Drawing.Point(203, 27)
        Me.showNameTxt.MaxLength = 32767
        Me.showNameTxt.Name = "showNameTxt"
        Me.showNameTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.showNameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.showNameTxt.SelectedText = ""
        Me.showNameTxt.SelectionLength = 0
        Me.showNameTxt.SelectionStart = 0
        Me.showNameTxt.Size = New System.Drawing.Size(100, 20)
        Me.showNameTxt.TabIndex = 22
        Me.showNameTxt.UseSelectable = True
        Me.showNameTxt.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.showNameTxt.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'nameChangeBtn
        '
        Me.nameChangeBtn.Enabled = False
        Me.nameChangeBtn.Location = New System.Drawing.Point(309, 27)
        Me.nameChangeBtn.Name = "nameChangeBtn"
        Me.nameChangeBtn.Size = New System.Drawing.Size(75, 23)
        Me.nameChangeBtn.TabIndex = 24
        Me.nameChangeBtn.Text = "Change"
        Me.nameChangeBtn.UseSelectable = True
        '
        'WhoisToolStripMenuItem
        '
        Me.WhoisToolStripMenuItem.Name = "WhoisToolStripMenuItem"
        Me.WhoisToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.WhoisToolStripMenuItem.Text = "Whois"
        '
        'KickToolStripMenuItem
        '
        Me.KickToolStripMenuItem.Name = "KickToolStripMenuItem"
        Me.KickToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.KickToolStripMenuItem.Text = "Kick"
        '
        'BanToolStripMenuItem
        '
        Me.BanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsernameToolStripMenuItem, Me.IPToolStripMenuItem})
        Me.BanToolStripMenuItem.Name = "BanToolStripMenuItem"
        Me.BanToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BanToolStripMenuItem.Text = "Ban"
        '
        'UsernameToolStripMenuItem
        '
        Me.UsernameToolStripMenuItem.Name = "UsernameToolStripMenuItem"
        Me.UsernameToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.UsernameToolStripMenuItem.Text = "Username"
        '
        'IPToolStripMenuItem
        '
        Me.IPToolStripMenuItem.Name = "IPToolStripMenuItem"
        Me.IPToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.IPToolStripMenuItem.Text = "IP"
        '
        'MuteToolStripMenuItem
        '
        Me.MuteToolStripMenuItem.Name = "MuteToolStripMenuItem"
        Me.MuteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MuteToolStripMenuItem.Text = "Mute"
        '
        'PokeToolStripMenuItem
        '
        Me.PokeToolStripMenuItem.Name = "PokeToolStripMenuItem"
        Me.PokeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PokeToolStripMenuItem.Text = "Poke"
        '
        'Client
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 535)
        Me.Controls.Add(Me.nameChangeBtn)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.showNameTxt)
        Me.Controls.Add(Me.sendBtn)
        Me.Controls.Add(Me.msgTxt)
        Me.Controls.Add(Me.msgHistoryTxt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.clientLb)
        Me.Name = "Client"
        Me.Text = "Client"
        Me.MetroContextMenu1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents clientLb As ListBox
    Friend WithEvents Label3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents msgHistoryTxt As MetroFramework.Controls.MetroTextBox
    Friend WithEvents msgTxt As MetroFramework.Controls.MetroTextBox
    Friend WithEvents sendBtn As MetroFramework.Controls.MetroButton
    Friend WithEvents usernameTxt As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label4 As MetroFramework.Controls.MetroLabel
    Friend WithEvents Labelx As MetroFramework.Controls.MetroLabel
    Friend WithEvents passwordTxt As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label5 As MetroFramework.Controls.MetroLabel
    Friend WithEvents showNameTxt As MetroFramework.Controls.MetroTextBox
    Friend WithEvents nameChangeBtn As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroContextMenu1 As MetroFramework.Controls.MetroContextMenu
    Friend WithEvents WhoisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KickToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsernameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MuteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PokeToolStripMenuItem As ToolStripMenuItem
End Class
