//
//  MBCGame+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCGAME_IOS_H_
#define MBCGAME_IOS_H_

#import "MBInterfaceEnums.h"

#include "MBCUtils+iOS.h"
#include "MBCGame.h"

#ifdef __cplusplus
extern "C" {
#endif

	#define MBCCToNativeGame(from) (__bridge NSObject<MBGame>*)(from->__CAPI_NATIVEREF)
	_MBCCToNativeArrayPrototype(Game);
	#define MBCCToNativeGameArray(from) _MBCCToNativeGameArray(from)
	
	#define MBCCopyGameIntoStructPtr(structPtr, objc, property) (structPtr)->property = MBCConstructGame((__bridge void*)[((MBC_OBJC_CLASSNAME*)objc) property])
	#define MBCCopyGameArrayIntoStructPtr(structPtr, objc, property) (structPtr)->property = MBCConstructGame_Array((__bridge void*)[((MBC_OBJC_CLASSNAME*)objc) property])
	
	#define MBCCToCGame(from,deepCopy) MBCCopyConstructGame(from,deepCopy)
	#define MBCCToCGameArray(from,deepCopy) MBCCopyConstructGame_Array(from,deepCopy)
	
	MBCGame_Array * _MBCHeapAllocateGame_Array(void);
	#define _MBCDestroyPropertyGame(structPtr,property) MBCReleaseGame(structPtr->property);structPtr->property = NULL
	#define _MBCDestroyPropertyGameArray(structPtr,property) MBCReleaseGame_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyGame(void * voidPtr);
	void _MBCInternalDestroyGame_Array(void * voidPtr);
	
	


#ifdef __cplusplus
}
#endif

#endif
