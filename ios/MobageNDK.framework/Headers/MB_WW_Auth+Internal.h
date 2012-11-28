//
//  MB_WW_Auth+Internal.h
//  NGMobageUS
//
//  Created by Maxwell Robinson on 6/22/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MB_WW_Auth.h"
#import "MB_G_MobageSession.h"

/**
 
 */
typedef enum {
	/**
	 
	 */
	MBMobageFacebookLoginStatusSuccess = 0, 
	/**
	 
	 */
	MBMobageFacebookLoginStatusError = 1, 
	/**
	 
	 */
	MBMobageFacebookLoginStatusNewEmailAddress = 2, 
	/**
	 
	 */
	MBMobageFacebookLoginStatusTakenEmailAddress = 3
} MBMobageFacebookLoginStatus;
#define IsMBMobageFacebookLoginStatus(error) (!((error < 0) || (error > 3)))

@protocol MB_WW_AuthInternal <MB_WW_Auth>

+ (void)loginWithUsername:(NSString *)theUsername andPassword:(NSString *)thePassword withCallbackQueue:(dispatch_queue_t)callbackQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error))callback;
+ (void)registerUser:(NSString *)userName withPassword:(NSString *)password withEmail:(NSString *)emailAddress andOptIn:(NSInteger) optIn withCallbackQueue:(dispatch_queue_t)callbackQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error))callback;
+ (void)loginToMobageWithFacebookWithCallbackQueue:(dispatch_queue_t)cbQueue
                                        onComplete:(void (^)(MBMobageFacebookLoginStatus status, NSObject<MBError> *error, NSArray *userData))completeCb;

+ (void)registerUserWithFacebook:(NSString*)username andOptIn:(NSInteger)optIn withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error))completeCb;
+ (void)testRemoteGamerName:(NSString*)username withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray * suggestions))completeCb;
+ (void)testRemoteEmailAddress:(NSString*)email withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error))completeCb;
+ (void)linkCurrentUserToCurrentFacebookAccountWithCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * error))onComplete;
+ (void)forgotPasswordForEmail:(NSString *)email withCallbackQueue:(dispatch_queue_t)callbackQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * error))callback;

@end

@interface MB_WW_Auth () <MB_WW_AuthInternal>

@end

