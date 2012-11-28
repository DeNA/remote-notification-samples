//
//  SocialService.h
//  mobage-ndk
//
//  Created by Henrik Johansson on 3/16/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_SocialService_h
#define mobage_ndk_SocialService_h

#include "RegionSpecifics.h"

#import "MBSocialService.h"

#if MB_WW
#import "MB_WW_SocialService.h"
#define RegionSpecificSocialService MB_WW_SocialService
#elif MB_JP
#import "MB_JP_SocialService.h"
#define RegionSpecificSocialService MB_JP_SocialService
#else
#error "Unknown or No Region Specified."
#endif

@interface MBSocialService : RegionSpecificSocialService

@end

#undef RegionSpecificSocialService

#endif