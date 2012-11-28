//
//  RemoteNotificationPayload.h
//  mobage-ndk
//
//  Created by Toliver Chris on 7/23/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_RemoteNotificationPayload_h
#define mobage_ndk_RemoteNotificationPayload_h

#import "MBRemoteNotificationPayload.h"
#import "RegionSpecifics.h"

#if MB_WW
#import "MB_WW_RemoteNotificationPayload.h"
#define RegionSpecificRemoteNotificationPayload MB_WW_RemoteNotificationPayload
#elif MB_JP
#import "MB_JP_RemoteNotificationPayload.h"
#define RegionSpecificRemoteNotificationPayload MB_JP_RemoteNotificationPayload
#else
#error "Invalid Configuration"
#endif

@interface MBRemoteNotificationPayload : RegionSpecificRemoteNotificationPayload
@end

#if defined(RegionSpecificRemoteNotificationPayload)
#undef RegionSpecificRemoteNotificationPayload
#endif

#endif
