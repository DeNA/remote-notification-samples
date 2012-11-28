//
//  MBCPeople.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCPEOPLE_H_
#define MBCPEOPLE_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"
#include "MBCUser.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	
	#pragma mark - Method Callbacks!
	/**
	 * MBCPeople_getCurrentUserCallback
	 * @description 	 * Callback for retrieving information about the current user.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser * currentUser Information about the current user, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCPeople_getCurrentUserCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser * currentUser,
				
				void * context
																);
	/**
	 * MBCPeople_getUserForIdCallback
	 * @description 	 * Callback for retrieving information about a specified user.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser * user Information about the specified user, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCPeople_getUserForIdCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser * user,
				
				void * context
																);
	/**
	 * MBCPeople_getUsersForIdsCallback
	 * @description 	 * Callback for retrieving information about multiple users.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * users An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCPeople_getUsersForIdsCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser_Array * users,
				
				void * context
																);
	/**
	 * MBCPeople_getFriendsForUserCallback
	 * @description 	 * Callback for retrieving information about a user's friends.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * users An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * @cb-param int32_t startOffset The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. On Android, the index of the first item on the entire list is <c>1</c>. On iOS, the index of the first item on the entire list is <c>0</c>.			
	 * @cb-param int32_t totalPossibleResultCount The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.			
	 */
	typedef void (*MBCPeople_getFriendsForUserCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser_Array * users,
				int32_t startOffset,
				int32_t totalPossibleResultCount,
				
				void * context
																);
	/**
	 * MBCPeople_getFriendsWithGameForUserCallback
	 * @description 	 * Callback for retrieving information about a user's friends who have used the current app.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * users An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * @cb-param int32_t startOffset The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. On Android, the index of the first item on the entire list is <c>1</c>. On iOS, the index of the first item on the entire list is <c>0</c>.			
	 * @cb-param int32_t totalPossibleResultCount The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.			
	 */
	typedef void (*MBCPeople_getFriendsWithGameForUserCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser_Array * users,
				int32_t startOffset,
				int32_t totalPossibleResultCount,
				
				void * context
																);
	/**
	 * MBCPeople_sendFriendInviteToUserIfPossibleCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error 			AUTORELEASED
	 */
	typedef void (*MBCPeople_sendFriendInviteToUserIfPossibleCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	
	#pragma mark - Static Methods
	/**
	 * MBCPeople_getCurrentUser
	 * @function
	 * @public
	 * @description 	 * Retrieve information about the current user.
	 *
	 * @cb GetCurrentUserOnCompleteCallback  onComplete 
	 * Retrieve information about the current user.
	 			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser * currentUser Information about the current user, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 */
	void MBCPeople_getCurrentUser(
										MBCPeople_getCurrentUserCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCPeople_getUserForId
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a specified user.
	 *
	 * @param const char *  userId The user ID of the user to retrieve.			AUTORELEASED
	 * @cb GetUserForIdOnCompleteCallback  onComplete 
	 * Retrieve information about a specified user.
	 			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser * user Information about the specified user, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 */
	void MBCPeople_getUserForId(
										const char *  userId,
										MBCPeople_getUserForIdCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCPeople_getUsersForIds
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a maximum of 100 users.
	 *
	 * @param MBCString_Array *  userIds The user IDs of the users to retrieve. Must contain between 1 and 100 user IDs.			AUTORELEASED
	 * @cb GetUsersForIdsOnCompleteCallback  onComplete 
	 * Retrieve information about a maximum of 100 users.
	 			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * users An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 */
	void MBCPeople_getUsersForIds(
										MBCString_Array *  userIds,
										MBCPeople_getUsersForIdsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCPeople_getFriendsForUser
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a user's friends.
	 * You can use the <c>howMany</c> and <c>offset</c> parameters to control the number
	 * of results that this method retrieves, as well as the start index for the search results.
	 * <p>
	 * <strong>Important</strong>: In the current version of the Unity SDK, Android starts numbering
	 * search results at <c>1</c>, which is consistent with other Unity SDK methods. However, iOS
	 * starts numbering search results at <c>0</c>, which is not consistent. If you will release
	 * your app on both Android and iOS, ensure that your code adjusts for this difference.
	 *
	 * @param MBCUser *  user The user whose friends will be retrieved.			AUTORELEASED
	 * @param int32_t  howMany The number of results to retrieve. The default value is <c>50</c>.			
	 * @param int32_t  offset The start index for the search results. On Android, the default value is <c>1</c>, and the index's numbering begins at <c>1</c>. On iOS, the default value is <c>0</c>, and the index's numbering begins at <c>0</c>.			
	 * @cb GetFriendsForUserOnCompleteCallback  onComplete 
	 * Retrieve information about a user's friends.
	 * You can use the <c>howMany</c> and <c>offset</c> parameters to control the number
	 * of results that this method retrieves, as well as the start index for the search results.
	 * <p>
	 * <strong>Important</strong>: In the current version of the Unity SDK, Android starts numbering
	 * search results at <c>1</c>, which is consistent with other Unity SDK methods. However, iOS
	 * starts numbering search results at <c>0</c>, which is not consistent. If you will release
	 * your app on both Android and iOS, ensure that your code adjusts for this difference.
	 			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * users An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * @cb-param int32_t startOffset The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. On Android, the index of the first item on the entire list is <c>1</c>. On iOS, the index of the first item on the entire list is <c>0</c>.			
	 * @cb-param int32_t totalPossibleResultCount The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.			
	 * <br/>
	 */
	void MBCPeople_getFriendsForUser(
										MBCUser *  user,
										int32_t  howMany,
										int32_t  offset,
										MBCPeople_getFriendsForUserCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCPeople_getFriendsWithGameForUser
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a user's friends who have used the current app.
	 * You can use the <c>howMany</c> and <c>offset</c> parameters to control the
	 * number of results that this method retrieves, as well as the start index for the search
	 * results.
	 * <p>
	 * <strong>Important</strong>: In the current version of the Unity SDK, Android starts numbering
	 * search results at <c>1</c>, which is consistent with other Unity SDK methods. However, iOS
	 * starts numbering search results at <c>0</c>, which is not consistent. If you will release
	 * your app on both Android and iOS, ensure that your code adjusts for this difference.
	 *
	 * @param MBCUser *  user The user whose friends have used the current app.			AUTORELEASED
	 * @param int32_t  howMany The number of results to retrieve. The default value is <c>50</c>.			
	 * @param int32_t  offset The start index for the search results. On Android, the default value is <c>1</c>, and the index's numbering begins at <c>1</c>. On iOS, the default value is <c>0</c>, and the index's numbering begins at <c>0</c>.			
	 * @cb GetFriendsWithGameForUserOnCompleteCallback  onComplete 
	 * Retrieve information about a user's friends who have used the current app.
	 * You can use the <c>howMany</c> and <c>offset</c> parameters to control the
	 * number of results that this method retrieves, as well as the start index for the search
	 * results.
	 * <p>
	 * <strong>Important</strong>: In the current version of the Unity SDK, Android starts numbering
	 * search results at <c>1</c>, which is consistent with other Unity SDK methods. However, iOS
	 * starts numbering search results at <c>0</c>, which is not consistent. If you will release
	 * your app on both Android and iOS, ensure that your code adjusts for this difference.
	 			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * users An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * @cb-param int32_t startOffset The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. On Android, the index of the first item on the entire list is <c>1</c>. On iOS, the index of the first item on the entire list is <c>0</c>.			
	 * @cb-param int32_t totalPossibleResultCount The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.			
	 * <br/>
	 */
	void MBCPeople_getFriendsWithGameForUser(
										MBCUser *  user,
										int32_t  howMany,
										int32_t  offset,
										MBCPeople_getFriendsWithGameForUserCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );


#ifdef __cplusplus
}
#endif

#endif /* MBCPEOPLE_H_ */

