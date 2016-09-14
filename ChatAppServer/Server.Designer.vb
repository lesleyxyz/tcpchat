<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Server
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
        Me.serverPortnud = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.listenBtn = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.stopBtn = New System.Windows.Forms.Button()
        Me.getAllClients = New System.Windows.Forms.Button()
        Me.bufferSizeNud = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.connectionNud = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.packetSizeNud = New System.Windows.Forms.NumericUpDown()
        Me.keepAliveCb = New System.Windows.Forms.CheckBox()
        Me.msgTxt = New System.Windows.Forms.TextBox()
        Me.sendBtn = New System.Windows.Forms.Button()
        Me.rawMsgCb = New System.Windows.Forms.CheckBox()
        Me.passLb = New System.Windows.Forms.ListBox()
        Me.showNameLb = New System.Windows.Forms.ListBox()
        Me.userLb = New System.Windows.Forms.ListBox()
        Me.keyLb = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ipTxt = New System.Windows.Forms.TextBox()
        CType(Me.serverPortnud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bufferSizeNud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.connectionNud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.packetSizeNud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'serverPortnud
        '
        Me.serverPortnud.Location = New System.Drawing.Point(422, 7)
        Me.serverPortnud.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.serverPortnud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.serverPortnud.Name = "serverPortnud"
        Me.serverPortnud.Size = New System.Drawing.Size(71, 20)
        Me.serverPortnud.TabIndex = 0
        Me.serverPortnud.Value = New Decimal(New Integer() {1604, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(393, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Port:"
        '
        'listenBtn
        '
        Me.listenBtn.Location = New System.Drawing.Point(422, 41)
        Me.listenBtn.Name = "listenBtn"
        Me.listenBtn.Size = New System.Drawing.Size(75, 23)
        Me.listenBtn.TabIndex = 2
        Me.listenBtn.Text = "Listen"
        Me.listenBtn.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(0, 394)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(590, 446)
        Me.ListBox1.TabIndex = 3
        '
        'stopBtn
        '
        Me.stopBtn.Location = New System.Drawing.Point(505, 41)
        Me.stopBtn.Name = "stopBtn"
        Me.stopBtn.Size = New System.Drawing.Size(75, 23)
        Me.stopBtn.TabIndex = 4
        Me.stopBtn.Text = "Stop"
        Me.stopBtn.UseVisualStyleBackColor = True
        '
        'getAllClients
        '
        Me.getAllClients.Location = New System.Drawing.Point(505, 12)
        Me.getAllClients.Name = "getAllClients"
        Me.getAllClients.Size = New System.Drawing.Size(75, 23)
        Me.getAllClients.TabIndex = 5
        Me.getAllClients.Text = "GetClients"
        Me.getAllClients.UseVisualStyleBackColor = True
        '
        'bufferSizeNud
        '
        Me.bufferSizeNud.Location = New System.Drawing.Point(99, 3)
        Me.bufferSizeNud.Maximum = New Decimal(New Integer() {1661992959, 1808227885, 5, 0})
        Me.bufferSizeNud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.bufferSizeNud.Name = "bufferSizeNud"
        Me.bufferSizeNud.Size = New System.Drawing.Size(139, 20)
        Me.bufferSizeNud.TabIndex = 6
        Me.bufferSizeNud.Value = New Decimal(New Integer() {64000, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Max buffer size:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Max connections:"
        '
        'connectionNud
        '
        Me.connectionNud.Location = New System.Drawing.Point(99, 24)
        Me.connectionNud.Maximum = New Decimal(New Integer() {1661992959, 1808227885, 5, 0})
        Me.connectionNud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.connectionNud.Name = "connectionNud"
        Me.connectionNud.Size = New System.Drawing.Size(139, 20)
        Me.connectionNud.TabIndex = 8
        Me.connectionNud.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Max packet size:"
        '
        'packetSizeNud
        '
        Me.packetSizeNud.Location = New System.Drawing.Point(99, 45)
        Me.packetSizeNud.Maximum = New Decimal(New Integer() {1661992959, 1808227885, 5, 0})
        Me.packetSizeNud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.packetSizeNud.Name = "packetSizeNud"
        Me.packetSizeNud.Size = New System.Drawing.Size(139, 20)
        Me.packetSizeNud.TabIndex = 11
        Me.packetSizeNud.Value = New Decimal(New Integer() {10485760, 0, 0, 0})
        '
        'keepAliveCb
        '
        Me.keepAliveCb.AutoSize = True
        Me.keepAliveCb.Checked = True
        Me.keepAliveCb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.keepAliveCb.Location = New System.Drawing.Point(257, 3)
        Me.keepAliveCb.Name = "keepAliveCb"
        Me.keepAliveCb.Size = New System.Drawing.Size(77, 17)
        Me.keepAliveCb.TabIndex = 12
        Me.keepAliveCb.Text = "Keep Alive"
        Me.keepAliveCb.UseVisualStyleBackColor = True
        '
        'msgTxt
        '
        Me.msgTxt.Location = New System.Drawing.Point(9, 367)
        Me.msgTxt.Name = "msgTxt"
        Me.msgTxt.Size = New System.Drawing.Size(488, 20)
        Me.msgTxt.TabIndex = 13
        '
        'sendBtn
        '
        Me.sendBtn.Location = New System.Drawing.Point(505, 365)
        Me.sendBtn.Name = "sendBtn"
        Me.sendBtn.Size = New System.Drawing.Size(75, 23)
        Me.sendBtn.TabIndex = 14
        Me.sendBtn.Text = "Send"
        Me.sendBtn.UseVisualStyleBackColor = True
        '
        'rawMsgCb
        '
        Me.rawMsgCb.AutoSize = True
        Me.rawMsgCb.Checked = True
        Me.rawMsgCb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rawMsgCb.Location = New System.Drawing.Point(492, 344)
        Me.rawMsgCb.Name = "rawMsgCb"
        Me.rawMsgCb.Size = New System.Drawing.Size(48, 17)
        Me.rawMsgCb.TabIndex = 15
        Me.rawMsgCb.Text = "Raw"
        Me.rawMsgCb.UseVisualStyleBackColor = True
        '
        'passLb
        '
        Me.passLb.FormattingEnabled = True
        Me.passLb.Location = New System.Drawing.Point(824, 3)
        Me.passLb.Name = "passLb"
        Me.passLb.Size = New System.Drawing.Size(220, 836)
        Me.passLb.TabIndex = 16
        '
        'showNameLb
        '
        Me.showNameLb.FormattingEnabled = True
        Me.showNameLb.Location = New System.Drawing.Point(1050, 3)
        Me.showNameLb.Name = "showNameLb"
        Me.showNameLb.Size = New System.Drawing.Size(220, 836)
        Me.showNameLb.TabIndex = 17
        '
        'userLb
        '
        Me.userLb.FormattingEnabled = True
        Me.userLb.Location = New System.Drawing.Point(598, 3)
        Me.userLb.Name = "userLb"
        Me.userLb.Size = New System.Drawing.Size(220, 836)
        Me.userLb.TabIndex = 18
        '
        'keyLb
        '
        Me.keyLb.FormattingEnabled = True
        Me.keyLb.Location = New System.Drawing.Point(1284, 3)
        Me.keyLb.Name = "keyLb"
        Me.keyLb.Size = New System.Drawing.Size(220, 836)
        Me.keyLb.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(244, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Port:"
        '
        'ipTxt
        '
        Me.ipTxt.Location = New System.Drawing.Point(279, 24)
        Me.ipTxt.Name = "ipTxt"
        Me.ipTxt.Size = New System.Drawing.Size(143, 20)
        Me.ipTxt.TabIndex = 22
        Me.ipTxt.Text = "0.0.0.0"
        '
        'Server
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1516, 845)
        Me.Controls.Add(Me.ipTxt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.keyLb)
        Me.Controls.Add(Me.userLb)
        Me.Controls.Add(Me.showNameLb)
        Me.Controls.Add(Me.passLb)
        Me.Controls.Add(Me.rawMsgCb)
        Me.Controls.Add(Me.sendBtn)
        Me.Controls.Add(Me.msgTxt)
        Me.Controls.Add(Me.keepAliveCb)
        Me.Controls.Add(Me.packetSizeNud)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.connectionNud)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bufferSizeNud)
        Me.Controls.Add(Me.getAllClients)
        Me.Controls.Add(Me.stopBtn)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.listenBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.serverPortnud)
        Me.Name = "Server"
        Me.Text = "Server"
        CType(Me.serverPortnud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bufferSizeNud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.connectionNud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.packetSizeNud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents serverPortnud As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents listenBtn As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents stopBtn As Button
    Friend WithEvents getAllClients As Button
    Friend WithEvents bufferSizeNud As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents connectionNud As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents packetSizeNud As NumericUpDown
    Friend WithEvents keepAliveCb As CheckBox
    Friend WithEvents msgTxt As TextBox
    Friend WithEvents sendBtn As Button
    Friend WithEvents rawMsgCb As CheckBox
    Friend WithEvents passLb As ListBox
    Friend WithEvents showNameLb As ListBox
    Friend WithEvents userLb As ListBox
    Friend WithEvents keyLb As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ipTxt As TextBox
End Class
