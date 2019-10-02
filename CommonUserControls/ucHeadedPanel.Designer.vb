Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucHeadedPanel
    Inherits ucExtendedPanel

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.hlblHeader = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'hlblHeader
        '
        Me.hlblHeader.BackColor = System.Drawing.Color.Transparent
        Me.hlblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hlblHeader.Location = New System.Drawing.Point(0, 0)
        Me.hlblHeader.Name = "hlblHeader"
        Me.hlblHeader.Size = New System.Drawing.Size(100, 23)
        Me.hlblHeader.TabIndex = 0
        Me.hlblHeader.Text = "Header Text"
        '
        'ucHeadedPanel
        '
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents hlblHeader As Label
End Class
