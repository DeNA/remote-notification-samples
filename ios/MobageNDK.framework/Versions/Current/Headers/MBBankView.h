//
//  MB_WW_LoginView.h
//  NGMobageUS
//
//  Created by Frederic Barthelemy on 3/6/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MBBankViewController.h"



@interface MBBankView : UIView

@property (nonatomic, assign) MBBankViewController *parentController;
@property (nonatomic, assign) id<MBBankViewDelegate> delegate;
@property (nonatomic, readwrite, strong) UILabel * myBalanceAmtLabel;
@property (nonatomic, readwrite, strong) UILabel * currencyLabel;
@property (nonatomic, strong) UIImageView * currencyIcon;
@property (nonatomic, strong) NSString *storvisitid;

-(void)setImageFolderPath:(NSString*)path;
-(void)refreshItem: (NSArray *)creditItem;
-(void)dealloc;
@end