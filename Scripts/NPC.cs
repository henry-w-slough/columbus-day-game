using Godot;
using System;
using DialogueManagerRuntime;

public partial class NPC : CharacterBody2D
{
	[Export]
	public Resource DialogueResource { get; set; }

	[Export]
	public string DialogueCue { get; set; } = "";

	// Components
	private AnimatedSprite2D sprite;

	public override void _Ready()
	{
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        sprite.Play("idle");
	}

	public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
	{
		if (DialogueResource == null
			|| @event is not InputEventMouseButton mouseButton
			|| mouseButton.ButtonIndex != MouseButton.Left
			|| !mouseButton.Pressed)
		{
			return;
		}

		DialogueManager.ShowDialogueBalloon(DialogueResource, DialogueCue);
	}
}
