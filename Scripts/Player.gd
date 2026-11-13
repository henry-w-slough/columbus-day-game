extends CharacterBody2D

@export var move_speed: float = 100.0

@onready var sprite: AnimatedSprite2D = $AnimatedSprite2D

var is_dialogue_active: bool = false


func _ready() -> void:
	DialogueManager.dialogue_started.connect(_on_dialogue_started)
	DialogueManager.dialogue_ended.connect(_on_dialogue_ended)


func _exit_tree() -> void:
	DialogueManager.dialogue_started.disconnect(_on_dialogue_started)
	DialogueManager.dialogue_ended.disconnect(_on_dialogue_ended)


func _physics_process(_delta: float) -> void:
	if is_dialogue_active:
		velocity = Vector2.ZERO
	else:
		_update_movement()
	_update_animation()
	move_and_slide()


func _update_movement() -> void:
	var input_direction := Input.get_vector("moveLeft", "moveRight", "moveUp", "moveDown")
	velocity = input_direction * move_speed


func _update_animation() -> void:
	if velocity == Vector2.ZERO:
		sprite.play("idle")
	else:
		sprite.play("walk")

	if velocity.x < 0:
		sprite.flip_h = true
	elif velocity.x > 0:
		sprite.flip_h = false


func _on_dialogue_started(_resource: DialogueResource) -> void:
	is_dialogue_active = true


func _on_dialogue_ended(_resource: DialogueResource) -> void:
	is_dialogue_active = false
