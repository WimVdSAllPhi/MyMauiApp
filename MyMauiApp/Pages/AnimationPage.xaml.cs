﻿namespace MyMauiApp.Pages;

public partial class AnimationPage : ContentPage
{
    #region Public Constructors

    public AnimationPage()
    {
        InitializeComponent();
    }

    #endregion Public Constructors

    #region Private Methods

    private void OnCancelAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce("Cancel animation");
        dotNetBotImage.CancelAnimations();
    }

    private async Task ResetProperties()
    {
        await Task.Delay(1000);
        dotNetBotImage.Rotation = 0;
        dotNetBotImage.Scale = 1;
        dotNetBotImage.TranslationX = 0;
        dotNetBotImage.TranslationY = 0;
        dotNetBotImage.Opacity = 1;
    }

    private async void OnFadeAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(AnimationLabel.Text);
        AnimationLabel.Text = "FadeTo";
        await dotNetBotImage.FadeTo(0, 500);
        await dotNetBotImage.FadeTo(1, 500);
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        ResetProperties();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    private async void OnRotateAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(AnimationLabel.Text);
        AnimationLabel.Text = "Rotate";
        await dotNetBotImage.RotateTo(360, 500);
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        ResetProperties();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    private async void OnScaleAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(AnimationLabel.Text);
        AnimationLabel.Text = "Scale";
        await dotNetBotImage.ScaleTo(2, 500);
        await dotNetBotImage.ScaleTo(1, 500);
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        ResetProperties();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    private async void OnTranslateAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(AnimationLabel.Text);
        AnimationLabel.Text = "Translate";
        await dotNetBotImage.TranslateTo(-200, 0, 500);
        await dotNetBotImage.TranslateTo(0, 0, 500);
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        ResetProperties();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    private async void OnCompositeAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(AnimationLabel.Text);
        AnimationLabel.Text = "Rotate and Scale";
        // Composite animation A composite animation is a combination of animations where two or
        // more animations run simultaneously. Composite animations can be created by combining
        // awaited and non-awaited animations: Set Rotation to 0, otherwise the second time this
        // animation runs, it won't rotate.
        dotNetBotImage.Rotation = 0;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        dotNetBotImage.RotateTo(360, 1000);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        await dotNetBotImage.ScaleTo(2, 500);
        await dotNetBotImage.ScaleTo(1, 500);
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        ResetProperties();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    private async void OnEasingBounceOutAnimationClicked(object sender, EventArgs e)
    {
        SemanticScreenReader.Announce(AnimationLabel.Text);
        AnimationLabel.Text = "Easing BounceOut";
        // This one took a little time to figure out. The last +10 is there because of the
        // Spacing="5" in the StackLayout plus the margin of 5. It works with any screen size.

        // Not on Emulator
        //var translateToCoordinateY = Height - dotNetBotImage.Height - (dotNetBotImage.Height / 2) + 10;
        //await dotNetBotImage.TranslateTo(0, translateToCoordinateY, 2000, Easing.BounceOut);
        await dotNetBotImage.TranslateTo(0, -200, 2000, Easing.BounceOut);
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        ResetProperties();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    #endregion Private Methods
}
