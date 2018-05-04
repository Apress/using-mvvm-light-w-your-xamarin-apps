using System;
using Android.Webkit;
namespace connectivity.Droid
{
    public partial class MainActivity
    {
        WebView webView;

        public WebView WebView => webView ?? (webView = FindViewById<WebView>(Resource.Id.webView));
    }
}
