//
//  MBError.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/11/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBModelSerialization.h"

/**
 * @file MBError.h
 * Get details about an error.
 * @since 1.5
 */

extern NSString *const kMBMobageAPIErrorDomain;

/**
 * Enumeration of standard Mobage API errors.
 * @since 2.0
 */
typedef enum {
	/**
	 * A server error occurred.
	 * @since 2.0
	 */
	MBStandardErrorServerError = 10001, 
	/**
	 * The device cannot connect to the network.
	 * @since 2.0
	 */
	MBStandardErrorNetworkUnavailable = 10002, 
	/**
	 * The request was missing required information.
	 * @since 2.0
	 */
	MBStandardErrorMissingData = 10003, 
	/**
	 * The request contained invalid data.
	 * @since 2.0
	 */
	MBStandardErrorInvalidData = 10004, 
	/**
	 * An unknown error occurred.
	 * @since 2.0
	 */
	MBStandardErrorUnknownError = 10005, 
	/**
	 * A message from the server could not be parsed.
	 * @since 2.0
	 */
	MBStandardErrorParseError = 10006, 
	/**
	 * There is no authorization token available for the user.
	 * @since 2.0
	 */
	MBStandardErrorNoAuthToken = 10007
} MBStandardError;
#define IsMBStandardError(error) (!((error < 10001) || (error > 10007)))

/**
 * Enumeration of Mobage errors that relate to HTTP errors.
 * @since 2.0
 */
typedef enum {
	/**
	 * The Mobage server is not currently available.
	 * @since 2.0
	 */
	MBHTTPErrorServerDown = 109, 
	/**
	 * The app must be upgraded to support the current version of Mobage.
	 * @since 2.0
	 */
	MBHTTPErrorUpgradeRequired = 110, 
	/**
	 * The user has been banned from Mobage.
	 * @since 2.0
	 */
	MBHTTPErrorUserBanned = 111, 
	/**
	 * The user has not agreed to the Mobage terms of service.
	 * @since 2.0
	 */
	MBHTTPErrorAgreementNeeded = 112, 
	/**
	 * The request data was invalid.
	 * @since 2.0
	 */
	MBHTTPErrorBadRequest = 400, 
	/**
	 * The specified data was not found.
	 * @since 2.0
	 */
	MBHTTPErrorRecordNotFound = 404, 
	/**
	 * An authentication error occurred.
	 * @since 2.0
	 */
	MBHTTPErrorUnauthorized = 401, 
	/**
	 * Access was forbidden for reasons other than an authentication error.
	 * @since 2.0
	 */
	MBHTTPErrorPermissionDenied = 403, 
	/**
	 * An internal server error occurred.
     * @since 2.0
	 */
	MBHTTPErrorFirstInternalServerError = 500, 
	/**
	 * An unknown error occurred.
     * @since 2.0
	 */
	MBHTTPErrorLastHTTPError = 599
} MBHTTPError;
#define IsMBHTTPError(error) (!((error < 109) || (error > 599)))

/**
 * Enumeration of errors for Mobage's common APIs, which are supported in all regions.
 * @since 2.0
 */
typedef enum {
	/**
	 * The user's session is invalid.
	 * @since 2.0
	 */
	MBCommonAPIInvalidSessionError = 20001, 
	/**
	 * The method was called without a required parameter.
	 * @since 2.0
	 */
	MBCommonAPIMethodMissingArgumentError = 20002, 
	/**
	 * The method was called with an invalid parameter value.
	 * @since 2.0
	 */
	MBCommonAPIMethodInvalidArgumentError = 20003, 
	/**
	 * The method has not been implemented.
	 * @since 2.0
	 */
	MBCommonAPIMethodNotImplementedError = 20004, 
	/**
	 * The current Mobage server does not support this method.
	 * @since 2.0
	 */
	MBCommonAPIMethodNotSupportedError = 20005
} MBCommonAPIError;
#define IsMBCommonAPIError(error) (!((error < 20001) || (error > 20005)))

/**
 * Enumeration of Mobage analytics errors.
 * @since 2.0
 */
typedef enum {
	/**
	 * An invalid response was received from the analytics server.
	 * @since 2.0
	 */
	MBAnalyticsServerErrorInvalidResponse = 30001, 
	/**
	 * The analytics server rejected the request.
	 * @since 2.0
	 */
	MBAnalyticsServerErrorEventRejected = 30002, 
	/**
	 * The analytics event size exceeded the maximum size.
	 * @since 2.0
	 */
	MBAnalyticsServerErrorEventSizeTooLarge = 30003, 
	/**
	 * The analytics event property size exceeded the maximum size.
	 * @since 2.0
	 */
	MBAnalyticsServerErrorEventPropertySizeTooLarge = 30004, 
	/**
	 * The analytics event contained an invalid array.
	 * @since 2.0
	 */
	MBAnalyticsServerErrorEventContainsInvalidArray = 30005
} MBAnalyticsServerError;
#define IsMBAnalyticsServerError(error) (!((error < 30001) || (error > 30005)))

/**
 * Enumeration of Mobage Bank errors.
 * @since 2.0
 */
typedef enum {
	/**
	 * The Bank request could not be completed, because the transaction is not in the correct state
	 * for the requested method.
	 * @since 2.0
	 */
	MBBankErrorInvalidStateTransition = 40001
} MBBankError;
#define IsMBBankError(error) (!((error < 40001) || (error > 40001)))

// added to 2.0 for legacy support only
typedef enum {
	/*
	 *
	 * The Mobage server is not currently available.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeServerDown = 109, 
	/*
	 *
	 * The app must be upgraded to support the current version of Mobage.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeUpgradeRequired = 110, 
	/*
	 *
	 * The user has been banned from Mobage.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeUserBanned = 111, 
	/*
	 *
	 * The user has not agreed to the Mobage terms of service.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeAgreementNeeded = 112, 
	/*
	 *
	 * The request data was invalid.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeBadRequest = 400, 
	/*
	 *
	 * The specified data was not found.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeRecordNotFound = 404, 
	/*
	 *
	 * An authentication error occurred.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeUnauthorized = 401, 
	/*
	 *
	 * Access was forbidden for reasons other than an authentication error.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypePermissionDenied = 403, 
	/*
	 *
	 * A server error occurred.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeServerError = 10001, 
	/*
	 *
	 * The device cannot connect to the network.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeNetworkUnavailable = 10002, 
	/*
	 *
	 * The request was missing required information.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeMissingData = 10003, 
	/*
	 *
	 * The request contained invalid data.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeInvalidData = 10004, 
	/*
	 *
	 * An unknown error occurred.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeUnknownError = 10005, 
	/*
	 *
	 * A message from the server could not be parsed.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeParseError = 10006, 
	/*
	 *
	 * There is no authorization token available for the user.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeNoAuthToken = 10007, 
	/*
	 *
	 * The user's session is invalid.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeCommonAPIInvalidSessionError = 20001, 
	/*
	 *
	 * The method was called without a required parameter.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeCommonAPIMethodMissingArgumentError = 20002, 
	/*
	 *
	 * The method was called with an invalid parameter value.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeCommonAPIMethodInvalidArgumentError = 20003, 
	/*
	 *
	 * The method has not been implemented.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeCommonAPIMethodNotImplementedError = 20004, 
	/*
	 *
	 * The current Mobage server does not support this method.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeCommonAPIMethodNotSupportedError = 20005, 
	/*
	 *
	 * An invalid response was received from the analytics server.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeAnalyticsServerInvalidResponse = 30001, 
	/*
	 *
	 * The analytics server rejected the request.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeAnalyticsServerEventRejected = 30002, 
	/*
	 *
	 * The analytics event size exceeded the maximum size.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeAnalyticsServerEventSizeTooLarge = 30003, 
	/*
	 *
	 * The analytics event property size exceeded the maximum size.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeAnalyticsServerEventPropertySizeTooLarge = 30004, 
	/*
	 *
	 * The analytics event contained an invalid array.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeAnalyticsServerEventContainsInvalidArray = 30005, 
	/*
	 *
	 * The Bank request could not be completed, because the transaction is not in the correct state
	 * for the requested method.
	 * @since 1.5
	 */
	MBMobageAPIErrorTypeBankErrorInvalidStateTransition = 40001
} MBMobageAPIErrorType;
#define IsMBMobageAPIErrorType(error) (!((error < 109) || (error > 40001)))

@class MBError;

@protocol MBError <MBSerializableItem>
+ (MBError *)makeErrorFromString:(NSString *)msg withDomain:(NSString *)domain andCode:(MBMobageAPIErrorType)code;
+ (MBError *)makeError:(NSError *)err;

@property (nonatomic, readonly, strong) NSString * domain;
@property (nonatomic, readonly, strong) NSString * description;
@property (nonatomic, readonly, strong) NSString * localizedDescription;
@property (nonatomic, readonly, assign) NSInteger code;
@end

@interface MBError : NSError <MBError>

@end

#include "MBCError.h"

// deprecated 1.5 errors
typedef enum {
    /*
     * The Mobage server is not currently available.
     * @since 1.5
     */
    kMBMobageApierrorServerDown = 109,
    /*
     * The app must be upgraded to support the current version of Mobage.
     * @since 1.5
     */
    kMBMobageApierrorUpgradeRequired = 110,
    /*
     * The user has been banned from Mobage.
     * @since 1.5
     */
    kMBMobageApierrorUserBanned = 111,
    /*
     * The user has not agreed to the Mobage terms of service.
     * @since 1.5
     */
	kMBMobageApierrorAgreementNeeded = 112,
    /*
     * The request data was invalid.
     * @since 1.5
     */
    kMBMobageApierrorBadRequest = 400,
    /*
     * The specified data was not found.
     * @since 1.5
     */
    kMBMobageApierrorRecordNotFound = 404,
    /*
     * An authentication error occurred.
     * @since 1.5
     */
    kMBMobageApierrorUnauthorized = 401,
    /*
     * Access was forbidden for reasons other than an authentication error.
     * @since 1.5
     */
    kMBMobageApierrorPermissionDenied = 403,
    /*
     * A server error occurred.
     * @since 1.5
     */
	kMBServerError = 10001,
    /*
     * The device cannot connect to the network.
     * @since 1.5
     */
	kMBNetworkUnavailable,
    /*
     * The request was missing required information.
     * @since 1.5
     */
	kMBMissingData,
    /*
     * The request contained invalid data.
     * @since 1.5
     */
	kMBInvalidData,
    /*
     * An unknown error occurred.
     * @since 1.5
     */
	kMBUnknownError,
    /*
     * A message from the server could not be parsed.
     * @since 1.5
     */
	kMBParseError,
    /*
     * There is no authorization token available for the user.
     * @since 1.5
     */
	kMBNoAuthToken,
    /*
     * The user's session is invalid.
     * @since 1.5
     */
    kMBCommonApiInvalidSession = 20001,
    /*
     * The method was called without a required parameter.
     * @since 1.5
     */
    kMBCommonApimethodMissingArgument,
    /*
     * The method was called with an invalid parameter value.
     * @since 1.5
     */
    kMBCommonApimethodInvalidArgument,
    /*
     * The method has not been implemented.
     * @since 1.5
     */
    kMBCommonApimethodNotImplemented,
    /*
     * The current Mobage server does not support this method.
     * @since 1.5
     */
    kMBCommonApimethodNotSupported,
    /*
     * An invalid response was received from the analytics server.
     * @since 1.5
     */
    kMBAnalyticsInvalidResponse = 30001,
    /*
     * The analytics server rejected the request.
     * @since 1.5
     */
    kMBAnalyticsServerRejectedEvent = 30002,
    /*
     * The analytics event size exceeded the maximum size.
     * @since 1.5
     */
    kMBAnalyticsServerEventSizeTooLarge = 30003,
    /*
     * The analytics event property size exceeded the maximum size.
     * @since 1.5
     */
    kMBAnalyticsServerEventPropertySizeTooLarge  = 30004,
    /*
     * The analytics event contained an invalid array.
     * @since 1.5
     */
    kMBAnalyticsServerEventContainsArray = 30005,
    /*
     * The Bank request could not be completed, because the transaction is not in the correct state
     * for the requested method.
     * @since 1.5
     */
    kMBBankErrorInvalidStateTransition = 40001
} LegacyMBMobageAPIErrorType;


#warning TODO: get rid of error conversion after 2.0 unless we have a darn good reason!
#define MBErrorConvertIfNecessary(err) \
((err && ![kMBMobageAPIErrorDomain isEqualToString:err.domain]) ? \
[MBError makeErrorFromString:[err localizedDescription] withDomain:kMBMobageAPIErrorDomain andCode: [err code] ?: MBMobageAPIErrorTypeUnknownError] :\
err)
