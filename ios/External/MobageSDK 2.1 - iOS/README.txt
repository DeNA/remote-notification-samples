================================================================================
Copyright 2012, DeNA Co., Ltd. All rights reserved
Proprietary and Confidential
Do Not Redistribute
================================================================================

Mobage Native SDK for iOS 2.1
================================================================================
    Getting Started
    Upgrading from Earlier Versions
    Dependencies
    Known Issues
    Device/Simulator Support
    Changelog
    Support Requests
    Licenses


Getting Started
================================================================================
To get started with the Native SDK, please refer to the Programming Guide,
included in this package as a PDF. In addition, please note the dependencies
that are listed below.

IMPORTANT: Mobage is responsible for publishing all Mobage apps on the App
Store. Do not use your own App Store account to publish your Mobage app.


Upgrading from Earlier Versions
================================================================================
If you are upgrading from Native SDK 1.5 or later, be sure to read UPGRADE.txt
for detailed information about how to upgrade.


Dependencies
================================================================================
The Mobage Native SDK has the following dependencies.

Extra Linker Flags
------------------
Your build configuration must include the following linker flags:

    -ObjC
    -lstdc++

Frameworks
----------
Your app must incorporate the following additional frameworks:

    - CoreGraphics.framework
    - CoreTelephony.framework
    - Foundation.framework
    - libsqlite3.dylib
    - MessageUI.framework
    - QuartzCore.framework
    - Security.framework
    - StoreKit.framework
    - SystemConfiguration.framework
    - Twitter.framework
    - UIKit.framework


Known Issues
================================================================================
- Mobage apps that are built with the Native SDK must not use the iOS keychain.
  All Mobage apps share a single keystore and have access to the keystore's
  data.
- The MBPeople protocol includes two methods, getFriendsForUser: and
  getFriendsWithGameForUser:, that use 0 as the start index for search results.
  In contrast, other Native SDK APIs use 1 as the start index for search
  results.


Device/Simulator Support
================================================================================
The Native SDK for iOS supports iOS 5 and later. You can use the Native SDK on
iOS devices as well as the iOS simulator.

NOTE: As of version 2.1 of the Native SDK, iOS 4.3.3 is no longer supported.


Changelog
================================================================================

2.1 (November 2012)
--------------------------------------------------------------------------------
Added support for iPhone 5, iOS 6, and Xcode 4.5. iOS 4.3.3 is no longer
supported. In addition, you must use Xcode 4.5 or later.

NOTE: If you are using the Mobage Install Tracking Framework, you must upgrade
to version 2.1 or later. Earlier versions of the Install Tracking Framework are
not compatible with Native SDK 2.1.

Updated the documentation to address several minor issues.

Made numerous improvements to overall stability and performance.


2.0.2 (October 2012)
--------------------------------------------------------------------------------
Addressed a critical issue with Analytics event reporting, and improved the
performance of event reporting.

Improved the performance of the Bank APIs.


2.0.1 (October 2012)
--------------------------------------------------------------------------------
Users are no longer permitted to close the login dialog.

The Balance Button now displays the correct icon for your app-specific purchased
currency.

Made numerous improvements to stability and performance.


2.0.0.2 (September 2012)
--------------------------------------------------------------------------------
Removes unnecessary log messages.


2.0.0.1 (September 2012)
--------------------------------------------------------------------------------
Fixes a critical issue with error handling during the login process.


2.0 (September 2012)
--------------------------------------------------------------------------------
All Native SDK apps are now required to display the Mobage Community Button. See
the Programming Guide for detailed instructions.

Users can now use a Facebook account to log into Mobage. This feature does not
require any changes to your app, except for the standard upgrade procedure that
is described above.

You can now send remote notifications using the new MBRemoteNotification
protocol.

You can now create and update leaderboards for your app using the new
MBGameLeaderboard protocol.

Many APIs have been deprecated and replaced by new versions, which use a simpler
format for callbacks. The deprecated APIs continue to be supported, and apps are
not required to migrate to the new APIs at this time. If you need documentation
for the deprecated APIs, please consult the API documentation for version 1.5
of the Native SDK.


Support Requests
================================================================================
Please submit all support requests through the Mobage Developer Support website:
https://developer.mobage.com/


Licenses
================================================================================
This product includes the following third-party software:

Facebook iOS SDK (https://github.com/facebook/facebook-ios-sdk)
--------------------------------------------------------------------------------
Copyright (c) 2010 Facebook, Inc.
Licensed under the Apache License, Version 2.0 (the "License"); you may not use
this file except in compliance with the License.
You may obtain a copy of the License at:
http://www.apache.org/licenses/LICENSE-2.0
Additionally, an electronic copy of the License is included with this SDK.

SMWebRequest (https://github.com/nfarina/webrequest)
--------------------------------------------------------------------------------
Copyright (c) 2010 Nick Farina
This code is licensed under the MIT License.  The license is reproduced below:

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

jQuery (https://github.com/jquery/jquery)
--------------------------------------------------------------------------------
Copyright 2012 jQuery Foundation and other contributors.

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
