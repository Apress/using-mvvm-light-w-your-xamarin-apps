using System;
using System.Collections.Generic;
using CoreGraphics;
using UIKit;

namespace TimeOfDeath.iOS
{
    public class PickerUI
    {
        public static UIView CreateDropList(UIView view, UIPickerView picker, UITextField txtField, List<string> param)
        {
            var choiceModel = new PickerModel((IList<string>)param);
            var imp = param[0];
            picker = new UIPickerView(new CGRect(0, 44, view.Bounds.Width, 216))
            {
                Model = choiceModel,
                BackgroundColor = UIColor.LightGray,
                ShowSelectionIndicator = true,
                Hidden = false,
                AutosizesSubviews = true,
            };

            var toolHigh = new UIToolbar
            {
                BarStyle = UIBarStyle.Black,
                Translucent = true,
                UserInteractionEnabled = true
            };
            toolHigh.SizeToFit();
            var doneHigh = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done,
                               (ss, ea) =>
                {
                    picker.ResignFirstResponder();
                    txtField.Text = imp;
                    txtField.ResignFirstResponder();
                });
            toolHigh.SetItems(new UIBarButtonItem[] { doneHigh }, true);

            var pickView = new UIView(new CGRect(0, 0, view.Bounds.Width, 260));
            pickView.AddSubviews(new UIView[] { picker, toolHigh });

            choiceModel.PickerChanged += (object sender, PickerChangedEventArgs ea) =>
            {
                imp = ea.SelectedValue;
            };
            return pickView;
        }
    }
}
