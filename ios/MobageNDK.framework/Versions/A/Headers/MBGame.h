//
//  MBGame.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/10/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

#import "MBDataModel.h"
#import "MBInterfaceEnums.h"
#import "MBError.h"

/**
 * Warning: This DataModel is *Proposed* it has not been approved.
 */

@protocol MBGame <MBDataModel>

@property (atomic, readonly, strong) NSString * appKey;

@property (atomic, readonly, strong) NSString * name;
@property (atomic, readonly, strong) NSString * longDescription;
@property (atomic, readonly, strong) NSString * publisherName;
@property (atomic, readonly, strong) NSString * appStoreURL;
@property (atomic, readonly, strong) NSString * iconUrl;
@property (atomic, readonly, strong) NSString * largeIconUrl;
@property (atomic, readonly, assign) BOOL installed;
@property (atomic, readonly, assign) BOOL featured;

//- (void) checkIfLaunchable:(^launchCheckBlock)(BOOL isLaunchable);
//- (void) launch;

+ (NSObject<MBGame>*) currentGame;

- (void) launchGameWithCallbackQueue:(dispatch_queue_t)cbQueue 
		 onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error))completeCb;

- (void) showInStoreWithCallbackQueue:(dispatch_queue_t)cbQueue 
		  onComplete:(void (^)(MBSimpleAPIStatus status, NSObject<MBError> *error))completeCb;

@end

typedef NSObject<MBGame> MBGameProtocol;
