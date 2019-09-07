#region DITeN Registration Info

// Copyright alright reserved by DITeN™ ©® 2003 - 2019
// ----------------------------------------------------------------------------------------------
// Agreement:
// 
// All developers could modify or developing this code but changing the architecture of
// the product is not allowed.
// 
// DITeN Research & Development
// ----------------------------------------------------------------------------------------------
// Solution: Diten Framework (V 2.1)
// Author: Arash Rahimian
// Creation Date: 2019/08/18 9:07 PM

#endregion

#region Used Directives

using EX = Diten.Parameters.Exceptions;

#endregion

//namespace Diten
//{
//	[StackTraceHidden]
//	internal static class ThrowHelper
//	{
//		[return: Nullable(1)]
//		private ArgumentException GetAddingDuplicateWithKeyArgumentException(
//			[Nullable(2)] object key) =>
//			new ArgumentException(string.Format(EX.Argument_AddingDuplicateWithKey, key));

//		[return: Nullable(1)]
//		private static ArgumentException GetArgumentException(
//			ExceptionResource resource) =>
//			new ArgumentException(GetResourceString(resource));

//		[return: Nullable(1)]
//		private static ArgumentException GetArgumentException(
//			ExceptionResource resource,
//			ExceptionArgument argument) =>
//			new ArgumentException(GetResourceString(resource), GetArgumentName(argument));

//		[return: Nullable(1)]
//		private static string GetArgumentName(ExceptionArgument argument)
//		{
//			switch (argument)
//			{
//				case ExceptionArgument.obj:
//					return "obj";
//				case ExceptionArgument.dictionary:
//					return "dictionary";
//				case ExceptionArgument.array:
//					return "array";
//				case ExceptionArgument.info:
//					return "info";
//				case ExceptionArgument.key:
//					return "key";
//				case ExceptionArgument.text:
//					return "text";
//				case ExceptionArgument.values:
//					return "values";
//				case ExceptionArgument.value:
//					return "value";
//				case ExceptionArgument.startIndex:
//					return "startIndex";
//				case ExceptionArgument.task:
//					return "task";
//				case ExceptionArgument.bytes:
//					return "bytes";
//				case ExceptionArgument.byteIndex:
//					return "byteIndex";
//				case ExceptionArgument.byteCount:
//					return "byteCount";
//				case ExceptionArgument.ch:
//					return "ch";
//				case ExceptionArgument.chars:
//					return "chars";
//				case ExceptionArgument.charIndex:
//					return "charIndex";
//				case ExceptionArgument.charCount:
//					return "charCount";
//				case ExceptionArgument.s:
//					return "s";
//				case ExceptionArgument.input:
//					return "input";
//				case ExceptionArgument.ownedMemory:
//					return "ownedMemory";
//				case ExceptionArgument.list:
//					return "list";
//				case ExceptionArgument.index:
//					return "index";
//				case ExceptionArgument.capacity:
//					return "capacity";
//				case ExceptionArgument.collection:
//					return "collection";
//				case ExceptionArgument.item:
//					return "item";
//				case ExceptionArgument.converter:
//					return "converter";
//				case ExceptionArgument.match:
//					return "match";
//				case ExceptionArgument.count:
//					return "count";
//				case ExceptionArgument.action:
//					return "action";
//				case ExceptionArgument.comparison:
//					return "comparison";
//				case ExceptionArgument.exceptions:
//					return "exceptions";
//				case ExceptionArgument.exception:
//					return "exception";
//				case ExceptionArgument.pointer:
//					return "pointer";
//				case ExceptionArgument.start:
//					return "start";
//				case ExceptionArgument.format:
//					return "format";
//				case ExceptionArgument.culture:
//					return "culture";
//				case ExceptionArgument.comparer:
//					return "comparer";
//				case ExceptionArgument.comparable:
//					return "comparable";
//				case ExceptionArgument.source:
//					return "source";
//				case ExceptionArgument.state:
//					return "state";
//				case ExceptionArgument.length:
//					return "length";
//				case ExceptionArgument.comparisonType:
//					return "comparisonType";
//				case ExceptionArgument.manager:
//					return "manager";
//				case ExceptionArgument.sourceBytesToCopy:
//					return "sourceBytesToCopy";
//				case ExceptionArgument.callBack:
//					return "callBack";
//				case ExceptionArgument.creationOptions:
//					return "creationOptions";
//				case ExceptionArgument.function:
//					return "function";
//				case ExceptionArgument.scheduler:
//					return "scheduler";
//				case ExceptionArgument.continuationAction:
//					return "continuationAction";
//				case ExceptionArgument.continuationFunction:
//					return "continuationFunction";
//				case ExceptionArgument.tasks:
//					return "tasks";
//				case ExceptionArgument.asyncResult:
//					return "asyncResult";
//				case ExceptionArgument.beginMethod:
//					return "beginMethod";
//				case ExceptionArgument.endMethod:
//					return "endMethod";
//				case ExceptionArgument.endFunction:
//					return "endFunction";
//				case ExceptionArgument.cancellationToken:
//					return "cancellationToken";
//				case ExceptionArgument.continuationOptions:
//					return "continuationOptions";
//				case ExceptionArgument.delay:
//					return "delay";
//				case ExceptionArgument.millisecondsDelay:
//					return "millisecondsDelay";
//				case ExceptionArgument.millisecondsTimeout:
//					return "millisecondsTimeout";
//				case ExceptionArgument.stateMachine:
//					return "stateMachine";
//				case ExceptionArgument.timeout:
//					return "timeout";
//				case ExceptionArgument.type:
//					return "type";
//				case ExceptionArgument.sourceIndex:
//					return "sourceIndex";
//				case ExceptionArgument.sourceArray:
//					return "sourceArray";
//				case ExceptionArgument.destinationIndex:
//					return "destinationIndex";
//				case ExceptionArgument.destinationArray:
//					return "destinationArray";
//				case ExceptionArgument.pHandle:
//					return "pHandle";
//				case ExceptionArgument.other:
//					return "other";
//				case ExceptionArgument.newSize:
//					return "newSize";
//				case ExceptionArgument.lowerBounds:
//					return "lowerBounds";
//				case ExceptionArgument.lengths:
//					return "lengths";
//				case ExceptionArgument.len:
//					return "len";
//				case ExceptionArgument.keys:
//					return "keys";
//				case ExceptionArgument.indices:
//					return "indices";
//				case ExceptionArgument.index1:
//					return "index1";
//				case ExceptionArgument.index2:
//					return "index2";
//				case ExceptionArgument.index3:
//					return "index3";
//				case ExceptionArgument.length1:
//					return "length1";
//				case ExceptionArgument.length2:
//					return "length2";
//				case ExceptionArgument.length3:
//					return "length3";
//				case ExceptionArgument.endIndex:
//					return "endIndex";
//				case ExceptionArgument.elementType:
//					return "elementType";
//				case ExceptionArgument.arrayIndex:
//					return "arrayIndex";
//				default:
//					return "";
//			}
//		}

//		[return: Nullable(1)]
//		private static ArgumentNullException GetArgumentNullException(
//			ExceptionArgument argument) =>
//			new ArgumentNullException(GetArgumentName(argument));

//		[return: Nullable(1)]
//		private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(
//			ExceptionArgument argument,
//			ExceptionResource resource) =>
//			new ArgumentOutOfRangeException(GetArgumentName(argument), GetResourceString(resource));

//		[return: Nullable(1)]
//		private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(
//			ExceptionArgument argument,
//			int paramNumber,
//			ExceptionResource resource) =>
//			new ArgumentOutOfRangeException(GetArgumentName(argument) + "[" + paramNumber + "]",
//				GetResourceString(resource));

//		[return: Nullable(1)]
//		private static Exception GetArraySegmentCtorValidationFailedException(
//			[Nullable(2)] Array array,
//			int offset,
//			int count)
//		{
//			if (array == null)
//				return (Exception) new ArgumentNullException(nameof(array));
//			if (offset < 0)
//				return (Exception) new ArgumentOutOfRangeException(nameof(offset), EX.ArgumentOutOfRange_NeedNonNegNum);
//			if (count < 0)
//				return (Exception) new ArgumentOutOfRangeException(nameof(count), EX.ArgumentOutOfRange_NeedNonNegNum);
//			return (Exception) new ArgumentException(EX.Argument_InvalidOffLen);
//		}

//		[return: Nullable(1)]
//		private static InvalidOperationException GetInvalidOperationException(
//			ExceptionResource resource) =>
//			new InvalidOperationException(GetResourceString(resource));

//		[return: Nullable(1)]
//		private static InvalidOperationException GetInvalidOperationException_EnumCurrent(
//			int index) =>
//			new InvalidOperationException(index < 0
//				? EX.InvalidOperation_EnumNotStarted
//				: EX.InvalidOperation_EnumEnded);

//		[return: Nullable(1)]
//		private static KeyNotFoundException GetKeyNotFoundException([Nullable(2)] object key) =>
//			new KeyNotFoundException(string.Format(EX.Arg_KeyNotFoundWithKey, key));

//		[return: Nullable(1)]
//		private static string GetResourceString(ExceptionResource resource)
//		{
//			switch (resource)
//			{
//				case ExceptionResource.ArgumentOutOfRange_Index:
//					return EX.ArgumentOutOfRange_Index;
//				case ExceptionResource.ArgumentOutOfRange_IndexCount:
//					return EX.ArgumentOutOfRange_IndexCount;
//				case ExceptionResource.ArgumentOutOfRange_IndexCountBuffer:
//					return EX.ArgumentOutOfRange_IndexCountBuffer;
//				case ExceptionResource.ArgumentOutOfRange_Count:
//					return EX.ArgumentOutOfRange_Count;
//				case ExceptionResource.Arg_ArrayPlusOffTooSmall:
//					return EX.Arg_ArrayPlusOffTooSmall;
//				case ExceptionResource.NotSupported_ReadOnlyCollection:
//					return EX.NotSupported_ReadOnlyCollection;
//				case ExceptionResource.Arg_RankMultiDimNotSupported:
//					return EX.Arg_RankMultiDimNotSupported;
//				case ExceptionResource.Arg_NonZeroLowerBound:
//					return EX.Arg_NonZeroLowerBound;
//				case ExceptionResource.ArgumentOutOfRange_ListInsert:
//					return EX.ArgumentOutOfRange_ListInsert;
//				case ExceptionResource.ArgumentOutOfRange_NeedNonNegNum:
//					return EX.ArgumentOutOfRange_NeedNonNegNum;
//				case ExceptionResource.ArgumentOutOfRange_SmallCapacity:
//					return EX.ArgumentOutOfRange_SmallCapacity;
//				case ExceptionResource.Argument_InvalidOffLen:
//					return EX.Argument_InvalidOffLen;
//				case ExceptionResource.Argument_CannotExtractScalar:
//					return EX.Argument_CannotExtractScalar;
//				case ExceptionResource.ArgumentOutOfRange_BiggerThanCollection:
//					return EX.ArgumentOutOfRange_BiggerThanCollection;
//				case ExceptionResource.Serialization_MissingKeys:
//					return EX.Serialization_MissingKeys;
//				case ExceptionResource.Serialization_NullKey:
//					return EX.Serialization_NullKey;
//				case ExceptionResource.NotSupported_KeyCollectionSet:
//					return EX.NotSupported_KeyCollectionSet;
//				case ExceptionResource.NotSupported_ValueCollectionSet:
//					return EX.NotSupported_ValueCollectionSet;
//				case ExceptionResource.InvalidOperation_NullArray:
//					return EX.InvalidOperation_NullArray;
//				case ExceptionResource.TaskT_TransitionToFinal_AlreadyCompleted:
//					return EX.TaskT_TransitionToFinal_AlreadyCompleted;
//				case ExceptionResource.TaskCompletionSourceT_TrySetException_NullException:
//					return EX.TaskCompletionSourceT_TrySetException_NullException;
//				case ExceptionResource.TaskCompletionSourceT_TrySetException_NoExceptions:
//					return EX.TaskCompletionSourceT_TrySetException_NoExceptions;
//				case ExceptionResource.NotSupported_StringComparison:
//					return EX.NotSupported_StringComparison;
//				case ExceptionResource.ConcurrentCollection_SyncRoot_NotSupported:
//					return EX.ConcurrentCollection_SyncRoot_NotSupported;
//				case ExceptionResource.Task_MultiTaskContinuation_NullTask:
//					return EX.Task_MultiTaskContinuation_NullTask;
//				case ExceptionResource.InvalidOperation_WrongAsyncResultOrEndCalledMultiple:
//					return EX.InvalidOperation_WrongAsyncResultOrEndCalledMultiple;
//				case ExceptionResource.Task_MultiTaskContinuation_EmptyTaskList:
//					return EX.Task_MultiTaskContinuation_EmptyTaskList;
//				case ExceptionResource.Task_Start_TaskCompleted:
//					return EX.Task_Start_TaskCompleted;
//				case ExceptionResource.Task_Start_Promise:
//					return EX.Task_Start_Promise;
//				case ExceptionResource.Task_Start_ContinuationTask:
//					return EX.Task_Start_ContinuationTask;
//				case ExceptionResource.Task_Start_AlreadyStarted:
//					return EX.Task_Start_AlreadyStarted;
//				case ExceptionResource.Task_RunSynchronously_Continuation:
//					return EX.Task_RunSynchronously_Continuation;
//				case ExceptionResource.Task_RunSynchronously_Promise:
//					return EX.Task_RunSynchronously_Promise;
//				case ExceptionResource.Task_RunSynchronously_TaskCompleted:
//					return EX.Task_RunSynchronously_TaskCompleted;
//				case ExceptionResource.Task_RunSynchronously_AlreadyStarted:
//					return EX.Task_RunSynchronously_AlreadyStarted;
//				case ExceptionResource.AsyncMethodBuilder_InstanceNotInitialized:
//					return EX.AsyncMethodBuilder_InstanceNotInitialized;
//				case ExceptionResource.Task_ContinueWith_ESandLR:
//					return EX.Task_ContinueWith_ESandLR;
//				case ExceptionResource.Task_ContinueWith_NotOnAnything:
//					return EX.Task_ContinueWith_NotOnAnything;
//				case ExceptionResource.Task_Delay_InvalidDelay:
//					return EX.Task_Delay_InvalidDelay;
//				case ExceptionResource.Task_Delay_InvalidMillisecondsDelay:
//					return EX.Task_Delay_InvalidMillisecondsDelay;
//				case ExceptionResource.Task_Dispose_NotCompleted:
//					return EX.Task_Dispose_NotCompleted;
//				case ExceptionResource.Task_ThrowIfDisposed:
//					return EX.Task_ThrowIfDisposed;
//				case ExceptionResource.Task_WaitMulti_NullTask:
//					return EX.Task_WaitMulti_NullTask;
//				case ExceptionResource.ArgumentException_OtherNotArrayOfCorrectLength:
//					return EX.ArgumentException_OtherNotArrayOfCorrectLength;
//				case ExceptionResource.ArgumentNull_Array:
//					return EX.ArgumentNull_Array;
//				case ExceptionResource.ArgumentNull_SafeHandle:
//					return EX.ArgumentNull_SafeHandle;
//				case ExceptionResource.ArgumentOutOfRange_EndIndexStartIndex:
//					return EX.ArgumentOutOfRange_EndIndexStartIndex;
//				case ExceptionResource.ArgumentOutOfRange_Enum:
//					return EX.ArgumentOutOfRange_Enum;
//				case ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported:
//					return EX.ArgumentOutOfRange_HugeArrayNotSupported;
//				case ExceptionResource.Argument_AddingDuplicate:
//					return EX.Argument_AddingDuplicate;
//				case ExceptionResource.Argument_InvalidArgumentForComparison:
//					return EX.Argument_InvalidArgumentForComparison;
//				case ExceptionResource.Arg_LowerBoundsMustMatch:
//					return EX.Arg_LowerBoundsMustMatch;
//				case ExceptionResource.Arg_MustBeType:
//					return EX.Arg_MustBeType;
//				case ExceptionResource.Arg_Need1DArray:
//					return EX.Arg_Need1DArray;
//				case ExceptionResource.Arg_Need2DArray:
//					return EX.Arg_Need2DArray;
//				case ExceptionResource.Arg_Need3DArray:
//					return EX.Arg_Need3DArray;
//				case ExceptionResource.Arg_NeedAtLeast1Rank:
//					return EX.Arg_NeedAtLeast1Rank;
//				case ExceptionResource.Arg_RankIndices:
//					return EX.Arg_RankIndices;
//				case ExceptionResource.Arg_RanksAndBounds:
//					return EX.Arg_RanksAndBounds;
//				case ExceptionResource.InvalidOperation_IComparerFailed:
//					return EX.InvalidOperation_IComparerFailed;
//				case ExceptionResource.NotSupported_FixedSizeCollection:
//					return EX.NotSupported_FixedSizeCollection;
//				case ExceptionResource.Rank_MultiDimNotSupported:
//					return EX.Rank_MultiDimNotSupported;
//				case ExceptionResource.Arg_TypeNotSupported:
//					return EX.Arg_TypeNotSupported;
//				default:
//					return "";
//			}
//		}

//		[return: Nullable(1)]
//		private static ArgumentException GetWrongKeyTypeArgumentException(
//			[Nullable(2)] object key,
//			[Nullable(1)] Type targetType) =>
//			new ArgumentException(string.Format(EX.Arg_WrongType, key, targetType), nameof(key));

//		[return: Nullable(1)]
//		private static ArgumentException GetWrongValueTypeArgumentException(
//			[Nullable(2)] object value,
//			[Nullable(1)] Type targetType) =>
//			new ArgumentException(string.Format(EX.Arg_WrongType, value, targetType), nameof(value));

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		internal static void IfNullAndNullsAreIllegalThenThrow<[Nullable(2)] T>(
//			[Nullable(1)] object value,
//			ExceptionArgument argName)
//		{
//			if (default(T) == null || value != null)
//				return;
//			ThrowArgumentNullException(argName);
//		}

//		internal static void ThrowAddingDuplicateWithKeyArgumentException<[Nullable(2)] T>([Nullable(1)] T key)
//		{
//			throw GetAddingDuplicateWithKeyArgumentException(key);
//		}

//		internal static void ThrowAggregateException([Nullable(1)] List<Exception> exceptions)
//		{
//			throw new AggregateException(exceptions);
//		}

//		internal static void ThrowArgumentException(ExceptionResource resource)
//		{
//			throw GetArgumentException(resource);
//		}

//		internal static void ThrowArgumentException(
//			ExceptionResource resource,
//			ExceptionArgument argument)
//		{
//			throw GetArgumentException(resource, argument);
//		}

//		internal static void ThrowArgumentException_Argument_InvalidArrayType()
//		{
//			throw new ArgumentException(EX.Argument_InvalidArrayType);
//		}

//		internal static void ThrowArgumentException_CannotExtractScalar(ExceptionArgument argument)
//		{
//			throw ThrowHelper.GetArgumentException(EX.Argument_CannotExtractScalar, argument);
//		}

//		internal static void ThrowArgumentException_DestinationTooShort()
//		{
//			throw new ArgumentException(EX.Argument_DestinationTooShort, "destination");
//		}

//		internal static void ThrowArgumentException_OverlapAlignmentMismatch()
//		{
//			throw new ArgumentException(EX.Argument_OverlapAlignmentMismatch);
//		}

//		internal static void ThrowArgumentNullException(ExceptionArgument argument)
//		{
//			throw GetArgumentNullException(argument);
//		}

//		internal static void ThrowArgumentNullException(
//			ExceptionArgument argument,
//			ExceptionResource resource)
//		{
//			throw new ArgumentNullException(GetArgumentName(argument), GetResourceString(resource));
//		}

//		internal static void ThrowArgumentOutOfRange_IndexException()
//		{
//			throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.index, EX.ArgumentOutOfRange_Index);
//		}

//		internal static void ThrowArgumentOutOfRangeException()
//		{
//			throw new ArgumentOutOfRangeException();
//		}

//		internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument)
//		{
//			throw new ArgumentOutOfRangeException(GetArgumentName(argument));
//		}

//		internal static void ThrowArgumentOutOfRangeException(
//			ExceptionArgument argument,
//			ExceptionResource resource)
//		{
//			throw GetArgumentOutOfRangeException(argument, resource);
//		}

//		internal static void ThrowArgumentOutOfRangeException(
//			ExceptionArgument argument,
//			int paramNumber,
//			ExceptionResource resource)
//		{
//			throw GetArgumentOutOfRangeException(argument, paramNumber, resource);
//		}

//		internal static void ThrowArgumentOutOfRangeException_PrecisionTooLarge()
//		{
//			throw new ArgumentOutOfRangeException("precision", string.Format(EX.Argument_PrecisionTooLarge, (byte) 99));
//		}

//		internal static void ThrowArgumentOutOfRangeException_SymbolDoesNotFit()
//		{
//			throw new ArgumentOutOfRangeException("symbol", EX.Argument_BadFormatSpecifier);
//		}

//		internal static void ThrowArraySegmentCtorValidationFailedExceptions(
//			[Nullable(2)] Array array,
//			int offset,
//			int count)
//		{
//			throw GetArraySegmentCtorValidationFailedException(array, offset, count);
//		}

//		internal static void ThrowArrayTypeMismatchException()
//		{
//			throw new ArrayTypeMismatchException();
//		}

//		internal static void ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count()
//		{
//			throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.count, EX.ArgumentOutOfRange_Count);
//		}

//		internal static void ThrowFormatException_BadFormatSpecifier()
//		{
//			throw new FormatException(EX.Argument_BadFormatSpecifier);
//		}

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		internal static void ThrowForUnsupportedVectorBaseType<T>() where T : struct
//		{
//			if (!(typeof(T) != typeof(byte)) || !(typeof(T) != typeof(sbyte)) || !(typeof(T) != typeof(short)) ||
//			    !(typeof(T) != typeof(ushort)) || !(typeof(T) != typeof(int)) || !(typeof(T) != typeof(uint)) ||
//			    !(typeof(T) != typeof(long)) || !(typeof(T) != typeof(ulong)) || !(typeof(T) != typeof(float)) ||
//			    !(typeof(T) != typeof(double)))
//				return;
//			ThrowHelper.ThrowNotSupportedException(EX.Arg_TypeNotSupported);
//		}

//		internal static void ThrowIndexArgumentOutOfRange_NeedNonNegNumException()
//		{
//			throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.index, EX.ArgumentOutOfRange_NeedNonNegNum);
//		}

//		internal static void ThrowIndexOutOfRangeException()
//		{
//			throw new IndexOutOfRangeException();
//		}

//		internal static void ThrowInvalidOperationException()
//		{
//			throw new InvalidOperationException();
//		}

//		internal static void ThrowInvalidOperationException(ExceptionResource resource)
//		{
//			throw GetInvalidOperationException(resource);
//		}

//		internal static void ThrowInvalidOperationException(ExceptionResource resource, [Nullable(1)] Exception e)
//		{
//			throw new InvalidOperationException(GetResourceString(resource), e);
//		}

//		internal static void ThrowInvalidOperationException_ConcurrentOperationsNotSupported()
//		{
//			throw new InvalidOperationException(EX.InvalidOperation_ConcurrentOperationsNotSupported);
//		}

//		internal static void ThrowInvalidOperationException_EnumCurrent(int index)
//		{
//			throw GetInvalidOperationException_EnumCurrent(index);
//		}

//		internal static void ThrowInvalidOperationException_HandleIsNotInitialized()
//		{
//			throw new InvalidOperationException(EX.InvalidOperation_HandleIsNotInitialized);
//		}

//		internal static void ThrowInvalidOperationException_HandleIsNotPinned()
//		{
//			throw new InvalidOperationException(EX.InvalidOperation_HandleIsNotPinned);
//		}

//		internal static void ThrowInvalidOperationException_InvalidOperation_EnumEnded()
//		{
//			throw new InvalidOperationException(EX.InvalidOperation_EnumEnded);
//		}

//		internal static void ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion()
//		{
//			throw new InvalidOperationException(EX.InvalidOperation_EnumFailedVersion);
//		}

//		internal static void ThrowInvalidOperationException_InvalidOperation_EnumNotStarted()
//		{
//			throw new InvalidOperationException(EX.InvalidOperation_EnumNotStarted);
//		}

//		internal static void ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen()
//		{
//			throw new InvalidOperationException(EX.InvalidOperation_EnumOpCantHappen);
//		}

//		internal static void ThrowInvalidOperationException_InvalidOperation_NoValue()
//		{
//			throw new InvalidOperationException(EX.InvalidOperation_NoValue);
//		}

//		internal static void ThrowInvalidTypeWithPointersNotSupported([Nullable(1)] Type targetType)
//		{
//			throw new ArgumentException(string.Format(EX.Argument_InvalidTypeWithPointersNotSupported, targetType));
//		}

//		internal static void ThrowKeyNotFoundException<[Nullable(2)] T>([Nullable(1)] T key)
//		{
//			throw GetKeyNotFoundException(key);
//		}

//		internal static void ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum()
//		{
//			throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.length,
//				EX.ArgumentOutOfRange_NeedNonNegNum);
//		}

//		internal static void ThrowNotSupportedException(ExceptionResource resource)
//		{
//			throw new NotSupportedException(GetResourceString(resource));
//		}

//		internal static void ThrowNotSupportedException()
//		{
//			throw new NotSupportedException();
//		}

//		internal static void ThrowObjectDisposedException(ExceptionResource resource)
//		{
//			throw new ObjectDisposedException(null, GetResourceString(resource));
//		}

//		internal static void ThrowRankException(ExceptionResource resource)
//		{
//			throw new RankException(GetResourceString(resource));
//		}

//		internal static void ThrowSerializationException(ExceptionResource resource)
//		{
//			throw new SerializationException(GetResourceString(resource));
//		}

//		internal static void ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index()
//		{
//			throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.startIndex, EX.ArgumentOutOfRange_Index);
//		}

//		internal static void ThrowValueArgumentOutOfRange_NeedNonNegNumException()
//		{
//			throw ThrowHelper.GetArgumentOutOfRangeException(ExceptionArgument.value, EX.ArgumentOutOfRange_NeedNonNegNum);
//		}

//		internal static void ThrowWrongKeyTypeArgumentException<[Nullable(2)] T>(
//			[Nullable(1)] T key,
//			[Nullable(1)] Type targetType)
//		{
//			throw GetWrongKeyTypeArgumentException(key, targetType);
//		}

//		internal static void ThrowWrongValueTypeArgumentException<[Nullable(2)] T>(
//			[Nullable(1)] T value,
//			[Nullable(1)] Type targetType)
//		{
//			throw GetWrongValueTypeArgumentException(value, targetType);
//		}
//	}
//}