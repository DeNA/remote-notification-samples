//
//  MBCSocialService.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCSOCIALSERVICE_H_
#define MBCSOCIALSERVICE_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"
#include "MBCUser.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	
	#pragma mark - Method Callbacks!
	/**
	 * MBCSocialService_openFriendPickerCallback
	 * @description 	 * Callback for retrieving the user's input from the Friend Picker.
	 * @cb-param MBCDismissableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * pickedFriends A list of friends that were chosen, or <c>null</c> if the user did not choose any friends.			AUTORELEASED
	 * @cb-param MBCUser_Array * invitedFriends A list of friends that were invited to try the current app, or <c>null</c> if no friends were invited.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_openFriendPickerCallback)(
				MBCDismissableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser_Array * pickedFriends,
				/*AUTORELEASED*/ MBCUser_Array * invitedFriends,
				
				void * context
																);
	/**
	 * MBCSocialService_openPlayerInviterCallback
	 * @description 
	 * @cb-param MBCCancelableAPIStatus status 			
	 * @cb-param MBCError * Error 			AUTORELEASED
	 */
	typedef void (*MBCSocialService_openPlayerInviterCallback)(
				MBCCancelableAPIStatus status,
				/*AUTORELEASED*/ MBCError * Error,
				
				void * context
																);
	/**
	 * MBCSocialService_executeLoginCallback
	 * @description 	 * Callback for logging the user into Mobage.
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_executeLoginCallback)(
				MBCCancelableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCSocialService_executeLoginWithParamsCallback
	 * @description 	 * Called after the request is completed.
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_executeLoginWithParamsCallback)(
				MBCCancelableAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCSocialService_executeLogoutCallback
	 * @description 	 * Callback for logging the user out of Mobage.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_executeLogoutCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCSocialService_openBankDialogCallback
	 * @description 	 * Callback for opening the Bank.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_openBankDialogCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCSocialService_showBalanceButtonCallback
	 * @description 	 * Callback for retrieving the Balance Button.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 */
	typedef void (*MBCSocialService_showBalanceButtonCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	
	#pragma mark - Static Methods
	/**
	 * MBCSocialService_openFriendPicker
	 * @function
	 * @public
	 * @description 	 * Open the Friend Picker, which enables the user to choose a list of their friends, with a maximum number of friends that you specify.
	 * The user can select from their entire list of Mobage friends, or they can select only from
	 * friends who have used the current app. The selected users are passed to the callback. If any
	 * of the selected friends are not using the current app, they will be invited to do so, and the
	 * selected friends are passed to the callback.
	 * <p>
	 * Calling this method will pause the app until the user exits the Friend Picker.
	 *
	 * @param int32_t  maxFriendsToSelect The maximum number of friends that the user may select. Use the value <c>0</c> to allow the user to select an unlimited number of friends.			
	 * @cb OpenFriendPickerOnCompleteCallback  onComplete 
	 * Open the Friend Picker, which enables the user to choose a list of their friends, with a maximum number of friends that you specify.
	 * The user can select from their entire list of Mobage friends, or they can select only from
	 * friends who have used the current app. The selected users are passed to the callback. If any
	 * of the selected friends are not using the current app, they will be invited to do so, and the
	 * selected friends are passed to the callback.
	 * <p>
	 * Calling this method will pause the app until the user exits the Friend Picker.
	 			
	 * @cb-param MBCDismissableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCUser_Array * pickedFriends A list of friends that were chosen, or <c>null</c> if the user did not choose any friends.			AUTORELEASED
	 * @cb-param MBCUser_Array * invitedFriends A list of friends that were invited to try the current app, or <c>null</c> if no friends were invited.			AUTORELEASED
	 * <br/>
	 */
	void MBCSocialService_openFriendPicker(
										int32_t  maxFriendsToSelect,
										MBCSocialService_openFriendPickerCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#if MB_WW
	/**
	 * MBCSocialService_openPlayerInviter
	 * @function
	 * @public
	 * @description 	 Opens the player inviter
	 *
	 * @cb OpenPlayerInviterOnCompleteCallback  onComplete  Opens the player inviter			
	 * @cb-param MBCCancelableAPIStatus status 			
	 * @cb-param MBCError * Error 			AUTORELEASED
	 * <br/>
	 */
	void MBCSocialService_openPlayerInviter(
										MBCSocialService_openPlayerInviterCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_WW
	/**
	 * MBCSocialService_executeLogin
	 * @function
	 * @public
	 * @description 	 * Log the user into Mobage, displaying the Login Dialog if necessary.
	 *
	 * @cb ExecuteLoginOnCompleteCallback  onComplete 
	 * Log the user into Mobage, displaying the Login Dialog if necessary.
	 			
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 */
	void MBCSocialService_executeLogin(
										MBCSocialService_executeLoginCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_executeLoginWithParams
	 * @function
	 * @public
	 * @description 	 * Log the user into Mobage using the specified key-value pairs as configuration parameters, and displaying the Login Dialog if necessary.
	 * <p>
	 * The only supported key is <c>LOGIN_OPTIONALITY</c>, which must be set to <c>mandatory</c>.
	 *
	 * @param MBCString_Array *  keys Keys for configuring the login process.			AUTORELEASED
	 * @param MBCString_Array *  values Values associated with the keys.			AUTORELEASED
	 * @cb ExecuteLoginWithParamsOnCompleteCallback  onComplete 
	 * Log the user into Mobage using the specified key-value pairs as configuration parameters, and displaying the Login Dialog if necessary.
	 * <p>
	 * The only supported key is <c>LOGIN_OPTIONALITY</c>, which must be set to <c>mandatory</c>.
	 			
	 * @cb-param MBCCancelableAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 */
	void MBCSocialService_executeLoginWithParams(
										MBCString_Array *  keys,
										MBCString_Array *  values,
										MBCSocialService_executeLoginWithParamsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_executeLogout
	 * @function
	 * @public
	 * @description 	 * Log the user out of Mobage, and clear the current session.
	 *
	 * @cb ExecuteLogoutOnCompleteCallback  onComplete 
	 * Log the user out of Mobage, and clear the current session.
	 			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 */
	void MBCSocialService_executeLogout(
										MBCSocialService_executeLogoutCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_openUserProfile
	 * @function
	 * @public
	 * @description 	 * Open the User Profile screen for the specified Mobage user.
	 * Opening the current user's profile allows the user to edit the profile.
	 * <p>
	 * Calling this method opens the Mobage user interface. The app is paused until the user returns
	 * to the app.
	 * <p>
	 * <strong>Note</strong>: In version 2.0, you can only display the current user's profile.
	 *
	 * @param MBCUser *  user The user whose profile will be displayed. <strong>Note</strong>: In version 2.0, you can only display the current user's profile.			AUTORELEASED
	 * <br/>
	 */
	void MBCSocialService_openUserProfile(
										MBCUser *  user,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_showCommunityUI
	 * @function
	 * @public
	 * @description 	 * Display the Mobage user interface.
	 * Your app must call this method when the user taps the Community Button.
	 * <p>
	 * Calling this method will pause the app until the user exits the Mobage user interface.
	 *
	 * <br/>
	 */
	void MBCSocialService_showCommunityUI(
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_openBankDialog
	 * @function
	 * @public
	 * @description 	 * Open the Bank, which enables a user to check their balance of purchased currency or buy additional currency.
	 *
	 * @cb OpenBankDialogOnCompleteCallback  onComplete 
	 * Open the Bank, which enables a user to check their balance of purchased currency or buy additional currency.
	 			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 */
	void MBCSocialService_openBankDialog(
										MBCSocialService_openBankDialogCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_showBalanceButton
	 * @function
	 * @public
	 * @description 	 * Retrieve the Balance Button for the Mobage Bank, which displays the user's current balance of purchased currency and opens the Bank.
	 * The Balance Button's minimum height is the largest of the following values:
	 * <ul>
	 * <li>50 pixels.</li>
	 * <li>In landscape mode, 10% of the screen's height.</li>
	 * <li>In portrait mode, 6% of the screen's height.</li>
	 * </ul>
	 * The Balance Button's width must be at least three times its height. For example, if the
	 * Balance Button's minimum height is 50 pixels, its minimum width is 150 pixels.
	 *
	 * @param int32_t  x The X coordinate at which to place the Balance Button's upper left corner.			
	 * @param int32_t  y The Y coordinate at which to place the Balance Button's upper left corner.			
	 * @param int32_t  width The width of the Balance Button.			
	 * @param int32_t  height The height of the Balance Button.			
	 * @cb ShowBalanceButtonOnCompleteCallback  onComplete 
	 * Retrieve the Balance Button for the Mobage Bank, which displays the user's current balance of purchased currency and opens the Bank.
	 * The Balance Button's minimum height is the largest of the following values:
	 * <ul>
	 * <li>50 pixels.</li>
	 * <li>In landscape mode, 10% of the screen's height.</li>
	 * <li>In portrait mode, 6% of the screen's height.</li>
	 * </ul>
	 * The Balance Button's width must be at least three times its height. For example, if the
	 * Balance Button's minimum height is 50 pixels, its minimum width is 150 pixels.
	 			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * <br/>
	 */
	void MBCSocialService_showBalanceButton(
										int32_t  x,
										int32_t  y,
										int32_t  width,
										int32_t  height,
										MBCSocialService_showBalanceButtonCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCSocialService_hideBalanceButton
	 * @function
	 * @public
	 * @description 	 * Hide the Balance Button for the Mobage Bank.
	 *
	 * <br/>
	 */
	void MBCSocialService_hideBalanceButton(
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );


#ifdef __cplusplus
}
#endif

#endif /* MBCSOCIALSERVICE_H_ */

