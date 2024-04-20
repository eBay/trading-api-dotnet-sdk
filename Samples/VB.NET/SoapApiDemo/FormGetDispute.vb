Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util

Public Class FormGetDispute
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


		Friend WithEvents BtnGetDispute As System.Windows.Forms.Button 

		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents LblTitle As System.Windows.Forms.Label

		Friend WithEvents TxtTitle As System.Windows.Forms.TextBox 

		Friend WithEvents LblDisputeId As System.Windows.Forms.Label 

		Friend WithEvents TxtDisputeId As System.Windows.Forms.TextBox 

		Friend WithEvents TxtBuyer As System.Windows.Forms.TextBox 

		Friend WithEvents LblBuyer As System.Windows.Forms.Label

		Friend WithEvents LblCreatedTime As System.Windows.Forms.Label

		Friend WithEvents TxtCreatedTime As System.Windows.Forms.TextBox 

		Friend WithEvents TxtSeller As System.Windows.Forms.TextBox 

		Friend WithEvents LblSeller As System.Windows.Forms.Label

		Friend WithEvents LblItemId As System.Windows.Forms.Label

		Friend WithEvents TxtItemId As System.Windows.Forms.TextBox 

		Friend WithEvents LstMessages As System.Windows.Forms.ListView 

		Friend WithEvents ClmSource As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmTime As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmMessage As System.Windows.Forms.ColumnHeader 

<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

	

			Me.LblDisputeId = new System.Windows.Forms.Label()

			Me.TxtDisputeId = new System.Windows.Forms.TextBox()

			Me.BtnGetDispute = new System.Windows.Forms.Button()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblTitle = new System.Windows.Forms.Label()

			Me.TxtTitle = new System.Windows.Forms.TextBox()

			Me.TxtBuyer = new System.Windows.Forms.TextBox()

			Me.LblBuyer = new System.Windows.Forms.Label()

			Me.LblCreatedTime = new System.Windows.Forms.Label()

			Me.TxtCreatedTime = new System.Windows.Forms.TextBox()

			Me.TxtSeller = new System.Windows.Forms.TextBox()

			Me.LblSeller = new System.Windows.Forms.Label()

			Me.LblItemId = new System.Windows.Forms.Label()

			Me.TxtItemId = new System.Windows.Forms.TextBox()

			Me.LstMessages = new System.Windows.Forms.ListView()

			Me.ClmSource = new System.Windows.Forms.ColumnHeader()

			Me.ClmTime = new System.Windows.Forms.ColumnHeader()

			Me.ClmMessage = new System.Windows.Forms.ColumnHeader()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' LblDisputeId

			' 

			Me.LblDisputeId.Location = new System.Drawing.Point(112, 8)

			Me.LblDisputeId.Name = "LblDisputeId"

			Me.LblDisputeId.Size = new System.Drawing.Size(80, 23)

			Me.LblDisputeId.TabIndex = 40

			Me.LblDisputeId.Text = "Dispute Id:"

			' 

			' TxtDisputeId

			' 

			Me.TxtDisputeId.Location = new System.Drawing.Point(192, 8)

			Me.TxtDisputeId.Name = "TxtDisputeId"

			Me.TxtDisputeId.Size = new System.Drawing.Size(128, 20)

			Me.TxtDisputeId.TabIndex = 27

			Me.TxtDisputeId.Text = ""

			' 

			' BtnGetDispute

			' 

			Me.BtnGetDispute.Location = new System.Drawing.Point(192, 40)

			Me.BtnGetDispute.Name = "BtnGetDispute"

			Me.BtnGetDispute.Size = new System.Drawing.Size(104, 23)

			Me.BtnGetDispute.TabIndex = 28

			Me.BtnGetDispute.Text = "GetDispute"

			'Me.BtnGetDispute.Click += new System.EventHandler(Me.BtnGetDispute_Click)

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LstMessages)

			Me.GrpResult.Controls.Add(Me.LblItemId)

			Me.GrpResult.Controls.Add(Me.TxtItemId)

			Me.GrpResult.Controls.Add(Me.LblTitle)

			Me.GrpResult.Controls.Add(Me.TxtTitle)

			Me.GrpResult.Controls.Add(Me.TxtBuyer)

			Me.GrpResult.Controls.Add(Me.LblBuyer)

			Me.GrpResult.Controls.Add(Me.LblCreatedTime)

			Me.GrpResult.Controls.Add(Me.TxtCreatedTime)

			Me.GrpResult.Controls.Add(Me.TxtSeller)

			Me.GrpResult.Controls.Add(Me.LblSeller)

			Me.GrpResult.Location = new System.Drawing.Point(8, 72)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(440, 336)

			Me.GrpResult.TabIndex = 41

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Result"

			' 

			' LblTitle

			' 

			Me.LblTitle.Location = new System.Drawing.Point(8, 48)

			Me.LblTitle.Name = "LblTitle"

			Me.LblTitle.Size = new System.Drawing.Size(72, 23)

			Me.LblTitle.TabIndex = 61

			Me.LblTitle.Text = "Title:"

			' 

			' TxtTitle

			' 

			Me.TxtTitle.Location = new System.Drawing.Point(80, 48)

			Me.TxtTitle.Name = "TxtTitle"

			Me.TxtTitle.ReadOnly = true

			Me.TxtTitle.Size = new System.Drawing.Size(344, 20)

			Me.TxtTitle.TabIndex = 72

			Me.TxtTitle.Text = ""

			' 

			' TxtBuyer

			' 

			Me.TxtBuyer.Location = new System.Drawing.Point(80, 96)

			Me.TxtBuyer.Name = "TxtBuyer"

			Me.TxtBuyer.ReadOnly = true

			Me.TxtBuyer.Size = new System.Drawing.Size(120, 20)

			Me.TxtBuyer.TabIndex = 73

			Me.TxtBuyer.Text = ""

			' 

			' LblBuyer

			' 

			Me.LblBuyer.Location = new System.Drawing.Point(8, 96)

			Me.LblBuyer.Name = "LblBuyer"

			Me.LblBuyer.Size = new System.Drawing.Size(72, 23)

			Me.LblBuyer.TabIndex = 60

			Me.LblBuyer.Text = "Buyer:"

			' 

			' LblCreatedTime

			' 

			Me.LblCreatedTime.Location = new System.Drawing.Point(8, 120)

			Me.LblCreatedTime.Name = "LblCreatedTime"

			Me.LblCreatedTime.Size = new System.Drawing.Size(72, 23)

			Me.LblCreatedTime.TabIndex = 62

			Me.LblCreatedTime.Text = "Created:"

			' 

			' TxtCreatedTime

			' 

			Me.TxtCreatedTime.Location = new System.Drawing.Point(80, 120)

			Me.TxtCreatedTime.Name = "TxtCreatedTime"

			Me.TxtCreatedTime.ReadOnly = true

			Me.TxtCreatedTime.Size = new System.Drawing.Size(120, 20)

			Me.TxtCreatedTime.TabIndex = 69

			Me.TxtCreatedTime.Text = ""

			' 

			' TxtSeller

			' 

			Me.TxtSeller.Location = new System.Drawing.Point(80, 72)

			Me.TxtSeller.Name = "TxtSeller"

			Me.TxtSeller.ReadOnly = true

			Me.TxtSeller.Size = new System.Drawing.Size(120, 20)

			Me.TxtSeller.TabIndex = 70

			Me.TxtSeller.Text = ""

			' 

			' LblSeller

			' 

			Me.LblSeller.Location = new System.Drawing.Point(8, 72)

			Me.LblSeller.Name = "LblSeller"

			Me.LblSeller.Size = new System.Drawing.Size(72, 23)

			Me.LblSeller.TabIndex = 54

			Me.LblSeller.Text = "Seller:"

			' 

			' LblItemId

			' 

			Me.LblItemId.Location = new System.Drawing.Point(8, 24)

			Me.LblItemId.Name = "LblItemId"

			Me.LblItemId.Size = new System.Drawing.Size(72, 23)

			Me.LblItemId.TabIndex = 74

			Me.LblItemId.Text = "Item Id:"

			' 

			' TxtItemId

			' 

			Me.TxtItemId.Location = new System.Drawing.Point(80, 24)

			Me.TxtItemId.Name = "TxtItemId"

			Me.TxtItemId.ReadOnly = true

			Me.TxtItemId.Size = new System.Drawing.Size(88, 20)

			Me.TxtItemId.TabIndex = 75

			Me.TxtItemId.Text = ""

			' 

			' LstMessages

			' 

        Me.LstMessages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmSource, Me.ClmTime, Me.ClmMessage})

			Me.LstMessages.GridLines = true

			Me.LstMessages.Location = new System.Drawing.Point(8, 168)

			Me.LstMessages.Name = "LstMessages"

			Me.LstMessages.Size = new System.Drawing.Size(424, 120)

			Me.LstMessages.TabIndex = 76

			Me.LstMessages.View = System.Windows.Forms.View.Details

			' 

			' ClmSource

			' 

			Me.ClmSource.Text = "Source"

			Me.ClmSource.Width = 83

			' 

			' ClmTime

			' 

			Me.ClmTime.Text = "Time"

			Me.ClmTime.Width = 80

			' 

			' ClmMessage

			' 

			Me.ClmMessage.Text = "Message"

			Me.ClmMessage.Width = 250

			' 

			' FrmGetDispute

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(456, 445)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.LblDisputeId)

			Me.Controls.Add(Me.TxtDisputeId)

			Me.Controls.Add(Me.BtnGetDispute)

			Me.Name = "FrmGetDispute"

			Me.Text = "GetDispute"

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)
    End Sub

#End Region


    Public Context As ApiContext

		Private Sub  BtnGetDispute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetDispute.Click

			Try

				LstMessages.Items.Clear()

				TxtItemId.Text =  ""

				TxtTitle.Text =  ""

				TxtSeller.Text =  ""

				TxtBuyer.Text =  ""

				TxtCreatedTime.Text =  ""



				Dim apicall As GetDisputeCall = new GetDisputeCall(Context)

				Dim dispute As DisputeType = apicall.GetDispute(TxtDisputeId.Text)

			
				TxtItemId.Text = dispute.Item.ItemID

				TxtTitle.Text = dispute.Item.Title

				TxtSeller.Text = dispute.SellerUserID

				TxtBuyer.Text = dispute.BuyerUserID

				TxtCreatedTime.Text = dispute.DisputeCreatedTime.ToString()

				Dim message As DisputeMessageType 

				For Each message in dispute.DisputeMessage

					Dim listparams(5) As String
				
					listparams(0) = message.MessageSource.ToString()

					listparams(1) = message.MessageCreationTime.ToString()

					listparams(2) = message.MessageText

					Dim vi As  ListViewItem = new ListViewItem(listparams)

					Me.LstMessages.Items.Add(vi)
				Next message
			

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class

