Imports ChatApp

Public Class Client
    Public WithEvents client As New UserClient
    Public serverIP As String = Nothing
    Public serverPort As UShort = Nothing
    Public username As String = Nothing
    Public password As String = Nothing
    Public loginHandle As ClientLogin
    Public engine As Tyrax_Program
    Private Sub client_ExceptionThrown(sender As UserClient, ex As Exception) Handles client.ExceptionThrown
        'Log("Exception: " & ex.ToString)
    End Sub

    Private Sub client_ReadPacket(sender As UserClient, data() As Byte) Handles client.ReadPacket
        Dim receivedStr As String = byteToStr(data)
        Dim header As String = readHeader(receivedStr)
        Dim content As String = removeHeader(receivedStr)
        If sender.EndPoint.Address.ToString = serverIP And sender.EndPoint.Port = serverPort Then
        Else
            Exit Sub
        End If

        Select Case header
            Case "JOIN"
                Try
                    clientLb.Items.Add(content)
                Catch
                End Try
            Case "CHANGENAME"
                Try
                    Dim oldUser As String = readHeader(content)
                    Dim newUser As String = removeHeader(content)
                    Dim uid As Integer = clientLb.Items.IndexOf(oldUser)
                    If uid = -1 Then
                        Exit Sub
                    End If
                    clientLb.Items.Item(uid) = newUser
                Catch
                End Try
            Case "LEAVE"
                Try
                    clientLb.Items.Remove(content)
                Catch
                End Try
            Case "USERLIST"
                Dim users() As String = content.Split(";")
                For Each user As String In users
                    If Not lbContains(clientLb, user) Then
                        clientLb.Items.Add(user)
                    End If
                Next
            Case "BROADCAST"
                Dim user As String = readHeader(content)
                Dim realContent As String = engine.EncryptionWrapper.DecryptData(removeHeader(content))
                Log(user & ": " & realContent)
            Case "MSGBOX"
                If content.StartsWith("[L1]") Or content.StartsWith("[L2]") Or content.StartsWith("[L4]") Or content.StartsWith("[R5]") Then

                    client.Disconnect()
                    loginHandle.throwError(content)
                    serverIP = Nothing
                    serverPort = Nothing
                    username = Nothing
                    password = Nothing

                    Exit Sub
                End If
                MsgBox(content)
            Case "NOTICE"
                If content.StartsWith("[L3]") Or content.StartsWith("[R6]") Then
                    Show()
                    loginHandle.Hide()
                End If

                Log("Server notice: " & content)
            Case "REC"
                Dim user As String = readHeader(content)
                Dim realContent As String = engine.EncryptionWrapper.DecryptData(removeHeader(content))
                Log("<" & user & "> -> Me : " & realContent)
            Case Else

        End Select
    End Sub

    Private Sub client_ReadProgressChanged(sender As UserClient, progress As Double, bytesRead As Integer, bytesToRead As Integer) Handles client.ReadProgressChanged

    End Sub
    Sub Log(str As String)
        msgHistoryTxt.AppendText(TimeOfDay.TimeOfDay.Hours & ":" & TimeOfDay.TimeOfDay.Minutes & ":" & TimeOfDay.TimeOfDay.Seconds & "  " & str & vbNewLine & vbNewLine)
    End Sub
    Private Sub client_StateChanged(sender As UserClient, connected As Boolean) Handles client.StateChanged
        Log("Connected: " & connected)
        If connected Then
            ClientLogin.usernameTxt.ReadOnly = True
            ClientLogin.passwordTxt.ReadOnly = True
            SendRaw(strToByte("CONNECT " & username & ":" & showNameTxt.Text & ":" & password))
            nameChangeBtn.Enabled = True
        Else
            clientLb.Items.Clear()
            ClientLogin.usernameTxt.ReadOnly = False
            nameChangeBtn.Enabled = False
            ClientLogin.passwordTxt.ReadOnly = False
            loginHandle.Show()
            Hide()
            Visible = False
        End If
    End Sub
    Sub SendRaw(bytes As Byte())
        client.Send(bytes)
    End Sub


    Private Sub msgTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles msgTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            sendBtn_Click(msgTxt, New EventArgs)
            e.Handled = True
        End If
    End Sub

    Private Sub sendBtn_Click(sender As Object, e As EventArgs) Handles sendBtn.Click

        Dim txtContent As String = msgTxt.Text
retryx:
        If txtContent.StartsWith(vbNewLine) Or txtContent.StartsWith(vbLf) Or txtContent.StartsWith(vbCr) Or txtContent.StartsWith(vbCrLf) Then
            txtContent = txtContent.Remove(0, 1)
            GoTo retryx
        End If

        If False Then
            Log("Me: " & txtContent)
            SendRaw(strToByte(txtContent))
        Else
            txtContent = engine.EncryptionWrapper.EncryptData(txtContent)
            If clientLb.SelectedItem = "@All" Then
                SendRaw(strToByte("BROADCAST " & txtContent))
                msgTxt.Text = Nothing
                Exit Sub
            End If

            If clientLb.SelectedIndex = -1 Then
                Log("NOTE: Please select a user at the right!")
                Exit Sub
            End If
            Log("Me -> <" & engine.EncryptionWrapper.DecryptData(clientLb.SelectedItem) & ">: " & txtContent)
            SendRaw(strToByte("TXT " & clientLb.SelectedItem.ToString & " " & txtContent))
            End If
            msgTxt.Text = Nothing
    End Sub

    Private Sub Client_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clientLb.Sorted = True
        Dim tempEngine As New Tyrax_Program("x")
        engine = New Tyrax_Program(tempEngine.MD5(tempEngine.ToBase64(serverIP & ":" & serverPort)))
        CheckForIllegalCrossThreadCalls = False 'TODO: Remove CheckForIllegalCrossThreadCalls = False and implement invokes
    End Sub

    Private Sub getUserList_Click(sender As Object, e As EventArgs)
        SendRaw(strToByte("GETUSERLIST"))
    End Sub

    Private Sub nameChangeBtn_Click(sender As Object, e As EventArgs) Handles nameChangeBtn.Click
        SendRaw(strToByte("CHANGE " & showNameTxt.Text))
    End Sub

    Private Sub fShown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Hide()
        Visible = False
    End Sub

End Class
