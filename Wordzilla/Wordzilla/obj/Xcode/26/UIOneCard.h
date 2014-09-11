// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface UIOneCard : UIView {
	UIButton *_UIBtmExample;
	UITextView *_UIExampleText;
	UIButton *_UITouchCard;
	UILabel *_UITranscription;
	UIButton *_UIVoice;
	UILabel *_UIWord;
}

@property (nonatomic, retain) IBOutlet UIButton *UIBtmExample;

@property (nonatomic, retain) IBOutlet UITextView *UIExampleText;

@property (nonatomic, retain) IBOutlet UIButton *UITouchCard;

@property (nonatomic, retain) IBOutlet UILabel *UITranscription;

@property (nonatomic, retain) IBOutlet UIButton *UIVoice;

@property (nonatomic, retain) IBOutlet UILabel *UIWord;

- (IBAction)SpeakWord:(UIButton *)sender;

- (IBAction)ShowExample:(UIButton *)sender;

@end
