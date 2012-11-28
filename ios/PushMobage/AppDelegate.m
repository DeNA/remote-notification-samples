//
//  AppDelegate.m
//  HelloMobage
//
//  Created by Ian Terrell on 11/5/12.
//  Copyright (c) 2012 ngmoco. All rights reserved.
//

#import "AppDelegate.h"

#import "ViewController.h"

#import "Credentials.h"

#import <MobageNDK/MobageNDK.h>
#import <UIKit/UIKit.h>

#define kMobageNotificationKey @"x"
#define kMobageExtraInformationIndex 3

#ifndef APP_ID
#error You must copy Credentials.h.template to Credentials.h in the project, and fill in your app's values!
#endif

@implementation AppDelegate

- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions
{
    self.window = [[UIWindow alloc] initWithFrame:[[UIScreen mainScreen] bounds]];
    self.window.rootViewController = [[ViewController alloc] init];
    [self.window makeKeyAndVisible];
    
    // These values are defined in Credentials.h
    // You will need to copy the Credentials.h.template file in the PushMobage folder and fill in your values
    [MBMobage initializeMobageWithServerEnvironment:kMBServerEnvironmentSandbox
                                              appId:APP_ID              /* e.g., My-App-iOS */
                                         appVersion:@"1.0.0"            /* e.g., 1.3.8 */
                                        consumerKey:CONSUMER_KEY        /* alphanumeric value */
                                     consumerSecret:CONSUMER_SECRET];   /* alphanumeric value */
    
    // We need to log in to send and receive push notifications
    [MBSocialService executeLoginWithCallbackQueue:nil onComplete:^(MBCancelableAPIStatus status, NSObject<MBError> *error) {
        switch (status){
        case MBCancelableAPIStatusError:
            NSLog(@"An error occured during user login: %@",error);
            break;
        case MBCancelableAPIStatusCancel:
            NSLog(@"User login cancelled.");
            break;
        case MBCancelableAPIStatusSuccess:
            NSLog(@"User login success.");
                
            // Since the login was successful, the MobageNDK automatically registers us for push notifications!
            // We don't need to do anything else for that to happen.
                
            // Let's check if they're enabled now.
            // Note: they may not be enabled on the first run as the initial network calls complete, but should be enabled on subsequent runs.
            // This is a custom method and is defined below.
            [self checkIfRemoteNotificationsEnabled];
            
            // Now we'll get our current user object so we can send a message to ourself. Other MBPeople APIs return MBUser objects, or you can create an MBUser directly
            [MBPeople getCurrentUserWithCallbackQueue:dispatch_get_main_queue() onComplete:^(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBUser> *user) {
                switch (status) {
                case MBSimpleAPIStatusError:
                    NSLog(@"getCurrentUser failed: %@", error);
                    break;
                case MBSimpleAPIStatusSuccess:
                    NSLog(@"getCurrentUser returned '%@'", user.nickname);
                        
                    // Create payload for our push notification
                    MBRemoteNotificationPayload *payload = [[MBRemoteNotificationPayload alloc] init];
                    payload.message = @"Message to myself from inside the app!";
                        
                    // You can create extras to send as well
                    payload.extraKeys = @[@"key1", @"key2"];
                    payload.extraValues = @[@"value1", @"value2"];
                    
                    // Send push notification
                    [MBRemoteNotification sendToUser:user payload:payload withCallbackQueue:dispatch_get_main_queue() onComplete:^(MBSimpleAPIStatus status, NSObject<MBError> *error, NSObject<MBRemoteNotificationResponse> *response) {
                        switch (status) {
                        case MBSimpleAPIStatusError:
                            NSLog(@"There was an error sending the message: %@", error);
                            break;
                        case MBSimpleAPIStatusSuccess:
                            NSLog(@"Successfully sent message!");
                            break;
                        }
                    }]; // sendToUser
                    break;
                }
            }]; // getCurrentUser
            break;
        }
    }]; // executeLogin
    
    
    // Now we'll check to see if we were launched from a remote notification.
    // This will happen if the app was not running and the user tapped on a push notification.
    NSDictionary *notification = [launchOptions objectForKey:UIApplicationLaunchOptionsRemoteNotificationKey];
    if (notification != nil) {
        NSLog(@"Launched from a remote notifciation");
        [self logNotificationInformation:notification];
    } else {
        NSLog(@"Did not receive a remote notification.");
    }
    
    return YES;
}

- (void)applicationWillResignActive:(UIApplication *)application
{
    // Sent when the application is about to move from active to inactive state. This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) or when the user quits the application and it begins the transition to the background state.
    // Use this method to pause ongoing tasks, disable timers, and throttle down OpenGL ES frame rates. Games should use this method to pause the game.
}

- (void)applicationDidEnterBackground:(UIApplication *)application
{
    // Use this method to release shared resources, save user data, invalidate timers, and store enough application state information to restore your application to its current state in case it is terminated later. 
    // If your application supports background execution, this method is called instead of applicationWillTerminate: when the user quits.
}

- (void)applicationWillEnterForeground:(UIApplication *)application
{
    // Called as part of the transition from the background to the inactive state; here you can undo many of the changes made on entering the background.
}

- (void)applicationDidBecomeActive:(UIApplication *)application
{
    // Restart any tasks that were paused (or not yet started) while the application was inactive. If the application was previously in the background, optionally refresh the user interface.
}

- (void)applicationWillTerminate:(UIApplication *)application
{
    // Called when the application is about to terminate. Save data if appropriate. See also applicationDidEnterBackground:.
}

// This method will check to see if remote notifications are enabled from Mobage's perspective and the device's perspective
- (void)checkIfRemoteNotificationsEnabled {
    [MBRemoteNotification
     getRemoteNotificationsEnabledWithCallbackQueue:dispatch_get_main_queue()
     onComplete:^(MBSimpleAPIStatus status, NSObject<MBError> *error, BOOL mobageEnabled) {
         switch (status) {
             case MBSimpleAPIStatusSuccess:
             {
                 UIRemoteNotificationType enabledTypes = [[UIApplication sharedApplication] enabledRemoteNotificationTypes];
                 BOOL deviceEnabled = !(enabledTypes == UIRemoteNotificationTypeNone);
                 NSLog(@"Remote Notification Enabled for user: (Mobage) %d (Device) %d", mobageEnabled, deviceEnabled);
                 break;
             }
             default:
                 NSLog(@"API error in MBRemoteNotification+getRemoteNotificationsEnabledWithCallbackQueue:onComplete:");
         }
     }];
}

// This method will be called if the app receives a push notification while it is running in the foreground,
// or if it was in the background and the user tapped on the message.
- (void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary*)userInfo {
    NSString *runningState = (application.applicationState == UIApplicationStateActive) ? @"foreground" : @"background";
    NSLog(@"Received a remote notification while running in %@", runningState);
    [self logNotificationInformation:userInfo];
}

// This method will retrieve the extra information sent along with the push notification.
- (NSDictionary *)extrasFromNotification:(NSDictionary *)notification {
    NSArray *mobageInformation = [notification objectForKey:kMobageNotificationKey];
    if (mobageInformation == nil)
        return nil;
    id extras = [mobageInformation objectAtIndex:kMobageExtraInformationIndex];
    if (extras == [NSNull null])
        return nil;
    
    return (NSDictionary *)extras;
}

- (void)logNotificationInformation:(NSDictionary *)notification {
    NSLog(@"Message: %@", [[notification objectForKey:@"aps"] objectForKey:@"alert"]);
    NSLog(@"Extras: %@", [self extrasFromNotification:notification]);
}

@end
