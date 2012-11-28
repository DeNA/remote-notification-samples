//
//  Debit.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 3/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_Debit_h
#define mobage_ndk_Debit_h


#import "MBBankDebit.h"



#if MB_WW
#import "MB_WW_BankDebit.h"
#define RegionSpecificDebit MB_WW_BankDebit
#elif MB_JP
#import "MB_JP_BankDebit.h"
#define RegionSpecificDebit MB_JP_BankDebit
#else
#error "Unknown or No Region Specified."
#endif

@interface MBBankDebit : RegionSpecificDebit
@end
#undef RegionSpecificDebit



#import "MBBankInventory.h"

#if MB_WW
#import "MB_WW_BankInventory.h"
#define RegionSpecificInventory MB_WW_BankInventory
#elif MB_JP
#import "MB_JP_BankInventory.h"
#define RegionSpecificInventory MB_JP_BankInventory
#else
#error "Unknown or No Region Specified."
#endif

@interface MBBankInventory : RegionSpecificInventory
@end
#undef RegionSpecificInventory

#endif
