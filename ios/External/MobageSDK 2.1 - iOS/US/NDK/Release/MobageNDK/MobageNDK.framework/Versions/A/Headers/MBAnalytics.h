//
//  MBAnalytics.h
//  mobage-ndk
//
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol MBAnalytics <NSObject>

+ (void) reportEvent:(NSString*) eventString;

@end

