//
//  MBCRewardCampaign+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCREWARDCAMPAIGN_IOS_H_
#define MBCREWARDCAMPAIGN_IOS_H_

#import "MBInterfaceEnums.h"
#include "MB_WW_RewardCampaign.h"
#include "MBCUtils+iOS.h"
#include "MBCRewardCampaign.h"

#ifdef __cplusplus
extern "C" {
#endif
#if MB_WW // whole interface/model is region-specific

	#define MBCCToNativeRewardCampaign(from) (__bridge NSObject<MB_WW_RewardCampaign>*)(from->__CAPI_NATIVEREF)
	_MBCCToNativeArrayPrototype(RewardCampaign);
	#define MBCCToNativeRewardCampaignArray(from) _MBCCToNativeRewardCampaignArray(from)
	
	#define MBCCopyRewardCampaignIntoStructPtr(structPtr, objc, property) (structPtr)->property = MBCConstructRewardCampaign((__bridge void*)[((MBC_OBJC_CLASSNAME*)objc) property])
	#define MBCCopyRewardCampaignArrayIntoStructPtr(structPtr, objc, property) (structPtr)->property = MBCConstructRewardCampaign_Array((__bridge void*)[((MBC_OBJC_CLASSNAME*)objc) property])
	
	#define MBCCToCRewardCampaign(from,deepCopy) MBCCopyConstructRewardCampaign(from,deepCopy)
	#define MBCCToCRewardCampaignArray(from,deepCopy) MBCCopyConstructRewardCampaign_Array(from,deepCopy)
	
	MBCRewardCampaign_Array * _MBCHeapAllocateRewardCampaign_Array(void);
	#define _MBCDestroyPropertyRewardCampaign(structPtr,property) MBCReleaseRewardCampaign(structPtr->property);structPtr->property = NULL
	#define _MBCDestroyPropertyRewardCampaignArray(structPtr,property) MBCReleaseRewardCampaign_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyRewardCampaign(void * voidPtr);
	void _MBCInternalDestroyRewardCampaign_Array(void * voidPtr);
	
	

#endif // MB_WW -- whole interface/model is region-specific

#ifdef __cplusplus
}
#endif

#endif
