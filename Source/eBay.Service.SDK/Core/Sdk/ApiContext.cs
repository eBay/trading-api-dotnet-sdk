#region Copyright
/*
 * *
 *  * Copyright 2024 eBay Inc.
 *  *
 *  * Licensed under the Apache License, Version 2.0 (the "License");
 *  * you may not use this file except in compliance with the License.
 *  * You may obtain a copy of the License at
 *  *
 *  *  http://www.apache.org/licenses/LICENSE-2.0
 *  *
 *  * Unless required by applicable law or agreed to in writing, software
 *  * distributed under the License is distributed on an "AS IS" BASIS,
 *  * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  * See the License for the specific language governing permissions and
 *  * limitations under the License.
 *  *
 */
#endregion

#region Namespaces
using System;
using System.Net;
using System.Runtime.InteropServices;
using eBay.Service.Core.Soap;
#endregion

namespace eBay.Service.Core.Sdk
{
    /// <summary>
    /// Defines the API context in which the API call is invoked against the eBay API server. The API context
    /// object contains certain required data (<see cref="ApiCredential"/> and <see cref="SoapApiServerUrl"/>). 
    /// It also contains other optional but useful properties for logging (<see cref="ApiLogManager"/>), 
    /// call metrics (<see cref="CallMetricsTable"/>), call retry (<see cref="CallRetry"/>), and so forth.  
    /// ApiContext is a singleton that is created and set typically before the construction of the API call wrapper
    /// objects, with the API call wrappers using the context object in their constructors.
    /// </summary>

	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class ApiContext
	{

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ApiContext()
		{
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Used by the SDK to updates the last call time that an API call occured. You can 
        /// find the time of the last API call simply by calling <see cref="LastCallTime"/>
		/// </summary>
		/// <param name="eBayTime">The <see cref="AbstractResponseType.Timestamp"/>.</param>
		public void CallUpdate(DateTime eBayTime)
		{
			lock( this )
			{
				mTotalCalls++;
				if (eBayTime > DateTime.MinValue)
				{
					mLastCallTime = eBayTime;
				}
			}
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ApiLogManager of type <see cref="ApiLogManager"/> used in the current context.
        /// If setting this property, you need to first create the ApiLogManager object, then use its <see cref="eBay.Service.Core.Sdk.ApiLogManager.ApiLoggerList"/>
        /// property to add the loggers of type <see cref="eBay.Service.Util.ApiLogger"/> you wish to add. Typically, you would add
        /// a <see cref="eBay.Service.Util.FileLogger"/> object to write to a file log, but you could also use a <see cref="eBay.Service.Util.ConsoleLogger"/> or
        /// an <see cref="eBay.Service.Util.EventLogger"/> object.
        /// </summary>
        /// <example>
        /// This snippet shows how to add a file logger using the ApiLogManager class:
        /// <code>apiContext.ApiLogManager = new ApiLogManager();
        /// apiContext.ApiLogManager.ApiLoggerList.Add(new FileLogger("listing_log.txt", true, true, true));
        /// apiContext.ApiLogManager.EnableLogging = true;
        ///  </code>
        /// </example>
		
		public ApiLogManager ApiLogManager
		{ 
			get { return mLogger; }
			set { mLogger = value; }
		}
		
		/// <summary>
        /// This value must be set before making API calls.
		/// Gets or sets the credentials to use for making API calls of type <see cref="ApiCredential"/>. 
        /// You need to set the ApiCredential <see cref="eBay.Service.Core.Sdk.ApiCredential.eBayToken"/> property with a valid user token in order to make calls into
        /// eBay. 
		/// </summary>
		public ApiCredential ApiCredential
		{ 
			get { return mApiCredential; }
			set { mApiCredential = value; }
		}

		/// <summary>
		/// Gets or sets the URL to use for uploading pictures if you are using the eBay Picture Service. 
        /// Type <see cref="string"/>. If you use "self hosted images", you would not use this, but would
        /// instead supply your own host URL in the AddItemCall by setting PictureURL and or GalleryURL.
        /// For production site use the value "https://api.ebay.com/ws/api.dll"
        /// For sandbox, use the value "https://api.sandbox.ebay.com/ws/api.dll"
		/// </summary>
		public string EPSServerUrl
		{ 
			get { return mEPSServerUrl; }
			set { mEPSServerUrl = value; }
		}

		/// <summary>
		/// Gets or sets the language in which API errors will be returned.  Type <see cref="ErrorLanguageCodeType"/>.
        /// By default, the errors returned are in the language used at the site you are sending the API calls to.
        /// You can change this default and have the errors returned in the language you specify here.
		/// </summary>
		public ErrorLanguageCodeType ErrorLanguage
		{ 
			get { return mErrorLanguage; }
			set { mErrorLanguage = value; }
		}
		
		/// <summary>
		/// Gets the time that the last API Call was made. Type <see cref="DateTime"/>
		/// </summary>
		public DateTime LastCallTime
		{ 
			get { return mLastCallTime; }
		}

		/// <summary>
		/// Gets or sets the retry parameters of type <see cref="CallRetry"/>.
        /// When your application accesses the eBay platform using the SDK, errors can occur, such as network connection 
        /// errors, an eBay server that is busy and fails to respond to the call request quickly enough, or some failure 
        /// in the SDK layer itself. For many types of these failures, your application should retry the call using 
        /// CallRetry. To do this, instantiate an object of the <see cref="CallRetry"/> class and set the number of retries, 
        /// the errors for which you want to retry and the interval at which you want to retry.
		/// </summary>
		public CallRetry CallRetry
		{ 
			get { return mCallRetry; }
			set { mCallRetry = value; }
		}

		/// <summary>
        /// The RuName identifies your application to eBay when you send users to the user consent flow page
        /// when using the Authentication &amp; Authorization feature. (Developers generate RuNames in their
        /// eBay developer account.)
        /// Gets or sets the RuName.  Type <see cref="string"/>.
		/// </summary>
		public string RuName
		{ 
			get { return mRuName; }
			set { mRuName = value; }
		}	

		/// <summary>
        /// Gets or sets the URL where the user is directed to sign in during the Authentication &amp; Authorization flow, as described in
        /// the Trading API Guide explanation of
        ///<see href="http://developer.ebay.com/DevZone/XML/docs/WebHelp/GettingTokens-Getting_Tokens_for_Applications_with_Multiple_Users.html"> sign-in URL.</see>
		///  type <see cref="string"/>.
		/// </summary>
		public string SignInUrl
		{ 
			get { return mSignInUrl; }
			set { mSignInUrl = value; }
		}

		/// <summary>
        /// This value must be set before making API calls.
		/// Gets or sets the site to use when making API Calls. Type <see cref="SiteCodeType"/>.
        /// Used to specify the site you are invoking the API calls against. Features vary by site and
        /// so does validation. To determine which API call features are available for the site you wish
        /// to use, refer to the Trading API <see href="http://www.developer.ebay.com/DevZone/XML/docs/Reference/eBay/index.html">Call Reference.</see>
		/// </summary>
		public SiteCodeType Site
		{ 
			get { return mSite; }
			set { mSite = value; }
		}

		/// <summary>
		/// Gets or sets the the number of milliseconds to wait before the API call times out. Type <see cref="int"/>.
		/// </summary>
		public int Timeout
		{ 
			get { return mTimeout; }
			set { mTimeout = value; }
		}

		/// <summary>
        /// Gets the total number of API calls that have been made with the current ApiContext
        /// object. Each time an API call is successfully made within the lifespan of the current
        /// ApiContext object, TotalCalls is incremented.
		/// Type <see cref="int"/>.
		/// </summary>
		public int TotalCalls
		{ 
			get { return mTotalCalls; }
		}
		/// <summary>
        /// This value must be set before making any API calls.
        /// Gets or sets the URL of the eBay API server to which you send the API calls.
        /// For Sandbox use: "https://api.sandbox.ebay.com/wsapi"
        /// For production use "https://api.ebay.com/wsapi"
		/// Type <see cref="string"/>.
		/// </summary>
		public string SoapApiServerUrl
		{ 
			get { return mSoapApiServerUrl; }
			set { mSoapApiServerUrl = value; }
		}

		/// <summary>
		/// Gets or sets the url to use when making XML API calls of type <see cref="string"/>.
		/// </summary>
		public string XmlApiServerUrl
		{ 
			get { return mXmlApiServerUrl; }
			set { mXmlApiServerUrl = value; }
		}

		/// <summary>
        /// Gets and sets version of the Trading API WSDL to be used. Type <see cref="string"/>.
        /// The Version refers to the WSDL version you want to use to make the API call; note that
        /// fields and features in the API call might or might not be available depending on the WSDL version
        /// you are using. For details, refer to the Trading API 
        /// <see href="http://www.developer.ebay.com/DevZone/XML/docs/Reference/eBay/index.html">Call Reference.</see>
		/// By default, the version is set to the version of the SDK currently being used. You can override this using this
        /// property. However, if you want to use a newer version than is supported by your SDK, you may need to do additional work. 
        /// For details, see the .NET SDK Getting Started guide.
		/// </summary>
		public string Version
		{ 
			get { return mVersion; }
			set { mVersion= value; }
		}

		/// <summary>
		/// If set to <b>true</b>, enables collection of data about total call latency, network latency, and server-side latency.
        /// All API calls will be tracked if you use this. 
		/// </summary>
		public bool EnableMetrics
		{ 
			get { return mEnableMetrics; }
			set { mEnableMetrics= value; }
		}
		/// <summary>
		/// Holds a reference to a master table of call metrics for any API call made during the current session.  
        /// There is normally one such table across an entire application
        /// (including multiple thread instances). To use call metrics only on a single call, use the CallMetricsEntry 
        /// property on the API call wrapper object. Notice that you need to log the call metrics data, as described in the 
        /// .NET SDK Getting Started guide.
		/// </summary>
		public CallMetricsTable CallMetricsTable
		{ 
			get { return mCallMetricsTable; }
			set { mCallMetricsTable= value; }
		}

        /// <summary>
        /// Set this if you accesss eBay API server behind a proxy server
        /// </summary>
        public IWebProxy WebProxy
        {
            get { return mWebProxy; }
            set { mWebProxy = value; }
        }

		/// <summary>
		/// holds the rulename to use when fetching token.
		/// </summary>
		public string RuleName
		{
			get { return ruleName; }
			set { ruleName = value; }
		}
		#endregion

		#region Private Fields
		private ApiCredential mApiCredential = new ApiCredential();
		private ErrorLanguageCodeType mErrorLanguage = ErrorLanguageCodeType.CustomCode;
		private string mEPSServerUrl;
		private DateTime mLastCallTime;
		private ApiLogManager mLogger = null;
		private CallRetry mCallRetry = null;
		private string mRuName = "";
		private string mSignInUrl;
		private SiteCodeType mSite = SiteCodeType.CustomCode;
		private int mTimeout = 60000;
		private int mTotalCalls = 0;
		private string mVersion= "1131";
		private string mSoapApiServerUrl;
		private string mXmlApiServerUrl;
		private bool mEnableMetrics;
		private CallMetricsTable mCallMetricsTable;
        private IWebProxy mWebProxy = null;
		private string ruleName;
		#endregion

	}
}
