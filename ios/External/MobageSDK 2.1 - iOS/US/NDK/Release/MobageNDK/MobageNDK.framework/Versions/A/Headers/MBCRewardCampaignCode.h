//
//  MBCRewardCampaignCode.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCREWARDCAMPAIGNCODE_H_
#define MBCREWARDCAMPAIGNCODE_H_

#include "MBCStandardTypes.h"

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
		MBC_Common_IsActive(const char * code);
		MBC_Common_IsActive(const char * channel);
		MBC_Common_IsActive(const char * marketingCopy);
		MBC_Common_IsActive(const char * iconUrl);
		MBC_Common_IsActive(int32_t redemptions);
	}  MBCRewardCampaignCode;
	
	MBCArrayForType(RewardCampaignCode,MBCRewardCampaignCode *);
	
	#pragma mark - Retain/Release (produces type-specific MBCRetain & MBCRelease)
	MBCRetainPrototype(RewardCampaignCode);
	MBCRetainPrototype(RewardCampaignCode_Array);
	MBCReleasePrototype(RewardCampaignCode);
	MBCReleasePrototype(RewardCampaignCode_Array);
	
	#pragma mark - Constructors
	/**
	 * Constructors return objects with a REFCOUNT of 1, you must call MBCRelease when you're done!
	 */
	MBCRewardCampaignCode * MBCConstructRewardCampaignCode(void * __CAPI_NATIVEREF);
	MBCRewardCampaignCode_Array * MBCConstructRewardCampaignCode_Array(void * __CAPI_NATIVEREF);
	
	MBCRewardCampaignCode * MBCCopyConstructRewardCampaignCode(MBCRewardCampaignCode * foreignObject, bool shouldDeepCopy); // Copies object into C address-space
	MBCRewardCampaignCode_Array * MBCCopyConstructRewardCampaignCode_Array(MBCRewardCampaignCode_Array * foreignObject, bool shouldCopyElements); // Copies object array into C address-space
	
	/**
	 * @private
	 * Fills a previously allocated struct (Internal)
	 */
	void MBCFillStructRewardCampaignCode(void * structObj, void * __CAPI_NATIVEREF);
	void MBCFillStructRewardCampaignCode_Array(void *structObj, void * __CAPI_NATIVEREF); 
	
	
	#pragma mark - Method Callbacks!
	
	#pragma mark - Static Methods
	// None!
	#pragma mark - Instance Methods
	// None!

#endif // MB_WW -- whole interface/model is region-specific

#ifdef __cplusplus
}
#endif

#endif /* MBCREWARDCAMPAIGNCODE_H_ */

