Imports System
Imports System.Globalization
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util



Public Class FormGetUser
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

		Friend WithEvents LblUserIdRet As System.Windows.Forms.Label

		Friend WithEvents TxtUserId As System.Windows.Forms.TextBox 

		Friend WithEvents BtnGetUser As System.Windows.Forms.Button 

		Friend WithEvents LblUserId As System.Windows.Forms.Label 

		Friend WithEvents GrpResult As System.Windows.Forms.GroupBox 

		Friend WithEvents TxtStar As System.Windows.Forms.TextBox 

		Friend WithEvents LblStar As System.Windows.Forms.Label 

		Friend WithEvents TxtStoreUrl As System.Windows.Forms.TextBox 

		Friend WithEvents LblStoreUrl As System.Windows.Forms.Label 

		Friend WithEvents TxtSite As System.Windows.Forms.TextBox 

		Friend WithEvents LblSite As System.Windows.Forms.Label 

		Friend WithEvents TxtRegDate As System.Windows.Forms.TextBox 

		Friend WithEvents TxtEmail As System.Windows.Forms.TextBox 

		Friend WithEvents TxtFeedBackScore As System.Windows.Forms.TextBox 

		Friend WithEvents TxtSellerLevel As System.Windows.Forms.TextBox 

		Friend WithEvents LblEmail As System.Windows.Forms.Label 

		Friend WithEvents LblRegDate As System.Windows.Forms.Label 

		Friend WithEvents LblFeedBackScore As System.Windows.Forms.Label 

		Friend WithEvents LblSellerLevel As System.Windows.Forms.Label 

		Friend WithEvents TxtItemId As System.Windows.Forms.TextBox 

		Friend WithEvents LblItemId As System.Windows.Forms.Label 

		Friend WithEvents TxtUserIdRet As System.Windows.Forms.TextBox 

		Friend WithEvents LblVerified As System.Windows.Forms.Label 

		Friend WithEvents TxtVerified As System.Windows.Forms.TextBox 

		Friend WithEvents TxtChanged As System.Windows.Forms.TextBox 

		Friend WithEvents LblLastChanged As System.Windows.Forms.Label 

		Friend WithEvents TxtNew As System.Windows.Forms.TextBox 

		Friend WithEvents LblNew As System.Windows.Forms.Label 




		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		

			Me.TxtUserId = new System.Windows.Forms.TextBox()

			Me.BtnGetUser = new System.Windows.Forms.Button()

			Me.LblUserId = new System.Windows.Forms.Label()

			Me.GrpResult = new System.Windows.Forms.GroupBox()

			Me.TxtNew = new System.Windows.Forms.TextBox()

			Me.LblNew = new System.Windows.Forms.Label()

			Me.TxtChanged = new System.Windows.Forms.TextBox()

			Me.LblLastChanged = new System.Windows.Forms.Label()

			Me.TxtVerified = new System.Windows.Forms.TextBox()

			Me.LblVerified = new System.Windows.Forms.Label()

			Me.TxtUserIdRet = new System.Windows.Forms.TextBox()

			Me.LblUserIdRet = new System.Windows.Forms.Label()

			Me.TxtStar = new System.Windows.Forms.TextBox()

			Me.LblStar = new System.Windows.Forms.Label()

			Me.TxtStoreUrl = new System.Windows.Forms.TextBox()

			Me.LblStoreUrl = new System.Windows.Forms.Label()

			Me.TxtSite = new System.Windows.Forms.TextBox()

			Me.LblSite = new System.Windows.Forms.Label()

			Me.TxtRegDate = new System.Windows.Forms.TextBox()

			Me.TxtEmail = new System.Windows.Forms.TextBox()

			Me.TxtFeedBackScore = new System.Windows.Forms.TextBox()

			Me.TxtSellerLevel = new System.Windows.Forms.TextBox()

			Me.LblEmail = new System.Windows.Forms.Label()

			Me.LblRegDate = new System.Windows.Forms.Label()

			Me.LblFeedBackScore = new System.Windows.Forms.Label()

			Me.LblSellerLevel = new System.Windows.Forms.Label()

			Me.TxtItemId = new System.Windows.Forms.TextBox()

			Me.LblItemId = new System.Windows.Forms.Label()

			Me.GrpResult.SuspendLayout()

			Me.SuspendLayout()

			' 

			' TxtUserId

			' 

			Me.TxtUserId.Location = new System.Drawing.Point(96, 16)

			Me.TxtUserId.Name = "TxtUserId"

			Me.TxtUserId.Size = new System.Drawing.Size(80, 20)

			Me.TxtUserId.TabIndex = 22

			Me.TxtUserId.Text = ""

			' 

			' BtnGetUser

			' 

			Me.BtnGetUser.Location = new System.Drawing.Point(136, 48)

			Me.BtnGetUser.Name = "BtnGetUser"

			Me.BtnGetUser.Size = new System.Drawing.Size(120, 23)

			Me.BtnGetUser.TabIndex = 23

			Me.BtnGetUser.Text = "GetUser"

        'Me.BtnGetUser.Click += new System.EventHandler(Me.BtnGetUser_Click)

			' 

			' LblUserId

			' 

			Me.LblUserId.Location = new System.Drawing.Point(32, 16)

			Me.LblUserId.Name = "LblUserId"

			Me.LblUserId.Size = new System.Drawing.Size(64, 23)

			Me.LblUserId.TabIndex = 24

			Me.LblUserId.Text = "User Id:"

			' 

			' GrpResult

			' 

			Me.GrpResult.Controls.Add(Me.TxtNew)

			Me.GrpResult.Controls.Add(Me.LblNew)

			Me.GrpResult.Controls.Add(Me.TxtChanged)

			Me.GrpResult.Controls.Add(Me.LblLastChanged)

			Me.GrpResult.Controls.Add(Me.TxtVerified)

			Me.GrpResult.Controls.Add(Me.LblVerified)

			Me.GrpResult.Controls.Add(Me.TxtUserIdRet)

			Me.GrpResult.Controls.Add(Me.LblUserIdRet)

			Me.GrpResult.Controls.Add(Me.TxtStar)

			Me.GrpResult.Controls.Add(Me.LblStar)

			Me.GrpResult.Controls.Add(Me.TxtStoreUrl)

			Me.GrpResult.Controls.Add(Me.LblStoreUrl)

			Me.GrpResult.Controls.Add(Me.TxtSite)

			Me.GrpResult.Controls.Add(Me.LblSite)

			Me.GrpResult.Controls.Add(Me.TxtRegDate)

			Me.GrpResult.Controls.Add(Me.TxtEmail)

			Me.GrpResult.Controls.Add(Me.TxtFeedBackScore)

			Me.GrpResult.Controls.Add(Me.TxtSellerLevel)

			Me.GrpResult.Controls.Add(Me.LblEmail)

			Me.GrpResult.Controls.Add(Me.LblRegDate)

			Me.GrpResult.Controls.Add(Me.LblFeedBackScore)

			Me.GrpResult.Controls.Add(Me.LblSellerLevel)

			Me.GrpResult.Location = new System.Drawing.Point(8, 80)

			Me.GrpResult.Name = "GrpResult"

			Me.GrpResult.Size = new System.Drawing.Size(408, 208)

			Me.GrpResult.TabIndex = 25

			Me.GrpResult.TabStop = false

			Me.GrpResult.Text = "Result"

			' 

			' TxtNew

			' 

			Me.TxtNew.Location = new System.Drawing.Point(328, 80)

			Me.TxtNew.Name = "TxtNew"

			Me.TxtNew.ReadOnly = true

			Me.TxtNew.Size = new System.Drawing.Size(72, 20)

			Me.TxtNew.TabIndex = 60

			Me.TxtNew.Text = ""

			' 

			' LblNew

			' 

			Me.LblNew.Location = new System.Drawing.Point(216, 80)

			Me.LblNew.Name = "LblNew"

			Me.LblNew.Size = new System.Drawing.Size(112, 23)

			Me.LblNew.TabIndex = 59

			Me.LblNew.Text = "New User:"

			' 

			' TxtChanged

			' 

			Me.TxtChanged.Location = new System.Drawing.Point(128, 176)

			Me.TxtChanged.Name = "TxtChanged"

			Me.TxtChanged.ReadOnly = true

			Me.TxtChanged.Size = new System.Drawing.Size(136, 20)

			Me.TxtChanged.TabIndex = 57

			Me.TxtChanged.Text = ""

			' 

			' LblLastChanged

			' 

			Me.LblLastChanged.Location = new System.Drawing.Point(16, 176)

			Me.LblLastChanged.Name = "LblLastChanged"

			Me.LblLastChanged.Size = new System.Drawing.Size(112, 23)

			Me.LblLastChanged.TabIndex = 58

			Me.LblLastChanged.Text = "User Id Changed:"

			' 

			' TxtVerified

			' 

			Me.TxtVerified.Location = new System.Drawing.Point(328, 104)

			Me.TxtVerified.Name = "TxtVerified"

			Me.TxtVerified.ReadOnly = true

			Me.TxtVerified.Size = new System.Drawing.Size(72, 20)

			Me.TxtVerified.TabIndex = 56

			Me.TxtVerified.Text = ""

			' 

			' LblVerified

			' 

			Me.LblVerified.Location = new System.Drawing.Point(216, 104)

			Me.LblVerified.Name = "LblVerified"

			Me.LblVerified.Size = new System.Drawing.Size(112, 23)

			Me.LblVerified.TabIndex = 55

			Me.LblVerified.Text = "Verified:"

			' 

			' TxtUserIdRet

			' 

			Me.TxtUserIdRet.Location = new System.Drawing.Point(128, 32)

			Me.TxtUserIdRet.Name = "TxtUserIdRet"

			Me.TxtUserIdRet.ReadOnly = true

			Me.TxtUserIdRet.Size = new System.Drawing.Size(72, 20)

			Me.TxtUserIdRet.TabIndex = 54

			Me.TxtUserIdRet.Text = ""

			' 

			' LblUserIdRet

			' 

			Me.LblUserIdRet.Location = new System.Drawing.Point(16, 32)

			Me.LblUserIdRet.Name = "LblUserIdRet"

			Me.LblUserIdRet.Size = new System.Drawing.Size(112, 23)

			Me.LblUserIdRet.TabIndex = 53

			Me.LblUserIdRet.Text = "User Id:"

			' 

			' TxtStar

			' 

			Me.TxtStar.Location = new System.Drawing.Point(128, 104)

			Me.TxtStar.Name = "TxtStar"

			Me.TxtStar.ReadOnly = true

			Me.TxtStar.Size = new System.Drawing.Size(72, 20)

			Me.TxtStar.TabIndex = 51

			Me.TxtStar.Text = ""

			' 

			' LblStar

			' 

			Me.LblStar.Location = new System.Drawing.Point(16, 104)

			Me.LblStar.Name = "LblStar"

			Me.LblStar.Size = new System.Drawing.Size(112, 23)

			Me.LblStar.TabIndex = 52

			Me.LblStar.Text = "Star:"

			' 

			' TxtStoreUrl

			' 

			Me.TxtStoreUrl.Location = new System.Drawing.Point(128, 128)

			Me.TxtStoreUrl.Name = "TxtStoreUrl"

			Me.TxtStoreUrl.ReadOnly = true

			Me.TxtStoreUrl.Size = new System.Drawing.Size(272, 20)

			Me.TxtStoreUrl.TabIndex = 49

			Me.TxtStoreUrl.Text = ""

			' 

			' LblStoreUrl

			' 

			Me.LblStoreUrl.Location = new System.Drawing.Point(16, 128)

			Me.LblStoreUrl.Name = "LblStoreUrl"

			Me.LblStoreUrl.Size = new System.Drawing.Size(112, 23)

			Me.LblStoreUrl.TabIndex = 50

			Me.LblStoreUrl.Text = "Store Url:"

			' 

			' TxtSite

			' 

			Me.TxtSite.Location = new System.Drawing.Point(328, 56)

			Me.TxtSite.Name = "TxtSite"

			Me.TxtSite.ReadOnly = true

			Me.TxtSite.Size = new System.Drawing.Size(72, 20)

			Me.TxtSite.TabIndex = 47

			Me.TxtSite.Text = ""

			' 

			' LblSite

			' 

			Me.LblSite.Location = new System.Drawing.Point(216, 56)

			Me.LblSite.Name = "LblSite"

			Me.LblSite.Size = new System.Drawing.Size(112, 23)

			Me.LblSite.TabIndex = 48

			Me.LblSite.Text = "Site:"

			' 

			' TxtRegDate

			' 

			Me.TxtRegDate.Location = new System.Drawing.Point(128, 152)

			Me.TxtRegDate.Name = "TxtRegDate"

			Me.TxtRegDate.ReadOnly = true

			Me.TxtRegDate.Size = new System.Drawing.Size(136, 20)

			Me.TxtRegDate.TabIndex = 45

			Me.TxtRegDate.Text = ""

			' 

			' TxtEmail

			' 

			Me.TxtEmail.Location = new System.Drawing.Point(128, 56)

			Me.TxtEmail.Name = "TxtEmail"

			Me.TxtEmail.ReadOnly = true

			Me.TxtEmail.Size = new System.Drawing.Size(72, 20)

			Me.TxtEmail.TabIndex = 40

			Me.TxtEmail.Text = ""

			' 

			' TxtFeedBackScore

			' 

			Me.TxtFeedBackScore.Location = new System.Drawing.Point(128, 80)

			Me.TxtFeedBackScore.Name = "TxtFeedBackScore"

			Me.TxtFeedBackScore.ReadOnly = true

			Me.TxtFeedBackScore.Size = new System.Drawing.Size(72, 20)

			Me.TxtFeedBackScore.TabIndex = 39

			Me.TxtFeedBackScore.Text = ""

			' 

			' TxtSellerLevel

			' 

			Me.TxtSellerLevel.Location = new System.Drawing.Point(328, 32)

			Me.TxtSellerLevel.Name = "TxtSellerLevel"

			Me.TxtSellerLevel.ReadOnly = true

			Me.TxtSellerLevel.Size = new System.Drawing.Size(72, 20)

			Me.TxtSellerLevel.TabIndex = 41

			Me.TxtSellerLevel.Text = ""

			' 

			' LblEmail

			' 

			Me.LblEmail.Location = new System.Drawing.Point(16, 56)

			Me.LblEmail.Name = "LblEmail"

			Me.LblEmail.Size = new System.Drawing.Size(112, 23)

			Me.LblEmail.TabIndex = 43

			Me.LblEmail.Text = "Email:"

			' 

			' LblRegDate

			' 

			Me.LblRegDate.Location = new System.Drawing.Point(16, 152)

			Me.LblRegDate.Name = "LblRegDate"

			Me.LblRegDate.Size = new System.Drawing.Size(112, 23)

			Me.LblRegDate.TabIndex = 46

			Me.LblRegDate.Text = "Registration Date:"

			' 

			' LblFeedBackScore

			' 

			Me.LblFeedBackScore.Location = new System.Drawing.Point(16, 80)

			Me.LblFeedBackScore.Name = "LblFeedBackScore"

			Me.LblFeedBackScore.Size = new System.Drawing.Size(112, 23)

			Me.LblFeedBackScore.TabIndex = 44

			Me.LblFeedBackScore.Text = "Feedback Score:"

			' 

			' LblSellerLevel

			' 

			Me.LblSellerLevel.Location = new System.Drawing.Point(216, 32)

			Me.LblSellerLevel.Name = "LblSellerLevel"

			Me.LblSellerLevel.Size = new System.Drawing.Size(112, 23)

			Me.LblSellerLevel.TabIndex = 42

			Me.LblSellerLevel.Text = "Seller Level:"

			' 

			' TxtItemId

			' 

			Me.TxtItemId.Location = new System.Drawing.Point(256, 16)

			Me.TxtItemId.Name = "TxtItemId"

			Me.TxtItemId.Size = new System.Drawing.Size(80, 20)

			Me.TxtItemId.TabIndex = 26

			Me.TxtItemId.Text = ""

			' 

			' LblItemId

			' 

			Me.LblItemId.Location = new System.Drawing.Point(192, 16)

			Me.LblItemId.Name = "LblItemId"

			Me.LblItemId.Size = new System.Drawing.Size(64, 23)

			Me.LblItemId.TabIndex = 27

			Me.LblItemId.Text = "Item Id:"

			' 

			' FrmGetUser

			' 

			Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)

			Me.ClientSize = new System.Drawing.Size(424, 293)

			Me.Controls.Add(Me.TxtItemId)

			Me.Controls.Add(Me.LblItemId)

			Me.Controls.Add(Me.GrpResult)

			Me.Controls.Add(Me.TxtUserId)

			Me.Controls.Add(Me.BtnGetUser)

			Me.Controls.Add(Me.LblUserId)

			Me.Name = "FrmGetUser"

			Me.Text = "GetUser"

			Me.GrpResult.ResumeLayout(false)

			Me.ResumeLayout(false)



    End Sub

#End Region


    Public Context As ApiContext

		Private Sub  BtnGetUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetUser.Click

		

			Try

            TxtUserIdRet.Text = ""

				TxtEmail.Text = ""

				TxtFeedBackScore.Text = ""

				TxtRegDate.Text = ""

				TxtSellerLevel.Text = ""

				TxtSite.Text = ""

				TxtStar.Text = ""

				TxtStoreUrl.Text = ""

				TxtNew.Text = ""

				TxtVerified.Text = ""

				TxtChanged.Text = ""



            Dim ApiCall As GetUserCall = New GetUserCall(Context)

            If TxtUserId.Text.Length > 0 Then
                ApiCall.UserID = TxtUserId.Text
            End If
            If TxtItemId.Text.Length > 0 Then
                ApiCall.ItemID = TxtItemId.Text
            End If



            Dim user As UserType = ApiCall.GetUser()



            TxtUserIdRet.Text = user.UserID

            TxtEmail.Text = user.Email

            TxtFeedBackScore.Text = user.FeedbackScore.ToString()

            TxtRegDate.Text = user.RegistrationDate.ToString()

            TxtSellerLevel.Text = user.SellerInfo.SellerLevel.ToString()

            TxtSite.Text = user.Site.ToString()

            TxtStar.Text = user.FeedbackRatingStar.ToString()

            TxtStoreUrl.Text = user.SellerInfo.StoreURL

            TxtNew.Text = user.NewUser.ToString()

            TxtVerified.Text = user.IDVerified.ToString()

            TxtChanged.Text = user.UserIDLastChanged.ToString()

        Catch ex As Exception
           
            MsgBox(ex.Message)

        End Try

    End Sub


End Class