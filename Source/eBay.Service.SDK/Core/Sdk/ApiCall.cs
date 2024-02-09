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
using System.Reflection;
using System.Collections;
using System.Web.Services.Protocols;
using System.Runtime.InteropServices;
using eBay.Service.Call;
using eBay.Service.Util;
using eBay.Service.Core.Soap;

#endregion

namespace eBay.Service.Core.Sdk
{

    /// <summary>
    /// Base class for all <see cref="eBay.Service.Call"/> API call classes, such as AddItemCall, GetOrderCall, GeteBayDetailsCall, and so forth. 
    /// Each API call object requires an ApiContext object, which is used to contain the context information needed to communicate with eBay, 
    /// such as the URL, user token, and so forth. Other useful ApiCall properties and objects include Site, which you use to specify the eBay
    /// site you are using, CallRetry, which you use for retrying failed calls, and CallMetricsEntry, which you can use during development and
    /// testing to determine call performance.
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class ApiCall
    {

        private Type mServiceType = typeof(eBayAPIInterfaceService2);

        #region Constructors
        /// <summary>
        /// Constructor. If you use this constructor, you must subsequently set the context for this object by creating and setting properties
        /// in an <see cref="ApiContext"/> object, then set that object in the ApiCall object so it has the required context data.
        /// </summary>
        public ApiCall()
        {
        }

        /// <summary>
        /// Constructor. Use this constructor to set the ApiContext object in the new ApiCall object.
        /// </summary>
        /// <param name="ApiContext">The <see cref="ApiContext"/> for this API Call. This object properties must be set to the ebay URL 
        /// used for the Trading API, the user token, and the eBay site.</param>
        public ApiCall(ApiContext ApiContext)
        {
            this.ApiContext = ApiContext;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Sends the Request and returns the Response.
        /// In most cases, you would use the <see cref="Execute"/> method to send the call request to eBay. The
        /// ExecuteRequest method is only used if you need to directly use the actual SOAP request object 
        /// that underlies the ApiCall object to make the call (and use the actual underlying SOAP response 
        /// object to receive the response). For more information, see 
        /// <see href="http://ebay.custhelp.com/cgi-bin/ebay.cfg/php/enduser/std_adp.php?p_faqid=616" />
        /// What is the difference between Execute and ExecuteRequest.
        /// </summary>
        /// <param name="Request">The <see cref="AbstractRequestType"/>.</param>
        /// <returns>The <see cref="AbstractResponseType"/>.</returns>
        public AbstractResponseType ExecuteRequest(AbstractRequestType Request)
        {
            AbstractRequest = Request;
            SendRequest();
            return AbstractResponse;
        }
        /// <summary>
        /// Sends the Api call request <see cref="AbstractRequest"/> to eBay. 
        /// </summary>
        /// <returns>Returns the response appropriate to
        /// the specific API call that is being Executed.</returns>
        public virtual void Execute()
        {
            SendRequest();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Constructs a security header from values in <see cref="ApiContext"/>.
        /// </summary>
        /// <returns>Security information of type <see cref="CustomSecurityHeaderType"/>.</returns>
        protected virtual CustomSecurityHeaderType GetSecurityHeader()
        {
            CustomSecurityHeaderType sechdr = new CustomSecurityHeaderType();

            //Check for oAuth 
            if (ApiContext.ApiCredential.oAuthToken != null && ApiContext.ApiCredential.oAuthToken.Length > 0)
            {
                if (ApiContext.ApiCredential.eBayToken != null && ApiContext.ApiCredential.eBayToken.Length > 0)
                {
                    sechdr.eBayAuthToken = ApiContext.ApiCredential.eBayToken;
                }

                //else
                //{                    
                //    sechdr.oAuthToken = ApiContext.ApiCredential.oAuthToken;
                //}
            }
            else if (ApiContext.ApiCredential.eBayToken != null && ApiContext.ApiCredential.eBayToken.Length > 0)
            {
                sechdr.eBayAuthToken = ApiContext.ApiCredential.eBayToken;
            }


            return (sechdr);
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SendRequest()
        {
            try
            {
                if (AbstractRequest == null)
                    throw new ApiException("RequestType reference not set to an instance of an object.", new System.ArgumentNullException());
                if (ApiContext == null)
                    throw new ApiException("ApiContext reference not set to an instance of an object.", new System.ArgumentNullException());
                if (ApiContext.ApiCredential == null)
                    throw new ApiException("Credentials reference in ApiContext object not set to an instance of an object.", new System.ArgumentNullException());

                string apiName = AbstractRequest.GetType().Name.Replace("RequestType", "");

                if (this.ApiContext.EnableMetrics)
                {
                    mCallMetrics = this.ApiContext.CallMetricsTable.GetNewEntry(apiName);
                    mCallMetrics.ApiCallStarted = System.DateTime.Now;
                }

                CustomSecurityHeaderType secHdr = this.GetSecurityHeader();

                // Get default constructor.
                /*
                ConstructorInfo svcCCTor = this.mServiceType.GetConstructor(
                    BindingFlags.Instance | BindingFlags.Public, null,
                    CallingConventions.HasThis, null, null);
                    */
                ConstructorInfo svcCCTor = this.mServiceType.GetConstructor(new Type[] { });

                object svcInst = svcCCTor.Invoke(null);

                PropertyInfo pi;

                pi = this.mServiceType.GetProperty("ApiLogManager");
                if (pi == null)
                    throw new SdkException("ApiLogManager was not found in InterfaceServiceType");
                pi.SetValue(svcInst, this.mApiContext.ApiLogManager, null);

                pi = this.mServiceType.GetProperty("EnableComression");
                if (pi == null)
                    throw new SdkException("EnableComression was not found in InterfaceServiceType");
                pi.SetValue(svcInst, this.mEnableCompression, null);

                //Add oAuth 
                //if (pi == null)
                //    throw new SdkException("RequesterCredentials was not found in InterfaceServiceType");
                //pi.SetValue(svcInst, this., null);
                if (string.IsNullOrEmpty(this.ApiContext.ApiCredential.oAuthToken))
                {
                    pi = this.mServiceType.GetProperty("RequesterCredentials");
                    if (pi == null)
                        throw new SdkException("RequesterCredentials was not found in InterfaceServiceType");
                    pi.SetValue(svcInst, secHdr, null);
                }

                pi = this.mServiceType.GetProperty("WebProxy");
                if (pi == null)
                    throw new SdkException("WebProxy was not found in InterfaceServiceType");
                pi.SetValue(svcInst, this.mApiContext.WebProxy, null);
                if (this.mApiContext.WebProxy != null)
                {
                    LogMessage("Proxy Server is Set", MessageType.Information, MessageSeverity.Informational);
                }

                pi = this.mServiceType.GetProperty("CallMetricsEntry");
                if (pi == null)
                    throw new SdkException("CallMetricsEntry was not found in InterfaceServiceType");
                if (this.ApiContext.EnableMetrics)
                    pi.SetValue(svcInst, this.mCallMetrics, null);
                else
                    pi.SetValue(svcInst, null, null);

                pi = this.mServiceType.GetProperty("OAuthToken");
                if (!string.IsNullOrEmpty(this.ApiContext.ApiCredential.oAuthToken))
                {
                    this.mOAuth = this.ApiContext.ApiCredential.oAuthToken;
                    pi.SetValue(svcInst, this.OAuth, null);
                }

                string url = "";
                try
                {
                    if (ApiContext.SoapApiServerUrl != null && ApiContext.SoapApiServerUrl.Length > 0)
                        url = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}?callname={1}&siteid={2}&client=netsoap",
                            ApiContext.SoapApiServerUrl, apiName, SiteUtility.GetSiteID(Site).ToString(System.Globalization.CultureInfo.InvariantCulture));
                    else
                    {
                        url = (string)this.mServiceType.GetProperty("Url").GetValue(svcInst, null);
                        url = String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}?callname={1}&siteid={2}&client=netsoap",
                            url, apiName, SiteUtility.GetSiteID(Site).ToString(System.Globalization.CultureInfo.InvariantCulture));
                    }

                    //svcCCTor.Url = url;
                    this.mServiceType.GetProperty("Url").SetValue(svcInst, url, null);
                }
                catch (Exception ex)
                {
                    throw new ApiException(ex.Message, ex);
                }

                LogMessage(url, MessageType.Information, MessageSeverity.Informational);

                //svcCCTor.Timeout = Timeout;
                this.mServiceType.GetProperty("Timeout").SetValue(svcInst, Timeout, null);

                AbstractRequest.Version = Version;

                if (!mDetailLevelOverride && AbstractRequest.DetailLevel == null)
                {
                    AbstractRequest.DetailLevel = new DetailLevelCodeTypeCollection();
                    AbstractRequest.DetailLevel.AddRange(mDetailLevelList);
                }

                //Added OutputSelector to base call JIRA-SDK-561
                AbstractRequest.OutputSelector = new StringCollection();
                AbstractRequest.OutputSelector.AddRange(mOutputSelector);

                if (ApiContext.ErrorLanguage != ErrorLanguageCodeType.CustomCode)
                    AbstractRequest.ErrorLanguage = ApiContext.ErrorLanguage.ToString();

                //Populate the message
                AbstractRequest.MessageID = System.Guid.NewGuid().ToString();

                Type methodtype = svcInst.GetType();
                object[] reqparm = new object[] { AbstractRequest };

                int retries = 0;
                int maxRetries = 0;
                bool doretry = false;
                CallRetry retry = null;
                if (mCallRetry != null)
                {
                    retry = mCallRetry;
                    maxRetries = retry.MaximumRetries;
                }
                else if (ApiContext.CallRetry != null)
                {
                    retry = ApiContext.CallRetry;
                    maxRetries = retry.MaximumRetries;
                }


                do
                {
                    Exception callException = null;
                    try
                    {
                        mResponse = null;
                        mApiException = null;

                        if (retries > 0)
                        {
                            LogMessage("Invoking Call Retry", MessageType.Information, MessageSeverity.Informational);
                            System.Threading.Thread.Sleep(retry.DelayTime);
                        }

                        if (BeforeRequest != null)
                            BeforeRequest(this, new BeforeRequestEventArgs(AbstractRequest));


                        //Invoke the Service
                        DateTime start = DateTime.Now;
                        mResponse = (AbstractResponseType)methodtype.GetMethod(apiName).Invoke(svcInst, reqparm);
                        mResponseTime = DateTime.Now - start;

                        if (AfterRequest != null)
                            AfterRequest(this, new AfterRequestEventArgs(mResponse));

                        // Catch Token Expiration warning
                        if (mResponse != null && secHdr.HardExpirationWarning != null)
                        {
                            ApiContext.ApiCredential.TokenHardExpirationWarning(
                                System.Convert.ToDateTime(secHdr.HardExpirationWarning, System.Globalization.CultureInfo.CurrentUICulture));
                        }


                        if (mResponse != null && mResponse.Errors != null && mResponse.Errors.Count > 0)
                        {
                            throw new ApiException(new ErrorTypeCollection(mResponse.Errors));
                        }
                    }

                    catch (Exception ex)
                    {
                        // this catches soap faults 
                        if (ex.GetType() == typeof(TargetInvocationException))
                        {
                            // we never care about the outer exception
                            Exception iex = ex.InnerException;

                            // Parse Soap Faults
                            if (iex.GetType() == typeof(SoapException))
                            {
                                ex = ApiException.FromSoapException((SoapException)iex);
                            }
                            else if (iex.GetType() == typeof(InvalidOperationException))
                            {
                                // Go to innermost exception
                                while (iex.InnerException != null)
                                    iex = iex.InnerException;
                                ex = new ApiException(iex.Message, iex);
                            }
                            else if (iex.GetType() == typeof(HttpException))
                            {
                                HttpException httpEx = (HttpException)iex;
                                String str = "HTTP Error Code: " + httpEx.StatusCode;
                                ex = new ApiException(str, iex);
                            }
                            else
                            {
                                ex = new ApiException(iex.Message, iex);
                            }
                        }
                        callException = ex;

                        // log the message - override current switches - *if* (a) we wouldn't normally log it, and (b) 
                        // the exception matches the exception filter.

                        if (retry != null)
                            doretry = retry.ShouldRetry(ex);

                        if (!doretry || retries == maxRetries)
                        {
                            throw ex;
                        }
                        else
                        {
                            string soapReq = (string)this.mServiceType.GetProperty("SoapRequest").GetValue(svcInst, null);
                            string soapResp = (string)this.mServiceType.GetProperty("SoapResponse").GetValue(svcInst, null);

                            LogMessagePayload(soapReq + "\r\n\r\n" + soapResp, MessageSeverity.Informational, ex);
                            MessageSeverity svr = ((ApiException)ex).SeverityErrorCount > 0 ? MessageSeverity.Error : MessageSeverity.Warning;
                            LogMessage(ex.Message, MessageType.Exception, svr);
                        }
                    }

                    finally
                    {
                        string soapReq = (string)this.mServiceType.GetProperty("SoapRequest").GetValue(svcInst, null);
                        string soapResp = (string)this.mServiceType.GetProperty("SoapResponse").GetValue(svcInst, null);

                        if (!doretry || retries == maxRetries)
                            LogMessagePayload(soapReq + "\r\n\r\n" + soapResp, MessageSeverity.Informational, callException);

                        if (mResponse != null && mResponse.TimestampSpecified)
                            ApiContext.CallUpdate(mResponse.Timestamp);
                        else
                            ApiContext.CallUpdate(new DateTime(0));

                        mSoapRequest = soapReq;
                        mSoapResponse = soapResp;
                        retries++;
                    }

                } while (doretry && retries <= maxRetries);
            }

            catch (Exception ex)
            {
                ApiException aex = ex as ApiException;

                if (aex != null)
                {
                    mApiException = aex;
                }
                else
                {
                    mApiException = new ApiException(ex.Message, ex);
                }
                MessageSeverity svr = mApiException.SeverityErrorCount > 0 ? MessageSeverity.Error : MessageSeverity.Warning;
                LogMessage(mApiException.Message, MessageType.Exception, svr);

                if (mApiException.SeverityErrorCount > 0)
                    throw mApiException;

            }
            finally
            {
                if (this.ApiContext.EnableMetrics)
                    mCallMetrics.ApiCallEnded = DateTime.Now;
            }
        }

        /// <summary>
        /// Log the message information under the specified type and severity.
        /// </summary>
        /// <param name="Message">The content to log of type <see cref="string"/>.</param>
        /// <param name="Type">The type of message to log of type <see cref="MessageType"/>.</param>
        /// <param name="Severity">The severity of the message of type <see cref="MessageSeverity"/>/</param>
        protected internal void LogMessage(string Message, MessageType Type, MessageSeverity Severity)
        {
            if (Message == null || ApiContext == null || ApiContext.ApiLogManager == null || ApiContext.ApiLogManager.ApiLoggerList == null || ApiContext.ApiLogManager.ApiLoggerList.Count == 0)
                return;

            if (Type == MessageType.ApiMessage)
            {
                Message = MaskPrivateInfo(Message);
            }

            ApiContext.ApiLogManager.RecordMessage(Message, Type, Severity);

        }

        /// <summary>
        /// Log the message information under the specified type and severity, in the context of an exception - used for exception-based
        /// payload logging.
        /// Message type is always assumed to be ApiMessage.
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Severity"></param>
        /// <param name="Ex"></param>
        protected internal void LogMessagePayload(string Message, MessageSeverity Severity, Exception Ex)
        {
            if (Message == null || ApiContext == null || ApiContext.ApiLogManager == null || ApiContext.ApiLogManager.ApiLoggerList == null || ApiContext.ApiLogManager.ApiLoggerList.Count == 0)
                return;

            Message = MaskPrivateInfo(Message);

            ApiContext.ApiLogManager.RecordPayloadOnException(Message, MessageType.ApiMessage, Severity, Ex);
        }

        private string MaskPrivateInfo(string Message)
        {
            Message = System.Text.RegularExpressions.Regex.Replace(Message, "<AuthCert>.+</AuthCert>", "<AuthCert>******</AuthCert>");
            Message = System.Text.RegularExpressions.Regex.Replace(Message, "<Password>.+</Password>", "<Password>******</Password>");
            Message = System.Text.RegularExpressions.Regex.Replace(Message, "<eBayAuthToken>.+</eBayAuthToken>", "<eBayAuthToken>******</eBayAuthToken>");

            return Message;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Reserved for eBay internal use. The type to be used to create the Web Service service instance. 
        /// </summary>
        public Type InterfaceServiceType
        {
            get { return this.mServiceType; }
            set { this.mServiceType = value; }
        }

        /// <summary>
        /// Returns the ApiException object that is created if an error occured during the API call request to the eBay API server. 
        /// (If there was no error, this returns null.) The ApiException object is used for exceptions 
        /// from the API call wrapper layer, which means it is API payload data-related. For example, you could get one of 
        /// these exceptions if you supplied an invalid category ID in an AddItem call. In this case, the server returns a response 
        /// indicating an error with an error severity of ‘Failure’,  wrapped by the SDK as an ApiException object. 
        /// </summary>
        public ApiException ApiException
        {
            get { return (ApiException)mApiException; }
        }

        /// <summary>
        /// Indicates whether the API call resulted in an ApiException indicating that an error occured. If an
        /// error occurred, use the ApiException property to get the ApiException object and examine the error.  
        /// </summary>
        /// <returns>Returns <b>true</b> if the API call resulted in an ApiException.
        /// Returns <b>false</b> if there was no error. </returns>
        ///
        public bool HasError
        {
            get { return (mApiException != null && mApiException.SeverityErrorCount > 0); }
        }

        /// <summary>
        /// An API call can result in a request sent successfully to the eBay API server, but yet contain an API warning in the response about some 
        /// non critical issue. (You can use the ApiException property to examine the warning.) 
        /// </summary>
        /// <returns>Returns <b>true</b> after an API call if the response contained one or more warnings. 
        /// Returns <b>false</b> if there are no warnings.
        /// </returns>
        public bool HasWarning
        {
            get { return (mApiException != null && mApiException.SeverityWarningCount > 0); }
        }

        /// <summary>
        /// Gets or sets the <see cref="ApiContext"/> of the API call object. The API call object must be set with an 
        /// ApiContext object containing valid URL, user token, site data, and other optional properties, such as logging
        /// and call metrics.
        /// </summary>
        public ApiContext ApiContext
        {
            get { return mApiContext; }
            set { mApiContext = value; }
        }

        /// <summary>
        /// Gets or sets the Request of the call of type <see cref="AbstractRequestType"/>. 
        /// The AbstractRequest is the abstract base class for all API call requests. 
        /// </summary>
        public AbstractRequestType AbstractRequest
        {
            get { return mRequest; }
            set { mRequest = value; }
        }

        /// <summary>
        /// Gets the Response of the call of type <see cref="AbstractResponseType"/>. 
        /// The AbstractResponse is the abstract base class for all API call responses. 
        /// </summary>
        public AbstractResponseType AbstractResponse
        {
            get { return mResponse; }
        }

        /// <summary>
        /// Gets or sets call retry of type <see cref="CallRetry"/>. 
        /// The optional CallRetry object controls the behavior of failure-retry.
        /// Notice that call retry can be set in the ApiContext object to apply to all API calls, 
        /// or it can be set in the API call wrapper object instead. The CallRetry object used by
        /// the API call wrapper overrides the CallRetry set in ApiContext.
        /// </summary>
        public CallRetry CallRetry
        {
            get { return mCallRetry; }
            set { mCallRetry = value; }
        }


        /// <summary>
        /// Gets or sets the <see cref="AbstractRequestType.DetailLevel"/> of type <see cref="DetailLevelCodeTypeCollection"/>. 
        /// The DetailLevel is used in some API calls that query eBay, for example, GetUserCall. The detail level specifies which
        /// data is to be returned in the query. For information on which detail levels are supported for a particular API call, 
        /// refer to the eBay Trading API Call Reference
        /// <see href="http://www.developer.ebay.com/DevZone/XML/docs/Reference/eBay/index.html" />
        /// </summary>



        public DetailLevelCodeTypeCollection DetailLevelList
        {
            get { return mDetailLevelList; }
            set { mDetailLevelList = value; }
        }

        /// <summary>
        /// Prevents <see cref="DetailLevelList"/> from being sent if set to <b>true</b>.
        /// </summary>
        /// <remarks>This property is set to <b>true</b> for <see cref="GetCategoriesCall.GetCategoriesVersion"/>.</remarks>
        protected internal bool DetailLevelOverride
        {
            get { return mDetailLevelOverride; }
            set { mDetailLevelOverride = value; }
        }

        /// <summary>
        /// Gets or sets the Timeout value for the HTTP connection used in the API call. 
        /// Time is expressed in milliseconds.
        /// </summary>
        /// <remarks>This property allows you to override the value set in <see cref="ApiContext"/></remarks>
        public int Timeout
        {
            get { return (mTimeout == Int32.MinValue) ? ApiContext.Timeout : mTimeout; }
            set { mTimeout = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="AbstractRequestType.Version"/> for the API call. This specifies which 
        /// Trading API WSDL version is to be used for the call.
        /// </summary>
        /// <remarks>This property allows you to override the value set in <see cref="ApiContext"/></remarks>
        public string Version
        {
            get { return (mVersion == null || mVersion.Length == 0) ? ApiContext.Version : mVersion; }
            set { mVersion = value; }
        }

        public string OAuth
        {
            get { return (mOAuth == null || mOAuth.Length == 0) ? ApiContext.Version : mOAuth; }
            set { mOAuth = value; }
        }

        /// <summary>
        /// Gets or sets the eBay site (<see cref="SiteCodeType"/>)to be used in the API call. The site is 
        /// important because the different sites support different API features, so data validation and returned
        /// data can be affected by the site value specified.
        /// </summary>
        /// <remarks>This property allows you to override the value set in <see cref="ApiContext"/></remarks>
        public SiteCodeType Site
        {
            get { return (mSite == SiteCodeType.CustomCode) ? ApiContext.Site : mSite; }
            set { mSite = value; }
        }

        /// <summary>
        /// Gets the time the API Call took to respond of type <see cref="TimeSpan"/>
        /// </summary>
        public TimeSpan ResponseTime
        {
            get { return mResponseTime; }
        }

        /// <summary>
        /// Gets the last raw web service request of type <see cref="string"/>
        /// </summary>
        public string SoapRequest
        {
            get { return MaskPrivateInfo(mSoapRequest); }
        }

        /// <summary>
        /// Gets the last raw web service response of type <see cref="string"/>
        /// </summary>
        public string SoapResponse
        {
            get { return MaskPrivateInfo(mSoapResponse); }
        }

        /// <summary>
        /// Set to true to ask the server to compress the response data to reduce the transfer size.
        /// By default HTTP compression is enabled to improve the performance.
        /// </summary>
        public bool EnableCompression
        {
            get
            {
                return this.mEnableCompression;
            }
            set
            {
                this.mEnableCompression = value;
            }
        }

        /// <summary>
        /// Holds the call metrics object used to optionally track client and server side latencies.
        /// </summary>
        public CallMetricsEntry CallMetricsEntry
        {
            get
            {
                return this.mCallMetrics;
            }
            set
            {
                this.mCallMetrics = value;
            }
        }

        /// <summary>
        /// OutputSelector to filter the response
        /// </summary>
        public string[] OutputSelector
        {
            get
            {
                return this.mOutputSelector;
            }
            set
            {
                this.mOutputSelector = value;
            }

        }
        #endregion

        #region Private Fields
        private bool mEnableCompression = true;
        private AbstractRequestType mRequest;
        private AbstractResponseType mResponse;
        private CallMetricsEntry mCallMetrics = new CallMetricsEntry();
        private ApiContext mApiContext = new ApiContext();
        private bool mDetailLevelOverride = false;
        private ApiException mApiException;
        private CallRetry mCallRetry;
        private int mTimeout = Int32.MinValue;
        private string mVersion;
        private TimeSpan mResponseTime;
        private SiteCodeType mSite = SiteCodeType.CustomCode;
        private DetailLevelCodeTypeCollection mDetailLevelList = new DetailLevelCodeTypeCollection();
        private string mSoapRequest;
        private string mSoapResponse;
        private string mOAuth;
        private string[] mOutputSelector = new string[0];
        #endregion

        #region Public Events
        /// <summary>
        /// Occurs before the API call is sent.
        /// </summary>
        public event BeforeRequestEventHandler BeforeRequest;

        /// <summary>
        /// Occurs after the API call returns the response.
        /// </summary>
        public event AfterRequestEventHandler AfterRequest;
        #endregion
    }

    #region BeforeRequestEventArgs
    /// <summary>
    /// 
    /// </summary>
    [ComVisible(false)]
    public class BeforeRequestEventArgs : EventArgs
    {

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AbstractRequest">The <see cref="AbstractRequest"/> for this API Call.</param>
        public BeforeRequestEventArgs(AbstractRequestType AbstractRequest)
        {
            mRequest = AbstractRequest;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Request for this API call of type <see cref="AbstractRequestType"/>.
        /// </summary>
        public AbstractRequestType AbstractRequest
        {
            get { return mRequest; }
            set { mRequest = value; }
        }
        #endregion

        #region Private Fields
        private AbstractRequestType mRequest;
        #endregion

    }
    #endregion

    #region AfterRequestEventArgs
    /// <summary>
    /// 
    /// </summary>
    [ComVisible(false)]
    public class AfterRequestEventArgs : EventArgs
    {

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AbstractResponse">The <see cref="AbstractResponse"/> for this API Call.</param>
        public AfterRequestEventArgs(AbstractResponseType AbstractResponse)
        {
            mResponse = AbstractResponse;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the Response for this API call of type <see cref="AbstractResponseType"/>.
        /// </summary>
        public AbstractResponseType AbstractResponse
        {
            get { return mResponse; }
        }
        #endregion

        #region Private Fields
        private AbstractResponseType mResponse;
        #endregion

    }
    #endregion

    #region Public Delegates
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="BeforeRequestEventArgs"/> containing the event data.</param>
    [ComVisible(false)]
    public delegate void BeforeRequestEventHandler(object sender, BeforeRequestEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="AfterRequestEventArgs"/> containing the event data.</param>
    [ComVisible(false)]
    public delegate void AfterRequestEventHandler(object sender, AfterRequestEventArgs e);
    #endregion

}
