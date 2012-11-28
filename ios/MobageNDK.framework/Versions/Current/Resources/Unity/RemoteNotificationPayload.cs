//
//  RemoteNotificationPayload.cs
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
	 * <summary> Content of a remote notification.</summary>
	 * <remarks>
	 * The maximum size of the payload is 256 bytes.
	 * <p>
	 * The payload can include app-specific key/value pairs that trigger a special behavior in your app,
	 * such as displaying a message to the user on launch. These key/value pairs are stored in the
	 * <c>extraKeys</c> and <c>extraValues</c> properties.
	 * <p>
	 * <strong>Note</strong>: Some properties are used only on Android or iOS, but not both. The Mobage
	 * server automatically discards any parameters that are not supported by the target user's device.
	 * Discarded parameters do not count towards the 256-byte limit.
	 * </remarks>
	 */
	public partial class RemoteNotificationPayload {}

#region Enums / Bitfields
#endregion
	
	public partial class RemoteNotificationPayload {
		// Properties!
		public IntPtr thisObj; // Pretty Darn Internal
		
		/**
		 * The notification message.
		 */
		public String message;
		/**
		 * The numeric badge to display on the app's icon. Used only on iOS.
		 */
		public Int32 badge;
		/**
		 * The alert sound to play. This property must contain the name of a sound file in the application bundle, or <c>default</c> to play the default alert sound. The sound file must be in a format that is supported for system sounds. Used only on iOS.
		 */
		public String sound;
		/**
		 * An identifier that causes newer notifications with the same identifier to be discarded. For example, if a user receives four notifications with the same identifier, only the newest notification will be displayed on the user's device. Used only on Android.
		 */
		public String collapseKey;
		/**
		 * The layout style for the notification in the device's notification tray. Set to <c>normal</c> to display a standard-size icon or <c>largeIcon</c> to display a large icon. Used only on Android.
		 */
		public String style;
		/**
		 * The URL for the icon to display in the device's notification bar. This value is ignored unless you also use the <c>style</c> property to specify the layout style. Used only on Android.
		 */
		public String iconUrl;
		/**
		 * The app-specific keys to include in the payload. Each key must be represented as a string. The following key names are reserved and cannot be used:<ul><li><c>badge</c></li><li><c>collapseKey</c></li><li><c>extras</c></li><li><c>iconUrl</c></li><li><c>message</c></li><li><c>sound</c></li><li><c>style</c></li></ul>
		 */
		public List<String> extraKeys;
		/**
		 * The app-specific values to include in the payload. Each value must be represented as a string.
		 */
		public List<String> extraValues;
		
		// Factories!
		public static RemoteNotificationPayload Factory(IntPtr cobj){
			CRemoteNotificationPayload tmp = (CRemoteNotificationPayload)Marshal.PtrToStructure(cobj, typeof(CRemoteNotificationPayload));
			tmp.thisObj = cobj;
			RemoteNotificationPayload result = Factory(ref tmp);
			return result;
		}
		private static RemoteNotificationPayload Factory(ref CRemoteNotificationPayload cobj) {
			RemoteNotificationPayload tmp = new RemoteNotificationPayload();
			tmp.thisObj = cobj.thisObj;
			MBCRetainRemoteNotificationPayload(tmp.thisObj);
			
			tmp.message = Convert.toCS_String(cobj.message);
			tmp.badge = Convert.toCS_Integer(cobj.badge);
			tmp.sound = Convert.toCS_String(cobj.sound);
			tmp.collapseKey = Convert.toCS_String(cobj.collapseKey);
			tmp.style = Convert.toCS_String(cobj.style);
			tmp.iconUrl = Convert.toCS_String(cobj.iconUrl);
			tmp.extraKeys = Convert.toCS_String_Array(cobj.extraKeys);
			tmp.extraValues = Convert.toCS_String_Array(cobj.extraValues);
			
			return tmp;
		}
		
		~RemoteNotificationPayload(){
			MBCReleaseRemoteNotificationPayload(thisObj);
			thisObj = IntPtr.Zero;
		}
	}
#region CLayer Marshaling [Shadow Objects]
	public partial class RemoteNotificationPayload {
		[StructLayout (LayoutKind.Sequential)]
		private struct CRemoteNotificationPayload {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr message;
			public Int32 badge;
			public IntPtr sound;
			public IntPtr collapseKey;
			public IntPtr style;
			public IntPtr iconUrl;
			public IntPtr extraKeys;
			public IntPtr extraValues;
			//End of Marshal struct
		}
		
		[StructLayout (LayoutKind.Sequential)]
		public struct RemoteNotificationPayload_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<RemoteNotificationPayload> Factory(IntPtr cobj){
				RemoteNotificationPayload_Array tmp = (RemoteNotificationPayload_Array)Marshal.PtrToStructure(cobj,typeof(RemoteNotificationPayload_Array));
				return tmp.toList();
			}
			private List<RemoteNotificationPayload> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<RemoteNotificationPayload>();
				}
				
				List<RemoteNotificationPayload> tmp = new List<RemoteNotificationPayload>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					RemoteNotificationPayload tmpItem = Convert.toCS_RemoteNotificationPayload(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(RemoteNotificationPayload obj){
			RemoteNotificationPayload.MBCRetainRemoteNotificationPayload(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<RemoteNotificationPayload> list){
			RemoteNotificationPayload.RemoteNotificationPayload_Array tmp = new RemoteNotificationPayload.RemoteNotificationPayload_Array();
			tmp.length = list.Count;
			tmp.elements = Marshal.AllocHGlobal(4 * list.Count);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = RemoteNotificationPayload.MBCCopyConstructRemoteNotificationPayload_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static RemoteNotificationPayload toCS_RemoteNotificationPayload(IntPtr obj){
			return RemoteNotificationPayload.Factory(obj);
		}
		public static List<RemoteNotificationPayload> toCS_RemoteNotificationPayload_Array(IntPtr obj){
			return RemoteNotificationPayload.RemoteNotificationPayload_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class RemoteNotificationPayload {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructRemoteNotificationPayload(IntPtr /*RemoteNotificationPayload*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructRemoteNotificationPayload_Array(IntPtr /*RemoteNotificationPayload_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainRemoteNotificationPayload(IntPtr /*RemoteNotificationPayload*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseRemoteNotificationPayload(IntPtr /*RemoteNotificationPayload*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainRemoteNotificationPayload_Array(IntPtr /*RemoteNotificationPayload_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseRemoteNotificationPayload_Array(IntPtr /*RemoteNotificationPayload_Array*/ objects);

	
	}
#endregion
#region Native Return Points
	public partial class RemoteNotificationPayload {
	}
#endregion



#region Delegate Callbacks
	public partial class RemoteNotificationPayload {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
	}
#endregion

#region Static Methods
	public partial class RemoteNotificationPayload {
	}
#endregion

#region Instance Methods
	public partial class RemoteNotificationPayload {
	}
#endregion

}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
