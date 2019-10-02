Option Strict On
Option Explicit On

Imports System.Text
Imports System.Windows.Forms
Imports SF = CommonFunctions.StringFunctions

Public Class ValidationFunctions

    Public Shared Function RequiredFieldHasText(ctrl As Control, Optional ctrlName As Control = Nothing, Optional sb As StringBuilder = Nothing) As String
        Dim s As String

        If ctrl.Text <> "" Then
            Return ""
        Else
            If ctrlName IsNot Nothing Then
                s = ctrlName.Text
            Else
                s = ctrl.Name
                s = SF.TextAfterFirstCapitalOrNumber(s)
                s = SF.AddSpaceBetweenCapitals(s)
            End If
            
            s += " is a required field"

            'KF If the product was to be localised then the string would be held in the database (and cached on application start-up) or a resource file

            If sb IsNot Nothing Then sb.AppendLine(s)

            Return s
        End If


    End Function



End Class
