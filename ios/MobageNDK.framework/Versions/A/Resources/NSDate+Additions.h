//
//  NSDate+Additions.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 11/1/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>

@interface NSDate (Additions)

- (BOOL) isSameDayAsDate: (NSDate *) aDate;
- (BOOL) isToday;

@end
