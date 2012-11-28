//
//  MBCAnalytics.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCANALYTICS_H_
#define MBCANALYTICS_H_

#include "MBCStandardTypes.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	
	#pragma mark - Method Callbacks!
	
	#pragma mark - Static Methods
	/**
	 * MBCAnalytics_reportEvent
	 * @function
	 * @public
	 * @description 	 * Report an Analytics event.
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
	 *
	 * @param const char *  eventString A JSON-formatted object with information about the event, using the format shown above.			AUTORELEASED
	 * <br/>
	 */
	void MBCAnalytics_reportEvent(
										const char *  eventString,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );


#ifdef __cplusplus
}
#endif

#endif /* MBCANALYTICS_H_ */

