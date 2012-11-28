//
//  RewardCampaignCode.cs
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
	public partial class RewardCampaignCode {}

#region Enums / Bitfields
#endregion
	
	public partial class RewardCampaignCode {
		// Properties!
		public IntPtr thisObj; // Pretty Darn Internal
		
		public String uid;
		public String code;
		public String channel;
		public String marketingCopy;
		public String iconUrl;
		public Int32 redemptions;
		
		// Factories!
		public static RewardCampaignCode Factory(IntPtr cobj){
			CRewardCampaignCode tmp = (CRewardCampaignCode)Marshal.PtrToStructure(cobj, typeof(CRewardCampaignCode));
			tmp.thisObj = cobj;
			RewardCampaignCode result = Factory(ref tmp);
			return result;
		}
		private static RewardCampaignCode Factory(ref CRewardCampaignCode cobj) {
			RewardCampaignCode tmp = new RewardCampaignCode();
			tmp.thisObj = cobj.thisObj;
			MBCRetainRewardCampaignCode(tmp.thisObj);
			
			tmp.uid = Convert.toCS_String(cobj.uid);
			tmp.code = Convert.toCS_String(cobj.code);
			tmp.channel = Convert.toCS_String(cobj.channel);
			tmp.marketingCopy = Convert.toCS_String(cobj.marketingCopy);
			tmp.iconUrl = Convert.toCS_String(cobj.iconUrl);
			tmp.redemptions = Convert.toCS_Integer(cobj.redemptions);
			
			return tmp;
		}
		
		~RewardCampaignCode(){
			MBCReleaseRewardCampaignCode(thisObj);
			thisObj = IntPtr.Zero;
		}
	}
#region CLayer Marshaling [Shadow Objects]
	public partial class RewardCampaignCode {
		[StructLayout (LayoutKind.Sequential)]
		private struct CRewardCampaignCode {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr uid;
			public IntPtr code;
			public IntPtr channel;
			public IntPtr marketingCopy;
			public IntPtr iconUrl;
			public Int32 redemptions;
			//End of Marshal struct
		}
		
		[StructLayout (LayoutKind.Sequential)]
		public struct RewardCampaignCode_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<RewardCampaignCode> Factory(IntPtr cobj){
				RewardCampaignCode_Array tmp = (RewardCampaignCode_Array)Marshal.PtrToStructure(cobj,typeof(RewardCampaignCode_Array));
				return tmp.toList();
			}
			private List<RewardCampaignCode> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<RewardCampaignCode>();
				}
				
				List<RewardCampaignCode> tmp = new List<RewardCampaignCode>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					RewardCampaignCode tmpItem = Convert.toCS_RewardCampaignCode(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(RewardCampaignCode obj){
			RewardCampaignCode.MBCRetainRewardCampaignCode(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<RewardCampaignCode> list){
			RewardCampaignCode.RewardCampaignCode_Array tmp = new RewardCampaignCode.RewardCampaignCode_Array();
			tmp.length = list.Count;
			tmp.elements = Marshal.AllocHGlobal(4 * list.Count);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = RewardCampaignCode.MBCCopyConstructRewardCampaignCode_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static RewardCampaignCode toCS_RewardCampaignCode(IntPtr obj){
			return RewardCampaignCode.Factory(obj);
		}
		public static List<RewardCampaignCode> toCS_RewardCampaignCode_Array(IntPtr obj){
			return RewardCampaignCode.RewardCampaignCode_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class RewardCampaignCode {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructRewardCampaignCode(IntPtr /*RewardCampaignCode*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructRewardCampaignCode_Array(IntPtr /*RewardCampaignCode_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainRewardCampaignCode(IntPtr /*RewardCampaignCode*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseRewardCampaignCode(IntPtr /*RewardCampaignCode*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainRewardCampaignCode_Array(IntPtr /*RewardCampaignCode_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseRewardCampaignCode_Array(IntPtr /*RewardCampaignCode_Array*/ objects);

	
	}
#endregion
#region Native Return Points
	public partial class RewardCampaignCode {
	}
#endregion



#region Delegate Callbacks
	public partial class RewardCampaignCode {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
	}
#endregion

#region Static Methods
	public partial class RewardCampaignCode {
	}
#endregion

#region Instance Methods
	public partial class RewardCampaignCode {
	}
#endregion

#endif // MB_WW -- whole interface/model is region-specific
}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
