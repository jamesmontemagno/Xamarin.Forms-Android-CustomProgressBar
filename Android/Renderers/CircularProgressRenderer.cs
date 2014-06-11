using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using com.refractored.monodroidtoolkit;
using CustomProgressBar.Droid.Renderers;
using CustomProgressBar.CustomControls;

[assembly:ExportRenderer(typeof(CircularProgress), typeof(CircularProgressRenderer))]
namespace CustomProgressBar.Droid.Renderers
{
	public class CircularProgressRenderer : NativeRenderer
	{

		HoloCircularProgressBar progress;
		public CircularProgressRenderer ()
		{
		}

		protected override void OnModelChanged (VisualElement oldModel, VisualElement newModel)
		{
			base.OnModelChanged (oldModel, newModel);

			var model = this.Model as CircularProgress;
			if (model == null)
				return;

			progress = new HoloCircularProgressBar (Forms.Context) {
				Max = model.Max,
				Progress = model.Progress,
				Indeterminate = model.Indeterminate,
				ProgressColor = model.ProgressColor.ToAndroid(),
				ProgressBackgroundColor = model.ProgressBackgroundColor.ToAndroid(),
				IndeterminateInterval = model.IndeterminateSpeed
			};


			SetNativeControl (progress);
		}

		protected override void OnHandlePropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnHandlePropertyChanged (sender, e);

			if (progress == null)
				return;

			var model = this.Model as CircularProgress;
			if (model == null)
				return;

			if (e.PropertyName == CircularProgress.MaxProperty.PropertyName) {
				progress.Max = model.Max;
			} else if (e.PropertyName == CircularProgress.ProgressProperty.PropertyName) {
				progress.Progress = model.Progress;
			} else if (e.PropertyName == CircularProgress.IndeterminateProperty.PropertyName) {
				progress.Indeterminate = model.Indeterminate;
			}else if (e.PropertyName == CircularProgress.ProgressBackgroundColorProperty.PropertyName) {
				progress.ProgressBackgroundColor = model.ProgressBackgroundColor.ToAndroid ();
			}else if (e.PropertyName == CircularProgress.ProgressColorProperty.PropertyName) {
				progress.ProgressColor = model.ProgressColor.ToAndroid ();
			}else if (e.PropertyName == CircularProgress.IndeterminateSpeedProperty.PropertyName) {
				progress.IndeterminateInterval = model.IndeterminateSpeed;
			}

		}
	}
}

