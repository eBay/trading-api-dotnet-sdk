Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetStoreOptions
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



    Friend WithEvents BtnGetStoreOptions As System.Windows.Forms.Button

    Friend WithEvents GrpResult As System.Windows.Forms.GroupBox

    Friend WithEvents LblBasic As System.Windows.Forms.Label

    Friend WithEvents LblAdvanced As System.Windows.Forms.Label

    Friend WithEvents LblLogos As System.Windows.Forms.Label

    Friend WithEvents LblSubscriptions As System.Windows.Forms.Label

    Friend WithEvents LstBasicThemes As System.Windows.Forms.ListView

    Friend WithEvents ClmThemId As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmName As System.Windows.Forms.ColumnHeader

    Friend WithEvents LstAdvancedThemes As System.Windows.Forms.ListView

    Friend WithEvents LstLogos As System.Windows.Forms.ListView

    Friend WithEvents ClmLogoId As System.Windows.Forms.ColumnHeader

    Friend WithEvents LstSubscriptions As System.Windows.Forms.ListView

    Friend WithEvents ClmLevel As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmFee As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmThemIdA As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmNameA As System.Windows.Forms.ColumnHeader

    Friend WithEvents ClmLogoName As System.Windows.Forms.ColumnHeader


		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		

			Me.BtnGetStoreOptions = new System.Windows.Forms.Button()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.LblBasic = new System.Windows.Forms.Label()

			Me.LblAdvanced = new System.Windows.Forms.Label()

			Me.LblLogos = new System.Windows.Forms.Label()

			Me.LblSubscriptions = new System.Windows.Forms.Label()

			Me.LstBasicThemes = new System.Windows.Forms.ListView()

			Me.ClmThemId = new System.Windows.Forms.ColumnHeader()

			Me.ClmName = new System.Windows.Forms.ColumnHeader()

			Me.LstAdvancedThemes = new System.Windows.Forms.ListView()

			Me.LstLogos = new System.Windows.Forms.ListView()

			Me.ClmLogoId = new System.Windows.Forms.ColumnHeader()

			Me.LstSubscriptions = new System.Windows.Forms.ListView()

			Me.ClmLevel = new System.Windows.Forms.ColumnHeader()

			Me.ClmFee = new System.Windows.Forms.ColumnHeader()

			Me.ClmThemIdA = new System.Windows.Forms.ColumnHeader()

			Me.ClmNameA = new System.Windows.Forms.ColumnHeader()

			Me.ClmLogoName = new System.Windows.Forms.ColumnHeader()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' BtnGetStoreOptions

			' 

			Me.BtnGetStoreOptions.Location = new System.Drawing.Point(168, 16)

			Me.BtnGetStoreOptions.Name = "BtnGetStoreOptions"

			Me.BtnGetStoreOptions.Size = new System.Drawing.Size(128, 23)

			Me.BtnGetStoreOptions.TabIndex = 28

			Me.BtnGetStoreOptions.Text = "GetStoreOptions"

        'Me.BtnGetStoreOptions.Click += new System.EventHandler(Me.BtnGetStoreOptions_Click)

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.LstSubscriptions)

			Me.GrpResult.Controls.Add(Me.LstLogos)

			Me.GrpResult.Controls.Add(Me.LstAdvancedThemes)

			Me.GrpResult.Controls.Add(Me.LstBasicThemes)

			Me.GrpResult.Controls.Add(Me.LblSubscriptions)

			Me.GrpResult.Controls.Add(Me.LblLogos)

			Me.GrpResult.Controls.Add(Me.LblAdvanced)

			Me.GrpResult.Controls.Add(Me.LblBasic)

			Me.GrpResult.Location = new System.Drawing.Point(8, 48)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(440, 568)

			Me.GrpResult.TabIndex = 41

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Result"

			' 

			' LblBasic

			' 

			Me.LblBasic.Location = new System.Drawing.Point(8, 16)

			Me.LblBasic.Name = "LblBasic"

			Me.LblBasic.Size = new System.Drawing.Size(64, 23)

			Me.LblBasic.TabIndex = 74

			Me.LblBasic.Text = "Basic"

			' 

			' LblAdvanced

			' 

			Me.LblAdvanced.Location = new System.Drawing.Point(8, 152)

			Me.LblAdvanced.Name = "LblAdvanced"

			Me.LblAdvanced.Size = new System.Drawing.Size(64, 23)

			Me.LblAdvanced.TabIndex = 76

			Me.LblAdvanced.Text = "Advanced"

			' 

			' LblLogos

			' 

			Me.LblLogos.Location = new System.Drawing.Point(8, 288)

			Me.LblLogos.Name = "LblLogos"

			Me.LblLogos.Size = new System.Drawing.Size(64, 23)

			Me.LblLogos.TabIndex = 78

			Me.LblLogos.Text = "Logos"

			' 

			' LblSubscriptions

			' 

			Me.LblSubscriptions.Location = new System.Drawing.Point(8, 424)

			Me.LblSubscriptions.Name = "LblSubscriptions"

			Me.LblSubscriptions.Size = new System.Drawing.Size(144, 23)

			Me.LblSubscriptions.TabIndex = 80

			Me.LblSubscriptions.Text = "Subscriptions"

			' 

			' LstBasicThemes

			' 

			Me.LstBasicThemes.Columns.AddRange(new System.Windows.Forms.ColumnHeader() { Me.ClmThemId,Me.ClmName})

			Me.LstBasicThemes.GridLines = true

			Me.LstBasicThemes.Location = new System.Drawing.Point(8, 40)

			Me.LstBasicThemes.Name = "LstBasicThemes"

			Me.LstBasicThemes.Size = new System.Drawing.Size(424, 104)

			Me.LstBasicThemes.TabIndex = 81

			Me.LstBasicThemes.View = System.Windows.Forms.View.Details

			' 

			' ClmThemId

			' 

			Me.ClmThemId.Text = "Theme Id"

			Me.ClmThemId.Width = 87

			' 

			' ClmName

			' 

			Me.ClmName.Text = "Name"

			Me.ClmName.Width = 313

			' 

			' LstAdvancedThemes

			' 

			Me.LstAdvancedThemes.Columns.AddRange(new System.Windows.Forms.ColumnHeader() {Me.ClmThemIdA,Me.ClmNameA})

			Me.LstAdvancedThemes.GridLines = true

			Me.LstAdvancedThemes.Location = new System.Drawing.Point(8, 176)

			Me.LstAdvancedThemes.Name = "LstAdvancedThemes"

			Me.LstAdvancedThemes.Size = new System.Drawing.Size(424, 104)

			Me.LstAdvancedThemes.TabIndex = 82

			Me.LstAdvancedThemes.View = System.Windows.Forms.View.Details

			' 

			' LstLogos

			' 

			Me.LstLogos.Columns.AddRange(new System.Windows.Forms.ColumnHeader() {Me.ClmLogoId, Me.ClmLogoName})

			Me.LstLogos.GridLines = true

			Me.LstLogos.Location = new System.Drawing.Point(8, 312)

			Me.LstLogos.Name = "LstLogos"

			Me.LstLogos.Size = new System.Drawing.Size(424, 104)

			Me.LstLogos.TabIndex = 83

			Me.LstLogos.View = System.Windows.Forms.View.Details

			' 

			' ClmLogoId

			' 

			Me.ClmLogoId.Text = "Logo Id"

			Me.ClmLogoId.Width = 91

			' 

			' LstSubscriptions

			' 

        Me.LstSubscriptions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClmLevel, Me.ClmFee})

			Me.LstSubscriptions.GridLines = true

			Me.LstSubscriptions.Location = new System.Drawing.Point(8, 448)

			Me.LstSubscriptions.Name = "LstSubscriptions"

			Me.LstSubscriptions.Size = new System.Drawing.Size(424, 104)

			Me.LstSubscriptions.TabIndex = 84

			Me.LstSubscriptions.View = System.Windows.Forms.View.Details

			' 

			' ClmLevel

			' 

			Me.ClmLevel.Text = "Level"

			Me.ClmLevel.Width = 134

			' 

			' ClmFee

			' 

			Me.ClmFee.Text = "Fee"

			Me.ClmFee.Width = 270

			' 

			' ClmThemIdA

			' 

			Me.ClmThemIdA.Text = "Theme Id"

			Me.ClmThemIdA.Width = 89

			' 

			' ClmNameA

			' 

			Me.ClmNameA.Text = "Name"

			Me.ClmNameA.Width = 312

			' 

			' ClmLogoName

			' 

			Me.ClmLogoName.Text = "Name"

			Me.ClmLogoName.Width = 312

			' 

			' FrmGetStoreOptions

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(456, 629)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.BtnGetStoreOptions)

			Me.Name = "FrmGetStoreOptions"

			Me.Text = "GetStoreOptions"

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)
   End Sub

#End Region


    Public Context As ApiContext

    Private Sub BtnGetStoreOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetStoreOptions.Click

        Try

            LstBasicThemes.Items.Clear()

            LstAdvancedThemes.Items.Clear()

            LstLogos.Items.Clear()

            LstSubscriptions.Items.Clear()


            Dim apicall As GetStoreOptionsCall = New GetStoreOptionsCall(Context)

            apicall.GetStoreOptions()

            Dim theme As StoreThemeType

            For Each theme In apicall.BasicThemeArray.Theme

                Dim listparams(2) As String

                listparams(0) = theme.ThemeID.ToString()

                listparams(1) = theme.Name

                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstBasicThemes.Items.Add(vi)

            Next theme

            For Each theme In apicall.AdvancedThemeArray.Theme

                Dim listparams(2) As String

                listparams(0) = theme.ThemeID.ToString()

                listparams(1) = theme.Name

                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstAdvancedThemes.Items.Add(vi)

            Next theme

            Dim logo As StoreLogoType
            For Each logo In apicall.LogoList
                Dim listparams(2) As String

                listparams(0) = logo.LogoID.ToString()
                listparams(1) = logo.Name

                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstLogos.Items.Add(vi)

            Next logo

            Dim subs As StoreSubscriptionType
            For Each subs In apicall.SubscriptionList
                Dim listparams(2) As String
                listparams(0) = subs.Level.ToString()
                listparams(1) = subs.Fee.Value.ToString()

                Dim vi As ListViewItem = New ListViewItem(listparams)

                LstSubscriptions.Items.Add(vi)
            Next subs


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class