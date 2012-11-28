//
//  MB_WW_Contact.h
//  NGMobageUS
//
//  Created by Thomas Chao on 6/19/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import "MBFacebookUser.h"
#import "MB_WW_DataModel.h"
#import "MBError.h"
#import "MBInterfaceEnums.h"

@protocol MB_WW_FacebookUser <MBFacebookUser>
// US-only properties
@property (atomic, readwrite, strong) NSString * username;
@property (atomic, readwrite, strong) NSString * name;
@property (atomic, readwrite, strong) NSString * email;
@property (atomic, readwrite, strong) NSString * picture;

@end

@interface MB_WW_FacebookUser : MB_WW_DataModel <MB_WW_FacebookUser>

@end
