//
//  MBCRewardCampaign.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCREWARDCAMPAIGN_H_
#define MBCREWARDCAMPAIGN_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"
#include "MBCRewardCampaignCode.h"
#include "MBCUser.h"

#ifdef __cplusplus
extern "C" {
#endif

#if MB_WW // whole interface/model is region-specific
#pragma mark Enums / Bitfields

	#pragma mark Structs
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		MBC_Common_IsActive(const char * uid);
		MBC_Common_IsActive(int32_t redemptions);
		MBC_Common_IsActive(int32_t startsAt);
		MBC_Common_IsActive(int32_t endsAt);
		MBC_Common_IsActive(int32_t expiresAt);
		MBC_Common_IsActive(const char * payload);
		MBC_Common_IsActive(MBCRewardCampaignCode_Array * codes);
	}  MBCRewardCampaign;
	
	MBCArrayForType(RewardCampaign,MBCRewardCampaign *);
	
	#pragma mark - Retain/Release (produces type-specific MBCRetain & MBCRelease)
	MBCRetainPrototype(RewardCampaign);
	MBCRetainPrototype(RewardCampaign_Array);
	MBCReleasePrototype(RewardCampaign);
	MBCReleasePrototype(RewardCampaign_Array);
	
	#pragma mark - Constructors
	/**
	 * Constructors return objects with a REFCOUNT of 1, you must call MBCRelease when you're done!
	 */
	MBCRewardCampaign * MBCConstructRewardCampaign(void * __CAPI_NATIVEREF);
	MBCRewardCampaign_Array * MBCConstructRewardCampaign_Array(void * __CAPI_NATIVEREF);
	
	MBCRewardCampaign * MBCCopyConstructRewardCampaign(MBCRewardCampaign * foreignObject, bool shouldDeepCopy); // Copies object into C address-space
	MBCRewardCampaign_Array * MBCCopyConstructRewardCampaign_Array(MBCRewardCampaign_Array * foreignObject, bool shouldCopyElements); // Copies object array into C address-space
	
	/**
	 * @private
	 * Fills a previously allocated struct (Internal)
	 */
	void MBCFillStructRewardCampaign(void * structObj, void * __CAPI_NATIVEREF);
	void MBCFillStructRewardCampaign_Array(void *structObj, void * __CAPI_NATIVEREF); 
	
	
	#pragma mark - Method Callbacks!
	/**
	 * MBCRewardCampaign_getActiveCampaignsCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param MBCRewardCampaign_Array * activeCampaigns 			AUTORELEASED
	 */
	typedef void (*MBCRewardCampaign_getActiveCampaignsCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCRewardCampaign_Array * activeCampaigns,
				
				void * context
																);
	
	#pragma mark - Static Methods
#if MB_WW
	/**
	 * MBCRewardCampaign_getActiveCampaigns
	 * @function
	 * @public
	 * @description 
	 *
	 * @cb GetActiveCampaignsOnCompleteCallback  onComplete 			
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param MBCRewardCampaign_Array * activeCampaigns 			AUTORELEASED
	 * <br/>
	 */
	void MBCRewardCampaign_getActiveCampaigns(
										MBCRewardCampaign_getActiveCampaignsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_WW
	#pragma mark - Instance Methods
	// None!

#endif // MB_WW -- whole interface/model is region-specific

#ifdef __cplusplus
}
#endif

#endif /* MBCREWARDCAMPAIGN_H_ */

