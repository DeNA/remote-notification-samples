//
//  Blacklist.cs
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
	 * <summary> Retrieves and searches a user's blacklist, which lists the Mobage users that a user has blocked.</summary>
	 * <remarks>
	 
	 * </remarks>
	 */
	public partial class Blacklist {}

#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class Blacklist {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBlacklist_fetchBlacklistOfUser(IntPtr input_user, Int32 input_howMany, Int32 input_startOffset, fetchBlacklistOfUser_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBlacklist_checkBlacklistOfUserForUser(IntPtr input_user, IntPtr input_targetUser, checkBlacklistOfUserForUser_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion
#region Native Return Points
	public partial class Blacklist {
		private delegate void fetchBlacklistOfUser_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_blacklistedUsers, Int32 input_startOffset, Int32 input_totalPossibleResultCount, IntPtr context);
		[MonoPInvokeCallback (typeof (fetchBlacklistOfUser_onCompleteCallbackDispatcherDelegate))]
		private static void fetchBlacklistOfUser_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_blacklistedUsers, Int32 input_startOffset, Int32 input_totalPossibleResultCount, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<User> blacklistedUsers = null;
			if (input_blacklistedUsers != IntPtr.Zero){
				blacklistedUsers = Convert.toCS_User_Array(input_blacklistedUsers);
			}
			Int32 startOffset = input_startOffset;
			Int32 totalPossibleResultCount = input_totalPossibleResultCount;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("fetchBlacklistOfUser callback about to invoke!");
				try {
					fetchBlacklistOfUser_onCompleteCallback del = (fetchBlacklistOfUser_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  blacklistedUsers,  startOffset,  totalPossibleResultCount );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("fetchBlacklistOfUser finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void checkBlacklistOfUserForUser_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, bool input_isBlacklisted, IntPtr context);
		[MonoPInvokeCallback (typeof (checkBlacklistOfUserForUser_onCompleteCallbackDispatcherDelegate))]
		private static void checkBlacklistOfUserForUser_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, bool input_isBlacklisted, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			bool isBlacklisted = input_isBlacklisted;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("checkBlacklistOfUserForUser callback about to invoke!");
				try {
					checkBlacklistOfUserForUser_onCompleteCallback del = (checkBlacklistOfUserForUser_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  isBlacklisted );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("checkBlacklistOfUserForUser finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion



#region Delegate Callbacks
	public partial class Blacklist {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
		/**
		 * <summary> Callback for retrieving a user's entire blacklist.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="blacklistedUsers" cref="F:System.Collections.Generic.List<Mobage.User>">An array of <c>User</c> objects representing blacklisted users, or <c>null</c> if the request did not succeed.</param>
		 * <param name="startOffset" cref="F:System.Int32">The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.</param>
		 * <param name="totalPossibleResultCount" cref="F:System.Int32">The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void fetchBlacklistOfUser_onCompleteCallback(SimpleAPIStatus status, Error error, List<User> blacklistedUsers, Int32 startOffset, Int32 totalPossibleResultCount);
		/**
		 * <summary> Callback for checking whether a user's blacklist contains a specified user.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="isBlacklisted" cref="F:System.bool">Set to <c>true</c> if the target user is on the user's blacklist or <c>false</c> if the target user is not on the blacklist.</param>
		 */
		public delegate void checkBlacklistOfUserForUser_onCompleteCallback(SimpleAPIStatus status, Error error, bool isBlacklisted);
	}
#endregion

#region Static Methods
	public partial class Blacklist {
		/**
		 * <summary> Retrieve a user's entire blacklist.</summary>
		 * <remarks>
		 * You can use the <c>howMany</c> and <c>startOffset</c> parameters to control the
		 * number of results that this method retrieves, as well as the start index for the search
		 * results.
		 * </remarks>
		 * <param name="user" cref="F:Mobage.User">The user who owns the blacklist.</param>
		 * <param name="howMany" cref="F:System.Int32">The number of results to retrieve. The default value is <c>50</c>.</param>
		 * <param name="startOffset" cref="F:System.Int32">The start index for the search results. The default value is <c>1</c>. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.FetchBlacklistOfUserOnCompleteCallback">
		 * Callback for retrieving a user's entire blacklist.</param>
		 */
		public static void fetchBlacklistOfUser(User user, Int32 howMany, Int32 startOffset, fetchBlacklistOfUser_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_user = (IntPtr)Convert.toC(user);

			Int32 out_howMany = howMany;

			Int32 out_startOffset = startOffset;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBlacklist_fetchBlacklistOfUser(out_user, out_howMany, out_startOffset, fetchBlacklistOfUser_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			User.MBCReleaseUser(out_user);
		}
		/**
		 * <summary> Check whether a user's blacklist contains a specified user.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="user" cref="F:Mobage.User">The user whose blacklist will be checked.</param>
		 * <param name="targetUser" cref="F:Mobage.User">The user to search for in the blacklist.</param>
		 * <param name="onComplete" cref="F:Mobage.CheckBlacklistOfUserForUserOnCompleteCallback">
		 * Callback for checking whether a user's blacklist contains a specified user.</param>
		 */
		public static void checkBlacklistOfUserForUser(User user, User targetUser, checkBlacklistOfUserForUser_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_user = (IntPtr)Convert.toC(user);

			IntPtr out_targetUser = (IntPtr)Convert.toC(targetUser);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBlacklist_checkBlacklistOfUserForUser(out_user, out_targetUser, checkBlacklistOfUserForUser_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			User.MBCReleaseUser(out_user);
			User.MBCReleaseUser(out_targetUser);
		}
	}
#endregion


}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
