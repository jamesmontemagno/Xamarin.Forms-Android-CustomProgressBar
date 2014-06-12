using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using com.refractored.monodroidtoolkit;
using CustomProgressBar.Droid.Renderers;
using CustomProgressBar.CustomControls;

[assembly:ExportRenderer(typeof(CircularProgress), typeof(CircularProgressRenderer))]
namespace CustomProgressBar.Droid.Renderers
{
	public class CircularProgressRenderer : ViewRenderer
	{

		HoloCircularProgressBar progress;
		public CircularProgressRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged (e);
			var element = this.Element as CircularProgress;
			if (element == null)
				return;

			progress = new HoloCircularProgressBar (Forms.Context) {
				Max = element.Max,
				Progress = element.Progress,
				Indeterminate = element.Indeterminate,
				ProgressColor = element.ProgressColor.ToAndroid (),
				ProgressBackgroundColor = element.ProgressBackgroundColor.ToAndroid (),
				IndeterminateInterval = element.IndeterminateSpeed
			};


			SetNativeControl (progress);
		}


		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (progress == null)
				return;

			var element = this.Element as CircularProgress;
			if (element == null)
				return;

			if (e.PropertyName == CircularProgress.MaxProperty.PropertyName) {
				progress.Max = element.Max;
			} else if (e.PropertyName == CircularProgress.ProgressProperty.PropertyName) {
				progress.Progress = element.Progress;
			} else if (e.PropertyName == CircularProgress.IndeterminateProperty.PropertyName) {
				progress.Indeterminate = element.Indeterminate;
			}else if (e.PropertyName == CircularProgress.ProgressBackgroundColorProperty.PropertyName) {
				progress.ProgressBackgroundColor = element.ProgressBackgroundColor.ToAndroid ();
			}else if (e.PropertyName == CircularProgress.ProgressColorProperty.PropertyName) {
				progress.ProgressColor = element.ProgressColor.ToAndroid ();
			}else if (e.PropertyName == CircularProgress.IndeterminateSpeedProperty.PropertyName) {
				progress.IndeterminateInterval = element.IndeterminateSpeed;
			}

		}
	}
}

