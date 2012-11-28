//
//  Error.cs
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
	 * <summary> Information about a Mobage error.</summary>
	 * <remarks>
	 
	 * </remarks>
	 */
	public partial class Error {}

#region Enums / Bitfields
	/**
	 * Enumeration of standard Mobage API errors.
	 */
	public enum StandardError {
		/**
				 *
		 * A server error occurred.
		 */
		ServerError = 10001, 
		/**
				 *
		 * The device cannot connect to the network.
		 */
		NetworkUnavailable = 10002, 
		/**
				 *
		 * The request was missing required information.
		 */
		MissingData = 10003, 
		/**
				 *
		 * The request contained invalid data.
		 */
		InvalidData = 10004, 
		/**
				 *
		 * An unknown error occurred.
		 */
		UnknownError = 10005, 
		/**
				 *
		 * A message from the server could not be parsed.
		 */
		ParseError = 10006, 
		/**
				 *
		 * There is no authorization token available for the user.
		 */
		NoAuthToken = 10007, 
	};
	
	public partial class Convert {
		public static bool IsStandardError(int intFlag){return (!((intFlag < 10001) || (intFlag > 10007))); }
		public static int toC(StandardError enumValue){return (int)enumValue;}
		public static StandardError toCS_StandardError(int enumValue){return (StandardError)enumValue;}
	}
	
	/**
	 * Enumeration of Mobage errors that relate to HTTP errors.
	 */
	public enum HTTPError {
		/**
				 *
		 * The Mobage server is not currently available.
		 */
		ServerDown = 109, 
		/**
				 *
		 * The app must be upgraded to support the current version of Mobage.
		 */
		UpgradeRequired = 110, 
		/**
				 *
		 * The user has been banned from Mobage.
		 */
		UserBanned = 111, 
		/**
				 *
		 * The user has not agreed to the Mobage terms of service.
		 */
		AgreementNeeded = 112, 
		/**
				 *
		 * The request data was invalid.
		 */
		BadRequest = 400, 
		/**
				 *
		 * The specified data was not found.
		 */
		RecordNotFound = 404, 
		/**
				 *
		 * An authentication error occurred.
		 */
		Unauthorized = 401, 
		/**
				 *
		 * Access was forbidden for reasons other than an authentication error.
		 */
		PermissionDenied = 403, 
		/**
				 *
		 * An internal server error occurred.
		 */
		FirstInternalServerError = 500, 
		/**
				 *
		 * An unknown error occurred.
		 */
		LastHTTPError = 599, 
	};
	
	public partial class Convert {
		public static bool IsHTTPError(int intFlag){return (!((intFlag < 109) || (intFlag > 599))); }
		public static int toC(HTTPError enumValue){return (int)enumValue;}
		public static HTTPError toCS_HTTPError(int enumValue){return (HTTPError)enumValue;}
	}
	
	/**
	 * Enumeration of errors for Mobage's common APIs, which are supported in all regions.
	 */
	public enum CommonAPIError {
		/**
				 *
		 * The user's session is invalid.
		 */
		InvalidSession = 20001, 
		/**
				 *
		 * The method was called without a required parameter.
		 */
		MethodMissingArgument = 20002, 
		/**
				 *
		 * The method was called with an invalid parameter value.
		 */
		MethodInvalidArgument = 20003, 
		/**
				 *
		 * The method has not been implemented.
		 */
		MethodNotImplemented = 20004, 
		/**
				 *
		 * The current Mobage server does not support this method.
		 */
		MethodNotSupported = 20005, 
	};
	
	public partial class Convert {
		public static bool IsCommonAPIError(int intFlag){return (!((intFlag < 20001) || (intFlag > 20005))); }
		public static int toC(CommonAPIError enumValue){return (int)enumValue;}
		public static CommonAPIError toCS_CommonAPIError(int enumValue){return (CommonAPIError)enumValue;}
	}
	
	/**
	 * Enumeration of Mobage analytics errors.
	 */
	public enum AnalyticsServerError {
		/**
				 *
		 * An invalid response was received from the analytics server.
		 */
		InvalidResponse = 30001, 
		/**
				 *
		 * The analytics server rejected the request.
		 */
		EventRejected = 30002, 
		/**
				 *
		 * The analytics event size exceeded the maximum size.
		 */
		EventSizeTooLarge = 30003, 
		/**
				 *
		 * The analytics event property size exceeded the maximum size.
		 */
		EventPropertySizeTooLarge = 30004, 
		/**
				 *
		 * The analytics event contained an invalid array.
		 */
		EventContainsInvalidArray = 30005, 
	};
	
	public partial class Convert {
		public static bool IsAnalyticsServerError(int intFlag){return (!((intFlag < 30001) || (intFlag > 30005))); }
		public static int toC(AnalyticsServerError enumValue){return (int)enumValue;}
		public static AnalyticsServerError toCS_AnalyticsServerError(int enumValue){return (AnalyticsServerError)enumValue;}
	}
	
	/**
	 * Enumeration of Mobage Bank errors.
	 */
	public enum BankError {
		/**
				 *
		 * The Bank request could not be completed, because the transaction is not in the correct  state for the requested method.
		 */
		InvalidStateTransition = 40001, 
	};
	
	public partial class Convert {
		public static bool IsBankError(int intFlag){return (!((intFlag < 40001) || (intFlag > 40001))); }
		public static int toC(BankError enumValue){return (int)enumValue;}
		public static BankError toCS_BankError(int enumValue){return (BankError)enumValue;}
	}
	
	/**

	 */
	public enum MobageAPIErrorType {
		/**
				 The Mobage server is not currently available.
		 */
		ServerDown = 109, 
		/**
				 The app must be upgraded to support the current version of Mobage.
		 */
		UpgradeRequired = 110, 
		/**
				 The user has been banned from Mobage.
		 */
		UserBanned = 111, 
		/**
				 The user has not agreed to the Mobage terms of service.
		 */
		AgreementNeeded = 112, 
		/**
				 The request data was invalid.
		 */
		BadRequest = 400, 
		/**
				 The specified data was not found.
		 */
		RecordNotFound = 404, 
		/**
				 An authentication error occurred.
		 */
		Unauthorized = 401, 
		/**
				 Access was forbidden for reasons other than an authentication error.
		 */
		PermissionDenied = 403, 
		/**
				 A server error occurred.
		 */
		ServerError = 10001, 
		/**
				 The device cannot connect to the network.
		 */
		NetworkUnavailable = 10002, 
		/**
				 The request was missing required information.
		 */
		MissingData = 10003, 
		/**
				 The request contained invalid data.
		 */
		InvalidData = 10004, 
		/**
				 An unknown error occurred.
		 */
		UnknownError = 10005, 
		/**
				 A message from the server could not be parsed.
		 */
		ParseError = 10006, 
		/**
				 There is no authorization token available for the user.
		 */
		NoAuthToken = 10007, 
		/**
				 The user's session is invalid.
		 */
		CommonAPIInvalidSessionError = 20001, 
		/**
				 The method was called without a required parameter.
		 */
		CommonAPIMethodMissingArgumentError = 20002, 
		/**
				 The method was called with an invalid parameter value.
		 */
		CommonAPIMethodInvalidArgumentError = 20003, 
		/**
				 The method has not been implemented.
		 */
		CommonAPIMethodNotImplementedError = 20004, 
		/**
				 The current Mobage server does not support this method.
		 */
		CommonAPIMethodNotSupportedError = 20005, 
		/**
				 An invalid response was received from the analytics server.
		 */
		AnalyticsServerInvalidResponse = 30001, 
		/**
				 The analytics server rejected the request.
		 */
		AnalyticsServerEventRejected = 30002, 
		/**
				 The analytics event size exceeded the maximum size.
		 */
		AnalyticsServerEventSizeTooLarge = 30003, 
		/**
				 The analytics event property size exceeded the maximum size.
		 */
		AnalyticsServerEventPropertySizeTooLarge = 30004, 
		/**
				 The analytics event contained an invalid array.
		 */
		AnalyticsServerEventContainsInvalidArray = 30005, 
		/**
				 The Bank request could not be completed, because the transaction is not in the correct state for the requested method.
		 */
		BankErrorInvalidStateTransition = 40001, 
	};
	
	public partial class Convert {
		public static bool IsMobageAPIErrorType(int intFlag){return (!((intFlag < 109) || (intFlag > 40001))); }
		public static int toC(MobageAPIErrorType enumValue){return (int)enumValue;}
		public static MobageAPIErrorType toCS_MobageAPIErrorType(int enumValue){return (MobageAPIErrorType)enumValue;}
	}
	
#endregion
	
	public partial class Error {
		// Properties!
		public IntPtr thisObj; // Pretty Darn Internal
		
		/**
		 * A unique string indicating the source of the error. All Mobage errors will contain the same value in this property.
		 */
		public String domain;
		/**
		 * A unique code identifying the error that occurred. Contains an enumerated value of one of the following:<ul><li>Mobage::AnalyticsServerError</li><li>Mobage::BankError</li><li>Mobage::CommonAPIError</li><li>Mobage::HTTPError</li><li>Mobage::MobageAPIErrorType</li><li>Mobage::StandardError</li></ul>
		 */
		public Int32 code;
		/**
		 * A summary of the error that can be displayed to the user.
		 */
		public String localizedDescription;
		/**
		 * A detailed description of the error that can be used for debugging.
		 */
		public String description;
		
		// Factories!
		public static Error Factory(IntPtr cobj){
			CError tmp = (CError)Marshal.PtrToStructure(cobj, typeof(CError));
			tmp.thisObj = cobj;
			Error result = Factory(ref tmp);
			return result;
		}
		private static Error Factory(ref CError cobj) {
			Error tmp = new Error();
			tmp.thisObj = cobj.thisObj;
			MBCRetainError(tmp.thisObj);
			
			tmp.domain = Convert.toCS_String(cobj.domain);
			tmp.code = Convert.toCS_Integer(cobj.code);
			tmp.localizedDescription = Convert.toCS_String(cobj.localizedDescription);
			tmp.description = Convert.toCS_String(cobj.description);
			
			return tmp;
		}
		
		~Error(){
			MBCReleaseError(thisObj);
			thisObj = IntPtr.Zero;
		}
	}
#region CLayer Marshaling [Shadow Objects]
	public partial class Error {
		[StructLayout (LayoutKind.Sequential)]
		private struct CError {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr domain;
			public Int32 code;
			public IntPtr localizedDescription;
			public IntPtr description;
			//End of Marshal struct
		}
		
		[StructLayout (LayoutKind.Sequential)]
		public struct Error_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<Error> Factory(IntPtr cobj){
				Error_Array tmp = (Error_Array)Marshal.PtrToStructure(cobj,typeof(Error_Array));
				return tmp.toList();
			}
			private List<Error> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<Error>();
				}
				
				List<Error> tmp = new List<Error>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					Error tmpItem = Convert.toCS_Error(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(Error obj){
			Error.MBCRetainError(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<Error> list){
			Error.Error_Array tmp = new Error.Error_Array();
			tmp.length = list.Count;
			tmp.elements = Marshal.AllocHGlobal(4 * list.Count);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = Error.MBCCopyConstructError_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static Error toCS_Error(IntPtr obj){
			return Error.Factory(obj);
		}
		public static List<Error> toCS_Error_Array(IntPtr obj){
			return Error.Error_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class Error {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructError(IntPtr /*Error*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructError_Array(IntPtr /*Error_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainError(IntPtr /*Error*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseError(IntPtr /*Error*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainError_Array(IntPtr /*Error_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseError_Array(IntPtr /*Error_Array*/ objects);

	
	}
#endregion
#region Native Return Points
	public partial class Error {
	}
#endregion



#region Delegate Callbacks
	public partial class Error {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
	}
#endregion

#region Static Methods
	public partial class Error {
	}
#endregion

#region Instance Methods
	public partial class Error {
	}
#endregion

}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
