//
//  MBAuth.h
//  mobage-ndk
//
//  Created by Manabu Sato on 3/17/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "MBError.h"

/**
 * @file MBAuth.h
 * Enables app servers to authenticate with the Mobage REST API.
 * @since 1.5
 */

/**
 * Retrieve a verification code for an OAuth request token. This class supports the
 * Mobage REST API, which your app server can use to integrate with Mobage's Bank and Social
 * features. For more information about the Mobage REST API, see the
 * <a href="https://developer.mobage.com/en/resources/rest_api">Mobage REST API Reference</a> on the
 * <a href="https://developer.mobage.com/">Mobage Developer Portal</a>.
 * @since 1.5
 */
@protocol MBAuth <NSObject>

/**
 * Generate a verification code for an OAuth request token.
 * @param token The OAuth request token to verify.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>verifier</code>: The verification code, or <code>nil</code> if the request did not
 * succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void) authorizeToken: (NSString*) token
	  withCallbackQueue: (dispatch_queue_t)cbQueue
			 onComplete: (void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error, NSString* verifier))completeCb;

#pragma mark - Deprecated
@optional
+ (void) authorizeToken : (NSString*) token
			   onSuccess: (void (^)( NSString* verifier))successCB
				 onError: (void (^)( MBError* error))errorCB					__attribute__((deprecated)) /*Deprecated in 1.9*/;

@end
