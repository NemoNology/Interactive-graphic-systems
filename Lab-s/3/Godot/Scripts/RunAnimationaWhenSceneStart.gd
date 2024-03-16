extends AnimationPlayer


func _ready():
	for anim in get_animation_list():
		play(anim)
