Imports System.Text
Module toolbox
    Public Function strToByte(s As String)
        Return Encoding.UTF8.GetBytes(s)
    End Function
    Public Function byteToStr(bytes As Byte())
        Return Encoding.UTF8.GetString(bytes)
    End Function
    Public Function readHeader(str As String) As String
        Dim header As String = Nothing
        For Each chr As Char In str.ToCharArray
            If chr = " " Then
                Exit For
            Else
                header = header & chr
            End If
        Next
        Return header
    End Function
    Public Function removeHeader(str As String) As String
        Dim header As String = readHeader(str)
        Try
            Return str.Remove(0, header.Length + 1)
        Catch
            Return Nothing
        End Try
    End Function
    Function lbContains(lb As ListBox, str As String) As Boolean
        Try
            If lb.Items.IndexOf(str) >= 0 Then
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function
End Module
