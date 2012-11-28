//
//  MBCString+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCSTRING_IOS_H_
#define MBCSTRING_IOS_H_

#import "MBInterfaceEnums.h"

#include "MBCUtils+iOS.h"
#include "MBCString.h"

#ifdef __cplusplus
extern "C" {
#endif

	
	_MBCCToNativeArrayPrototype(String);
	#define MBCCToNativeStringArray(from) _MBCCToNativeStringArray(from)
	
	#define MBCCopyStringIntoStructPtr(structPtr, objc, property) (structPtr)->property = _MBCNativeToCString([((MBC_OBJC_CLASSNAME*)objc) property])
	#define MBCCopyStringArrayIntoStructPtr(structPtr, objc, property) (structPtr)->property = MBCConstructString_Array((__bridge void*)[((MBC_OBJC_CLASSNAME*)objc) property])
	
	#define MBCCToCStringArray(from,deepCopy) MBCCopyConstructString_Array(from,deepCopy)
	
	MBCString_Array * _MBCHeapAllocateString_Array(void);
	#define _MBCDestroyPropertyString(structPtr,property) if(structPtr->property){free((void*)structPtr->property);}structPtr->property = NULL
	#define _MBCDestroyPropertyStringArray(structPtr,property) MBCReleaseString_Array(structPtr->property);structPtr->property = NULL
	
	void _MBCInternalDestroyString(void * voidPtr);
	void _MBCInternalDestroyString_Array(void * voidPtr);
	
	const char * _MBCNativeToCString(NSString* from);
	void _MBCNativeToCStringArray(MBCString_Array * to, NSArray * from);
	


#ifdef __cplusplus
}
#endif

#endif
