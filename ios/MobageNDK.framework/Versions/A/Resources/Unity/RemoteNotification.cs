//
//  RemoteNotification.cs
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
	 * <summary> Enables an app to send remote notifications, also known as push notifications, to another Mobage user.</summary>
	 * <remarks>
	 * For example, you could send a remote notification to user A saying that user B had visited their
	 * kingdom.
	 * <p>
	 * <strong>Note</strong>: Mobage enables remote notifications for your app when the app is
	 * published. Remote notifications are not enabled in the sandbox environment.
	 * <p>
	 * Examples of legitimate uses of this class include:
	 * <ul>
	 * <li>Inviting a user to the current app.</li>
	 * <li>Sending notifications announcing asynchronous app events.</li>
	 * <li>Announcing a user-initiated invitation or challenge.</li>
	 * <li>Promoting app features that a user has not yet explicitly engaged.</li>
	 * </ul>
	 * Examples of notifications that do not comply with Mobage platform policies include:
	 * <ul>
	 * <li>An excessive number of notifications sent by a single app. Your account may be
	 * throttled or suspended if your app sends an excessive number of notifications.</li>
	 * <li>Notifications promoting other apps.</li>
	 * <li>Notifications generated on behalf of a user that are not explicitly approved by the
	 * user.</li>
	 * </ul>
	 * As you develop your app, keep the following limitations in mind:
	 * <ul>
	 * <li>Remote notifications may take a long time to arrive, and there is no guarantee that users
	 * will receive them.</li>
	 * <li>If a user dismisses the remote notification, rather than tapping on it, the payload will not
	 * be delivered to the app.</li>
	 * <li>If an app sends multiple remote notifications, the user may receive only the most recent
	 * notification.</li>
	 * </ul>
	 * <strong>Important</strong>: Do not use remote notifications to provide features that require
	 * reliable messaging, such as delivery of a virtual item.
	 * </remarks>
	 */
	public partial class RemoteNotification {}

#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class RemoteNotification {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCRemoteNotification_sendToUser(IntPtr input_user, IntPtr input_message, Int32 input_badge, IntPtr input_sound, IntPtr input_collapseKey, IntPtr input_style, IntPtr input_iconUrl, IntPtr input_extrasKeys, IntPtr input_extrasValues, sendToUser_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCRemoteNotification_getRemoteNotificationsEnabled(getRemoteNotificationsEnabled_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCRemoteNotification_setRemoteNotificationsEnabled(bool input_enabled, setRemoteNotificationsEnabled_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion
#region Native Return Points
	public partial class RemoteNotification {
		private delegate void sendToUser_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_response, IntPtr context);
		[MonoPInvokeCallback (typeof (sendToUser_onCompleteCallbackDispatcherDelegate))]
		private static void sendToUser_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_response, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			RemoteNotificationResponse response = null;
			if (input_response != IntPtr.Zero){
				response = Convert.toCS_RemoteNotificationResponse(input_response);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("sendToUser callback about to invoke!");
				try {
					sendToUser_onCompleteCallback del = (sendToUser_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  response );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("sendToUser finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getRemoteNotificationsEnabled_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, bool input_canBeNotified, IntPtr context);
		[MonoPInvokeCallback (typeof (getRemoteNotificationsEnabled_onCompleteCallbackDispatcherDelegate))]
		private static void getRemoteNotificationsEnabled_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, bool input_canBeNotified, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			bool canBeNotified = input_canBeNotified;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getRemoteNotificationsEnabled callback about to invoke!");
				try {
					getRemoteNotificationsEnabled_onCompleteCallback del = (getRemoteNotificationsEnabled_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  canBeNotified );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getRemoteNotificationsEnabled finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void setRemoteNotificationsEnabled_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (setRemoteNotificationsEnabled_onCompleteCallbackDispatcherDelegate))]
		private static void setRemoteNotificationsEnabled_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("setRemoteNotificationsEnabled callback about to invoke!");
				try {
					setRemoteNotificationsEnabled_onCompleteCallback del = (setRemoteNotificationsEnabled_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("setRemoteNotificationsEnabled finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion



#region Delegate Callbacks
	public partial class RemoteNotification {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
		/**
		 * <summary> Callback for sending a remote notification.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="response" cref="F:Mobage.RemoteNotificationResponse">Information about the Mobage server's response, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void sendToUser_onCompleteCallback(SimpleAPIStatus status, Error error, RemoteNotificationResponse response);
		/**
		 * <summary> Callback for checking whether the current user can receive remote notifications for the current app.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="canBeNotified" cref="F:System.bool">Set to <c>true</c> if notifications are enabled or <c>false</c> if notifications are disabled.</param>
		 */
		public delegate void getRemoteNotificationsEnabled_onCompleteCallback(SimpleAPIStatus status, Error error, bool canBeNotified);
		/**
		 * <summary> Callback for setting whether the current user can receive remote notifications for the current app.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void setRemoteNotificationsEnabled_onCompleteCallback(SimpleAPIStatus status, Error error);
	}
#endregion

#region Static Methods
	public partial class RemoteNotification {
		/**
		 * <summary> Send a remote notification to another Mobage user.</summary>
		 * <remarks>
		 * The remote notification is queued on the Mobage server and may not be sent immediately. The
		 * maximum size of the notification's content is 256 bytes.
		 * <p>
		 * The notification can include app-specific key/value pairs that trigger a special behavior in
		 * your app, such as displaying a message to the user on launch. These key/value pairs are
		 * stored in the <c>extrasKeys</c> and <c>extrasValues</c> properties.
		 * <p>
		 * <strong>Note</strong>: Some parameters are used only on Android or iOS, but not both. The
		 * Mobage server automatically discards any parameters that are not supported by the target
		 * user's device. Discarded parameters do not count towards the 256-byte limit.
		 * </remarks>
		 * <param name="user" cref="F:Mobage.User">The notification's recipient.</param>
		 * <param name="message" cref="F:System.String">The notification message.</param>
		 * <param name="badge" cref="F:System.Int32">The numeric badge to display on the app's icon. Used only on iOS.</param>
		 * <param name="sound" cref="F:System.String">The alert sound to play. This property must contain the name of a sound file in the application bundle, or <c>default</c> to play the default alert sound. The sound file must be in a format that is supported for system sounds. Used only on iOS.</param>
		 * <param name="collapseKey" cref="F:System.String">An identifier that causes newer notifications with the same identifier to be discarded. For example, if a user receives four notifications with the same identifier, only the newest notification will be displayed on the user's device. Used only on Android.</param>
		 * <param name="style" cref="F:System.String">The layout style for the notification in the device's notification tray. Set to <c>normal</c> to display a standard-size icon or <c>largeIcon</c> to display a large icon. Used only on Android.</param>
		 * <param name="iconUrl" cref="F:System.String">The URL for the icon to display in the device's notification bar. This value is ignored unless you also use the <c>style</c> parameter to specify the layout style. Used only on Android.</param>
		 * <param name="extrasKeys" cref="F:System.Collections.Generic.List<System.String>">The app-specific keys to include in the payload. Each key must be represented as a string. The following key names are reserved and cannot be used:<ul><li><c>badge</c></li><li><c>collapseKey</c></li><li><c>extras</c></li><li><c>iconUrl</c></li><li><c>message</c></li><li><c>sound</c></li><li><c>style</c></li></ul></param>
		 * <param name="extrasValues" cref="F:System.Collections.Generic.List<System.String>">The app-specific values to include in the payload. Each value must be represented as a string.</param>
		 * <param name="onComplete" cref="F:Mobage.SendToUserOnCompleteCallback">
		 * Callback for sending a remote notification.</param>
		 */
		public static void sendToUser(User user, String message, Int32 badge, String sound, String collapseKey, String style, String iconUrl, List<String> extrasKeys, List<String> extrasValues, sendToUser_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_user = (IntPtr)Convert.toC(user);

			IntPtr out_message = (IntPtr)Convert.toC(message);

			Int32 out_badge = badge;

			IntPtr out_sound = (IntPtr)Convert.toC(sound);

			IntPtr out_collapseKey = (IntPtr)Convert.toC(collapseKey);

			IntPtr out_style = (IntPtr)Convert.toC(style);

			IntPtr out_iconUrl = (IntPtr)Convert.toC(iconUrl);

			IntPtr out_extrasKeys = (IntPtr)Convert.toC(extrasKeys);

			IntPtr out_extrasValues = (IntPtr)Convert.toC(extrasValues);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCRemoteNotification_sendToUser(out_user, out_message, out_badge, out_sound, out_collapseKey, out_style, out_iconUrl, out_extrasKeys, out_extrasValues, sendToUser_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			User.MBCReleaseUser(out_user);
			Marshal.FreeHGlobal(out_message);
			Marshal.FreeHGlobal(out_sound);
			Marshal.FreeHGlobal(out_collapseKey);
			Marshal.FreeHGlobal(out_style);
			Marshal.FreeHGlobal(out_iconUrl);
			Marshal.FreeHGlobal(out_extrasKeys);
			Marshal.FreeHGlobal(out_extrasValues);
		}
		/**
		 * <summary> Check whether the current user can receive remote notifications for the current app.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.GetRemoteNotificationsEnabledOnCompleteCallback">
		 * Callback for checking whether the current user can receive remote notifications for the current app.</param>
		 */
		public static void getRemoteNotificationsEnabled(getRemoteNotificationsEnabled_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCRemoteNotification_getRemoteNotificationsEnabled(getRemoteNotificationsEnabled_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		/**
		 * <summary> Set whether the current user can receive remote notifications for the current app.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="enabled" cref="F:System.bool">Set to <c>true</c> to enable notifications or <c>false</c> to disable notifications.</param>
		 * <param name="onComplete" cref="F:Mobage.SetRemoteNotificationsEnabledOnCompleteCallback">
		 * Callback for setting whether the current user can receive remote notifications for the current app.</param>
		 */
		public static void setRemoteNotificationsEnabled(bool enabled, setRemoteNotificationsEnabled_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			bool out_enabled = enabled;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCRemoteNotification_setRemoteNotificationsEnabled(out_enabled, setRemoteNotificationsEnabled_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
	}
#endregion


}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
