// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface TrainingViewController : UIViewController {
	UIButton *_UIAnswer;
	UIView *_UIAnswerPlace;
	UILabel *_UIRussian;
	UILabel *_UITranslate;
	UILabel *_UIWord;
}

@property (nonatomic, retain) IBOutlet UIButton *UIAnswer;

@property (nonatomic, retain) IBOutlet UIView *UIAnswerPlace;

@property (nonatomic, retain) IBOutlet UILabel *UIRussian;

@property (nonatomic, retain) IBOutlet UILabel *UITranslate;

@property (nonatomic, retain) IBOutlet UILabel *UIWord;

- (IBAction)AnswerTouch:(UIButton *)sender;

- (IBAction)SelectAnswerTouch:(UIButton *)sender;

@end
