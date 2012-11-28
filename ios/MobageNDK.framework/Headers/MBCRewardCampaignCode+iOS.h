//
//  MBCRewardCampaignCode+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCREWARDCAMPAIGNCODE_IOS_H_
#define MBCREWARDCAMPAIGNCODE_IOS_H_

#import "MBInterfaceEnums.h"
#include "MB_WW_RewardCampaignCode.h"
#include "MBCUtils+iOS.h"
#include "MBCRewardCampaignCode.h"

#ifdef __cplusplus
extern "C" {
#endif
#if MB_WW // whole interface/model is region-specific

	#define MBCCToNativeRewardCampaignCode(from) (__bridge NSObject<MB_WW_RewardCampaignCode>*)(from->__CAPI_NATIVEREF)
	_MBCCToNativeArrayPrototype(RewardCampaignCode);
	#define MBCCToNativeRewardCampaignCodeArray(from) _MBCCToNativeRewardCampaignCodeArray(from)
	
	#define MBCCopyRewardCampaignCodeIntoStructPtr(structPtr, objc, property) (structPtr)->property = MBCConstructRewardCampaignCode((__bridge void*)[((MBC_OBJC_CLASSNAME*)objc) property])
	#define MBCCopyRewardCampaignCodeArrayIntoStructPtr(structPtr, objc, property) (structPtr)->property = MBCConstructRewardCampaignCode_Array((__bridge void*)[((MBC_OBJC_CLASSNAME*)objc) property])
	
	#define MBCCToCRewardCampaignCode(from,deepCopy) MBCCopyConstructRewardCampaignCode(from,deepCopy)
	#define MBCCToCRewardCampaignCodeArray(from,deepCopy) MBCCopyConstructRewardCampaignCode_Array(from,deepCopy)
	
	MBCRewardCampaignCode_Array * _MBCHeapAllocateRewardCampaignCode_Array(void);
	#define _MBCDestroyPropertyRewardCampaignCode(structPtr,property) MBCReleaseRewardCampaignCode(structPtr->property);structPtr->property = NULL
	#define _MBCDestroyPropertyRewardCampaignCodeArray(structPtr,property) MBCReleaseRewardCampaignCode_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyRewardCampaignCode(void * voidPtr);
	void _MBCInternalDestroyRewardCampaignCode_Array(void * voidPtr);
	
	

#endif // MB_WW -- whole interface/model is region-specific

#ifdef __cplusplus
}
#endif

#endif
