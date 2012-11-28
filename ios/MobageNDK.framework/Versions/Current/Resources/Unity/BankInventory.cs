//
//  BankInventory.cs
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
	 * <summary> Provides access to information about virtual items.</summary>
	 * <remarks>
	 * Use the <a href="https://developer.mobage.com/">Mobage Developer Portal</a> to set up the virtual
	 * items for your app.
	 * </remarks>
	 */
	public partial class BankInventory {}

#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class BankInventory {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankInventory_getItemForId(IntPtr input_itemId, getItemForId_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion
#region Native Return Points
	public partial class BankInventory {
		private delegate void getItemForId_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_itemData, IntPtr context);
		[MonoPInvokeCallback (typeof (getItemForId_onCompleteCallbackDispatcherDelegate))]
		private static void getItemForId_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_itemData, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			ItemData itemData = null;
			if (input_itemData != IntPtr.Zero){
				itemData = Convert.toCS_ItemData(input_itemData);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getItemForId callback about to invoke!");
				try {
					getItemForId_onCompleteCallback del = (getItemForId_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  itemData );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getItemForId finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion



#region Delegate Callbacks
	public partial class BankInventory {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
		/**
		 * <summary> Callback for retrieving information about a virtual item.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="itemData" cref="F:Mobage.ItemData">Information about the virtual item, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getItemForId_onCompleteCallback(SimpleAPIStatus status, Error error, ItemData itemData);
	}
#endregion

#region Static Methods
	public partial class BankInventory {
		/**
		 * <summary> Retrieve information about a virtual item.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="itemId" cref="F:System.String">The item's unique ID.</param>
		 * <param name="onComplete" cref="F:Mobage.GetItemForIdOnCompleteCallback">
		 * Callback for retrieving information about a virtual item.</param>
		 */
		public static void getItemForId(String itemId, getItemForId_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_itemId = (IntPtr)Convert.toC(itemId);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankInventory_getItemForId(out_itemId, getItemForId_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_itemId);
		}
	}
#endregion


}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
