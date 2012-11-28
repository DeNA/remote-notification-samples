//
//  MBBillingItem.h
//  mobage-ndk
//
//  Created by Andy Block on 3/15/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBDataModel.h"
#import "MBInterfaceEnums.h"
#import "ItemData.h"

/**
 * @file MBBillingItem.h
 * Model for information about a billing item for a transaction.
 * @since 1.5
 */

/**
 * Stores information about a billing item for a transaction.
 * @since 1.5
 */
@protocol MBBillingItem <MBDataModel>
/**
 * Information about the billing item.
 * @since 1.5
 */
@property (nonatomic, retain) NSObject<MBItemData>* item;
/**
 * The quantity of the virtual item being purchased.
 * @since 1.5
 */
@property (nonatomic, assign) int quantity;

/**
 * Create a billing item for a purchase.
 * @since 1.5
 */
+ (id) billingItem;

@end

typedef NSObject<MBBillingItem> MBBillingItemProtocol;