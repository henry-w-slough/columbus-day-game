using Godot;


public partial class Player : CharacterBody2D
{
	// Components
	private AnimatedSprite2D sprite;

	// Movement
	[Export]
	public float MoveSpeed = 100.0f;


	public override void _Ready()
	{
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}


	public override void _PhysicsProcess(double delta)
	{
		movement();
		animation();
		
		MoveAndSlide();
	}


	public void movement()
	{
		Vector2 inputDirection = Input.GetVector("moveLeft", "moveRight", "moveUp", "moveDown");
		Velocity = inputDirection * MoveSpeed;
	}

	
	public void animation()
	{

		if (Velocity == Vector2.Zero)
		{
			sprite.Play("idle");
		}
		else
		{
			sprite.Play("walk");
		}


		if (Velocity.X < 0)
		{
			sprite.FlipH = true;
		}
		if (Velocity.X > 0)
		{
			sprite.FlipH = false;
		}
	}

}
