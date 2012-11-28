//
//  MB_WW_SocialService.h
//  NGMobageUS
//
//  Created by Henrik Johansson on 3/16/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBSocialService.h"

@protocol MB_WW_SocialService <MBSocialService>

+ (void)showToast:(NSString*)displayText;

+ (void)openCurrentUserProfile;
+ (void)openOtherUserProfileWithUser:(NSObject<MBUser> *)user;
+ (void)openCurrentUserSettings;
+ (void)openOtherUserSettingsWithUser:(NSObject<MBUser> *)user;
@end

@interface MB_WW_SocialService : NSObject <MB_WW_SocialService>

+ (void) getDeviceContactsWithCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(NSObject<MBError> *error, NSDictionary *result))completeCb;

/** TODO JWilliams (whole comment blob out of date)
 * @abstract Open the Player Inviter, which enables the user to invite friends via viral channels.
 * @discussion Open the Player Inviter
 * @param 
 * @cb onComplete
 * @cb-param MBCancelableAPIStatus status
 * @since 2.0
 */
+ (void)openPlayerInviterWithCallbackQueue:(dispatch_queue_t)cbQueue
                                onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError> *error))completeCb;

+ (void)openOSViralChannel;

@end

extern NSString *const kMB_G_BalanceBtnUpdatedNotification;