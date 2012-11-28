//
//  MBCBlacklist.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCBLACKLIST_H_
#define MBCBLACKLIST_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"
#include "MBCUser.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	
	#pragma mark - Method Callbacks!
	/**
	 * MBCBlacklist_fetchBlacklistOfUserCallback
	 * @description 	 * Callback for retrieving a user's entire blacklist.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * blacklistedUsers An array of <c>User</c> objects representing blacklisted users, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * @cb-param int32_t startOffset The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.			
	 * @cb-param int32_t totalPossibleResultCount The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.			
	 */
	typedef void (*MBCBlacklist_fetchBlacklistOfUserCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser_Array * blacklistedUsers,
				int32_t startOffset,
				int32_t totalPossibleResultCount,
				
				void * context
																);
	/**
	 * MBCBlacklist_checkBlacklistOfUserForUserCallback
	 * @description 	 * Callback for checking whether a user's blacklist contains a specified user.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param bool isBlacklisted Set to <c>true</c> if the target user is on the user's blacklist or <c>false</c> if the target user is not on the blacklist.			
	 */
	typedef void (*MBCBlacklist_checkBlacklistOfUserForUserCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				bool isBlacklisted,
				
				void * context
																);
	
	#pragma mark - Static Methods
	/**
	 * MBCBlacklist_fetchBlacklistOfUser
	 * @function
	 * @public
	 * @description 	 * Retrieve a user's entire blacklist.
	 * You can use the <c>howMany</c> and <c>startOffset</c> parameters to control the
	 * number of results that this method retrieves, as well as the start index for the search
	 * results.
	 *
	 * @param MBCUser *  user The user who owns the blacklist.			AUTORELEASED
	 * @param int32_t  howMany The number of results to retrieve. The default value is <c>50</c>.			
	 * @param int32_t  startOffset The start index for the search results. The default value is <c>1</c>. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.			
	 * @cb FetchBlacklistOfUserOnCompleteCallback  onComplete 
	 * Retrieve a user's entire blacklist.
	 * You can use the <c>howMany</c> and <c>startOffset</c> parameters to control the
	 * number of results that this method retrieves, as well as the start index for the search
	 * results.
	 			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * blacklistedUsers An array of <c>User</c> objects representing blacklisted users, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * @cb-param int32_t startOffset The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.			
	 * @cb-param int32_t totalPossibleResultCount The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.			
	 * <br/>
	 */
	void MBCBlacklist_fetchBlacklistOfUser(
										MBCUser *  user,
										int32_t  howMany,
										int32_t  startOffset,
										MBCBlacklist_fetchBlacklistOfUserCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBlacklist_checkBlacklistOfUserForUser
	 * @function
	 * @public
	 * @description 	 * Check whether a user's blacklist contains a specified user.
	 *
	 * @param MBCUser *  user The user whose blacklist will be checked.			AUTORELEASED
	 * @param MBCUser *  targetUser The user to search for in the blacklist.			AUTORELEASED
	 * @cb CheckBlacklistOfUserForUserOnCompleteCallback  onComplete 
	 * Check whether a user's blacklist contains a specified user.
	 			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param bool isBlacklisted Set to <c>true</c> if the target user is on the user's blacklist or <c>false</c> if the target user is not on the blacklist.			
	 * <br/>
	 */
	void MBCBlacklist_checkBlacklistOfUserForUser(
										MBCUser *  user,
										MBCUser *  targetUser,
										MBCBlacklist_checkBlacklistOfUserForUserCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );


#ifdef __cplusplus
}
#endif

#endif /* MBCBLACKLIST_H_ */

