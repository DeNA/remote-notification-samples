//
//  GameLeaderboard.cs
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
	 * <summary> Information about a Mobage leaderboard.</summary>
	 * <remarks>
	 
	 * </remarks>
	 */
	public partial class GameLeaderboard {}

#region Enums / Bitfields
#endregion
	
	public partial class GameLeaderboard {
		// Properties!
		public IntPtr thisObj; // Pretty Darn Internal
		
		public String uid;
		/**
		 * The app ID associated with the leaderboard.
		 */
		public String appId;
		/**
		 * The leaderboard's title.
		 */
		public String title;
		/**
		 * The rules that the leaderboard uses to format a score for display. Contains one of the following values:<ul><li><c>day_hour</c>: Formatted as <c>DD HH.zzz</c>. The score represents the number of seconds.</li><li><c>day_minute</c>: Formatted as <c>DD HH:MM.zzz</c>. The score represents the number of seconds.</li><li><c>day_second</c>: Formatted as <c>DD HH:MM:SS.zzz</c>. The score represents the number of seconds.</li><li><c>decimal</c>: Formatted as a signed double.</li><li><c>hour_minute</c>: Formatted as <c>HH:MM.zzz</c>. The score represents the number of seconds.</li><li><c>hour_second</c>: Formatted as <c>HH:MM:SS.zzz</c>. The score represents the number of seconds.</li><li><c>hours</c>: Formatted as <c>HH.zzz</c>. The score represents the number of seconds.</li><li><c>integer</c>: Formatted as a signed 32-bit integer.</li><li><c>minute_second</c>: Formatted as <c>MM:SS.zzz</c>. The score represents the number of seconds.</li><li><c>minutes</c>: Formatted as <c>MM.zzz</c>. The score represents the number of seconds.</li><li><c>seconds</c>: Formatted as <c>SS.zzz</c>. The score represents the number of seconds.</li></ul>
		 */
		public String scoreFormat;
		/**
		 * The number of decimal places that the leaderboard uses when it reformats a score for display.
		 */
		public Int32 scorePrecision;
		/**
		 * The URL of the leaderboard icon.
		 */
		public String iconUrl;
		/**
		 * Indicates whether a user's top score can be replaced by a new, lower score.
		 */
		public bool allowLowerScore;
		/**
		 * Indicates whether the leaderboard treats lower scores as more desirable.
		 */
		public bool reverse;
		/**
		 * Indicates whether the leaderboard has been archived and can no longer be updated. This property is reserved for future use and is currently always set to <c>false</c>.
		 */
		public bool archived;
		/**
		 * The default score for users that have not recorded a top score.
		 */
		public double defaultScore;
		/**
		 * The date and time when the leaderboard was created. Uses the format <c>YYYY-MM-DDThh:mm:ss</c>.
		 */
		public String published;
		/**
		 * The date and time when the leaderboard was updated. Uses the format <c>YYYY-MM-DDThh:mm:ss</c>.
		 */
		public String updated;
		
		// Factories!
		public static GameLeaderboard Factory(IntPtr cobj){
			CGameLeaderboard tmp = (CGameLeaderboard)Marshal.PtrToStructure(cobj, typeof(CGameLeaderboard));
			tmp.thisObj = cobj;
			GameLeaderboard result = Factory(ref tmp);
			return result;
		}
		private static GameLeaderboard Factory(ref CGameLeaderboard cobj) {
			GameLeaderboard tmp = new GameLeaderboard();
			tmp.thisObj = cobj.thisObj;
			MBCRetainGameLeaderboard(tmp.thisObj);
			
			tmp.uid = Convert.toCS_String(cobj.uid);
			tmp.appId = Convert.toCS_String(cobj.appId);
			tmp.title = Convert.toCS_String(cobj.title);
			tmp.scoreFormat = Convert.toCS_String(cobj.scoreFormat);
			tmp.scorePrecision = Convert.toCS_Integer(cobj.scorePrecision);
			tmp.iconUrl = Convert.toCS_String(cobj.iconUrl);
			tmp.allowLowerScore = Convert.toCS_Bool(cobj.allowLowerScore);
			tmp.reverse = Convert.toCS_Bool(cobj.reverse);
			tmp.archived = Convert.toCS_Bool(cobj.archived);
			tmp.defaultScore = Convert.toCS_Double(cobj.defaultScore);
			tmp.published = Convert.toCS_String(cobj.published);
			tmp.updated = Convert.toCS_String(cobj.updated);
			
			return tmp;
		}
		
		~GameLeaderboard(){
			MBCReleaseGameLeaderboard(thisObj);
			thisObj = IntPtr.Zero;
		}
	}
#region CLayer Marshaling [Shadow Objects]
	public partial class GameLeaderboard {
		[StructLayout (LayoutKind.Sequential)]
		private struct CGameLeaderboard {
			public Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			public IntPtr thisObj; // ALSO VERY INTERNAL
					
			public IntPtr uid;
			public IntPtr appId;
			public IntPtr title;
			public IntPtr scoreFormat;
			public Int32 scorePrecision;
			public IntPtr iconUrl;
			public short allowLowerScore;
			public short reverse;
			public short archived;
			public double defaultScore;
			public IntPtr published;
			public IntPtr updated;
			//End of Marshal struct
		}
		
		[StructLayout (LayoutKind.Sequential)]
		public struct GameLeaderboard_Array {
			private Int32 __CAPI_REFCOUNT; // VERY INTERNAL
			private IntPtr __CAPI_NATIVEREF; // ALSO VERY INTERNAL
			
			public int length;
			public IntPtr elements;
			
			public static List<GameLeaderboard> Factory(IntPtr cobj){
				GameLeaderboard_Array tmp = (GameLeaderboard_Array)Marshal.PtrToStructure(cobj,typeof(GameLeaderboard_Array));
				return tmp.toList();
			}
			private List<GameLeaderboard> toList()
			{
				if (length <= 0 || elements == IntPtr.Zero){
					return new List<GameLeaderboard>();
				}
				
				List<GameLeaderboard> tmp = new List<GameLeaderboard>(length);
				int stepSize = 4;
				
				for (int i = 0; i < length; i++){
					// Calculate current offset from start of elements
					int offset = i * stepSize;
					
					// Jump to the offset, and then deref pointer to get another pointer
					// 		This means read the integer at the location of
					//		(start + offset), and turn that into a new pointer
					IntPtr curPtr = new IntPtr(Marshal.ReadInt32(elements,offset));
					
					GameLeaderboard tmpItem = Convert.toCS_GameLeaderboard(curPtr);
					if (tmpItem != null){
						tmp.Add(tmpItem);
					}
				}
				return tmp;
			}
		}
	}
	
	public partial class Convert {
		public static IntPtr toC(GameLeaderboard obj){
			GameLeaderboard.MBCRetainGameLeaderboard(obj.thisObj);
			return obj.thisObj;
		}
		public static IntPtr toC(List<GameLeaderboard> list){
			GameLeaderboard.GameLeaderboard_Array tmp = new GameLeaderboard.GameLeaderboard_Array();
			tmp.length = list.Count;
			tmp.elements = Marshal.AllocHGlobal(4 * list.Count);
			
			for (int i = 0; i < tmp.length; i++)
			{	
				Marshal.WriteIntPtr(tmp.elements, i * 4, Convert.toC(list[i]));
			}
			
			GCHandle tmpHandle = GCHandle.Alloc(tmp,GCHandleType.Pinned);
			
			IntPtr cVersion = GameLeaderboard.MBCCopyConstructGameLeaderboard_Array(GCHandle.ToIntPtr(tmpHandle),Convert.toC_Bool(false));
			
			tmpHandle.Free();
			
			Marshal.FreeHGlobal(tmp.elements);
			return (cVersion);
		}
		public static GameLeaderboard toCS_GameLeaderboard(IntPtr obj){
			return GameLeaderboard.Factory(obj);
		}
		public static List<GameLeaderboard> toCS_GameLeaderboard_Array(IntPtr obj){
			return GameLeaderboard.GameLeaderboard_Array.Factory(obj);
		}
	}
#endregion

#region Native Method Imports
	public partial class GameLeaderboard {
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructGameLeaderboard(IntPtr /*GameLeaderboard*/ obj, short shouldDeepCopy);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern IntPtr MBCCopyConstructGameLeaderboard_Array(IntPtr /*GameLeaderboard_Array*/ obj, short shouldCopyArrayElements);
	
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainGameLeaderboard(IntPtr /*GameLeaderboard*/ obj);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseGameLeaderboard(IntPtr /*GameLeaderboard*/ obj);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern void MBCRetainGameLeaderboard_Array(IntPtr /*GameLeaderboard_Array*/ objects);
		
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		public static extern short MBCReleaseGameLeaderboard_Array(IntPtr /*GameLeaderboard_Array*/ objects);

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCGameLeaderboard_getLeaderboardForId(IntPtr input_leaderboardId, getLeaderboardForId_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCGameLeaderboard_getLeaderboardsForIds(IntPtr input_leaderboardIds, getLeaderboardsForIds_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCGameLeaderboard_getAllLeaderboards(getAllLeaderboards_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCGameLeaderboard_getScoresForLeaderboard(IntPtr input_leaderboard, Int32 input_count, Int32 input_startIndex, getScoresForLeaderboard_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCGameLeaderboard_getFriendsScoresForLeaderboard(IntPtr input_leaderboard, Int32 input_count, Int32 input_startIndex, getFriendsScoresForLeaderboard_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCGameLeaderboard_getScoreForLeaderboard(IntPtr input_leaderboard, IntPtr input_user, getScoreForLeaderboard_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCGameLeaderboard_updateCurrentUserScoreForLeaderboard(IntPtr input_leaderboard, double input_value, updateCurrentUserScoreForLeaderboard_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCGameLeaderboard_deleteCurrentUserScoreForLeaderboard(IntPtr input_leaderboard, deleteCurrentUserScoreForLeaderboard_onCompleteCallbackDispatcherDelegate onComplete, IntPtr context);
	
	}
#endregion
#region Native Return Points
	public partial class GameLeaderboard {
		private delegate void getLeaderboardForId_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_leaderboard, IntPtr context);
		[MonoPInvokeCallback (typeof (getLeaderboardForId_onCompleteCallbackDispatcherDelegate))]
		private static void getLeaderboardForId_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_leaderboard, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			GameLeaderboard leaderboard = null;
			if (input_leaderboard != IntPtr.Zero){
				leaderboard = Convert.toCS_GameLeaderboard(input_leaderboard);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getLeaderboardForId callback about to invoke!");
				try {
					getLeaderboardForId_onCompleteCallback del = (getLeaderboardForId_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  leaderboard );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getLeaderboardForId finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getLeaderboardsForIds_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_leaderboards, IntPtr context);
		[MonoPInvokeCallback (typeof (getLeaderboardsForIds_onCompleteCallbackDispatcherDelegate))]
		private static void getLeaderboardsForIds_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_leaderboards, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<GameLeaderboard> leaderboards = null;
			if (input_leaderboards != IntPtr.Zero){
				leaderboards = Convert.toCS_GameLeaderboard_Array(input_leaderboards);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getLeaderboardsForIds callback about to invoke!");
				try {
					getLeaderboardsForIds_onCompleteCallback del = (getLeaderboardsForIds_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  leaderboards );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getLeaderboardsForIds finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getAllLeaderboards_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_leaderboards, IntPtr context);
		[MonoPInvokeCallback (typeof (getAllLeaderboards_onCompleteCallbackDispatcherDelegate))]
		private static void getAllLeaderboards_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_leaderboards, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<GameLeaderboard> leaderboards = null;
			if (input_leaderboards != IntPtr.Zero){
				leaderboards = Convert.toCS_GameLeaderboard_Array(input_leaderboards);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getAllLeaderboards callback about to invoke!");
				try {
					getAllLeaderboards_onCompleteCallback del = (getAllLeaderboards_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  leaderboards );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getAllLeaderboards finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getScoresForLeaderboard_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_scores, IntPtr context);
		[MonoPInvokeCallback (typeof (getScoresForLeaderboard_onCompleteCallbackDispatcherDelegate))]
		private static void getScoresForLeaderboard_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_scores, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<Score> scores = null;
			if (input_scores != IntPtr.Zero){
				scores = Convert.toCS_Score_Array(input_scores);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getScoresForLeaderboard callback about to invoke!");
				try {
					getScoresForLeaderboard_onCompleteCallback del = (getScoresForLeaderboard_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  scores );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getScoresForLeaderboard finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getFriendsScoresForLeaderboard_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_scores, IntPtr context);
		[MonoPInvokeCallback (typeof (getFriendsScoresForLeaderboard_onCompleteCallbackDispatcherDelegate))]
		private static void getFriendsScoresForLeaderboard_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_scores, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			List<Score> scores = null;
			if (input_scores != IntPtr.Zero){
				scores = Convert.toCS_Score_Array(input_scores);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getFriendsScoresForLeaderboard callback about to invoke!");
				try {
					getFriendsScoresForLeaderboard_onCompleteCallback del = (getFriendsScoresForLeaderboard_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  scores );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getFriendsScoresForLeaderboard finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void getScoreForLeaderboard_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_score, IntPtr context);
		[MonoPInvokeCallback (typeof (getScoreForLeaderboard_onCompleteCallbackDispatcherDelegate))]
		private static void getScoreForLeaderboard_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_score, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Score score = null;
			if (input_score != IntPtr.Zero){
				score = Convert.toCS_Score(input_score);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("getScoreForLeaderboard callback about to invoke!");
				try {
					getScoreForLeaderboard_onCompleteCallback del = (getScoreForLeaderboard_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  score );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("getScoreForLeaderboard finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void updateCurrentUserScoreForLeaderboard_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr input_score, IntPtr context);
		[MonoPInvokeCallback (typeof (updateCurrentUserScoreForLeaderboard_onCompleteCallbackDispatcherDelegate))]
		private static void updateCurrentUserScoreForLeaderboard_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr input_score, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			Score score = null;
			if (input_score != IntPtr.Zero){
				score = Convert.toCS_Score(input_score);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("updateCurrentUserScoreForLeaderboard callback about to invoke!");
				try {
					updateCurrentUserScoreForLeaderboard_onCompleteCallback del = (updateCurrentUserScoreForLeaderboard_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error,  score );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("updateCurrentUserScoreForLeaderboard finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
		private delegate void deleteCurrentUserScoreForLeaderboard_onCompleteCallbackDispatcherDelegate(Int32 input_status, IntPtr input_error, IntPtr context);
		[MonoPInvokeCallback (typeof (deleteCurrentUserScoreForLeaderboard_onCompleteCallbackDispatcherDelegate))]
		private static void deleteCurrentUserScoreForLeaderboard_onCompleteCallbackDispatcher(Int32 input_status, IntPtr input_error, IntPtr context)
		{
			SimpleAPIStatus status = Convert.toCS_SimpleAPIStatus(input_status);
			Error error = null;
			if (input_error != IntPtr.Zero){
				error = Convert.toCS_Error(input_error);
			}
			int cbKey = context.ToInt32();
			if (pendingCallbacks.ContainsKey(cbKey)){
				MobageLogger.log("deleteCurrentUserScoreForLeaderboard callback about to invoke!");
				try {
					deleteCurrentUserScoreForLeaderboard_onCompleteCallback del = (deleteCurrentUserScoreForLeaderboard_onCompleteCallback)pendingCallbacks[cbKey];
					del(status,  error );
				} catch ( Exception e ) {
					MobageLogger.exceptionLog(e);
				}
				MobageLogger.log("deleteCurrentUserScoreForLeaderboard finished invoking!");
				pendingCallbacks.Remove(cbKey);
			}
		}
		
	}
#endregion



#region Delegate Callbacks
	public partial class GameLeaderboard {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
		/**
		 * <summary> Callback for retrieving information about a leaderboard.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="leaderboard" cref="F:Mobage.GameLeaderboard">Information about the leaderboard, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getLeaderboardForId_onCompleteCallback(SimpleAPIStatus status, Error error, GameLeaderboard leaderboard);
		/**
		 * <summary> Callback for retrieving information about multiple leaderboards.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="leaderboards" cref="F:System.Collections.Generic.List<Mobage.GameLeaderboard>">An array of <c>GameLeaderboard</c> objects, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getLeaderboardsForIds_onCompleteCallback(SimpleAPIStatus status, Error error, List<GameLeaderboard> leaderboards);
		/**
		 * <summary> Callback for retrieving information about all of the current app's leaderboards.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="leaderboards" cref="F:System.Collections.Generic.List<Mobage.GameLeaderboard>">An array of <c>GameLeaderboard</c> objects, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getAllLeaderboards_onCompleteCallback(SimpleAPIStatus status, Error error, List<GameLeaderboard> leaderboards);
		/**
		 * <summary> Callback for retrieving a leaderboard's top scores.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="scores" cref="F:System.Collections.Generic.List<Mobage.Score>">An array of <c>Score</c> objects, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getScoresForLeaderboard_onCompleteCallback(SimpleAPIStatus status, Error error, List<Score> scores);
		/**
		 * <summary> Callback for retrieving a leaderboard's top scores for the current user's friends.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="scores" cref="F:System.Collections.Generic.List<Mobage.Score>">An array of <c>Score</c> objects, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getFriendsScoresForLeaderboard_onCompleteCallback(SimpleAPIStatus status, Error error, List<Score> scores);
		/**
		 * <summary> Callback for retrieving a user's top score on a leaderboard.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="score" cref="F:Mobage.Score">Information about the user's score, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void getScoreForLeaderboard_onCompleteCallback(SimpleAPIStatus status, Error error, Score score);
		/**
		 * <summary> Callback for updating the current user's top score.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 * <param name="score" cref="F:Mobage.Score">Information about the user's score, or <c>null</c> if the request did not succeed.</param>
		 */
		public delegate void updateCurrentUserScoreForLeaderboard_onCompleteCallback(SimpleAPIStatus status, Error error, Score score);
		/**
		 * <summary> Callback for deleting the current user's top score.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="status" cref="F:Mobage.SimpleAPIStatus">Information about the result of the request.</param>
		 * <param name="error" cref="F:Mobage.Error">Information about the error, or <c>null</c> if there was not an error.</param>
		 */
		public delegate void deleteCurrentUserScoreForLeaderboard_onCompleteCallback(SimpleAPIStatus status, Error error);
	}
#endregion

#region Static Methods
	public partial class GameLeaderboard {
		/**
		 * <summary> Retrieve information about a leaderboard.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="leaderboardId" cref="F:System.String">The leaderboard IDs of the leaderboards to retrieve.</param>
		 * <param name="onComplete" cref="F:Mobage.GetLeaderboardForIdOnCompleteCallback">
		 * Callback for retrieving information about a leaderboard.</param>
		 */
		public static void getLeaderboardForId(String leaderboardId, getLeaderboardForId_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_leaderboardId = (IntPtr)Convert.toC(leaderboardId);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCGameLeaderboard_getLeaderboardForId(out_leaderboardId, getLeaderboardForId_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_leaderboardId);
		}
		/**
		 * <summary> Retrieve information about multiple leaderboards.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="leaderboardIds" cref="F:System.Collections.Generic.List<System.String>">The leaderboard IDs of the leaderboards to retrieve.</param>
		 * <param name="onComplete" cref="F:Mobage.GetLeaderboardsForIdsOnCompleteCallback">
		 * Callback for retrieving information about multiple leaderboards.</param>
		 */
		public static void getLeaderboardsForIds(List<String> leaderboardIds, getLeaderboardsForIds_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_leaderboardIds = (IntPtr)Convert.toC(leaderboardIds);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCGameLeaderboard_getLeaderboardsForIds(out_leaderboardIds, getLeaderboardsForIds_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_leaderboardIds);
		}
		/**
		 * <summary> Retrieve information about all of the current app's leaderboards.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="onComplete" cref="F:Mobage.GetAllLeaderboardsOnCompleteCallback">
		 * Callback for retrieving information about all of the current app's leaderboards.</param>
		 */
		public static void getAllLeaderboards(getAllLeaderboards_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCGameLeaderboard_getAllLeaderboards(getAllLeaderboards_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
		}
		/**
		 * <summary> Retrieve information about a leaderboard's top scores, starting with the highest score.</summary>
		 * <remarks>
		 * You can use the <c>count</c> and <c>startIndex</c> parameters to control the
		 * number of results that this method retrieves, as well as the start index for the search
		 * results.
		 * </remarks>
		 * <param name="leaderboard" cref="F:Mobage.GameLeaderboard">The leaderboard whose scores will be retrieved.</param>
		 * <param name="count" cref="F:System.Int32">The number of results to retrieve. The default value is <c>50</c>.</param>
		 * <param name="startIndex" cref="F:System.Int32">The start index for the search results. The default value is <c>1</c>. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.GetScoresForLeaderboardOnCompleteCallback">
		 * Callback for retrieving a leaderboard's top scores.</param>
		 */
		public static void getScoresForLeaderboard(GameLeaderboard leaderboard, Int32 count, Int32 startIndex, getScoresForLeaderboard_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_leaderboard = (IntPtr)Convert.toC(leaderboard);

			Int32 out_count = count;

			Int32 out_startIndex = startIndex;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCGameLeaderboard_getScoresForLeaderboard(out_leaderboard, out_count, out_startIndex, getScoresForLeaderboard_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			GameLeaderboard.MBCReleaseGameLeaderboard(out_leaderboard);
		}
		/**
		 * <summary> Retrieve information about a leaderboard's scores that were earned by the current user's friends, starting with the highest score.</summary>
		 * <remarks>
		 * You can use the <c>count</c> and <c>startIndex</c> parameters to control the
		 * number of results that this method retrieves, as well as the start index for the search
		 * results.
		 * </remarks>
		 * <param name="leaderboard" cref="F:Mobage.GameLeaderboard">The leaderboard whose scores will be retrieved.</param>
		 * <param name="count" cref="F:System.Int32">The number of results to retrieve. The default value is <c>50</c>.</param>
		 * <param name="startIndex" cref="F:System.Int32">The start index for the search results. The default value is <c>1</c>. <strong>Important</strong>: The index's numbering begins at <c>1</c>, <em>not</em> <c>0</c>.</param>
		 * <param name="onComplete" cref="F:Mobage.GetFriendsScoresForLeaderboardOnCompleteCallback">
		 * Callback for retrieving a leaderboard's top scores for the current user's friends.</param>
		 */
		public static void getFriendsScoresForLeaderboard(GameLeaderboard leaderboard, Int32 count, Int32 startIndex, getFriendsScoresForLeaderboard_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_leaderboard = (IntPtr)Convert.toC(leaderboard);

			Int32 out_count = count;

			Int32 out_startIndex = startIndex;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCGameLeaderboard_getFriendsScoresForLeaderboard(out_leaderboard, out_count, out_startIndex, getFriendsScoresForLeaderboard_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			GameLeaderboard.MBCReleaseGameLeaderboard(out_leaderboard);
		}
		/**
		 * <summary> Retrieve information about a user's top score on a leaderboard.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="leaderboard" cref="F:Mobage.GameLeaderboard">The leaderboard whose score will be retrieved.</param>
		 * <param name="user" cref="F:Mobage.User">The user whose top score will be retrieved.</param>
		 * <param name="onComplete" cref="F:Mobage.GetScoreForLeaderboardOnCompleteCallback">
		 * Callback for retrieving a user's top score on a leaderboard.</param>
		 */
		public static void getScoreForLeaderboard(GameLeaderboard leaderboard, User user, getScoreForLeaderboard_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_leaderboard = (IntPtr)Convert.toC(leaderboard);

			IntPtr out_user = (IntPtr)Convert.toC(user);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCGameLeaderboard_getScoreForLeaderboard(out_leaderboard, out_user, getScoreForLeaderboard_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			GameLeaderboard.MBCReleaseGameLeaderboard(out_leaderboard);
			User.MBCReleaseUser(out_user);
		}
		/**
		 * <summary> Update the current user's top score on a leaderboard.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="leaderboard" cref="F:Mobage.GameLeaderboard">The leaderboard whose score for the current user will be updated.</param>
		 * <param name="value" cref="F:System.double">The current user's score.</param>
		 * <param name="onComplete" cref="F:Mobage.UpdateCurrentUserScoreForLeaderboardOnCompleteCallback">
		 * Callback for updating the current user's top score.</param>
		 */
		public static void updateCurrentUserScoreForLeaderboard(GameLeaderboard leaderboard, double value, updateCurrentUserScoreForLeaderboard_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_leaderboard = (IntPtr)Convert.toC(leaderboard);

			double out_value = value;

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCGameLeaderboard_updateCurrentUserScoreForLeaderboard(out_leaderboard, out_value, updateCurrentUserScoreForLeaderboard_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			GameLeaderboard.MBCReleaseGameLeaderboard(out_leaderboard);
		}
		/**
		 * <summary> Delete the current user's top score from a leaderboard.</summary>
		 * <remarks>
		 
		 * </remarks>
		 * <param name="leaderboard" cref="F:Mobage.GameLeaderboard">The leaderboard whose score for the current user will be deleted.</param>
		 * <param name="onComplete" cref="F:Mobage.DeleteCurrentUserScoreForLeaderboardOnCompleteCallback">
		 * Callback for deleting the current user's top score.</param>
		 */
		public static void deleteCurrentUserScoreForLeaderboard(GameLeaderboard leaderboard, deleteCurrentUserScoreForLeaderboard_onCompleteCallback onComplete)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_leaderboard = (IntPtr)Convert.toC(leaderboard);

			// Store callback for later	
			pendingCallbacks.Add(cbId,onComplete);
			MBCGameLeaderboard_deleteCurrentUserScoreForLeaderboard(out_leaderboard, deleteCurrentUserScoreForLeaderboard_onCompleteCallbackDispatcher, new IntPtr(cbId));
			
			// Free memory used for parameters
			GameLeaderboard.MBCReleaseGameLeaderboard(out_leaderboard);
		}
	}
#endregion

#region Instance Methods
	public partial class GameLeaderboard {
	}
#endregion

}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
