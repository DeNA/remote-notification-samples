//
//  MB_WW_LoginViewController.h
//  NGMobageUS
//
//  Created by Frederic Barthelemy on 3/6/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MBSocialService.h"
#import "MBInAppPurchase.h"

@protocol MBBankViewDelegate <NSObject>

-(void) purchase: (NSString *) identifier amt: (NSString *) price itemamt: (NSString *) value cur: (int) currenc;

@end


@interface MBBankViewController : UIViewController <MBInAppPurchaseDelegate, MBBankViewDelegate>

+ (MBBankViewController *)sharedBank;
- (void) setStorvisitid: (NSString *) uid;

- (void)show:(void (^)())dismissCb onError:(void (^)(MBError *userIds))errorCB;
- (void)setImageFolderPath:(NSString*)path;
- (void)hideView;
- (void)updateBalance;
- (void)hideGettingProductDialog;

@end
