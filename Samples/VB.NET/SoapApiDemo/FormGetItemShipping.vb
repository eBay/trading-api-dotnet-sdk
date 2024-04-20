Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetItemShipping
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



    Friend WithEvents BtnGetItemShipping As System.Windows.Forms.Button

    Friend WithEvents GrpResult As System.Windows.Forms.GroupBox

    Friend WithEvents LblItemId As System.Windows.Forms.Label

    Friend WithEvents TxtItemId As System.Windows.Forms.TextBox

    Friend WithEvents LblDestination As System.Windows.Forms.Label

    Friend WithEvents TxtDestination As System.Windows.Forms.TextBox

    Friend WithEvents LstShipSvc As System.Windows.Forms.ListView

    Friend WithEvents ClmService As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmCost As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmInsurance As System.Windows.Forms.ColumnHeader

    Friend WithEvents TxtShipZip As System.Windows.Forms.TextBox

    Friend WithEvents LblShipZip As System.Windows.Forms.Label

    Friend WithEvents LblHandlingCost As System.Windows.Forms.Label

    Friend WithEvents TxtHandlingCost As System.Windows.Forms.TextBox

    Friend WithEvents TxtShipType As System.Windows.Forms.TextBox

    Friend WithEvents LblShipType As System.Windows.Forms.Label

    Friend WithEvents LblPackage As System.Windows.Forms.Label

    Friend WithEvents TxtPackage As System.Windows.Forms.TextBox

    Friend WithEvents LblWeight As System.Windows.Forms.Label

    Friend WithEvents TxtWeight As System.Windows.Forms.TextBox

    Friend WithEvents ClmAddedCost As System.Windows.Forms.ColumnHeader

    Friend WithEvents LblCountryCode As System.Windows.Forms.Label

    Friend WithEvents LblQuantity As System.Windows.Forms.Label

    Friend WithEvents TxtQuantity As System.Windows.Forms.TextBox

    Friend WithEvents CboCountry As System.Windows.Forms.ComboBox

    Friend WithEvents ClmShipLocation As System.Windows.Forms.ColumnHeader


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.LblItemId = New System.Windows.Forms.Label()
        Me.TxtItemId = New System.Windows.Forms.TextBox()
        Me.BtnGetItemShipping = New System.Windows.Forms.Button()
        Me.GrpResult = New System.Windows.Forms.GroupBox()
        Me.LblWeight = New System.Windows.Forms.Label()
        Me.TxtWeight = New System.Windows.Forms.TextBox()
        Me.LblPackage = New System.Windows.Forms.Label()
        Me.TxtPackage = New System.Windows.Forms.TextBox()
        Me.LstShipSvc = New System.Windows.Forms.ListView()
        Me.ClmService = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClmCost = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClmInsurance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClmAddedCost = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClmShipLocation = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TxtShipZip = New System.Windows.Forms.TextBox()
        Me.LblShipZip = New System.Windows.Forms.Label()
        Me.LblHandlingCost = New System.Windows.Forms.Label()
        Me.TxtHandlingCost = New System.Windows.Forms.TextBox()
        Me.TxtShipType = New System.Windows.Forms.TextBox()
        Me.LblShipType = New System.Windows.Forms.Label()
        Me.LblDestination = New System.Windows.Forms.Label()
        Me.TxtDestination = New System.Windows.Forms.TextBox()
        Me.LblCountryCode = New System.Windows.Forms.Label()
        Me.LblQuantity = New System.Windows.Forms.Label()
        Me.TxtQuantity = New System.Windows.Forms.TextBox()
        Me.CboCountry = New System.Windows.Forms.ComboBox()
        Me.GrpResult.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblItemId
        '
        Me.LblItemId.Location = New System.Drawing.Point(16, 8)
        Me.LblItemId.Name = "LblItemId"
        Me.LblItemId.Size = New System.Drawing.Size(88, 16)
        Me.LblItemId.TabIndex = 40
        Me.LblItemId.Text = "Item Id:"
        '
        'TxtItemId
        '
        Me.TxtItemId.Location = New System.Drawing.Point(104, 8)
        Me.TxtItemId.Name = "TxtItemId"
        Me.TxtItemId.Size = New System.Drawing.Size(128, 20)
        Me.TxtItemId.TabIndex = 27
        '
        'BtnGetItemShipping
        '
        Me.BtnGetItemShipping.Location = New System.Drawing.Point(192, 80)
        Me.BtnGetItemShipping.Name = "BtnGetItemShipping"
        Me.BtnGetItemShipping.Size = New System.Drawing.Size(104, 23)
        Me.BtnGetItemShipping.TabIndex = 28
        Me.BtnGetItemShipping.Text = "GetItemShipping"
        '
        'GrpResult
        '
        Me.GrpResult.Controls.Add(Me.LblWeight)
        Me.GrpResult.Controls.Add(Me.TxtWeight)
        Me.GrpResult.Controls.Add(Me.LblPackage)
        Me.GrpResult.Controls.Add(Me.TxtPackage)
        Me.GrpResult.Controls.Add(Me.LstShipSvc)
        Me.GrpResult.Controls.Add(Me.TxtShipZip)
        Me.GrpResult.Controls.Add(Me.LblShipZip)
        Me.GrpResult.Controls.Add(Me.LblHandlingCost)
        Me.GrpResult.Controls.Add(Me.TxtHandlingCost)
        Me.GrpResult.Controls.Add(Me.TxtShipType)
        Me.GrpResult.Controls.Add(Me.LblShipType)
        Me.GrpResult.Location = New System.Drawing.Point(8, 112)
        Me.GrpResult.Name = "GrpResult"
        Me.GrpResult.Size = New System.Drawing.Size(464, 264)
        Me.GrpResult.TabIndex = 41
        Me.GrpResult.TabStop = False
        Me.GrpResult.Text = "Result"
        '
        'LblWeight
        '
        Me.LblWeight.Location = New System.Drawing.Point(8, 120)
        Me.LblWeight.Name = "LblWeight"
        Me.LblWeight.Size = New System.Drawing.Size(120, 23)
        Me.LblWeight.TabIndex = 79
        Me.LblWeight.Text = "Weight:"
        Me.LblWeight.Visible = False
        '
        'TxtWeight
        '
        Me.TxtWeight.Location = New System.Drawing.Point(128, 120)
        Me.TxtWeight.Name = "TxtWeight"
        Me.TxtWeight.ReadOnly = True
        Me.TxtWeight.Size = New System.Drawing.Size(120, 20)
        Me.TxtWeight.TabIndex = 80
        Me.TxtWeight.Visible = False
        '
        'LblPackage
        '
        Me.LblPackage.Location = New System.Drawing.Point(8, 96)
        Me.LblPackage.Name = "LblPackage"
        Me.LblPackage.Size = New System.Drawing.Size(120, 23)
        Me.LblPackage.TabIndex = 77
        Me.LblPackage.Text = "Package:"
        Me.LblPackage.Visible = False
        '
        'TxtPackage
        '
        Me.TxtPackage.Location = New System.Drawing.Point(128, 96)
        Me.TxtPackage.Name = "TxtPackage"
        Me.TxtPackage.ReadOnly = True
        Me.TxtPackage.Size = New System.Drawing.Size(120, 20)
        Me.TxtPackage.TabIndex = 78
        Me.TxtPackage.Visible = False
        '
        'LstShipSvc
        '
        Me.LstShipSvc.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmService, Me.ClmCost, Me.ClmInsurance, Me.ClmAddedCost, Me.ClmShipLocation})
        Me.LstShipSvc.GridLines = True
        Me.LstShipSvc.Location = New System.Drawing.Point(8, 168)
        Me.LstShipSvc.Name = "LstShipSvc"
        Me.LstShipSvc.Size = New System.Drawing.Size(424, 80)
        Me.LstShipSvc.TabIndex = 76
        Me.LstShipSvc.UseCompatibleStateImageBehavior = False
        Me.LstShipSvc.View = System.Windows.Forms.View.Details
        '
        'ClmService
        '
        Me.ClmService.Text = "Service"
        Me.ClmService.Width = 129
        '
        'ClmCost
        '
        Me.ClmCost.Text = "Cost"
        Me.ClmCost.Width = 61
        '
        'ClmInsurance
        '
        Me.ClmInsurance.Text = "Insurance"
        Me.ClmInsurance.Width = 63
        '
        'ClmAddedCost
        '
        Me.ClmAddedCost.Text = "Additional Cost"
        Me.ClmAddedCost.Width = 83
        '
        'ClmShipLocation
        '
        Me.ClmShipLocation.Text = "Locations"
        Me.ClmShipLocation.Width = 79
        '
        'TxtShipZip
        '
        Me.TxtShipZip.Location = New System.Drawing.Point(128, 48)
        Me.TxtShipZip.Name = "TxtShipZip"
        Me.TxtShipZip.ReadOnly = True
        Me.TxtShipZip.Size = New System.Drawing.Size(120, 20)
        Me.TxtShipZip.TabIndex = 73
        '
        'LblShipZip
        '
        Me.LblShipZip.Location = New System.Drawing.Point(8, 48)
        Me.LblShipZip.Name = "LblShipZip"
        Me.LblShipZip.Size = New System.Drawing.Size(120, 23)
        Me.LblShipZip.TabIndex = 60
        Me.LblShipZip.Text = "Ship From Zip:"
        '
        'LblHandlingCost
        '
        Me.LblHandlingCost.Location = New System.Drawing.Point(8, 72)
        Me.LblHandlingCost.Name = "LblHandlingCost"
        Me.LblHandlingCost.Size = New System.Drawing.Size(120, 23)
        Me.LblHandlingCost.TabIndex = 62
        Me.LblHandlingCost.Text = "Handling Cost:"
        '
        'TxtHandlingCost
        '
        Me.TxtHandlingCost.Location = New System.Drawing.Point(128, 72)
        Me.TxtHandlingCost.Name = "TxtHandlingCost"
        Me.TxtHandlingCost.ReadOnly = True
        Me.TxtHandlingCost.Size = New System.Drawing.Size(120, 20)
        Me.TxtHandlingCost.TabIndex = 69
        '
        'TxtShipType
        '
        Me.TxtShipType.Location = New System.Drawing.Point(128, 24)
        Me.TxtShipType.Name = "TxtShipType"
        Me.TxtShipType.ReadOnly = True
        Me.TxtShipType.Size = New System.Drawing.Size(120, 20)
        Me.TxtShipType.TabIndex = 70
        '
        'LblShipType
        '
        Me.LblShipType.Location = New System.Drawing.Point(8, 24)
        Me.LblShipType.Name = "LblShipType"
        Me.LblShipType.Size = New System.Drawing.Size(120, 23)
        Me.LblShipType.TabIndex = 54
        Me.LblShipType.Text = "Ship Type:"
        '
        'LblDestination
        '
        Me.LblDestination.Location = New System.Drawing.Point(16, 32)
        Me.LblDestination.Name = "LblDestination"
        Me.LblDestination.Size = New System.Drawing.Size(88, 16)
        Me.LblDestination.TabIndex = 43
        Me.LblDestination.Text = "Destination Zip:"
        '
        'TxtDestination
        '
        Me.TxtDestination.Location = New System.Drawing.Point(104, 32)
        Me.TxtDestination.Name = "TxtDestination"
        Me.TxtDestination.Size = New System.Drawing.Size(128, 20)
        Me.TxtDestination.TabIndex = 42
        '
        'LblCountryCode
        '
        Me.LblCountryCode.Location = New System.Drawing.Point(248, 8)
        Me.LblCountryCode.Name = "LblCountryCode"
        Me.LblCountryCode.Size = New System.Drawing.Size(96, 16)
        Me.LblCountryCode.TabIndex = 45
        Me.LblCountryCode.Text = "Country Code:"
        '
        'LblQuantity
        '
        Me.LblQuantity.Location = New System.Drawing.Point(248, 32)
        Me.LblQuantity.Name = "LblQuantity"
        Me.LblQuantity.Size = New System.Drawing.Size(96, 16)
        Me.LblQuantity.TabIndex = 47
        Me.LblQuantity.Text = "Quantity:"
        '
        'TxtQuantity
        '
        Me.TxtQuantity.Location = New System.Drawing.Point(344, 32)
        Me.TxtQuantity.Name = "TxtQuantity"
        Me.TxtQuantity.Size = New System.Drawing.Size(128, 20)
        Me.TxtQuantity.TabIndex = 46
        '
        'CboCountry
        '
        Me.CboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCountry.Location = New System.Drawing.Point(344, 8)
        Me.CboCountry.Name = "CboCountry"
        Me.CboCountry.Size = New System.Drawing.Size(128, 21)
        Me.CboCountry.TabIndex = 56
        '
        'FormGetItemShipping
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(480, 389)
        Me.Controls.Add(Me.CboCountry)
        Me.Controls.Add(Me.LblQuantity)
        Me.Controls.Add(Me.TxtQuantity)
        Me.Controls.Add(Me.LblCountryCode)
        Me.Controls.Add(Me.LblDestination)
        Me.Controls.Add(Me.TxtDestination)
        Me.Controls.Add(Me.TxtItemId)
        Me.Controls.Add(Me.GrpResult)
        Me.Controls.Add(Me.LblItemId)
        Me.Controls.Add(Me.BtnGetItemShipping)
        Me.Name = "FormGetItemShipping"
        Me.Text = "GetItemShipping"
        Me.GrpResult.ResumeLayout(False)
        Me.GrpResult.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Public Context As ApiContext

    Private Sub FrmGetItemShipping_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CboCountry.Items.Add("NoChange")
        Dim countries() As String = [Enum].GetNames(GetType(CountryCodeType))
        Dim cntry As String

        For Each cntry In countries
            If cntry <> "CustomCode" Then
                CboCountry.Items.Add(cntry)
            End If
        Next cntry

        CboCountry.SelectedIndex = 0

    End Sub

    Private Sub BtnGetItemShipping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetItemShipping.Click

        Try

            LstShipSvc.Items.Clear()

            TxtShipZip.Text = ""

            TxtHandlingCost.Text = ""

            TxtShipType.Text = ""

            TxtPackage.Text = ""

            TxtWeight.Text = ""

            Dim ApiCall As GetItemShippingCall = New GetItemShippingCall(Context)

            If TxtQuantity.Text <> String.Empty Then
                ApiCall.QuantitySold = Convert.ToInt32(TxtQuantity.Text)
            End If

            If CboCountry.SelectedIndex <> 0 Then
                ApiCall.DestinationCountryCode = [Enum].Parse(GetType(CountryCodeType), CboCountry.SelectedItem.ToString())
            End If
            Dim shipdetails As ShippingDetailsType = ApiCall.GetItemShipping(TxtItemId.Text, TxtDestination.Text)


            TxtShipType.Text = shipdetails.ShippingType.ToString()
            If Not shipdetails.CalculatedShippingRate Is Nothing Then
                TxtShipZip.Text = shipdetails.CalculatedShippingRate.OriginatingPostalCode
                TxtHandlingCost.Text = shipdetails.CalculatedShippingRate.PackagingHandlingCosts.Value.ToString()
                'TxtPackage.Text = shipdetails.CalculatedShippingRate.ShippingPackage.ToString()
                'TxtWeight.Text = shipdetails.CalculatedShippingRate.WeightMajor.Value.ToString() + " " + shipdetails.CalculatedShippingRate.WeightMajor.unit + " - " + shipdetails.CalculatedShippingRate.WeightMinor.Value.ToString() + " " + shipdetails.CalculatedShippingRate.WeightMinor.unit
            End If


            Dim shipopt As ShippingServiceOptionsType
            For Each shipopt In shipdetails.ShippingServiceOptions

                Dim listparams(5) As String
                listparams(0) = shipopt.ShippingService.ToString()
                If Not shipopt.ShippingServiceCost Is Nothing Then
                    listparams(1) = shipopt.ShippingServiceCost.Value.ToString()
                End If

                If Not shipopt.ShippingInsuranceCost Is Nothing Then
                    listparams(2) = shipopt.ShippingInsuranceCost.Value.ToString()
                End If

                If Not shipopt.ShippingServiceAdditionalCost Is Nothing Then
                    listparams(3) = shipopt.ShippingServiceAdditionalCost.Value.ToString()
                End If

                Dim vi As ListViewItem = New ListViewItem(listparams)

                Me.LstShipSvc.Items.Add(vi)
            Next shipopt

            Dim shipoptintl As InternationalShippingServiceOptionsType
            For Each shipoptintl In shipdetails.InternationalShippingServiceOption
                Dim listparams(5) As String
                listparams(0) = shipoptintl.ShippingService.ToString()
                If Not shipoptintl.ShippingServiceCost Is Nothing Then
                    listparams(1) = shipoptintl.ShippingServiceCost.Value.ToString()
                End If

                If Not shipoptintl.ShippingServiceAdditionalCost Is Nothing Then
                    listparams(3) = shipoptintl.ShippingServiceAdditionalCost.Value.ToString()
                End If

                listparams(4) = String.Join(", ", shipoptintl.ShipToLocation.ToArray())
                Dim vi As ListViewItem = New ListViewItem(listparams)

                Me.LstShipSvc.Items.Add(vi)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class

