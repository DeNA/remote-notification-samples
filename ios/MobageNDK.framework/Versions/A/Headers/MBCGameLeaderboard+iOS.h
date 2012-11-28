//
//  MBCGameLeaderboard+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCGAMELEADERBOARD_IOS_H_
#define MBCGAMELEADERBOARD_IOS_H_

#import "MBInterfaceEnums.h"

#include "MBCUtils+iOS.h"
#include "MBCGameLeaderboard.h"

#ifdef __cplusplus
extern "C" {
#endif

	#define MBCCToNativeGameLeaderboard(from) (__bridge NSObject<MBGameLeaderboard>*)(from->__CAPI_NATIVEREF)
	_MBCCToNativeArrayPrototype(GameLeaderboard);
	#define MBCCToNativeGameLeaderboardArray(from) _MBCCToNativeGameLeaderboardArray(from)
	
	#define MBCCopyGameLeaderboardIntoStructPtr(structPtr, objc, property) (structPtr)->property = MBCConstructGameLeaderboard((__bridge void*)[((MBC_OBJC_CLASSNAME*)objc) property])
	#define MBCCopyGameLeaderboardArrayIntoStructPtr(structPtr, objc, property) (structPtr)->property = MBCConstructGameLeaderboard_Array((__bridge void*)[((MBC_OBJC_CLASSNAME*)objc) property])
	
	#define MBCCToCGameLeaderboard(from,deepCopy) MBCCopyConstructGameLeaderboard(from,deepCopy)
	#define MBCCToCGameLeaderboardArray(from,deepCopy) MBCCopyConstructGameLeaderboard_Array(from,deepCopy)
	
	MBCGameLeaderboard_Array * _MBCHeapAllocateGameLeaderboard_Array(void);
	#define _MBCDestroyPropertyGameLeaderboard(structPtr,property) MBCReleaseGameLeaderboard(structPtr->property);structPtr->property = NULL
	#define _MBCDestroyPropertyGameLeaderboardArray(structPtr,property) MBCReleaseGameLeaderboard_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyGameLeaderboard(void * voidPtr);
	void _MBCInternalDestroyGameLeaderboard_Array(void * voidPtr);
	
	


#ifdef __cplusplus
}
#endif

#endif
