Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util
Imports eBay.Service.EPS


Public Class FormUploadPictures

    Public Context As ApiContext

    Public fileList As List(Of String) = New Generic.List(Of String)


    Private Sub browseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseButton.Click
        openFileDialog.Multiselect = True
        If (openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            If (openFileDialog.FileNames IsNot Nothing) Then
                Dim fileName As String

                For Each fileName In openFileDialog.FileNames

                    addImage(fileName)

                Next
            Else
                addImage(openFileDialog.FileName)

            End If

            Me.updateListView()

        End If
    End Sub

    Private Sub addImage(ByVal imageToLoad As String)
        If (Not String.IsNullOrEmpty(imageToLoad)) Then

            Me.fileList.Add(imageToLoad)

        End If

    End Sub

    Private Sub updateListView()
        Try
            imageList.Images.Clear()
            listView.Items.Clear()

            Dim file As String
            Dim i As Integer = 0
            For Each file In Me.fileList

                imageList.Images.Add(ResizeImage(Image.FromFile(file), 100, 100))
                Dim lvi As ListViewItem = New ListViewItem(Path.GetFileName(file))
                lvi.ImageIndex = i
                Me.listView.Items.Add(lvi)
                i += 1
            Next
        Catch ex As Exception
            Me.fileList.Clear()
            imageList.Images.Clear()
            listView.Items.Clear()
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Function ResizeImage(ByVal image As System.Drawing.Image, ByVal width As Integer, ByVal height As Integer) As System.Drawing.Bitmap

        'a holder for the result
        Dim result As Bitmap = New Bitmap(width, height)

        'use a graphics object to draw the resized image into the bitmap
        Using graphics As Graphics = graphics.FromImage(result)

            'set the resize quality modes to high quality 
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            'draw the image into the target bitmap 
            graphics.DrawImage(image, 0, 0, result.Width, result.Height)


        End Using

        'return the resulting bitmap
        Return result


    End Function



    Private Sub removeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeButton.Click
        If Me.listView.SelectedItems.Count > 0 Then
            Dim sc As StringCollection = New StringCollection
            For Each index As Integer In Me.listView.SelectedIndices
                sc.Add(Me.fileList.Item(index))
            Next
            For Each file As String In sc
                Me.fileList.Remove(file)
            Next
            Me.updateListView()
        End If
    End Sub

    Private Sub uploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uploadButton.Click
        Try
            Dim eps As eBayPictureService = New eBayPictureService(Context)
            Dim result As String = String.Empty
            Dim size As Integer = Me.fileList.Count
            Dim i As Integer
            'upload pictures one by one
            For i = 0 To size - 1
                Dim file As String = Me.fileList.Item(i)
                Dim request As UploadSiteHostedPicturesRequestType = New UploadSiteHostedPicturesRequestType
                If Me.checkBox.Checked Then
                    request.PictureWatermark = New PictureWatermarkCodeTypeCollection
                    request.PictureWatermark.Add(PictureWatermarkCodeType.User)
                End If

                If Not String.IsNullOrEmpty(Me.extDaysTextBox.Text) Then
                    Dim extDays As Integer = Integer.Parse(Me.extDaysTextBox.Text)
                    request.ExtensionInDays = extDays
                End If

                Dim response As UploadSiteHostedPicturesResponseType = eps.UpLoadSiteHostedPicture(request, file)
                result += Path.GetFileName(file) + " : " + response.SiteHostedPictureDetails.FullURL + Chr(13) + Chr(10)
            Next
            Me.textBox.Text = result
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub
End Class