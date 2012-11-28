//
//  MobageNDK.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/10/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

/**
 * This file is here to import every public header in the NDK, as per described in Apple's Documentation:
 * - Code Naming Basics Header Files: https://developer.apple.com/library/mac/#documentation/Cocoa/Conceptual/CodingGuidelines/Articles/NamingBasics.html%23//apple_ref/doc/uid/20001281-1002806
 */

#ifndef mobage_ndk_MobageNDK_h
#define mobage_ndk_MobageNDK_h

#pragma mark - Header Files that import a collection of other headers

#import "AllBank.h"
#import "AllBlacklist.h"
#import "AllModels.h"
#import "AllPeople.h"
#import "AllProfanity.h"
#import "AllUI.h"
#import "AllAnalytics.h"
#import "AllRemoteNotification.h"
#import "AllFacebookInterface.h"

#pragma mark - API Header Files

#import "MBMobage.h"
#import "MBError.h"
#import "Auth.h"
#import "Reward.h"

// deprecated
#import "MBPagingAPIOptions.h"
#import "MBPagingAPIResult.h"

#pragma mark - Specific Globally Exposed Classes

#import "MBMobageUI.h"

#pragma mark - Exposed Infrastructure Imported from Plus+
#import "NGUIKitUtils.h"

#endif
