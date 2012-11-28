//
//  RewardCampaignCode.h
//  mobage-ndk
//
//  Created by Thomas Chao on 7/6/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_RewardCampaignCode_h
#define mobage_ndk_RewardCampaignCode_h

#include "RegionSpecifics.h"

#import "MBRewardCampaignCode.h"

#if MB_WW
#import "MB_WW_RewardCampaignCode.h"
#define RegionSpecificRewardCode MB_WW_RewardCampaignCode
#elif MB_JP
#import "MB_JP_RewardCampaignCode.h"
#define RegionSpecificRewardCode MB_JP_RewardCampaignCode
#else
#error "Unknown or No Region Specified."
#endif

@interface MBRewardCampaignCode : RegionSpecificRewardCode
@end
#undef RegionSpecificRewardCode

#endif
