//
//  MB_WW_Game.h
//  NGMobageUS
//
//  Created by Frederic Barthelemy on 2/10/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MB_WW_DataModel.h"
#import "MBCacheableModel.h"
#import "MBGame.h"

@protocol MB_WW_Game <MBGame>

@property (nonatomic, readonly, strong) NSString * appKey;
@property (nonatomic, readonly, strong) NSString * masterProductId;
@property (nonatomic, readonly, strong) NSString * bundleId;

@property (nonatomic, readonly, strong) NSString * name;
@property (nonatomic, readonly, strong) NSString * longDescription;
@property (nonatomic, readonly, strong) NSString * publisherName;
@property (nonatomic, readonly, strong) NSString * appStoreURL;
@property (nonatomic, readonly, strong) NSString * iconUrl;
@property (nonatomic, readonly, strong) NSString * largeIconUrl;
@property (nonatomic, readonly, strong) NSString * promotionImageUrl;

@property (nonatomic, readonly, assign) BOOL installed;
@property (nonatomic, readonly, assign) BOOL featured;

//@property (nonatomic, readonly, strong) NSString * name;
//@property (nonatomic, readonly, strong) BOOL supports_android;
//@property (nonatomic, readonly, strong) BOOL supports_ios;
//@property (nonatomic, readonly, strong) BOOL visible;

+ (void) getGames:(NSInteger)howMany
	  startOffset:(NSInteger)startOffset
withCallbackQueue:(dispatch_queue_t)cbQueue 
	   onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSArray *games, NSInteger startOffset, NSInteger totalPossibleResultCount))completeCb;

+ (void) getCurrentGameWithCallbackQueue: (dispatch_queue_t)cbQueue 
							  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBGame> *game))completeCb;

@end

@interface MB_WW_Game : MB_WW_DataModel <MB_WW_Game>

@end
