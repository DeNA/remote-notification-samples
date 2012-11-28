//
//  Facebook.h
//  mobage-ndk
//
//  Created by Maxwell Robinson on 5/29/12
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_FacebookInterface_h
#define mobage_ndk_FacebookInterface_h

#include "RegionSpecifics.h"

#import "MBFacebookInterface.h"

#if MB_WW
#import "MB_WW_FacebookInterface.h"
#import "MB_WW_FacebookInterface+Internal.h"
#define RegionSpecificFacebookInterface MB_WW_FacebookInterface
#elif MB_JP
#import "MB_JP_FacebookInterface.h"
#define RegionSpecificFacebookInterface MB_JP_FacebookInterface
#else
#error "Unknown or No Region Specified."
#endif

@interface MBFacebookInterface : RegionSpecificFacebookInterface
@end
#undef RegionSpecificFacebookInterface

#endif
