//
//  Reward.h
//  MobageNDK
//
//  Created by Frederic Barthelemy on 8/8/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef MobageNDK_Reward_h
#define MobageNDK_Reward_h

#include "RegionSpecifics.h"

#import "MBReward.h"

#if MB_WW
#import "MB_WW_Reward.h"
#define RegionSpecificReward MB_WW_Reward
#elif MB_JP
#import "MB_JP_Reward.h"
#define RegionSpecificReward MB_JP_Reward
#else
#error "Unknown or No Region Specified."
#endif

@interface MBReward : RegionSpecificReward
@end
#undef RegionSpecificReward

#endif

