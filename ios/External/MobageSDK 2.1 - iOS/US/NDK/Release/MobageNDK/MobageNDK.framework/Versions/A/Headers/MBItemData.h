//
//  MBItemData.h
//  mobage-ndk
//
//  Created by Andy Block on 3/15/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBDataModel.h"

/**
 * @file MBItemData.h
 * Model for information about a virtual item.
 * @since 1.5
 */

/**
 * Stores information about a virtual item for your app. Use the
 * <a href="https://developer.mobage.com/">Mobage Developer Portal</a> to set up your app's virtual
 * items.
 * @since 1.5
 */
@protocol MBItemData <MBDataModel>
/**
 * The item's unique ID.
 * @since 1.5
 */
@property (nonatomic, retain) NSString* itemId;
/**
 * The item's name.
 * @since 1.5
 */
@property (nonatomic, retain) NSString* name;
/**
 * The item's price, represented in your app-specific purchased currency.
 * @since 1.5
 */
@property (nonatomic, assign) int price;
/**
 * A description of the item.
 * @since 1.5
 */
@property (nonatomic, retain) NSString* description;
/**
 * The URL for an image of the item.
 * @since 1.5
 */
@property (nonatomic, retain) NSString* imageUrl;


/**
 * Create an object representing a virtual item.
 * <p>
 * <strong>Note</strong>: This method creates a representation of a virtual item that you have
 * already set up for your app. Use the <a href="https://developer.mobage.com/">Mobage Developer
 * Portal</a> to set up your app's virtual items.
 * @since 1.5
 */
+ (id) item;

@end

typedef NSObject<MBItemData> MBItemDataProtocol;
