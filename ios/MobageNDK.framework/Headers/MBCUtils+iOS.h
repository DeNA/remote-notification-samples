//
//  MBCUtils+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCUTILS_IOS_H_
#define MBCUTILS_IOS_H_

#include "MBCUtils.h"
#include "MBCStandardTypes.h"

#ifdef __cplusplus
extern "C" {
	#include <cstdlib>
	#include <cstring>
#else
	#include <stdlib.h>
	#include <string.h>
#endif


#define MBCToLiteral(type, from) (type)from


// Native->C
#define MBCNativeToCDouble(from) MBCToLiteral(double,from)
#define MBCNativeToCInteger(from) MBCToLiteral(int,from)
#define MBCNativeToCBool(from) MBCToLiteral(bool,from)
#define MBCNativeToCBillingItem(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCBillingItemArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCError(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCErrorArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCFacebookUser(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCFacebookUserArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCGame(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCGameArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCGameLeaderboard(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCGameLeaderboardArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCItemData(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCItemDataArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCRemoteNotificationPayload(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCRemoteNotificationPayloadArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCRemoteNotificationResponse(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCRemoteNotificationResponseArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCRewardCampaign(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCRewardCampaignArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCRewardCampaignCode(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCRewardCampaignCodeArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCScore(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCScoreArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCString(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCStringArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCTransaction(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCTransactionArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCUser(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCUserArray(from) (from)?(transient_ ## from):NULL

// C->Native
#define MBCCToNativeDouble(from) MBCToLiteral(double,from)
#define MBCCToNativeInteger(from) MBCToLiteral(NSInteger,from)
#define MBCCToNativeBool(from) MBCToLiteral(BOOL,from)
#define MBCCToNativeString(from) ((from) ? [NSString stringWithUTF8String:from] : nil)
#define _MBCCToNativeArrayPrototype(type) NSArray* _MBCCToNative ## type ## Array(MBC ## type ## _Array* from)
#define _MBCCToNativeArrayBody(type,objcType,t2Convert) \
NSArray* _MBCCToNative ## type ## Array(MBC ## type ## _Array* from){ \
	int len = from ? from->length : 0; \
	NSMutableArray * tmp = [NSMutableArray arrayWithCapacity: len]; \
	for (int i = 0; i < len; i++){ \
		objcType t2 = MBCCToNative ## type (from->elements[i]); \
		if (t2){[tmp addObject:t2Convert];} \
	}\
	return tmp;\
}

#define MBCCToNativeDoubleArray(from) _MBCCToNativeDoubleArray(from)
#define MBCCToNativeIntegerArray(from) _MBCCToNativeIntegerArray(from)
#define MBCCToNativeBoolArray(from) _MBCCToNativeBoolArray(from)

// C->C
#define MBCCToCDouble(from,deepCopy) MBCToLiteral(double,from)
#define MBCCToCInteger(from,deepCopy) MBCToLiteral(int,from)
#define MBCCToCBool(from,deepCopy) MBCToLiteral(bool,from)
#define MBCCToCString(from,deepCopy) _MBCCStringCopy(from)
const char * _MBCCStringCopy(const char * input);

// Native->C_Struct
#define MBCCopyLiteralIntoStructPtr(structPtr, objc, property) {(structPtr)->property = [((MBC_OBJC_CLASSNAME*)objc) property];}
#define MBCCopyDoubleIntoStructPtr(structPtr, objc, property) {MBCCopyLiteralIntoStructPtr(structPtr,objc,property)}
#define MBCCopyIntegerIntoStructPtr(structPtr, objc, property) {MBCCopyLiteralIntoStructPtr(structPtr,objc,property)}
#define MBCCopyBoolIntoStructPtr(structPtr, objc, property) {MBCCopyLiteralIntoStructPtr(structPtr,objc,property)}

#define _MBCDestroyPropertyLiteral(structPtr,property) /* property is a literal */
#define _MBCDestroyPropertyDouble(structPtr,property) _MBCDestroyPropertyLiteral(structPtr,property)
#define _MBCDestroyPropertyInteger(structPtr,property) _MBCDestroyPropertyLiteral(structPtr,property)
#define _MBCDestroyPropertyBool(structPtr,property) _MBCDestroyPropertyLiteral(structPtr,property)

_MBCCToNativeArrayPrototype(Double);
_MBCCToNativeArrayPrototype(Integer);
_MBCCToNativeArrayPrototype(Bool);

// This is an exceptional error, object gets leaked!
#define MBCMakeError(domain,code,msg) MBCConstructError((__bridge void *)[MBError makeErrorFromString: @"" msg withDomain: @"" domain andCode: code])

#ifdef __cplusplus
}
#endif

#endif
