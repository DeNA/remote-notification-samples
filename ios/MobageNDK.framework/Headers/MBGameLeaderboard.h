//
//  MBGameLeaderboard.h
//  mobage-ndk
//
//  Created by Chris Toliver on 6/13/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//


#import <Foundation/Foundation.h>
#import "MBDataModel.h"
#import "MBScore.h"
#import "MBInterfaceEnums.h"
#import "MBError.h"
#import "MBUser.h"

/**
 * @file MBGameLeaderboard.h
 * Model for information about a Mobage leaderboard.
 * @since 2.0
 */

/**
 * Information about a Mobage leaderboard.
 * @since 2.0
 */
@protocol MBGameLeaderboard <MBDataModel>
/**
 * The app ID associated with the leaderboard.
 * @since 2.0
 */
@property (nonatomic, readonly, strong) NSString *appId;

/**
 * The leaderboard's title.
 * @since 2.0
 */
@property (nonatomic, readonly, strong) NSString *title;

/**
 * The rules that the leaderboard uses to format a score for display. Contains one of the following
 * values:
 * <ul>
 * <li><code>day_hour</code>: Formatted as <code>DD HH.zzz</code>. The score represents the
 * number of seconds.</li>
 * <li><code>day_minute</code>: Formatted as <code>DD HH:MM.zzz</code>. The score represents
 * the number of seconds.</li>
 * <li><code>day_second</code>: Formatted as <code>DD HH:MM:SS.zzz</code>. The score represents
 * the number of seconds.</li>
 * <li><code>decimal</code>: Formatted as a signed double.</li>
 * <li><code>hour_minute</code>: Formatted as <code>HH:MM.zzz</code>. The score represents the
 * number of seconds.</li>
 * <li><code>hour_second</code>: Formatted as <code>HH:MM:SS.zzz</code>. The score represents
 * the number of seconds.</li>
 * <li><code>hours</code>: Formatted as <code>HH.zzz</code>. The score represents the number
 * of seconds.</li>
 * <li><code>integer</code>: Formatted as a signed 32-bit integer.</li>
 * <li><code>minute_second</code>: Formatted as <code>MM:SS.zzz</code>. The score represents the
 * number of seconds.</li>
 * <li><code>minutes</code>: Formatted as <code>MM.zzz</code>. The score represents the number
 * of seconds.</li>
 * <li><code>seconds</code>: Formatted as <code>SS.zzz</code>. The score represents the number
 * of seconds.</li>
 * </ul>
 * @since 2.0
 */
@property (nonatomic, readonly, strong) NSString *scoreFormat;

/**
 * The number of decimal places that the leaderboard uses when it reformats a score for display.
 * @since 2.0
 */
@property (nonatomic, readonly, assign) NSInteger scorePrecision;

/**
 * The URL of the leaderboard icon.
 * @since 2.0
 */
@property (nonatomic, readonly, strong) NSString *iconUrl;

/**
 * Indicates whether a user's top score can be replaced by a new, lower score.
 * @since 2.0
 */
@property (nonatomic, readonly, assign) BOOL allowLowerScore;

/**
 * Indicates whether the leaderboard treats lower scores as more desirable.
 * @since 2.0
 */
@property (nonatomic, readonly, assign) BOOL reverse;

/**
 * Indicates whether the leaderboard has been archived and can no longer be updated. This property
 * is reserved for future use and is currently always set to <code>NO</code>.
 * @since 2.0
 */
@property (nonatomic, readonly, assign) BOOL archived;

/**
 * The default score for users that have not recorded a top score.
 * @since 2.0
 */
@property (nonatomic, readonly, assign) double defaultScore;

/**
 * The date and time when the leaderboard was created. Uses the format
 * <code>YYYY-MM-DDThh:mm:ss</code>.
 * @since 2.0
 */
@property (nonatomic, readonly, strong) NSString *published;

/**
 * The date and time when the leaderboard was updated. Uses the format
 * <code>YYYY-MM-DDThh:mm:ss</code>.
 * @since 2.0
 */
@property (nonatomic, retain) NSString *updated;

/**
 * Retrieve information about a leaderboard.
 * @param leaderboardId The leaderboard ID of the leaderboard to retrieve.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>leaderboard</code>: Information about the leaderboard, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)getLeaderboardForId:(NSString*)leaderboardId
         withCallbackQueue:(dispatch_queue_t)cbQueue
                onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBGameLeaderboard> *leaderboard))completeCb;

/**
 * Retrieve information about multiple leaderboards.
 * @param leaderboardIds The leaderboard IDs of the leaderboards to retrieve.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>leaderboards</code>: An array of <code>MBGameLeaderboard</code> objects, or
 * <code>nil</code> if the request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)getLeaderboardsForIds:(NSArray*)leaderboardIds 
           withCallbackQueue:(dispatch_queue_t)cbQueue
                  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *leaderboards))completeCb;


/**
 * Retrieve information about all of the current app's leaderboards.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>leaderboards</code>: An array of <code>MBGameLeaderboard</code> objects, or
 * <code>nil</code> if the request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)getAllLeaderboardsWithCallbackQueue:(dispatch_queue_t)cbQueue 
                                onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *leaderboards))completeCb;

// not public
+(void)getScoresForLeaderboardId:(NSString*)leaderboardId
                           count:(NSInteger)count
                      startIndex:(NSInteger)startIndex
               withCallbackQueue:(dispatch_queue_t)cbQueue
                      onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *scores))completeCb;

/**
 * Retrieve information about a leaderboard's top scores, starting with the highest score. You can
 * use the <code>count</code> and <code>startIndex</code> parameters to control the number of
 * results that this method retrieves, as well as the start index for the search results.
 * @param leaderboard The leaderboard whose scores will be retrieved.
 * @param count The number of results to retrieve. The default value is <code>50</code>.
 * @param startIndex The start index for the search results. The default value is <code>1</code>.
 *      <strong>Important</strong>: The index's numbering begins at <code>1</code>, <em>not</em>
 *      <code>0</code>.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>scores</code>: An array of <code>MBScore</code> objects, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)getScoresForLeaderboard:(NSObject<MBGameLeaderboard>*)leaderboard
                         count:(NSInteger)count
                    startIndex:(NSInteger)startIndex
             withCallbackQueue:(dispatch_queue_t)cbQueue
                    onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *scores))completeCb;

// not public
+(void)getFriendsScoresForLeaderboardId:(NSString*)leaderboardId
                                  count:(NSInteger)count
                             startIndex:(NSInteger)startIndex
                      withCallbackQueue:(dispatch_queue_t)cbQueue
                             onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *scores))completeCb;

/**
 * Retrieve information about a leaderboard's scores that were earned by a user's friends, starting
 * with the highest score. You can use the <code>count</code> and <code>startIndex</code> parameters
 * to control the number of results that this method retrieves, as well as the start index for the
 * search results.
 * @param leaderboard The leaderboard whose scores will be retrieved.
 * @param count The number of results to retrieve. The default value is <code>50</code>.
 * @param startIndex The start index for the search results. The default value is <code>1</code>.
 *      <strong>Important</strong>: The index's numbering begins at <code>1</code>, <em>not</em>
 *      <code>0</code>.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>scores</code>: An array of <code>MBScore</code> objects, or <code>nil</code> if the
 * request did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)getFriendsScoresForLeaderboard:(NSObject<MBGameLeaderboard>*)leaderboard
                                count:(NSInteger)count
                           startIndex:(NSInteger)startIndex
                    withCallbackQueue:(dispatch_queue_t)cbQueue
                           onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *scores))completeCb;

// not public
+(void)getScoreForLeaderboardId:(NSString*)leaderboardId
        forUserId:(NSString*)userId
       withCallbackQueue:(dispatch_queue_t)cbQueue
              onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBScore> *score))completeCb;

/**
 * Retrieve information about a user's top score on a leaderboard.
 * @param leaderboard The leaderboard whose score will be retrieved.
 * @param user The user whose top score will be retrieved.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>score</code>: Information about the user's score, or <code>nil</code> if the request
 * did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)getScoreForLeaderboard:(NSObject<MBGameLeaderboard>*)leaderboard
        forUser:(NSObject<MBUser>*)user
     withCallbackQueue:(dispatch_queue_t)cbQueue
            onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBScore> *score))completeCb;


// not public
+(void)updateCurrentUserScoreForLeaderboardId:(NSString*)leaderboardId
                                        value:(double)value
                            withCallbackQueue:(dispatch_queue_t)cbQueue
                                   onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBScore> *score))completeCb;

/**
 * Update the current user's top score on a leaderboard.
 * @param leaderboard The leaderboard whose score for the current user will be updated.
 * @param value The current user's score.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * <li><code>score</code>: Information about the user's score, or <code>nil</code> if the request
 * did not succeed.</li>
 * </ul>
 * @since 2.0
 */
+(void)updateCurrentUserScoreForLeaderboard:(NSObject<MBGameLeaderboard>*)leaderboard
                                      value:(double)value
                          withCallbackQueue:(dispatch_queue_t)cbQueue
                                 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBScore> *score))completeCb;

// not public
+(void)deleteCurrentUserScoreForLeaderboardId:(NSString*)leaderboardId
                            withCallbackQueue:(dispatch_queue_t)cbQueue
                                   onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error))completeCb;

/**
 * Delete the current user's top score from a leaderboard.
 * @param leaderboard The leaderboard whose score for the current user will be deleted.
 * @param cbQueue The dispatch queue for the callback.
 * @param completeCb Called after the request is completed. Accepts the following parameters:
 * <ul>
 * <li><code>status</code>: Information about the result of the request.</li>
 * <li><code>error</code>: Information about the error, or <code>nil</code> if there was not an
 * error.</li>
 * </ul>
 * @since 2.0
 */
+(void)deleteCurrentUserScoreForLeaderboard:(NSObject<MBGameLeaderboard>*)leaderboard
                          withCallbackQueue:(dispatch_queue_t)cbQueue
                                 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error))completeCb;


@end

