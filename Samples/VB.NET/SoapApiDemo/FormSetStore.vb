Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormSetStore
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



		Friend WithEvents TxtDescription As System.Windows.Forms.TextBox 

		Friend WithEvents LblDescription As System.Windows.Forms.Label 

		Friend WithEvents BtnSetStore As System.Windows.Forms.Button 

		Friend WithEvents TxtName As System.Windows.Forms.TextBox 

		Friend WithEvents LblName As System.Windows.Forms.Label 

		Friend WithEvents TxtHeader As System.Windows.Forms.TextBox 

		Friend WithEvents LblHeader As System.Windows.Forms.Label 

		Friend WithEvents CboLayout As System.Windows.Forms.ComboBox 

		Friend WithEvents LblLayout As System.Windows.Forms.Label 

		Friend WithEvents CboSort As System.Windows.Forms.ComboBox 

		Friend WithEvents LblSort As System.Windows.Forms.Label 

		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents label1 As System.Windows.Forms.Label 

		Friend WithEvents TxtStatus As System.Windows.Forms.TextBox 


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		

			Me.TxtDescription = new System.Windows.Forms.TextBox()

			Me.LblDescription = new System.Windows.Forms.Label()

			Me.BtnSetStore = new System.Windows.Forms.Button()

			Me.TxtName = new System.Windows.Forms.TextBox()

			Me.LblName = new System.Windows.Forms.Label()

			Me.TxtHeader = new System.Windows.Forms.TextBox()

			Me.LblHeader = new System.Windows.Forms.Label()

			Me.CboLayout = new System.Windows.Forms.ComboBox()

			Me.LblLayout = new System.Windows.Forms.Label()

			Me.CboSort = new System.Windows.Forms.ComboBox()

			Me.LblSort = new System.Windows.Forms.Label()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.label1 = new System.Windows.Forms.Label()

			Me.TxtStatus = new System.Windows.Forms.TextBox()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' TxtDescription

			' 

			Me.TxtDescription.Location = new System.Drawing.Point(104, 40)

			Me.TxtDescription.Multiline = true

			Me.TxtDescription.Name = "TxtDescription"

			Me.TxtDescription.Size = new System.Drawing.Size(352, 56)

			Me.TxtDescription.TabIndex = 35

			Me.TxtDescription.Text = ""

			' 

			' LblDescription

			' 

			Me.LblDescription.Location = new System.Drawing.Point(24, 40)

			Me.LblDescription.Name = "LblDescription"

			Me.LblDescription.Size = new System.Drawing.Size(80, 18)

			Me.LblDescription.TabIndex = 42

			Me.LblDescription.Text = "Description:"

			' 

			' BtnSetStore

			' 

			Me.BtnSetStore.Location = new System.Drawing.Point(184, 208)

			Me.BtnSetStore.Name = "BtnSetStore"

			Me.BtnSetStore.Size = new System.Drawing.Size(120, 26)

			Me.BtnSetStore.TabIndex = 36

			Me.BtnSetStore.Text = "SetStore"

        'Me.BtnSetStore.Click += new System.EventHandler(Me.BtnSetStore_Click)

			' 

			' TxtName

			' 

			Me.TxtName.Location = new System.Drawing.Point(104, 16)

			Me.TxtName.Name = "TxtName"

			Me.TxtName.Size = new System.Drawing.Size(248, 20)

			Me.TxtName.TabIndex = 55

			Me.TxtName.Text = ""

			' 

			' LblName

			' 

			Me.LblName.Location = new System.Drawing.Point(24, 16)

			Me.LblName.Name = "LblName"

			Me.LblName.Size = new System.Drawing.Size(80, 18)

			Me.LblName.TabIndex = 56

			Me.LblName.Text = "Store Name:"

			' 

			' TxtHeader

			' 

			Me.TxtHeader.Location = new System.Drawing.Point(104, 96)

			Me.TxtHeader.Multiline = true

			Me.TxtHeader.Name = "TxtHeader"

			Me.TxtHeader.Size = new System.Drawing.Size(352, 56)

			Me.TxtHeader.TabIndex = 57

			Me.TxtHeader.Text = ""

			' 

			' LblHeader

			' 

			Me.LblHeader.Location = new System.Drawing.Point(24, 96)

			Me.LblHeader.Name = "LblHeader"

			Me.LblHeader.Size = new System.Drawing.Size(80, 18)

			Me.LblHeader.TabIndex = 58

			Me.LblHeader.Text = "Header:"

			' 

			' CboLayout

			' 

			Me.CboLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

			Me.CboLayout.Location = new System.Drawing.Point(104, 152)

			Me.CboLayout.Name = "CboLayout"

			Me.CboLayout.Size = new System.Drawing.Size(144, 21)

			Me.CboLayout.TabIndex = 61

			' 

			' LblLayout

			' 

			Me.LblLayout.Location = new System.Drawing.Point(24, 152)

			Me.LblLayout.Name = "LblLayout"

			Me.LblLayout.Size = new System.Drawing.Size(80, 18)

			Me.LblLayout.TabIndex = 60

			Me.LblLayout.Text = "Item Layout:"

			' 

			' CboSort

			' 

			Me.CboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

			Me.CboSort.Location = new System.Drawing.Point(104, 176)

			Me.CboSort.Name = "CboSort"

			Me.CboSort.Size = new System.Drawing.Size(144, 21)

			Me.CboSort.TabIndex = 63

			' 

			' LblSort

			' 

			Me.LblSort.Location = new System.Drawing.Point(24, 176)

			Me.LblSort.Name = "LblSort"

			Me.LblSort.Size = new System.Drawing.Size(80, 18)

			Me.LblSort.TabIndex = 62

			Me.LblSort.Text = "Item Sort:"

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.label1)

			Me.GrpResult.Controls.Add(Me.TxtStatus)

			Me.GrpResult.Location = new System.Drawing.Point(16, 240)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(464, 64)

			Me.GrpResult.TabIndex = 64

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Result"

			' 

			' label1

			' 

			Me.label1.Location = new System.Drawing.Point(16, 24)

			Me.label1.Name = "label1"

			Me.label1.Size = new System.Drawing.Size(80, 23)

			Me.label1.TabIndex = 42

			Me.label1.Text = "Status:"

			' 

			' TxtStatus

			' 

			Me.TxtStatus.Location = new System.Drawing.Point(96, 24)

			Me.TxtStatus.Name = "TxtStatus"

			Me.TxtStatus.ReadOnly = true

			Me.TxtStatus.Size = new System.Drawing.Size(72, 20)

			Me.TxtStatus.TabIndex = 41

			Me.TxtStatus.Text = ""

			' 

			' FrmSetStore

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(480, 317)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.CboSort)

			Me.Controls.Add(Me.LblSort)

			Me.Controls.Add(Me.CboLayout)

			Me.Controls.Add(Me.LblLayout)

			Me.Controls.Add(Me.TxtHeader)

			Me.Controls.Add(Me.LblHeader)

			Me.Controls.Add(Me.TxtName)

			Me.Controls.Add(Me.LblName)

			Me.Controls.Add(Me.TxtDescription)

			Me.Controls.Add(Me.LblDescription)

			Me.Controls.Add(Me.BtnSetStore)

			Me.Name = "FrmSetStore"

			Me.Text = "SetStore"

			'Me.Load += new System.EventHandler(Me.FrmSetStore_Load)

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)
   End Sub

#End Region


		Public Context As ApiContext

		Private Sub  FrmSetStore_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		

			CboLayout.Items.Add("NoChange")

		
			Dim layouts As Type = GetType(StoreItemListLayoutCodeType)
			Dim layout As String

			For Each layout in [Enum].GetNames(layouts)

				If layout <> "CustomCode" Then
					CboLayout.Items.Add(layout)

				end if

			Next layout

			CboLayout.SelectedIndex = 0
			CboSort.Items.Add("NoChange")


        Dim sorts As Type = GetType(StoreItemListSortOrderCodeType)
        Dim srt As String

        For Each srt In [Enum].GetNames(sorts)

            If srt <> "CustomCode" Then

                CboSort.Items.Add(srt)

            End If

        Next srt

        CboSort.SelectedIndex = 0



    End Sub


    Private Sub BtnSetStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetStore.Click



        Try

            TxtStatus.Text = ""

            Dim apicall As SetStoreCall = New SetStoreCall(Context)
            Dim store As StoreType = New StoreType()

            If TxtName.Text <> String.Empty Then

                store.Name = TxtName.Text

            End If

            If TxtDescription.Text <> String.Empty Then

                store.Description = TxtDescription.Text
            End If



            If TxtHeader.Text <> String.Empty Then

                store.CustomHeader = TxtHeader.Text
            End If



            If CboLayout.SelectedIndex > 0 Then

                store.ItemListLayout = [Enum].Parse(GetType(StoreItemListLayoutCodeType), CboLayout.SelectedItem.ToString())

            End If




            If CboSort.SelectedIndex > 0 Then

                store.ItemListSortOrder = [Enum].Parse(GetType(StoreItemListSortOrderCodeType), CboSort.SelectedItem.ToString())

            End If


            apicall.SetStore(store)
            TxtStatus.Text = apicall.ApiResponse.Ack.ToString()


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class

