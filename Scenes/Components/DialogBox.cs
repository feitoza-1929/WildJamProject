using Godot;
using System;
using System.Collections.Generic;

public class DialogBox : ColorRect
{
    [Export] private string dialogPath;
    [Export] private float textSpeed = 0.05f;
    private Timer _timer;
    private RichTextLabel _text;
    private RichTextLabel _name;
    private Dialog[] dialog;
    private bool isFinished;
    private int phraseIndex = 0;

    public override void _Ready()
    {
        _timer = GetNode<Timer>("Timer");
        _timer.WaitTime = textSpeed;

        _text = GetNode<RichTextLabel>("Text");
        _text.GetChild<VScrollBar>(0).RectScale = Vector2.Zero;

        _name = GetNode<RichTextLabel>("Name");

        dialog = 
            GetJsonFile<List<Dialog>>.GetData(dialogPath).ToArray()
            ?? throw new NullReferenceException($"Dialog is null {dialogPath}");

        NextPhrase();
    }

    public override void _Process(float delta)
    {
        SkipPhrase();
    }

    private async void NextPhrase()
    {
        if(phraseIndex >= dialog.Length - 1)
            QueueFree();

        _name.BbcodeText = dialog[phraseIndex].Name;
        _text.BbcodeText = dialog[phraseIndex].Text;

        _text.VisibleCharacters = 0;

        isFinished = false;

        while (_text.VisibleCharacters < _text.Text.Length())
        {
            _text.VisibleCharacters += 1;
            _timer.Start();
            await ToSignal(_timer, "timeout");
        }

        isFinished = true;
        phraseIndex += 1;

    }

    private void SkipPhrase()
    {
        if (Input.IsActionJustPressed("ui_accept"))
        {
            if (isFinished)
                NextPhrase();
            else
                _text.VisibleCharacters = _text.Text.Length();
        }
    }
}
