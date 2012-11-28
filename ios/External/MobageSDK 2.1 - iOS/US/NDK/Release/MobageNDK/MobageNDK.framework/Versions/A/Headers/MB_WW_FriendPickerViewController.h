//
//  MB_WW_FriendPickerViewController.h
//  NGMobageUS
//
//  Created by ngmoco on 3/15/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MB_WW_SocialService.h"
#import "MB_WW_FriendsListCell.h"
#import "MBUIViewController.h"

@interface MB_WW_FriendPickerViewController : MBUIViewController <UITableViewDataSource, MB_WW_FriendsListCellDelegate>

+ (MB_WW_FriendPickerViewController *)sharedFriendPicker;

- (void)show:(NSInteger)maxFriendsToSelect
withCallbackQueue:(dispatch_queue_t)cbQueue
  onComplete:(void (^)(MBDismissableAPIStatus status, NSObject<MBError>* error, NSArray *pickedUsers, NSArray *invitedUsers))completeCb;

- (void)updateFriendsListFromServer;

- (void)runNoFriendsPath;
- (void)filterFriendsByService;

- (void)showModalSpinner;
- (void)hideModalSpinner;

@end
