//
//  Reward.h
//  mobage-ndk
//
//  Created by Thomas Chao on 7/6/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_RewardCampaign_h
#define mobage_ndk_RewardCampaign_h

#include "RegionSpecifics.h"

#import "MBRewardCampaign.h"

#if MB_WW
#import "MB_WW_RewardCampaign.h"
#define RegionSpecificReward MB_WW_RewardCampaign
#elif MB_JP
#import "MB_JP_RewardCampaign.h"
#define RegionSpecificReward MB_JP_RewardCampaign
#else
#error "Unknown or No Region Specified."
#endif

@interface MBRewardCampaign : RegionSpecificReward
@end
#undef RegionSpecificReward

#endif
