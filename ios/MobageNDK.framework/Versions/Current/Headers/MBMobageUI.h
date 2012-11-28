//
//  MBMobageUI.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 5/2/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <UIKit/UIKit.h>
#import "BankUI.h"

typedef enum {
	MBUIPresentationStyleFullScreen = 0, 

	/* Apple's Constants, so our method override can cast to Apple's UIModalPresentationStyle*/
	MB_UIModalPresentationFullScreen = 0,
	MB_UIModalPresentationPageSheet,
	MB_UIModalPresentationFormSheet,
	MB_UIModalPresentationCurrentContext,
	/* End Apple's values */
	
	MBUIPresentationStyleFloatingWindow = 10, //This specific value is irrelevant, we're just making room for apple!

	MBUIPresentationStyleDrawerDockTop,
	MBUIPresentationStyleDrawerDockRight,
	MBUIPresentationStyleDrawerDockBottom,
	MBUIPresentationStyleDrawerDockLeft
} MBUIPresentationStyle;

#define MBUIPresentationStyleIsCustom(style) (style >= MBUIPresentationStyleFloatingWindow)
#define MBUIPresentationStyleIsDocked(style) (style >= MBUIPresentationStyleDrawerDockTop && style <= MBUIPresentationStyleDrawerDockLeft)
#define MBUIPresentationStyleDockIsHorizontal(side) (side == MBUIPresentationStyleDrawerDockLeft || side == MBUIPresentationStyleDrawerDockRight)
#define MBUIPresentationStyleDockIsVertical(side) (!(MBUIPresentationStyleDockIsHorizontal(side)))

@interface MBMobageUI : UIViewController

+ (MBMobageUI*) sharedMobageUI;

@property (nonatomic, readonly, getter=isOpen) BOOL open;
@property (nonatomic, readwrite, strong) UIViewController * activeViewController;

- (void)pushChildViewController:(UIViewController*)viewControllerToPresent animated:(BOOL)flag completion:(void (^)(void))completion;
- (void)popChildViewControllerAnimated:(BOOL)flag completion:(void (^)(void))completion;

- (void)dismissViewControllerAnimated:(BOOL)flag completion:(void (^)(void))completion;
/**
 * If UIViewController implements MBUIViewController (optional protocol)
 *	it can decide what side it wants to dock to. Defaults to rightside
 */
- (void)presentViewController:(UIViewController *)viewControllerToPresent animated:(BOOL)flag completion:(void (^)(void))completion;

///// Set the tint color for navigation- and toolbars in popup views.
//- (void) setModalViewTintColor:(UIColor *)color;

@property (nonatomic, readwrite) BOOL isBalanceButtonVisible;
- (void)setBalanceButton:(MBBalanceButton *)button;
- (void)showBalanceButton;
- (void)removeBalanceButton;
@end
