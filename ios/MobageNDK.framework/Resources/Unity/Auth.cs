//
//  Auth.cs
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
	 * <summary> Retrieve a verification code for an OAuth request token.</summary>
	 * <remarks>
	 * This class supports the Mobage REST API, which your app server can use to integrate with Mobage's
	 * Bank and Social features. For more information about the Mobage REST API, see the
	 * <a href="https://developer.mobage.com/en/resources/rest_api">Mobage REST API Reference</a> on the
	 * <a href="https://developer.mobage.com/">Mobage Developer Portal</a>.
	 * </remarks>
	 */
	public partial class Auth {}

#region Enums / Bitfields
	/**

	 */
	public enum MobageFacebookLoginStatus {
		/**
		
		 */
		Success = 0, 
		/**
		
		 */
		Error = 1, 
		/**
		
		 */
		NewEmailAddress = 2, 
		/**
		
		 */
		TakenEmailAddress = 3, 
		/**
		
		 */
		Cancelled = 4, 
	};
	
	public partial class Convert {
		public static bool IsMobageFacebookLoginStatus(int intFlag){return (!((intFlag < 0) || (intFlag > 4))); }
		public static int toC(MobageFacebookLoginStatus enumValue){return (int)enumValue;}
		public static MobageFacebookLoginStatus toCS_MobageFacebookLoginStatus(int enumValue){return (MobageFacebookLoginStatus)enumValue;}
	}
	
#endregion
	

#region Native Method Imports
	public partial class Auth {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAuth_authorizeToken(IntPtr input_token, authorizeToken_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion
#region Native Return Points
	public partial class Auth {
		private delegate void authorizeToken_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_verifier, IntPtr context);
		[MonoPInvokeCallback (typeof (authorizeToken_onCompleteCallbackDispatcherDelegate))]
		private static void authorizeToken_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_verifier, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			String verifier = null;
			if (input_verifier != IntPtr.Zero){
				verifier = Convert.toCS_String(input_verifier);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("authorizeToken callback about to invoke!");
				try {
					authorizeToken_onCompleteCallback del = (authorizeToken_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  verifier );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("authorizeToken finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion



#region Delegate Callbacks
	public partial class Auth {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
		/**
		 * <summary> Callback for retrieving a verification code for an OAuth token.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="verifier" cref="F:System.String">The verification code, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void authorizeToken_onCompleteCallback(SimpleAPIStatus status, Error error, String verifier);
	}
#endregion

#region Static Methods
	public partial class Auth {
		/**
		 * <summary> Generate a verification code for an OAuth request token.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="token" cref="F:System.String">The OAuth request token to verify.</param>
		 * <param name="onComplete" cref="F:Mobage.AuthorizeTokenOnCompleteCallback">
		 * Callback for retrieving a verification code for an OAuth token.</param>
		 */
		public static void authorizeToken(String token, authorizeToken_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_token = (IntPtr)Convert.toC(token);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCAuth_authorizeToken(out_token, authorizeToken_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_token);
		}
	}
#endregion


}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
