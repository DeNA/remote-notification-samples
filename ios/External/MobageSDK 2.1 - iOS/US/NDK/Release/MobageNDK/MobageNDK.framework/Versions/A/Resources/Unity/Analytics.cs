//
//  Analytics.cs
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
	 * <summary> Report an Analytics event to the Mobage server.</summary>
	 * <remarks>
	 * You can view reports on your app's Analytics events on the
	 * <a href="https://developer.mobage.com/">Mobage Developer Portal</a>.
	 * </remarks>
	 */
	public partial class Analytics {}

#region Enums / Bitfields
#endregion
	

#region Native Method Imports
	public partial class Analytics {

	#if UNITY_IPHONE && !UNITY_EDITOR
		[DllImport("__Internal")]
	#else
		[DllImport("NDKPlugin")] // Mobage-NDK doesn't have a framework for the desktop yet!
	#endif
		private static extern void MBCAnalytics_reportEvent(IntPtr input_eventString, IntPtr context);
	
	}
#endregion
#region Native Return Points
	public partial class Analytics {
	}
#endregion



#region Delegate Callbacks
	public partial class Analytics {
	#pragma warning disable 0414
		private static int cbUidGenerator = 0;
		private static Dictionary<int, Delegate> pendingCallbacks = new Dictionary<int, Delegate>();
	#pragma warning restore 0414
	
	}
#endregion

#region Static Methods
	public partial class Analytics {
		/**
		 * <summary> Report an Analytics event.</summary>
		 * <remarks>
		 * The <c>eventString</c> parameter is a <a href="http://www.json.org/">JSON</a>-formatted
		 * object that contains the following properties:
		 * <ul>
		 * <li><c>eventId</c>: A string identifying the type of event that is being reported.</li>
		 * <li><c>payload</c>: An object whose properties are key/value pairs with additional
		 * information about the event. Each key and value must be a string.</li>
		 * <li><c>playerState</c>: Information about the user's current state, such as the user's
		 * level and number of lives remaining. Do not include information that is unique to a specific
		 * user, such as a user ID or nickname.</li>
		 * </ul>
		 * For example, your app could report a <c>battle</c> event whenever a user completes a
		 * battle, passing a value similar to the following in the <c>eventString</c> parameter.
		 * (For clarity, this example is split into multiple lines.)
		 * <code>
		 * {
		 * 	"eventId": "battle",
		 * 	"payload": {
		 * 		"enemyType": "greenDragon",
		 * 		"enemyHitPoints": "58",
		 * 		"quest": "treasureHunt",
		 * 		"battleWon": "true"
		 * 	},
		 * 	"playerState": {
		 * 		"hitPoints": "36",
		 * 		"score": "18755",
		 * 		"level": "8",
		 * 		"xp": "143"
		 * 	}
		 * }
		 * </code>
		 * </remarks>
		 * <param name="eventString" cref="F:System.String">A JSON-formatted object with information about the event, using the format shown above.</param>
		 */
		public static void reportEvent(String eventString)
		{
			int cbId = (cbUidGenerator++);
			IntPtr out_eventString = (IntPtr)Convert.toC(eventString);

			MBCAnalytics_reportEvent(out_eventString, new IntPtr(cbId));
			
			// Free memory used for parameters
			Marshal.FreeHGlobal(out_eventString);
		}
	}
#endregion


}

#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM
