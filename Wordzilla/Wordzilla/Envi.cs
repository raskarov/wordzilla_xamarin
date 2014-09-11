using System;
using MonoTouch.AVFoundation;
using MonoTouch.Foundation;

namespace Wordzilla
{
	public static class Envi
	{

		public static class Sounds
		{
			static string forvoApi = "";
			static AVAudioPlayer player;

			public static void PlaySound (string soundurl)
			{
				if (soundurl == string.Empty)
					return;

				if (player != null) {
					player.Stop ();
				}
				try {
					//var file = Path.Combine("sounds", filename);
					NSData data = NSData.FromUrl(NSUrl.FromString(soundurl));
					player = AVAudioPlayer.FromData (data);
					var onePlay = player;
					onePlay.CurrentTime = onePlay.Duration * 2;
					onePlay.NumberOfLoops = 1;
					onePlay.Volume = 1.0f;
					onePlay.FinishedPlaying += DidFinishPlaying;
					onePlay.PrepareToPlay ();
					onePlay.Play ();
				} catch (Exception e) {
					//LogLine ("PlaySound: Error: " + e.Message, true);
				}
			}

			public static void DidFinishPlaying (object sender, AVStatusEventArgs e)
			{
				if (e.Status) {
					// your code
				}

			}
		}
	}
}

