Option Strict On
Option Explicit On

Imports System.Text
Imports VB = Microsoft.VisualBasic

Public Class StringFunctions

    Public Shared Function CapitaliseFirstLetters(ByRef s As String, Optional ByVal sWordBreakCharacters As String = Nothing,
                                          Optional ByVal bNotFirstLetter As Boolean = False) As String
        Dim cLast As Char
        Dim i As Integer = 0
        Dim sb As New StringBuilder

        'If word break chars is empty then use the default
        If sWordBreakCharacters = Nothing Then sWordBreakCharacters = ".,;:""!'()[]{}@#?\/|`-_"

        'Loop through every character in the string
        For Each c As Char In s
            'If first character, or is after whitespace or is after wordbreak char or is already a capital letter (and not the 1st letter & NotFirstLetter is true)
            If (i = 0 AndAlso bNotFirstLetter = False) OrElse
               Char.IsWhiteSpace(cLast) OrElse
               sWordBreakCharacters.IndexOf(cLast) <> -1 OrElse
               (Char.IsUpper(c) And Not (i = 0 AndAlso bNotFirstLetter)) Then
                c = Char.ToUpper(c)
            Else
                c = Char.ToLower(c)
            End If

            sb.Append(c)
            cLast = c
            i += 1
        Next

        s = sb.ToString()
        Return sb.ToString()
    End Function

    Public Shared Function AddSpaceBetweenCapitals(ByRef s As String) As String
        Dim sb As New StringBuilder
        Dim i As Integer = 0

        'Loop through every character in the string
        For Each c As Char In s
            'If not first character, if is capital then insert a space
            If Not i = 0 AndAlso Char.IsUpper(c) Then
                'So long as the previous character was a lower-case letter and the next letter is not a capital
                If Char.IsLower(s(i - 1)) AndAlso
                   (s.Length > i + 1 AndAlso Not Char.IsUpper(s(i + 1))) Then
                    sb.Append(" ")
                End If
            End If

            sb.Append(c)
            i += 1
        Next

        s = sb.ToString()
        Return sb.ToString()
    End Function

    Public Shared Function TextAfterFirstCapitalOrNumber(ByVal s As String) As String
        Dim sReturn As String = ""
        Dim iPosition As Integer = IndexOfFirstCapitalOrNumber(s, False)

        If iPosition > 0 Then
            sReturn = VB.Right(s, s.Length - iPosition)
        Else
            sReturn = ""
        End If

        Return sReturn
    End Function

    Public Shared Function IndexOfFirstCapitalOrNumber(ByVal s As String, Optional ByVal bZeroIfNoCap As Boolean = True) As Integer
        Dim c As Char() = s.ToCharArray()
        Dim i As Integer = 0
        Dim bFound As Boolean = False

        While Not bFound AndAlso i < c.Length
            If Char.IsUpper(c(i)) OrElse Char.IsDigit(c(i)) Then bFound = True
            i += 1
        End While

        If Not bFound Then
            If bZeroIfNoCap Then
                i = 1
            Else
                i = i + 1
            End If
        End If

        Return i - 1
    End Function
End Class
