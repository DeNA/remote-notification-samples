//
//  MBSocialService.h
//  mobage-ndk
//
//  Created by ngmoco on 3/16/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBInterfaceEnums.h"
#import "MBError.h"
#import "MBBankUI.h"
@protocol MBUser;

/**
 * @file MBSocialService.h
 * Provides access to the Mobage user interface.
 * @since 1.5
 */

/**
 * Display components of the Mobage user interface. The following components are
 * available:
 * <ul>
 * <li>The Balance Button, which displays the user's balance of app-specific purchased
 * currency.</li>
 * <li>The Bank, which enables a user to check their balance of app-specific purchased currency or
 * buy additional currency.</li>
 * <li>The Friend Picker, which enables the app to retrieve a user-selected group of the user's
 * friends.</li>
 * <li>The Login Dialog, which enables the user to log into Mobage.</li>
 * <li>The Mobage Community user interface.</li>
 * <li>The User Profile screen, which shows a user's Mobage profile.</li>
 * </ul>
 * @since 1.5
 */
@protocol MBSocialService <NSObject>

/**
 * Open the User Profile screen for the specified Mobage user. Opening the current user's profile
 * allows the user to edit the profile.
 * <p>
 * Calling this method opens the Mobage user interface. The app is paused until the user returns to
 * the app.
 * @param user The user whose profile will be displayed.
 * @since 2.0
 */
+ (void)openUserProfile:(NSObject<MBUser>*)user;

/**
 * Open the Friend Picker, which enables the user to choose a list of their friends, with a maximum
 * number of friends that you specify. The user can select from their entire list of Mobage friends,
 * or they can select only from friends who have used the current app. The selected user IDs are
 * passed to the callback. If any of the selected friends are not using the current app, they will
 * be invited to do so, and the friends' user IDs are passed to the callback.
 * <p>
 * Calling this method will pause the app until the user exits the Friend Picker.
 * @param maxFriendsToSelect The maximum number of friends that the user may select. Use the value
 *      <code>0</code> to allow the user to select an unlimited number of friends.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>pickedFriends</code>: A list of friends that were chosen, or <code>nil</code> if the
 * user did not choose any friends.</li>
 * <li><code>invitedFriends</code>: A list of friends that were invited to try the current app, or
 * <code>nil</code> if no friends were invited.</li>
 * </ul>
 * @since 2.0
 */
+ (void)openFriendPicker:(NSInteger) maxFriendsToSelect
	   withCallbackQueue:(dispatch_queue_t)cbQueue
			  onComplete:(void (^)(MBDismissableAPIStatus status, NSObject<MBError> *error, NSArray* pickedFriends, NSArray* invitedFriends))completeCb;

/**
 * Open the Bank, which enables a user to check their balance of app-specific purchased currency or
 * buy additional currency.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * </ul>
 * @since 2.0
 */
+ (void)openBankDialogWithCallbackQueue:(dispatch_queue_t)cbQueue 
							 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * error))completeCb;

/**
 * Log the user into Mobage, displaying the Login Dialog if necessary.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * </ul>
 * @since 2.0
 */
+ (void)executeLoginWithCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError> *error))completeCb;

/**
 * Log the user into Mobage using the specified key-value pairs as configuration parameters, and
 * displaying the Login Dialog if necessary.
 * <p>
 * The only supported key is <code>LOGIN_OPTIONALITY</code>, which must be set to
 * <code>mandatory</code>.
 * @param keys Keys for configuring the login process.
 * @param values Values associated with the keys.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * </ul>
 * @since 2.0.1
 */
+ (void)executeLoginWithKeys:(NSArray*)keys values:(NSArray*)values withCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBCancelableAPIStatus status, NSObject<MBError> *error))completeCb;

/**
 * Log the user out of Mobage, and clear the current session.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * </ul>
 * @since 2.0
 */
+ (void)executeLogoutWithCallbackQueue:(dispatch_queue_t)cbQueue onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error))completeCb;

/**
 * Retrieve the Balance Button for the Mobage Bank, which displays the user's current balance of the
 * app-specific purchased currency and opens the Bank.
 * <p>
 * The Balance Button's minimum height is the largest of the following values:
 * <ul>
 * <li>50 pixels.</li>
 * <li>In landscape mode, 10% of the screen's height.</li>
 * <li>In portrait mode, 6% of the screen's height.</li>
 * </ul>
 * The Balance Button's width must be at least three times its height. For example, if the Balance
 * Button's minimum height is 50 pixels, its minimum width is 150 pixels.
 * @param rect The frame for the button.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>button</code>: The Balance Button, or <code>nil</code> if the Balance Button could not
 * be retrieved.</li>
 * </ul>
 * @since 2.0
 */
+ (MBBalanceButton *)getBalanceButton:(CGRect)rect
	   withCallbackQueue:(dispatch_queue_t)cbQueue
			  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * error, MBBalanceButton *button))completeCb;


+ (void)showBalanceButton:(int)x
						y:(int)y
					width:(int)width
				   height:(int)height
		withCallbackQueue:(dispatch_queue_t)cbQueue
			   onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> * error))completeCb;

+ (void)hideBalanceButton;

/**
 * Display the Mobage user interface. Your app must call this method when the user taps the
 * Community Button.
 * <p>
 * Calling this method will pause the app until the user exits the Mobage user interface.
 * @since 2.0
 */
+ (void)showCommunityUI;

#pragma mark - Deprecated
@optional
+ (void)openLoginDialog:(void (^)())loginCompleteCB 
			   onCancel:(void (^)())loginCancelCB 
                onError:(void (^)(MBError *error))errorCB											__attribute__((deprecated)) /*Deprecated in 1.9*/;

+ (void)openFriendPicker:(NSInteger) maxFriendsToSelect 
				onPicked:(void (^)(NSArray *userIds))pickedCB 
			onInviteSent:(void (^)(NSArray *userIds))inviteSentCB 
			   onDismiss:(void (^)())dismissCB 
                 onError:(void (^)(MBError *error))errorCB											__attribute__((deprecated)) /*Deprecated in 1.9*/;

+ (void)openBankDialog:(void (^)())dismissCB 
               onError:(void (^)(MBError *error))errorCB											__attribute__((deprecated)) /*Deprecated in 2.0*/;

+ (MBBalanceButton *)getBalanceButton:(CGRect)rect 
                                queue:(dispatch_queue_t)callbackQueue
                              onClick:(void (^)(MBBalanceButton *button))clickCB
                              onError:(void (^)(MBError *error))errorCB											__attribute__((deprecated)) /*Deprecated in 2.0*/;

@end
