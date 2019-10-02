Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Windows.Forms
Imports SF = CommonFunctions.StringFunctions

Public Class ucHeadedPanel
    Inherits ucExtendedPanel

    Private _iActiveBanner As Integer

#Region "Gets & Sets"

#Region "Header Label"
    Public Property HeaderText As String
        Get
            Return hlblHeader.Text
        End Get
        Set(value As String)
            hlblHeader.Text = value
        End Set
    End Property

    Public Property HeaderBackColor As Color
        Get
            Return hlblHeader.BackColor
        End Get
        Set(value As Color)
            hlblHeader.BackColor = value
        End Set
    End Property
#End Region

#End Region


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        hlblHeader.Width = Me.Width - 17
        hlblHeader.Top = 0
        hlblHeader.Left = 0
        hlblHeader.Font = New Font(Me.Font, FontStyle.Bold)


        Me.Controls.Add(hlblHeader)

        Me.Images = Enums.ImageSet.TripleArrow
        Me.InitialState = Enums.State.Expanded
        Me.ReductionDirection = Enums.Direction.UpDown

        Me.hlblHeader.BringToFront()
    End Sub

    Private Sub ucExtendedPanel_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        hlblHeader.Width = Me.Width - 17
        hlblHeader.Height = 17
        hlblHeader.Top = 0
        hlblHeader.Left = 0
    End Sub

    Private dctLabels As Dictionary(Of Integer, Label)

    Public Sub AddBanner(sText As String)
        Me.SuspendLayout()

        Dim lblNew As New Label

        If dctLabels Is Nothing Then dctLabels = New Dictionary(Of Integer, Label)

        Dim iIndex As Integer = dctLabels.Count + 1
        Dim iGutter As Integer = 3
        Dim iPadding As Integer = 1
        Dim iHeight As Integer = 13

        lblNew.Name = "lbl" + CStr(iIndex)
        lblNew.Left = 5
        lblNew.Top = iHeight + iGutter + (iIndex * (iHeight + iPadding))
        lblNew.AutoSize = False
        lblNew.Width = hlblHeader.Width
        lblNew.Height = 13
        lblNew.Text = sText
        lblNew.TabIndex = Me.TabIndex + iIndex
        lblNew.Font = Me.Font

        'RemoveHandler lblNew.Click,
        AddHandler lblNew.Click, AddressOf BannerClicked
        AddHandler lblNew.MouseHover, AddressOf BannerHover
        AddHandler lblNew.MouseLeave, AddressOf BannerLeave

        dctLabels.Add(iIndex, lblNew)
        Me.Controls.Add(lblNew)

        Application.DoEvents()
    End Sub

    Public Sub ResetAllBanners()
        For Each lbl As Label In dctLabels.Values
            lbl.ForeColor = Color.Black
            lbl.Font = New Font(lbl.Font, FontStyle.Regular)
        Next

        _iActiveBanner = -1
    End Sub


    Public Delegate Sub delBannerClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event evBannerClicked As delBannerClicked

    Public Sub BannerClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent evBannerClicked(sender, e)

        For Each lbl As Label In dctLabels.Values
            lbl.ForeColor = Color.Black
            lbl.Font = New Font(lbl.Font, FontStyle.Regular)
        Next

        _iActiveBanner = CInt(SF.TextAfterFirstCapitalOrNumber(CType(sender, Label).Name))

        CType(sender, Label).ForeColor = Color.WhiteSmoke
        CType(sender, Label).Font = New Font(CType(sender, Label).Font, FontStyle.Bold)
    End Sub

    Public Sub BannerHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '_iActiveBanner = CInt(SF.TextAfterFirstCapitalOrNumber(CType(sender, Label).Name))

        For Each lbl As Label In dctLabels.Values
            lbl.ForeColor = Color.Black
            lbl.Font = New Font(lbl.Font, FontStyle.Regular)
        Next

        CType(sender, Label).ForeColor = Color.WhiteSmoke
        CType(sender, Label).Font = New Font(CType(sender, Label).Font, FontStyle.Bold)

    End Sub

    Public Sub BannerLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If _iActiveBanner <> CInt(SF.TextAfterFirstCapitalOrNumber(CType(sender, Label).Name)) Then
            CType(sender, Label).ForeColor = Color.Black
            CType(sender, Label).Font = New Font(CType(sender, Label).Font, FontStyle.Regular)
        End If
    End Sub

    Public Sub BannerLeaveAll()
        For Each lbl As Label In dctLabels.Values
            lbl.ForeColor = Color.Black
            lbl.Font = New Font(lbl.Font, FontStyle.Regular)
        Next
    End Sub

    Private dctButtons As Dictionary(Of Integer, Button)

    Public Sub AddButton(sText As String)
        Me.SuspendLayout()

        Dim btnNew As New Button

        If dctButtons Is Nothing Then dctButtons = New Dictionary(Of Integer, Button)

        Dim iIndex As Integer = dctButtons.Count + 1
        Dim iGutter As Integer = 3
        Dim iPadding As Integer = 1
        Dim iHeight As Integer = 22

        btnNew.Name = "btnh" + CStr(iIndex)
        btnNew.Left = 5
        btnNew.Top = iGutter + (iIndex * (iHeight + iPadding))
        btnNew.Width = hlblHeader.Width
        btnNew.Height = iHeight
        btnNew.Text = sText
        btnNew.TabIndex = Me.TabIndex + iIndex
        btnNew.Font = New Font(Me.Font.FontFamily, 8)

        'btnNew.BackColor = Color.Yellow
        'btnNew.FlatStyle = FlatStyle.System
        'btnNew.FlatAppearance = FlatButtonAppearanc

        'RemoveHandler lblNew.Click,
        'AddHandler lblNew.Click, AddressOf BannerClicked
        'AddHandler lblNew.MouseHover, AddressOf BannerHover
        'AddHandler lblNew.MouseLeave, AddressOf BannerLeave

        dctButtons.Add(iIndex, btnNew)
        Me.Controls.Add(btnNew)

        Application.DoEvents()
    End Sub



End Class


