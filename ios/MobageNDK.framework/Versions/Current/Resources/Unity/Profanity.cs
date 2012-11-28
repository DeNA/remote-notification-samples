//
//  Profanity.cs
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
	 * <summary> Determine whether a string contains words that are clearly profane or offensive.</summary>
	 * <remarks>
	 * On the US/worldwide platform, this class checks for English-language profanity.
	 * <p>
	 * The list of profane and offensive words may be updated at any time.
	 * </remarks>
	 */
	public partial class Profanity {}

#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class Profanity {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCProfanity_checkProfanity(IntPtr input_text, checkProfanity_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion
#region Native Return Points
	public partial class Profanity {
		private delegate void checkProfanity_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, bool input_textIsValid, IntPtr context);
		[MonoPInvokeCallback (typeof (checkProfanity_onCompleteCallbackDispatcherDelegate))]
		private static void checkProfanity_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, bool input_textIsValid, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			bool textIsValid = input_textIsValid;
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("checkProfanity callback about to invoke!");
				try {
					checkProfanity_onCompleteCallback del = (checkProfanity_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  textIsValid );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("checkProfanity finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion



#region Delegate Callbacks
	public partial class Profanity {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
		/**
		 * <summary> Callback for checking a text string for profane or offensive words.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="textIsValid" cref="F:System.bool">Set to <c>true</c> if the string is valid, or <c>false</c> if the string contains profane or offensive words.</param>
		 */
		public delegate void checkProfanity_onCompleteCallback(SimpleAPIStatus status, Error error, bool textIsValid);
	}
#endregion

#region Static Methods
	public partial class Profanity {
		/**
		 * <summary> Check a text string to determine whether it contains words that are clearly profane or offensive.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="text" cref="F:System.String">The string to check for profanity.</param>
		 * <param name="onComplete" cref="F:Mobage.CheckProfanityOnCompleteCallback">
		 * Callback for checking a text string for profane or offensive words.</param>
		 */
		public static void checkProfanity(String text, checkProfanity_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_text = (IntPtr)Convert.toC(text);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCProfanity_checkProfanity(out_text, checkProfanity_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_text);
		}
	}
#endregion


}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
