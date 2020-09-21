using System;
using AVFoundation;
using AVKit;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace GoogleIMA
{
	//[Static]
	//partial interface GoogleInteractiveMediaAdsConstants
	//{
	//	// extern double GoogleInteractiveMediaAdsVersionNumber;
	//	[Field("GoogleInteractiveMediaAdsVersionNumber", "__Internal")]
	//	double GoogleInteractiveMediaAdsVersionNumber { get; }

	//	// extern const unsigned char [] GoogleInteractiveMediaAdsVersionString;
	//	[Field("GoogleInteractiveMediaAdsVersionString", "__Internal")]
	//	NSString GoogleInteractiveMediaAdsVersionString { get; }

	//	// extern NSString *const kIMAPropertyCurrentTime;
	//	[Field("kIMAPropertyCurrentTime", "__Internal")]
	//	NSString kIMAPropertyCurrentTime { get; }
	//}

	partial interface IIMAContentPlayhead { }
	// @protocol IMAContentPlayhead
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAContentPlayhead
	{
		// @required @property (readonly, nonatomic) NSTimeInterval currentTime;
		[Abstract]
		[Export("currentTime")]
		double CurrentTime { get; }
	}

	// @interface IMAAVPlayerContentPlayhead : NSObject <IMAContentPlayhead>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAVPlayerContentPlayhead : IMAContentPlayhead
	{
		// @property (readonly, nonatomic, strong) AVPlayer * player;
		[Export("player", ArgumentSemantic.Strong)]
		AVPlayer Player { get; }

		// -(instancetype)initWithAVPlayer:(AVPlayer *)player;
		[Export("initWithAVPlayer:")]
		IntPtr Constructor(AVPlayer player);
	}

	// @protocol IMAAdPlaybackInfo <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAAdPlaybackInfo
	{
		// @required @property (readonly, nonatomic) NSTimeInterval currentMediaTime;
		[Abstract]
		[Export("currentMediaTime")]
		double CurrentMediaTime { get; }

		// @required @property (readonly, nonatomic) NSTimeInterval totalMediaTime;
		[Abstract]
		[Export("totalMediaTime")]
		double TotalMediaTime { get; }

		// @required @property (readonly, nonatomic) NSTimeInterval bufferedMediaTime;
		[Abstract]
		[Export("bufferedMediaTime")]
		double BufferedMediaTime { get; }

		// @required @property (readonly, getter = isPlaying, nonatomic) BOOL playing;
		[Abstract]
		[Export("playing")]
		bool Playing { [Bind("isPlaying")] get; }
	}

	partial interface IIMAVideoDisplayDelegate { }
	// @protocol IMAVideoDisplayDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAVideoDisplayDelegate
	{
		// @required -(void)videoDisplayDidLoad:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export("videoDisplayDidLoad:")]
		void VideoDisplayDidLoad(IIMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidStart:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export("videoDisplayDidStart:")]
		void VideoDisplayDidStart(IIMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidPause:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export("videoDisplayDidPause:")]
		void VideoDisplayDidPause(IIMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidResume:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export("videoDisplayDidResume:")]
		void VideoDisplayDidResume(IIMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidPlay:(id<IMAVideoDisplay>)videoDisplay __attribute__((deprecated("Use videoDisplayDidResume: instead.")));
		[Abstract]
		[Export("videoDisplayDidPlay:")]
		void VideoDisplayDidPlay(IIMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidComplete:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export("videoDisplayDidComplete:")]
		void VideoDisplayDidComplete(IIMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidClick:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export("videoDisplayDidClick:")]
		void VideoDisplayDidClick(IIMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplay:(id<IMAVideoDisplay>)videoDisplay didReceiveError:(NSError *)error;
		[Abstract]
		[Export("videoDisplay:didReceiveError:")]
		void VideoDisplay(IIMAVideoDisplay videoDisplay, NSError error);

		// @required -(void)videoDisplayDidSkip:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export("videoDisplayDidSkip:")]
		void VideoDisplayDidSkip(IIMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplayDidShowSkip:(id<IMAVideoDisplay>)videoDisplay;
		[Abstract]
		[Export("videoDisplayDidShowSkip:")]
		void VideoDisplayDidShowSkip(IIMAVideoDisplay videoDisplay);

		// @required -(void)videoDisplay:(id<IMAVideoDisplay>)videoDisplay volumeChangedTo:(NSNumber *)volume;
		[Abstract]
		[Export("videoDisplay:volumeChangedTo:")]
		void VideoDisplay(IIMAVideoDisplay videoDisplay, NSNumber volume);

		// @required -(void)videoDisplay:(id<IMAVideoDisplay>)videoDisplay didProgressWithMediaTime:(NSTimeInterval)mediaTime totalTime:(NSTimeInterval)duration;
		[Abstract]
		[Export("videoDisplay:didProgressWithMediaTime:totalTime:")]
		void VideoDisplay(IIMAVideoDisplay videoDisplay, double mediaTime, double duration);

		// @required -(void)videoDisplay:(id<IMAVideoDisplay>)videoDisplay didReceiveTimedMetadata:(NSDictionary<NSString *,NSString *> *)metadata;
		[Abstract]
		[Export("videoDisplay:didReceiveTimedMetadata:")]
		void VideoDisplay(IIMAVideoDisplay videoDisplay, NSDictionary<NSString, NSString> metadata);

		// @optional -(void)videoDisplay:(id<IMAVideoDisplay>)videoDisplay didBufferToMediaTime:(NSTimeInterval)mediaTime;
		[Export("videoDisplay:didBufferToMediaTime:")]
		void VideoDisplay(IIMAVideoDisplay videoDisplay, double mediaTime);

		// @optional -(void)videoDisplayIsPlaybackReady:(id<IMAVideoDisplay>)videoDisplay;
		[Export("videoDisplayIsPlaybackReady:")]
		void VideoDisplayIsPlaybackReady(IIMAVideoDisplay videoDisplay);

		// @optional -(void)videoDisplayDidStartBuffering:(id<IMAVideoDisplay>)videoDisplay;
		[Export("videoDisplayDidStartBuffering:")]
		void VideoDisplayDidStartBuffering(IMAVideoDisplay videoDisplay);
	}

	partial interface IIMAVideoDisplay { }
	// @protocol IMAVideoDisplay <IMAAdPlaybackInfo>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAVideoDisplay : IMAAdPlaybackInfo
	{
		//[Wrap("WeakDelegate"), Abstract]
		//IIMAVideoDisplayDelegate Delegate { get; set; }

		//// @required @property (nonatomic, weak) id<IMAVideoDisplayDelegate> delegate;
		//[Abstract]
		//[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		//NSObject WeakDelegate { get; set; }

		[Abstract]
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		IIMAVideoDisplayDelegate WeakDelegate { get; set; }

		// @required @property (assign, nonatomic) float volume;
		[Abstract]
		[Export("volume")]
		float Volume { get; set; }

		// @required -(void)loadStream:(NSURL *)streamURL withSubtitles:(NSArray *)subtitles;
		[Abstract]
		[Export("loadStream:withSubtitles:")]
		void LoadStream(NSUrl streamURL, NSObject[] subtitles);

		// @required -(void)loadUrl:(NSURL *)url __attribute__((deprecated("Unused, use loadStream:withSubtitles: for media loading.")));
		[Abstract]
		[Export("loadUrl:")]
		void LoadUrl(NSUrl url);

		// @required -(void)play;
		[Abstract]
		[Export("play")]
		void Play();

		// @required -(void)pause;
		[Abstract]
		[Export("pause")]
		void Pause();

		// @required -(void)reset;
		[Abstract]
		[Export("reset")]
		void Reset();

		// @required -(void)seekStreamToTime:(NSTimeInterval)time;
		[Abstract]
		[Export("seekStreamToTime:")]
		void SeekStreamToTime(double time);
	}

	[Static]
	partial interface IMASubtitleConstants
	{
		// extern NSString *const kIMASubtitleLanguage;
		[Field("kIMASubtitleLanguage", "__Internal")]
		NSString kIMASubtitleLanguage { get; }

		// extern NSString *const kIMASubtitleWebVTT;
		[Field("kIMASubtitleWebVTT", "__Internal")]
		NSString kIMASubtitleWebVTT { get; }

		// extern NSString *const kIMASubtitleTTML;
		[Field("kIMASubtitleTTML", "__Internal")]
		NSString kIMASubtitleTTML { get; }
	}

	// @protocol IMAAVPlayerVideoDisplayDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAAVPlayerVideoDisplayDelegate
	{
		// @optional -(void)playerVideoDisplay:(IMAAVPlayerVideoDisplay *)playerVideoDisplay willLoadStreamAsset:(AVURLAsset *)URLAsset;
		[Export("playerVideoDisplay:willLoadStreamAsset:")]
		void WillLoadStreamAsset(IMAAVPlayerVideoDisplay playerVideoDisplay, AVUrlAsset URLAsset);

		// @optional -(void)playerVideoDisplay:(IMAAVPlayerVideoDisplay *)playerVideoDisplay didLoadPlayerItem:(AVPlayerItem *)playerItem;
		[Export("playerVideoDisplay:didLoadPlayerItem:")]
		void DidLoadPlayerItem(IMAAVPlayerVideoDisplay playerVideoDisplay, AVPlayerItem playerItem);
	}

	// @interface IMAAVPlayerVideoDisplay : NSObject <IMAVideoDisplay>
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAVPlayerVideoDisplay : IMAVideoDisplay
	{
		// @property (readonly, nonatomic, strong) AVPlayer * player __attribute__((deprecated("Use the player passed into initWithAVPlayer: instead.")));
		[Export("player", ArgumentSemantic.Strong)]
		AVPlayer Player { get; }

		// @property (readonly, nonatomic, strong) AVPlayerItem * playerItem __attribute__((deprecated("Use playerVideoDisplay:didLoadPlayerItem: instead.")));
		[Export("playerItem", ArgumentSemantic.Strong)]
		AVPlayerItem PlayerItem { get; }

		[Wrap("WeakPlayerVideoDisplayDelegate")]
		IMAAVPlayerVideoDisplayDelegate PlayerVideoDisplayDelegate { get; set; }

		// @property (nonatomic, weak) id<IMAAVPlayerVideoDisplayDelegate> playerVideoDisplayDelegate;
		[NullAllowed, Export("playerVideoDisplayDelegate", ArgumentSemantic.Weak)]
		NSObject WeakPlayerVideoDisplayDelegate { get; set; }

		// @property (readonly, nonatomic, strong) NSArray * subtitles;
		[Export("subtitles", ArgumentSemantic.Strong)]
		NSObject[] Subtitles { get; }

		// -(instancetype)initWithAVPlayer:(AVPlayer *)player;
		[Export("initWithAVPlayer:")]
		IntPtr Constructor(AVPlayer player);
	}

	// @interface IMAAdPodInfo : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdPodInfo
	{
		// @property (readonly, nonatomic) NSInteger totalAds;
		[Export("totalAds")]
		nint TotalAds { get; }

		// @property (readonly, nonatomic) NSInteger adPosition;
		[Export("adPosition")]
		nint AdPosition { get; }

		// @property (readonly, nonatomic) BOOL isBumper;
		[Export("isBumper")]
		bool IsBumper { get; }

		// @property (readonly, nonatomic) NSInteger podIndex;
		[Export("podIndex")]
		nint PodIndex { get; }

		// @property (readonly, nonatomic) NSTimeInterval timeOffset;
		[Export("timeOffset")]
		double TimeOffset { get; }

		// @property (readonly, nonatomic) NSTimeInterval maxDuration;
		[Export("maxDuration")]
		double MaxDuration { get; }
	}

	// @interface IMACompanionAd : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMACompanionAd
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable resourceValue;
		[NullAllowed, Export("resourceValue")]
		string ResourceValue { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable APIFramework;
		[NullAllowed, Export("APIFramework")]
		string APIFramework { get; }

		// @property (readonly, nonatomic) NSInteger width;
		[Export("width")]
		nint Width { get; }

		// @property (readonly, nonatomic) NSInteger height;
		[Export("height")]
		nint Height { get; }
	}

	// @interface IMAUniversalAdID : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAUniversalAdID
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull adIDValue;
		[Export("adIDValue")]
		string AdIDValue { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull adIDRegistry;
		[Export("adIDRegistry")]
		string AdIDRegistry { get; }
	}

	// @interface IMAAd : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAd
	{
		// @property (readonly, copy, nonatomic) NSString * adId;
		[Export("adId")]
		string AdId { get; }

		// @property (readonly, copy, nonatomic) NSString * adTitle;
		[Export("adTitle")]
		string AdTitle { get; }

		// @property (readonly, copy, nonatomic) NSString * adDescription;
		[Export("adDescription")]
		string AdDescription { get; }

		// @property (readonly, copy, nonatomic) NSString * adSystem;
		[Export("adSystem")]
		string AdSystem { get; }

		// @property (readonly, copy, nonatomic) NSArray<IMACompanionAd *> * companionAds;
		[Export("companionAds", ArgumentSemantic.Copy)]
		IMACompanionAd[] CompanionAds { get; }

		// @property (readonly, copy, nonatomic) NSString * contentType;
		[Export("contentType")]
		string ContentType { get; }

		// @property (readonly, nonatomic) NSTimeInterval duration;
		[Export("duration")]
		double Duration { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * uiElements;
		[Export("uiElements", ArgumentSemantic.Copy)]
		NSNumber[] UiElements { get; }

		// @property (readonly, getter = isUiDisabled, nonatomic) BOOL uiDisabled;
		[Export("uiDisabled")]
		bool UiDisabled { [Bind("isUiDisabled")] get; }

		// @property (readonly, nonatomic) NSInteger width;
		[Export("width")]
		nint Width { get; }

		// @property (readonly, nonatomic) NSInteger height;
		[Export("height")]
		nint Height { get; }

		// @property (readonly, nonatomic) NSInteger VASTMediaWidth;
		[Export("VASTMediaWidth")]
		nint VASTMediaWidth { get; }

		// @property (readonly, nonatomic) NSInteger VASTMediaHeight;
		[Export("VASTMediaHeight")]
		nint VASTMediaHeight { get; }

		// @property (readonly, nonatomic) NSInteger VASTMediaBitrate;
		[Export("VASTMediaBitrate")]
		nint VASTMediaBitrate { get; }

		// @property (readonly, getter = isLinear, nonatomic) BOOL linear;
		[Export("linear")]
		bool Linear { [Bind("isLinear")] get; }

		// @property (readonly, getter = isSkippable, nonatomic) BOOL skippable;
		[Export("skippable")]
		bool Skippable { [Bind("isSkippable")] get; }

		// @property (readonly, nonatomic) NSTimeInterval skipTimeOffset;
		[Export("skipTimeOffset")]
		double SkipTimeOffset { get; }

		// @property (readonly, nonatomic, strong) IMAAdPodInfo * adPodInfo;
		[Export("adPodInfo", ArgumentSemantic.Strong)]
		IMAAdPodInfo AdPodInfo { get; }

		// @property (readonly, copy, nonatomic) NSString * traffickingParameters;
		[Export("traffickingParameters")]
		string TraffickingParameters { get; }

		// @property (readonly, copy, nonatomic) NSString * creativeID;
		[Export("creativeID")]
		string CreativeID { get; }

		// @property (readonly, copy, nonatomic) NSString * creativeAdID;
		[Export("creativeAdID")]
		string CreativeAdID { get; }

		// @property (readonly, copy, nonatomic) NSArray<IMAUniversalAdID *> * universalAdIDs;
		[Export("universalAdIDs", ArgumentSemantic.Copy)]
		IMAUniversalAdID[] UniversalAdIDs { get; }

		// @property (readonly, copy, nonatomic) NSString * universalAdIdValue __attribute__((deprecated("Use universalAdIDs instead.")));
		[Export("universalAdIdValue")]
		string UniversalAdIdValue { get; }

		// @property (readonly, copy, nonatomic) NSString * universalAdIdRegistry __attribute__((deprecated("Use universalAdIDs instead.")));
		[Export("universalAdIdRegistry")]
		string UniversalAdIdRegistry { get; }

		// @property (readonly, copy, nonatomic) NSString * advertiserName;
		[Export("advertiserName")]
		string AdvertiserName { get; }

		// @property (readonly, copy, nonatomic) NSString * surveyURL;
		[Export("surveyURL")]
		string SurveyURL { get; }

		// @property (readonly, copy, nonatomic) NSString * dealID;
		[Export("dealID")]
		string DealID { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * wrapperAdIDs;
		[Export("wrapperAdIDs", ArgumentSemantic.Copy)]
		string[] WrapperAdIDs { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * wrapperCreativeIDs;
		[Export("wrapperCreativeIDs", ArgumentSemantic.Copy)]
		string[] WrapperCreativeIDs { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * wrapperSystems;
		[Export("wrapperSystems", ArgumentSemantic.Copy)]
		string[] WrapperSystems { get; }
	}

	// @interface IMAAdDisplayContainer : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdDisplayContainer
	{
		// @property (readonly, nonatomic) UIView * _Nonnull adContainer;
		[Export("adContainer")]
		UIView AdContainer { get; }

		// @property (nonatomic, weak) UIViewController * _Nullable adContainerViewController;
		[NullAllowed, Export("adContainerViewController", ArgumentSemantic.Weak)]
		UIViewController AdContainerViewController { get; set; }

		//// @property (readonly, nonatomic) id<UIFocusEnvironment> _Nullable focusEnvironment;
		//[NullAllowed, Export("focusEnvironment")]
		//UIFocusEnvironment FocusEnvironment { get; }

		// @property (readonly, nonatomic) NSArray<IMACompanionAdSlot *> * _Nullable companionSlots;
		[NullAllowed, Export("companionSlots")]
		IMACompanionAdSlot[] CompanionSlots { get; }

		[Export("initWithAdContainer:")]
		IntPtr Constructor(UIView adContainer);

		// -(instancetype _Nonnull)initWithAdContainer:(UIView * _Nonnull)adContainer viewController:(UIViewController * _Nullable)adContainerViewController;
		[Export("initWithAdContainer:viewController:")]
		IntPtr Constructor(UIView adContainer, [NullAllowed] UIViewController adContainerViewController);

		// -(instancetype _Nonnull)initWithAdContainer:(UIView * _Nonnull)adContainer viewController:(UIViewController * _Nullable)adContainerViewController companionSlots:(NSArray<IMACompanionAdSlot *> * _Nullable)companionSlots;
		[Export("initWithAdContainer:viewController:companionSlots:")]
		IntPtr Constructor(UIView adContainer, [NullAllowed] UIViewController adContainerViewController, [NullAllowed] IMACompanionAdSlot[] companionSlots);

		// -(void)registerFriendlyObstruction:(IMAFriendlyObstruction * _Nonnull)friendlyObstruction;
		[Export("registerFriendlyObstruction:")]
		void RegisterFriendlyObstruction(IMAFriendlyObstruction friendlyObstruction);

		// -(void)unregisterAllFriendlyObstructions;
		[Export("unregisterAllFriendlyObstructions")]
		void UnregisterAllFriendlyObstructions();

		// -(void)registerVideoControlsOverlay:(UIView * _Nonnull)videoControlsOverlay __attribute__((deprecated("Use registerFriendlyObstruction: instead.")));
		[Export("registerVideoControlsOverlay:")]
		void RegisterVideoControlsOverlay(UIView videoControlsOverlay);

		// -(void)unregisterAllVideoControlsOverlays __attribute__((deprecated("Use unregisterAllFriendlyObstructions: instead.")));
		[Export("unregisterAllVideoControlsOverlays")]
		void UnregisterAllVideoControlsOverlays();
	}

	// @interface IMAAdError : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdError
	{
		// @property (readonly, nonatomic) IMAErrorType type;
		[Export("type")]
		IMAErrorType Type { get; }

		// @property (readonly, nonatomic) IMAErrorCode code;
		[Export("code")]
		IMAErrorCode Code { get; }

		// @property (readonly, copy, nonatomic) NSString * message;
		[Export("message")]
		string Message { get; }
	}

	[Static]
	partial interface IMAAdBreakTimeConstants
	{
		// extern NSString *const kIMAAdBreakTime;
		[Field("kIMAAdBreakTime", "__Internal")]
		NSString kIMAAdBreakTime { get; }
	}

	// @interface IMAAdEvent : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdEvent
	{
		// @property (readonly, nonatomic) IMAAdEventType type;
		[Export("type")]
		IMAAdEventType Type { get; }

		// @property (readonly, copy, nonatomic) NSString * typeString;
		[Export("typeString")]
		string TypeString { get; }

		// @property (readonly, nonatomic, strong) IMAAd * ad;
		[Export("ad", ArgumentSemantic.Strong)]
		IMAAd Ad { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * adData;
		[Export("adData", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AdData { get; }
	}

	// @interface IMAAdsLoadedData : NSObject
	[BaseType(typeof(NSObject))]
	interface IMAAdsLoadedData
	{
		// @property (readonly, nonatomic, strong) IMAAdsManager * adsManager;
		[Export("adsManager", ArgumentSemantic.Strong)]
		IMAAdsManager AdsManager { get; }

		// @property (readonly, nonatomic, strong) IMAStreamManager * streamManager;
		[Export("streamManager", ArgumentSemantic.Strong)]
		IMAStreamManager StreamManager { get; }

		// @property (readonly, nonatomic, strong) id userContext;
		[Export("userContext", ArgumentSemantic.Strong)]
		NSObject UserContext { get; }
	}

	// @interface IMAAdLoadingErrorData : NSObject
	[BaseType(typeof(NSObject))]
	interface IMAAdLoadingErrorData
	{
		// @property (readonly, nonatomic, strong) IMAAdError * adError;
		[Export("adError", ArgumentSemantic.Strong)]
		IMAAdError AdError { get; }

		// @property (readonly, nonatomic, strong) id userContext;
		[Export("userContext", ArgumentSemantic.Strong)]
		NSObject UserContext { get; }
	}

	partial interface IIMAAdsLoaderDelegate { }
	// @protocol IMAAdsLoaderDelegate
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAAdsLoaderDelegate
	{
		// @required -(void)adsLoader:(IMAAdsLoader *)loader adsLoadedWithData:(IMAAdsLoadedData *)adsLoadedData;
		[Abstract]
		[Export("adsLoader:adsLoadedWithData:")]
		void AdsLoadedWithData(IMAAdsLoader loader, IMAAdsLoadedData adsLoadedData);

		// @required -(void)adsLoader:(IMAAdsLoader *)loader failedWithErrorData:(IMAAdLoadingErrorData *)adErrorData;
		[Abstract]
		[Export("adsLoader:failedWithErrorData:")]
		void FailedWithErrorData(IMAAdsLoader loader, IMAAdLoadingErrorData adErrorData);
	}

	// @interface IMAAdsLoader : NSObject
	[BaseType(typeof(NSObject))]
	interface IMAAdsLoader
	{
		// @property (readonly, copy, nonatomic) IMASettings * settings;
		[Export("settings", ArgumentSemantic.Copy)]
		IMASettings Settings { get; }

		[Wrap("WeakDelegate")]
		IIMAAdsLoaderDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<IMAAdsLoaderDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// +(NSString *)sdkVersion;
		[Static]
		[Export("sdkVersion")]
		string SdkVersion { get; }

		// -(instancetype)initWithSettings:(IMASettings *)settings;
		[Export("initWithSettings:")]
		IntPtr Constructor(IMASettings settings);

		// -(void)requestAdsWithRequest:(IMAAdsRequest *)request;
		[Export("requestAdsWithRequest:")]
		void RequestAdsWithRequest(IMAAdsRequest request);

		// -(void)requestStreamWithRequest:(IMAStreamRequest *)request;
		[Export("requestStreamWithRequest:")]
		void RequestStreamWithRequest(IMAStreamRequest request);

		// -(void)contentComplete;
		[Export("contentComplete")]
		void ContentComplete();
	}

	partial interface IIMAAdsManagerDelegate { }
	// @protocol IMAAdsManagerDelegate
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAAdsManagerDelegate
	{
		// @required -(void)adsManager:(IMAAdsManager *)adsManager didReceiveAdEvent:(IMAAdEvent *)event;
		[Abstract]
		[Export("adsManager:didReceiveAdEvent:")]
		void AdsManager(IMAAdsManager adsManager, IMAAdEvent @event);

		// @required -(void)adsManager:(IMAAdsManager *)adsManager didReceiveAdError:(IMAAdError *)error;
		[Abstract]
		[Export("adsManager:didReceiveAdError:")]
		void AdsManager(IMAAdsManager adsManager, IMAAdError error);

		// @required -(void)adsManagerDidRequestContentPause:(IMAAdsManager *)adsManager;
		[Abstract]
		[Export("adsManagerDidRequestContentPause:")]
		void AdsManagerDidRequestContentPause(IMAAdsManager adsManager);

		// @required -(void)adsManagerDidRequestContentResume:(IMAAdsManager *)adsManager;
		[Abstract]
		[Export("adsManagerDidRequestContentResume:")]
		void AdsManagerDidRequestContentResume(IMAAdsManager adsManager);

		// @optional -(void)adsManager:(IMAAdsManager *)adsManager adDidProgressToTime:(NSTimeInterval)mediaTime totalTime:(NSTimeInterval)totalTime;
		[Export("adsManager:adDidProgressToTime:totalTime:")]
		void AdsManager(IMAAdsManager adsManager, double mediaTime, double totalTime);

		// @optional -(void)adsManagerAdPlaybackReady:(IMAAdsManager *)adsManager;
		[Export("adsManagerAdPlaybackReady:")]
		void AdsManagerAdPlaybackReady(IMAAdsManager adsManager);

		// @optional -(void)adsManagerAdDidStartBuffering:(IMAAdsManager *)adsManager;
		[Export("adsManagerAdDidStartBuffering:")]
		void AdsManagerAdDidStartBuffering(IMAAdsManager adsManager);

		// @optional -(void)adsManager:(IMAAdsManager *)adsManager adDidBufferToMediaTime:(NSTimeInterval)mediaTime;
		[Export("adsManager:adDidBufferToMediaTime:")]
		void AdsManager(IMAAdsManager adsManager, double mediaTime);
	}

	// @interface IMAAdsManager : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdsManager
	{
		[Wrap("WeakDelegate")]
		IIMAAdsManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) NSObject<IMAAdsManagerDelegate> * delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSArray * adCuePoints;
		[Export("adCuePoints", ArgumentSemantic.Copy)]
		NSObject[] AdCuePoints { get; }

		// @property (readonly, nonatomic, strong) id<IMAAdPlaybackInfo> adPlaybackInfo;
		[Export("adPlaybackInfo", ArgumentSemantic.Strong)]
		IMAAdPlaybackInfo AdPlaybackInfo { get; }

		// @property (assign, nonatomic) float volume;
		[Export("volume")]
		float Volume { get; set; }

		// -(void)initializeWithAdsRenderingSettings:(IMAAdsRenderingSettings *)adsRenderingSettings;
		[Export("initializeWithAdsRenderingSettings:")]
		void InitializeWithAdsRenderingSettings(IMAAdsRenderingSettings adsRenderingSettings);

		// -(void)start;
		[Export("start")]
		void Start();

		// -(void)pause;
		[Export("pause")]
		void Pause();

		// -(void)resume;
		[Export("resume")]
		void Resume();

		// -(void)skip;
		[Export("skip")]
		void Skip();

		// -(void)clicked;
		[Export("clicked")]
		void Clicked();

		// -(void)destroy;
		[Export("destroy")]
		void Destroy();

		// -(void)discardAdBreak;
		[Export("discardAdBreak")]
		void DiscardAdBreak();
	}

	[Static]
	partial interface IMAAutodetectConstants
	{
		// extern const NSInteger kIMAAutodetectBitrate;
		[Field("kIMAAutodetectBitrate", "__Internal")]
		nint kIMAAutodetectBitrate { get; }
	}

	// @protocol IMAWebOpenerDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAWebOpenerDelegate
	{
		// @optional -(void)webOpenerWillOpenExternalBrowser:(NSObject *)webOpener;
		[Export("webOpenerWillOpenExternalBrowser:")]
		void WebOpenerWillOpenExternalBrowser(NSObject webOpener);

		// @optional -(void)webOpenerWillOpenInAppBrowser:(NSObject *)webOpener;
		[Export("webOpenerWillOpenInAppBrowser:")]
		void WebOpenerWillOpenInAppBrowser(NSObject webOpener);

		// @optional -(void)webOpenerDidOpenInAppBrowser:(NSObject *)webOpener;
		[Export("webOpenerDidOpenInAppBrowser:")]
		void WebOpenerDidOpenInAppBrowser(NSObject webOpener);

		// @optional -(void)webOpenerWillCloseInAppBrowser:(NSObject *)webOpener;
		[Export("webOpenerWillCloseInAppBrowser:")]
		void WebOpenerWillCloseInAppBrowser(NSObject webOpener);

		// @optional -(void)webOpenerDidCloseInAppBrowser:(NSObject *)webOpener;
		[Export("webOpenerDidCloseInAppBrowser:")]
		void WebOpenerDidCloseInAppBrowser(NSObject webOpener);
	}

	// @interface IMAAdsRenderingSettings : NSObject
	[BaseType(typeof(NSObject))]
	interface IMAAdsRenderingSettings
	{
		// @property (copy, nonatomic) NSArray<NSString *> * mimeTypes;
		[Export("mimeTypes", ArgumentSemantic.Copy)]
		string[] MimeTypes { get; set; }

		// @property (nonatomic) NSInteger bitrate;
		[Export("bitrate")]
		nint Bitrate { get; set; }

		// @property (nonatomic) NSTimeInterval loadVideoTimeout;
		[Export("loadVideoTimeout")]
		double LoadVideoTimeout { get; set; }

		// @property (nonatomic) NSTimeInterval playAdsAfterTime;
		[Export("playAdsAfterTime")]
		double PlayAdsAfterTime { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * uiElements;
		[Export("uiElements", ArgumentSemantic.Copy)]
		NSNumber[] UiElements { get; set; }

		// @property (nonatomic) BOOL disableUi;
		[Export("disableUi")]
		bool DisableUi { get; set; }

		// @property (nonatomic) BOOL enablePreloading;
		[Export("enablePreloading")]
		bool EnablePreloading { get; set; }

		// @property (nonatomic, weak) UIViewController * webOpenerPresentingController;
		[Export("webOpenerPresentingController", ArgumentSemantic.Weak)]
		UIViewController WebOpenerPresentingController { get; set; }

		[Wrap("WeakWebOpenerDelegate")]
		IMAWebOpenerDelegate WebOpenerDelegate { get; set; }

		// @property (nonatomic, weak) id<IMAWebOpenerDelegate> webOpenerDelegate;
		[NullAllowed, Export("webOpenerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakWebOpenerDelegate { get; set; }
	}

	// @interface IMAAdsRequest : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAAdsRequest
	{
		// @property (readonly, copy, nonatomic) NSString * adTagUrl;
		[Export("adTagUrl")]
		string AdTagUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * adsResponse;
		[Export("adsResponse")]
		string AdsResponse { get; }

		// @property (readonly, nonatomic, strong) IMAAdDisplayContainer * adDisplayContainer;
		[Export("adDisplayContainer", ArgumentSemantic.Strong)]
		IMAAdDisplayContainer AdDisplayContainer { get; }

		// @property (readonly, nonatomic, strong) id userContext;
		[Export("userContext", ArgumentSemantic.Strong)]
		NSObject UserContext { get; }

		// @property (nonatomic) BOOL adWillAutoPlay;
		[Export("adWillAutoPlay")]
		bool AdWillAutoPlay { get; set; }

		// @property (nonatomic) BOOL adWillPlayMuted;
		[Export("adWillPlayMuted")]
		bool AdWillPlayMuted { get; set; }

		// @property (nonatomic) BOOL continuousPlayback;
		[Export("continuousPlayback")]
		bool ContinuousPlayback { get; set; }

		// @property (nonatomic) float contentDuration;
		[Export("contentDuration")]
		float ContentDuration { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * contentKeywords;
		[Export("contentKeywords", ArgumentSemantic.Copy)]
		string[] ContentKeywords { get; set; }

		// @property (copy, nonatomic) NSString * contentTitle;
		[Export("contentTitle")]
		string ContentTitle { get; set; }

		// @property (copy, nonatomic) NSURL * contentURL;
		[Export("contentURL", ArgumentSemantic.Copy)]
		NSUrl ContentURL { get; set; }

		// @property (nonatomic) float vastLoadTimeout;
		[Export("vastLoadTimeout")]
		float VastLoadTimeout { get; set; }

		// @property (nonatomic) float liveStreamPrefetchSeconds;
		[Export("liveStreamPrefetchSeconds")]
		float LiveStreamPrefetchSeconds { get; set; }

		// -(instancetype)initWithAdsResponse:(NSString *)adsResponse adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer avPlayerVideoDisplay:(IMAAVPlayerVideoDisplay *)avPlayerVideoDisplay pictureInPictureProxy:(IMAPictureInPictureProxy *)pictureInPictureProxy userContext:(id)userContext __attribute__((availability(tvos, unavailable)));
		[NoTV]
		[Export("initWithAdsResponse:adDisplayContainer:avPlayerVideoDisplay:pictureInPictureProxy:userContext:")]
		IntPtr Constructor(string adsResponse, IMAAdDisplayContainer adDisplayContainer, IMAAVPlayerVideoDisplay avPlayerVideoDisplay, IMAPictureInPictureProxy pictureInPictureProxy, NSObject userContext);

		// -(instancetype)initWithAdsResponse:(NSString *)adsResponse adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer contentPlayhead:(NSObject<IMAContentPlayhead> *)contentPlayhead userContext:(id)userContext __attribute__((objc_designated_initializer));
		[Export("initWithAdsResponse:adDisplayContainer:contentPlayhead:userContext:")]
		[DesignatedInitializer]
		IntPtr Constructor(string adsResponse, IMAAdDisplayContainer adDisplayContainer, IMAContentPlayhead contentPlayhead, NSObject userContext);

        //// -(instancetype)initWithAdTagUrl:(NSString *)adTagUrl adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer avPlayerVideoDisplay:(IMAAVPlayerVideoDisplay *)avPlayerVideoDisplay pictureInPictureProxy:(IMAPictureInPictureProxy *)pictureInPictureProxy userContext:(id)userContext __attribute__((availability(tvos, unavailable)));
        //[NoTV]
        //[Export("initWithAdTagUrl:adDisplayContainer:avPlayerVideoDisplay:pictureInPictureProxy:userContext:")]
        //IntPtr Constructor(string adTagUrl, IMAAdDisplayContainer adDisplayContainer, IMAAVPlayerVideoDisplay avPlayerVideoDisplay, IMAPictureInPictureProxy pictureInPictureProxy, NSObject userContext);

        // -(instancetype)initWithAdTagUrl:(NSString *)adTagUrl adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer contentPlayhead:(NSObject<IMAContentPlayhead> *)contentPlayhead userContext:(id)userContext __attribute__((objc_designated_initializer));
        [Export("initWithAdTagUrl:adDisplayContainer:contentPlayhead:userContext:")]
        [DesignatedInitializer]
        IntPtr Constructor(string adTagUrl, IMAAdDisplayContainer adDisplayContainer, IMAAVPlayerContentPlayhead contentPlayhead, NSObject userContext);
    }

	// @protocol IMACompanionDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMACompanionDelegate
	{
		// @optional -(void)companionSlot:(IMACompanionAdSlot *)slot filled:(BOOL)filled;
		[Export("companionSlot:filled:")]
		void CompanionSlot(IMACompanionAdSlot slot, bool filled);

		// @optional -(void)companionSlotWasClicked:(IMACompanionAdSlot *)slot;
		[Export("companionSlotWasClicked:")]
		void CompanionSlotWasClicked(IMACompanionAdSlot slot);
	}

	// @interface IMACompanionAdSlot : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMACompanionAdSlot
	{
		// @property (readonly, nonatomic, strong) UIView * view;
		[Export("view", ArgumentSemantic.Strong)]
		UIView View { get; }

		// @property (readonly, nonatomic) NSInteger width;
		[Export("width")]
		nint Width { get; }

		// @property (readonly, nonatomic) NSInteger height;
		[Export("height")]
		nint Height { get; }

		[Wrap("WeakDelegate")]
		IMACompanionDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<IMACompanionDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype)initWithView:(UIView *)view width:(NSInteger)width height:(NSInteger)height __attribute__((availability(tvos, unavailable)));
		[NoTV]
		[Export("initWithView:width:height:")]
		IntPtr Constructor(UIView view, nint width, nint height);
	}

	// @interface IMACuepoint : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMACuepoint
	{
		// @property (readonly, nonatomic) NSTimeInterval startTime;
		[Export("startTime")]
		double StartTime { get; }

		// @property (readonly, nonatomic) NSTimeInterval endTime;
		[Export("endTime")]
		double EndTime { get; }

		// @property (readonly, getter = isPlayed, nonatomic) BOOL played;
		[Export("played")]
		bool Played { [Bind("isPlayed")] get; }
	}

	// @interface IMAFriendlyObstruction : NSObject
	[BaseType(typeof(NSObject))]
	interface IMAFriendlyObstruction
	{
		// @property (readonly, nonatomic) UIView * _Nonnull view;
		[Export("view")]
		UIView View { get; }

		// @property (readonly, nonatomic) IMAFriendlyObstructionPurpose purpose;
		[Export("purpose")]
		IMAFriendlyObstructionPurpose Purpose { get; }

		// @property (readonly, nonatomic) NSString * _Nullable detailedReason;
		[NullAllowed, Export("detailedReason")]
		string DetailedReason { get; }

		// -(instancetype _Nonnull)initWithView:(UIView * _Nonnull)view purpose:(IMAFriendlyObstructionPurpose)purpose detailedReason:(NSString * _Nullable)detailedReason;
		[Export("initWithView:purpose:detailedReason:")]
		IntPtr Constructor(UIView view, IMAFriendlyObstructionPurpose purpose, [NullAllowed] string detailedReason);
	}

	// @interface IMAStreamRequest : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAStreamRequest
	{
		// @property (readonly, nonatomic, strong) IMAAdDisplayContainer * adDisplayContainer;
		[Export("adDisplayContainer", ArgumentSemantic.Strong)]
		IMAAdDisplayContainer AdDisplayContainer { get; }

		// @property (readonly, nonatomic, strong) id<IMAVideoDisplay> videoDisplay;
		[Export("videoDisplay", ArgumentSemantic.Strong)]
		IMAVideoDisplay VideoDisplay { get; }

		// @property (copy, nonatomic) NSString * apiKey;
		[Export("apiKey")]
		string ApiKey { get; set; }

		// @property (copy, nonatomic) NSString * authToken;
		[Export("authToken")]
		string AuthToken { get; set; }

		// @property (copy, nonatomic) NSString * streamActivityMonitorID;
		[Export("streamActivityMonitorID")]
		string StreamActivityMonitorID { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * adTagParameters;
		[Export("adTagParameters", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> AdTagParameters { get; set; }

		// @property (copy, nonatomic) NSString * manifestURLSuffix;
		[Export("manifestURLSuffix")]
		string ManifestURLSuffix { get; set; }

		// @property (copy, nonatomic) NSURL * contentURL;
		[Export("contentURL", ArgumentSemantic.Copy)]
		NSUrl ContentURL { get; set; }
	}

	// @interface IMAPictureInPictureProxy : NSProxy <AVPictureInPictureControllerDelegate, AVPlayerViewControllerDelegate>
	[BaseType(typeof(NSObject))]
	interface IMAPictureInPictureProxy : IAVPictureInPictureControllerDelegate, IAVPlayerViewControllerDelegate
	{
		// @property (readonly, getter = isPictureInPictureActive, nonatomic) BOOL pictureInPictureActive;
		[Export("pictureInPictureActive")]
		bool PictureInPictureActive { [Bind("isPictureInPictureActive")] get; }

		// +(BOOL)isPictureInPictureSupported;
		[Static]
		[Export("isPictureInPictureSupported")]
		bool IsPictureInPictureSupported { get; }

		// -(instancetype)initWithAVPictureInPictureControllerDelegate:(id<AVPictureInPictureControllerDelegate>)delegate __attribute__((availability(tvos, unavailable)));
		[NoTV]
		[Export("initWithAVPictureInPictureControllerDelegate:")]
		IntPtr Constructor(AVPictureInPictureControllerDelegate @delegate);

		// -(instancetype)initWithAVPlayerViewControllerDelegate:(id<AVPlayerViewControllerDelegate>)delegate __attribute__((availability(tvos, unavailable)));
		[NoTV]
		[Export("initWithAVPlayerViewControllerDelegate:")]
		IntPtr Constructor(AVPlayerViewControllerDelegate @delegate);
	}

	// @interface IMALiveStreamRequest : IMAStreamRequest
	[BaseType(typeof(IMAStreamRequest))]
	[DisableDefaultCtor]
	interface IMALiveStreamRequest
	{
		// @property (readonly, copy, nonatomic) NSString * assetKey;
		[Export("assetKey")]
		string AssetKey { get; }

		// -(instancetype)initWithAssetKey:(NSString *)assetKey adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer videoDisplay:(id<IMAVideoDisplay>)videoDisplay;
		[Export("initWithAssetKey:adDisplayContainer:videoDisplay:")]
		IntPtr Constructor(string assetKey, IMAAdDisplayContainer adDisplayContainer, IIMAVideoDisplay videoDisplay);

		// -(instancetype)initWithAssetKey:(NSString *)assetKey adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer videoDisplay:(id<IMAVideoDisplay>)videoDisplay pictureInPictureProxy:(IMAPictureInPictureProxy *)pictureInPictureProxy;
		[Export("initWithAssetKey:adDisplayContainer:videoDisplay:pictureInPictureProxy:")]
		IntPtr Constructor(string assetKey, IMAAdDisplayContainer adDisplayContainer, IIMAVideoDisplay videoDisplay, IMAPictureInPictureProxy pictureInPictureProxy);
	}

	// @interface IMASettings : NSObject <NSCopying>
	[BaseType(typeof(NSObject))]
	interface IMASettings : INSCopying
	{
		// @property (copy, nonatomic) NSString * ppid;
		[Export("ppid")]
		string Ppid { get; set; }

		// @property (copy, nonatomic) NSString * language;
		[Export("language")]
		string Language { get; set; }

		// @property (nonatomic) NSUInteger maxRedirects;
		[Export("maxRedirects")]
		nuint MaxRedirects { get; set; }

		// @property (nonatomic) BOOL enableBackgroundPlayback;
		[Export("enableBackgroundPlayback")]
		bool EnableBackgroundPlayback { get; set; }

		// @property (nonatomic) BOOL autoPlayAdBreaks;
		[Export("autoPlayAdBreaks")]
		bool AutoPlayAdBreaks { get; set; }

		// @property (nonatomic) BOOL disableNowPlayingInfo;
		[Export("disableNowPlayingInfo")]
		bool DisableNowPlayingInfo { get; set; }

		// @property (copy, nonatomic) NSString * playerType;
		[Export("playerType")]
		string PlayerType { get; set; }

		// @property (copy, nonatomic) NSString * playerVersion;
		[Export("playerVersion")]
		string PlayerVersion { get; set; }

		// @property (nonatomic) BOOL enableDebugMode;
		[Export("enableDebugMode")]
		bool EnableDebugMode { get; set; }
	}

	partial interface IIMAStreamManagerDelegate { }
	// @protocol IMAStreamManagerDelegate
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface IMAStreamManagerDelegate
	{
		// @required -(void)streamManager:(IMAStreamManager *)streamManager didReceiveAdEvent:(IMAAdEvent *)event;
		[Abstract]
		[Export("streamManager:didReceiveAdEvent:")]
		void DidReceiveAdEvent(IMAStreamManager streamManager, IMAAdEvent @event);

		// @required -(void)streamManager:(IMAStreamManager *)streamManager didReceiveAdError:(IMAAdError *)error;
		[Abstract]
		[Export("streamManager:didReceiveAdError:")]
		void DidReceiveAdError(IMAStreamManager streamManager, IMAAdError error);

		// @optional -(void)streamManager:(IMAStreamManager *)streamManager adDidProgressToTime:(NSTimeInterval)time adDuration:(NSTimeInterval)adDuration adPosition:(NSInteger)adPosition totalAds:(NSInteger)totalAds adBreakDuration:(NSTimeInterval)adBreakDuration;
		[Export("streamManager:adDidProgressToTime:adDuration:adPosition:totalAds:adBreakDuration:")]
		void AdDidProgressToTime(IMAStreamManager streamManager, double time, double adDuration, nint adPosition, nint totalAds, double adBreakDuration);
	}

	// @interface IMAStreamManager : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface IMAStreamManager
	{
		[Wrap("WeakDelegate")]
		IMAStreamManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) NSObject<IMAStreamManagerDelegate> * delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSString * streamId;
		[Export("streamId")]
		string StreamId { get; }

		// -(void)initializeWithAdsRenderingSettings:(IMAAdsRenderingSettings *)adsRenderingSettings;
		[Export("initializeWithAdsRenderingSettings:")]
		void InitializeWithAdsRenderingSettings(IMAAdsRenderingSettings adsRenderingSettings);

		// -(NSTimeInterval)streamTimeForContentTime:(NSTimeInterval)contentTime;
		[Export("streamTimeForContentTime:")]
		double StreamTimeForContentTime(double contentTime);

		// -(NSTimeInterval)contentTimeForStreamTime:(NSTimeInterval)streamTime;
		[Export("contentTimeForStreamTime:")]
		double ContentTimeForStreamTime(double streamTime);

		// -(IMACuepoint *)previousCuepointForStreamTime:(NSTimeInterval)streamTime;
		[Export("previousCuepointForStreamTime:")]
		IMACuepoint PreviousCuepointForStreamTime(double streamTime);

		// -(void)replaceAdTagParameters:(NSDictionary<NSString *,NSString *> *)adTagParameters;
		[Export("replaceAdTagParameters:")]
		void ReplaceAdTagParameters(NSDictionary<NSString, NSString> adTagParameters);

		// -(void)destroy;
		[Export("destroy")]
		void Destroy();
	}

	// @interface IMAVODStreamRequest : IMAStreamRequest
	[BaseType(typeof(IMAStreamRequest))]
	[DisableDefaultCtor]
	interface IMAVODStreamRequest
	{
		// @property (readonly, copy, nonatomic) NSString * contentSourceID;
		[Export("contentSourceID")]
		string ContentSourceID { get; }

		// @property (readonly, copy, nonatomic) NSString * videoID;
		[Export("videoID")]
		string VideoID { get; }

		// -(instancetype)initWithContentSourceID:(NSString *)contentSourceID videoID:(NSString *)videoID adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer videoDisplay:(id<IMAVideoDisplay>)videoDisplay;
		[Export("initWithContentSourceID:videoID:adDisplayContainer:videoDisplay:")]
		IntPtr Constructor(string contentSourceID, string videoID, IMAAdDisplayContainer adDisplayContainer, IMAVideoDisplay videoDisplay);

		// -(instancetype)initWithContentSourceID:(NSString *)contentSourceID videoID:(NSString *)videoID adDisplayContainer:(IMAAdDisplayContainer *)adDisplayContainer videoDisplay:(id<IMAVideoDisplay>)videoDisplay pictureInPictureProxy:(IMAPictureInPictureProxy *)pictureInPictureProxy;
		[Export("initWithContentSourceID:videoID:adDisplayContainer:videoDisplay:pictureInPictureProxy:")]
		IntPtr Constructor(string contentSourceID, string videoID, IMAAdDisplayContainer adDisplayContainer, IMAVideoDisplay videoDisplay, IMAPictureInPictureProxy pictureInPictureProxy);
	}
}