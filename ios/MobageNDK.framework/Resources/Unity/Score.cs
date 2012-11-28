//
//  Score.cs
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
	 * <summary> Model for information about a high score on a leaderboard.</summary>
	 * <remarks>
	 
	 * </remarks>
	 */
	public partial class Score {}

#region Enums / Bitfields
#endregion
	
	public partial class Score {
		// Properties!
		public IntPtr thisObj; // Pretty Darn Internal
		
		public String uid;
		/**
		 * The Mobage user ID associated with the score.
		 */
		public String userId;
		/**
		 * The value of the score.
		 */
		public double scoreValue;
		/**
		 * A version of the score that has been formatted for display, based on the leaderboard's settings.
		 */
		public String displayValue;
		/**
		 * The score's rank within the leaderboard.
		 */
		public Int32 rank;
		
		// Factories!
		public static Score Factory(IntPtr cobj){
			CScore tmp = (CScore)Marshal.PtrToStructure(cobj, typeof(CScore));
			tmp.thisObj = cobj;
			Score result = Factory(ref tmp);
			return result;
		}
		private static Score Factory(ref CScore cobj) {
			Score tmp = new Score();
			tmp.thisObj = cobj.thisObj;
			MBCRetainScore(tmp.thisObj);
			
			tmp.uid = Convert.toCS_String(cobj.uid);
			tmp.userId = Convert.toCS_String(cobj.userId);
			tmp.scoreValue = Convert.toCS_Double(cobj.scoreValue);
			tmp.displayValue = Convert.toCS_String(cobj.displayValue);
			tmp.rank = Convert.toCS_Integer(cobj.rank);
			
			return tmp;
		}
		
		~Score(){
			MBCReleaseScore(thisObj);
			thisObj = IntPtr.Zero;
		}
	}
#region CLayer Marshaling [Shadow Objects]
	public partial class Score {
		[StructLayout (LayoutKind.Sequential)]
		private struct CScore {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr uid;
			public IntPtr userId;
			public double scoreValue;
			public IntPtr displayValue;
			public Int32 rank;
			//End of Marshal struct
		}
		
		[StructLayout (LayoutKind.Sequential)]
		public struct Score_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<Score> Factory(IntPtr cobj){
				Score_Array tmp = (Score_Array)Marshal.PtrToStructure(cobj,typeof(Score_Array));
				return tmp.toList();
			}
			private List<Score> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<Score>();
				}
				
				List<Score> tmp = new List<Score>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					Score tmpItem = Convert.toCS_Score(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(Score obj){
			Score.MBCRetainScore(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<Score> list){
			Score.Score_Array tmp = new Score.Score_Array();
			tmp.length = list.Count;
			tmp.elements = Marshal.AllocHGlobal(4 * list.Count);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = Score.MBCCopyConstructScore_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static Score toCS_Score(IntPtr obj){
			return Score.Factory(obj);
		}
		public static List<Score> toCS_Score_Array(IntPtr obj){
			return Score.Score_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class Score {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructScore(IntPtr /*Score*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructScore_Array(IntPtr /*Score_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainScore(IntPtr /*Score*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseScore(IntPtr /*Score*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainScore_Array(IntPtr /*Score_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseScore_Array(IntPtr /*Score_Array*/ objects);

	
	}
#endregion
#region Native Return Points
	public partial class Score {
	}
#endregion



#region Delegate Callbacks
	public partial class Score {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
	}
#endregion

#region Static Methods
	public partial class Score {
	}
#endregion

#region Instance Methods
	public partial class Score {
	}
#endregion

}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
