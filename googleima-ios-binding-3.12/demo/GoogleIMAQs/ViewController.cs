using System;
using GoogleIMA;
using AVFoundation;
using AVKit;
using UIKit;
using Foundation;

namespace GoogleIMAQs
{
    public partial class ViewController : UIViewController, IIMAAdsLoaderDelegate, IIMAAdsManagerDelegate
    {
        IMAAVPlayerContentPlayhead contentPlayhead;
        IMAAdsLoader adsLoader;
        IMAAdsManager adsManager;
        static string contentUrlString = "https://devstreaming-cdn.apple.com/videos/streaming/examples/img_bipbop_adv_example_fmp4/master.m3u8";
        //static string AdTagURLString = "https://pubads.g.doubleclick.net/gampad/ads?sz=640x480&iu=/124319096/external/single_ad_samples&ciu_szs=300x250&impl=s&gdfp_req=1&env=vp&output=vast&unviewed_position_start=1&cust_params=deployment%3Ddevsite%26sample_ct%3Dlinear&correlator=";

        //static string contentUrlString = "https://storage.googleapis.com/gvabox/media/samples/stock.mp4";
        static string AdTagURLString = "https://pubads.g.doubleclick.net/gampad/ads?sz=640x480&iu=/124319096/external/single_ad_samples&ciu_szs=300x250&impl=s&gdfp_req=1&env=vp&output=vast&unviewed_position_start=1&cust_params=deployment%3Ddevsite%26sample_ct%3Dlinear&correlator=";

        AVPlayerViewController aVPlayerViewController;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.


        }
        ~ViewController()
        {
            NSNotificationCenter.DefaultCenter.RemoveObserver(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            this.View.BackgroundColor = UIColor.Black;
            SetUpContentPlayer();
            SetUpAdsLoader();

        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            RequestAds();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void SetUpContentPlayer()
        {
            var contentURL = new Foundation.NSUrl(contentUrlString);
            AVPlayer player = new AVPlayer(contentURL);
            aVPlayerViewController = new AVPlayerViewController();
            aVPlayerViewController.Player = player;

            // Set up your content playhead and contentComplete callback.

            contentPlayhead = new IMAAVPlayerContentPlayhead(player);
            NSNotificationCenter.DefaultCenter.AddObserver(new NSString("AVPlayerItemDidPlayToEndTime"), ContentDidFinishPlaying);

            //NSNotificationCenter.DefaultCenter.AddObserver(this
            //    , new ObjCRuntime.Selector("ViewController.contentDidFinishPlaying(_:)")
            //    , new NSString("AVPlayerItemDidPlayToEndTime")
            //    , player.CurrentItem) ;



            //        contentPlayhead = IMAAVPlayerContentPlayhead(avPlayer: player)
            //NotificationCenter.default.addObserver(
            //  self,
            //  selector: #selector(ViewController.contentDidFinishPlaying(_:)),
            //  name: NSNotification.Name.AVPlayerItemDidPlayToEndTime,
            //  object: player.currentItem);


            ShowContentPlayer();
        }

        void ContentDidFinishPlaying(NSNotification notification)
        {
            adsLoader.ContentComplete();
        }

        void SetUpAdsLoader()
        {
            adsLoader = new IMAAdsLoader();
            adsLoader.Delegate = this;

        }

        void RequestAds()
        {

            // Create ad display container for ad rendering.
            var adDisplayContainer = new IMAAdDisplayContainer(this.View,this,null);
            // Create an ad request with our ad tag, display container, and optional user context.
            var request = new IMAAdsRequest(
                AdTagURLString,
                adDisplayContainer,
                contentPlayhead,
                new NSObject());

            adsLoader.RequestAdsWithRequest(request);
        }


        void ShowContentPlayer()
        {
            this.AddChildViewController(aVPlayerViewController);
            aVPlayerViewController.View.Frame = this.View.Bounds;
            this.View.InsertSubview(aVPlayerViewController.View, 0);
            aVPlayerViewController.DidMoveToParentViewController(this);

        }

        void HideContentPlayer()
        {
            // The whole controller needs to be detached so that it doesn't capture  events from the remote.
            aVPlayerViewController.WillMoveToParentViewController(null);
            aVPlayerViewController.View.RemoveFromSuperview();
            aVPlayerViewController.RemoveFromParentViewController();
        }

        public void AdsLoadedWithData(IMAAdsLoader loader, IMAAdsLoadedData adsLoadedData)
        {
            adsManager = adsLoadedData.AdsManager;
            adsManager.Delegate = this;

            IMAAdsRenderingSettings adsRenderingSettings = new IMAAdsRenderingSettings();
            adsRenderingSettings.WebOpenerPresentingController = this;
            adsManager.InitializeWithAdsRenderingSettings(adsRenderingSettings);
            //adsManager.Init();

        }

        public void FailedWithErrorData(IMAAdsLoader loader, IMAAdLoadingErrorData adErrorData)
        {
            Console.WriteLine("Error loading ads: " + adErrorData.AdError.Message);
            ShowContentPlayer();
            aVPlayerViewController.Player?.Play();

        }

        public void AdsManager(IMAAdsManager adsManager, IMAAdEvent @event)
        {
            if (@event.Type == IMAAdEventType.Loaded)
            {
                adsManager.Start();
            }
        }

        public void AdsManager(IMAAdsManager adsManager, IMAAdError error)
        {
            // Fall back to playing content
            Console.WriteLine("AdsManager error: " + error.Message);
            ShowContentPlayer();
            aVPlayerViewController.Player?.Play();

        }

        public void AdsManagerDidRequestContentPause(IMAAdsManager adsManager)
        {
            // Pause the content for the SDK to play ads.
            aVPlayerViewController.Player?.Pause();
            HideContentPlayer();

        }

        public void AdsManagerDidRequestContentResume(IMAAdsManager adsManager)
        {
            // Resume the content since the SDK is done playing ads (at least for now).
            ShowContentPlayer();
            aVPlayerViewController.Player?.Play();

        }
    }
}
