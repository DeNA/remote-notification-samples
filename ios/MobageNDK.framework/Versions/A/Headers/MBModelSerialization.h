//
//  MBModelSerialization.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/16/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_MBModelSerialization_h
#define mobage_ndk_MBModelSerialization_h

#import <Foundation/Foundation.h>

typedef enum {
	kMBModelSerializationEnvironmentUnknown = 0,
	kMBModelSerializationEnvironmentToModel,
	kMBModelSerializationEnvironmentToDisk,
	kMBModelSerializationEnvironmentToServer,
	
#warning TODO Make this Distinct / Useful!
	kMBModelSerializationEnvironmentToJS = 0
} MBModelSerializationEnvironment;


#pragma mark - Unpackers

#define MBModelUnpackerNSString(usType, setter)\
[^(id us, id value){\
	usType* obj = (usType*)us;\
	if((!value || value == [NSNull null]) || value && (([value isKindOfClass:[NSString class]] || ([value isKindOfClass:[NSNumber class]] && (value = [value description]))))) {\
		obj.setter = (value == [NSNull null])?nil:value;\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelUnpackerBOOL(usType, setter)\
[^(id us, id value){\
	usType* obj = (usType*)us;\
	id tmp;\
	if(value && (tmp = value) && [tmp isKindOfClass:[NSNumber class]]) {\
		obj.setter = [tmp boolValue];\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelUnpackerNSInteger(usType, setter)\
[^(id us, id value){\
	usType* obj = (usType*)us;\
	id tmp;\
	if(value && (tmp = value) && [tmp isKindOfClass:[NSNumber class]]) {\
		obj.setter = [tmp integerValue];\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelUnpackerNSUInteger(usType, setter)\
[^(id us, id value){\
	usType* obj = (usType*)us;\
	id tmp;\
	if(value && (tmp = value) && [tmp isKindOfClass:[NSNumber class]]) {\
		obj.setter = [tmp unsignedIntegerValue];\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelUnpackerdouble(usType, setter)\
[^(id us, id value){\
	usType* obj = (usType*)us;\
	id tmp;\
	if(value && (tmp = value) && [tmp isKindOfClass:[NSNumber class]]) {\
		obj.setter = [tmp doubleValue];\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelUnpackerNSData(usType, setter)\
[^(id us, id value){\
	usType* obj = (usType*)us;\
	NSData * tmp; \
	if((!value || value == [NSNull null]) || (tmp = [NSData dataWithBase64EncodedString:value])){\
		obj.setter = (value == [NSNull null])?nil:tmp;\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelUnpackerNSArray(usType, setter)\
[^(id us, id value){\
    usType* obj = (usType*)us;\
    id tmp;\
    if(value && (tmp = value) && [tmp isKindOfClass:[NSArray class]]) {\
        obj.setter = tmp;\
        return YES;\
    }\
    return NO;\
} copy]

#define MBModelUnpackerNSArrayTyped(usType, innerType, setter)\
[^(id us, id value){\
	usType* obj = (usType*)us;\
	id tmp;\
	if(value && (tmp = value) && [tmp isKindOfClass:[NSArray class]]) {\
		NSMutableArray * tArray = [NSMutableArray arrayWithCapacity:[tmp count]];\
		for (NSDictionary * dict in ((NSArray*) tmp)){\
			innerType * tmpObj = [[innerType alloc] initWithDictionary:dict];\
			if (tmpObj){[tArray addObject:tmpObj];}\
		}\
		obj.setter = tArray;\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelUnpackerModel(usType, innerType, setter)\
[^(id us, id value){\
	usType* obj = (usType*)us;\
	id tmp;\
	if(value && (tmp = value) && [tmp isKindOfClass:[NSDictionary class]]) {\
		innerType * tmpObj = [[innerType alloc] initWithDictionary:tmp];\
		if (tmpObj){\
			obj.setter = tmpObj;\
			return YES;\
		}\
	}\
	return NO;\
} copy]

#pragma mark - Packers

#define MBModelPackerNSString(usType, serialKey, getter)\
[^(id us,NSMutableDictionary* output){\
	usType* obj = (usType*)us;\
	NSString* tmp = obj.getter;\
	if (tmp){\
		[output setObject: tmp forKey: serialKey];\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelPackerBOOL(usType, serialKey, getter)\
[^(id us,NSMutableDictionary* output){\
	usType* obj = (usType*)us;\
	NSNumber* tmp = [NSNumber numberWithBool:obj.getter];\
	if (tmp){\
		[output setObject: tmp forKey: serialKey];\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelPackerNSInteger(usType, serialKey, getter)\
[^(id us,NSMutableDictionary* output){\
	usType* obj = (usType*)us;\
	NSNumber* tmp = [NSNumber numberWithInteger:obj.getter];\
	if (tmp){\
		[output setObject: tmp forKey: serialKey];\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelPackerNSUInteger(usType, serialKey, getter)\
[^(id us,NSMutableDictionary* output){\
	usType* obj = (usType*)us;\
	NSNumber* tmp = [NSNumber numberWithUnsignedInteger:obj.getter];\
	if (tmp){\
		[output setObject: tmp forKey: serialKey];\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelPackerdouble(usType, serialKey, getter)\
[^(id us,NSMutableDictionary* output){\
	usType* obj = (usType*)us;\
	NSNumber* tmp = [NSNumber numberWithDouble:obj.getter];\
	if (tmp){\
		[output setObject: tmp forKey: serialKey];\
		return YES;\
	}\
	NSLog(@"Failed to pack double");\
	return NO;\
} copy]

#define MBModelPackerNSData(usType, serialKey, getter)\
[^(id us,NSMutableDictionary* output){\
	usType* obj = (usType*)us;\
	NSData* tmp = obj.getter;\
	if (tmp){\
		[output setObject: [tmp base64Encoding] forKey: serialKey];\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelPackerNSArray(usType, serialKey, getter)\
[^(id us,NSMutableDictionary* output){\
    usType* obj = (usType*)us;\
    NSArray* tmp = obj.getter; \
    if(tmp) { \
        [output setObject:tmp forKey:serialKey];\
        return YES;\
    }\
    return NO;\
} copy]

#define MBModelPackerNSArrayTyped(usType, innerType, packingEnvironment, serialKey, getter)\
[^(id us,NSMutableDictionary* output){\
	usType* obj = (usType*)us;\
	NSArray* tmp = obj.getter; \
	if(tmp) { \
		NSMutableArray * outputArr = [NSMutableArray arrayWithCapacity: [tmp count]];\
		for (innerType * tObj in tmp){\
			[outputArr addObject: [tObj packForEnvironment:packingEnvironment]];\
		}\
		[output setObject:outputArr forKey:serialKey];\
		return YES;\
	}\
	return NO;\
} copy]

#define MBModelPackerModel(usType, innerType, packingEnvironment, serialKey, getter)\
[^(id us,NSMutableDictionary* output){\
	usType* obj = (usType*)us;\
	innerType * tmp = obj.getter; \
	if(tmp) { \
		[output setObject:[tmp packForEnvironment: packingEnvironment] forKey:serialKey];\
		return YES;\
	}\
	return NO;\
} copy]

#pragma mark -
#import <Foundation/Foundation.h>
@interface MBPropertyAliases : NSObject <NSObject>
{
}
@property (nonatomic, readwrite, strong) NSMutableDictionary *toModel;
@property (nonatomic, readwrite, strong) NSMutableDictionary *toDisk;
@property (nonatomic, readwrite, strong) NSMutableDictionary *toServer;

@end

@protocol MBSerializableItem <NSObject>
- (NSDictionary*)packForEnvironment:(MBModelSerializationEnvironment)env;
@end

@protocol MBSerializableModel <MBSerializableItem>

+ (void) registerPropertyAliases;
+ (BOOL (^)(id obj, id value)) unpackerForKey:(NSString*)key;

@end

#endif
