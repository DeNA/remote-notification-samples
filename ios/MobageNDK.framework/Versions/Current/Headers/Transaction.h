//
//  Transaction.h
//  NGMobageUS
//
//  Created by Kinkoi Lo on 5/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_transaction_h


#import "MBTransaction.h"

#if MB_WW
#import "MB_WW_Transaction.h"
#define RegionSpecificTransaction MB_WW_Transaction
#elif MB_JP
#import "MB_JP_Transaction.h"
#define RegionSpecificTransaction MB_JP_Transaction
#else
#error "Unknown or No Region Specified."
#endif

@interface MBTransaction : RegionSpecificTransaction
@end
#undef RegionSpecificTransaction

#endif
