Option Explicit On
Option Strict On

Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Public Class ucExtendedPanel
    Private _iOriginalWidth As Integer
    Private _iOriginalHeight As Integer
    Private _iReducedWidth As Integer
    Private _iReducedHeight As Integer
    Private _eDirection As Direction
    Private _eImageSet As ImageSet
    Private _eInitialState As State
    Private _eCurrentState As State
    Private _bInSetup As Boolean
    Private WithEvents _ctrlSplitter As SplitterControl

#Region "Gets & Sets"
    Public Property ReducedWidth As Integer
        Get
            Return _iReducedWidth
        End Get
        Set(value As Integer)
            _iReducedWidth = value
            Setup()
        End Set
    End Property

    Public Property ReducedHeight As Integer
        Get
            Return _iReducedHeight
        End Get
        Set(value As Integer)
            _iReducedHeight = value
            Setup()
        End Set
    End Property

    Public Property ReductionDirection As Enums.Direction
        Get
            Return _eDirection
        End Get
        Set(value As Direction)
            _eDirection = value
            Setup()
        End Set
    End Property

    Public Property Images As ImageSet
        Get
            Return _eImageSet
        End Get
        Set(value As ImageSet)
            _eImageSet = value
            Setup()
        End Set
    End Property

    Public Property InitialState As State
        Get
            Return _eInitialState
        End Get
        Set(value As State)
            _eInitialState = value
            Setup()
        End Set
    End Property

    Public Property BuddySplitter As SplitterControl
        Get
            Return _ctrlSplitter
        End Get
        Set(value As SplitterControl)
            _ctrlSplitter = value
        End Set
    End Property
#End Region



    Public Sub New()
        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'Add Defaults
        _iReducedWidth = 40
        _iReducedHeight = 40
        _eDirection = Direction.LeftRight
        _eImageSet = ImageSet.PlusMinus
        _eInitialState = State.Expanded

        pbIcon.Parent = Me
        pbIcon.Visible = True
        pbIcon.Width = 17
        pbIcon.Height = 17

        'pbIcon.Anchor = AnchorStyles.Right And AnchorStyles.Top

        Setup()
    End Sub

    Public Sub Setup()
        _bInSetup = True

        _eCurrentState = _eInitialState

        If _eInitialState = State.Reduced Then
            SetSize()
        End If

        SetImage()

        _bInSetup = False
    End Sub

    Private Sub pbIcon_Click(sender As Object, e As EventArgs) Handles pbIcon.Click
        SetSize()
        SetImage()
    End Sub

    Private Sub SetImage()
        Dim sImageName As String = ""

        Select Case _eImageSet * _eCurrentState * _eDirection
            Case ImageSet.SingleArrow * State.Expanded * Direction.LeftRight
                sImageName = "reduce_left"
            Case ImageSet.DoubleArrow * State.Expanded * Direction.LeftRight
                sImageName = "reduce_left_double_arrow"
            Case ImageSet.TripleArrow * State.Expanded * Direction.LeftRight
                sImageName = "reduce_left_triple_arrow"
            Case ImageSet.SingleArrow * State.Reduced * Direction.LeftRight
                sImageName = "expand_right"
            Case ImageSet.DoubleArrow * State.Reduced * Direction.LeftRight
                sImageName = "expand_right_double_arrow"
            Case ImageSet.TripleArrow * State.Reduced * Direction.LeftRight
                sImageName = "expand_right_triple_arrow"

            Case ImageSet.SingleArrow * State.Expanded * Direction.UpDown
                sImageName = "reduce_up"
            Case ImageSet.DoubleArrow * State.Expanded * Direction.UpDown
                sImageName = "reduce_up_double_arrow"
            Case ImageSet.TripleArrow * State.Expanded * Direction.UpDown
                sImageName = "reduce_up_triple_arrow"
            Case ImageSet.SingleArrow * State.Reduced * Direction.UpDown
                sImageName = "expand_down"
            Case ImageSet.DoubleArrow * State.Reduced * Direction.UpDown
                sImageName = "expand_down_double_arrow"
            Case ImageSet.TripleArrow * State.Reduced * Direction.UpDown
                sImageName = "expand_down_triple_arrow"

            Case ImageSet.PlusMinus * State.Reduced * Direction.UpDown
            Case ImageSet.PlusMinus * State.Reduced * Direction.LeftRight
                sImageName = "plus"
            Case ImageSet.PlusMinus * State.Expanded * Direction.UpDown
            Case ImageSet.PlusMinus * State.Expanded * Direction.LeftRight
                sImageName = "minus"

        End Select

        pbIcon.Image = CType(My.Resources.ResourceManager.GetObject(sImageName), Image)
        pbIcon.Location = New System.Drawing.Point(Me.Width - 17, 0)
        pbIcon.BringToFront()
    End Sub

    Private Sub SetSize()
        Dim iGutter As Integer = 0
        Dim ctlToChange As Control = Nothing

        'If Me.Parent IsNot Nothing AndAlso
        If (Me.Dock = DockStyle.Fill OrElse Me.Dock = DockStyle.Top OrElse Me.Dock = DockStyle.Bottom) Then
            iGutter = 1
            ctlToChange = _ctrlSplitter

            If ctlToChange IsNot Nothing Then
                If _eCurrentState = State.Reduced AndAlso _eDirection = Direction.LeftRight Then
                    ctlToChange.Left = _iOriginalWidth - iGutter
                    _eCurrentState = State.Expanded
                ElseIf _eCurrentState = State.Expanded AndAlso _eDirection = Direction.LeftRight Then
                    _iOriginalWidth = Me.Width
                    ctlToChange.Left = _iReducedWidth - iGutter
                    _eCurrentState = State.Reduced
                ElseIf _eCurrentState = State.Reduced AndAlso _eDirection = Direction.UpDown Then
                    'ctlToChange.Top = _iOriginalHeight - iGutter
                    CType(ctlToChange, Splitter).SplitPosition = _iOriginalHeight - iGutter
                    _eCurrentState = State.Expanded
                ElseIf _eCurrentState = State.Expanded AndAlso _eDirection = Direction.UpDown Then
                    _iOriginalHeight = Me.Height
                    'ctlToChange.Top = _iReducedHeight - iGutter
                    CType(ctlToChange, Splitter).SplitPosition = _iReducedHeight - iGutter
                    _eCurrentState = State.Reduced
                End If
            Else
                If (_eCurrentState = State.Reduced AndAlso _eDirection = Direction.LeftRight) OrElse
                   (_eCurrentState = State.Reduced AndAlso _eDirection = Direction.UpDown) Then
                    _eCurrentState = State.Expanded
                Else
                    _eCurrentState = State.Reduced
                End If
            End If

        Else
            ctlToChange = Me

            If _eCurrentState = State.Reduced AndAlso _eDirection = Direction.LeftRight Then
                ctlToChange.Width = _iOriginalWidth - iGutter
                _eCurrentState = State.Expanded
            ElseIf _eCurrentState = State.Expanded AndAlso _eDirection = Direction.LeftRight Then
                _iOriginalWidth = ctlToChange.Width
                ctlToChange.Width = _iReducedWidth - iGutter
                _eCurrentState = State.Reduced
            ElseIf _eCurrentState = State.Reduced AndAlso _eDirection = Direction.UpDown Then
                ctlToChange.Height = _iOriginalHeight - iGutter
                _eCurrentState = State.Expanded
            ElseIf _eCurrentState = State.Expanded AndAlso _eDirection = Direction.UpDown Then
                _iOriginalHeight = ctlToChange.Height
                ctlToChange.Height = _iReducedHeight - iGutter
                _eCurrentState = State.Reduced
            End If
        End If

        pbIcon.Location = New System.Drawing.Point(ctlToChange.Width - 17, 0)
        pbIcon.BringToFront()
    End Sub

    Private Sub ucExtendedPanel_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'pbIcon.Location = New System.Drawing.Point(Me.Width - 17, 0)
        pbIcon.Top = 0
        pbIcon.Left = Me.Width - 17
    End Sub

    Friend Sub ManualPosition(iPosition As Integer)
        pbIcon.Top = 0
        pbIcon.Left = iPosition
    End Sub
End Class
