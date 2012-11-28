//
//  MBCAuth.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCAUTH_H_
#define MBCAUTH_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields
/**

 * @region Common
 */
typedef enum {
	/**

	 */
	MBCMobageFacebookLoginStatusSuccess = 0, 
	/**

	 */
	MBCMobageFacebookLoginStatusError = 1, 
	/**

	 */
	MBCMobageFacebookLoginStatusNewEmailAddress = 2, 
	/**

	 */
	MBCMobageFacebookLoginStatusTakenEmailAddress = 3, 
	/**

	 */
	MBCMobageFacebookLoginStatusCancelled = 4
} MBCMobageFacebookLoginStatus;
#define IsMBCMobageFacebookLoginStatus(intFlag) (!((intFlag < 0) || (intFlag > 4)))

	
	#pragma mark - Method Callbacks!
	/**
	 * MBCAuth_authorizeTokenCallback
	 * @description 	 * Callback for retrieving a verification code for an OAuth token.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param const char * verifier The verification code, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCAuth_authorizeTokenCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ const char * verifier,
				
				void * context
																);
	/**
	 * MBCAuth_loginWithUsernameAndPasswordCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 */
	typedef void (*MBCAuth_loginWithUsernameAndPasswordCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCAuth_registerUserCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 */
	typedef void (*MBCAuth_registerUserCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCAuth_forgotPasswordForEmailCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 */
	typedef void (*MBCAuth_forgotPasswordForEmailCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCAuth_loginToMobageWithFacebookCallback
	 * @description 
	 * @cb-param MBCMobageFacebookLoginStatus status status code returned by the login attempt. 0 = success, 1 = error, 2 = new email, 3 = taken email			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 * @cb-param MBCString_Array * result extra data describing the result, only populated on taken email case			AUTORELEASED
	 */
	typedef void (*MBCAuth_loginToMobageWithFacebookCallback)(
				MBCMobageFacebookLoginStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCString_Array * result,
				
				void * context
																);
	/**
	 * MBCAuth_registerUserWithFacebookCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 */
	typedef void (*MBCAuth_registerUserWithFacebookCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCAuth_testRemoteGamernameCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 * @cb-param MBCString_Array * suggestedNames list of suggested names, will be populated if the error is "name is taken"			AUTORELEASED
	 */
	typedef void (*MBCAuth_testRemoteGamernameCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCString_Array * suggestedNames,
				
				void * context
																);
	/**
	 * MBCAuth_testRemoteEmailAddressCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 */
	typedef void (*MBCAuth_testRemoteEmailAddressCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	/**
	 * MBCAuth_linkCurrentUserToCurrentFacebookAccountCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error null unless error occurred			AUTORELEASED
	 */
	typedef void (*MBCAuth_linkCurrentUserToCurrentFacebookAccountCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				
				void * context
																);
	
	#pragma mark - Static Methods
	/**
	 * MBCAuth_authorizeToken
	 * @function
	 * @public
	 * @description 	 * Generate a verification code for an OAuth request token.
	 *
	 * @param const char *  token The OAuth request token to verify.			AUTORELEASED
	 * @cb AuthorizeTokenOnCompleteCallback  onComplete 
	 * Generate a verification code for an OAuth request token.
	 			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param const char * verifier The verification code, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 */
	void MBCAuth_authorizeToken(
										const char *  token,
										MBCAuth_authorizeTokenCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );


#ifdef __cplusplus
}
#endif

#endif /* MBCAUTH_H_ */

