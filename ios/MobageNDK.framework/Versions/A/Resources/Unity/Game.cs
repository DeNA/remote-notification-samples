//
//  Game.cs
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
	 * <summary></summary>
	 * <remarks>

	 * </remarks>
	 */
	public partial class Game {}

#region Enums / Bitfields
#endregion
	
	public partial class Game {
		// Properties!
		public IntPtr thisObj; // Pretty Darn Internal
		
		public String uid;
		public String name;
		public String longDescription;
		public String publisherName;
		public String appStoreURL;
		public String appKey;
		public String iconUrl;
		public String largeIconUrl;
		public bool installed;
		public bool featured;
		public String promotionImageUrl;
		
		// Factories!
		public static Game Factory(IntPtr cobj){
			CGame tmp = (CGame)Marshal.PtrToStructure(cobj, typeof(CGame));
			tmp.thisObj = cobj;
			Game result = Factory(ref tmp);
			return result;
		}
		private static Game Factory(ref CGame cobj) {
			Game tmp = new Game();
			tmp.thisObj = cobj.thisObj;
			MBCRetainGame(tmp.thisObj);
			
			tmp.uid = Convert.toCS_String(cobj.uid);
			tmp.name = Convert.toCS_String(cobj.name);
			tmp.longDescription = Convert.toCS_String(cobj.longDescription);
			tmp.publisherName = Convert.toCS_String(cobj.publisherName);
			tmp.appStoreURL = Convert.toCS_String(cobj.appStoreURL);
			tmp.appKey = Convert.toCS_String(cobj.appKey);
			tmp.iconUrl = Convert.toCS_String(cobj.iconUrl);
			tmp.largeIconUrl = Convert.toCS_String(cobj.largeIconUrl);
			tmp.installed = Convert.toCS_Bool(cobj.installed);
			tmp.featured = Convert.toCS_Bool(cobj.featured);
			tmp.promotionImageUrl = Convert.toCS_String(cobj.promotionImageUrl);
			
			return tmp;
		}
		
		~Game(){
			MBCReleaseGame(thisObj);
			thisObj = IntPtr.Zero;
		}
	}
#region CLayer Marshaling [Shadow Objects]
	public partial class Game {
		[StructLayout (LayoutKind.Sequential)]
		private struct CGame {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr uid;
			public IntPtr name;
			public IntPtr longDescription;
			public IntPtr publisherName;
			public IntPtr appStoreURL;
			public IntPtr appKey;
			public IntPtr iconUrl;
			public IntPtr largeIconUrl;
			public short installed;
			public short featured;
			public IntPtr promotionImageUrl;
			//End of Marshal struct
		}
		
		[StructLayout (LayoutKind.Sequential)]
		public struct Game_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<Game> Factory(IntPtr cobj){
				Game_Array tmp = (Game_Array)Marshal.PtrToStructure(cobj,typeof(Game_Array));
				return tmp.toList();
			}
			private List<Game> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<Game>();
				}
				
				List<Game> tmp = new List<Game>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					Game tmpItem = Convert.toCS_Game(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(Game obj){
			Game.MBCRetainGame(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<Game> list){
			Game.Game_Array tmp = new Game.Game_Array();
			tmp.length = list.Count;
			tmp.elements = Marshal.AllocHGlobal(4 * list.Count);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = Game.MBCCopyConstructGame_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static Game toCS_Game(IntPtr obj){
			return Game.Factory(obj);
		}
		public static List<Game> toCS_Game_Array(IntPtr obj){
			return Game.Game_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class Game {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructGame(IntPtr /*Game*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructGame_Array(IntPtr /*Game_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainGame(IntPtr /*Game*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseGame(IntPtr /*Game*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainGame_Array(IntPtr /*Game_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseGame_Array(IntPtr /*Game_Array*/ objects);

	
	}
#endregion
#region Native Return Points
	public partial class Game {
	}
#endregion



#region Delegate Callbacks
	public partial class Game {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
	}
#endregion

#region Static Methods
	public partial class Game {
	}
#endregion

#region Instance Methods
	public partial class Game {
	}
#endregion

}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
