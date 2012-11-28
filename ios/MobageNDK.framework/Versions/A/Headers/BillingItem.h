//
//  BillingItem.h
//  mobage-ndk
//
//  Created by Kinkoi Lo on 5/8/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_billingitem_h
#define mobage_ndk_billingitem_h


#import "MBBillingItem.h"
#if MB_WW
#import "MB_WW_BillingItem.h"
#define RegionSpecificBillingItem MB_WW_BillingItem
#elif MB_JP
#import "MB_JP_BillingItem.h"
#define RegionSpecificBillingItem MB_JP_BillingItem
#else
#error "Unknown or No Region Specified."
#endif

@interface MBBillingItem : RegionSpecificBillingItem
@end
#undef RegionSpecificBillingItem


#endif