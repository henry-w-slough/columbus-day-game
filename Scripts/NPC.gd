extends CharacterBody2D

@export var dialogue_resource: DialogueResource
@export var dialogue_cue: String = ""

@onready var sprite: AnimatedSprite2D = $AnimatedSprite2D


func _ready() -> void:
	sprite.play("idle")


func _input_event(_viewport: Viewport, event: InputEvent, _shape_idx: int) -> void:
	if dialogue_resource == null:
		return
	if event is InputEventMouseButton and event.button_index == MOUSE_BUTTON_LEFT and event.pressed:
		DialogueManager.show_dialogue_balloon(dialogue_resource, dialogue_cue)
