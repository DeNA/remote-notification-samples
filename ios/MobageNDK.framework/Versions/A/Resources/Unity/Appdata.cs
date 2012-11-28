//
//  Appdata.cs
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
	 * <summary> Create, update, retrieve, and delete app-specific data on the Mobage server.</summary>
	 * <remarks>
	 * Data is stored as key/value pairs that are tied to the current user and are limited as follows:
	 * <ul>
	 * <li>An app can store a maximum of 30 key/value pairs for each user.</li>
	 * <li>The maximum key length is 32 bytes.</li>
	 * <li>The maximum value length is 1,024 bytes.</li>
	 * </ul>
	 * Use the methods in this class to store app data that is tied to a specific user and should be
	 * available whenever the user is logged into Mobage.
	 * </remarks>
	 */
	public partial class Appdata {}

#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class Appdata {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAppdata_deleteEntriesForKeys(IntPtr input_theKeys, deleteEntriesForKeys_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAppdata_getEntriesForKeys(IntPtr input_theKeys, getEntriesForKeys_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAppdata_updateEntries(IntPtr input_theKeys, IntPtr input_theValues, updateEntries_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion
#region Native Return Points
	public partial class Appdata {
		private delegate void deleteEntriesForKeys_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_deletedKeys, IntPtr context);
		[MonoPInvokeCallback (typeof (deleteEntriesForKeys_onCompleteCallbackDispatcherDelegate))]
		private static void deleteEntriesForKeys_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_deletedKeys, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<String> deletedKeys = null;
			if (input_deletedKeys != IntPtr.Zero){
				deletedKeys = Convert.toCS_String_Array(input_deletedKeys);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("deleteEntriesForKeys callback about to invoke!");
				try {
					deleteEntriesForKeys_onCompleteCallback del = (deleteEntriesForKeys_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  deletedKeys );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("deleteEntriesForKeys finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getEntriesForKeys_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_keys, IntPtr input_values, IntPtr context);
		[MonoPInvokeCallback (typeof (getEntriesForKeys_onCompleteCallbackDispatcherDelegate))]
		private static void getEntriesForKeys_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_keys, IntPtr input_values, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<String> keys = null;
			if (input_keys != IntPtr.Zero){
				keys = Convert.toCS_String_Array(input_keys);
			}
			List<String> values = null;
			if (input_values != IntPtr.Zero){
				values = Convert.toCS_String_Array(input_values);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getEntriesForKeys callback about to invoke!");
				try {
					getEntriesForKeys_onCompleteCallback del = (getEntriesForKeys_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  keys,  values );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getEntriesForKeys finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void updateEntries_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_updatedKeys, IntPtr context);
		[MonoPInvokeCallback (typeof (updateEntries_onCompleteCallbackDispatcherDelegate))]
		private static void updateEntries_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_updatedKeys, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<String> updatedKeys = null;
			if (input_updatedKeys != IntPtr.Zero){
				updatedKeys = Convert.toCS_String_Array(input_updatedKeys);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("updateEntries callback about to invoke!");
				try {
					updateEntries_onCompleteCallback del = (updateEntries_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  updatedKeys );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("updateEntries finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion



#region Delegate Callbacks
	public partial class Appdata {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
		/**
		 * <summary> Callback for deleting key-value pairs.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="deletedKeys" cref="F:System.Collections.Generic.List<System.String>">A list of keys that were deleted, with each key represented as a <c>String</c>, or <c>null</c> if the request did not succeed. <strong>Note</strong>: The keys may not be in the same order as the list of keys in the request.</param>
		 */
		public delegate void deleteEntriesForKeys_onCompleteCallback(SimpleAPIStatus status, Error error, List<String> deletedKeys);
		/**
		 * <summary> Callback for retrieving key-value pairs.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="keys" cref="F:System.Collections.Generic.List<System.String>">The keys that were retrieved, with each key represented as a <c>String</c>, or <c>null</c> if the request did not succeed. <strong>Note</strong>: The keys may not be in the same order as the list of keys in the request.</param>
		 * <param name="values" cref="F:System.Collections.Generic.List<System.String>">The values that were retrieved, with each value represented as a <c>String</c>, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getEntriesForKeys_onCompleteCallback(SimpleAPIStatus status, Error error, List<String> keys, List<String> values);
		/**
		 * <summary> Callback for creating or updating key/value pairs.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="updatedKeys" cref="F:System.Collections.Generic.List<System.String>">The keys that were created or updated, with each key represented as a <c>String</c>, or <c>null</c> if the request did not succeed. <strong>Note</strong>: The keys may not be in the same order as the list of keys in the request.</param>
		 */
		public delegate void updateEntries_onCompleteCallback(SimpleAPIStatus status, Error error, List<String> updatedKeys);
	}
#endregion

#region Static Methods
	public partial class Appdata {
		/**
		 * <summary> Delete one or more key/value pairs.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="theKeys" cref="F:System.Collections.Generic.List<System.String>">The keys to delete. Each key name must be a <c>String</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.DeleteEntriesForKeysOnCompleteCallback">
		 * Callback for deleting key-value pairs.</param>
		 */
		public static void deleteEntriesForKeys(List<String> theKeys, deleteEntriesForKeys_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_theKeys = (IntPtr)Convert.toC(theKeys);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCAppdata_deleteEntriesForKeys(out_theKeys, deleteEntriesForKeys_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_theKeys);
		}
		/**
		 * <summary> Retrieve one or more key/value pairs.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="theKeys" cref="F:System.Collections.Generic.List<System.String>">The keys to retrieve. Each key name must be a <c>String</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.GetEntriesForKeysOnCompleteCallback">
		 * Callback for retrieving key-value pairs.</param>
		 */
		public static void getEntriesForKeys(List<String> theKeys, getEntriesForKeys_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_theKeys = (IntPtr)Convert.toC(theKeys);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCAppdata_getEntriesForKeys(out_theKeys, getEntriesForKeys_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_theKeys);
		}
		/**
		 * <summary> Create or update one or more key/value pairs.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="theKeys" cref="F:System.Collections.Generic.List<System.String>">The keys to create or update. Each key name must be a <c>String</c>.</param>
		 * <param name="theValues" cref="F:System.Collections.Generic.List<System.String>">The values for each key. Each value must be a <c>String</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.UpdateEntriesOnCompleteCallback">
		 * Callback for creating or updating key/value pairs.</param>
		 */
		public static void updateEntries(List<String> theKeys, List<String> theValues, updateEntries_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_theKeys = (IntPtr)Convert.toC(theKeys);

			IntPtr out_theValues = (IntPtr)Convert.toC(theValues);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCAppdata_updateEntries(out_theKeys, out_theValues, updateEntries_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_theKeys);
			Marshal.FreeHGlobal(out_theValues);
		}
	}
#endregion


}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
