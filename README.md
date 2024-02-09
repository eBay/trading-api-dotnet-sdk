# Trading API .NET SDK  

[Support](https://developer.ebay.com/support)     [Knowledge Base](https://developer.ebay.com/support/knowledge-base)

## Introduction

Please note that upgrades to an SDK should always be done in a test environment. Additionally, before using a version of the SDK, please read this Readme file. Please also read the [Trading API Release Notes](https://developer.ebay.com/DevZone/XML/docs/ReleaseNotes.html) (which contain tables showing schema changes that occur every two weeks) for all Trading API versions released after your current version.

## Release Information for the eBay SDK for .NET

**Important:** Changes to the Trading API affect the SDK. For example, in schema version latest, deprecated objects in the schema were deleted, creating backward incompatibility. Please see the [Trading API Release Notes](https://developer.ebay.com/DevZone/XML/docs/ReleaseNotes.html) for ongoing updates to the schema (including occasional removals of schema elements). Please also see [Versioning Strategy](https://developer.ebay.com/DevZone/XML/docs/HowTo/eBayWS/eBaySchemaVersioning.html) and [Deprecated Objects](https://developer.ebay.com/DevZone/XML/docs/Reference/ebay/deprObjects.html).

## SDK Version Latest Release

With Latest release, the .NET Trading API SDK supports OAuth for authentication. eBay uses the OAuth 2.0 protocol only for authorizing the eBay Buy and Sell RESTful APIs. Now, OAuth can be used with the Trading API, as well. With the Trading API, all calls use the authorization code grant type, meaning users must go through the sign-in flow to grant permission to the application to make calls on their behalf. Please refer to the [Handling Authorization in Your Applications](http://developer.ebay.com/DevZone/javasdk-jaxb/docs/GettingStarted/GettingStarted.html#AuthAndAuth) section in the SDK Getting Started topic for more information.

### Using OAuth with the SDK

eBay uses the OAuth 2.0 protocol for authorizing the eBay Buy and Sell RESTful APIs. eBay’s OAuth implementation can also be used with the Trading API. With the Trading API, all calls use the authorization code grant type, meaning users must go through the sign-in flow to grant permission to the application to make calls on their behalf. For details about using authorization code grant type to retrieve access tokens, see [Getting User Tokens](https://developer.ebay.com/api-docs/static/oauth-user-token.html) in the Using eBay RESTful APIs guide. For the Trading API, we recommend that you use the <https://api.ebay.com/oauth/api_scope/sell.account> scope.

When you are able to retrieve oauth user access tokens, you simply pass your oauth token to the ApiContext object and the SDK does the rest.

### New ConsoleGetItemUsingOAuth using OAuth User Access Token

ConsoleGetItemUsingOAuth sample has been added illustrating the usage of OAuth User Access Token instead of Auth&Auth Token to access eBay Trading API Server as below

- ApiContext apiContext = new ApiContext();
- ApiCredential cred = apiContext.getApiCredential();
- cred.oAuthToken = "YourOAuthToken";

Important: eBay will be adding scopes for use with the Trading API specifically. When new scopes are available, your application must be ready to implement them. Users will be required to sign-in and go through the permission grant flow when the new scopes are implemented. This release is compatible with eBay's latest Trading WSDL.

Please refer to the [Trading API Release Notes](https://developer.ebay.com/Devzone/XML/docs/ReleaseNotes.html) for a detailed list of the new elements and features.

---

This release includes:

- The core libraries built in VS2022.
- The code generator for VS2022 can generate eBay Trading Web Service proxy (both in command line and in VS2022 IDE).
- The core libraries can be built in VS2022, including the corresponding solution file.
- All samples/unit tests have been built/run in VS2022.

---

© 2024 eBay Inc. All rights reserved.  
eBay and the eBay logo are registered trademarks of eBay Inc.  
All other brands are the property of their respective owners.
