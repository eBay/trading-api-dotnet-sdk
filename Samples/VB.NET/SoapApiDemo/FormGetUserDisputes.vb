Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetUserDisputes
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

		Friend WithEvents BtnGetUserDisputes As System.Windows.Forms.Button 

		Friend WithEvents CboSort As System.Windows.Forms.ComboBox 

		Friend WithEvents LblSort As System.Windows.Forms.Label

		Friend WithEvents CboFilter As System.Windows.Forms.ComboBox

		Friend WithEvents LblFilter As System.Windows.Forms.Label 

		Friend WithEvents LblDisputes As System.Windows.Forms.Label 

		Friend WithEvents LstDisputes As System.Windows.Forms.ListView 

		Friend WithEvents ClmDisputeId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmItemId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmTransactionId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmState As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmStatus As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmUserId As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmOtherPartyName As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmRole As System.Windows.Forms.ColumnHeader 
	
		Friend WithEvents ClmDisputeReason As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmDisputeExplanation As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmDisputeModifiedTime As System.Windows.Forms.ColumnHeader 





		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtnGetUserDisputes = New System.Windows.Forms.Button()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.LblDisputes = New System.Windows.Forms.Label()
        Me.LstDisputes = New System.Windows.Forms.ListView()
        Me.ClmDisputeId = New System.Windows.Forms.ColumnHeader()
        Me.ClmItemId = New System.Windows.Forms.ColumnHeader()
        Me.ClmTransactionId = New System.Windows.Forms.ColumnHeader()
        Me.ClmState = New System.Windows.Forms.ColumnHeader()
        Me.ClmStatus = New System.Windows.Forms.ColumnHeader()
        Me.ClmOtherPartyName = New System.Windows.Forms.ColumnHeader()
        Me.ClmRole = New System.Windows.Forms.ColumnHeader()
        Me.ClmDisputeReason = New System.Windows.Forms.ColumnHeader()
        Me.ClmDisputeExplanation = New System.Windows.Forms.ColumnHeader()
        Me.ClmDisputeModifiedTime = New System.Windows.Forms.ColumnHeader()
        Me.CboSort = New System.Windows.Forms.ComboBox()
        Me.LblSort = New System.Windows.Forms.Label()
        Me.CboFilter = New System.Windows.Forms.ComboBox()
        Me.LblFilter = New System.Windows.Forms.Label()
        Me.ClmUserId = New System.Windows.Forms.ColumnHeader()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnGetUserDisputes
        '
        Me.BtnGetUserDisputes.Location = New System.Drawing.Point(208, 72)
        Me.BtnGetUserDisputes.Name = "BtnGetUserDisputes"
        Me.BtnGetUserDisputes.Size = New System.Drawing.Size(176, 23)
        Me.BtnGetUserDisputes.TabIndex = 9
        Me.BtnGetUserDisputes.Text = "GetUserDisputes"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.LblDisputes, Me.LstDisputes})
        Me.GrpResult.Location = New System.Drawing.Point(8, 104)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(848, 288)
        Me.GrpResult.TabIndex = 10
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'LblDisputes
        '
        Me.LblDisputes.Location = New System.Drawing.Point(16, 24)
        Me.LblDisputes.Name = "LblDisputes"
        Me.LblDisputes.Size = New System.Drawing.Size(475, 23)
        Me.LblDisputes.TabIndex = 12
        Me.LblDisputes.Text = "User Disputes:"
        '
        'LstDisputes
        '
        Me.LstDisputes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmDisputeId, Me.ClmItemId, Me.ClmTransactionId, Me.ClmState, Me.ClmStatus, Me.ClmOtherPartyName, Me.ClmRole, Me.ClmDisputeReason, Me.ClmDisputeExplanation, Me.ClmDisputeModifiedTime})
        Me.LstDisputes.GridLines = True
        Me.LstDisputes.Location = New System.Drawing.Point(16, 56)
        Me.LstDisputes.Name = "LstDisputes"
        Me.LstDisputes.Size = New System.Drawing.Size(824, 224)
        Me.LstDisputes.TabIndex = 13
        Me.LstDisputes.View = System.Windows.Forms.View.Details
        '
        'ClmDisputeId
        '
        Me.ClmDisputeId.Text = "Dispute Id"
        Me.ClmDisputeId.Width = 65
        '
        'ClmItemId
        '
        Me.ClmItemId.Text = "Item Id"
        Me.ClmItemId.Width = 83
        '
        'ClmTransactionId
        '
        Me.ClmTransactionId.Text = "Transaction Id"
        Me.ClmTransactionId.Width = 81
        '
        'ClmState
        '
        Me.ClmState.Text = "State"
        Me.ClmState.Width = 50
        '
        'ClmStatus
        '
        Me.ClmStatus.Text = "Status"
        Me.ClmStatus.Width = 80
        '
        'ClmOtherPartyName
        '
        Me.ClmOtherPartyName.Text = "OtherPartyName"
        Me.ClmOtherPartyName.Width = 90
        '
        'ClmRole
        '
        Me.ClmRole.Text = "My Role"
        Me.ClmRole.Width = 55
        '
        'ClmDisputeReason
        '
        Me.ClmDisputeReason.Text = "DisputeReason"
        Me.ClmDisputeReason.Width = 90
        '
        'ClmDisputeExplanation
        '
        Me.ClmDisputeExplanation.Text = "DisputeExplanation"
        Me.ClmDisputeExplanation.Width = 112
        '
        'ClmDisputeModifiedTime
        '
        Me.ClmDisputeModifiedTime.Text = "DisputeModifiedTime"
        Me.ClmDisputeModifiedTime.Width = 114
        '
        'CboSort
        '
        Me.CboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSort.Location = New System.Drawing.Point(256, 16)
        Me.CboSort.Name = "CboSort"
        Me.CboSort.Size = New System.Drawing.Size(144, 21)
        Me.CboSort.TabIndex = 57
        '
        'LblSort
        '
        Me.LblSort.Location = New System.Drawing.Point(176, 16)
        Me.LblSort.Name = "LblSort"
        Me.LblSort.Size = New System.Drawing.Size(80, 18)
        Me.LblSort.TabIndex = 56
        Me.LblSort.Text = "Sort:"
        '
        'CboFilter
        '
        Me.CboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFilter.Location = New System.Drawing.Point(256, 40)
        Me.CboFilter.Name = "CboFilter"
        Me.CboFilter.Size = New System.Drawing.Size(144, 21)
        Me.CboFilter.TabIndex = 59
        '
        'LblFilter
        '
        Me.LblFilter.Location = New System.Drawing.Point(176, 40)
        Me.LblFilter.Name = "LblFilter"
        Me.LblFilter.Size = New System.Drawing.Size(80, 18)
        Me.LblFilter.TabIndex = 58
        Me.LblFilter.Text = "Reason:"
        '
        'FormGetUserDisputes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(864, 397)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.CboFilter, Me.LblFilter, Me.CboSort, Me.LblSort, Me.GrpResult, Me.BtnGetUserDisputes})
        Me.Name = "FormGetUserDisputes"
        Me.Text = "GetUserDisputesForm"
        Me.GrpResult.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Context As ApiContext


		Private Sub  FrmGetUserDisputes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		

			Dim sorts() As String = [Enum].GetNames(GetType(DisputeSortTypeCodeType))
			Dim srt As String

			For Each srt in sorts

				If srt <> "CustomCode" Then

					CboSort.Items.Add(srt)
				End If
			Next srt


			CboSort.SelectedIndex = 0

			

			Dim filters() As String = [Enum].GetNames(GetType(DisputeFilterTypeCodeType))
			Dim fltr As String

			For Each fltr in filters

            If fltr <> "CustomCode" Then

                CboFilter.Items.Add(fltr)

            End If

        Next fltr

			CboFilter.SelectedIndex = 0

	End Sub

			Private Sub  BtnGetUserDisputes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetUserDisputes.Click

		

			try

			

				LstDisputes.Items.Clear()

	

            Dim apicall As GetUserDisputesCall = New GetUserDisputesCall(Context)



            apicall.DisputeFilterType = [Enum].Parse(GetType(DisputeFilterTypeCodeType), CboFilter.SelectedItem.ToString())

            apicall.DisputeSortType = [Enum].Parse(GetType(DisputeSortTypeCodeType), CboSort.SelectedItem.ToString())

            Dim page As PaginationType = New PaginationType()
            page.PageNumber = 1

            Dim disputes As DisputeTypeCollection = apicall.GetUserDisputes(page)
            Dim dsp As DisputeType
				

				For Each  dsp in disputes

                Dim listparams(10) As String

					listparams(0) = dsp.DisputeID

					listparams(1) = dsp.Item.ItemID

					listparams(2) =  dsp.TransactionID

					listparams(3) =  dsp.DisputeState.ToString()

					listparams(4) =  dsp.DisputeStatus.ToString()

					listparams(5) =  dsp.OtherPartyName

					listparams(6) =  dsp.UserRole.ToString()

					listparams(7) =  dsp.DisputeReason.ToString()

					listparams(8) =  dsp.DisputeExplanation.ToString()

					listparams(9) =  dsp.DisputeModifiedTime.ToString()


					Dim vi As ListViewItem = new ListViewItem(listparams)

					Me.LstDisputes.Items.Add(vi)


			Next 
				

        Catch ex As Exception
  
            MsgBox(ex.Message)

        End Try

    End Sub
End Class