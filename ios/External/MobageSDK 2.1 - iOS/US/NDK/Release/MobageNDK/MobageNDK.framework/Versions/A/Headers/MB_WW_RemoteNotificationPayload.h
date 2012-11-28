//
//  MB_WW_RemoteNotificationPayload.h
//  NGMobageUS
//
//  Created by Toliver Chris on 7/24/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MB_WW_DataModel.h"
#import "MBRemoteNotificationPayload.h"

@protocol MB_WW_RemoteNotificationPayload <MBRemoteNotificationPayload>
@property (atomic, readonly, assign) NSInteger badge;
@property (atomic, readonly, strong) NSString *message;
@property (atomic, readonly, strong) NSString *sound;
@property (atomic, readonly, strong) NSString *collapseKey;
@property (atomic, readonly, strong) NSString *style;
@property (atomic, readonly, strong) NSString *iconUrl;
@property (atomic, readonly, strong) NSArray *extraKeys;
@property (atomic, readonly, strong) NSArray *extraValues;
@end

@interface MB_WW_RemoteNotificationPayload : MB_WW_DataModel<MB_WW_RemoteNotificationPayload>
@end