Imports System
Imports System.Net
Imports System.Reflection
Imports System.Globalization
Imports System.Configuration.ConfigurationManager
Imports eBay.Service.Core.Soap
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Call
Imports eBay.Service.Util


Public Class SimpleListForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        FillCommandListBox()

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents OpenFileDialogIMG As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnConfigAccount As System.Windows.Forms.Button
    Friend WithEvents commandsListBox As System.Windows.Forms.ListBox
    Friend WithEvents runCommandButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SimpleListForm))
        Me.OpenFileDialogIMG = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnConfigAccount = New System.Windows.Forms.Button()
        Me.commandsListBox = New System.Windows.Forms.ListBox()
        Me.runCommandButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'OpenFileDialogIMG
        '
        Me.OpenFileDialogIMG.Filter = "JPEG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All Files|*.*"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(104, 352)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select an eBay API command"
        '
        'btnConfigAccount
        '
        Me.btnConfigAccount.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnConfigAccount.Location = New System.Drawing.Point(88, 8)
        Me.btnConfigAccount.Name = "btnConfigAccount"
        Me.btnConfigAccount.Size = New System.Drawing.Size(192, 28)
        Me.btnConfigAccount.TabIndex = 1
        Me.btnConfigAccount.Text = "Config API Account"
        '
        'commandsListBox
        '
        Me.commandsListBox.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.commandsListBox.Location = New System.Drawing.Point(24, 44)
        Me.commandsListBox.Name = "commandsListBox"
        Me.commandsListBox.Size = New System.Drawing.Size(328, 290)
        Me.commandsListBox.Sorted = True
        Me.commandsListBox.TabIndex = 0
        '
        'runCommandButton
        '
        Me.runCommandButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.runCommandButton.Location = New System.Drawing.Point(88, 376)
        Me.runCommandButton.Name = "runCommandButton"
        Me.runCommandButton.Size = New System.Drawing.Size(192, 28)
        Me.runCommandButton.TabIndex = 3
        Me.runCommandButton.Text = "Run an eBay API call"
        '
        'SimpleListForm
        '
        Me.AcceptButton = Me.runCommandButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(372, 413)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.runCommandButton, Me.commandsListBox, Me.Label1, Me.btnConfigAccount})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(200, 300)
        Me.Name = "SimpleListForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "eBay Soap SDK Sample - API Library Demo (VB.NET)"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Context As ApiContext

    Private Sub SimpleListForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Context = New ApiContext()
        Context.ApiCredential.ApiAccount.Developer = ""
        Context.ApiCredential.ApiAccount.Application = ""
        Context.ApiCredential.ApiAccount.Certificate = ""
        'Context.ApiCredential.eBayAccount.UserName = ""
        'Context.ApiCredential.eBayAccount.Password = ""
        Context.ApiCredential.eBayToken = ""
        Context.SoapApiServerUrl = ""
        Context.SignInUrl = ""
        Context.EPSServerUrl = ""
        Context.Version = ""
        Context.ApiLogManager = New ApiLogManager()
        Context.ApiLogManager.ApiLoggerList.Add(New FileLogger(AppSettings.Get("LogFileName"), True, True, True))
        Context.ApiLogManager.EnableLogging = True
        Context.Site = eBay.Service.Core.Soap.SiteCodeType.US
        Context.Timeout = Convert.ToInt32(AppSettings.Get("TimeOut"))

        If Not AppSettings.Get("DevName") Is Nothing Then
            Context.ApiCredential.ApiAccount.Developer = AppSettings.Get("DevName")
        End If

        If Not AppSettings.Get("AppName") Is Nothing Then
            Context.ApiCredential.ApiAccount.Application = AppSettings.Get("AppName")
        End If

        If Not AppSettings.Get("AppCert") Is Nothing Then
            Context.ApiCredential.ApiAccount.Certificate = AppSettings.Get("AppCert")
        End If

        If Not AppSettings.Get("eBayToken") Is Nothing Then
            Context.ApiCredential.eBayToken = AppSettings.Get("eBayToken")
        End If

        'If Not AppSettings.Get("UserName") Is Nothing Then
        '    Context.ApiCredential.eBayAccount.UserName = AppSettings.Get("UserName")
        'End If

        'If Not AppSettings.Get("UserPassword") Is Nothing Then
        '    Context.ApiCredential.eBayAccount.Password = AppSettings.Get("UserPassword")
        'End If

        If Not AppSettings.Get("SoapApiServerUrl") Is Nothing Then
            Context.SoapApiServerUrl = AppSettings.Get("SoapApiServerUrl")
        End If

        If Not AppSettings.Get("SignInUrl") Is Nothing Then
            Context.SignInUrl = AppSettings.Get("SignInUrl")
        End If

        If Not AppSettings.Get("EpsServerUrl") Is Nothing Then
            Context.EPSServerUrl = AppSettings.Get("EpsServerUrl")
        End If

        If Not AppSettings.Get("Version") Is Nothing Then
            Context.Version = AppSettings.Get("Version")
        End If

        If Not AppSettings.Get("RuName") Is Nothing Then
            Context.RuleName() = AppSettings.Get("RuName")
        End If

        'Set proxy server if necessary
        SetProxy()

    End Sub

    Private Sub SetProxy()
        Dim proxy As IWebProxy = Nothing
        Dim proxyHost As String = AppSettings.Get("Proxy.Host")
        Dim proxyPort As String = AppSettings.Get("Proxy.Port")
        If proxyHost.Length > 0 And proxyPort.Length > 0 Then
            proxy = New WebProxy(proxyHost, Integer.Parse(proxyPort))

            Dim username As String = AppSettings.Get("Proxy.Username")
            Dim password As String = AppSettings.Get("Proxy.Password")
            If username.Length > 0 And password.Length > 0 Then
                proxy.Credentials = New NetworkCredential(username, password)
            End If
        End If
        Context.WebProxy = proxy

    End Sub

    Private Sub btnConfigAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfigAccount.Click
        Dim formAcc As FormAccount = New FormAccount()
        formAcc.Context = Context
        If formAcc.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Context = formAcc.Context
        End If

    End Sub

    Private Sub FillCommandListBox()
        AddCommandToListBox("AddDispute", GetType(FormAddDispute))
        AddCommandToListBox("AddDisputeResponse", GetType(FormAddDisputeResponse))
        AddCommandToListBox("AddItem", GetType(FormAddItem))
        AddCommandToListBox("AddOrder", GetType(FormAddOrder))
        AddCommandToListBox("AddSecondChanceItem", GetType(FormAddsecondChanceItem))
        AddCommandToListBox("AddToItemDescription", GetType(FormAddToItemDesc))
        AddCommandToListBox("EndItem", GetType(FormEndItem))
        AddCommandToListBox("GetAccount", GetType(FormGetAccount))
        AddCommandToListBox("GetAllBidders", GetType(FormGetAllBidders))
        
        AddCommandToListBox("GetApiAccessRules", GetType(FormGetApiAccessRules))
        AddCommandToListBox("GetBestOffers", GetType(FormGetBestOffers))
        AddCommandToListBox("GetCategories", GetType(FormGetCategories))

        'AddCommandToListBox("GetCrossPromotions", GetType(FormGetCrossPromotions))
        AddCommandToListBox("GetDispute", GetType(FormGetDispute))
        AddCommandToListBox("GeteBayOfficialTime", GetType(FormGeteBayOfficialTime))
        AddCommandToListBox("GetFeedback", GetType(FormGetFeedback))
        'AddCommandToListBox("GetHighBidders", GetType(FormGetHighBidders))
        AddCommandToListBox("GetItem", GetType(FormGetItem))
        'AddCommandToListBox("GetItemRecommendations", GetType(FormGetItemRecommendations))
        AddCommandToListBox("GetItemShipping", GetType(FormGetItemShipping))
        AddCommandToListBox("GetItemTransactions", GetType(FormGetItemTransactions))
        AddCommandToListBox("GetMemberMessages", GetType(FormGetMemberMessages))
        AddCommandToListBox("GetNotificationPreferences", GetType(FormGetNotificationPreferences))
        AddCommandToListBox("GetOrders", GetType(FormGetOrders))
        'AddCommandToListBox("GetPromotionRules", GetType(FormGetPromotionRules))
        AddCommandToListBox("GetSellerEvents", GetType(FormGetSellerEvents))
        AddCommandToListBox("GetSellerList", GetType(FormGetSellerList))
        AddCommandToListBox("GetSellerTransactions", GetType(FormGetSellerTransactions))
        AddCommandToListBox("GetStore", GetType(FormGetStore))
        AddCommandToListBox("GetStoreCustomPage", GetType(FormGetStoreCustomPage))
        AddCommandToListBox("GetStoreOptions", GetType(FormGetStoreOptions))
        AddCommandToListBox("GetSuggestedCategories", GetType(FormGetSuggestedCategories))
        AddCommandToListBox("GetTokenStatus", GetType(FormGetTokenStatus))
        AddCommandToListBox("GetUser", GetType(FormGetUser))
        AddCommandToListBox("GetUserDisputes", GetType(FormGetUserDisputes))
        AddCommandToListBox("LeaveFeedback", GetType(FormLeaveFeedback))
        AddCommandToListBox("RelistItem", GetType(FormRelistItem))
        AddCommandToListBox("ReviseItem", GetType(FormReviseItem))
        AddCommandToListBox("ReviseCheckoutStatus", GetType(FormReviseCheckoutStatus))
        AddCommandToListBox("RespondToBestOffer", GetType(FormRespondToBestOffer))
        AddCommandToListBox("SendInvoice", GetType(FormSendInvoice))
        AddCommandToListBox("SellerReverseDispute", GetType(FormSellerReverseDispute))
        AddCommandToListBox("SetStore", GetType(FormSetStore))
        AddCommandToListBox("SetNotificationPreferences", GetType(FormSetNotificationPreferences))
        AddCommandToListBox("UploadPictures", GetType(FormUploadPictures))

        commandsListBox.SelectedIndex = 0
    End Sub

    Private Sub AddCommandToListBox(ByVal commandName As String, ByVal formType As Type)
        Me.commandsListBox.Items.Add(New CommandListBoxEntry(commandName, formType))
    End Sub



    Private Sub runCommandButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles runCommandButton.Click
        RunSelectedCommand()
    End Sub

    Private Sub RunSelectedCommand()
        Dim commandListBoxEntry As CommandListBoxEntry = _
            CType(Me.commandsListBox.SelectedItem, CommandListBoxEntry)
        Dim formType As Type = commandListBoxEntry.FormType

        Dim obj As [Object] = formType.InvokeMember(Nothing, BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.CreateInstance, Nothing, Nothing, Nothing)
        obj.Context = Context
        obj.ShowDialog()
        obj.Dispose()

    End Sub

    Private Sub commandsListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles commandsListBox.SelectedIndexChanged
        Dim lbe As CommandListBoxEntry = Me.commandsListBox.SelectedItem
        Me.runCommandButton.Text = "Run " + lbe.ToString()
    End Sub

    Private Sub commandsListBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles commandsListBox.DoubleClick
        RunSelectedCommand()
    End Sub
End Class

Public Class CommandListBoxEntry

    Public Sub New(ByVal name As String, ByVal formType As System.Type)
        Me.Name = name
        Me.FormType = formType
    End Sub

    Private Name As String = String.Empty
    Public FormType As System.Type = Nothing

    Public Overrides Function ToString() As String
        Return Me.Name
    End Function
End Class

