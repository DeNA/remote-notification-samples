//
//  MB_WW_FacebookInterface+Internal.h
//  NGMobageUS
//
//  Created by Maxwell Robinson on 6/18/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MB_WW_FacebookInterface.h"
#import <Foundation/Foundation.h>
#import "MBError.h"

@protocol MB_WW_FacebookInterfaceInternal <MB_WW_FacebookInterface>

// Mobage MBFacebookInterface API:

/**
 *  Priv JS Facebook Login+Reg Methods
 *
 *  Exposed to privJS
 */

+ (void)loginToMobageWithFacebookWithCallbackQueue:(dispatch_queue_t)cbQueue
                                        onComplete:(void (^)(MBMobageFacebookLoginStatus, NSObject<MBError> *error, NSArray *userData))completeCb;

+ (void)registerUserWithFacebook:(NSString*)username
                        andOptIn:(NSInteger)optIn
               withCallbackQueue:(dispatch_queue_t)cbQueue
                      onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error))completeCb;

+ (void)linkCurrentUserToCurrentFacebookAccountWithCallbackQueue:(dispatch_queue_t)cbQueue
													  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * error))completeCb;

/**
 *  Priv JS Facebook API wrappers
 *
 *  Exposed to privJS
 */

+ (void)isSessionValidWithCallbackQueue:(dispatch_queue_t)cbQueue
                             onComplete:(void (^)(MBSimpleAPIStatus status, BOOL result))completeCb;

+ (void)loginToFacebookWithCallbackQueue:(dispatch_queue_t)cbQueue
                              onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * error))completeCb;

+ (void)showInviteDialogForId:(NSString*) fbid
            withCallbackQueue:(dispatch_queue_t)cbQueue
                   onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError> * error))completeCb;

+ (void)showShareDialogWithCallbackQueue:(dispatch_queue_t)cbQueue
                              onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError> * error))completeCb;

+ (void)getFriendsWithCount:(int) count
                  andOffset:(int) offset
          withCallbackQueue:(dispatch_queue_t)cbQueue
                 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * error, NSArray* contacts))completeCb;

/**
 *  Facebook API wrapper
 *
 *  Not exposed for now
 */

+ (void)requestWithParams:(NSMutableDictionary *)params
        withCallbackQueue:(dispatch_queue_t)cbQueue
               onComplete:(void (^)(NSObject<MBError> *error, id result))completeCb;

+ (void)requestWithMethodName:(NSString *)methodName
                    andParams:(NSMutableDictionary *)params
                andHttpMethod:(NSString *)httpMethod
            withCallbackQueue:(dispatch_queue_t)cbQueue
                   onComplete:(void (^)(NSObject<MBError> *error, id result))completeCb;

+ (void)requestWithGraphPath:(NSString *)graphPath
           withCallbackQueue:(dispatch_queue_t)cbQueue
                  onComplete:(void (^)(NSObject<MBError> *error, id result))completeCb;

+ (void)requestWithGraphPath:(NSString *)graphPath
                   andParams:(NSMutableDictionary *)params
           withCallbackQueue:(dispatch_queue_t)cbQueue
                  onComplete:(void (^)(NSObject<MBError> *error, id result))completeCb;

+ (void)requestWithGraphPath:(NSString *)graphPath
                   andParams:(NSMutableDictionary *)params
               andHttpMethod:(NSString *)httpMethod
           withCallbackQueue:(dispatch_queue_t)cbQueue
                  onComplete:(void (^)(NSObject<MBError> *error, id result))completeCb;

+ (void)   dialog:(NSString *)action
withCallbackQueue:(dispatch_queue_t)cbQueue
       onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError> *error, id result))completeCb;

+ (void)   dialog:(NSString *)action
        andParams:(NSMutableDictionary *)params
withCallbackQueue:(dispatch_queue_t)cbQueue
       onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError> *error, id result))completeCb;

@end

@interface MB_WW_FacebookInterface () <MB_WW_FacebookInterfaceInternal>

@end

