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
	UILabel *_UITranscription;
	UILabel *_UIWord;
}

@property (nonatomic, retain) IBOutlet UIView *UIAnswerPlace;

@property (nonatomic, retain) IBOutlet UIButton *UIBtmExample;

@property (nonatomic, retain) IBOutlet UITextView *UIExampleText;

@property (nonatomic, retain) IBOutlet UILabel *UITranscription;

@property (nonatomic, retain) IBOutlet UILabel *UIWord;

- (IBAction)ShowExample:(UIButton *)sender;

- (IBAction)SpeakWord:(UIButton *)sender;

@end
