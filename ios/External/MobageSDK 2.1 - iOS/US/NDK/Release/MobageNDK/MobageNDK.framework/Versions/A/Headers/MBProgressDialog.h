//
//  MBProgressDialog.h
//  NGMobageUS
//
//  Created by rcuser on 3/26/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <UIKit/UIKit.h>

@interface MBProgressDialog : UIAlertView<UIAlertViewDelegate>
-(id)initWithTitle:(NSString*)title message:(NSString*)message;
-(void)hide;
-(void)show;
@end
