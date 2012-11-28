//
//  MBUser.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/10/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

#import "MBDataModel.h"
#import "MBDataList.h"

/**
 * @file MBUser.h
 * Model for Mobage user information.
 * @since 1.5
 */

/**
 * Stores properties for a Mobage user.
 * @since 1.5
 */
@protocol MBUser <MBDataModel>

+ (NSObject<MBUser>*) currentUser;
+ (void)fetchUserWithUserID:(NSString*) userId callbackQueue:(dispatch_queue_t)cbQueue block:(void (^)(NSError *err, NSObject<MBUser> * user))cb;
+ (void)fetchUserWithNickname:(NSString*) nickname callbackQueue:(dispatch_queue_t)cbQueue block:(void (^)(NSError *err, NSObject<MBUser> * user))cb;

- (BOOL)isEqualToUser:(NSObject<MBUser>*)object;

/**
 * The user's nickname.
 * @since 1.5
 */
@property (nonatomic, readonly, strong) NSString * nickname; //username
/**
 * The name displayed for the user.
 * @since 1.5
 */
@property (nonatomic, readonly, strong) NSString * displayName;
/**
 * The URL for the user's thumbnail image.
 * @since 1.5
 */
@property (nonatomic, readonly, strong) NSString * thumbnailUrl;
/**
 * The profile for the user
 * @since 1.5
 */
@property (nonatomic, readonly, strong) NSString * aboutMe;

/**
 * Set to <code>YES</code> if the user has used the current app.
 * @since 1.5
 */
@property (nonatomic, readonly, assign) BOOL hasApp;
// legacy field
@property (nonatomic, readonly, assign) BOOL ageRestricted;
/**
 * The user's age.
 * @since 1.5
 */
@property (nonatomic, readonly, assign) NSInteger age;

@property (nonatomic, readonly, strong) NSObject<MBDataList> * mutualFriends;
@property (nonatomic, readonly, strong) NSObject<MBDataList> * mutualFriendsWithCurrentGame;
@property (nonatomic, readonly, strong) NSObject<MBDataList> * pendingFriendRequests;
@property (nonatomic, readonly, strong) NSObject<MBDataList> * blacklistedUsers;

// In Place Mutation!
- (void)updateFromServerWithCallbackQueue:(dispatch_queue_t)cbQueue block:(void (^)(NSError *err, NSObject<MBUser> * user))block;

// *note* For Internal use. Temporary placing here because of codegen limitation.
// need to move into MB_WW_User+Internal.h.
// currently only motto, firstName, lastName, password, email are supported
- (void) saveWithCallbackQueue:(dispatch_queue_t)cbQueue
                    onComplete:(void (^)(NSObject<MBError> *error, 
                                         NSObject<MBUser> * user))completeCb;

@end

typedef NSObject<MBUser> MBUserProtocol;
