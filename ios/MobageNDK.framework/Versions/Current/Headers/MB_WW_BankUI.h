//
//  MB_WW_BankUI.h
//  NGMobageUS
//
//  Created by Frederic Barthelemy on 3/7/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBBankUI.h"
#import "MBError.h"

@interface MB_WW_BankUI : NSObject<MBBankUI>

@end


@interface MB_WW_BalanceButton : MBBalanceButton {
    UIButton* _button;
	UILabel* _currencyName;
	UIImageView* _balanceImage;
	UIImageView* _coinImage;
	CGRect _mainRect;
	CGFloat _ratio;
}
@property(nonatomic, retain) UIView* button;
@property(nonatomic, retain) UILabel* currencyName;
@property(nonatomic, retain) UIImageView* coinImage;
@property(nonatomic, retain) UIImageView* balanceImage;
@property(nonatomic) NSInteger balance;



- (id)initWithFrame:(CGRect)frame
              queue:(dispatch_queue_t)_callbackQueue
            onClick:(void (^)(MBBalanceButton *button))_clickCB
            onError:(void (^)(NSObject<MBError> *error))_errorCB;
@end