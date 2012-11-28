//
//  RemoteNotification.h
//  mobage-ndk
//
//  Created by Eric So on 4/27/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_RemoteNotification_h
#define mobage_ndk_RemoteNotification_h

#include "RegionSpecifics.h"

#import "MBRemoteNotification.h"

#if MB_WW
#import "MB_WW_RemoteNotification.h"
#define RegionSpecificNotification MB_WW_RemoteNotification
#elif MB_JP
#import "MB_JP_RemoteNotification.h"
#define RegionSpecificNotification MB_JP_RemoteNotification
#else
#error "Unknown or No Region Specified."
#endif

@interface MBRemoteNotification : RegionSpecificNotification
@end
#undef RegionSpecificNotification

#endif
