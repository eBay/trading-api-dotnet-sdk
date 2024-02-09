Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetAllBidders
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


		Friend WithEvents TxtItemId As System.Windows.Forms.TextBox 

		Friend WithEvents LblItemId As System.Windows.Forms.Label 

		Friend WithEvents LblHighBidders As System.Windows.Forms.Label 

		Friend WithEvents BtnGetAllBidders As System.Windows.Forms.Button 

		Friend WithEvents ClmAction As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmUser As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmCurrency As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmMaxBid As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmQuantiy As System.Windows.Forms.ColumnHeader 

		Friend WithEvents ClmTimeBid As System.Windows.Forms.ColumnHeader 

		Friend WithEvents GrpResults As System.Windows.Forms.GroupBox 

		Friend WithEvents LstHighBids As System.Windows.Forms.ListView 

		Friend WithEvents CboCallMode As System.Windows.Forms.ComboBox 

		Friend WithEvents LblCallMode As System.Windows.Forms.Label 


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		

			Me.TxtItemId = new System.Windows.Forms.TextBox()

			Me.LblItemId = new System.Windows.Forms.Label()

			Me.GrpResults = new System.Windows.Forms.GroupBox()

			Me.LblHighBidders = new System.Windows.Forms.Label()

			Me.LstHighBids = new System.Windows.Forms.ListView()

			Me.ClmAction = new System.Windows.Forms.ColumnHeader()

			Me.ClmUser = new System.Windows.Forms.ColumnHeader()

			Me.ClmCurrency = new System.Windows.Forms.ColumnHeader()

			Me.ClmMaxBid = new System.Windows.Forms.ColumnHeader()

			Me.ClmQuantiy = new System.Windows.Forms.ColumnHeader()

			Me.ClmTimeBid = new System.Windows.Forms.ColumnHeader()

			Me.BtnGetAllBidders = new System.Windows.Forms.Button()

			Me.CboCallMode = new System.Windows.Forms.ComboBox()

			Me.LblCallMode = new System.Windows.Forms.Label()

			Me.GrpResults.SuspendLayout()

			Me.SuspendLayout()

			' 

			' TxtItemId

			' 

			Me.TxtItemId.Location = new System.Drawing.Point(256, 8)

			Me.TxtItemId.Name = "TxtItemId"

			Me.TxtItemId.Size = new System.Drawing.Size(88, 20)

			Me.TxtItemId.TabIndex = 30

			Me.TxtItemId.Text = ""

			' 

			' LblItemId

			' 

			Me.LblItemId.Location = new System.Drawing.Point(176, 8)

			Me.LblItemId.Name = "LblItemId"

			Me.LblItemId.Size = new System.Drawing.Size(80, 18)

			Me.LblItemId.TabIndex = 37

			Me.LblItemId.Text = "Item Id:"

			' 

			' GrpResults

			' 

			Me.GrpResults.Controls.Add(Me.LblHighBidders)

			Me.GrpResults.Controls.Add(Me.LstHighBids)

			Me.GrpResults.Location = new System.Drawing.Point(8, 128)

			Me.GrpResults.Name = "GrpResults"

			Me.GrpResults.Size = new System.Drawing.Size(488, 192)

			Me.GrpResults.TabIndex = 45

			Me.GrpResults.TabStop = false

			Me.GrpResults.Text = "Results"

			' 

			' LblHighBidders

			' 

			Me.LblHighBidders.Location = new System.Drawing.Point(16, 24)

			Me.LblHighBidders.Name = "LblHighBidders"

			Me.LblHighBidders.Size = new System.Drawing.Size(136, 23)

			Me.LblHighBidders.TabIndex = 14

			Me.LblHighBidders.Text = "High Bidders:"

			' 

			' LstHighBids

			' 

			Me.LstHighBids.Columns.AddRange(new System.Windows.Forms.ColumnHeader(){Me.ClmAction,Me.ClmUser,Me.ClmCurrency,Me.ClmMaxBid,Me.ClmQuantiy, Me.ClmTimeBid})

			Me.LstHighBids.GridLines = true

			Me.LstHighBids.Location = new System.Drawing.Point(24, 48)

			Me.LstHighBids.Name = "LstHighBids"

			Me.LstHighBids.Size = new System.Drawing.Size(456, 136)

			Me.LstHighBids.TabIndex = 15

			Me.LstHighBids.View = System.Windows.Forms.View.Details

			' 

			' ClmAction

			' 

			Me.ClmAction.Text = "Action"

			Me.ClmAction.Width = 50

			' 

			' ClmUser

			' 

			Me.ClmUser.Text = "User"

			Me.ClmUser.Width = 59

			' 

			' ClmCurrency

			' 

			Me.ClmCurrency.Text = "Currency"

			Me.ClmCurrency.Width = 62

			' 

			' ClmMaxBid

			' 

			Me.ClmMaxBid.Text = "MaxBid"

			' 

			' ClmQuantiy

			' 

			Me.ClmQuantiy.Text = "Quantity"

			Me.ClmQuantiy.Width = 59

			' 

			' ClmTimeBid

			' 

			Me.ClmTimeBid.Text = "Bid Time"

			Me.ClmTimeBid.Width = 158

			' 

			' BtnGetAllBidders

			' 

			Me.BtnGetAllBidders.Location = new System.Drawing.Point(200, 88)

			Me.BtnGetAllBidders.Name = "BtnGetAllBidders"

			Me.BtnGetAllBidders.Size = new System.Drawing.Size(120, 26)

			Me.BtnGetAllBidders.TabIndex = 46

			Me.BtnGetAllBidders.Text = "GetAllBidders"

        'Me.BtnGetAllBidders.Click += new System.EventHandler(Me.BtnGetAllBidders_Click)

			' 

			' CboCallMode

			' 

			Me.CboCallMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

			Me.CboCallMode.Location = new System.Drawing.Point(256, 32)

			Me.CboCallMode.Name = "CboCallMode"

			Me.CboCallMode.Size = new System.Drawing.Size(144, 21)

			Me.CboCallMode.TabIndex = 57

			' 

			' LblCallMode

			' 

			Me.LblCallMode.Location = new System.Drawing.Point(176, 32)

			Me.LblCallMode.Name = "LblCallMode"

			Me.LblCallMode.Size = new System.Drawing.Size(80, 18)

			Me.LblCallMode.TabIndex = 56

			Me.LblCallMode.Text = "Call Mode:"

			' 

			' FrmGetAllBidders

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(504, 325)

			Me.Controls.Add(Me.CboCallMode)

			Me.Controls.Add(Me.LblCallMode)

			Me.Controls.Add(Me.BtnGetAllBidders)

			Me.Controls.Add(Me.GrpResults)

			Me.Controls.Add(Me.TxtItemId)

			Me.Controls.Add(Me.LblItemId)

			Me.Name = "FrmGetAllBidders"

			Me.Text = "GetAllBidders"

			'Me.Load += new System.EventHandler(Me.FrmGetAllBidders_Load)

			Me.GrpResults.ResumeLayout(false)

			Me.ResumeLayout(false)
    End Sub

#End Region


    Public Context As ApiContext

		Private Sub  FrmGetAllBidders_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

			Dim modes() As String = [Enum].GetNames(GetType(GetAllBiddersModeCodeType))
			Dim mode As String

			For Each mode in modes
				If mode <> "CustomCode" Then
					CboCallMode.Items.Add(mode)

				End If
			Next mode

			CboCallMode.SelectedIndex = 0
    End Sub

    Private Sub BtnGetAllBidders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetAllBidders.Click

        Try

            LstHighBids.Items.Clear()

            Dim apicall As GetAllBiddersCall = New GetAllBiddersCall(Context)

            Dim bids As OfferTypeCollection = apicall.GetAllBidders(TxtItemId.Text, [Enum].Parse(GetType(GetAllBiddersModeCodeType), CboCallMode.SelectedItem.ToString()))
            Dim offer As OfferType

            For Each offer In bids

                Dim listparams(6) As String

                listparams(0) = offer.Action.ToString()

                listparams(1) = offer.User.UserID

                listparams(2) = offer.Currency.ToString()

                listparams(3) = offer.MaxBid.Value.ToString()

                listparams(4) = offer.Quantity.ToString()

                listparams(5) = offer.TimeBid.ToString()


                Dim vi As ListViewItem = New ListViewItem(listparams)

                Me.LstHighBids.Items.Add(vi)
            Next offer


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class

