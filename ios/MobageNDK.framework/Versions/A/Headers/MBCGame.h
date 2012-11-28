//
//  MBCGame.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCGAME_H_
#define MBCGAME_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark Structs
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		MBC_Common_IsActive(const char * uid);
		MBC_Common_IsActive(const char * name);
		MBC_Common_IsActive(const char * longDescription);
		MBC_Common_IsActive(const char * publisherName);
		MBC_Common_IsActive(const char * appStoreURL);
		MBC_Common_IsActive(const char * appKey);
		MBC_Common_IsActive(const char * iconUrl);
		MBC_Common_IsActive(const char * largeIconUrl);
		MBC_Common_IsActive(bool installed);
		MBC_Common_IsActive(bool featured);
		MBC_Common_IsActive(const char * promotionImageUrl);
	}  MBCGame;
	
	MBCArrayForType(Game,MBCGame *);
	
	#pragma mark - Retain/Release (produces type-specific MBCRetain & MBCRelease)
	MBCRetainPrototype(Game);
	MBCRetainPrototype(Game_Array);
	MBCReleasePrototype(Game);
	MBCReleasePrototype(Game_Array);
	
	#pragma mark - Constructors
	/**
	 * Constructors return objects with a REFCOUNT of 1, you must call MBCRelease when you're done!
	 */
	MBCGame * MBCConstructGame(void * __CAPI_NATIVEREF);
	MBCGame_Array * MBCConstructGame_Array(void * __CAPI_NATIVEREF);
	
	MBCGame * MBCCopyConstructGame(MBCGame * foreignObject, bool shouldDeepCopy); // Copies object into C address-space
	MBCGame_Array * MBCCopyConstructGame_Array(MBCGame_Array * foreignObject, bool shouldCopyElements); // Copies object array into C address-space
	
	/**
	 * @private
	 * Fills a previously allocated struct (Internal)
	 */
	void MBCFillStructGame(void * structObj, void * __CAPI_NATIVEREF);
	void MBCFillStructGame_Array(void *structObj, void * __CAPI_NATIVEREF); 
	
	
	#pragma mark - Method Callbacks!
	/**
	 * MBCGame_getGamesCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 * @cb-param MBCGame_Array * games array of games			AUTORELEASED
	 * @cb-param int32_t startOffset 			
	 * @cb-param int32_t totalPossibleResults 			
	 */
	typedef void (*MBCGame_getGamesCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCGame_Array * games,
				int32_t startOffset,
				int32_t totalPossibleResults,
				
				void * context
																);
	/**
	 * MBCGame_launchGameCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 */
	typedef void (*MBCGame_launchGameCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCGame_showInStoreCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 */
	typedef void (*MBCGame_showInStoreCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCGame_getCurrentGameCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param MBCGame * game 			AUTORELEASED
	 */
	typedef void (*MBCGame_getCurrentGameCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCGame * game,
				
				void * context
																);
	
	#pragma mark - Static Methods
	#pragma mark - Instance Methods
	/**
	 * MBCGame_launchGame
	 * @function
	 * @private
	 * @description 
	 *
	 * @cb LaunchGameOnCompleteCallback  onComplete 			
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 * <br/>
	 */
	void MBCGame_launchGame(
								MBCGame * thisObj,
								MBCGame_launchGameCallback onComplete,
								
								void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	
	/**
	 * MBCGame_showInStore
	 * @function
	 * @private
	 * @description 
	 *
	 * @cb ShowInStoreOnCompleteCallback  onComplete 			
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 * <br/>
	 */
	void MBCGame_showInStore(
								MBCGame * thisObj,
								MBCGame_showInStoreCallback onComplete,
								
								void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	


#ifdef __cplusplus
}
#endif

#endif /* MBCGAME_H_ */

