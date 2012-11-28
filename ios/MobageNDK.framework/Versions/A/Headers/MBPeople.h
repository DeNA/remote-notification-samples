//
//  MBPeople.h
//  mobage-ndk
//
//  Created by Henrik Johansson on 3/11/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "User.h"
#import "MBError.h"
#import "MBPagingAPIResult.h"
#import "MBPagingAPIOptions.h"

/**
 * @file MBPeople.h
 * Provides access to user information.
 * @since 1.5
 */

/**
 * Provides access to information about Mobage users, including their personal 
 * information and their friends. A user's network of friends is sometimes referred to as the user's
 * "social graph."
 * @since 1.5
 */
@protocol MBPeople <NSObject>

/**
 * Retrieve information about a specified user.
 * @param userId The user ID of the user to retrieve.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>user</code>: Information about the specified user, or <code>nil</code> if the request
 * did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void) getUserForId:(NSString *)userId
	withCallbackQueue:(dispatch_queue_t)cbQueue 
		   onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError>* error, NSObject<MBUser> *user))completeCb;

/**
 * Retrieve information about a maximum of 100 users.
 * @param userIds The user IDs of the users to retrieve. Each user ID must be an
 *      <code>NSString</code>. Must contain between 1 and 100 user IDs.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>users</code>: An array of <code>MBUser</code> objects, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void) getUsersForIds:(NSArray *)userIds 
	  withCallbackQueue:(dispatch_queue_t)cbQueue 
			 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *users))completeCb;

/**
 * Retrieve information about the current user.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>user</code>: Information about the current user, or <code>nil</code> if the request did
 * not succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void) getCurrentUserWithCallbackQueue:(dispatch_queue_t)cbQueue 
							  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBUser> *user))completeCb;

/**
 * Retrieve information about a user's friends.
 * <p>
 * You can use the <code>howMany</code> and <code>startOffset</code> parameters to control the
 * number of results that this method retrieves, as well as the start index for the search results.
 * <p>
 * <strong>Important</strong>: In the current version of the Native SDK, this method uses a starting
 * index of <code>0</code> for the first search result, which differs from other Native SDK APIs.
 * @param user The user whose friends will be retrieved.
 * @param howMany The number of results to retrieve. The default value is <code>50</code>.
 * @param startOffset The start index for the search results. The default value is <code>0</code>.
 *      <strong>Important</strong>: This differs from other Native SDK APIs.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>users</code>: An array of <code>MBUser</code> objects, or <code>nil</code> if the
 * request did not succeed.</li>
 * <li><code>startOffset</code>: The starting index for this group of items within the entire list,
 * or <code>nil</code> if the request did not succeed. <strong>Important</strong>: The index of the
 * first item on the entire list is <code>0</code>, which differs from other Native SDK APIs.</li>
 * <li><code>totalPossibleResultCount</code>: The total number of items that can be retrieved, or
 * <code>nil</code> if the request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void) getFriendsForUser:(NSObject<MBUser>*)user
				   howMany:(NSInteger)howMany
			   startOffset:(NSInteger)startOffset
		 withCallbackQueue:(dispatch_queue_t)cbQueue 
				onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *users, NSInteger startOffset, NSInteger totalPossibleResultCount))completeCb;

/**
 * Retrieve information about a user's friends who have used the current app.
 * <p>
 * You can use the <code>howMany</code> and <code>startOffset</code> parameters to control the
 * number of results that this method retrieves, as well as the start index for the search results.
 * <p>
 * <strong>Important</strong>: In the current version of the Native SDK, this method uses a starting
 * index of <code>0</code> for the first search result, which differs from other Native SDK APIs.
 * @param user The user whose friends have used the current app.
 * @param howMany The number of results to retrieve. The default value is <code>50</code>.
 * @param startOffset The start index for the search results. The default value is <code>0</code>.
 *      <strong>Important</strong>: This differs from other Native SDK APIs.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>users</code>: An array of <code>MBUser</code> objects, or <code>nil</code> if the
 * request did not succeed.</li>
 * <li><code>startOffset</code>: The starting index for this group of items within the entire list,
 * or <code>nil</code> if the request did not succeed. <strong>Important</strong>: The index of the
 * first item on the entire list is <code>0</code>, which differs from other Native SDK APIs.</li>
 * <li><code>totalPossibleResultCount</code>: The total number of items that can be retrieved, or
 * <code>nil</code> if the request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+ (void) getFriendsWithGameForUser:(NSObject<MBUser> *)user
						   howMany:(NSInteger)howMany
					   startOffset:(NSInteger)startOffset
				   withCallbackQueue:(dispatch_queue_t)cbQueue 
						  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error,NSArray *users, NSInteger startOffset, NSInteger totalPossibleResultCount))completeCb;

#pragma mark - Deprecated
@optional
+ (void) getUser:(NSString *)userId
withCallbackQueue:(dispatch_queue_t)cbQueue 
       onSuccess:(void (^)(MBUser *user))successCB
         onError:(void (^)(MBError *error))errorCB								__attribute__((deprecated)) /*Deprecated in 1.9*/;

+ (void) getUsers:(NSArray *)userIds 
withCallbackQueue:(dispatch_queue_t)cbQueue 
        onSuccess:(void (^)(NSArray *users))successCB
          onError:(void (^)(MBError *error))errorCB								__attribute__((deprecated)) /*Deprecated in 1.9*/;

+ (void) getCurrentUser:(dispatch_queue_t)cbQueue 
              onSuccess:(void (^)(MBUser *user))successCB
                onError:(void (^)(MBError *error))errorCB						__attribute__((deprecated)) /*Deprecated in 1.9*/;

+ (void) getFriends:(NSString *)userId 
                opt:(MBPagingAPIOptions *)option
  withCallbackQueue:(dispatch_queue_t)cbQueue 
          onSuccess:(void (^)(NSArray *users, MBPagingAPIResult *result))successCB
            onError:(void (^)(MBError *error))errorCB							__attribute__((deprecated)) /*Deprecated in 1.9*/;

+ (void) getFriendsWithGame:(NSString *)userId 
                        opt:(MBPagingAPIOptions *)option
          withCallbackQueue:(dispatch_queue_t)cbQueue 
                  onSuccess:(void (^)(NSArray *users, MBPagingAPIResult *result))successCB
                    onError:(void (^)(MBError *error))errorCB					__attribute__((deprecated)) /*Deprecated in 1.9*/;
@end

