//
//  Game.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/10/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_Game_h
#define mobage_ndk_Game_h

#include "RegionSpecifics.h"

#import "MBGame.h"

#if MB_WW
#import "MB_WW_Game.h"
#define RegionSpecificGame MB_WW_Game
#elif MB_JP
//#import "MB_JP_Game.h"
//#define RegionSpecificGame MB_JP_Game
#else
// Invalid Configuration
#endif

@interface MBGame : RegionSpecificGame
@end

#undef RegionSpecificGame

#include "MBCGame.h"
#endif

