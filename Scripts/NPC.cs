using Godot;
using System;

public partial class NPC : CharacterBody2D
{
	// Components
	private AnimatedSprite2D sprite;

	public override void _Ready()
	{
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        sprite.Play("idle");
	}
}
