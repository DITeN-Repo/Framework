﻿// Copyright alright reserved by DITeN™ ©® 2003 - 2019
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
// Creation Date: 2019/08/18 10:12 PM

namespace Diten
{
	public enum ExceptionResource
	{
		ArgumentOutOfRange_Index,
		ArgumentOutOfRange_IndexCount,
		ArgumentOutOfRange_IndexCountBuffer,
		ArgumentOutOfRange_Count,
		Arg_ArrayPlusOffTooSmall,
		NotSupported_ReadOnlyCollection,
		Arg_RankMultiDimNotSupported,
		Arg_NonZeroLowerBound,
		ArgumentOutOfRange_ListInsert,
		ArgumentOutOfRange_NeedNonNegNum,
		ArgumentOutOfRange_SmallCapacity,
		Argument_InvalidOffLen,
		Argument_CannotExtractScalar,
		ArgumentOutOfRange_BiggerThanCollection,
		Serialization_MissingKeys,
		Serialization_NullKey,
		NotSupported_KeyCollectionSet,
		NotSupported_ValueCollectionSet,
		InvalidOperation_NullArray,
		TaskT_TransitionToFinal_AlreadyCompleted,
		TaskCompletionSourceT_TrySetException_NullException,
		TaskCompletionSourceT_TrySetException_NoExceptions,
		NotSupported_StringComparison,
		ConcurrentCollection_SyncRoot_NotSupported,
		Task_MultiTaskContinuation_NullTask,
		InvalidOperation_WrongAsyncResultOrEndCalledMultiple,
		Task_MultiTaskContinuation_EmptyTaskList,
		Task_Start_TaskCompleted,
		Task_Start_Promise,
		Task_Start_ContinuationTask,
		Task_Start_AlreadyStarted,
		Task_RunSynchronously_Continuation,
		Task_RunSynchronously_Promise,
		Task_RunSynchronously_TaskCompleted,
		Task_RunSynchronously_AlreadyStarted,
		AsyncMethodBuilder_InstanceNotInitialized,
		Task_ContinueWith_ESandLR,
		Task_ContinueWith_NotOnAnything,
		Task_Delay_InvalidDelay,
		Task_Delay_InvalidMillisecondsDelay,
		Task_Dispose_NotCompleted,
		Task_ThrowIfDisposed,
		Task_WaitMulti_NullTask,
		ArgumentException_OtherNotArrayOfCorrectLength,
		ArgumentNull_Array,
		ArgumentNull_SafeHandle,
		ArgumentOutOfRange_EndIndexStartIndex,
		ArgumentOutOfRange_Enum,
		ArgumentOutOfRange_HugeArrayNotSupported,
		Argument_AddingDuplicate,
		Argument_InvalidArgumentForComparison,
		Arg_LowerBoundsMustMatch,
		Arg_MustBeType,
		Arg_Need1DArray,
		Arg_Need2DArray,
		Arg_Need3DArray,
		Arg_NeedAtLeast1Rank,
		Arg_RankIndices,
		Arg_RanksAndBounds,
		InvalidOperation_IComparerFailed,
		NotSupported_FixedSizeCollection,
		Rank_MultiDimNotSupported,
		Arg_TypeNotSupported
	}
}