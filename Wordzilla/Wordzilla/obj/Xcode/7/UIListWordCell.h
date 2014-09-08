// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface UIListWordCell : UITableViewCell {
	UILabel *_UIInfo;
	UILabel *_UITitle;
    
    UILabel *_UICustomProgress;
    UILabel *_UICustomRed;
    UILabel *_UICustomGreen;
    UILabel *_UICustomSilver;
    UILabel *_UICustomYellow;
    
    UIButton *_UIEdit;
    UIButton *_UITraining;

}

@property (nonatomic, retain) IBOutlet UILabel *UIInfo;

@property (nonatomic, retain) IBOutlet UILabel *UITitle;

@property (nonatomic, retain) IBOutlet UIView *UICustomProgress;
@property (nonatomic, retain) IBOutlet UIView *UICustomRed;
@property (nonatomic, retain) IBOutlet UIView *UICustomGreen;
@property (nonatomic, retain) IBOutlet UIView *UICustomSilver;
@property (nonatomic, retain) IBOutlet UIView *UICustomYellow;

@property (nonatomic, retain) IBOutlet UIButton *UIEdit;
@property (nonatomic, retain) IBOutlet UIButton *UITraining;

@end
