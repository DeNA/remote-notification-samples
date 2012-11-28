//
//  FacebookUser.h
//  mobage-ndk
//
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_FacebookUser_h
#define mobage_ndk_FacebookUser_h

#include "RegionSpecifics.h"

#import "MBFacebookUser.h"

#if MB_WW
#import "MB_WW_FacebookUser.h"
#define RegionSpecificFacebookUser MB_WW_FacebookUser
#elif MB_JP
//#import "MB_JP_FacebookUser.h"
//#define RegionSpecificFacebookUser MB_JP_FacebookUser
#else
// Invalid Configuration
#endif

@interface MBFacebookUser : RegionSpecificFacebookUser
@end

#undef RegionSpecificFacebookUser

#endif
