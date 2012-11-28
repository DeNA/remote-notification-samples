//
//  MobageUtils.cs
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using UnityEngine;

namespace Mobage {
#region Mono Magic!
	public class MonoPInvokeCallbackAttribute : System.Attribute
	{
		private Type type;
		public MonoPInvokeCallbackAttribute( Type t ) { type = t; }
	}
#endregion
	
#region Enums
	/**
	
	 */
	public enum SimpleAPIStatus {
		/**
		
		 */
		SimpleAPIStatusSuccess = 0, 
		/**
		
		 */
		SimpleAPIStatusError = 1, 
	};
	
	public partial class Convert {
		public static bool IsSimpleAPIStatus(int intFlag){return (!((intFlag < 0) || (intFlag > 1))); }
		public static int toC(SimpleAPIStatus enumValue){return (int)enumValue;}
		public static SimpleAPIStatus toCS_SimpleAPIStatus(int enumValue){return (SimpleAPIStatus)enumValue;}
	}
	
	/**
	
	 */
	public enum DismissableAPIStatus {
		/**
		
		 */
		DismissableAPIStatusSuccess = 0, 
		/**
		
		 */
		DismissableAPIStatusError = 1, 
		/**
		
		 */
		DismissableAPIStatusDismiss = 2, 
	};
	
	public partial class Convert {
		public static bool IsDismissableAPIStatus(int intFlag){return (!((intFlag < 0) || (intFlag > 2))); }
		public static int toC(DismissableAPIStatus enumValue){return (int)enumValue;}
		public static DismissableAPIStatus toCS_DismissableAPIStatus(int enumValue){return (DismissableAPIStatus)enumValue;}
	}
	
	/**
	
	 */
	public enum CancelableAPIStatus {
		/**
		
		 */
		CancelableAPIStatusSuccess = 0, 
		/**
		
		 */
		CancelableAPIStatusError = 1, 
		/**
		
		 */
		CancelableAPIStatusCancel = 2, 
	};
	
	public partial class Convert {
		public static bool IsCancelableAPIStatus(int intFlag){return (!((intFlag < 0) || (intFlag > 2))); }
		public static int toC(CancelableAPIStatus enumValue){return (int)enumValue;}
		public static CancelableAPIStatus toCS_CancelableAPIStatus(int enumValue){return (CancelableAPIStatus)enumValue;}
	}
	
#endregion
	
	public class MobageLogger : MonoBehaviour
	{
		public static bool LoggingEnabled = true;
		public static void exceptionLog(object obj)
		{
			if (!MobageLogger.LoggingEnabled){return;}
			print("MBUnityLogger[GameException]: "+obj);
		}
		public static void log(object obj)
		{
			if (!MobageLogger.LoggingEnabled){return;}
			print("MBUnityLogger[Log]: "+obj);
		}
	}
		
	[StructLayout (LayoutKind.Sequential)]
	public struct CString {
		public uint __CAPI_REFCOUNT; // VERY INTERNAL
		public IntPtr thisObj; // ALSO VERY INTERNAL
				
		public IntPtr c_str;
					//End of Marshal struct
	}
	
	[StructLayout (LayoutKind.Sequential)]
	public struct String_Array {
		private uint __CAPI_REFCOUNT; // VERY INTERNAL
		private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		public int length;
		public IntPtr elements;
		
		public static List<String> Factory(IntPtr cobj){
			String_Array tmp = (String_Array)Marshal.PtrToStructure(cobj,typeof(String_Array));
			return tmp.toList();
		}
		private List<String> toList()
		{
			if (length <= 0 || elements == IntPtr.Zero){
				return new List<String>();
			}
			
			List<String> tmp = new List<String>(length);
			uint stepSize = 4;
			
			for (int i = 0; i < length; i++){
				// Calculate current offset from start of elements
				uint offset = ((uint)i) * stepSize;
				
				// Jump to the offset, and then deref pointer to get another pointer
				// 		This means read the integer at the location of
				//		(start + offset), and turn that into a new pointer
				IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,(int)offset));
				
				String tmpItem = Convert.toCS_String(curPtr);
				if (tmpItem != null){
					tmp.Add(tmpItem);
				}
			}
			return tmp;
		}
	}
		
	public partial class Convert {
		public static IntPtr toC(String str)
		{
			return MarshalPtrToUtf8.GetInstance("").MarshalManagedToNative(str);
		}
		private static CString toC_MBCString(String str){
			CString tmp = new CString();
			tmp.__CAPI_REFCOUNT = 1;
			tmp.thisObj = IntPtr.Zero;
			tmp.c_str = Convert.toC(str);
			return tmp;
		}
		public static IntPtr toC(List<String> list)
		{
			List<IntPtr> allocatedMemory = new List<IntPtr>();
			String_Array tmp = new String_Array();
			tmp.length = list.Count;
			tmp.elements = Marshal.AllocHGlobal(4 * list.Count);
			
			CString tmpMBCString = new CString();
			tmpMBCString.__CAPI_REFCOUNT = 1;
			tmpMBCString.c_str = IntPtr.Zero;
			for (int i = 0; i < tmp.length; i++)
			{
				IntPtr nativeObj = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CString)));
				allocatedMemory.Add(nativeObj);
				
				tmpMBCString.c_str = Convert.toC(list[i]);
				allocatedMemory.Add(tmpMBCString.c_str);
				
				Marshal.StructureToPtr(tmpMBCString, nativeObj, false);
				
				Marshal.WriteIntPtr(tmp.elements, i * 4, nativeObj);
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = MBCCopyConstructString_Array(tmpHandle.AddrOfPinnedObject(),Convert.toC_Bool(true));
			
			tmpHandle.Free();
			
			foreach(IntPtr tPtr in allocatedMemory){
				Marshal.FreeHGlobal(tPtr);
			}
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static String toCS_String(IntPtr obj){
			return (String)Marshal.PtrToStringAnsi(obj);
		}
		public static List<String> toCS_String_Array(IntPtr obj){
			return String_Array.Factory(obj);
		}
		
		
		public static double toCS_Double(double obj){
			return obj;
		}
		public static int toCS_Integer(int obj){
			return obj;
		}
		public static bool toCS_Bool(short obj){
			return (obj == 0) ? false : true;
		}
		public static short toC_Bool(bool obj){
			return (short)((obj) ? 1 : 0);
		}
		
		#if UNITY_IPHONE && !UNITY_EDITOR
			[DllImport("__Internal")]
		#else
			[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
		#endif
			private static extern IntPtr MBCCopyConstructString(IntPtr /*MBCString*/ obj);
		#if UNITY_IPHONE && !UNITY_EDITOR
			[DllImport("__Internal")]
		#else
			[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
		#endif
			private static extern IntPtr MBCCopyConstructString_Array(IntPtr /*MBCString_Array*/ obj, short shouldCopyArrayElements);
	}
	
	// From: http://blog.gebhardtcomputing.com/2007/11/marshal-utf8-strings-in-net.html
	public class MarshalPtrToUtf8 : ICustomMarshaler
	{
		static MarshalPtrToUtf8 marshaler = new MarshalPtrToUtf8();

		public void CleanUpManagedData(object ManagedObj)
		{

		}

		public void CleanUpNativeData(IntPtr pNativeData)
		{
			Marshal.Release(pNativeData);
		}

		public int GetNativeDataSize()
		{
			return Marshal.SizeOf(typeof(byte));
		}

		public int GetNativeDataSize(IntPtr ptr)
		{
			int size = 0;
			
			for (size = 0; Marshal.ReadByte(ptr, size) > 0; size++)
				; //All done in ReadByte
			
			return size;
		}

		public IntPtr MarshalManagedToNative(object ManagedObj)
		{
			if (ManagedObj == null)
				return IntPtr.Zero;
			if (ManagedObj.GetType() != typeof(string))
				throw new ArgumentException("ManagedObj", "Can only marshal type of System.String");
			byte[] array = Encoding.UTF8.GetBytes((string)ManagedObj);
			int size = Marshal.SizeOf(array[0]) * array.Length + Marshal.SizeOf(array[0]);
			IntPtr ptr = Marshal.AllocHGlobal(size);
			Marshal.Copy(array, 0, ptr, array.Length);
			Marshal.WriteByte(ptr, size - 1, 0);
			return ptr;
		}

		public object MarshalNativeToManaged(IntPtr pNativeData)
		{
			if (pNativeData == IntPtr.Zero)
				return null;
			int size = GetNativeDataSize(pNativeData);
			byte[] array = new byte[size - 1];
			Marshal.Copy(pNativeData, array, 0, size - 1);
			return Encoding.UTF8.GetString(array);
		}

		public static ICustomMarshaler GetInstance(string cookie)
		{
			return marshaler;
		}
	}
}
