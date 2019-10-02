Option Strict On
Option Explicit On

Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports VB = Microsoft.VisualBasic

Public Class Events
    Public Enum EventLevel
        Information = 1
        Exception = 2
    End Enum

    Public Property EventLevelToLog As EventLevel

    Public Property ShowMessage As Boolean
    Public Property OutputToDatabase As Boolean
    Public Property OutputToLogFile As Boolean

    Public Sub LogEvent(message As String, level As EventLevel, Optional overrideDontShow As Boolean = False)
        If Me.EventLevelToLog <= level Then
            If Me.ShowMessage AndAlso Not overrideDontShow Then
                XtraMessageBox.Show(message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            If Me.OutputToDatabase Then
                'Save to the database
            End If

            If Me.OutputToLogFile Then
                'Save to a log file
            End If

        End If
    End Sub



End Class
