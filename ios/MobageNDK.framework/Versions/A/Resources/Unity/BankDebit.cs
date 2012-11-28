//
//  BankDebit.cs
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
	 * <summary> Interface for purchasing virtual in-app items.</summary>
	 * <remarks>
	 * To complete a purchase, your app typically follows these steps:
	 * <ol>
	 * <li>Create a transaction, which causes the Native SDK to present a purchase screen to the user.
	 * If the user completes the purchase, the transaction's state changes from <c>new</c> to
	 * <c>authorized</c>.</li>
	 * <li>Open the transaction, which changes the transaction's state to <c>open</c> and places
	 * the user's funds into escrow.</li>
	 * <li>If the user's funds are successfully placed into escrow, deliver the virtual item to the
	 * user.</li>
	 * <li>Close the transaction to capture the user's funds and change the transaction's state to
	 * <c>closed</c>.</li>
	 * </ol>
	 * <strong>Important</strong>: Your app must wait for the callback from each method and verify that
	 * the request succeeded before proceeding to the next step.
	 * </remarks>
	 */
	public partial class BankDebit {}

#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class BankDebit {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_createTransactionForItem(IntPtr input_itemToPurchase, Int32 input_quantity, IntPtr input_comment, createTransactionForItem_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_openTransaction(IntPtr input_transaction, openTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_closeTransaction(IntPtr input_transaction, closeTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_continueTransaction(IntPtr input_transaction, continueTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_cancelTransaction(IntPtr input_transaction, cancelTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCBankDebit_getTransaction(IntPtr input_transactionId, getTransaction_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion
#region Native Return Points
	public partial class BankDebit {
		private delegate void createTransactionForItem_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (createTransactionForItem_onCompleteCallbackDispatcherDelegate))]
		private static void createTransactionForItem_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			CancelableAPIStatus status = Convert.toCS_CancelableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("createTransactionForItem callback about to invoke!");
				try {
					createTransactionForItem_onCompleteCallback del = (createTransactionForItem_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("createTransactionForItem finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void openTransaction_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (openTransaction_onCompleteCallbackDispatcherDelegate))]
		private static void openTransaction_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("openTransaction callback about to invoke!");
				try {
					openTransaction_onCompleteCallback del = (openTransaction_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("openTransaction finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void closeTransaction_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (closeTransaction_onCompleteCallbackDispatcherDelegate))]
		private static void closeTransaction_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("closeTransaction callback about to invoke!");
				try {
					closeTransaction_onCompleteCallback del = (closeTransaction_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("closeTransaction finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void continueTransaction_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (continueTransaction_onCompleteCallbackDispatcherDelegate))]
		private static void continueTransaction_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			CancelableAPIStatus status = Convert.toCS_CancelableAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("continueTransaction callback about to invoke!");
				try {
					continueTransaction_onCompleteCallback del = (continueTransaction_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("continueTransaction finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void cancelTransaction_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (cancelTransaction_onCompleteCallbackDispatcherDelegate))]
		private static void cancelTransaction_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("cancelTransaction callback about to invoke!");
				try {
					cancelTransaction_onCompleteCallback del = (cancelTransaction_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("cancelTransaction finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getTransaction_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context);
		[MonoPInvokeCallback (typeof (getTransaction_onCompleteCallbackDispatcherDelegate))]
		private static void getTransaction_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_transaction, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Transaction transaction = null;
			if (input_transaction != IntPtr.Zero){
				transaction = Convert.toCS_Transaction(input_transaction);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getTransaction callback about to invoke!");
				try {
					getTransaction_onCompleteCallback del = (getTransaction_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  transaction );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getTransaction finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion



#region Delegate Callbacks
	public partial class BankDebit {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
		/**
		 * <summary> Callback for creating a transaction.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.CancelableAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void createTransactionForItem_onCompleteCallback(CancelableAPIStatus status, Error error, Transaction transaction);
		/**
		 * <summary> Callback for placing the user's funds for a transaction in escrow.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void openTransaction_onCompleteCallback(SimpleAPIStatus status, Error error, Transaction transaction);
		/**
		 * <summary> Callback for closing a transaction.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void closeTransaction_onCompleteCallback(SimpleAPIStatus status, Error error, Transaction transaction);
		/**
		 * <summary> Callback for continuing to process a transaction created by an app server.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.CancelableAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void continueTransaction_onCompleteCallback(CancelableAPIStatus status, Error error, Transaction transaction);
		/**
		 * <summary> Callback for canceling a transaction.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void cancelTransaction_onCompleteCallback(SimpleAPIStatus status, Error error, Transaction transaction);
		/**
		 * <summary> Callback for retrieving information about a transaction.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="transaction" cref="F:Mobage.Transaction">Information about the transaction, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getTransaction_onCompleteCallback(SimpleAPIStatus status, Error error, Transaction transaction);
	}
#endregion

#region Static Methods
	public partial class BankDebit {
		/**
		 * <summary> Create a new transaction.</summary>
		 * <remarks>
		 * When your app calls this method, the following steps occur:
		 * <ol>
		 * <li>The app's inventory is checked to make sure the requested item exists, and a new
		 * transaction is created, with its state set to <c>new</c>.</li>
		 * <li>Mobage presents a screen that prompts the user to confirm the transaction.</li>
		 * <li>If the user decides not to proceed with the transaction, the transaction is automatically
		 * canceled. Otherwise, the transaction's state is set to <c>authorized</c>.</li>
		 * </ol>
		 * </remarks>
		 * <param name="itemToPurchase" cref="F:Mobage.ItemData">The item that the user is purchasing.</param>
		 * <param name="quantity" cref="F:System.Int32">The quantity of the item to purchase.</param>
		 * <param name="comment" cref="F:System.String">A comment on the transaction. On the US/worldwide platform, this comment is not currently displayed to users.</param>
		 * <param name="onComplete" cref="F:Mobage.CreateTransactionForItemOnCompleteCallback">
		 * Callback for creating a transaction.</param>
		 */
		public static void createTransactionForItem(ItemData itemToPurchase, Int32 quantity, String comment, createTransactionForItem_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_itemToPurchase = (IntPtr)Convert.toC(itemToPurchase);

			Int32 out_quantity = quantity;

			IntPtr out_comment = (IntPtr)Convert.toC(comment);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_createTransactionForItem(out_itemToPurchase, out_quantity, out_comment, createTransactionForItem_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			ItemData.MBCReleaseItemData(out_itemToPurchase);
			Marshal.FreeHGlobal(out_comment);
		}
		/**
		 * <summary> Place the user's funds into escrow prior to delivering the virtual item.</summary>
		 * <remarks>
		 * If this method succeeds, the transaction's state is set to <c>open</c>, and the virtual
		 * item should be delivered to the user.
		 * </remarks>
		 * <param name="transaction" cref="F:Mobage.Transaction">The transaction for which funds will be placed in escrow.</param>
		 * <param name="onComplete" cref="F:Mobage.OpenTransactionOnCompleteCallback">
		 * Callback for placing the user's funds for a transaction in escrow.</param>
		 */
		public static void openTransaction(Transaction transaction, openTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transaction = (IntPtr)Convert.toC(transaction);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_openTransaction(out_transaction, openTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Transaction.MBCReleaseTransaction(out_transaction);
		}
		/**
		 * <summary> Close the transaction after delivering the virtual item.</summary>
		 * <remarks>
		 * If this method succeeds, the transaction's state is set to <c>closed</c>, and the
		 * user's funds are captured to your account.
		 * </remarks>
		 * <param name="transaction" cref="F:Mobage.Transaction">The transaction to be closed.</param>
		 * <param name="onComplete" cref="F:Mobage.CloseTransactionOnCompleteCallback">
		 * Callback for closing a transaction.</param>
		 */
		public static void closeTransaction(Transaction transaction, closeTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transaction = (IntPtr)Convert.toC(transaction);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_closeTransaction(out_transaction, closeTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Transaction.MBCReleaseTransaction(out_transaction);
		}
		/**
		 * <summary> Continue processing a transaction created by an app server using the <a href="https://developer.mobage.com/en/resources/rest_api">Mobage REST API</a>.</summary>
		 * <remarks>
		 * When a transaction is created through the REST API, its state is set to <c>new</c>.
		 * Calling this method on the transaction does the following:
		 * <ol>
		 * <li>The transaction's state is set to <c>authorized</c>.</li>
		 * <li>The user's funds are placed into escrow.</li>
		 * <li>The transaction's state is set to <c>open</c>. The virtual item should now be
		 * delivered to the user.</li>
		 * </ol>
		 * If the user has insufficient funds for the transaction, the transaction's state is set to
		 * <c>canceled</c>.
		 * <p>
		 * <strong>Note</strong>: Before you call this method, you must use the transaction ID to
		 * retrieve a <c>Transaction</c> object. Call <c>BankDebit::getTransaction</c> to retrieve the
		 * object.
		 * </remarks>
		 * <param name="transaction" cref="F:Mobage.Transaction">The transaction to continue processing.</param>
		 * <param name="onComplete" cref="F:Mobage.ContinueTransactionOnCompleteCallback">
		 * Callback for continuing to process a transaction created by an app server.</param>
		 */
		public static void continueTransaction(Transaction transaction, continueTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transaction = (IntPtr)Convert.toC(transaction);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_continueTransaction(out_transaction, continueTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Transaction.MBCReleaseTransaction(out_transaction);
		}
		/**
		 * <summary> Mark the transaction as canceled, setting its state to <c>canceled</c> and releasing funds from escrow if applicable.</summary>
		 * <remarks>
		 * Call this method if any of the following occur:
		 * <ul>
		 * <li>The user cancels the transaction.</li>
		 * <li>The user does not have sufficient funds for the transaction.</li>
		 * <li>The virtual item cannot be delivered.</li>
		 * <li>An error occurs that prevents the transaction from being processed.</li>
		 * </ul>
		 * </remarks>
		 * <param name="transaction" cref="F:Mobage.Transaction">The transaction to cancel.</param>
		 * <param name="onComplete" cref="F:Mobage.CancelTransactionOnCompleteCallback">
		 * Callback for canceling a transaction.</param>
		 */
		public static void cancelTransaction(Transaction transaction, cancelTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transaction = (IntPtr)Convert.toC(transaction);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_cancelTransaction(out_transaction, cancelTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Transaction.MBCReleaseTransaction(out_transaction);
		}
		/**
		 * <summary> Retrieve information about a transaction.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="transactionId" cref="F:System.String">The transaction's unique ID.</param>
		 * <param name="onComplete" cref="F:Mobage.GetTransactionOnCompleteCallback">
		 * Callback for retrieving information about a transaction.</param>
		 */
		public static void getTransaction(String transactionId, getTransaction_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_transactionId = (IntPtr)Convert.toC(transactionId);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCBankDebit_getTransaction(out_transactionId, getTransaction_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_transactionId);
		}
	}
#endregion


}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
