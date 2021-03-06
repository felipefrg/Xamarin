﻿using System;
using ObjCRuntime;

namespace GoogleIMA
{
	[Native]
	public enum IMAErrorType : long
	{
		UnknownErrorType,
		LoadingFailed,
		PlayingFailed
	}

	[Native]
	public enum IMAErrorCode : long
	{
		VastMalformedResponse = 100,
		VastTraffickingError = 200,
		VastLoadTimeout = 301,
		VastTooManyRedirects = 302,
		VastInvalidUrl = 303,
		VideoPlayError = 400,
		VastMediaLoadTimeout = 402,
		VastLinearAssetMismatch = 403,
		CompanionAdLoadingFailed = 603,
		UnknownError = 900,
		PlaylistMalformedResponse = 1004,
		FailedToRequestAds = 1005,
		RequiredListenersNotAdded = 1006,
		VastAssetNotFound = 1007,
		AdslotNotVisible = 1008,
		VastEmptyResponse = 1009,
		FailedLoadingAd = 1010,
		StreamInitializationFailed = 1020,
		InvalidArguments = 1101,
		ApiError = 1102,
		OsRuntimeTooOld = 1103,
		VideoElementUsed = 1201,
		VideoElementRequired = 1202,
		ContentPlayheadMissing = 1205
	}

	[Native]
	public enum IMAAdEventType : long
	{
		AdBreakReady,
		AdBreakFetchError,
		AdBreakEnded,
		AdBreakStarted,
		AdPeriodEnded,
		AdPeriodStarted,
		AllAdsCompleted,
		Clicked,
		Complete,
		CuepointsChanged,
		IconFallbackImageClosed,
		IconTapped,
		FirstQuartile,
		Loaded,
		Log,
		Midpoint,
		Pause,
		Resume,
		Skipped,
		Started,
		StreamLoaded,
		StreamStarted,
		Tapped,
		ThirdQuartile
	}

	[Native]
	public enum IMAFriendlyObstructionPurpose : long
	{
		MediaControls,
		CloseAd,
		NotVisible,
		Other
	}

	[Native]
	public enum IMAUiElementType : long
	{
		AdAttribution,
		Countdown
	}
}