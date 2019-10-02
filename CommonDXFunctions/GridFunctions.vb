Option Strict On
Option Explicit On

Imports SF = CommonFunctions.StringFunctions
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports System.Globalization
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Controls

Public Class GridFunctions

    Private Shared Function CreateCaption(sFieldName As String, Optional sOverrideCaption As String = "") As String
        Dim sCaption As String = sFieldName
        If sOverrideCaption.Length = 0 Then
            sCaption = sCaption.Replace("_", " ")
            sCaption = SF.CapitaliseFirstLetters(sCaption)
            sCaption = SF.AddSpaceBetweenCapitals(sCaption)
        Else
            sCaption = sOverrideCaption
        End If

        Return sCaption
    End Function

    Public Shared Function CreateGridColumn(sColumnName As String,
                                      sFieldName As String,
                                      Optional bVisible As Boolean = True,
                                      Optional iWidth As Integer? = Nothing,
                                      Optional sOverrideCaption As String = "",
                                      Optional eFormatType As FormatType = FormatType.None,
                                      Optional sFormatString As String = "") As Columns.GridColumn

        Dim col As Columns.GridColumn = New Columns.GridColumn()

        Dim sCaption As String = CreateCaption(sFieldName, sOverrideCaption)

        col.Caption = sCaption
        col.CustomizationCaption = sCaption
        col.FieldName = sFieldName
        col.Name = "col" + sFieldName

        col.OptionsColumn.AllowEdit = False
        col.OptionsColumn.ReadOnly = True
        col.Visible = bVisible

        If sFormatString.Length > 0 Then
            If sFormatString = "LocalMoney" Then
                'Not sure if the grid automatically picks up the local culture or not
                col.DisplayFormat.FormatType = eFormatType
                col.DisplayFormat.Format = CultureInfo.CurrentCulture
                col.DisplayFormat.FormatString = "c2"
            ElseIf sFormatString = "DollarMoney" Then
                col.DisplayFormat.FormatType = eFormatType
                col.DisplayFormat.Format = CultureInfo.GetCultureInfo("en-US")
                col.DisplayFormat.FormatString = "c2"
            Else
                col.DisplayFormat.FormatType = eFormatType
                col.DisplayFormat.FormatString = sFormatString
            End If
        End If

        If iWidth IsNot Nothing Then col.Width = CInt(iWidth)

        Return col
    End Function

    Public Shared Function CreatePictureEditColumn(pictureEdit As RepositoryItemPictureEdit,
                                               sColumnName As String,
                                               sFieldName As String,
                                               Optional bVisible As Boolean = True,
                                               Optional iWidth As Integer? = Nothing,
                                               Optional sOverrideCaption As String = "") As Columns.GridColumn

        pictureEdit.SizeMode = PictureSizeMode.Zoom
        pictureEdit.NullText = " "
        'pictureEdit.P

        Dim col As Columns.GridColumn = New Columns.GridColumn()
        Dim sCaption As String = CreateCaption(sFieldName, sOverrideCaption)

        col.Caption = sCaption
        col.CustomizationCaption = sCaption
        col.FieldName = sFieldName
        col.Name = sColumnName
        col.OptionsColumn.AllowEdit = False
        col.OptionsColumn.ReadOnly = True
        col.Visible = bVisible

        col.ColumnEdit = pictureEdit

        Return col
    End Function



End Class
