//
//  SocialService.cs
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
// Mobage don't support Unity Editor right now. (add "-define:HAS_MOBAGE_DESKTOP_SHIM" to /Assets/smcs.rsp to override)

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Mobage {

	/**
	 * <summary> Display components of the Mobage user interface.</summary>
	 * <remarks>
	 * The following components are available:
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
	 * </remarks>
	 */
	public partial class SocialService {}

#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class SocialService {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openFriendPicker(Int32 input_maxFriendsToSelect, openFriendPicker_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#if MB_WW
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openPlayerInviter(openPlayerInviter_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_WW
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_executeLogin(executeLogin_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_executeLoginWithParams(IntPtr input_keys, IntPtr input_values, executeLoginWithParams_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_executeLogout(executeLogout_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openUserProfile(IntPtr input_user, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_showCommunityUI(IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_openBankDialog(openBankDialog_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_showBalanceButton(Int32 input_x, Int32 input_y, Int32 input_width, Int32 input_height, showBalanceButton_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCSocialService_hideBalanceButton(IntPtr context);
	
	}
#endregion
#region Native Return Points
	public partial class SocialService {
		private delegate void openFriendPicker_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_pickedFriends, IntPtr input_invitedFriends, IntPtr context);
		[MonoPInvokeCallback (typeof (openFriendPicker_onCompleteCallbackDispatcherDelegate))]
		private static void openFriendPicker_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_pickedFriends, IntPtr input_invitedFriends, IntPtr context)
		{
			DismissableAPIStatus status = Convert.toCS_DismissableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<User> pickedFriends = null;
			if (input_pickedFriends != IntPtr.Zero){
				pickedFriends = Convert.toCS_User_Array(input_pickedFriends);
			}
			List<User> invitedFriends = null;
			if (input_invitedFriends != IntPtr.Zero){
				invitedFriends = Convert.toCS_User_Array(input_invitedFriends);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("openFriendPicker callback about to invoke!");
				try {
					openFriendPicker_onCompleteCallback del = (openFriendPicker_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  pickedFriends,  invitedFriends );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("openFriendPicker finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void openPlayerInviter_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_Error, IntPtr context);
		[MonoPInvokeCallback (typeof (openPlayerInviter_onCompleteCallbackDispatcherDelegate))]
		private static void openPlayerInviter_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_Error, IntPtr context)
		{
			CancelableAPIStatus status = Convert.toCS_CancelableAPIStatus(input_status);
			Error Error = null;
			if (input_Error != IntPtr.Zero){
				Error = Convert.toCS_Error(input_Error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("openPlayerInviter callback about to invoke!");
				try {
					openPlayerInviter_onCompleteCallback del = (openPlayerInviter_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  Error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("openPlayerInviter finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void executeLogin_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (executeLogin_onCompleteCallbackDispatcherDelegate))]
		private static void executeLogin_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			CancelableAPIStatus status = Convert.toCS_CancelableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("executeLogin callback about to invoke!");
				try {
					executeLogin_onCompleteCallback del = (executeLogin_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("executeLogin finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void executeLoginWithParams_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (executeLoginWithParams_onCompleteCallbackDispatcherDelegate))]
		private static void executeLoginWithParams_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			CancelableAPIStatus status = Convert.toCS_CancelableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("executeLoginWithParams callback about to invoke!");
				try {
					executeLoginWithParams_onCompleteCallback del = (executeLoginWithParams_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("executeLoginWithParams finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void executeLogout_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (executeLogout_onCompleteCallbackDispatcherDelegate))]
		private static void executeLogout_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("executeLogout callback about to invoke!");
				try {
					executeLogout_onCompleteCallback del = (executeLogout_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("executeLogout finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void openBankDialog_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (openBankDialog_onCompleteCallbackDispatcherDelegate))]
		private static void openBankDialog_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("openBankDialog callback about to invoke!");
				try {
					openBankDialog_onCompleteCallback del = (openBankDialog_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("openBankDialog finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void showBalanceButton_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (showBalanceButton_onCompleteCallbackDispatcherDelegate))]
		private static void showBalanceButton_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("showBalanceButton callback about to invoke!");
				try {
					showBalanceButton_onCompleteCallback del = (showBalanceButton_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("showBalanceButton finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion



#region Delegate Callbacks
	public partial class SocialService {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
		/**
		 * <summary> Callback for retrieving the user's input from the Friend Picker.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.DismissableAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="pickedFriends" cref="F:System.Collections.Generic.List<Mobage.User>">A list of friends that were chosen, or <c>null</c> if the user did not choose any friends.</param>
		 * <param name="invitedFriends" cref="F:System.Collections.Generic.List<Mobage.User>">A list of friends that were invited to try the current app, or <c>null</c> if no friends were invited.</param>
		 */
		public delegate void openFriendPicker_onCompleteCallback(DismissableAPIStatus status, Error error, List<User> pickedFriends, List<User> invitedFriends);
		/**
		 * <summary></summary>
		 * <remarks>

		 * </remarks>
		 * <param name="status" cref="F:Mobage.CancelableAPIStatus"></param>
		 * <param name="Error" cref="F:Mobage.Error"></param>
		 */
		public delegate void openPlayerInviter_onCompleteCallback(CancelableAPIStatus status, Error Error);
		/**
		 * <summary> Callback for logging the user into Mobage.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.CancelableAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void executeLogin_onCompleteCallback(CancelableAPIStatus status, Error error);
		/**
		 * <summary> Called after the request is completed.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.CancelableAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void executeLoginWithParams_onCompleteCallback(CancelableAPIStatus status, Error error);
		/**
		 * <summary> Callback for logging the user out of Mobage.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void executeLogout_onCompleteCallback(SimpleAPIStatus status, Error error);
		/**
		 * <summary> Callback for opening the Bank.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void openBankDialog_onCompleteCallback(SimpleAPIStatus status, Error error);
		/**
		 * <summary> Callback for retrieving the Balance Button.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void showBalanceButton_onCompleteCallback(SimpleAPIStatus status, Error error);
	}
#endregion

#region Static Methods
	public partial class SocialService {
		/**
		 * <summary> Open the Friend Picker, which enables the user to choose a list of their friends, with a maximum number of friends that you specify.</summary>
		 * <remarks>
		 * The user can select from their entire list of Mobage friends, or they can select only from
		 * friends who have used the current app. The selected users are passed to the callback. If any
		 * of the selected friends are not using the current app, they will be invited to do so, and the
		 * selected friends are passed to the callback.
		 * <p>
		 * Calling this method will pause the app until the user exits the Friend Picker.
		 * </remarks>
		 * <param name="maxFriendsToSelect" cref="F:System.Int32">The maximum number of friends that the user may select. Use the value <c>0</c> to allow the user to select an unlimited number of friends.</param>
		 * <param name="onComplete" cref="F:Mobage.OpenFriendPickerOnCompleteCallback">
		 * Callback for retrieving the user's input from the Friend Picker.</param>
		 */
		public static void openFriendPicker(Int32 maxFriendsToSelect, openFriendPicker_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			Int32 out_maxFriendsToSelect = maxFriendsToSelect;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_openFriendPicker(out_maxFriendsToSelect, openFriendPicker_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
#if MB_WW
		/**
		 * <summary></summary>
		 * <remarks>

		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.OpenPlayerInviterOnCompleteCallback">
</param>
		 */
		public static void openPlayerInviter(openPlayerInviter_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_openPlayerInviter(openPlayerInviter_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
#endif // MB_WW
		/**
		 * <summary> Log the user into Mobage, displaying the Login Dialog if necessary.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.ExecuteLoginOnCompleteCallback">
		 * Callback for logging the user into Mobage.</param>
		 */
		public static void executeLogin(executeLogin_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_executeLogin(executeLogin_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		/**
		 * <summary> Log the user into Mobage using the specified key-value pairs as configuration parameters, and displaying the Login Dialog if necessary.</summary>
		 * <remarks>
		 * <p>
		 * The only supported key is <c>LOGIN_OPTIONALITY</c>, which must be set to <c>mandatory</c>.
		 * </remarks>
		 * <param name="keys" cref="F:System.Collections.Generic.List<System.String>">Keys for configuring the login process.</param>
		 * <param name="values" cref="F:System.Collections.Generic.List<System.String>">Values associated with the keys.</param>
		 * <param name="onComplete" cref="F:Mobage.ExecuteLoginWithParamsOnCompleteCallback">
		 * Called after the request is completed.</param>
		 */
		public static void executeLoginWithParams(List<String> keys, List<String> values, executeLoginWithParams_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_keys = (IntPtr)Convert.toC(keys);

			IntPtr out_values = (IntPtr)Convert.toC(values);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_executeLoginWithParams(out_keys, out_values, executeLoginWithParams_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_keys);
			Marshal.FreeHGlobal(out_values);
		}
		/**
		 * <summary> Log the user out of Mobage, and clear the current session.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.ExecuteLogoutOnCompleteCallback">
		 * Callback for logging the user out of Mobage.</param>
		 */
		public static void executeLogout(executeLogout_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_executeLogout(executeLogout_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		/**
		 * <summary> Open the User Profile screen for the specified Mobage user.</summary>
		 * <remarks>
		 * Opening the current user's profile allows the user to edit the profile.
		 * <p>
		 * Calling this method opens the Mobage user interface. The app is paused until the user returns
		 * to the app.
		 * <p>
		 * <strong>Note</strong>: In version 2.0, you can only display the current user's profile.
		 * </remarks>
		 * <param name="user" cref="F:Mobage.User">The user whose profile will be displayed. <strong>Note</strong>: In version 2.0, you can only display the current user's profile.</param>
		 */
		public static void openUserProfile(User user)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_user = (IntPtr)Convert.toC(user);

			MBCSocialService_openUserProfile(out_user, new IntPtr(cbId));
			
			// Free memory used for parameters
			User.MBCReleaseUser(out_user);
		}
		/**
		 * <summary> Display the Mobage user interface.</summary>
		 * <remarks>
		 * Your app must call this method when the user taps the Community Button.
		 * <p>
		 * Calling this method will pause the app until the user exits the Mobage user interface.
		 * </remarks>
		 */
		public static void showCommunityUI()
		{
			int cbId = (cbUidGenerator++);
			MBCSocialService_showCommunityUI(new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		/**
		 * <summary> Open the Bank, which enables a user to check their balance of purchased currency or buy additional currency.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.OpenBankDialogOnCompleteCallback">
		 * Callback for opening the Bank.</param>
		 */
		public static void openBankDialog(openBankDialog_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_openBankDialog(openBankDialog_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		/**
		 * <summary> Retrieve the Balance Button for the Mobage Bank, which displays the user's current balance of purchased currency and opens the Bank.</summary>
		 * <remarks>
		 * The Balance Button's minimum height is the largest of the following values:
		 * <ul>
		 * <li>50 pixels.</li>
		 * <li>In landscape mode, 10% of the screen's height.</li>
		 * <li>In portrait mode, 6% of the screen's height.</li>
		 * </ul>
		 * The Balance Button's width must be at least three times its height. For example, if the
		 * Balance Button's minimum height is 50 pixels, its minimum width is 150 pixels.
		 * </remarks>
		 * <param name="x" cref="F:System.Int32">The X coordinate at which to place the Balance Button's upper left corner.</param>
		 * <param name="y" cref="F:System.Int32">The Y coordinate at which to place the Balance Button's upper left corner.</param>
		 * <param name="width" cref="F:System.Int32">The width of the Balance Button.</param>
		 * <param name="height" cref="F:System.Int32">The height of the Balance Button.</param>
		 * <param name="onComplete" cref="F:Mobage.ShowBalanceButtonOnCompleteCallback">
		 * Callback for retrieving the Balance Button.</param>
		 */
		public static void showBalanceButton(Int32 x, Int32 y, Int32 width, Int32 height, showBalanceButton_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			Int32 out_x = x;

			Int32 out_y = y;

			Int32 out_width = width;

			Int32 out_height = height;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCSocialService_showBalanceButton(out_x, out_y, out_width, out_height, showBalanceButton_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		/**
		 * <summary> Hide the Balance Button for the Mobage Bank.</summary>
		 * <remarks>
		 
		 * </remarks>
		 */
		public static void hideBalanceButton()
		{
			int cbId = (cbUidGenerator++);
			MBCSocialService_hideBalanceButton(new IntPtr(cbId));
			
			// Free memory used for parameters
		}
	}
#endregion


}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
