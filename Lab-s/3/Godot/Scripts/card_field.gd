class_name CardField extends Container

const CARDS_SEPARATION_LENGTH: int = 8

@export_category("Cards field")
@export var card_pairs_amount: int = 2
signal card_toogled(id: int, is_face_up: bool)

func _ready():
	item_rect_changed.connect(_update_cards_positions)
	reset_cards()

func _some_card_toogled(id: int, is_face_up: bool):
	card_toogled.emit(id, is_face_up)

func remove_cards_by_id(id: int):
	for c in get_children():
		if c is Card and c.id == id:
			remove_child(c)

func _cards_fill_with_shufle():
	# remove possible old cards
	for c in get_children():
		remove_child(c)
	# fill by new cards
	var cards: Array[Card] = []
	for i in range(card_pairs_amount):
		for j in range(2):
			var card_buffer: Card = Card.new()
			card_buffer.id = i + 1
			card_buffer.toogled.connect(_some_card_toogled)
			cards.append(card_buffer)
	# Shuffle cards
	cards.shuffle()
	# fill node by cards
	for card in cards:
		add_child(card)

func flip_cards_to(to_state: bool, with_pause: bool=false):
	var flipping_cards: Array[Card] = []
	# Determinating what're cards needs to be flipped
	for c: Card in get_children():
		if c.is_card_up != to_state:
			flipping_cards.append(c)
	# Flip cards
	if with_pause:
		await get_tree().create_timer(.4).timeout
	for c: Card in flipping_cards:
		c.toogle(false)

func _update_cards_positions():
	var current_width: float = CARDS_SEPARATION_LENGTH
	var current_height: float = CARDS_SEPARATION_LENGTH
	for c: Card in get_children():
		c.position = Vector2(current_width, current_height)
		current_width += c.size.x + CARDS_SEPARATION_LENGTH
		if current_width >= size.x:
			current_width = CARDS_SEPARATION_LENGTH
			current_height += CARDS_SEPARATION_LENGTH + c.size.y

func reset_cards():
	_cards_fill_with_shufle()
	_update_cards_positions()
