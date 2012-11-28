//
//  Transaction.cs
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
	 * <summary> Stores information about a Bank transaction.</summary>
	 * <remarks>
	 
	 * </remarks>
	 */
	public partial class Transaction {}

#region Enums / Bitfields
	/**
	 * Enumeration for transaction states.
	 */
	public enum TransactionState {
		/**
				 *
		 * The transaction is new.
		 */
		New = 0, 
		/**
				 *
		 * The transaction has been authorized and is ready to be opened.
		 */
		Authorized = 1, 
		/**
				 *
		 * The transaction has been canceled.
		 */
		Canceled = 2, 
		/**
				 *
		 * The transaction has been opened, and the user's funds have been placed into escrow.
		 */
		Open = 3, 
		/**
				 *
		 * The transaction has been closed, and the user's funds have been captured.
		 */
		Closed = 4, 
		/**
		
		 */
		Same = 5, 
		/**
		
		 */
		Invalid = 6, 
	};
	
	public partial class Convert {
		public static bool IsTransactionState(int intFlag){return (!((intFlag < 0) || (intFlag > 6))); }
		public static int toC(TransactionState enumValue){return (int)enumValue;}
		public static TransactionState toCS_TransactionState(int enumValue){return (TransactionState)enumValue;}
	}
	
#endregion
	
	public partial class Transaction {
		// Properties!
		public IntPtr thisObj; // Pretty Darn Internal
		
		public String uid;
		/**
		 * The transaction's unique ID.
		 */
		public String transactionId;
		/**
		 * The billing items for the transaction. The array must contain only one item, which must be a <c>BillingItem</c>.
		 */
		public List<BillingItem> items;
		/**
		 * A comment on the transaction. On the US/worldwide platform, this comment is not currently displayed to users.
		 */
		public String comment;
		/**
		 * The transaction's current state. Contains an enumerated value of Mobage::TransactionState.
		 */
		public TransactionState state;
		/**
		 * The date and time when the transaction was created, represented in Unix time (milliseconds since 00:00:00 UTC on January 1, 1970).
		 */
		public String published;
		/**
		 * The date and time when the transaction was last modified, represented in Unix time (milliseconds since 00:00:00 UTC on January 1, 1970).
		 */
		public String updated;
		
		// Factories!
		public static Transaction Factory(IntPtr cobj){
			CTransaction tmp = (CTransaction)Marshal.PtrToStructure(cobj, typeof(CTransaction));
			tmp.thisObj = cobj;
			Transaction result = Factory(ref tmp);
			return result;
		}
		private static Transaction Factory(ref CTransaction cobj) {
			Transaction tmp = new Transaction();
			tmp.thisObj = cobj.thisObj;
			MBCRetainTransaction(tmp.thisObj);
			
			tmp.uid = Convert.toCS_String(cobj.uid);
			tmp.transactionId = Convert.toCS_String(cobj.transactionId);
			tmp.items = Convert.toCS_BillingItem_Array(cobj.items);
			tmp.comment = Convert.toCS_String(cobj.comment);
			tmp.state = Convert.toCS_TransactionState(cobj.state);
			tmp.published = Convert.toCS_String(cobj.published);
			tmp.updated = Convert.toCS_String(cobj.updated);
			
			return tmp;
		}
		
		~Transaction(){
			MBCReleaseTransaction(thisObj);
			thisObj = IntPtr.Zero;
		}
	}
#region CLayer Marshaling [Shadow Objects]
	public partial class Transaction {
		[StructLayout (LayoutKind.Sequential)]
		private struct CTransaction {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr uid;
			public IntPtr transactionId;
			public IntPtr items;
			public IntPtr comment;
			public Int32 state;
			public IntPtr published;
			public IntPtr updated;
			//End of Marshal struct
		}
		
		[StructLayout (LayoutKind.Sequential)]
		public struct Transaction_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<Transaction> Factory(IntPtr cobj){
				Transaction_Array tmp = (Transaction_Array)Marshal.PtrToStructure(cobj,typeof(Transaction_Array));
				return tmp.toList();
			}
			private List<Transaction> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<Transaction>();
				}
				
				List<Transaction> tmp = new List<Transaction>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					Transaction tmpItem = Convert.toCS_Transaction(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(Transaction obj){
			Transaction.MBCRetainTransaction(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<Transaction> list){
			Transaction.Transaction_Array tmp = new Transaction.Transaction_Array();
			tmp.length = list.Count;
			tmp.elements = Marshal.AllocHGlobal(4 * list.Count);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = Transaction.MBCCopyConstructTransaction_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static Transaction toCS_Transaction(IntPtr obj){
			return Transaction.Factory(obj);
		}
		public static List<Transaction> toCS_Transaction_Array(IntPtr obj){
			return Transaction.Transaction_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class Transaction {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructTransaction(IntPtr /*Transaction*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructTransaction_Array(IntPtr /*Transaction_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainTransaction(IntPtr /*Transaction*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseTransaction(IntPtr /*Transaction*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainTransaction_Array(IntPtr /*Transaction_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseTransaction_Array(IntPtr /*Transaction_Array*/ objects);

	
	}
#endregion
#region Native Return Points
	public partial class Transaction {
	}
#endregion



#region Delegate Callbacks
	public partial class Transaction {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
	}
#endregion

#region Static Methods
	public partial class Transaction {
	}
#endregion

#region Instance Methods
	public partial class Transaction {
	}
#endregion

}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
