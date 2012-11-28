//
//  MBCAuth+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCAUTH_IOS_H_
#define MBCAUTH_IOS_H_

#import "MBInterfaceEnums.h"

#include "MBCUtils+iOS.h"
#include "MBCAuth.h"

#ifdef __cplusplus
extern "C" {
#endif

	
	
	#define MBCCToNativeMobageFacebookLoginStatus(status) ((MBMobageFacebookLoginStatus)status)
	#define MBCNativeToCMobageFacebookLoginStatus(status) ((MBCMobageFacebookLoginStatus)status)
	
	#define MBCCopyMobageFacebookLoginStatusIntoStructPtr(structPtr, objc, property) (structPtr)->property = [((MBC_OBJC_CLASSNAME*)objc) property]
	#define MBCCToCMobageFacebookLoginStatus(from,deepCopy) from
	#define _MBCDestroyPropertyMobageFacebookLoginStatus(from,property)


#ifdef __cplusplus
}
#endif

#endif
