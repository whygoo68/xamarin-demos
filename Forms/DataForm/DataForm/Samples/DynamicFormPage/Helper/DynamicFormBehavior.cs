#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SampleBrowser.Core;
using DataForm = Syncfusion.XForms.DataForm.SfDataForm;
using Syncfusion.XForms.DataForm;
using ComboBox = Syncfusion.XForms.ComboBox.SfComboBox;
using Syncfusion.XForms.ComboBox;
using SelectionChangedEventArgs = Syncfusion.XForms.ComboBox.SelectionChangedEventArgs;

namespace SampleBrowser.SfDataForm
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class DynamicFormBehavior : Behavior<SampleView>
    {
        /// <summary>
        /// DataForm control to edit the data fields of any data object
        /// </summary>
        DataForm dataForm;

        /// <summary>
        /// ComboBox control to choose the data forms to view.
        /// </summary>
        ComboBox sfComboBox;

        /// <summary>
        /// Attaches to the superclass and then calls the OnAttachedTo method on this object.
        /// </summary>
        /// <param name="bindable">The bindable object to which the behavior was attached.</param>
        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            sfComboBox = bindable.FindByName<ComboBox>("combo");
            sfComboBox.SelectionChanged += SfComboBox_SelectionChanged;
            sfComboBox.SelectedItem = "Organization Form";
            dataForm = bindable.FindByName<DataForm>("dataForm");
        }

        /// <summary>
        /// Occurs when selected item of the ComboBox is changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments of selectionchanged event.</param>
        private void SfComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Value.Equals("Organization Form"))
            {
                dataForm.ContainerBackgroundColor = Color.Default;
                dataForm.ContainerType = ContainerType.Outlined;
                dataForm.DataObject = new OrganizationForm();
                dataForm.ShowHelperText = true;
            }
            else if (e.Value.Equals("Employee Form"))
            {
                dataForm.ContainerBackgroundColor = Color.FromHex("#F3F7FF");
                dataForm.ContainerType = ContainerType.Outlined;
                dataForm.DataObject = new EmployeeForm();
                dataForm.ShowHelperText = false;
            }
            else
            {
                dataForm.ContainerBackgroundColor = Color.Default;
                dataForm.ContainerType = ContainerType.Filled;
                dataForm.DataObject = new Ecommerce();
                dataForm.ShowHelperText = true;
            }
        }

        /// <summary>
        /// Calls the OnDetachingFrom method and then detaches from the superclass.
        /// </summary>
        /// <param name="bindable">The bindable object from which the behavior was detached.</param>
        protected override void OnDetachingFrom(SampleView bindable)
        {
            base.OnDetachingFrom(bindable);
            sfComboBox.SelectionChanged -= SfComboBox_SelectionChanged;
            dataForm = null;
            sfComboBox = null;
        }
    }
}
