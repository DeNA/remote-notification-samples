//
//  MBBankUI.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 3/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

/**
 * @file MBBankUI.h
 * Provides a Balance Button for the Bank.
 * @since 1.5
 */

@protocol MBBankUI <NSObject>

@end


/**
 * The Balance Button for the Mobage Bank, which displays the user's current balance of
 * the app-specific purchased currency and opens the Bank when tapped. Call
 * <code>MBSocialService::getBalanceButton:withCallbackQueue:onComplete:</code> to retrieve the Balance
 * Button.
 * @since 1.5
 */
@interface MBBalanceButton : UIButton {
    
}
- (void)update;


@end
