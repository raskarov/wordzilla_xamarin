// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface UIWordEdit : UITableViewCell {
	UITextView *_UIEnglish;
	UITextView *_UIMyCards;
	UITextView *_UIRussian;
	UITextView *_UITranscr;
    UITextView *_UIExample;
    UITextView *_UIDelete;
    UITextView *_UIVoice;
}

@property (nonatomic, retain) IBOutlet UITextView *UIEnglish;

@property (nonatomic, retain) IBOutlet UITextView *UIRussian;

@property (nonatomic, retain) IBOutlet UITextView *UITranscr;

@property (nonatomic, retain) IBOutlet UITextView *UIExample;

@property (nonatomic, retain) IBOutlet UIButton *UIDelete;

@property (nonatomic, retain) IBOutlet UIButton *UIVoice;

@end
