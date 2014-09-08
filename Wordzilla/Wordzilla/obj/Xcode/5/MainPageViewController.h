// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface MainPageViewController : UIViewController {
	UITextField *_UIGroupPass;
	UIButton *_UIOk;
	UIButton *_UISkip;
}

@property (nonatomic, retain) IBOutlet UITextField *UIGroupPass;

@property (nonatomic, retain) IBOutlet UIButton *UIOk;

@property (nonatomic, retain) IBOutlet UIButton *UISkip;

- (IBAction)NextPage:(UIButton *)sender;

@end
