//
//  BankUI.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 3/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_BankUI_h
#define mobage_ndk_BankUI_h

#include "RegionSpecifics.h"

#import "MBBankUI.h"

#if MB_WW
#import "MB_WW_BankUI.h"
#define RegionSpecificBankUI MB_WW_BankUI
#elif MB_JP
#import "MB_JP_BankUI.h"
#define RegionSpecificBankUI MB_JP_BankUI
#else
// Invalid config
#endif

@interface MBBankUI : RegionSpecificBankUI
@end

#undef RegionSpecificBankUI

#endif
