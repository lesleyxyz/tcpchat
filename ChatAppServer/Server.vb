Imports System.Net
Imports System.Threading

Public Class Server
    Private WithEvents Server As New ServerListener

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles stopBtn.Click
        Server.Disconnect()

    End Sub
    Sub Log(str As String)
        ListBox1.Items.Add(str)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles listenBtn.Click
        Server.MaxConnections = connectionNud.Value
        Server.KeepAlive = keepAliveCb.Checked
        Server.BufferSize = bufferSizeNud.Value
        Server.MaxPacketSize = packetSizeNud.Value
        Try
            Server.Listen(ipTxt.Text, serverPortnud.Value)
        Catch ex As Exception
            Log("Failed to bind to port " & serverPortnud.Value & ": " & ex.ToString)
        End Try
        Dim t As New Threading.Thread(Sub() fillLb())
        t.SetApartmentState(ApartmentState.STA)
        t.Start()
    End Sub
    Sub fillLb()
        For i = 1 To Server.MaxConnections
            userLb.Items.Add("")
            passLb.Items.Add("")
            showNameLb.Items.Add("")
            keyLb.Items.Add("")
        Next
    End Sub
#Region "Server Events"
    Private Sub Server_ClientExceptionThrown(sender As ServerListener, client As ServerClient, ex As Exception) Handles Server.ClientExceptionThrown
        Try
            Log("ServerClient exception: " & getAlias(client) & ": " & ex.ToString)
        Catch
            Log("ServerClient exception: " & client.EndPoint.Address.ToString & ": " & ex.ToString)
        End Try
    End Sub
    Private Sub Disconnect(client As ServerClient)
        Dim disc As New Threading.Thread(Sub() _Disconnect(client))
        disc.SetApartmentState(ApartmentState.STA)
        disc.Start()
    End Sub
    Private Sub _Disconnect(client As ServerClient)
        Threading.Thread.Sleep(2000)
        client.Disconnect()
    End Sub
    Private Sub Server_ClientReadPacket(sender As ServerListener, client As ServerClient, data() As Byte) Handles Server.ClientReadPacket

        Dim header As String = readHeader(byteToStr(data))
        Dim content As String = removeHeader(byteToStr(data))
        If Not header = "CONNECT" Then
            Log(getAlias(client) & ": " & byteToStr(data))
        End If
        Select Case header
            Case "BROADCAST"
                Try
                    Broadcast(strToByte("BROADCAST " & getAlias(client) & " " & content))
                Catch ex As Exception
                    Log(ex.ToString)
                    Log(ex.StackTrace)
                End Try
            Case "CHANGE"
                Try
                    Dim oldUser As String = getAlias(client)
                    Dim newUser As String = content
                    If lbContains(showNameLb, newUser) Then
                        client.Send(strToByte("NOTICE There is already someone with this shown name!"))
                        Exit Sub
                    End If
                    If lbContains(userLb, newUser) Then
                        client.Send(strToByte("NOTICE You can not use someone else's login name as your shownname!"))
                        Exit Sub
                    End If
                    If newUser = "" Or newUser = " " Or newUser.StartsWith("@") Or newUser.Contains(":") Or newUser.Contains(";") Then
                        client.Send(strToByte("NOTICE Your new username is not allowed."))
                        Exit Sub
                    End If
                    Dim uid As Integer = showNameLb.Items.IndexOf(oldUser)
                    If uid = -1 Then
                        client.Send(strToByte("NOTICE Your username is not present in our database"))
                        Exit Sub
                    End If
                    Broadcast(strToByte("CHANGENAME " & oldUser & " " & newUser))
                    showNameLb.Items.Item(uid) = newUser

                Catch ex As Exception
                    Log(ex.ToString)
                    Log(ex.StackTrace)
                End Try
            Case "TXT"
                Dim user As String = readHeader(content)
                Dim realContent As String = removeHeader(content)
                Dim uid As Integer = Nothing

                uid = showNameLb.Items.IndexOf(user)
                If uid = -1 Then
                    client.Send(strToByte("NOTICE User " & user & " does not exist."))
                    Exit Sub
                End If
                Dim ip() As String = keyLb.Items.Item(uid).ToString.Split(":")
                Server.Clients.Where(Function(x) x.EndPoint.Address.ToString = ip(0) And x.EndPoint.Port.ToString = ip(1)).First.Send(strToByte("REC " & getAlias(client) & " " & realContent))
            Case "CONNECT"
                Try
                    Dim creds() As String = content.Split(":")
                    Dim user As String = creds(0)
                    Dim showname As String = creds(1)
                    Dim pass As String = creds(2)

                    If Not creds.Length = 3 Then
                        client.Send(strToByte("MSGBOX [L2] Please don't use special characters in your name and check if you filled out all the fields."))
                        Disconnect(client)
                        Exit Sub
                    End If



                    If user = "" Or user = " " Or showname = "" Or showname = " " Or pass = "" Or pass = " " Or user.Contains(":") Or pass.Contains(":") Or showname.Contains(":") Or showname.StartsWith("@") Or showname.Contains(";") Or user.Contains(" ") Then
                        client.Send(strToByte("MSGBOX [L2] Please don't use special characters in your name and check if you filled out all the fields."))
                        Disconnect(client)
                        Exit Sub
                    End If
                    If Not showname = user Then

                    End If
                    If lbContains(userLb, user) Or user.ToLower = "server" Then 'If user is registered yet
                        Dim userid As Integer = userLb.Items.IndexOf(user) 'User registered with UID
                        If passLb.Items.Item(userid) = pass Then
                            Dim ip() As String = keyLb.Items.Item(userid).ToString.Split(":")
                            Try
                                Disconnect(Server.Clients.Where(Function(x) x.EndPoint.Address.ToString = ip(0) And x.EndPoint.Port.ToString = ip(1)).First)
                            Catch
                            End Try
                            client.Send(strToByte("NOTICE [L3] Logged in."))
                            showNameLb.Items.Item(userid) = showname
                            keyLb.Items.Item(userid) = client.EndPoint.Address.ToString & ":" & client.EndPoint.Port.ToString
                            Broadcast(strToByte("JOIN " & showname))
                        Else
                            client.Send(strToByte("MSGBOX [L4] Please re check your username and password."))
                            Disconnect(client)
                            Exit Sub
                        End If

                    Else
                        'register user
                        If lbContains(showNameLb, showname) Then
                            client.Send(strToByte("MSGBOX [R5] There is already someone with this shown name!"))
                            Disconnect(client)
                            Exit Sub
                        End If

                        If lbContains(userLb, showname) Then
                            If showname = user Then
                            Else
                                client.Send(strToByte("MSGBOX [L1] You can not use someone else's login name as your shownname!"))
                                Disconnect(client)
                                Exit Sub
                            End If

                        End If

                        Dim nextUID As Integer = userLb.Items.IndexOf("")

                            userLb.Items.Item(nextUID) = user
                            passLb.Items.Item(nextUID) = pass
                            showNameLb.Items.Item(nextUID) = showname
                            keyLb.Items.Item(nextUID) = client.EndPoint.Address.ToString & ":" & client.EndPoint.Port.ToString
                        client.Send(strToByte("NOTICE [R6] You are successfully registered with username " & user))
                        Broadcast(strToByte("JOIN " & showname))
                        End If
                Catch ex As Exception
                    client.Send(strToByte("MSGBOX [L2] Please don't use special characters in your name and check if you filled out all the fields."))
                    Disconnect(client)
                    Exit Sub
                End Try

        End Select
    End Sub

    Private Sub Server_ClientReadProgressChanged(sender As ServerListener, client As ServerClient, progress As Double, bytesRead As Integer, bytesToRead As Integer) Handles Server.ClientReadProgressChanged

    End Sub

    Private Sub Server_ClientStateChanged(sender As ServerListener, client As ServerClient, connected As Boolean) Handles Server.ClientStateChanged
        Log(client.EndPoint.Address.ToString & " connection state: " & connected)
        client.Send(strToByte("USERLIST " & getAllUsers()))
        If connected = False Then
            Try
                Broadcast(strToByte("LEAVE " & getAlias(client)))
            Catch ex As Exception
                Dim exs = ex.ToString
            End Try
        End If
    End Sub

    Private Sub Server_ClientWritePacket(sender As ServerListener, client As ServerClient, size As Integer) Handles Server.ClientWritePacket

    End Sub

    Private Sub Server_ClientWriteProgressChanged(sender As ServerListener, client As ServerClient, progress As Double, bytesWritten As Integer, bytesToWrite As Integer) Handles Server.ClientWriteProgressChanged

    End Sub

    Private Sub Server_ExceptionThrown(sender As ServerListener, ex As Exception) Handles Server.ExceptionThrown
        Log("Exception: " & ex.ToString)
    End Sub

    Private Sub Server_StateChanged(sender As ServerListener, listening As Boolean) Handles Server.StateChanged
        Log("Listening: " & listening)
    End Sub
#End Region
    Function getAllUsers() As String
        Dim str As String = "@All"
        For Each C As ServerClient In Server.Clients
            Try
                str = str & ";" & getAlias(C)
            Catch
            End Try
        Next
        Return str
    End Function

    Private Function getAlias(sClient As ServerClient)
        Dim ip As String = sClient.EndPoint.Address.ToString & ":" & sClient.EndPoint.Port.ToString
        Dim uid As String = keyLb.Items.IndexOf(ip)
        Return showNameLb.Items.Item(uid)
    End Function
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles getAllClients.Click
        Log(getAllUsers)
    End Sub

    Private Sub Server_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False 'TODO: Remove CheckForIllegalCrossThreadCalls = False and implement invokes
    End Sub

    Private Sub msgTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles msgTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            sendBtn_Click(msgTxt, New EventArgs)
            e.Handled = True
        End If
    End Sub
    Private Sub Broadcast(data As Byte())
        Log("Broadcasted " & byteToStr(data))
        For Each C As ServerClient In Server.Clients
            C.Send(data)
        Next
    End Sub
    Private Sub sendBtn_Click(sender As Object, e As EventArgs) Handles sendBtn.Click
        Dim txtContent As String = msgTxt.Text
        If rawMsgCb.Checked Then
            Broadcast(strToByte(txtContent))
        Else
            Broadcast(strToByte("BROADCAST " & txtContent))
        End If
    End Sub
    Private Function getIpAndPortFromClient(client As ServerClient)
        Dim ip As String = client.EndPoint.Address.ToString
        Dim port As String = client.EndPoint.Port.ToString
    End Function
    Function getIpFromAlias(_alias As String)
        Dim uid As Integer = userLb.Items.IndexOf(_alias)
        Return keyLb.Items.Item(uid)
    End Function
    Function getAliasFromIp(ipAndPort As String)
        Dim ip() As String = ipAndPort.Split(":")
        Return getAlias(Server.Clients.Where(Function(x) x.EndPoint.Address.ToString = ip(0) And x.EndPoint.Port.ToString = ip(1)).First)
    End Function
    Private Sub userLb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles userLb.SelectedIndexChanged
        passLb.SelectedIndex = userLb.SelectedIndex
        showNameLb.SelectedIndex = userLb.SelectedIndex
        keyLb.SelectedIndex = userLb.SelectedIndex
    End Sub
    Private Sub passLb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles passLb.SelectedIndexChanged
        userLb.SelectedIndex = passLb.SelectedIndex
        showNameLb.SelectedIndex = passLb.SelectedIndex
        keyLb.SelectedIndex = passLb.SelectedIndex
    End Sub
    Private Sub showNameLb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles showNameLb.SelectedIndexChanged
        passLb.SelectedIndex = showNameLb.SelectedIndex
        userLb.SelectedIndex = showNameLb.SelectedIndex
        keyLb.SelectedIndex = showNameLb.SelectedIndex
    End Sub
    Private Sub keyLb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles keyLb.SelectedIndexChanged
        passLb.SelectedIndex = keyLb.SelectedIndex
        userLb.SelectedIndex = keyLb.SelectedIndex
        showNameLb.SelectedIndex = keyLb.SelectedIndex
    End Sub
End Class