//
//  MBCReward.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCREWARD_H_
#define MBCREWARD_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"
#include "MBCRewardCampaign.h"
#include "MBCUser.h"

#ifdef __cplusplus
extern "C" {
#endif

#if MB_WW // whole interface/model is region-specific
#pragma mark Enums / Bitfields

	
	#pragma mark - Method Callbacks!
	/**
	 * MBCReward_redeemRewardCodeCallback
	 * @description 
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param MBCUser * inviter 			AUTORELEASED
	 * @cb-param int32_t redemptions 			
	 * @cb-param const char * payload 			AUTORELEASED
	 */
	typedef void (*MBCReward_redeemRewardCodeCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCUser * inviter,
				int32_t redemptions,
				/*AUTORELEASED*/ const char * payload,
				
				void * context
																);
	
	#pragma mark - Static Methods
#if MB_WW
	/**
	 * MBCReward_redeemRewardCode
	 * @function
	 * @public
	 * @description 
	 *
	 * @param const char *  code 			AUTORELEASED
	 * @cb RedeemRewardCodeOnCompleteCallback  onComplete 			
	 * @cb-param MBCSimpleAPIStatus status 			
	 * @cb-param MBCError * error 			AUTORELEASED
	 * @cb-param MBCUser * inviter 			AUTORELEASED
	 * @cb-param int32_t redemptions 			
	 * @cb-param const char * payload 			AUTORELEASED
	 * <br/>
	 */
	void MBCReward_redeemRewardCode(
										const char *  code,
										MBCReward_redeemRewardCodeCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_WW

#endif // MB_WW -- whole interface/model is region-specific

#ifdef __cplusplus
}
#endif

#endif /* MBCREWARD_H_ */

