//
//  Reward.cs
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
#if MB_WW // whole interface/model is region-specific

	/**
	 * <summary></summary>
	 * <remarks>

	 * </remarks>
	 */
	public partial class Reward {}

#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class Reward {

#if MB_WW
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCReward_redeemRewardCode(IntPtr input_code, redeemRewardCode_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_WW
	
	}
#endregion
#region Native Return Points
	public partial class Reward {
		private delegate void redeemRewardCode_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_inviter, Int32 input_redemptions, IntPtr input_payload, IntPtr context);
		[MonoPInvokeCallback (typeof (redeemRewardCode_onCompleteCallbackDispatcherDelegate))]
		private static void redeemRewardCode_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_inviter, Int32 input_redemptions, IntPtr input_payload, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			User inviter = null;
			if (input_inviter != IntPtr.Zero){
				inviter = Convert.toCS_User(input_inviter);
			}
			Int32 redemptions = input_redemptions;
			String payload = null;
			if (input_payload != IntPtr.Zero){
				payload = Convert.toCS_String(input_payload);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("redeemRewardCode callback about to invoke!");
				try {
					redeemRewardCode_onCompleteCallback del = (redeemRewardCode_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  inviter,  redemptions,  payload );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("redeemRewardCode finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion



#region Delegate Callbacks
	public partial class Reward {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
		/**
		 * <summary></summary>
		 * <remarks>

		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus"></param>
		 * <param name="error" cref="F:Mobage.Error"></param>
		 * <param name="inviter" cref="F:Mobage.User"></param>
		 * <param name="redemptions" cref="F:System.Int32"></param>
		 * <param name="payload" cref="F:System.String"></param>
		 */
		public delegate void redeemRewardCode_onCompleteCallback(SimpleAPIStatus status, Error error, User inviter, Int32 redemptions, String payload);
	}
#endregion

#region Static Methods
	public partial class Reward {
#if MB_WW
		/**
		 * <summary></summary>
		 * <remarks>

		 * </remarks>
		 * <param name="code" cref="F:System.String"></param>
		 * <param name="onComplete" cref="F:Mobage.RedeemRewardCodeOnCompleteCallback">
</param>
		 */
		public static void redeemRewardCode(String code, redeemRewardCode_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_code = (IntPtr)Convert.toC(code);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCReward_redeemRewardCode(out_code, redeemRewardCode_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_code);
		}
#endif // MB_WW
	}
#endregion


#endif // MB_WW -- whole interface/model is region-specific
}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
