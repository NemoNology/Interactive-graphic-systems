class_name CardField extends MarginContainer

@export_category("Cards field")
@export var card_pairs_amount: int = 2
var box: HFlowContainer = HFlowContainer.new();
signal card_toogled(id: int, is_face_up: bool)

func _init():
	box.add_theme_constant_override("h_separation", 8)
	box.add_theme_constant_override("v_separation", 8)
	add_theme_constant_override("margin_bottom", 8)
	add_theme_constant_override("margin_left", 8)
	add_theme_constant_override("margin_right", 8)
	add_theme_constant_override("margin_top", 8)
	add_child(box)

func _ready():
	var cards: Array[Card] = []
	var card_buffer: Card
	for i in range(card_pairs_amount):
		for j in range(2):
			card_buffer = Card.new()
			card_buffer.id = i + 1
			card_buffer.toogled.connect(some_card_toogled)
			cards.append(card_buffer)
	cards.shuffle()
	for card in cards:
		box.add_child(card)

func some_card_toogled(id: int, is_face_up: bool):
	card_toogled.emit(id, is_face_up)

func remove_cards_by_id(id: int):
	for c in box.get_children():
		if c is Card and c.id == id:
			box.remove_child(c)

func cards_shufle_and_fill():
	var children: Array[Node] = box.get_children()
	for c in children:
		box.remove_child(c)
		
func flip_cards_to(to_state: bool):
	var cards_amount: int = box.get_child_count() - 1
	for c: Card in box.get_children() as Array[Card]:
		if c.is_card_up != to_state:
			c.toogle(false)
