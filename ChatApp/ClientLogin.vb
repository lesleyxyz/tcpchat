Public Class ClientLogin

    Public c As New Client
    Private Sub connectBtn_Click_1(sender As Object, e As EventArgs) Handles connectBtn.Click
        c.Show()
        c.Visible = True
        c.showNameTxt.Text = usernameTxt.Text
        c.username = usernameTxt.Text
        c.password = passwordTxt.Text
        c.serverIP = serverIptxt.Text
        c.serverPort = serverPortnud.Value
        c.loginHandle = Me
        'TODO: Store ShownameTxt & UsernameTxt
        c.client.Connect(serverIptxt.Text, serverPortnud.Value)
    End Sub
    Public Sub throwError(err As String)
        c.Hide()
        c.Visible = False
        c = New Client
        MsgBox(err)

    End Sub
    Private Sub ClientLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
    End Sub
End Class