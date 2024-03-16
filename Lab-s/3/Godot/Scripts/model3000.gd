class_name Model3000 extends RigidBody3D

var dispose_timer: Timer = Timer.new()
@export_category("Model3000")
@export var mesh: MeshInstance3D
@export var dispose_seconds: int = 8

func _init():
	dispose_timer.wait_time = dispose_seconds
	dispose_timer.autostart = true
	dispose_timer.timeout.connect(on_timeout)

func load_model():
	if mesh == null:
		return
	mesh.scale = scale
	mesh.create_convex_collision()
	var collision_shape: CollisionShape3D
	var mesh_doby = mesh.get_child(0)
	for mesh_body_child in mesh_doby.get_children():
		if mesh_body_child is CollisionShape3D:
			collision_shape = mesh_body_child.duplicate()
			collision_shape.scale = scale
			break
	mesh.remove_child(mesh_doby)
	add_child(mesh)
	add_child(collision_shape)

func _ready():
	load_model()
	add_child(dispose_timer)

func on_timeout():
	queue_free()
