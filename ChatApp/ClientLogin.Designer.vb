<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClientLogin
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
        Me.Labelx = New MetroFramework.Controls.MetroLabel()
        Me.passwordTxt = New MetroFramework.Controls.MetroTextBox()
        Me.Label4 = New MetroFramework.Controls.MetroLabel()
        Me.usernameTxt = New MetroFramework.Controls.MetroTextBox()
        Me.Label2 = New MetroFramework.Controls.MetroLabel()
        Me.serverIptxt = New MetroFramework.Controls.MetroTextBox()
        Me.connectBtn = New MetroFramework.Controls.MetroButton()
        Me.serverPortnud = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New MetroFramework.Controls.MetroLabel()
        CType(Me.serverPortnud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Labelx
        '
        Me.Labelx.AutoSize = True
        Me.Labelx.Location = New System.Drawing.Point(62, 116)
        Me.Labelx.Name = "Labelx"
        Me.Labelx.Size = New System.Drawing.Size(66, 19)
        Me.Labelx.TabIndex = 30
        Me.Labelx.Text = "Password:"
        '
        'passwordTxt
        '
        '
        '
        '
        Me.passwordTxt.CustomButton.Image = Nothing
        Me.passwordTxt.CustomButton.Location = New System.Drawing.Point(82, 2)
        Me.passwordTxt.CustomButton.Name = ""
        Me.passwordTxt.CustomButton.Size = New System.Drawing.Size(15, 15)
        Me.passwordTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.passwordTxt.CustomButton.TabIndex = 1
        Me.passwordTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.passwordTxt.CustomButton.UseSelectable = True
        Me.passwordTxt.CustomButton.Visible = False
        Me.passwordTxt.Lines = New String(-1) {}
        Me.passwordTxt.Location = New System.Drawing.Point(132, 113)
        Me.passwordTxt.MaxLength = 32767
        Me.passwordTxt.Name = "passwordTxt"
        Me.passwordTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.passwordTxt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.passwordTxt.SelectedText = ""
        Me.passwordTxt.SelectionLength = 0
        Me.passwordTxt.SelectionStart = 0
        Me.passwordTxt.Size = New System.Drawing.Size(100, 20)
        Me.passwordTxt.TabIndex = 1
        Me.passwordTxt.UseSelectable = True
        Me.passwordTxt.UseSystemPasswordChar = True
        Me.passwordTxt.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.passwordTxt.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 19)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Login:"
        '
        'usernameTxt
        '
        '
        '
        '
        Me.usernameTxt.CustomButton.Image = Nothing
        Me.usernameTxt.CustomButton.Location = New System.Drawing.Point(82, 2)
        Me.usernameTxt.CustomButton.Name = ""
        Me.usernameTxt.CustomButton.Size = New System.Drawing.Size(15, 15)
        Me.usernameTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.usernameTxt.CustomButton.TabIndex = 1
        Me.usernameTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.usernameTxt.CustomButton.UseSelectable = True
        Me.usernameTxt.CustomButton.Visible = False
        Me.usernameTxt.Lines = New String(-1) {}
        Me.usernameTxt.Location = New System.Drawing.Point(132, 88)
        Me.usernameTxt.MaxLength = 32767
        Me.usernameTxt.Name = "usernameTxt"
        Me.usernameTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.usernameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.usernameTxt.SelectedText = ""
        Me.usernameTxt.SelectionLength = 0
        Me.usernameTxt.SelectionStart = 0
        Me.usernameTxt.Size = New System.Drawing.Size(100, 20)
        Me.usernameTxt.TabIndex = 0
        Me.usernameTxt.UseSelectable = True
        Me.usernameTxt.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.usernameTxt.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 19)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "IP:"
        '
        'serverIptxt
        '
        '
        '
        '
        Me.serverIptxt.CustomButton.Image = Nothing
        Me.serverIptxt.CustomButton.Location = New System.Drawing.Point(75, 2)
        Me.serverIptxt.CustomButton.Name = ""
        Me.serverIptxt.CustomButton.Size = New System.Drawing.Size(15, 15)
        Me.serverIptxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.serverIptxt.CustomButton.TabIndex = 1
        Me.serverIptxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.serverIptxt.CustomButton.UseSelectable = True
        Me.serverIptxt.CustomButton.Visible = False
        Me.serverIptxt.Lines = New String() {"127.0.0.1"}
        Me.serverIptxt.Location = New System.Drawing.Point(60, 62)
        Me.serverIptxt.MaxLength = 32767
        Me.serverIptxt.Name = "serverIptxt"
        Me.serverIptxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.serverIptxt.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.serverIptxt.SelectedText = ""
        Me.serverIptxt.SelectionLength = 0
        Me.serverIptxt.SelectionStart = 0
        Me.serverIptxt.Size = New System.Drawing.Size(93, 20)
        Me.serverIptxt.TabIndex = 3
        Me.serverIptxt.Text = "127.0.0.1"
        Me.serverIptxt.UseSelectable = True
        Me.serverIptxt.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.serverIptxt.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'connectBtn
        '
        Me.connectBtn.Location = New System.Drawing.Point(156, 138)
        Me.connectBtn.Name = "connectBtn"
        Me.connectBtn.Size = New System.Drawing.Size(75, 23)
        Me.connectBtn.TabIndex = 2
        Me.connectBtn.Text = "Connect"
        Me.connectBtn.UseSelectable = True
        '
        'serverPortnud
        '
        Me.serverPortnud.Location = New System.Drawing.Point(159, 62)
        Me.serverPortnud.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.serverPortnud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.serverPortnud.Name = "serverPortnud"
        Me.serverPortnud.Size = New System.Drawing.Size(71, 20)
        Me.serverPortnud.TabIndex = 4
        Me.serverPortnud.Value = New Decimal(New Integer() {1604, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(150, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 19)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = ":"
        '
        'ClientLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 179)
        Me.Controls.Add(Me.Labelx)
        Me.Controls.Add(Me.passwordTxt)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.usernameTxt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.serverIptxt)
        Me.Controls.Add(Me.connectBtn)
        Me.Controls.Add(Me.serverPortnud)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ClientLogin"
        Me.Text = "ClientLogin"
        CType(Me.serverPortnud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents usernameTxt As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents serverIptxt As MetroFramework.Controls.MetroTextBox
    Friend WithEvents connectBtn As MetroFramework.Controls.MetroButton
    Friend WithEvents serverPortnud As NumericUpDown
    Friend WithEvents Label1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents Labelx As MetroFramework.Controls.MetroLabel
    Friend WithEvents passwordTxt As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Label4 As MetroFramework.Controls.MetroLabel
End Class
