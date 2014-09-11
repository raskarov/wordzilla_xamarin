// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface UIWordEdit : UITableViewCell {
	UIButton *_UIDelete;
	UIButton *_UIEdit;
	UILabel *_UIEnglish;
	UILabel *_UIExample;
	UILabel *_UIRussian;
	UILabel *_UITranscr;
	UIButton *_UIVoice;
}

@property (nonatomic, retain) IBOutlet UIButton *UIDelete;

@property (nonatomic, retain) IBOutlet UIButton *UIEdit;

@property (nonatomic, retain) IBOutlet UILabel *UIEnglish;

@property (nonatomic, retain) IBOutlet UILabel *UIExample;

@property (nonatomic, retain) IBOutlet UILabel *UIRussian;

@property (nonatomic, retain) IBOutlet UILabel *UITranscr;

@property (nonatomic, retain) IBOutlet UIButton *UIVoice;

- (IBAction)SpeakWord:(UIButton *)sender;

@end
