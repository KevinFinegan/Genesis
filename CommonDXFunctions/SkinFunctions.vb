Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress
Imports DevExpress.LookAndFeel

Public Class SkinFunctions

    Public Shared Sub SetSkin(ctl As Control, skin As String)

        If skin = "" Then skin = "Lilian"

        UserLookAndFeel.Default.Style = LookAndFeelStyle.Skin
        UserLookAndFeel.Default.SkinName = skin

        If TypeOf ctl Is ISupportLookAndFeel Then
            CType(ctl, ISupportLookAndFeel).LookAndFeel.SkinName = skin
            CType(ctl, ISupportLookAndFeel).LookAndFeel.UseDefaultLookAndFeel = False
            CType(ctl, ISupportLookAndFeel).LookAndFeel.UseWindowsXPTheme = False
        End If

        For Each subCtl As Control In ctl.Controls
            'Recursively call this sub
            SetSkin(subCtl, skin)
        Next

    End Sub

    Public Shared Sub SetHeadingsToBold(ctl As Control)

        Select Case ctl.GetType.Name
            Case "XtraTabPage"
                CType(ctl, XtraTab.XtraTabPage).Appearance.Header.Font = New Font(ctl.Font, FontStyle.Bold)
            Case "GroupControl"
                CType(ctl, XtraEditors.GroupControl).AppearanceCaption.Font = New Font(ctl.Font, FontStyle.Bold)
                'Case "NavBarGroup"
                'CType(ctl, XtraNavBar.NavBarGroup).Appearance.GroupHeader.Font = New Font(ctl.Font, FontStyle.Bold)
        End Select

        For Each subCtl As Control In ctl.Controls
            SetHeadingsToBold(subCtl)
        Next

    End Sub


End Class
