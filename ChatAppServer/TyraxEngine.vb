Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Security.Cryptography
Imports System.Environment

''' ***********************************************************
''' Copyright 2013-2016  TyraxoSoft. All rights reserved.
''' ***********************************************************
''' <summary>
'''  Tyrax_Program (AKA TyraxEngine) is the Engine used in tyraxosoft applications.
'''  This class makes it easier and secure to create these applications and should be easy to use.
''' </summary>
''' <remarks><para><pre>
''' RevisionHistory:
''' -----------------------------------------------------------
''' Date        Name              Description
''' -----------------------------------------------------------
''' 01/01/2016  Lesley  Initial Request and Creation
''' 22/01/2016  Lesley  Huge update on Tyrax_User able to GetInfo()
''' 22/01/2016  Lesley  Added all comments necessary till FromBase64
''' 03/02/2016  Lesley  Added all other comments, UserInfo now accepts a Type to be returned as.
''' 03/02/2016  Lesley  Autologin and Encryption working.
''' 03/02/2016  Lesley  (Of T) removed bij GetInfo
''' </pre></para>
''' </remarks>
''' -----------------------------------------------------------
Public Class Tyrax_Program

    Public ReadOnly MainUrl As String = "https://tyraxosoft.be/"
    Public Session As New AuthKey
    Protected ReadOnly ProgramName As String = Nothing
    Private _User As String = Nothing
    Public LoggedinUser As TyraxUser
    Private _RootFolderPath As String
    Private ReadOnly EncKey As String
    Public EncryptionWrapper As Simple3Des
    Public JSSerializer As New System.Web.Script.Serialization.JavaScriptSerializer

    ''' <summary>
    '''  Returns the Username
    ''' </summary>
    Public Property Username() As String
        Get
            Return _User
        End Get
        Protected Set(ByVal value As String)
            _User = value
        End Set
    End Property

    ''' <summary>
    '''  Converts a json callback into a dictionary array
    ''' </summary>
    ''' <param name="input">
    '''       The JSON Input.
    '''       Value Type: <see cref="String" />   (System.String)
    ''' </param>
    ''' <exception cref="System.ArgumentException">
    '''       Thrown when invalid json is given
    ''' </exception>
    ''' <returns><see cref="Dictionary(Of String, Object)" />(System.Collections.Generic.Dictionary)</returns>

    Function json_decode(input As String) As Dictionary(Of String, Object)
        Return JSSerializer.DeserializeObject(input)
    End Function
    ''' <summary>
    '''  Converts an array to a json array
    ''' </summary>
    ''' <param name="input">
    '''       The Array Input.
    '''       Value Type: <see cref="Array" />   (System.Array)
    ''' </param>
    Function json_encode(input As Array)
        Return JSSerializer.Serialize(input)
    End Function

    ''' <summary>
    '''  Returns the escaped/safe string
    ''' </summary>
    ''' <param name="input">
    '''       The input to be escaped
    '''       Value Type: <see cref="String" />   (System.String)
    ''' </param>
    Function EscapeJson(input As String)
        Return input.Replace("""", "\""").Replace("\", "\\").Replace("/", "\/").Replace(vbLf, "\n")
    End Function

    ''' <summary>
    '''  Uploads a string and returns the server returned content.
    ''' </summary>
    ''' <param name="api">
    '''       The location of the API/URL
    '''       Value Type: <see cref="String" />   (System.String)
    ''' </param>
    ''' <param name="content">
    '''       Content that needs to be written in the POST section.
    '''       Value Type: <see cref="String" />   (System.String)
    ''' </param>
    ''' <returns><see cref="String" />(System.String)</returns>
    Function POST(api As String, Optional content As String = "") As String
        Try

            If (Session.Success = True) Then
                content = content & "&authkey=" & Session.AuthKeyString
            End If
            content = content & "&userhwid=" & HWIDGen() & "&program=" & ProgramName

            Dim request As HttpWebRequest = HttpWebRequest.Create(api)
            request.Method = "POST"
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(content)
            request.Proxy = Nothing
            request.UserAgent = "Tyrax-" & ProgramName & "-" & _User
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As HttpWebResponse = request.GetResponse
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            reader.Close()
            dataStream.Close()
            response.Close()


            Dim result As String = responseFromServer
            Return result

        Catch ex As WebException
            Return ex.Message
        End Try

    End Function

    ''' <summary>
    '''  Returns the HWID (Username + MachineName + WindowsUsername)
    ''' </summary>
    ''' <returns><see cref="String" />(System.String)</returns>
    Public Function HWIDGen()
        Return _User & "/" & Environment.MachineName & "/" & Environment.UserName
    End Function

    Private Sub CheckFileExistance()
        If Not IO.Directory.Exists(GetFolderPath(SpecialFolder.ApplicationData) & "\TyraxoSoft") Then
            IO.Directory.CreateDirectory(GetFolderPath(SpecialFolder.ApplicationData) & "\TyraxoSoft")
        End If

        Try
            If Not IO.Directory.Exists(GetFolderPath(SpecialFolder.ApplicationData) & "\TyraxoSoft\" & ProgramName) Then
                IO.Directory.CreateDirectory(GetFolderPath(SpecialFolder.ApplicationData) & "\TyraxoSoft\" & ProgramName)
            End If
        Catch
            Throw New Exception("Program name Is Not valid. It may Not contain invalid characters.")
        End Try


        Dim FilesToBeCreated() As String = {"User.te", "Keys.te", "Settings.te"}
        For Each file As String In FilesToBeCreated
            If IO.File.Exists(_RootFolderPath & file) Then
            Else
                IO.File.Create(_RootFolderPath & file).Dispose()
            End If
        Next
    End Sub

    ''' <summary>
    '''  Returns the HWID (Username + MachineName + WindowsUsername)
    ''' </summary>
    ''' <param name="NewProgramName">
    '''       Current program name, usually the marketed name.
    '''       Only registered TyraxoSoft products are allowed.
    '''       Value Type: <see cref="String" />   (System.String)
    ''' </param>    
    Public Sub New(NewProgramName As String)
        ProgramName = NewProgramName.ToLower.Replace(".", "")
        _RootFolderPath = GetFolderPath(SpecialFolder.ApplicationData) & "/TyraxoSoft/" & ProgramName & "/"
        CheckFileExistance()
        EncKey = "TYR" & Environment.MachineName & "/" & Environment.UserName & "7785b81139d9d2ac36d719cd4eec824bbaf808008106e6fbe6132f4518f76458b2a81181f032b413745d16dbaf7850f64386a5d12da4fed8d05341be9c93914842ee70db556b6bbc63d5063aeacb96475ca2164ce0cc5c715dce12c4d666071648b5523360ed0608971482bb2fb3120babfad3d50e84f1345f156491863d5316c5fe28d56d1051ea9bb71793c1d766748482b0ccc8e6eacc3b52e5713a79e923edddfb9d27ce58a957df639c138ed1a55bd2dce9ecd54ff4de0151d491235073"
        EncKey = If(EncKey.Length <= 24, EncKey, EncKey.Substring(0, 24))
        EncryptionWrapper = New Simple3Des(EncKey)

    End Sub
    ''' <summary>
    '''  Logs out the current user
    '''  (Would recommend creating a New Tyrax_Program instead)
    ''' </summary>
    Public Sub Logout()
        Session = Nothing
        Session = New AuthKey
        _User = Nothing
        LoggedinUser = Nothing
    End Sub
    ''' <summary>
    '''  Tries to login if user 'RememberMe'd
    '''  If success, return true, if fail return false (then user normal Login)
    ''' </summary>
    Function TryAutoLogin()
        Try
            CheckFileExistance()
            Dim DecContStr As String = EncryptionWrapper.DecryptData(IO.File.ReadAllText(_RootFolderPath & "User.te"))
            Dim JsonDec = json_decode(DecContStr)

            Return Login(JsonDec("username"), JsonDec("password"), JsonDec("remember"))
        Catch ex As Exception

            Return False
        End Try
    End Function



    ''' <summary>
    '''  Returns If the login was successfull
    ''' </summary>
    ''' <param name="username">
    '''       The on TyraxoSoft registered username, usualy the input of a textbox.
    '''       Value Type: <see cref="String" />   (System.String)
    ''' </param>    
    '''   <param name="password">
    '''       The raw, non hashed, non encrypted password of the client, usually the input of a textbox.
    '''       Value Type: <see cref="String" />   (System.String)
    ''' </param>    
    ''' <param name="RememberMe">
    '''       Either if it needs to remember the account to afterwards <see cref="TryAutoLogin()" />
    '''       Value Type: <see cref="Boolean" />   (System.Boolean)
    ''' </param>    
    ''' <returns><see cref="Boolean" />(System.Boolean)</returns>
    Public Function Login(username As String, password As String, Optional RememberMe As Boolean = False)
        If Session.Success = True Then
            Throw New Exception("User already logged in, use Logout first. If you use TryAutoLogin, you didn't check that it succeeded or not (it returns true if so).")
        End If
        Session = Nothing
        Session = New AuthKey
        _User = username
        Dim ReturnResult As String = POST(MainUrl & "/apis/main/login.php", "username=" & username & "&password=" & password & "&getkey=015721d76821597decf28bd5f077ff25").Replace(vbLf, "")
        Dim Meaning As String = ""
        Dim RaiseError As Boolean = False
        If ReturnResult = "403" Then
            Meaning = "Invalid username/password."
            RaiseError = True
        ElseIf ReturnResult = "403.2" Then
            Meaning = "Problem occured at the authentication server."
            RaiseError = True
        ElseIf ReturnResult = "403.4" Then
            Meaning = "Your account has been banned."
            RaiseError = True
        ElseIf ReturnResult = "403.5" Then
            Meaning = "You aren't authorized to use this program."
            RaiseError = True
        ElseIf ReturnResult.Length = 32 Then
            Session.AuthKeyString = ReturnResult
            LoggedinUser = New TyraxUser(_User, Me)

            If RememberMe = True Then

            Else

            End If

        ElseIf ReturnResult = "err" Or ReturnResult.StartsWith("403.") Then
            Meaning = "Something is preventing us from communicating to the authentication server."
            RaiseError = True
        Else
            Throw New System.Exception("An exception has occured at Tyrax_Login.Login() with ReturnResult: " & ReturnResult)
        End If


        If RaiseError = True Then
            _User = Nothing
            Session.ErrorRaised = Meaning
            Return False
            Exit Function
        End If

        CheckFileExistance()
        Try
            Dim JsonStr As String = "{username: """ & EscapeJson(username) & """, password: """ & EscapeJson(password) & """, remember: """ & RememberMe & """}"
            IO.File.WriteAllText(_RootFolderPath & "User.te", EncryptionWrapper.EncryptData(JsonStr))


        Catch ex As Exception

        End Try

        Return True
    End Function
#Region "Common functions"
    ''' <summary>
    '''  Returns the MD5 hash of a given string
    ''' </summary>
    ''' <param name="str">
    '''       The string that needs to be hashed.
    '''       Value Type: <see cref="String" />   (System.String)
    ''' </param>    
    Function MD5(str As String) As String
        Dim dBytes As Byte() = MD5CryptoServiceProvider.Create().ComputeHash(Encoding.UTF8.GetBytes(str))
        Dim sBuilder As New StringBuilder
        For i = 0 To dBytes.Length - 1
            sBuilder.Append(dBytes(i).ToString("X2"))
        Next
        Return sBuilder.ToString
    End Function

    ''' <summary>
    '''  Returns the Base64() of a given string
    '''  (Invert this with <see cref="FromBase64(String)" />)
    ''' </summary>
    ''' <param name="str">
    '''       The string that needs to be converted to base64.
    '''       Value Type: <see cref="String" />   (System.String)
    ''' </param>    
    ''' <seealso cref="FromBase64(String)"/>
    Function ToBase64(str As String) As String
        Dim dBytes() As Byte = Encoding.UTF8.GetBytes(str)
        Return Convert.ToBase64String(dBytes)
    End Function

    ''' <summary>
    '''  Returns the string of a given Base64 string
    '''  (Invert this with <see cref="ToBase64(String)" />)
    ''' </summary>
    ''' <param name="str">
    '''       The string that needs to be converted to a string.
    '''       Value Type: <see cref="String" />   (System.String)
    ''' </param>    
    ''' <seealso cref="FromBase64(String)"/>
    Function FromBase64(str As String) As String
        Dim dBytes() As Byte = Convert.FromBase64String(str)
        Return Encoding.UTF8.GetString(dBytes)
    End Function
#End Region
End Class
Public Class AuthKey
    Dim _AuthKeyString As String = "{UNSET}"
    Dim _ErrorRaised As Boolean
    Dim _ErrorDetails As String

    Public Overrides Function ToString() As String
        Return _AuthKeyString.ToString
    End Function

    Public Property AuthKeyString As String
        Get
            Return _AuthKeyString
        End Get
        Set(value As String)
            _AuthKeyString = value
        End Set
    End Property

    Public Property ErrorRaised As String
        Get
            Return _ErrorRaised
        End Get
        Set(value As String)
            _ErrorDetails = value
            _ErrorRaised = True
        End Set
    End Property

    Public ReadOnly Property ErrorDetails
        Get
            Return _ErrorDetails
        End Get
    End Property
    Public ReadOnly Property Success As Boolean
        Get
            If ErrorRaised = False And _AuthKeyString.Length = 32 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property
End Class
Public Class TyraxUser
    Private UserInfo As Generic.Dictionary(Of String, Object)
    Private Program As Tyrax_Program
    Private Givenuser As String = "{UNSET}"
    Enum InfoType
        username = 0
        email = 1
        premium = 2
        banned = 3
        rank = 4
        country = 5
        countrycode = 6
        firstname = 7
        lastname = 8
        functie = 9
        birthday = 10
        mobile = 11
        bio = 12
        mood = 13
        website = 14
        twitter = 15
        facebook = 16
        skype = 17
    End Enum
    Public Overrides Function ToString() As String
        Return Givenuser.ToString
    End Function

    ''' <summary>
    '''  Creates a new TyraxUser
    ''' </summary>
    ''' <param name="User">
    '''       The user that needs to be queried
    '''       Value Type: <see cref="String" />   (System.String)
    ''' </param>    
    ''' <param name="From">
    '''       The program for future references and checks.
    '''       Value Type: <see cref="Tyrax_Program" />   (Tyrax_Program)
    ''' </param>    
    Sub New(User As String, From As Tyrax_Program)
        Givenuser = User
        Program = From
        UpdateInfo()
    End Sub
    ''' <summary>
    '''  Updates the info about the user.
    ''' </summary>
    Sub UpdateInfo()
        If Givenuser = Program.Username Then
            Dim JSUserCont As String = Program.POST(Program.MainUrl & "apis/main/getUserInfo.php")
            Dim UserInfoDL As Generic.Dictionary(Of String, Object) = Program.json_decode(JSUserCont)
            UserInfo = UserInfoDL
        Else
            Throw New NotImplementedException("No third person info requests can get called. Not implemented yet.")
        End If

    End Sub
    ''' <summary>
    '''  Creates a new TyraxUser
    ''' </summary>
    ''' <param name="type">
    '''       The type of info required.
    '''       Value Type: <see cref="InfoType" />   (Enum InfoType)
    ''' </param>    
    Function GetInfo(type As InfoType)
        Return UserInfo(type.ToString)
    End Function
End Class


Public NotInheritable Class Simple3Des
    Private TripleDes As New TripleDESCryptoServiceProvider
    Private Function TruncateHash(
    ByVal key As String,
    ByVal length As Integer) As Byte()

        Dim sha1 As New SHA1CryptoServiceProvider

        ' Hash the key.
        Dim keyBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash.
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    Sub New(ByVal key As String)
        ' Initialize the crypto provider.
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub

    Public Function EncryptData(
    ByVal plaintext As String) As String

        ' Convert the plaintext string to a byte array.
        Dim plaintextBytes() As Byte =
            System.Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the encoder to write to the stream.
        Dim encStream As New CryptoStream(ms,
            TripleDes.CreateEncryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string.
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    Public Function DecryptData(
    ByVal encryptedtext As String) As String

        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream.
        Dim decStream As New CryptoStream(ms,
            TripleDes.CreateDecryptor(),
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string.
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function
End Class