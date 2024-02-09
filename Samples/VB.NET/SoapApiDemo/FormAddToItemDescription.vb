Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util


Public Class FormAddToItemDesc
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    Friend WithEvents GrpResult As System.Windows.Forms.GroupBox

    Friend WithEvents TxtItemId As System.Windows.Forms.TextBox

    Friend WithEvents LblItemId As System.Windows.Forms.Label

    Friend WithEvents TxtStatus As System.Windows.Forms.TextBox

    Friend WithEvents LblStatus As System.Windows.Forms.Label

    Friend WithEvents LblAppend As System.Windows.Forms.Label

    Friend WithEvents TxtAppend As System.Windows.Forms.TextBox

    Friend WithEvents BtnAddToItemDescriptionCall As System.Windows.Forms.Button


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        Me.BtnAddToItemDescriptionCall = New System.Windows.Forms.Button()

        Me.GrpResult = New System.Windows.Forms.GroupBox()

        Me.LblStatus = New System.Windows.Forms.Label()

        Me.TxtStatus = New System.Windows.Forms.TextBox()

        Me.TxtItemId = New System.Windows.Forms.TextBox()

        Me.LblItemId = New System.Windows.Forms.Label()

        Me.LblAppend = New System.Windows.Forms.Label()

        Me.TxtAppend = New System.Windows.Forms.TextBox()

        Me.GrpResult.SuspendLayout()

        Me.SuspendLayout()

        ' 

        ' BtnAddToItemDescriptionCall

        ' 

        Me.BtnAddToItemDescriptionCall.Location = New System.Drawing.Point(112, 104)

        Me.BtnAddToItemDescriptionCall.Name = "BtnAddToItemDescriptionCall"

        Me.BtnAddToItemDescriptionCall.Size = New System.Drawing.Size(144, 23)

        Me.BtnAddToItemDescriptionCall.TabIndex = 23

        Me.BtnAddToItemDescriptionCall.Text = "AddToItemDescriptionCall"

        'TODO Me.BtnAddToItemDescriptionCall.Click += New System.EventHandler(Me.BtnAddToItemDescription_Click)

        ' 

        ' GrpResult

        ' 

        Me.GrpResult.Controls.Add(Me.LblStatus)

        Me.GrpResult.Controls.Add(Me.TxtStatus)

        Me.GrpResult.Location = New System.Drawing.Point(8, 136)

        Me.GrpResult.Name = "GrpResult"

        Me.GrpResult.Size = New System.Drawing.Size(352, 64)

        Me.GrpResult.TabIndex = 25

        Me.GrpResult.TabStop = False

        Me.GrpResult.Text = "Result"

        ' 

        ' LblStatus

        ' 

        Me.LblStatus.Location = New System.Drawing.Point(16, 24)

        Me.LblStatus.Name = "LblStatus"

        Me.LblStatus.Size = New System.Drawing.Size(80, 23)

        Me.LblStatus.TabIndex = 42

        Me.LblStatus.Text = "Status:"

        ' 

        ' TxtStatus

        ' 

        Me.TxtStatus.Location = New System.Drawing.Point(96, 24)

        Me.TxtStatus.Name = "TxtStatus"

        Me.TxtStatus.ReadOnly = True

        Me.TxtStatus.Size = New System.Drawing.Size(72, 20)

        Me.TxtStatus.TabIndex = 41

        Me.TxtStatus.Text = ""

        ' 

        ' TxtItemId

        ' 

        Me.TxtItemId.Location = New System.Drawing.Point(88, 8)

        Me.TxtItemId.Name = "TxtItemId"

        Me.TxtItemId.Size = New System.Drawing.Size(80, 20)

        Me.TxtItemId.TabIndex = 26

        Me.TxtItemId.Text = ""

        ' 

        ' LblItemId

        ' 

        Me.LblItemId.Location = New System.Drawing.Point(8, 8)

        Me.LblItemId.Name = "LblItemId"

        Me.LblItemId.Size = New System.Drawing.Size(80, 23)

        Me.LblItemId.TabIndex = 27

        Me.LblItemId.Text = "Item Id:"

        ' 

        ' LblAppend

        ' 

        Me.LblAppend.Location = New System.Drawing.Point(8, 32)

        Me.LblAppend.Name = "LblAppend"

        Me.LblAppend.Size = New System.Drawing.Size(88, 23)

        Me.LblAppend.TabIndex = 31

        Me.LblAppend.Text = "Comments:"

        ' 

        ' TxtAppend

        ' 

        Me.TxtAppend.Location = New System.Drawing.Point(88, 32)

        Me.TxtAppend.Multiline = True

        Me.TxtAppend.Name = "TxtAppend"

        Me.TxtAppend.Size = New System.Drawing.Size(272, 64)

        Me.TxtAppend.TabIndex = 30

        Me.TxtAppend.Text = "Append to Description"

        ' 

        ' FrmAddToItemDescription

        ' 

        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)

        Me.ClientSize = New System.Drawing.Size(368, 205)

        Me.Controls.Add(Me.TxtAppend)

        Me.Controls.Add(Me.LblAppend)

        Me.Controls.Add(Me.TxtItemId)

        Me.Controls.Add(Me.LblItemId)

        Me.Controls.Add(Me.GrpResult)

        Me.Controls.Add(Me.BtnAddToItemDescriptionCall)

        Me.Name = "FrmAddToItemDescription"

        Me.Text = "AddToItemDescription"

        Me.GrpResult.ResumeLayout(False)

        Me.ResumeLayout(False)



    End Sub

#End Region


    Public Context As ApiContext


    Private Sub BtnAddToItemDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddToItemDescriptionCall.Click
        Try
            TxtStatus.Text = ""
            Dim apicall As AddToItemDescriptionCall = New AddToItemDescriptionCall(Context)
            apicall.AddToItemDescription(TxtItemId.Text, TxtAppend.Text)
            TxtStatus.Text = apicall.ApiResponse.Ack.ToString()


        Catch ex As Exception
            'Me.txtErrors.Text = ex.Message
            MsgBox(ex.Message)

        End Try


    End Sub

End Class

