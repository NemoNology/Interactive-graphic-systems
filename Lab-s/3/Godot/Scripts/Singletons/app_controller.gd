extends Node

func _enter_tree():
	get_viewport().size_changed.connect(_on_viewport_size_changed)
	
func _on_viewport_size_changed():
	var viewport = get_viewport()
	viewport.content_scale_size = viewport.size
