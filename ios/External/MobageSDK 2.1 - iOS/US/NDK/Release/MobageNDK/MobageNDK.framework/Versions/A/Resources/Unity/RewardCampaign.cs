//
//  RewardCampaign.cs
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
	public partial class RewardCampaign {}

#region Enums / Bitfields
#endregion
	
	public partial class RewardCampaign {
		// Properties!
		public IntPtr thisObj; // Pretty Darn Internal
		
		public String uid;
		public Int32 redemptions;
		public Int32 startsAt;
		public Int32 endsAt;
		public Int32 expiresAt;
		public String payload;
		public List<RewardCampaignCode> codes;
		
		// Factories!
		public static RewardCampaign Factory(IntPtr cobj){
			CRewardCampaign tmp = (CRewardCampaign)Marshal.PtrToStructure(cobj, typeof(CRewardCampaign));
			tmp.thisObj = cobj;
			RewardCampaign result = Factory(ref tmp);
			return result;
		}
		private static RewardCampaign Factory(ref CRewardCampaign cobj) {
			RewardCampaign tmp = new RewardCampaign();
			tmp.thisObj = cobj.thisObj;
			MBCRetainRewardCampaign(tmp.thisObj);
			
			tmp.uid = Convert.toCS_String(cobj.uid);
			tmp.redemptions = Convert.toCS_Integer(cobj.redemptions);
			tmp.startsAt = Convert.toCS_Integer(cobj.startsAt);
			tmp.endsAt = Convert.toCS_Integer(cobj.endsAt);
			tmp.expiresAt = Convert.toCS_Integer(cobj.expiresAt);
			tmp.payload = Convert.toCS_String(cobj.payload);
			tmp.codes = Convert.toCS_RewardCampaignCode_Array(cobj.codes);
			
			return tmp;
		}
		
		~RewardCampaign(){
			MBCReleaseRewardCampaign(thisObj);
			thisObj = IntPtr.Zero;
		}
	}
#region CLayer Marshaling [Shadow Objects]
	public partial class RewardCampaign {
		[StructLayout (LayoutKind.Sequential)]
		private struct CRewardCampaign {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr uid;
			public Int32 redemptions;
			public Int32 startsAt;
			public Int32 endsAt;
			public Int32 expiresAt;
			public IntPtr payload;
			public IntPtr codes;
			//End of Marshal struct
		}
		
		[StructLayout (LayoutKind.Sequential)]
		public struct RewardCampaign_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<RewardCampaign> Factory(IntPtr cobj){
				RewardCampaign_Array tmp = (RewardCampaign_Array)Marshal.PtrToStructure(cobj,typeof(RewardCampaign_Array));
				return tmp.toList();
			}
			private List<RewardCampaign> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<RewardCampaign>();
				}
				
				List<RewardCampaign> tmp = new List<RewardCampaign>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					RewardCampaign tmpItem = Convert.toCS_RewardCampaign(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(RewardCampaign obj){
			RewardCampaign.MBCRetainRewardCampaign(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<RewardCampaign> list){
			RewardCampaign.RewardCampaign_Array tmp = new RewardCampaign.RewardCampaign_Array();
			tmp.length = list.Count;
			tmp.elements = Marshal.AllocHGlobal(4 * list.Count);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = RewardCampaign.MBCCopyConstructRewardCampaign_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static RewardCampaign toCS_RewardCampaign(IntPtr obj){
			return RewardCampaign.Factory(obj);
		}
		public static List<RewardCampaign> toCS_RewardCampaign_Array(IntPtr obj){
			return RewardCampaign.RewardCampaign_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class RewardCampaign {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructRewardCampaign(IntPtr /*RewardCampaign*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructRewardCampaign_Array(IntPtr /*RewardCampaign_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainRewardCampaign(IntPtr /*RewardCampaign*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseRewardCampaign(IntPtr /*RewardCampaign*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainRewardCampaign_Array(IntPtr /*RewardCampaign_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseRewardCampaign_Array(IntPtr /*RewardCampaign_Array*/ objects);

#if MB_WW
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCRewardCampaign_getActiveCampaigns(getActiveCampaigns_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
#endif // MB_WW
	
	}
#endregion
#region Native Return Points
	public partial class RewardCampaign {
		private delegate void getActiveCampaigns_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_activeCampaigns, IntPtr context);
		[MonoPInvokeCallback (typeof (getActiveCampaigns_onCompleteCallbackDispatcherDelegate))]
		private static void getActiveCampaigns_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_activeCampaigns, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<RewardCampaign> activeCampaigns = null;
			if (input_activeCampaigns != IntPtr.Zero){
				activeCampaigns = Convert.toCS_RewardCampaign_Array(input_activeCampaigns);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getActiveCampaigns callback about to invoke!");
				try {
					getActiveCampaigns_onCompleteCallback del = (getActiveCampaigns_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  activeCampaigns );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getActiveCampaigns finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion



#region Delegate Callbacks
	public partial class RewardCampaign {
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
		 * <param name="activeCampaigns" cref="F:System.Collections.Generic.List<Mobage.RewardCampaign>"></param>
		 */
		public delegate void getActiveCampaigns_onCompleteCallback(SimpleAPIStatus status, Error error, List<RewardCampaign> activeCampaigns);
	}
#endregion

#region Static Methods
	public partial class RewardCampaign {
#if MB_WW
		/**
		 * <summary></summary>
		 * <remarks>

		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.GetActiveCampaignsOnCompleteCallback">
</param>
		 */
		public static void getActiveCampaigns(getActiveCampaigns_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCRewardCampaign_getActiveCampaigns(getActiveCampaigns_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
#endif // MB_WW
	}
#endregion

#region Instance Methods
	public partial class RewardCampaign {
	}
#endregion

#endif // MB_WW -- whole interface/model is region-specific
}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
