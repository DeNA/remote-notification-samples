//
//  People.cs
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
	 * <summary> Retrieve information about Mobage users, including their personal information and their friends.</summary>
	 * <remarks>
	 * A user's network of friends is sometimes referred to as the user's "social graph."
	 * <p>
	 * <strong>Note</strong>: The user must log into Mobage before your app uses the <c>People</c>
	 * APIs.
	 * </remarks>
	 */
	public partial class People {}

#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class People {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCPeople_getCurrentUser(getCurrentUser_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCPeople_getUserForId(IntPtr input_userId, getUserForId_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCPeople_getUsersForIds(IntPtr input_userIds, getUsersForIds_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCPeople_getFriendsForUser(IntPtr input_user, Int32 input_howMany, Int32 input_offset, getFriendsForUser_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCPeople_getFriendsWithGameForUser(IntPtr input_user, Int32 input_howMany, Int32 input_offset, getFriendsWithGameForUser_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion
#region Native Return Points
	public partial class People {
		private delegate void getCurrentUser_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_currentUser, IntPtr context);
		[MonoPInvokeCallback (typeof (getCurrentUser_onCompleteCallbackDispatcherDelegate))]
		private static void getCurrentUser_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_currentUser, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			User currentUser = null;
			if (input_currentUser != IntPtr.Zero){
				currentUser = Convert.toCS_User(input_currentUser);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getCurrentUser callback about to invoke!");
				try {
					getCurrentUser_onCompleteCallback del = (getCurrentUser_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  currentUser );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getCurrentUser finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getUserForId_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_user, IntPtr context);
		[MonoPInvokeCallback (typeof (getUserForId_onCompleteCallbackDispatcherDelegate))]
		private static void getUserForId_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_user, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			User user = null;
			if (input_user != IntPtr.Zero){
				user = Convert.toCS_User(input_user);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getUserForId callback about to invoke!");
				try {
					getUserForId_onCompleteCallback del = (getUserForId_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  user );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getUserForId finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getUsersForIds_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_users, IntPtr context);
		[MonoPInvokeCallback (typeof (getUsersForIds_onCompleteCallbackDispatcherDelegate))]
		private static void getUsersForIds_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_users, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<User> users = null;
			if (input_users != IntPtr.Zero){
				users = Convert.toCS_User_Array(input_users);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getUsersForIds callback about to invoke!");
				try {
					getUsersForIds_onCompleteCallback del = (getUsersForIds_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  users );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getUsersForIds finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getFriendsForUser_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_users, Int32 input_startOffset, Int32 input_totalPossibleResultCount, IntPtr context);
		[MonoPInvokeCallback (typeof (getFriendsForUser_onCompleteCallbackDispatcherDelegate))]
		private static void getFriendsForUser_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_users, Int32 input_startOffset, Int32 input_totalPossibleResultCount, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<User> users = null;
			if (input_users != IntPtr.Zero){
				users = Convert.toCS_User_Array(input_users);
			}
			Int32 startOffset = input_startOffset;
			Int32 totalPossibleResultCount = input_totalPossibleResultCount;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getFriendsForUser callback about to invoke!");
				try {
					getFriendsForUser_onCompleteCallback del = (getFriendsForUser_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  users,  startOffset,  totalPossibleResultCount );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getFriendsForUser finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getFriendsWithGameForUser_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_users, Int32 input_startOffset, Int32 input_totalPossibleResultCount, IntPtr context);
		[MonoPInvokeCallback (typeof (getFriendsWithGameForUser_onCompleteCallbackDispatcherDelegate))]
		private static void getFriendsWithGameForUser_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_users, Int32 input_startOffset, Int32 input_totalPossibleResultCount, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<User> users = null;
			if (input_users != IntPtr.Zero){
				users = Convert.toCS_User_Array(input_users);
			}
			Int32 startOffset = input_startOffset;
			Int32 totalPossibleResultCount = input_totalPossibleResultCount;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getFriendsWithGameForUser callback about to invoke!");
				try {
					getFriendsWithGameForUser_onCompleteCallback del = (getFriendsWithGameForUser_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  users,  startOffset,  totalPossibleResultCount );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getFriendsWithGameForUser finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion



#region Delegate Callbacks
	public partial class People {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
		/**
		 * <summary> Callback for retrieving information about the current user.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="currentUser" cref="F:Mobage.User">Information about the current user, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getCurrentUser_onCompleteCallback(SimpleAPIStatus status, Error error, User currentUser);
		/**
		 * <summary> Callback for retrieving information about a specified user.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="user" cref="F:Mobage.User">Information about the specified user, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getUserForId_onCompleteCallback(SimpleAPIStatus status, Error error, User user);
		/**
		 * <summary> Callback for retrieving information about multiple users.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="users" cref="F:System.Collections.Generic.List<Mobage.User>">An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getUsersForIds_onCompleteCallback(SimpleAPIStatus status, Error error, List<User> users);
		/**
		 * <summary> Callback for retrieving information about a user's friends.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="users" cref="F:System.Collections.Generic.List<Mobage.User>">An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.</param>
		 * <param name="startOffset" cref="F:System.Int32">The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. On Android, the index of the first item on the entire list is <c>1</c>. On iOS, the index of the first item on the entire list is <c>0</c>.</param>
		 * <param name="totalPossibleResultCount" cref="F:System.Int32">The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getFriendsForUser_onCompleteCallback(SimpleAPIStatus status, Error error, List<User> users, Int32 startOffset, Int32 totalPossibleResultCount);
		/**
		 * <summary> Callback for retrieving information about a user's friends who have used the current app.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="users" cref="F:System.Collections.Generic.List<Mobage.User>">An array of <c>User</c> objects, or <c>null</c> if the request did not succeed.</param>
		 * <param name="startOffset" cref="F:System.Int32">The starting index for this group of items within the entire list, or <c>null</c> if the request did not succeed. On Android, the index of the first item on the entire list is <c>1</c>. On iOS, the index of the first item on the entire list is <c>0</c>.</param>
		 * <param name="totalPossibleResultCount" cref="F:System.Int32">The total number of items that can be retrieved, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getFriendsWithGameForUser_onCompleteCallback(SimpleAPIStatus status, Error error, List<User> users, Int32 startOffset, Int32 totalPossibleResultCount);
	}
#endregion

#region Static Methods
	public partial class People {
		/**
		 * <summary> Retrieve information about the current user.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.GetCurrentUserOnCompleteCallback">
		 * Callback for retrieving information about the current user.</param>
		 */
		public static void getCurrentUser(getCurrentUser_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCPeople_getCurrentUser(getCurrentUser_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		/**
		 * <summary> Retrieve information about a specified user.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="userId" cref="F:System.String">The user ID of the user to retrieve.</param>
		 * <param name="onComplete" cref="F:Mobage.GetUserForIdOnCompleteCallback">
		 * Callback for retrieving information about a specified user.</param>
		 */
		public static void getUserForId(String userId, getUserForId_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_userId = (IntPtr)Convert.toC(userId);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCPeople_getUserForId(out_userId, getUserForId_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_userId);
		}
		/**
		 * <summary> Retrieve information about a maximum of 100 users.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="userIds" cref="F:System.Collections.Generic.List<System.String>">The user IDs of the users to retrieve. Must contain between 1 and 100 user IDs.</param>
		 * <param name="onComplete" cref="F:Mobage.GetUsersForIdsOnCompleteCallback">
		 * Callback for retrieving information about multiple users.</param>
		 */
		public static void getUsersForIds(List<String> userIds, getUsersForIds_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_userIds = (IntPtr)Convert.toC(userIds);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCPeople_getUsersForIds(out_userIds, getUsersForIds_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_userIds);
		}
		/**
		 * <summary> Retrieve information about a user's friends.</summary>
		 * <remarks>
		 * You can use the <c>howMany</c> and <c>offset</c> parameters to control the number
		 * of results that this method retrieves, as well as the start index for the search results.
		 * <p>
		 * <strong>Important</strong>: In the current version of the Unity SDK, Android starts numbering
		 * search results at <c>1</c>, which is consistent with other Unity SDK methods. However, iOS
		 * starts numbering search results at <c>0</c>, which is not consistent. If you will release
		 * your app on both Android and iOS, ensure that your code adjusts for this difference.
		 * </remarks>
		 * <param name="user" cref="F:Mobage.User">The user whose friends will be retrieved.</param>
		 * <param name="howMany" cref="F:System.Int32">The number of results to retrieve. The default value is <c>50</c>.</param>
		 * <param name="offset" cref="F:System.Int32">The start index for the search results. On Android, the default value is <c>1</c>, and the index's numbering begins at <c>1</c>. On iOS, the default value is <c>0</c>, and the index's numbering begins at <c>0</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.GetFriendsForUserOnCompleteCallback">
		 * Callback for retrieving information about a user's friends.</param>
		 */
		public static void getFriendsForUser(User user, Int32 howMany, Int32 offset, getFriendsForUser_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_user = (IntPtr)Convert.toC(user);

			Int32 out_howMany = howMany;

			Int32 out_offset = offset;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCPeople_getFriendsForUser(out_user, out_howMany, out_offset, getFriendsForUser_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			User.MBCReleaseUser(out_user);
		}
		/**
		 * <summary> Retrieve information about a user's friends who have used the current app.</summary>
		 * <remarks>
		 * You can use the <c>howMany</c> and <c>offset</c> parameters to control the
		 * number of results that this method retrieves, as well as the start index for the search
		 * results.
		 * <p>
		 * <strong>Important</strong>: In the current version of the Unity SDK, Android starts numbering
		 * search results at <c>1</c>, which is consistent with other Unity SDK methods. However, iOS
		 * starts numbering search results at <c>0</c>, which is not consistent. If you will release
		 * your app on both Android and iOS, ensure that your code adjusts for this difference.
		 * </remarks>
		 * <param name="user" cref="F:Mobage.User">The user whose friends have used the current app.</param>
		 * <param name="howMany" cref="F:System.Int32">The number of results to retrieve. The default value is <c>50</c>.</param>
		 * <param name="offset" cref="F:System.Int32">The start index for the search results. On Android, the default value is <c>1</c>, and the index's numbering begins at <c>1</c>. On iOS, the default value is <c>0</c>, and the index's numbering begins at <c>0</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.GetFriendsWithGameForUserOnCompleteCallback">
		 * Callback for retrieving information about a user's friends who have used the current app.</param>
		 */
		public static void getFriendsWithGameForUser(User user, Int32 howMany, Int32 offset, getFriendsWithGameForUser_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_user = (IntPtr)Convert.toC(user);

			Int32 out_howMany = howMany;

			Int32 out_offset = offset;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCPeople_getFriendsWithGameForUser(out_user, out_howMany, out_offset, getFriendsWithGameForUser_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			User.MBCReleaseUser(out_user);
		}
	}
#endregion


}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
