<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUploadPictures
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.extDaysTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.checkBox = New System.Windows.Forms.CheckBox
        Me.uploadButton = New System.Windows.Forms.Button
        Me.removeButton = New System.Windows.Forms.Button
        Me.browseButton = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.listView = New System.Windows.Forms.ListView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.textBox = New System.Windows.Forms.TextBox
        Me.openFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.imageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.extDaysTextBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.checkBox)
        Me.Panel1.Controls.Add(Me.uploadButton)
        Me.Panel1.Controls.Add(Me.removeButton)
        Me.Panel1.Controls.Add(Me.browseButton)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(493, 61)
        Me.Panel1.TabIndex = 0
        '
        'extDaysTextBox
        '
        Me.extDaysTextBox.Location = New System.Drawing.Point(398, 20)
        Me.extDaysTextBox.Name = "extDaysTextBox"
        Me.extDaysTextBox.Size = New System.Drawing.Size(48, 20)
        Me.extDaysTextBox.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(342, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "ExtDays:"
        '
        'checkBox
        '
        Me.checkBox.AutoSize = True
        Me.checkBox.Location = New System.Drawing.Point(258, 23)
        Me.checkBox.Name = "checkBox"
        Me.checkBox.Size = New System.Drawing.Size(78, 17)
        Me.checkBox.TabIndex = 3
        Me.checkBox.Text = "Watermark"
        Me.checkBox.UseVisualStyleBackColor = True
        '
        'uploadButton
        '
        Me.uploadButton.Location = New System.Drawing.Point(176, 18)
        Me.uploadButton.Name = "uploadButton"
        Me.uploadButton.Size = New System.Drawing.Size(75, 23)
        Me.uploadButton.TabIndex = 2
        Me.uploadButton.Text = "Upload"
        Me.uploadButton.UseVisualStyleBackColor = True
        '
        'removeButton
        '
        Me.removeButton.Location = New System.Drawing.Point(95, 18)
        Me.removeButton.Name = "removeButton"
        Me.removeButton.Size = New System.Drawing.Size(75, 23)
        Me.removeButton.TabIndex = 1
        Me.removeButton.Text = "Remove"
        Me.removeButton.UseVisualStyleBackColor = True
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(13, 18)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(75, 23)
        Me.browseButton.TabIndex = 0
        Me.browseButton.Text = "Browse..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.listView)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(493, 269)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pictures"
        '
        'listView
        '
        Me.listView.LargeImageList = Me.imageList
        Me.listView.Location = New System.Drawing.Point(6, 19)
        Me.listView.Name = "listView"
        Me.listView.Size = New System.Drawing.Size(481, 244)
        Me.listView.TabIndex = 0
        Me.listView.UseCompatibleStateImageBehavior = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.textBox)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 355)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(493, 122)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Uploaded Pictures URLs"
        '
        'textBox
        '
        Me.textBox.Location = New System.Drawing.Point(6, 19)
        Me.textBox.Multiline = True
        Me.textBox.Name = "textBox"
        Me.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.textBox.Size = New System.Drawing.Size(481, 97)
        Me.textBox.TabIndex = 0
        Me.textBox.WordWrap = False
        '
        'openFileDialog
        '
        Me.openFileDialog.FileName = "OpenFileDialog1"
        '
        'imageList
        '
        Me.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
        Me.imageList.ImageSize = New System.Drawing.Size(100, 100)
        Me.imageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'FormUploadPictures
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 488)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormUploadPictures"
        Me.Text = "FormUploadPictures"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents uploadButton As System.Windows.Forms.Button
    Friend WithEvents removeButton As System.Windows.Forms.Button
    Friend WithEvents browseButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents extDaysTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents checkBox As System.Windows.Forms.CheckBox
    Friend WithEvents openFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents imageList As System.Windows.Forms.ImageList
    Friend WithEvents listView As System.Windows.Forms.ListView
    Friend WithEvents textBox As System.Windows.Forms.TextBox
End Class
